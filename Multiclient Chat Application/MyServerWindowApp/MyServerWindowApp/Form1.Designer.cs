namespace MyServerWindowApp
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
            this.IpTextBox = new System.Windows.Forms.TextBox();
            this.PortTextBox = new System.Windows.Forms.TextBox();
            this.IpLbl = new System.Windows.Forms.Label();
            this.PortLbl = new System.Windows.Forms.Label();
            this.ListeningBtn = new System.Windows.Forms.Button();
            this.listBox = new System.Windows.Forms.ListBox();
            this.waitingLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // IpTextBox
            // 
            this.IpTextBox.Location = new System.Drawing.Point(61, 12);
            this.IpTextBox.Name = "IpTextBox";
            this.IpTextBox.Size = new System.Drawing.Size(214, 20);
            this.IpTextBox.TabIndex = 0;
            // 
            // PortTextBox
            // 
            this.PortTextBox.Location = new System.Drawing.Point(335, 12);
            this.PortTextBox.Name = "PortTextBox";
            this.PortTextBox.Size = new System.Drawing.Size(56, 20);
            this.PortTextBox.TabIndex = 1;
            // 
            // IpLbl
            // 
            this.IpLbl.AutoSize = true;
            this.IpLbl.Location = new System.Drawing.Point(1, 15);
            this.IpLbl.Name = "IpLbl";
            this.IpLbl.Size = new System.Drawing.Size(54, 13);
            this.IpLbl.TabIndex = 2;
            this.IpLbl.Text = "IpAddress";
            // 
            // PortLbl
            // 
            this.PortLbl.AutoSize = true;
            this.PortLbl.Location = new System.Drawing.Point(303, 15);
            this.PortLbl.Name = "PortLbl";
            this.PortLbl.Size = new System.Drawing.Size(26, 13);
            this.PortLbl.TabIndex = 3;
            this.PortLbl.Text = "Port";
            // 
            // ListeningBtn
            // 
            this.ListeningBtn.Location = new System.Drawing.Point(410, 10);
            this.ListeningBtn.Name = "ListeningBtn";
            this.ListeningBtn.Size = new System.Drawing.Size(105, 23);
            this.ListeningBtn.TabIndex = 4;
            this.ListeningBtn.Text = "Start Listening";
            this.ListeningBtn.UseVisualStyleBackColor = true;
            this.ListeningBtn.Click += new System.EventHandler(this.ListeningBtn_Click);
            // 
            // listBox
            // 
            this.listBox.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox.FormattingEnabled = true;
            this.listBox.ItemHeight = 21;
            this.listBox.Location = new System.Drawing.Point(12, 77);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(503, 277);
            this.listBox.TabIndex = 5;
            // 
            // waitingLbl
            // 
            this.waitingLbl.AutoSize = true;
            this.waitingLbl.Location = new System.Drawing.Point(12, 51);
            this.waitingLbl.Name = "waitingLbl";
            this.waitingLbl.Size = new System.Drawing.Size(54, 13);
            this.waitingLbl.TabIndex = 6;
            this.waitingLbl.Text = "waitingLbl";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(527, 374);
            this.Controls.Add(this.waitingLbl);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.ListeningBtn);
            this.Controls.Add(this.PortLbl);
            this.Controls.Add(this.IpLbl);
            this.Controls.Add(this.PortTextBox);
            this.Controls.Add(this.IpTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox IpTextBox;
        private System.Windows.Forms.TextBox PortTextBox;
        private System.Windows.Forms.Label IpLbl;
        private System.Windows.Forms.Label PortLbl;
        private System.Windows.Forms.Button ListeningBtn;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Label waitingLbl;
    }
}

