namespace MulticlientChat
{
    partial class ToolTipOfUser
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
            this.NameLbl = new System.Windows.Forms.Label();
            this.UserEmailLbl = new System.Windows.Forms.Label();
            this.UserStatusLbl = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // NameLbl
            // 
            this.NameLbl.AutoSize = true;
            this.NameLbl.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.NameLbl.Location = new System.Drawing.Point(12, 171);
            this.NameLbl.Name = "NameLbl";
            this.NameLbl.Size = new System.Drawing.Size(35, 13);
            this.NameLbl.TabIndex = 1;
            this.NameLbl.Text = "Name";
            // 
            // UserEmailLbl
            // 
            this.UserEmailLbl.AutoSize = true;
            this.UserEmailLbl.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.UserEmailLbl.Location = new System.Drawing.Point(15, 219);
            this.UserEmailLbl.Name = "UserEmailLbl";
            this.UserEmailLbl.Size = new System.Drawing.Size(32, 13);
            this.UserEmailLbl.TabIndex = 2;
            this.UserEmailLbl.Text = "Email";
            // 
            // UserStatusLbl
            // 
            this.UserStatusLbl.AutoSize = true;
            this.UserStatusLbl.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.UserStatusLbl.Location = new System.Drawing.Point(15, 261);
            this.UserStatusLbl.Name = "UserStatusLbl";
            this.UserStatusLbl.Size = new System.Drawing.Size(37, 13);
            this.UserStatusLbl.TabIndex = 3;
            this.UserStatusLbl.Text = "Status";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.CadetBlue;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(91, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(170, 135);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // ToolTipOfUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(376, 288);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.UserStatusLbl);
            this.Controls.Add(this.UserEmailLbl);
            this.Controls.Add(this.NameLbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ToolTipOfUser";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Info";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ToolTipOfUser_FormClosing);
            this.Load += new System.EventHandler(this.ToolTip_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label NameLbl;
        private System.Windows.Forms.Label UserEmailLbl;
        private System.Windows.Forms.Label UserStatusLbl;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}