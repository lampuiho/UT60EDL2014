using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UT60EDL2014
{
    public interface IControllable
    {
        void Connect(IUT60EDataSender controller);
        void Disconnect(IUT60EDataSender controller);
    }
    public interface ILogControl
    {
        void SetupLogging(UT60ELogSettings log_settings);
        bool IsLogging();
        void StopLogging();
    }
    public class UT60EMainController : ILogControl, IDisposable
    {
        class LogLimiter : ILogLimitHandler
        {
            int log_limit;
            EventHandler limit;
            public event EventHandler HitLogLimit;
            internal LogLimiter(IUT60EDataSender logger, UT60ELogSettings log_settings)
            {
                this.log_limit = log_settings.log_limit;
                switch (log_settings.log_limit)
                {
                    case 0:
                        this.limit = time_limit;
                        break;
                    default:
                        this.limit = number_limit;
                        break;
                }
                logger.DataReady += limit;
            }
            void time_limit(object sender, EventArgs e)
            {
                if ((double)((List<object>)sender)[0] / 1000 > log_limit)
                    HitLogLimit(sender, e);
            }
            void number_limit(object sender, EventArgs e)
            {
                log_limit -= 1;
                if (log_limit <= 0)
                    HitLogLimit(sender, e);
            }
        }

        public event EventHandler LoggingStarted;
        public event EventHandler LoggingStopped;

        UT60ELogSettings log_settings;
        List<UT60ESerialPortSettings> serial_port_settings;
        ILogLimitHandler log_limiter;
        UT60EDataLogger data_logger;
        UT60ELogDataController log_data_controller;
        List<UT60EDataController> data_controllers;
        public UT60EMainController(IUserView view, List<UT60ESerialPortSettings> serial_port_settings, UT60ELogSettings log_settings)
        {
            this.log_settings = log_settings;
            this.serial_port_settings = serial_port_settings;
            data_controllers = new List<UT60EDataController>(serial_port_settings.Count);
            foreach (var port in serial_port_settings)
            {
                UT60EPacketReceiver package_receiver = new UT60EPacketReceiver(port.port_name);
                var display = view.Add(port);
                var data_controller = new UT60EDataController(port, package_receiver);
                display.Connect(data_controller);
                data_controllers.Add(data_controller);
            }

            if (log_settings != null)
            {
                InitialiseLogging();
            }
        }
        void InitialiseLogging()
        {
            DateTime start_time = log_settings.start_time;
            var span = (start_time - DateTime.Now);
            if (span.CompareTo(TimeSpan.Zero) < 0)
            {
                span = TimeSpan.Zero;
            }
            System.Threading.Timer timer = new System.Threading.Timer(StartLogging, null, span, TimeSpan.FromMilliseconds(-1));
            log_data_controller = new UT60ELogDataController(data_controllers, log_settings);
            data_logger = new UT60EDataLogger(serial_port_settings, log_settings);
            log_limiter = new LogLimiter(log_data_controller, log_settings);
        }
        public void SetupLogging(UT60ELogSettings log_settings)
        {
            this.log_settings = log_settings;
            InitialiseLogging();
        }
        public bool IsLogging()
        {
            return log_data_controller.IsLogging();
        }
        void StartLogging()
        {
            LoggingStarted(log_settings, null);
            log_limiter.HitLogLimit += this.OnHitLogLimit;
            data_logger.Connect(log_data_controller);
        }
        public void StopLogging()
        {
            if (data_logger != null)
            {
                LoggingStopped(null, null);
                data_logger.Disconnect(log_data_controller);
                data_logger.Dispose();
                data_logger = null;
                log_data_controller.Dispose();
                log_data_controller = null;
            }
        }
        public void Dispose()
        {
            StopLogging();
        }
        void StartLogging(object state)
        {
            StartLogging();
        }
        void OnHitLogLimit(object sender, EventArgs e)
        {
            StopLogging();
            /*
            int total_byte_error_count = 0;
            int total_byte_received_count = 0;
            foreach (var receiver in data_packages.Keys)
            {
                total_byte_error_count += receiver.byte_error_count;
                total_byte_received_count += receiver.byte_received_count;
            }
            Console.WriteLine(String.Format("Total Byte Received: {0}, Total Parse Error Count {1}, Total Byte Error Count: {2}", data_handler.byte_received_count, parse_error_count, data_handler.byte_error_count));
             */
        }
    }
    class UT60ELogDataController : IUT60EDataSender, IDisposable
    {
        public event EventHandler DataReady;

        int packet_count;
        double period;
        DateTime start_time, period_end;
        Dictionary<string, IUT60EData> data_keeper;
        public UT60ELogDataController(List<UT60EDataController> data_controllers, UT60ELogSettings log_settings)
        {
            this.period = 0.26 * log_settings.log_freq_m;
            this.start_time = log_settings.start_time;
            data_keeper = new Dictionary<string, IUT60EData>(data_controllers.Count);
            foreach(var controller in data_controllers)
            {
                controller.DataReady += this.OnDataReady;
                data_keeper.Add(controller.id, null);
            }
        }
        public bool IsLogging()
        {
            return DataReady.GetInvocationList().Count() > 0;
        }
        void NewPeriod(IUT60EData data)
        {
            period_end = data.Time.AddSeconds(period);
        }
        void CheckPeriod(IUT60EData data)
        {
            if (packet_count++ == 0 || data.Time > period_end)
            {
                NewPeriod(data);
            }
        }
        List<object> PrepareData(IEnumerable<IUT60EData> package)
        {
            DateTime last_received_time = start_time;
            List<object> columns = new List<object>(1 + package.Count());
            columns.Add((double)0);
            foreach (var data in package)
            {
                if (data.Time > last_received_time)
                    last_received_time = data.Time;
                columns.Add(data.Value * Math.Pow(10, data.Scale));
            }
            columns[0] = (last_received_time - start_time).TotalMilliseconds;
            return columns;
        }
        void OnDataReady(object sender, EventArgs e)
        {
            lock (data_keeper)
            {
                IUT60EData data = (e as UT60EDataReadyEventArgs).data;
                if (data != null)
                {
                    CheckPeriod(data);
                    data_keeper[(sender as UT60EDataController).id] = (e as UT60EDataReadyEventArgs).data;
                    if (data_keeper.Count == packet_count)
                    {
                        DataReady(PrepareData(data_keeper.Values), null);
                        packet_count = 0;
                    }
                }
            }
        }
        public void Dispose()
        {
            foreach (EventHandler e in DataReady.GetInvocationList())
            {
                DataReady -= e;
            }
        }
    }
}
