using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UT60EDL2014
{
    /// <summary>
    /// Wrapper for a data package and time stamp
    /// </summary>
    class UT60EPortDataPackage
    {
        public byte[] data = new byte[14];
        public DateTime time_stamp = DateTime.Now;
    }

    /// <summary>
    /// Package data and keep hold of those packages
    /// </summary>
    class UT60EPortDataPacker
    {
        Stack<byte> buffer = new Stack<byte>(14);
        DateTime current_package_time_stamp;
        public event EventHandler dataReadyEventHandler;

        public UT60EPortDataPacker(params IUT60EDataHandler[] dataHandlers)
        {
            foreach (var handler in dataHandlers)
                this.dataReadyEventHandler += handler.DataReady;
        }

        /// <summary>
        /// Process bytes read from port buffer.
        /// </summary>
        /// <param name="buf">Bytes received from ports.</param>
        public void DataReceived(byte[] buf)
        {
            lock (buffer)
            {
                DateTime now = DateTime.Now;
                if (current_package_time_stamp != null)
                {
                    if ((now - current_package_time_stamp).TotalMilliseconds > 500)
                        buffer.Clear();
                }

                if (buffer.Count == 0)
                    current_package_time_stamp = now;

                DataHandler(buf, 0);
            }
        }

        /// <summary>
        /// Recursively process all bytes read from port buffer
        /// </summary>
        /// <param name="buf"></param>
        /// <param name="start_index"></param>
        void DataHandler(byte[] buf, int start_index)
        {
            int buffer_index = buffer.Count == 0 ? 0 : ((buffer.Peek() & 0xF0) >> 4);
            int buf_upper_boundary = Math.Min(start_index + 14 - buffer_index, buf.Length);

            for (int i = start_index; i < buf_upper_boundary; ++i)
            {
                if ((((buf[i] & 0xF0) >> 4) - 1) == buffer_index)
                {
                    buffer.Push(buf[i]);
                    buffer_index++;
                }
                else if (buffer_index > 0)
                {
                    buffer.Clear();
                    buffer_index = 0;
                    DataHandler(buf, i + 1);
                    return;
                }
            }
            if (buffer.Count > 14)
            {
                buffer.Clear();
                throw new InvalidOperationException();
            }
            else if (buffer.Count == 14)
            {
                DataReady();
                if (buf.Length > buf_upper_boundary)
                    DataHandler(buf, buf_upper_boundary);
            }
        }

        void DataReady()
        {
            UT60EPortDataPackage package = new UT60EPortDataPackage();
            for (int i = package.data.Length - 1; i >= 0; --i)
                package.data[i] = buffer.Pop();
            package.time_stamp = current_package_time_stamp;
            UT60EDataParser parser = new UT60EDataParser(package);
            UT60EDataBase data;
            try
            {
                data = parser.Parse();
            }
            catch (Exception e)
            {
                /*
                switch (e.GetType().ToString())
                {
                    default:
                        break;
                }*/
                data = null;
            }
            var receivers = dataReadyEventHandler.GetInvocationList();
            foreach (EventHandler receiver in receivers)
            {
                receiver.BeginInvoke(data, null, null, null);
            }
        }
    }
}
