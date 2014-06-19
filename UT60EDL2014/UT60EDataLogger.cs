using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace UT60EDL2014
{
    /// <summary>
    /// Record data in csv file
    /// </summary>
    class UT60EDataLogger : CsvFile.CsvFileWriter, IUT60EDataHandler
    {
        DateTime base_time;
        event EventHandler writeHandler;
        LogLimiter log_limiter;
        string log_unit;

        class LogLimiter
        {
            int log_limit;
            public EventHandler limit { get; private set; }
            public event EventHandler hitLimitHandler;
            internal LogLimiter(int limit_type, int log_limit)
            {
                this.log_limit = log_limit;
                switch (limit_type)
                {
                    case 0:
                        this.limit = time_limit;
                        break;
                    default:
                        this.limit = number_limit;
                        break;
                }
            }

            void time_limit(object sender, EventArgs e)
            {
                if ((double)((List<object>)sender)[0] > log_limit)
                    hitLimitHandler(sender, e);
            }

            void number_limit(object sender, EventArgs e)
            {
                log_limit -= 1;
                if (log_limit <= 0)
                    hitLimitHandler(sender,e);
            }
        }
        public UT60EDataLogger(UT60EDisplayForm parent, string path, string unit, DateTime now, int log_limit_type, int log_limit)
            : base(GetPath(path, now))
        {
            base_time = now;
            log_unit = unit;
            log_limiter = new LogLimiter(log_limit_type, log_limit);
            writeHandler += log_limiter.limit;
            log_limiter.hitLimitHandler += parent.OnHitLogLimit;
            writeHandler += parent.OnWrite;
            WriteHeader();

        }
        static string GetPath(string path, DateTime now)
        {
            path = Path.Combine(System.Windows.Forms.Application.StartupPath, path + now.ToString("yyyy-MM-ddTHH.mm.ss") + ".log");
            return path;
        }
        void WriteHeader()
        {

            List<object> columns = new List<object>();
            columns.Add("Datetime of Log");
            columns.Add("Unit");
            WriteRow(columns);
            columns = new List<object>();
            columns.Add(base_time.ToString("yyyy-MM-ddTHH:mm:ss.fffffffzzz"));
            columns.Add(log_unit);
            WriteRow(columns);
            columns = new List<object>();
            columns.Add("Time offset(ms)");
            columns.Add("Value");
            columns.Add("Scale");
            WriteRow(columns);
        }
        public void DataReady(object sender, EventArgs e)
        {
            UT60EDataBase data = (UT60EDataBase)sender;
            if (log_unit == data.getUnit()) { 
            List<object> columns = new List<object>(3);
            columns.Add((data.time - base_time).TotalMilliseconds);
            columns.Add(data.value);
            columns.Add(data.scale);
            WriteRow(columns);
            writeHandler(columns, e);
            }
        }
    }
}
