namespace MulticlientChat
{
    partial class OTPWindow
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
            this.OTPHeadingLbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.OTPtextBox = new System.Windows.Forms.TextBox();
            this.ResendBtn = new System.Windows.Forms.Button();
            this.VerifyBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Sessionlbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // OTPHeadingLbl
            // 
            this.OTPHeadingLbl.AutoSize = true;
            this.OTPHeadingLbl.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OTPHeadingLbl.Location = new System.Drawing.Point(2, 9);
            this.OTPHeadingLbl.Name = "OTPHeadingLbl";
            this.OTPHeadingLbl.Size = new System.Drawing.Size(32, 12);
            this.OTPHeadingLbl.TabIndex = 0;
            this.OTPHeadingLbl.Text = "label";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(39, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Enter OTP:";
            // 
            // OTPtextBox
            // 
            this.OTPtextBox.Location = new System.Drawing.Point(145, 52);
            this.OTPtextBox.Multiline = true;
            this.OTPtextBox.Name = "OTPtextBox";
            this.OTPtextBox.Size = new System.Drawing.Size(146, 27);
            this.OTPtextBox.TabIndex = 2;
            // 
            // ResendBtn
            // 
            this.ResendBtn.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ResendBtn.Location = new System.Drawing.Point(297, 52);
            this.ResendBtn.Name = "ResendBtn";
            this.ResendBtn.Size = new System.Drawing.Size(75, 28);
            this.ResendBtn.TabIndex = 3;
            this.ResendBtn.Text = "Resend";
            this.ResendBtn.UseVisualStyleBackColor = false;
            this.ResendBtn.Click += new System.EventHandler(this.ResendBtn_Click);
            // 
            // VerifyBtn
            // 
            this.VerifyBtn.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.VerifyBtn.Location = new System.Drawing.Point(257, 116);
            this.VerifyBtn.Name = "VerifyBtn";
            this.VerifyBtn.Size = new System.Drawing.Size(81, 27);
            this.VerifyBtn.TabIndex = 4;
            this.VerifyBtn.Text = "Verify";
            this.VerifyBtn.UseVisualStyleBackColor = false;
            this.VerifyBtn.Click += new System.EventHandler(this.button2_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.CancelBtn.Location = new System.Drawing.Point(367, 116);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(84, 27);
            this.CancelBtn.TabIndex = 5;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = false;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Sessionlbl
            // 
            this.Sessionlbl.AutoSize = true;
            this.Sessionlbl.Location = new System.Drawing.Point(142, 97);
            this.Sessionlbl.Name = "Sessionlbl";
            this.Sessionlbl.Size = new System.Drawing.Size(58, 13);
            this.Sessionlbl.TabIndex = 6;
            this.Sessionlbl.Text = "SessionLbl";
            // 
            // OTPWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(475, 155);
            this.Controls.Add(this.Sessionlbl);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.VerifyBtn);
            this.Controls.Add(this.ResendBtn);
            this.Controls.Add(this.OTPtextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.OTPHeadingLbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OTPWindow";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "OTP Window";
            this.Load += new System.EventHandler(this.OTPWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label OTPHeadingLbl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox OTPtextBox;
        private System.Windows.Forms.Button ResendBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Button VerifyBtn;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label Sessionlbl;
    }
}