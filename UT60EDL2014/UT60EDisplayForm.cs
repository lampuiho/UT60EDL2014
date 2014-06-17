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
    enum Modifier { M = -2, k = -1, m = 1, u = 2, n = 3 };
    public partial class UT60EDisplayForm : Form
    {
        UT60EPortDataPacker data_handler;
        System.IO.Ports.SerialPort sp;
        DataTable dt;
        public UT60EDisplayForm()
        {
            InitializeComponent();
            data_handler = new UT60EPortDataPacker(UpdateDisplay);
            this.sp = new System.IO.Ports.SerialPort("COM1", 2400, System.IO.Ports.Parity.None, 8, System.IO.Ports.StopBits.One);
            sp.DtrEnable = true;
            sp.ReceivedBytesThreshold = 2;
            sp.Open();
            this.sp.DataReceived += OnDataReceive;
            dt = new DataTable("UT60EData");
            dt.Columns.Add("Time", typeof(DateTime));
            dt.Columns.Add("Value", typeof(Decimal));
            dt.Columns.Add("Unit", typeof(String));
            this.dataGridView1.DataSource = dt;
            this.dataGridView1.Columns[0].DefaultCellStyle.Format = "yyyy'/'MM'/'dd HH:mm:ss:ffff";
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

        private void UpdateDisplay(object sender, EventArgs e)
        {
            UT60EDataBase data = (UT60EDataBase)sender;
            this.BeginInvoke((Action)(() =>
            {
                textBoxValue.Text = data.ToString();
                dt.Rows.Add(new Object[] { data.time, data.value * Math.Pow(10, -data.scale), data.getUnit() });
            }));
        }
    }
}
