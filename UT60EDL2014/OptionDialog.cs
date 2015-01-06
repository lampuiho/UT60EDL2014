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
    public partial class OptionDialog : Form
    {
        public OptionDialog()
        {
            InitializeComponent();
            textBoxDefaultPath.ep = errorProvider1;
            Reset();
        }
        void Reset()
        {
            textBoxDefaultPath.Text = Properties.Settings.Default.DefaultPath;
            checkBoxSavePath.Checked = Properties.Settings.Default.SaveToDefault;
            textBoxFont.Text = Properties.Settings.Default.Font.ToString();
        }
        bool SaveSettings()
        {
            textBoxDefaultPath.CausesValidation = true;
            bool validated;
            if (validated = ValidateChildren())
            {
                Properties.Settings.Default.SaveToDefault = checkBoxSavePath.Checked;
                Properties.Settings.Default.DefaultPath = textBoxDefaultPath.Text;
                Properties.Settings.Default.Save();
            }
            return validated;
        }
        private void OptionDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = !SaveSettings();
            }
        }
        private void buttonReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void textBoxFont_DoubleClick(object sender, EventArgs e)
        {

        }
    }
}
