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
    public partial class UT60EConfigWizard : Form
    {
        int last_port_index = -1;
        public bool log { get; set; }
        public List<UT60ESerialPortSettings> port_settings { get; set; }
        public UT60ELogSettings log_setting { get; set; }
        public UT60EConfigWizard()
        {
            InitializeComponent();
            var portNames = System.IO.Ports.SerialPort.GetPortNames();
            comboBoxUnits.Items.AddRange(Enum.GetNames(typeof(log_units)));
            comboBoxPorts.Items.AddRange(portNames);
            numericUpDownPort.Maximum = portNames.Count();
        }
        public void LogSettingMode()
        {
            wizardPage1.Suppress = true;
            wizardPage2.Suppress = true;
            wizardPage2.IsFinishPage = false;
            wizardPage3.Suppress = false;
        }
        private void wizardPage1_Commit(object sender, AeroWizard.WizardPageConfirmEventArgs e)
        {
            if (numericUpDownPort.Value <= 0){
                MessageBox.Show("There must be at least one port to be monitored", "Error");
                e.Cancel = true;
            }
            else
            {
                int port_amount = (int)numericUpDownPort.Value;
                for (int i = 1; i <= port_amount; ++i)
                    comboBoxPickPort.Items.Add(i);
                if (port_settings == null)
                    port_settings = new List<UT60ESerialPortSettings>(port_amount);
                if (port_settings.Count > port_amount)
                    port_settings.RemoveRange(port_amount, port_settings.Count - port_amount);
                else if (port_settings.Count < port_amount)
                    port_settings.AddRange(new UT60ESerialPortSettings[port_amount - port_settings.Count]);
            }
        }
        private void checkBoxKeepLog_CheckedChanged(object sender, EventArgs e)
        {
            log = checkBoxKeepLog.Checked;
            wizardPage3.Suppress = !log;
            wizardPage2.IsFinishPage = !log;
        }
        private void wizardPage2_Commit(object sender, AeroWizard.WizardPageConfirmEventArgs e)
        {
            foreach (var setting in port_settings)
            {
                if (setting == null) {
                    MessageBox.Show("You must config all the ports", "Error");
                    e.Cancel = true;
                    return;
                }
            }
        }
        private void comboBoxPickPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (last_port_index >= 0 && last_port_index != comboBoxPickPort.SelectedIndex)
                if (textBoxName.Text == "" || textBoxName.Text.IndexOfAny(System.IO.Path.GetInvalidFileNameChars()) >= 0)
                {
                    MessageBox.Show("Name cannot contain path invalid characters or be empty","Error");
                    comboBoxPickPort.SelectedIndex = last_port_index;
                }
                else
                {
                    comboBoxPickPort.Items[last_port_index] = textBoxName.Text;
                    port_settings[last_port_index] = new UT60ESerialPortSettings(
                        textBoxName.Text,
                        comboBoxPorts.GetItemText(comboBoxPorts.SelectedItem),
                        comboBoxUnits.SelectedIndex);
                    last_port_index = comboBoxPickPort.SelectedIndex;
                    if (port_settings[last_port_index] == null)
                    {
                        textBoxName.Text = "";
                        comboBoxPorts.SelectedIndex = 0;
                        comboBoxUnits.SelectedIndex = 0;
                    }
                    else
                    {
                        textBoxName.Text = port_settings[last_port_index].name;
                        comboBoxPorts.SelectedIndex = comboBoxPorts.FindStringExact(port_settings[last_port_index].port_name);
                        comboBoxUnits.SelectedIndex = port_settings[last_port_index].log_unit;
                    }
                }
            else
                last_port_index = 0;
        }
        private void wizardPage3_Commit(object sender, AeroWizard.WizardPageConfirmEventArgs e)
        {
            if (numericUpDownLimit.Value <= 0)
            {
                MessageBox.Show("Limit cannot be less than or equal to 0", "Error");
                e.Cancel = true;
            }
            else
            {
                log_setting = new UT60ELogSettings(comboBoxLimit.SelectedIndex,
                    (int)numericUpDownLimit.Value,
                    (int)numericUpDownFrequency.Value,
                    filePathTextBox1.Text,
                    dateTimePicker1.Value);
            }
        }
    }
}
