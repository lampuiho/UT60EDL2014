using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UT60EDL2014
{
    enum log_units { V, A, C, F, Ohm, Hz };
    public interface ISaveFile
    {
        string save_path { get; }
    }
    public class UT60ELogSettings : ISaveFile
    {
        public UT60ELogSettings(int log_type, int log_limit, int log_freq_m, string save_path, DateTime start_time)
        {
            this.log_limit = log_limit;
            this.log_type = log_type;
            this.log_freq_m = log_freq_m;
            this.save_path = save_path;
            this.start_time = start_time;
        }
        public int log_limit { get; private set; }
        public int log_type { get; private set; }
        public int log_freq_m { get; private set; }
        public string save_path { get; private set; }
        public DateTime start_time { get; private set; }
    }
    public class UT60ESerialPortSettings
    {
        public UT60ESerialPortSettings(string name, string port_name, int log_unit)
        {
            this.port_name = port_name;
            this.log_unit = log_unit;
            this.name = name;
        }
        public string name { get; private set; }
        public string port_name { get; private set; }
        public int log_unit { get; private set; }
    }
    public class UT60EMonitorSettings
    {
        public UT60EMonitorSettings(UT60ELogSettings log_settings, IList<UT60ESerialPortSettings> port_settings)
        {
            this.port_settings = new System.Collections.ObjectModel.ReadOnlyCollection<UT60ESerialPortSettings>(port_settings);
            this.log_settings = log_settings;
        }
        public readonly IList<UT60ESerialPortSettings> port_settings;
        public readonly UT60ELogSettings log_settings;
    }
}
