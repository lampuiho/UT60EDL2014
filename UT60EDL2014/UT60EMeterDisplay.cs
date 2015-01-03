using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UT60EDL2014
{
    public partial class UT60EMeterDisplay : UserControl, IControllable
    {
        class UpdateFrequencyRecorder
        {
            Action<DateTime> func;
            int count;
            DateTime last_datetime;
            double result = 0;

            public UpdateFrequencyRecorder()
            {
                func = state_begin;
            }
            public double run(DateTime input)
            {
                func(input);
                return 1000 * count / result;
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

                if (result > 100000)
                    reset();
            }
            void reset()
            {
                result = result / count;
                count = 1;
            }
        }
        UpdateFrequencyRecorder freq_func = new UpdateFrequencyRecorder();
        public UT60EMeterDisplay()
        {
            InitializeComponent();
        }
        public void Connect(IUT60EDataSender data_sender)
        {
            UT60EDataController data_controller = (data_sender as UT60EDataController);
            textBoxPort.Text = data_controller.id;
            textBoxUnit.Text = ((log_units)(data_controller.unit)).ToString();
            data_sender.DataReady += OnDataReady;
        }
        public void Disconnect(IUT60EDataSender data_sender)
        {
            data_sender.DataReady -= OnDataReady;
        }
        void OnDataReady(object sender, EventArgs e)
        {
            IUT60EData data = (e as UT60EDataReadyEventArgs).data;
            if (data == null)
            {
                this.textBoxValue.Text = "----";
            }
            else
            {
                this.textBoxValue.Text = data.ToString();
                this.textBoxUpdateFrequency.Text = freq_func.run(data.Time).ToString();
            }
        }
    }
}
