namespace Daily_Task_Tracker_WFA
{
    partial class DailyTasktracker
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
            this.WelcomeLbl = new System.Windows.Forms.Label();
            this.UsrLbl = new System.Windows.Forms.Label();
            this.ListBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // WelcomeLbl
            // 
            this.WelcomeLbl.AutoSize = true;
            this.WelcomeLbl.Location = new System.Drawing.Point(53, 45);
            this.WelcomeLbl.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.WelcomeLbl.Name = "WelcomeLbl";
            this.WelcomeLbl.Size = new System.Drawing.Size(79, 21);
            this.WelcomeLbl.TabIndex = 0;
            this.WelcomeLbl.Text = "Welcome";
            // 
            // UsrLbl
            // 
            this.UsrLbl.AutoSize = true;
            this.UsrLbl.Location = new System.Drawing.Point(228, 45);
            this.UsrLbl.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.UsrLbl.Name = "UsrLbl";
            this.UsrLbl.Size = new System.Drawing.Size(63, 21);
            this.UsrLbl.TabIndex = 1;
            this.UsrLbl.Text = "Userlbl";
            // 
            // ListBtn
            // 
            this.ListBtn.Location = new System.Drawing.Point(257, 138);
            this.ListBtn.Margin = new System.Windows.Forms.Padding(5);
            this.ListBtn.Name = "ListBtn";
            this.ListBtn.Size = new System.Drawing.Size(110, 33);
            this.ListBtn.TabIndex = 2;
            this.ListBtn.Text = "Show List";
            this.ListBtn.UseVisualStyleBackColor = true;
            this.ListBtn.Click += new System.EventHandler(this.ListBtn_Click);
            // 
            // DailyTasktracker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 178);
            this.Controls.Add(this.ListBtn);
            this.Controls.Add(this.UsrLbl);
            this.Controls.Add(this.WelcomeLbl);
            this.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "DailyTasktracker";
            this.Text = "Daily Task Tracker";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DailyTasktracker_FormClosing);
            this.Load += new System.EventHandler(this.DailyTasktracker_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label WelcomeLbl;
        private System.Windows.Forms.Label UsrLbl;
        private System.Windows.Forms.Button ListBtn;
    }
}

