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
    public partial class UT60EDisplayForm : Form, IUserView
    {

        UT60EMainController controller;
        System.Data.DataTable dt;
        public UT60EDisplayForm()
        {
            InitializeComponent();
            dt = new System.Data.DataTable("UT60ELogData");
            dt.Columns.Add("Time Offset (ms)", typeof(double));
            dataGridView1.DataSource = dt;
        }
        public void Connect(IUT60EDataSender data_sender)
        {
            data_sender.DataReady += this.OnDataReady;
        }
        public void Disconnect(IUT60EDataSender data_sender)
        {
            data_sender.DataReady -= this.OnDataReady;
        }
        public void Connect(UT60EMainController controller)
        {
            this.controller = controller;
            controller.LoggingStarted += this.OnLoggingStarted;
            controller.LoggingStopped += this.OnLoggingStopped;
        }
        public void Disconnect(UT60EMainController controller)
        {
            controller.LoggingStarted -= this.OnLoggingStarted;
            controller.LoggingStopped -= this.OnLoggingStopped;
            this.controller = null;
        }
        public IControllable Add(UT60ESerialPortSettings serial_port_setting)
        {
            dt.Columns.Add(serial_port_setting.port_name + " (" + serial_port_setting.log_unit + ")");
            UT60EMeterDisplay newDisplay = new UT60EMeterDisplay();
            this.meterFlowLayoutPanel.Controls.Add(newDisplay);
            return newDisplay;
        }
        private void UT60EDisplayForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            controller.Dispose();
        }
        void OnDataReady(object sender, EventArgs e)
        {
            this.BeginInvoke((Action)(() =>
            {
                /*if (dt.Rows.Count > 150)
                {
                    dt.Rows.Clear();
                }*/
                dt.Rows.Add(((List<object>)sender).ToArray());
            }));
        }
        void OnLoggingStopped(object sender, EventArgs e)
        {
            this.BeginInvoke((Action)(() =>
            {
                stopLoggingToolStripMenuItem.Text = "Start Logging";
            }));
        }
        void OnLoggingStarted(object sender, EventArgs e)
        {
            this.BeginInvoke((Action)(() =>
            {
                stopLoggingToolStripMenuItem.Text = "Stop Logging";
                dt.Clear();
                UT60ELogSettings log_settings = sender as UT60ELogSettings;
                this.Text += "Log started at: " + log_settings.start_time.ToString("HH.mm.ss.ffffff");
            }));
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (controller.IsLogging())
            {
                controller.StopLogging();
            }
            else
            {
                UT60EConfigWizard config = new UT60EConfigWizard();
                if (config.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    controller.SetupLogging(config.log_setting);
                }
            }
        }
    }
    public interface IUserView : IControllable
    {
        IControllable Add(UT60ESerialPortSettings serial_port_setting);
    }
    public interface IUT60EDataSender
    {
        event EventHandler DataReady;
    }
    class UT60EDataReadyEventArgs : EventArgs
    {
        public IUT60EData data { get; private set; }
        public UT60EDataReadyEventArgs(IUT60EData data)
        {
            this.data = data;
        }
    }
    enum Modifier { n = -3, u, m, k = 1, M = 2 };
}
