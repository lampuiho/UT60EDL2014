using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UT60EDL2014
{
    public interface IUT60EDataHandler
    {
        /// <summary>
        /// Sender is normally data package. Must handle null case.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void DataReady(object sender, EventArgs e);
    }

    enum Modifier { n = -3, u, m, k = 1, M = 2 };
    public partial class UT60EDisplayForm : Form, IUT60EDataHandler
    {
        GetRecordFrequencyFunctor freq_func = new GetRecordFrequencyFunctor();
        UT60EDataLogger data_logger;
        UT60EPortDataPacker data_handler;
        System.IO.Ports.SerialPort sp;
        DataTable dt;
        public UT60EDisplayForm(string port_name, string unit, int limit_type, int log_limit)
        {
            InitializeComponent();
            DateTime now = DateTime.Now;
            textBoxDate.Text = now.ToString("yyyy-MM-ddTHH.mm.ss.ffff") + "Unit: " + unit;
            data_logger = new UT60EDataLogger(this, port_name, unit, now, limit_type, log_limit);
            data_handler = new UT60EPortDataPacker(this, data_logger);
            this.sp = new System.IO.Ports.SerialPort(port_name, 2400, System.IO.Ports.Parity.None, 8, System.IO.Ports.StopBits.One);
            sp.DtrEnable = true;
            sp.ReceivedBytesThreshold = 2;
            sp.Open();
            this.sp.DataReceived += OnDataReceive;
            dt = new DataTable("UT60EData");
            dt.Columns.Add("Time Offset (ms)", typeof(double));
            dt.Columns.Add("Value", typeof(int));
            dt.Columns.Add("scale", typeof(int));
            this.dataGridView1.DataSource = dt;
        }

        private void UT60EDisplayForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            sp.Close();
        }

        private void OnDataReceive(object sender, EventArgs e)
        {
            int size = sp.BytesToRead;
            if (size > 0)
            {
                byte[] buf = new byte[size];
                sp.Read(buf, 0, size);
                data_handler.DataReceived(buf);
            }
        }

        public void DataReady(object sender, EventArgs e)
        {
            UT60EDataBase data = (UT60EDataBase)sender;
            this.BeginInvoke((Action)(() =>
            {
                if (data == null)
                    textBoxDate.Text = "----";
                else
                {
                    textBoxValue.Text = data.ToString();
                    textBoxFrequency.Text = freq_func.run(data.time).ToString();
                }
            }));
        }

        public void OnWrite(object sender, EventArgs e)
        {
            this.BeginInvoke((Action)(() => { dt.Rows.Add(((List<object>)sender).ToArray()); }));
        }

        public void OnHitLogLimit(object sender, EventArgs e)
        {
            data_handler.dataReadyEventHandler -= data_logger.DataReady;
            data_logger.Dispose();
            data_logger = null;
        }

        class GetRecordFrequencyFunctor
        {
            Action<DateTime> func;
            int count;
            DateTime last_datetime;
            double result = 0;

            public GetRecordFrequencyFunctor()
            {
                func = state_begin;
            }

            public double run(DateTime input)
            {
                func(input);
                return 1000*count/result;
            }

            void state_begin(DateTime dt)
            {
                last_datetime = dt;
                func = state_last_datetime_set;
            }

            void state_last_datetime_set(DateTime dt)
            {
                result += (dt - last_datetime).TotalMilliseconds;
                last_datetime = dt;
                count += 1;
            }

        }
    }
}
