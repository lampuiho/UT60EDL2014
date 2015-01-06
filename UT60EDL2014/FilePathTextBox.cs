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
    public partial class FilePathTextBox : TextBox
    {
        public ErrorProvider ep { get; set; }
        public FilePathTextBox()
        {
            InitializeComponent();
            this.CausesValidation = false;
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
        protected override void OnDoubleClick(EventArgs e)
        {
            base.OnDoubleClick(e);

            using (FolderBrowserDialog fd = new FolderBrowserDialog())
            {
                if (System.IO.Directory.Exists(this.Text))
                    fd.SelectedPath = this.Text;
                if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    this.Text = fd.SelectedPath;
            }
        }
        protected override void OnValidating(CancelEventArgs e)
        {
            base.OnValidating(e);
            if (this.Text == "" || System.IO.Directory.Exists(this.Text))
                return;

            ep.SetError(this, "You must enter a valid path.");
            ep.SetIconPadding(this, this.Bounds.Width - ep.Icon.Width - this.ClientRectangle.Width);
            e.Cancel = true;
        }
        protected override void OnValidated(EventArgs e)
        {
 	        base.OnValidated(e);
            ep.SetError(this, "");
        }
    }

    public class FilePathDefaultTextBox : FilePathTextBox
    {
        public FilePathDefaultTextBox()
            : base()
        {
            this.Text = Properties.Settings.Default.DefaultPath;
        }
    }
}
