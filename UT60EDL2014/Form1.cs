using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UT60EDL2014
{
    public partial class Form1 : Form
    {
        List<System.IO.Ports.SerialPort> portList = new List<System.IO.Ports.SerialPort>();

        public Form1()
        {
            InitializeComponent();
        }

        private void newConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.IO.Ports.SerialPort sp = new System.IO.Ports.SerialPort("COM1", 2400, System.IO.Ports.Parity.None, 8, System.IO.Ports.StopBits.None);
            sp.DtrEnable = true;
            sp.ReceivedBytesThreshold = 14;
            sp.Open();
        }

        private void disconnectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var sp in portList)
                sp.Close();
        }
    }
}
