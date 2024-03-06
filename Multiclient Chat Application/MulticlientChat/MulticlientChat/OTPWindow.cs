using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MulticlientChat
{
    public partial class OTPWindow : Form
    {
        public static string EmailRegs;
        public static string DisplayName;
        public static string Status;
        public static int OTP = 0;
        int duration = 60;
        public static byte[] image = null;
        public OTPWindow()
        {
            InitializeComponent();
        }

        private void OTPWindow_Load(object sender, EventArgs e)
        {
            try
            {
                timer1.Enabled = true;
                timer1.Interval = 1000;
                timer1.Start();
                string newEmail = null;
                for (int i = 0; i < EmailRegs.Length; i++)
                {
                    if (i <= (EmailRegs.Length - 13))
                        newEmail += "*";
                    else
                        newEmail += EmailRegs[i];
                }
                string email = EmailRegs.Replace(EmailRegs, newEmail);

                OTPHeadingLbl.Text = "Please verify your Email, We have sent OTP  your Email  " + email;
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(OTPtextBox.Text))
                {
                    if (OTP == Convert.ToInt32(OTPtextBox.Text))
                    {
                        SQLDataAccess sql = new SQLDataAccess();
                        timer1.Stop();
                        Sessionlbl.Text = "Successfully Verified!";
                        if (image != null)
                        {
                            sql.RegisterUser(DisplayName, EmailRegs, Status, image);
                        }
                        else
                        {
                            sql.RegisterUser(DisplayName, EmailRegs, Status);
                        }
                        sql.AddEmailToLocal(EmailRegs, DisplayName, Status);
                        ListOfUsersWindow.EmailOfUser = EmailRegs;
                        this.Close();
                        ListOfUsersWindow UserWindow = new ListOfUsersWindow();
                        UserWindow.Show();
                    }
                    else
                    {
                        MessageBox.Show("Wrong Input!", "Verified", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show(" Empty Not allowed!", "Verified", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void ResendBtn_Click(object sender, EventArgs e)
        {
            try
            {
                OTPtextBox.Text = "";
                timer1.Stop();
                duration = 60;
                timer1.Start();
                StartingWindow w = new StartingWindow();
                int NewOTP = w.GenerateOTP();
                OTP = NewOTP;
                Thread t = new Thread(() => w.SendMail(NewOTP, EmailRegs));
                t.Start();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (duration == 0)
                {
                    Sessionlbl.Text = "Session Times out! Please click on resend to generate new.";
                    OTP = 0;
                    timer1.Stop();
                }
                else
                {
                    duration = duration - 1;
                    Sessionlbl.Text = "Session times out in " + duration.ToString() + " seconds";

                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
