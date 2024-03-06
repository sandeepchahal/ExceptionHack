namespace MulticlientChat
{
    partial class ChatWindow
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
            this.SendtextBox = new System.Windows.Forms.TextBox();
            this.RecieverLbl = new System.Windows.Forms.Label();
            this.SendBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.StatusLbl = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Userpic = new System.Windows.Forms.PictureBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Userpic)).BeginInit();
            this.SuspendLayout();
            // 
            // SendtextBox
            // 
            this.SendtextBox.BackColor = System.Drawing.Color.CadetBlue;
            this.SendtextBox.Location = new System.Drawing.Point(0, 369);
            this.SendtextBox.Margin = new System.Windows.Forms.Padding(4);
            this.SendtextBox.Multiline = true;
            this.SendtextBox.Name = "SendtextBox";
            this.SendtextBox.Size = new System.Drawing.Size(438, 60);
            this.SendtextBox.TabIndex = 1;
            this.SendtextBox.Click += new System.EventHandler(this.SendtextBox_Click);
            this.SendtextBox.Enter += new System.EventHandler(this.SendtextBox_Enter);
            this.SendtextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SendtextBox_KeyUp);
            this.SendtextBox.Leave += new System.EventHandler(this.SendtextBox_Leave);
            // 
            // RecieverLbl
            // 
            this.RecieverLbl.AutoSize = true;
            this.RecieverLbl.Font = new System.Drawing.Font("Comic Sans MS", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RecieverLbl.ForeColor = System.Drawing.SystemColors.Desktop;
            this.RecieverLbl.Location = new System.Drawing.Point(101, 7);
            this.RecieverLbl.Name = "RecieverLbl";
            this.RecieverLbl.Size = new System.Drawing.Size(97, 33);
            this.RecieverLbl.TabIndex = 3;
            this.RecieverLbl.Text = "userLbl";
            // 
            // SendBtn
            // 
            this.SendBtn.BackColor = System.Drawing.Color.DarkCyan;
            this.SendBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.SendBtn.Location = new System.Drawing.Point(438, 368);
            this.SendBtn.Name = "SendBtn";
            this.SendBtn.Size = new System.Drawing.Size(89, 61);
            this.SendBtn.TabIndex = 6;
            this.SendBtn.Text = "Send File";
            this.SendBtn.UseVisualStyleBackColor = false;
            this.SendBtn.Click += new System.EventHandler(this.SendBtn_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.StatusLbl);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.RecieverLbl);
            this.panel1.Location = new System.Drawing.Point(0, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(515, 72);
            this.panel1.TabIndex = 7;
            // 
            // StatusLbl
            // 
            this.StatusLbl.AutoSize = true;
            this.StatusLbl.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusLbl.ForeColor = System.Drawing.Color.MintCream;
            this.StatusLbl.Location = new System.Drawing.Point(148, 40);
            this.StatusLbl.Name = "StatusLbl";
            this.StatusLbl.Size = new System.Drawing.Size(63, 17);
            this.StatusLbl.TabIndex = 9;
            this.StatusLbl.Text = "StatusLbl";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.Userpic);
            this.panel2.Location = new System.Drawing.Point(8, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(78, 66);
            this.panel2.TabIndex = 8;
            // 
            // Userpic
            // 
            this.Userpic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Userpic.Location = new System.Drawing.Point(0, 3);
            this.Userpic.Name = "Userpic";
            this.Userpic.Size = new System.Drawing.Size(75, 60);
            this.Userpic.TabIndex = 0;
            this.Userpic.TabStop = false;
            this.Userpic.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Userpic_MouseDoubleClick);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.LightBlue;
            this.richTextBox1.Enabled = false;
            this.richTextBox1.Location = new System.Drawing.Point(0, 80);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(527, 289);
            this.richTextBox1.TabIndex = 8;
            this.richTextBox1.Text = "";
            // 
            // ChatWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(527, 430);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.SendBtn);
            this.Controls.Add(this.SendtextBox);
            this.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ChatWindow";
            this.Text = "ChatWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChatWindow_FormClosing);
            this.Load += new System.EventHandler(this.ChatWindow_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Userpic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox SendtextBox;
        private System.Windows.Forms.Label RecieverLbl;
        private System.Windows.Forms.Button SendBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox Userpic;
        private System.Windows.Forms.Label StatusLbl;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}