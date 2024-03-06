namespace MulticlientChat
{
    partial class StartingWindow
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
            this.EmailLbl = new System.Windows.Forms.Label();
            this.DisplayNameLbl = new System.Windows.Forms.Label();
            this.EmailTextBox = new System.Windows.Forms.TextBox();
            this.AddImageBtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.DoneBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.DisplayNameTextBox = new System.Windows.Forms.TextBox();
            this.StatusLbl = new System.Windows.Forms.Label();
            this.StatusTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // EmailLbl
            // 
            this.EmailLbl.AutoSize = true;
            this.EmailLbl.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmailLbl.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.EmailLbl.Location = new System.Drawing.Point(12, 47);
            this.EmailLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.EmailLbl.Name = "EmailLbl";
            this.EmailLbl.Size = new System.Drawing.Size(104, 18);
            this.EmailLbl.TabIndex = 0;
            this.EmailLbl.Text = "Enter Email:";
            // 
            // DisplayNameLbl
            // 
            this.DisplayNameLbl.AutoSize = true;
            this.DisplayNameLbl.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DisplayNameLbl.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DisplayNameLbl.Location = new System.Drawing.Point(12, 103);
            this.DisplayNameLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.DisplayNameLbl.Name = "DisplayNameLbl";
            this.DisplayNameLbl.Size = new System.Drawing.Size(121, 18);
            this.DisplayNameLbl.TabIndex = 1;
            this.DisplayNameLbl.Text = "Display Name:";
            // 
            // EmailTextBox
            // 
            this.EmailTextBox.BackColor = System.Drawing.Color.LightBlue;
            this.EmailTextBox.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmailTextBox.Location = new System.Drawing.Point(143, 46);
            this.EmailTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.EmailTextBox.Multiline = true;
            this.EmailTextBox.Name = "EmailTextBox";
            this.EmailTextBox.Size = new System.Drawing.Size(257, 26);
            this.EmailTextBox.TabIndex = 3;
            this.EmailTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // AddImageBtn
            // 
            this.AddImageBtn.BackColor = System.Drawing.Color.SkyBlue;
            this.AddImageBtn.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddImageBtn.Location = new System.Drawing.Point(421, 153);
            this.AddImageBtn.Margin = new System.Windows.Forms.Padding(4);
            this.AddImageBtn.Name = "AddImageBtn";
            this.AddImageBtn.Size = new System.Drawing.Size(158, 28);
            this.AddImageBtn.TabIndex = 6;
            this.AddImageBtn.Text = "Add Image";
            this.AddImageBtn.UseVisualStyleBackColor = false;
            this.AddImageBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.LightBlue;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(421, 14);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(158, 131);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // DoneBtn
            // 
            this.DoneBtn.BackColor = System.Drawing.Color.SkyBlue;
            this.DoneBtn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DoneBtn.Location = new System.Drawing.Point(310, 206);
            this.DoneBtn.Margin = new System.Windows.Forms.Padding(4);
            this.DoneBtn.Name = "DoneBtn";
            this.DoneBtn.Size = new System.Drawing.Size(100, 32);
            this.DoneBtn.TabIndex = 8;
            this.DoneBtn.Text = "Done";
            this.DoneBtn.UseVisualStyleBackColor = false;
            this.DoneBtn.Click += new System.EventHandler(this.button2_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.BackColor = System.Drawing.Color.SkyBlue;
            this.CancelBtn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelBtn.Location = new System.Drawing.Point(448, 206);
            this.CancelBtn.Margin = new System.Windows.Forms.Padding(4);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(100, 32);
            this.CancelBtn.TabIndex = 9;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = false;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // DisplayNameTextBox
            // 
            this.DisplayNameTextBox.BackColor = System.Drawing.Color.LightBlue;
            this.DisplayNameTextBox.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DisplayNameTextBox.Location = new System.Drawing.Point(143, 102);
            this.DisplayNameTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.DisplayNameTextBox.Multiline = true;
            this.DisplayNameTextBox.Name = "DisplayNameTextBox";
            this.DisplayNameTextBox.Size = new System.Drawing.Size(257, 26);
            this.DisplayNameTextBox.TabIndex = 10;
            // 
            // StatusLbl
            // 
            this.StatusLbl.AutoSize = true;
            this.StatusLbl.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusLbl.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.StatusLbl.Location = new System.Drawing.Point(13, 158);
            this.StatusLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.StatusLbl.Name = "StatusLbl";
            this.StatusLbl.Size = new System.Drawing.Size(65, 18);
            this.StatusLbl.TabIndex = 11;
            this.StatusLbl.Text = "Status:";
            // 
            // StatusTextBox
            // 
            this.StatusTextBox.BackColor = System.Drawing.Color.LightBlue;
            this.StatusTextBox.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusTextBox.Location = new System.Drawing.Point(143, 157);
            this.StatusTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.StatusTextBox.Multiline = true;
            this.StatusTextBox.Name = "StatusTextBox";
            this.StatusTextBox.Size = new System.Drawing.Size(257, 26);
            this.StatusTextBox.TabIndex = 12;
            // 
            // StartingWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(589, 251);
            this.Controls.Add(this.StatusTextBox);
            this.Controls.Add(this.StatusLbl);
            this.Controls.Add(this.DisplayNameTextBox);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.DoneBtn);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.AddImageBtn);
            this.Controls.Add(this.EmailTextBox);
            this.Controls.Add(this.DisplayNameLbl);
            this.Controls.Add(this.EmailLbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "StartingWindow";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StartingWindow_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label EmailLbl;
        private System.Windows.Forms.Label DisplayNameLbl;
        private System.Windows.Forms.TextBox EmailTextBox;
        private System.Windows.Forms.Button AddImageBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button DoneBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.TextBox DisplayNameTextBox;
        private System.Windows.Forms.Label StatusLbl;
        private System.Windows.Forms.TextBox StatusTextBox;
    }
}

