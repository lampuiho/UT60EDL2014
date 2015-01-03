using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace UT60EDL2014
{
    interface ILogLimitHandler
    {
        event EventHandler HitLogLimit;
    }
    /// <summary>
    /// Record data in csv file
    /// </summary>
    class UT60EDataLogger : CsvFile.CsvFileWriter, IControllable
    {
        public UT60EDataLogger(List<UT60ESerialPortSettings> serial_port_settings, UT60ELogSettings log_settings)
            : base(GetPath(log_settings.start_time))
        {
            WriteHeader(serial_port_settings, log_settings.start_time);
        }
        public void Connect(IUT60EDataSender sender)
        {
            sender.DataReady += this.OnDataReady;
        }
        public void Disconnect(IUT60EDataSender sender)
        {
            sender.DataReady -= this.OnDataReady;
        }
        static string GetPath(DateTime now)
        {
            string path = Path.Combine(Properties.Settings.Default.DefaultPath == "" ?
                System.Windows.Forms.Application.StartupPath :
                Properties.Settings.Default.DefaultPath, now.ToString("yyyy-MM-ddTHH.mm.ss") + ".csv");
            return path;
        }
        void WriteHeader(List<UT60ESerialPortSettings> serial_port_settings, DateTime start_time)
        {
            List<object> columns = new List<object>();
            columns.Add("Datetime of Log:");
            columns.Add(start_time.ToString("yyyy-MM-ddTHH:mm:ss.fffffffzzz"));
            WriteRow(columns);
            columns = new List<object>();
            columns.Add("Time offset(ms)");
            foreach (var port in serial_port_settings)
            {
                columns.Add(port.name + " (" + port.log_unit + ")");
            }
            WriteRow(columns);
        }
        void OnDataReady(object sender, EventArgs e)
        {
            List<object> columns = sender as List<object>;
            WriteRow(columns);
        }
    }

}
