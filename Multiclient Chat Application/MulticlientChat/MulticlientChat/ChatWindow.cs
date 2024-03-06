using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MulticlientChat
{
    public partial class ChatWindow : Form
    {
        public static string EmailOfSender;
        public static string EmailOfReceiver;
        public static string NameofReciever;
        public static bool Connected;
        
        public static Socket clientSocket;
        public ChatWindow()
        {
            InitializeComponent();
            this.Text = EmailOfReceiver;
            RecieverLbl.Text = "You are chatting with "+NameofReciever.ToUpper();
           
        }
        private delegate void UpdateLogCallback(string msg,bool FromServer);
        private delegate void CloseConnectionCallback(string reason);
        private void ChatWindow_Load(object sender, EventArgs e)
        {
            try
            {
                SendtextBox.Text = "Enter message here and press enter to send...";
                SQLDataAccess sql = new SQLDataAccess();
                string text = sql.GetUserStatus(EmailOfReceiver);
                if (text.Length > 40)
                {
                    StatusLbl.Text = text.Substring(0, 40) + "\n\t" + text.Substring(40);
                }
                else
                {
                    StatusLbl.Text = text;
                }


                StatusLbl.Text = sql.GetUserStatus(EmailOfReceiver);
                byte[] imageofuser = sql.GetUserImage(EmailOfReceiver);
                if (imageofuser != null)
                {
                    using (MemoryStream ms = new MemoryStream(imageofuser))
                    {
                        if (ms != null)
                        {
                            Userpic.SizeMode = PictureBoxSizeMode.Zoom;
                            Userpic.Image = new Bitmap((Bitmap)Image.FromStream(ms, true, true));
                        }
                    }
                }
                else
                {
                    Userpic.SizeMode = PictureBoxSizeMode.Zoom;

                    Userpic.Image = new Bitmap(Properties.Resources.icon_user_default);
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
       

        public void UpdateChatMessageBox(string message)
        {
            this.Invoke(new UpdateLogCallback(this.UpdateLog), new object[] { message, false });
        }
        private void UpdateLog(String strMessage, bool IsServer)
        {
            try
            {
                // Append text also scrolls the TextBox to the bottom each time
                richTextBox1.SelectionAlignment = HorizontalAlignment.Left;

                if (IsServer == false)
                {
                    richTextBox1.SelectionBackColor = Color.Teal;
                    richTextBox1.ForeColor = Color.White;

                    richTextBox1.AppendText(NameofReciever + ">> \r");
                    richTextBox1.SelectionBackColor = Color.Teal;
                    richTextBox1.ForeColor = Color.White;
                    if (strMessage.Length > 40 && strMessage.Length < 100)
                    {
                        richTextBox1.AppendText(strMessage.Substring(0, (strMessage.Length / 2)) + "\r\n");
                        richTextBox1.SelectionBackColor = Color.Teal;
                        richTextBox1.ForeColor = Color.White;
                        richTextBox1.AppendText(strMessage.Substring(strMessage.Length / 2));
                    }
                    else if (strMessage.Length >= 100)
                    {
                        richTextBox1.AppendText(strMessage.Substring(0, (strMessage.Length / 2)) + "\r\n");
                        richTextBox1.SelectionBackColor = Color.Teal;
                        richTextBox1.ForeColor = Color.White;
                        richTextBox1.AppendText(strMessage.Substring(strMessage.Length / 2));
                    }
                    else
                    {
                        richTextBox1.SelectionBackColor = Color.Teal;
                        richTextBox1.ForeColor = Color.White;
                        richTextBox1.AppendText(strMessage);
                    }

                    richTextBox1.AppendText(Environment.NewLine);
                }
                else
                {
                    richTextBox1.SelectionBackColor = Color.DimGray;
                    richTextBox1.ForeColor = Color.White;
                    //richTextBox1.AppendText("Server >> \r"+strMessage);
                }
                richTextBox1.AppendText(Environment.NewLine);
                richTextBox1.ScrollToCaret();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        public void SendMessage(string msg)
        {
            try
            {
               
                if (Connected)
                {
                    String Msg = EmailOfReceiver.ToLower() + "$" + EmailOfSender.ToLower() + "$" + msg;
                    byte[] msgtoserver = System.Text.Encoding.ASCII.GetBytes(Msg);
                    clientSocket.Send(msgtoserver, 0, msgtoserver.Length, SocketFlags.None);
                }
            }catch(Exception)
            {
                MessageBox.Show("Server is not responding! Please try after some time", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void SendtextBox_Enter(object sender, EventArgs e)
        {
            SendtextBox.Text = "";

        }

        private void SendtextBox_Leave(object sender, EventArgs e)
        {
            SendtextBox.Text = "Enter You Message here and press Enter";
        }

        private void SendtextBox_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Connected)
                {
                    if (!String.IsNullOrEmpty(SendtextBox.Text))
                    {
                        if (e.KeyCode == Keys.Enter)
                        {
                            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;

                            string strMessage = SendtextBox.Text;
                            richTextBox1.SelectionBackColor = Color.Chocolate;
                            richTextBox1.ForeColor = Color.White;

                            richTextBox1.AppendText("You >> \r");
                            richTextBox1.SelectionBackColor = Color.Chocolate;
                            richTextBox1.ForeColor = Color.White;
                            if (strMessage.Length > 40 && strMessage.Length < 100)
                            {
                                richTextBox1.AppendText(strMessage.Substring(0, (strMessage.Length / 2)) + "\r\n");
                                richTextBox1.SelectionBackColor = Color.Chocolate;
                                richTextBox1.ForeColor = Color.White;
                                richTextBox1.AppendText(strMessage.Substring(strMessage.Length / 2));
                            }
                            else if (strMessage.Length >= 100)
                            {
                                richTextBox1.AppendText(strMessage.Substring(0, (strMessage.Length / 2)) + "\r\n");
                                richTextBox1.SelectionBackColor = Color.Chocolate;
                                richTextBox1.ForeColor = Color.White;
                                richTextBox1.AppendText(strMessage.Substring(strMessage.Length / 2));
                            }
                            else
                            {
                                richTextBox1.SelectionBackColor = Color.Chocolate;
                                richTextBox1.ForeColor = Color.White;
                                richTextBox1.AppendText(strMessage);
                            }
                            richTextBox1.AppendText(Environment.NewLine);
                            richTextBox1.ScrollToCaret();
                            SendMessage(SendtextBox.Text);
                            SendtextBox.Text = "";

                        }
                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void ChatWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                try
                {
                    var TempUserList = ListOfUsersWindow.ListofOpenedUser;
                    string Email = this.Text;
                    TempUserList.Remove(Email);

                    ListOfUsersWindow.ListofOpenedUser = TempUserList;
                }
                catch
                {
                    Connected = false;
                    clientSocket.Shutdown(SocketShutdown.Both);
                    clientSocket.Dispose();
                }
                finally
                {
                    GC.Collect();
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public void SendFile(string FileName)
        {
            try
            {
                clientSocket.SendFile(FileName, System.Text.Encoding.ASCII.GetBytes(FileName.Length.ToString() + "$" + EmailOfReceiver + "$" + EmailOfSender + "$"), System.Text.Encoding.ASCII.GetBytes("$" + Path.GetExtension(FileName)), TransmitFileOptions.UseSystemThread);

                this.Invoke(new UpdateLogCallback(this.UpdateLog), new object[] { "File has successfully send! ", true });
            }
            catch
            {
                MessageBox.Show("Server is not responding! Please try after some time", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void SendBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (Connected)
                {
                    OpenFileDialog dialog = new OpenFileDialog();
                    dialog.InitialDirectory = @"c:\Documents";
                    DialogResult result = dialog.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        string FileName = dialog.FileName;
                        byte[] byteOfFile = System.Text.Encoding.ASCII.GetBytes(FileName);
                        SendFile(FileName);
                    }
                }
                else
                {
                    MessageBox.Show("Server is not responding! Please try after some time", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void SendtextBox_Click(object sender, EventArgs e)
        {
            SendtextBox.Text = "";
        }

        private void Userpic_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                PictureBoxForm.img = Userpic.Image;
                PictureBoxForm form = new PictureBoxForm();
                form.ShowDialog();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
