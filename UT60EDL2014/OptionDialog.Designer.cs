namespace UT60EDL2014
{
    partial class OptionDialog
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
            this.components = new System.ComponentModel.Container();
            this.labelDefaultPath = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonAccept = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.checkBoxSavePath = new System.Windows.Forms.CheckBox();
            this.labelFont = new System.Windows.Forms.Label();
            this.textBoxFont = new System.Windows.Forms.TextBox();
            this.textBoxDefaultPath = new FilePathTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelDefaultPath
            // 
            this.labelDefaultPath.AutoSize = true;
            this.labelDefaultPath.Location = new System.Drawing.Point(9, 9);
            this.labelDefaultPath.Name = "labelDefaultPath";
            this.labelDefaultPath.Size = new System.Drawing.Size(69, 13);
            this.labelDefaultPath.TabIndex = 1;
            this.labelDefaultPath.Text = "Default Path:";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.CausesValidation = false;
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(200, 120);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonAccept
            // 
            this.buttonAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAccept.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonAccept.Location = new System.Drawing.Point(119, 120);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Size = new System.Drawing.Size(75, 23);
            this.buttonAccept.TabIndex = 3;
            this.buttonAccept.Text = "Accept";
            this.buttonAccept.UseVisualStyleBackColor = true;
            // 
            // buttonReset
            // 
            this.buttonReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonReset.Location = new System.Drawing.Point(38, 120);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(75, 23);
            this.buttonReset.TabIndex = 4;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // textBoxDefaultPath
            // 
            this.textBoxDefaultPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDefaultPath.CausesValidation = false;
            this.textBoxDefaultPath.ep = this.errorProvider1;
            this.textBoxDefaultPath.Location = new System.Drawing.Point(11, 25);
            this.textBoxDefaultPath.Name = "textBoxDefaultPath";
            this.textBoxDefaultPath.Size = new System.Drawing.Size(263, 20);
            this.textBoxDefaultPath.TabIndex = 0;
            // 
            // checkBoxSavePath
            // 
            this.checkBoxSavePath.AutoSize = true;
            this.checkBoxSavePath.Location = new System.Drawing.Point(11, 94);
            this.checkBoxSavePath.Name = "checkBoxSavePath";
            this.checkBoxSavePath.Size = new System.Drawing.Size(152, 17);
            this.checkBoxSavePath.TabIndex = 6;
            this.checkBoxSavePath.Text = "Set Last Setting as Default";
            this.checkBoxSavePath.UseVisualStyleBackColor = true;
            // 
            // labelFont
            // 
            this.labelFont.AutoSize = true;
            this.labelFont.Location = new System.Drawing.Point(13, 52);
            this.labelFont.Name = "labelFont";
            this.labelFont.Size = new System.Drawing.Size(72, 13);
            this.labelFont.TabIndex = 7;
            this.labelFont.Text = "Font Settings:";
            // 
            // textBoxFont
            // 
            this.textBoxFont.Location = new System.Drawing.Point(12, 68);
            this.textBoxFont.Name = "textBoxFont";
            this.textBoxFont.Size = new System.Drawing.Size(262, 20);
            this.textBoxFont.TabIndex = 8;
            this.textBoxFont.DoubleClick += new System.EventHandler(this.textBoxFont_DoubleClick);
            // 
            // OptionDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 152);
            this.Controls.Add(this.textBoxFont);
            this.Controls.Add(this.labelFont);
            this.Controls.Add(this.checkBoxSavePath);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.buttonAccept);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.labelDefaultPath);
            this.Controls.Add(this.textBoxDefaultPath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "OptionDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OptionDialog_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelDefaultPath;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonAccept;
        private System.Windows.Forms.Button buttonReset;
        private FilePathTextBox textBoxDefaultPath;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.CheckBox checkBoxSavePath;
        private System.Windows.Forms.TextBox textBoxFont;
        private System.Windows.Forms.Label labelFont;
    }
}