namespace AllFileConverter
{
    partial class Form1
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
            this.SingleRadioBTN = new System.Windows.Forms.RadioButton();
            this.ConvertBTN = new System.Windows.Forms.Button();
            this.FirstLineLBL = new System.Windows.Forms.Label();
            this.InputFileTXTBox = new System.Windows.Forms.TextBox();
            this.BrowseBTN = new System.Windows.Forms.Button();
            this.InputFileLBL = new System.Windows.Forms.Label();
            this.OutputFileLBL = new System.Windows.Forms.Label();
            this.OutputFileTXTBox = new System.Windows.Forms.TextBox();
            this.ChangeBTN = new System.Windows.Forms.Button();
            this.CancelBTN = new System.Windows.Forms.Button();
            this.ConvertLBL = new System.Windows.Forms.Label();
            this.ConvertTypeCombobox = new System.Windows.Forms.ComboBox();
            this.MultipleRadioBTN = new System.Windows.Forms.RadioButton();
            this.FileLBL = new System.Windows.Forms.Label();
            this.FileEXTComboBox = new System.Windows.Forms.ComboBox();
            this.ResetBTN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SingleRadioBTN
            // 
            this.SingleRadioBTN.AutoSize = true;
            this.SingleRadioBTN.Location = new System.Drawing.Point(63, 57);
            this.SingleRadioBTN.Name = "SingleRadioBTN";
            this.SingleRadioBTN.Size = new System.Drawing.Size(54, 17);
            this.SingleRadioBTN.TabIndex = 0;
            this.SingleRadioBTN.Text = "Single";
            this.SingleRadioBTN.UseVisualStyleBackColor = true;
            this.SingleRadioBTN.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // ConvertBTN
            // 
            this.ConvertBTN.Location = new System.Drawing.Point(147, 299);
            this.ConvertBTN.Name = "ConvertBTN";
            this.ConvertBTN.Size = new System.Drawing.Size(124, 33);
            this.ConvertBTN.TabIndex = 8;
            this.ConvertBTN.Text = "Convert";
            this.ConvertBTN.UseVisualStyleBackColor = true;
            this.ConvertBTN.Click += new System.EventHandler(this.ConvertBTN_Click);
            // 
            // FirstLineLBL
            // 
            this.FirstLineLBL.AutoSize = true;
            this.FirstLineLBL.Location = new System.Drawing.Point(12, 30);
            this.FirstLineLBL.Name = "FirstLineLBL";
            this.FirstLineLBL.Size = new System.Drawing.Size(134, 13);
            this.FirstLineLBL.TabIndex = 3;
            this.FirstLineLBL.Text = "Select the Number of Files:";
            // 
            // InputFileTXTBox
            // 
            this.InputFileTXTBox.Location = new System.Drawing.Point(12, 179);
            this.InputFileTXTBox.Name = "InputFileTXTBox";
            this.InputFileTXTBox.Size = new System.Drawing.Size(441, 20);
            this.InputFileTXTBox.TabIndex = 4;
            this.InputFileTXTBox.MouseHover += new System.EventHandler(this.selectFileTXTBox_MouseHover);
            // 
            // BrowseBTN
            // 
            this.BrowseBTN.Location = new System.Drawing.Point(462, 179);
            this.BrowseBTN.Name = "BrowseBTN";
            this.BrowseBTN.Size = new System.Drawing.Size(103, 24);
            this.BrowseBTN.TabIndex = 5;
            this.BrowseBTN.Text = "Browse";
            this.BrowseBTN.UseVisualStyleBackColor = true;
            this.BrowseBTN.Click += new System.EventHandler(this.button2_Click);
            // 
            // InputFileLBL
            // 
            this.InputFileLBL.AutoSize = true;
            this.InputFileLBL.Location = new System.Drawing.Point(12, 163);
            this.InputFileLBL.Name = "InputFileLBL";
            this.InputFileLBL.Size = new System.Drawing.Size(84, 13);
            this.InputFileLBL.TabIndex = 6;
            this.InputFileLBL.Text = "Select File Path:";
            // 
            // OutputFileLBL
            // 
            this.OutputFileLBL.AutoSize = true;
            this.OutputFileLBL.Location = new System.Drawing.Point(9, 232);
            this.OutputFileLBL.Name = "OutputFileLBL";
            this.OutputFileLBL.Size = new System.Drawing.Size(184, 13);
            this.OutputFileLBL.TabIndex = 7;
            this.OutputFileLBL.Text = "By default file/files will be saved here:";
            // 
            // OutputFileTXTBox
            // 
            this.OutputFileTXTBox.Location = new System.Drawing.Point(12, 248);
            this.OutputFileTXTBox.Name = "OutputFileTXTBox";
            this.OutputFileTXTBox.Size = new System.Drawing.Size(441, 20);
            this.OutputFileTXTBox.TabIndex = 6;
            this.OutputFileTXTBox.MouseHover += new System.EventHandler(this.OutputFileTXTBox_MouseHover);
            // 
            // ChangeBTN
            // 
            this.ChangeBTN.Location = new System.Drawing.Point(462, 244);
            this.ChangeBTN.Name = "ChangeBTN";
            this.ChangeBTN.Size = new System.Drawing.Size(103, 24);
            this.ChangeBTN.TabIndex = 7;
            this.ChangeBTN.Text = "Change";
            this.ChangeBTN.UseVisualStyleBackColor = true;
            this.ChangeBTN.Click += new System.EventHandler(this.ChangeBTN_Click);
            // 
            // CancelBTN
            // 
            this.CancelBTN.Location = new System.Drawing.Point(296, 299);
            this.CancelBTN.Name = "CancelBTN";
            this.CancelBTN.Size = new System.Drawing.Size(124, 33);
            this.CancelBTN.TabIndex = 9;
            this.CancelBTN.Text = "Cancel";
            this.CancelBTN.UseVisualStyleBackColor = true;
            this.CancelBTN.Click += new System.EventHandler(this.CancelBTN_Click);
            // 
            // ConvertLBL
            // 
            this.ConvertLBL.AutoSize = true;
            this.ConvertLBL.Location = new System.Drawing.Point(12, 120);
            this.ConvertLBL.Name = "ConvertLBL";
            this.ConvertLBL.Size = new System.Drawing.Size(71, 13);
            this.ConvertLBL.TabIndex = 11;
            this.ConvertLBL.Text = "Convert Into: ";
            // 
            // ConvertTypeCombobox
            // 
            this.ConvertTypeCombobox.FormattingEnabled = true;
            this.ConvertTypeCombobox.Location = new System.Drawing.Point(99, 117);
            this.ConvertTypeCombobox.Name = "ConvertTypeCombobox";
            this.ConvertTypeCombobox.Size = new System.Drawing.Size(193, 21);
            this.ConvertTypeCombobox.TabIndex = 2;
            this.ConvertTypeCombobox.Text = "-- select--";
            this.ConvertTypeCombobox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // MultipleRadioBTN
            // 
            this.MultipleRadioBTN.AutoSize = true;
            this.MultipleRadioBTN.Location = new System.Drawing.Point(63, 80);
            this.MultipleRadioBTN.Name = "MultipleRadioBTN";
            this.MultipleRadioBTN.Size = new System.Drawing.Size(85, 17);
            this.MultipleRadioBTN.TabIndex = 1;
            this.MultipleRadioBTN.Text = "Multiple Files";
            this.MultipleRadioBTN.UseVisualStyleBackColor = true;
            this.MultipleRadioBTN.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // FileLBL
            // 
            this.FileLBL.AutoSize = true;
            this.FileLBL.Location = new System.Drawing.Point(351, 125);
            this.FileLBL.Name = "FileLBL";
            this.FileLBL.Size = new System.Drawing.Size(78, 13);
            this.FileLBL.TabIndex = 13;
            this.FileLBL.Text = "File Extension: ";
            // 
            // FileEXTComboBox
            // 
            this.FileEXTComboBox.FormattingEnabled = true;
            this.FileEXTComboBox.Location = new System.Drawing.Point(459, 122);
            this.FileEXTComboBox.Name = "FileEXTComboBox";
            this.FileEXTComboBox.Size = new System.Drawing.Size(106, 21);
            this.FileEXTComboBox.TabIndex = 3;
            this.FileEXTComboBox.Text = "-- select--";
            this.FileEXTComboBox.SelectedIndexChanged += new System.EventHandler(this.FileEXTComboBox_SelectedIndexChanged);
            // 
            // ResetBTN
            // 
            this.ResetBTN.Location = new System.Drawing.Point(441, 299);
            this.ResetBTN.Name = "ResetBTN";
            this.ResetBTN.Size = new System.Drawing.Size(124, 33);
            this.ResetBTN.TabIndex = 14;
            this.ResetBTN.Text = "Reset";
            this.ResetBTN.UseVisualStyleBackColor = true;
            this.ResetBTN.Click += new System.EventHandler(this.ResetBTN_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 349);
            this.Controls.Add(this.ResetBTN);
            this.Controls.Add(this.FileEXTComboBox);
            this.Controls.Add(this.FileLBL);
            this.Controls.Add(this.ConvertTypeCombobox);
            this.Controls.Add(this.ConvertLBL);
            this.Controls.Add(this.CancelBTN);
            this.Controls.Add(this.ChangeBTN);
            this.Controls.Add(this.OutputFileTXTBox);
            this.Controls.Add(this.OutputFileLBL);
            this.Controls.Add(this.InputFileLBL);
            this.Controls.Add(this.BrowseBTN);
            this.Controls.Add(this.InputFileTXTBox);
            this.Controls.Add(this.FirstLineLBL);
            this.Controls.Add(this.ConvertBTN);
            this.Controls.Add(this.MultipleRadioBTN);
            this.Controls.Add(this.SingleRadioBTN);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "EasyToConvert";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton SingleRadioBTN;
        private System.Windows.Forms.Button ConvertBTN;
        private System.Windows.Forms.Label FirstLineLBL;
        private System.Windows.Forms.TextBox InputFileTXTBox;
        private System.Windows.Forms.Button BrowseBTN;
        private System.Windows.Forms.Label InputFileLBL;
        private System.Windows.Forms.Label OutputFileLBL;
        private System.Windows.Forms.TextBox OutputFileTXTBox;
        private System.Windows.Forms.Button ChangeBTN;
        private System.Windows.Forms.Button CancelBTN;
        private System.Windows.Forms.Label ConvertLBL;
        private System.Windows.Forms.ComboBox ConvertTypeCombobox;
        private System.Windows.Forms.RadioButton MultipleRadioBTN;
        private System.Windows.Forms.Label FileLBL;
        private System.Windows.Forms.ComboBox FileEXTComboBox;
        private System.Windows.Forms.Button ResetBTN;
    }
}

