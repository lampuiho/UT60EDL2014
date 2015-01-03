using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UT60EDL2014
{
    public interface ITimedObject
    {
        DateTime Time { get; }
    }
    public interface IParseable<T>
    {
        T Parse();
    }
    public interface IPacket
    {
        IList<byte> Data { get; }
    }
    class UT60EPackageReceivedEventArgs : EventArgs
    {
        public readonly UT60EPacket package;
        public UT60EPackageReceivedEventArgs(UT60EPacket package)
            : base()
        {
            this.package = package;
        }
    }
    /// <summary>
    /// Wrapper for a data package and time stamp
    /// </summary>
    class UT60EPacket : IParseable<IUT60EData>
    {
        readonly System.Collections.ObjectModel.ReadOnlyCollection<byte> data;
        readonly DateTime time;
        public DateTime Time
        {
            get
            {
                return this.time;
            }
        }
        public IList<byte> Data
        {
            get
            {
                return data;
            }
        }
        public UT60EPacket(DateTime time, IEnumerable<byte> bytes)
        {
            this.time = time;
            this.data = bytes.Reverse().ToList().AsReadOnly();
        }
        public IUT60EData Parse()
        {
            UT60EDataParser parser = new UT60EDataParser(this);
            IUT60EData data;
            try
            {
                data = parser.Parse();
            }
            catch
            {
                data = null;
            }
            return data;
        }
    }
    /// <summary>
    /// Package data and keep hold of those packages
    /// </summary>
    class UT60EPacketReceiver : IUT60EDataSender, IDisposable
    {
        System.IO.Ports.SerialPort sp;
        public int byte_error_count { get; set; }
        public int byte_received_count { get; set; }
        Stack<byte> buffer = new Stack<byte>(14);
        DateTime current_package_time_stamp;
        public event EventHandler DataReady;

        public UT60EPacketReceiver(string port_name)
        {
            this.sp = new System.IO.Ports.SerialPort(port_name, 2400, System.IO.Ports.Parity.None, 8, System.IO.Ports.StopBits.One);
            sp.DtrEnable = true;
            sp.ReceivedBytesThreshold = 1;
            this.sp.DataReceived += OnDataReceive;
            sp.Open();
        }
        void OnDataReceive(object sender, EventArgs e)
        {
            int size = sp.BytesToRead;
            if (size > 0)
            {
                byte[] buf = new byte[size];
                sp.Read(buf, 0, size);
                DataReceived(buf);
            }
        }
        /// <summary>
        /// Process bytes read from port buffer.
        /// </summary>
        /// <param name="buf">Bytes received from ports.</param>
        void DataReceived(byte[] buf)
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

                byte_received_count += buf.Length;

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
            int buffer_index = buffer.Count;
                //buffer.Count == 0 ? 0 : ((buffer.Peek() & 0xF0) >> 4);
            int buf_upper_boundary = Math.Min(start_index + 14 - buffer_index, buf.Length);

            for (int i = start_index; i < buf_upper_boundary; ++i)
            {
                if ((((buf[i] & 0xF0) >> 4) - 1) == buffer_index)
                {
                    buffer.Push(buf[i]);
                    buffer_index++;
                }
                else
                {
                    byte_error_count++;
                    if (buffer_index > 0)
                    {
                        buffer.Clear();
                        buffer_index = 0;
                        DataHandler(buf, i + 1);
                        return;
                    }
                }
            }
            if (buffer.Count > 14)
            {
                buffer.Clear();
                throw new InvalidOperationException();
            }
            else if (buffer.Count == 14)
            {
                OnDataReady();
                if (buf.Length > buf_upper_boundary)
                    DataHandler(buf, buf_upper_boundary);
            }
        }
        void OnDataReady()
        {
            UT60EPacket package = new UT60EPacket(current_package_time_stamp, buffer);
            buffer.Clear();
            EventArgs e = new UT60EPackageReceivedEventArgs(package);
            foreach (EventHandler event_handler in DataReady.GetInvocationList())
                event_handler.BeginInvoke(this, e, null, null);
        }
        public void Dispose()
        {
            sp.Dispose();
        }
    }
}
