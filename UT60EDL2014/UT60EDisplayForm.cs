﻿using System;
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
        UT60EDataParser parser = new UT60EDataParser();
        System.IO.Ports.SerialPort sp;
        bool synced;
        public UT60EDisplayForm()
        {
            InitializeComponent();
            parser.dataReadyEventHandler += UpdateDisplay;
            this.sp = new System.IO.Ports.SerialPort("COM1", 2400, System.IO.Ports.Parity.None, 8, System.IO.Ports.StopBits.One);
            sp.DtrEnable = true;
            sp.ReceivedBytesThreshold = 14;
            sp.Open();
            this.sp.DataReceived += OnDataReceive;
        }

        private void UT60EDisplayForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            sp.Close();
        }

        private void OnDataReceive(object sender, EventArgs e)
        {
            int size = sp.BytesToRead;
            byte[] buf = new byte[size];
            sp.Read(buf, 0, size);
            parser.DataReceived(buf);
        }

        private void UpdateDisplay(object sender, EventArgs e)
        {
            UT60EDataBase data = (UT60EDataBase)sender;
            int scale = data.scale;
            int unit = 0;
            while (scale > 3)
            {
                unit += 1;
                scale -= 3;
            }
            while (scale < 3)
            {
                unit -= 1;
                scale += 3;
            }
            Decimal actualValue = new Decimal(data.value * Math.Pow(10, -scale));
            StringBuilder temp = new StringBuilder();
            temp.Append(actualValue.ToString());
            if (Enum.IsDefined(typeof(Modifier), unit))
                temp.Append(((Modifier)unit).ToString());
            temp.Append(data.getUnit());
            this.BeginInvoke((Action)(() => { textBoxValue.Text = temp.ToString(); }));
        }
    }
}
