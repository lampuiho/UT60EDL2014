namespace UT60EDL2014
{
    partial class UT60EConfigWizard
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
            this.stepWizardControl1 = new AeroWizard.StepWizardControl();
            this.wizardPage1 = new AeroWizard.WizardPage();
            this.checkBoxKeepLog = new System.Windows.Forms.CheckBox();
            this.groupBoxPortNo = new System.Windows.Forms.GroupBox();
            this.numericUpDownPort = new System.Windows.Forms.NumericUpDown();
            this.wizardPage2 = new AeroWizard.WizardPage();
            this.groupBoxPorts = new System.Windows.Forms.GroupBox();
            this.comboBoxPickPort = new System.Windows.Forms.ComboBox();
            this.groupBoxRecordUnit = new System.Windows.Forms.GroupBox();
            this.comboBoxUnits = new System.Windows.Forms.ComboBox();
            this.groupBoxPortNames = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.comboBoxPorts = new System.Windows.Forms.ComboBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.wizardPage3 = new AeroWizard.WizardPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxLogFre = new System.Windows.Forms.GroupBox();
            this.numericUpDownFrequency = new System.Windows.Forms.NumericUpDown();
            this.groupBoxStartTime = new System.Windows.Forms.GroupBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.groupBoxPath = new System.Windows.Forms.GroupBox();
            this.filePathTextBox1 = new UT60EDL2014.FilePathDefaultTextBox();
            this.groupBoxLogLimit = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.comboBoxLimit = new System.Windows.Forms.ComboBox();
            this.numericUpDownLimit = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.stepWizardControl1)).BeginInit();
            this.wizardPage1.SuspendLayout();
            this.groupBoxPortNo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPort)).BeginInit();
            this.wizardPage2.SuspendLayout();
            this.groupBoxPorts.SuspendLayout();
            this.groupBoxRecordUnit.SuspendLayout();
            this.groupBoxPortNames.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.wizardPage3.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupBoxLogFre.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFrequency)).BeginInit();
            this.groupBoxStartTime.SuspendLayout();
            this.groupBoxPath.SuspendLayout();
            this.groupBoxLogLimit.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLimit)).BeginInit();
            this.SuspendLayout();
            // 
            // stepWizardControl1
            // 
            this.stepWizardControl1.Location = new System.Drawing.Point(0, 0);
            this.stepWizardControl1.Name = "stepWizardControl1";
            this.stepWizardControl1.Pages.Add(this.wizardPage1);
            this.stepWizardControl1.Pages.Add(this.wizardPage2);
            this.stepWizardControl1.Pages.Add(this.wizardPage3);
            this.stepWizardControl1.Size = new System.Drawing.Size(742, 456);
            this.stepWizardControl1.StepListWidth = 225;
            this.stepWizardControl1.TabIndex = 0;
            // 
            // wizardPage1
            // 
            this.wizardPage1.Controls.Add(this.checkBoxKeepLog);
            this.wizardPage1.Controls.Add(this.groupBoxPortNo);
            this.wizardPage1.Name = "wizardPage1";
            this.wizardPage1.NextPage = this.wizardPage2;
            this.wizardPage1.Size = new System.Drawing.Size(469, 277);
            this.stepWizardControl1.SetStepText(this.wizardPage1, "No. of Ports");
            this.wizardPage1.TabIndex = 2;
            this.wizardPage1.Text = "Basic Setup";
            this.wizardPage1.Commit += new System.EventHandler<AeroWizard.WizardPageConfirmEventArgs>(this.wizardPage1_Commit);
            // 
            // checkBoxKeepLog
            // 
            this.checkBoxKeepLog.AutoSize = true;
            this.checkBoxKeepLog.Location = new System.Drawing.Point(4, 88);
            this.checkBoxKeepLog.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBoxKeepLog.Name = "checkBoxKeepLog";
            this.checkBoxKeepLog.Size = new System.Drawing.Size(112, 29);
            this.checkBoxKeepLog.TabIndex = 13;
            this.checkBoxKeepLog.Text = "Keep Log";
            this.checkBoxKeepLog.UseVisualStyleBackColor = true;
            this.checkBoxKeepLog.CheckedChanged += new System.EventHandler(this.checkBoxKeepLog_CheckedChanged);
            // 
            // groupBoxPortNo
            // 
            this.groupBoxPortNo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxPortNo.Controls.Add(this.numericUpDownPort);
            this.groupBoxPortNo.Location = new System.Drawing.Point(4, 5);
            this.groupBoxPortNo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxPortNo.Name = "groupBoxPortNo";
            this.groupBoxPortNo.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxPortNo.Size = new System.Drawing.Size(461, 74);
            this.groupBoxPortNo.TabIndex = 12;
            this.groupBoxPortNo.TabStop = false;
            this.groupBoxPortNo.Text = "No. of Ports to Monitor";
            // 
            // numericUpDownPort
            // 
            this.numericUpDownPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDownPort.Location = new System.Drawing.Point(4, 29);
            this.numericUpDownPort.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numericUpDownPort.Name = "numericUpDownPort";
            this.numericUpDownPort.Size = new System.Drawing.Size(453, 31);
            this.numericUpDownPort.TabIndex = 0;
            // 
            // wizardPage2
            // 
            this.wizardPage2.Controls.Add(this.groupBoxPorts);
            this.wizardPage2.Controls.Add(this.groupBoxRecordUnit);
            this.wizardPage2.Controls.Add(this.groupBoxPortNames);
            this.wizardPage2.IsFinishPage = true;
            this.wizardPage2.Name = "wizardPage2";
            this.wizardPage2.NextPage = this.wizardPage3;
            this.wizardPage2.Size = new System.Drawing.Size(469, 277);
            this.stepWizardControl1.SetStepText(this.wizardPage2, "Port Setup");
            this.wizardPage2.TabIndex = 3;
            this.wizardPage2.Text = "Port Setup";
            this.wizardPage2.Commit += new System.EventHandler<AeroWizard.WizardPageConfirmEventArgs>(this.wizardPage2_Commit);
            // 
            // groupBoxPorts
            // 
            this.groupBoxPorts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxPorts.Controls.Add(this.comboBoxPickPort);
            this.groupBoxPorts.Location = new System.Drawing.Point(4, 4);
            this.groupBoxPorts.Name = "groupBoxPorts";
            this.groupBoxPorts.Size = new System.Drawing.Size(457, 66);
            this.groupBoxPorts.TabIndex = 0;
            this.groupBoxPorts.TabStop = false;
            this.groupBoxPorts.Text = "Ports";
            // 
            // comboBoxPickPort
            // 
            this.comboBoxPickPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxPickPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPickPort.FormattingEnabled = true;
            this.comboBoxPickPort.Location = new System.Drawing.Point(7, 31);
            this.comboBoxPickPort.Name = "comboBoxPickPort";
            this.comboBoxPickPort.Size = new System.Drawing.Size(446, 33);
            this.comboBoxPickPort.TabIndex = 0;
            this.comboBoxPickPort.SelectedIndexChanged += new System.EventHandler(this.comboBoxPickPort_SelectedIndexChanged);
            // 
            // groupBoxRecordUnit
            // 
            this.groupBoxRecordUnit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxRecordUnit.Controls.Add(this.comboBoxUnits);
            this.groupBoxRecordUnit.Location = new System.Drawing.Point(4, 200);
            this.groupBoxRecordUnit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxRecordUnit.Name = "groupBoxRecordUnit";
            this.groupBoxRecordUnit.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxRecordUnit.Size = new System.Drawing.Size(457, 63);
            this.groupBoxRecordUnit.TabIndex = 2;
            this.groupBoxRecordUnit.TabStop = false;
            this.groupBoxRecordUnit.Text = "Choose the unit you want to monitor";
            // 
            // comboBoxUnits
            // 
            this.comboBoxUnits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxUnits.FormattingEnabled = true;
            this.comboBoxUnits.Location = new System.Drawing.Point(4, 29);
            this.comboBoxUnits.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxUnits.Name = "comboBoxUnits";
            this.comboBoxUnits.Size = new System.Drawing.Size(449, 33);
            this.comboBoxUnits.TabIndex = 0;
            this.comboBoxUnits.Tag = "log_unit";
            // 
            // groupBoxPortNames
            // 
            this.groupBoxPortNames.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxPortNames.Controls.Add(this.tableLayoutPanel1);
            this.groupBoxPortNames.Location = new System.Drawing.Point(4, 78);
            this.groupBoxPortNames.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxPortNames.Name = "groupBoxPortNames";
            this.groupBoxPortNames.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxPortNames.Size = new System.Drawing.Size(457, 112);
            this.groupBoxPortNames.TabIndex = 1;
            this.groupBoxPortNames.TabStop = false;
            this.groupBoxPortNames.Text = "Pick a port connected to UT60E and Give it an ID";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.comboBoxPorts, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBoxName, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 29);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(449, 78);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // comboBoxPorts
            // 
            this.comboBoxPorts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPorts.FormattingEnabled = true;
            this.comboBoxPorts.Location = new System.Drawing.Point(0, 0);
            this.comboBoxPorts.Margin = new System.Windows.Forms.Padding(0);
            this.comboBoxPorts.Name = "comboBoxPorts";
            this.comboBoxPorts.Size = new System.Drawing.Size(449, 33);
            this.comboBoxPorts.TabIndex = 0;
            this.comboBoxPorts.Tag = "port_name";
            // 
            // textBoxName
            // 
            this.textBoxName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxName.Location = new System.Drawing.Point(0, 39);
            this.textBoxName.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(449, 31);
            this.textBoxName.TabIndex = 1;
            this.textBoxName.Tag = "name";
            // 
            // wizardPage3
            // 
            this.wizardPage3.Controls.Add(this.tableLayoutPanel3);
            this.wizardPage3.Controls.Add(this.groupBoxPath);
            this.wizardPage3.Controls.Add(this.groupBoxLogLimit);
            this.wizardPage3.IsFinishPage = true;
            this.wizardPage3.Name = "wizardPage3";
            this.wizardPage3.Size = new System.Drawing.Size(469, 277);
            this.stepWizardControl1.SetStepText(this.wizardPage3, "Log Setup");
            this.wizardPage3.Suppress = true;
            this.wizardPage3.TabIndex = 4;
            this.wizardPage3.Text = "Log Setup";
            this.wizardPage3.Commit += new System.EventHandler<AeroWizard.WizardPageConfirmEventArgs>(this.wizardPage3_Commit);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.groupBoxLogFre, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.groupBoxStartTime, 1, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(8, 90);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(461, 77);
            this.tableLayoutPanel3.TabIndex = 17;
            // 
            // groupBoxLogFre
            // 
            this.groupBoxLogFre.Controls.Add(this.numericUpDownFrequency);
            this.groupBoxLogFre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxLogFre.Location = new System.Drawing.Point(0, 0);
            this.groupBoxLogFre.Margin = new System.Windows.Forms.Padding(0);
            this.groupBoxLogFre.Name = "groupBoxLogFre";
            this.groupBoxLogFre.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxLogFre.Size = new System.Drawing.Size(230, 77);
            this.groupBoxLogFre.TabIndex = 1;
            this.groupBoxLogFre.TabStop = false;
            this.groupBoxLogFre.Text = "Log Frequency Multiplier";
            // 
            // numericUpDownFrequency
            // 
            this.numericUpDownFrequency.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDownFrequency.Location = new System.Drawing.Point(4, 29);
            this.numericUpDownFrequency.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numericUpDownFrequency.Name = "numericUpDownFrequency";
            this.numericUpDownFrequency.Size = new System.Drawing.Size(222, 31);
            this.numericUpDownFrequency.TabIndex = 0;
            // 
            // groupBoxStartTime
            // 
            this.groupBoxStartTime.Controls.Add(this.dateTimePicker1);
            this.groupBoxStartTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxStartTime.Location = new System.Drawing.Point(230, 0);
            this.groupBoxStartTime.Margin = new System.Windows.Forms.Padding(0);
            this.groupBoxStartTime.Name = "groupBoxStartTime";
            this.groupBoxStartTime.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxStartTime.Size = new System.Drawing.Size(231, 77);
            this.groupBoxStartTime.TabIndex = 2;
            this.groupBoxStartTime.TabStop = false;
            this.groupBoxStartTime.Text = "Time to Start";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyy-MM-ddThh:mm:ss";
            this.dateTimePicker1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(4, 29);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(223, 31);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // groupBoxPath
            // 
            this.groupBoxPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxPath.Controls.Add(this.filePathTextBox1);
            this.groupBoxPath.Location = new System.Drawing.Point(4, 165);
            this.groupBoxPath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxPath.Name = "groupBoxPath";
            this.groupBoxPath.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxPath.Size = new System.Drawing.Size(461, 74);
            this.groupBoxPath.TabIndex = 3;
            this.groupBoxPath.TabStop = false;
            this.groupBoxPath.Text = "SaveFilePath";
            // 
            // filePathTextBox1
            // 
            this.filePathTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filePathTextBox1.CausesValidation = false;
            this.filePathTextBox1.ep = null;
            this.filePathTextBox1.Location = new System.Drawing.Point(8, 33);
            this.filePathTextBox1.Name = "filePathTextBox1";
            this.filePathTextBox1.Size = new System.Drawing.Size(446, 31);
            this.filePathTextBox1.TabIndex = 0;
            // 
            // groupBoxLogLimit
            // 
            this.groupBoxLogLimit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxLogLimit.Controls.Add(this.tableLayoutPanel2);
            this.groupBoxLogLimit.Location = new System.Drawing.Point(4, 5);
            this.groupBoxLogLimit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxLogLimit.Name = "groupBoxLogLimit";
            this.groupBoxLogLimit.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxLogLimit.Size = new System.Drawing.Size(461, 77);
            this.groupBoxLogLimit.TabIndex = 0;
            this.groupBoxLogLimit.TabStop = false;
            this.groupBoxLogLimit.Text = "Log Limit";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.comboBoxLimit, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.numericUpDownLimit, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 29);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(453, 43);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // comboBoxLimit
            // 
            this.comboBoxLimit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxLimit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLimit.FormattingEnabled = true;
            this.comboBoxLimit.Items.AddRange(new object[] {
            "Limit By Time (s)",
            "Limit By Record Count"});
            this.comboBoxLimit.Location = new System.Drawing.Point(4, 5);
            this.comboBoxLimit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxLimit.Name = "comboBoxLimit";
            this.comboBoxLimit.Size = new System.Drawing.Size(218, 33);
            this.comboBoxLimit.TabIndex = 0;
            // 
            // numericUpDownLimit
            // 
            this.numericUpDownLimit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDownLimit.Location = new System.Drawing.Point(230, 5);
            this.numericUpDownLimit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numericUpDownLimit.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownLimit.Name = "numericUpDownLimit";
            this.numericUpDownLimit.Size = new System.Drawing.Size(219, 31);
            this.numericUpDownLimit.TabIndex = 1;
            // 
            // UT60EConfigWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 456);
            this.Controls.Add(this.stepWizardControl1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UT60EConfigWizard";
            this.Text = "UT60EConfigWizard";
            ((System.ComponentModel.ISupportInitialize)(this.stepWizardControl1)).EndInit();
            this.wizardPage1.ResumeLayout(false);
            this.wizardPage1.PerformLayout();
            this.groupBoxPortNo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPort)).EndInit();
            this.wizardPage2.ResumeLayout(false);
            this.groupBoxPorts.ResumeLayout(false);
            this.groupBoxRecordUnit.ResumeLayout(false);
            this.groupBoxPortNames.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.wizardPage3.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.groupBoxLogFre.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFrequency)).EndInit();
            this.groupBoxStartTime.ResumeLayout(false);
            this.groupBoxPath.ResumeLayout(false);
            this.groupBoxPath.PerformLayout();
            this.groupBoxLogLimit.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLimit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AeroWizard.StepWizardControl stepWizardControl1;
        private AeroWizard.WizardPage wizardPage1;
        private System.Windows.Forms.CheckBox checkBoxKeepLog;
        private System.Windows.Forms.GroupBox groupBoxPortNo;
        private System.Windows.Forms.NumericUpDown numericUpDownPort;
        private AeroWizard.WizardPage wizardPage2;
        private System.Windows.Forms.GroupBox groupBoxRecordUnit;
        private System.Windows.Forms.ComboBox comboBoxUnits;
        private System.Windows.Forms.GroupBox groupBoxPortNames;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox comboBoxPorts;
        private System.Windows.Forms.TextBox textBoxName;
        private AeroWizard.WizardPage wizardPage3;
        private System.Windows.Forms.GroupBox groupBoxStartTime;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.GroupBox groupBoxLogFre;
        private System.Windows.Forms.NumericUpDown numericUpDownFrequency;
        private System.Windows.Forms.GroupBox groupBoxPath;
        private System.Windows.Forms.GroupBox groupBoxLogLimit;
        private System.Windows.Forms.NumericUpDown numericUpDownLimit;
        private System.Windows.Forms.ComboBox comboBoxLimit;
        private FilePathDefaultTextBox filePathTextBox1;
        private System.Windows.Forms.GroupBox groupBoxPorts;
        private System.Windows.Forms.ComboBox comboBoxPickPort;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}