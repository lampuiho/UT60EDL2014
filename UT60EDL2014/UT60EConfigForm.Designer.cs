namespace UT60EDL2014
{
    partial class UT60EConfigForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBoxAvaComPorts = new System.Windows.Forms.ComboBox();
            this.comboBoxUnits = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBoxLimit = new System.Windows.Forms.TextBox();
            this.comboBoxLimit = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // comboBoxAvaComPorts
            // 
            this.comboBoxAvaComPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAvaComPorts.FormattingEnabled = true;
            this.comboBoxAvaComPorts.Location = new System.Drawing.Point(13, 13);
            this.comboBoxAvaComPorts.Name = "comboBoxAvaComPorts";
            this.comboBoxAvaComPorts.Size = new System.Drawing.Size(157, 21);
            this.comboBoxAvaComPorts.TabIndex = 0;
            // 
            // comboBoxUnits
            // 
            this.comboBoxUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxUnits.FormattingEnabled = true;
            this.comboBoxUnits.Items.AddRange(new object[] {
            "V",
            "A",
            "C",
            "F",
            "Ohm",
            "Hz"});
            this.comboBoxUnits.Location = new System.Drawing.Point(13, 41);
            this.comboBoxUnits.Name = "comboBoxUnits";
            this.comboBoxUnits.Size = new System.Drawing.Size(157, 21);
            this.comboBoxUnits.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(12, 95);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(93, 95);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // textBoxLimit
            // 
            this.textBoxLimit.Location = new System.Drawing.Point(95, 68);
            this.textBoxLimit.Name = "textBoxLimit";
            this.textBoxLimit.Size = new System.Drawing.Size(75, 20);
            this.textBoxLimit.TabIndex = 3;
            // 
            // comboBoxLimit
            // 
            this.comboBoxLimit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLimit.FormattingEnabled = true;
            this.comboBoxLimit.Items.AddRange(new object[] {
            "Limit By Time (s)",
            "Limit By Record Count"});
            this.comboBoxLimit.Location = new System.Drawing.Point(12, 68);
            this.comboBoxLimit.Name = "comboBoxLimit";
            this.comboBoxLimit.Size = new System.Drawing.Size(77, 21);
            this.comboBoxLimit.TabIndex = 2;
            // 
            // UT60EConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(173, 125);
            this.Controls.Add(this.comboBoxLimit);
            this.Controls.Add(this.textBoxLimit);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBoxUnits);
            this.Controls.Add(this.comboBoxAvaComPorts);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "UT60EConfigForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "UT60EConfigForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.ComboBox comboBoxAvaComPorts;
        public System.Windows.Forms.ComboBox comboBoxUnits;
        public System.Windows.Forms.TextBox textBoxLimit;
        public System.Windows.Forms.ComboBox comboBoxLimit;
    }
}