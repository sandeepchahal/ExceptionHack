using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Threading;
using System.IO;

namespace MulticlientChat
{
    public partial class StartingWindow : Form
    {
        public String DefaultStatus = "Hi there, I am available";
        public static String ImageFileName=null;
        public StartingWindow()
        {
            InitializeComponent();
            StatusTextBox.Text =DefaultStatus ;
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        public bool ThumbnailCallback()
        {
            return false;
        }
        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                OpenFileDialog file = new OpenFileDialog();

                file.Filter = "Image file (.jpg;.jpeg;)|*.jpg;*.jpeg|All files (*.*)|*.*";
                file.InitialDirectory = @"c:\";
                file.CheckFileExists = true;
                file.CheckPathExists = true;

                file.ReadOnlyChecked = true;
                file.ShowReadOnly = true;
                DialogResult result= file.ShowDialog();
                if (result == DialogResult.OK)
                {
                    ImageFileName = file.FileName;

                   
                    Bitmap map = new Bitmap(file.FileName);
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox1.Image = map;
                    AddImageBtn.Text = "Change Pic";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                Bitmap map = new Bitmap(Properties.Resources.icon_user_default);
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox1.Image = map;
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(EmailTextBox.Text) || String.IsNullOrEmpty(DisplayNameTextBox.Text))
                {
                    MessageBox.Show("Empty Not Allowed", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (EmailTextBox.Text.ToLower().Contains("@gmail.com"))
                    {

                        this.Cursor = Cursors.WaitCursor;
                        SQLDataAccess sql = new SQLDataAccess();
                        if (sql.CheckEmailFromServerDB(EmailTextBox.Text) == 0)
                        {
                            DialogResult result = MessageBox.Show(EmailTextBox.Text + " is already register, Do you want to use it", "Information", MessageBoxButtons.YesNo);
                            if (result == DialogResult.Yes)
                            {
                                if (sql.GetUserEmailFromLocal() == null)
                                {
                                    sql.AddEmailToLocal(EmailTextBox.Text, DisplayNameTextBox.Text, StatusTextBox.Text);
                                    ListOfUsersWindow.EmailOfUser = EmailTextBox.Text;

                                    ListOfUsersWindow UserWindow = new ListOfUsersWindow();
                                    UserWindow.Show();
                                    this.Hide();
                                }
                                else
                                {
                                    sql.DeleteALLDataFromLocal();
                                    sql.AddEmailToLocal(EmailTextBox.Text, DisplayNameTextBox.Text, StatusTextBox.Text);
                                    ListOfUsersWindow.EmailOfUser = EmailTextBox.Text;
                                    this.Hide();
                                    ListOfUsersWindow UserWindow = new ListOfUsersWindow();
                                    UserWindow.Show();
                                }

                            }
                            else
                            {
                                MessageBox.Show("Please use another Email! Thanks", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Cursor = Cursors.Default;
                            }

                        }
                        else
                        {

                            bool value = false;
                            int otpForMail = GenerateOTP();
                            OTPWindow.OTP = otpForMail;
                            Thread t = new Thread(() => { value = SendMail(otpForMail, EmailTextBox.Text); });
                            t.Start();
                            t.Join();
                            if (value)
                            {
                                this.Cursor = Cursors.Default;
                                if (ImageFileName != null)
                                {
                                    Image img = Image.FromFile(ImageFileName);
                                    MemoryStream ms = new MemoryStream();
                                    img.Save(ms, img.RawFormat);
                                    OTPWindow.image = ms.ToArray();
                                }
                                OTPWindow.DisplayName = DisplayNameTextBox.Text;
                                OTPWindow.EmailRegs = EmailTextBox.Text;
                                if (!String.IsNullOrEmpty(StatusTextBox.Text))
                                    OTPWindow.Status = StatusTextBox.Text;
                                else
                                    OTPWindow.Status = DefaultStatus;

                                this.Hide();
                                OTPWindow otp = new OTPWindow();
                                otp.ShowDialog();
                            }
                        }
                    }
                    else
                        MessageBox.Show("Please enter right Email!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        public Int32 GenerateOTP()
        {
            Random rand = new Random();
            int randNumber = rand.Next(10000, 99999);
            return randNumber;
        }
        public bool SendMail(int OTP,string EmailTo)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress(ConfigurationManager.AppSettings["UserName"]);
                mail.To.Add(EmailTo);
                mail.Subject = "MyChat registeration OTP";
                mail.Body = "Hey User, your OTP for MyChat is "+OTP;

                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["UserName"],ConfigurationManager.AppSettings["Password"]);
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
            
                return true;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void StartingWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
