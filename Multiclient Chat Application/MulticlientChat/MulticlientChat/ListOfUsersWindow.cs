using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MulticlientChat
{
    public partial class ListOfUsersWindow : Form
    {
        public static Dictionary<string, ChatWindow> ListofOpenedUser = new Dictionary<string, ChatWindow>();
        DataTable dt = new DataTable();
        public static string EmailOfUser;
        public static string NameofUser;
        public static string Status;
        public static bool flagForUpdate = true;
        private Socket clientSocket;
        private bool connectedWithServer = false;
        public static Form globalForm;
        public ListOfUsersWindow()
        {
            InitializeComponent();
        }

        private void ListOfUsersWindow_Load(object sender, EventArgs e)
        {
            LoadListitem();
            globalForm = new Form();
            globalForm.Show();
            globalForm.Hide();
            Thread t = new Thread(() => InitializeConnection());
            t.Start();
        }
        public void AddClientText()
        {}
       
        public bool ThumbnailCallback()
        {
            return false;
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void ListOfUsersWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                e.Cancel = true;
                notifyIcon1.Visible = true;
                notifyIcon1.Icon = SystemIcons.Application;

                notifyIcon1.BalloonTipText = "Minimized";
                notifyIcon1.BalloonTipTitle = "Your Application is Running for further Use";
                notifyIcon1.ShowBalloonTip(500);
                this.Hide();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void listBox1_MouseDoubleClick_1(object sender, MouseEventArgs e)
        {
            try
            {
                if (listBox1.SelectedIndex > -1)
                {
                    ToolTipOfUser.value = listBox1.SelectedItem.ToString();
                    ToolTipOfUser.dt = dt;
                    ToolTipOfUser tp = new ToolTipOfUser();
                    tp.ShowDialog();
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void EditpictureBox_Click(object sender, EventArgs e)
        {
            try
            {
                EditWindow.UserName = UserLbl.Text;
                EditWindow.Status = StatusLbl.Text;
                EditWindow.EmailofUser = EmailOfUser;
                EditWindow window = new EditWindow();
                window.ShowDialog();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }
        public void UpdateUserDetails()
        {
            try
            {
                SQLDataAccess sql = new SQLDataAccess();

                sql.UpdateAvailableStatus(EmailOfUser, "T");
                UserLbl.Text = sql.GetUserName(EmailOfUser).ToUpper();
                string text = sql.GetUserStatus(EmailOfUser);
                if (text.Length > 40)
                {
                    StatusLbl.Text = text.Substring(0, 40) + "\n\t" + text.Substring(40);
                }
                else
                {
                    StatusLbl.Text = text;
                }


                byte[] imageofuser = sql.GetUserImage(EmailOfUser);

                if (imageofuser != null)
                {
                    if (imageofuser.Length != 0)
                    {
                        using (MemoryStream ms = new MemoryStream(imageofuser))
                        {
                            if (ms != null)
                            {
                                UserPic.SizeMode = PictureBoxSizeMode.Zoom;
                                UserPic.Image = new Bitmap((Bitmap)Image.FromStream(ms, true, true));

                            }
                        }
                    }
                    else
                    {
                        UserPic.SizeMode = PictureBoxSizeMode.Zoom;
                    
                        Bitmap map = new Bitmap(Properties.Resources.no_image_icon);
                        UserPic.Image = map;
                    }

                }
                else
                {
                    UserPic.SizeMode = PictureBoxSizeMode.Zoom;

                    Bitmap map = new Bitmap(Properties.Resources.icon_user_default);
                    UserPic.Image = map;

                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        public void LoadListitem()
        {
            try
            {
                SQLDataAccess sql = new SQLDataAccess();
                dt = sql.GetListOfUsers(EmailOfUser);
                listBox1.Items.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    String value = dt.Rows[i][2].ToString();
                    listBox1.ItemHeight = 20;

                    listBox1.Items.Add(value);
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void ListOfUsersWindow_Activated(object sender, EventArgs e)
        {
            LoadListitem();
            if (flagForUpdate)  // flag for update means every time when window activated no need to update data if it is true then need to call the function
            {
                UpdateUserDetails();
                flagForUpdate = false;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (listBox1.SelectedIndex > -1)
                {
                    ChatWindow.EmailOfSender = EmailOfUser;
                    ChatWindow.EmailOfReceiver = dt.Rows[listBox1.SelectedIndex][1].ToString();
                    ChatWindow.NameofReciever = listBox1.SelectedItem.ToString();
                    ChatWindow window = new ChatWindow();
                    if (ListofOpenedUser.Count != 0)
                    {
                        if (!ListofOpenedUser.Any(h => h.Key == dt.Rows[listBox1.SelectedIndex][1].ToString()))
                        {
                            ListofOpenedUser.Add(dt.Rows[listBox1.SelectedIndex][1].ToString().ToLower(), window);
                            globalForm.Invoke((MethodInvoker)delegate ()
                            {
                                window.Text = listBox1.SelectedItem.ToString();
                                window.Show();
                            });
                        }
                        else
                        {
                            foreach (var item in ListofOpenedUser)
                            {
                                if (item.Key == dt.Rows[listBox1.SelectedIndex][1].ToString())
                                {
                                    item.Value.TopMost = true;
                                }
                            }
                        }

                    }
                    else
                    {
                        ListofOpenedUser.Add(dt.Rows[listBox1.SelectedIndex][1].ToString().ToLower(), window);
                        window.Show();
                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.ShowInTaskbar = true;
            this.WindowState = FormWindowState.Normal;
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

            notifyIcon1.Visible = false;
            try
            {
                if (connectedWithServer)
                {
                    String Msg = EmailOfUser+"$Di@sc@on@ne@ct@";
                    byte[] msgtoserver = System.Text.Encoding.ASCII.GetBytes(Msg);
                    clientSocket.Send(msgtoserver, 0, msgtoserver.Length, SocketFlags.None);
                    clientSocket.Shutdown(SocketShutdown.Both);
                    connectedWithServer = false;
                    foreach (var item in ListOfUsersWindow.ListofOpenedUser)
                    {
                        if (item.Key.ToLower() == EmailOfUser.ToLower())
                        {
                            ListofOpenedUser.Remove(EmailOfUser.ToLower());
                            break;
                        }
                    }
                    SQLDataAccess sql = new SQLDataAccess();
                    sql.UpdateAvailableStatus(EmailOfUser, "F");
                }

            }
            catch(Exception ex)
            {
                connectedWithServer = false;
                clientSocket.Shutdown(SocketShutdown.Both);
                clientSocket.Dispose();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                GC.Collect();
                Environment.Exit(0);
            }
            
        }
        public void InitializeConnection()
        {
            try
            {
                int port = 11000;
                IPAddress Ipaddress = IPAddress.Parse("127.0.0.1");
                clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint ep = new IPEndPoint(Ipaddress, port);
                clientSocket.Connect(ep);
                connectedWithServer = true;
                ChatWindow.Connected = true;
                ChatWindow.clientSocket = clientSocket;
                System.Threading.Thread RecieveThread = new System.Threading.Thread(new System.Threading.ThreadStart(() => RecieveMessage(clientSocket)));
                RecieveThread.Start();
                byte[] msgtoserver = System.Text.Encoding.ASCII.GetBytes(EmailOfUser + "$");
                clientSocket.Send(msgtoserver);
            }
            catch (Exception)
            {
                MessageBox.Show("Server is not responding! Not able to connect to server,Please try again ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        public void RecieveMessage(Socket client)
        {
            try
            {
                String LengthOfFile = null;
                int count = 0;
                long totalSize = 0;
                bool IsFile = false;
                String MessageRecieved = null;
                int IndexOfLengthOfFile = 0;
                int i = 0;
                SQLDataAccess sql = new SQLDataAccess();
                while (connectedWithServer)
                {
                    byte[] BytemessageFromServer = new byte[10000000];
                    int bytesize = client.Receive(BytemessageFromServer);
                    string messageFromServer = System.Text.Encoding.ASCII.GetString(BytemessageFromServer, 0, bytesize);
                    if (bytesize != 0)
                    {
                        if (count == 0)
                        {
                            IndexOfLengthOfFile = messageFromServer.IndexOf('$');
                            if (IndexOfLengthOfFile > 0)
                            {
                                LengthOfFile = messageFromServer.Substring(0, IndexOfLengthOfFile);
                                if (Char.IsNumber(LengthOfFile[0]))
                                {
                                    IsFile = true;
                                    count++;
                                }
                                else
                                {
                                    IsFile = false;
                                }
                            }
                            else
                            {
                                if (Char.IsNumber(messageFromServer[0]))
                                {
                                    IsFile = true;
                                    count++;
                                }
                                else
                                {
                                    IsFile = false;
                                }

                            }
                        }
                        if (IsFile == false)
                        {
                            if (messageFromServer == "Wsdrf@#%uevl")
                            {
                                count = 0;
                                connectedWithServer = true;
                            }
                            else
                            {
                                if (messageFromServer.Substring(IndexOfLengthOfFile + 1) != "Di@sc@on@ne@ct@" )
                                {
                                    if (ListofOpenedUser.Count != 0)
                                    {
                                        string email = messageFromServer.Substring(0, IndexOfLengthOfFile);
                                        if (ListofOpenedUser.Any(item => item.Key.ToLower() == email.ToLower()))
                                        {
                                            ListofOpenedUser[email.ToLower()].UpdateChatMessageBox(messageFromServer.Substring(IndexOfLengthOfFile + 1));

                                        }
                                        else
                                        {
                                            ChatWindow.EmailOfSender = EmailOfUser;
                                            ChatWindow.EmailOfReceiver = messageFromServer.Substring(0, IndexOfLengthOfFile);
                                            ChatWindow.NameofReciever = sql.GetUserName(messageFromServer.Substring(0, IndexOfLengthOfFile));
                                            ChatWindow window = new ChatWindow();
                                            ListofOpenedUser.Add(messageFromServer.Substring(0, IndexOfLengthOfFile).ToLower(), window);
                                            globalForm.Invoke((MethodInvoker)delegate ()
                                            {
                                                window.Text = messageFromServer.Substring(0, IndexOfLengthOfFile);
                                                window.Show();
                                            });
                                            window.UpdateChatMessageBox(messageFromServer.Substring(IndexOfLengthOfFile + 1));

                                        }
                                    }
                                    else
                                    {
                                        ChatWindow.EmailOfSender = EmailOfUser;
                                        ChatWindow.EmailOfReceiver = messageFromServer.Substring(0, IndexOfLengthOfFile);
                                        ChatWindow.NameofReciever = sql.GetUserName(messageFromServer.Substring(0, IndexOfLengthOfFile));
                                        ChatWindow window = new ChatWindow();
                                        ListofOpenedUser.Add(messageFromServer.Substring(0, IndexOfLengthOfFile), window);
                                        globalForm.Invoke((MethodInvoker)delegate ()
                                        {
                                            window.Text = messageFromServer.Substring(0, IndexOfLengthOfFile);
                                            window.Show();
                                        });
                                        window.UpdateChatMessageBox(messageFromServer.Substring(IndexOfLengthOfFile + 1));
                                    }

                                    count = 0;
                                }
                                else if(messageFromServer.Substring(IndexOfLengthOfFile + 1) != "Di@sc@on@ne@ct@")
                                {
                                    string emailOfsender = messageFromServer.Substring(0, IndexOfLengthOfFile).ToLower();
                                    if (ListofOpenedUser.Any(item => item.Key.ToLower() == emailOfsender.ToLower()))
                                    {
                                        ChatWindow.EmailOfReceiver = emailOfsender.ToLower();
                                        ListofOpenedUser[emailOfsender].UpdateChatMessageBox("has Disconnected");

                                    }
                                   
                                }

                            }
                        }
                        else
                        {
                            totalSize += bytesize;
                            MessageRecieved += messageFromServer;
                            if (LengthOfFile == totalSize.ToString() || totalSize > Convert.ToInt64(LengthOfFile))
                            {
                                String tempMsg = messageFromServer.Substring(IndexOfLengthOfFile + 1);
                                int indexOfMail = tempMsg.IndexOf('$');
                                string msgFromServerTogetEmail = tempMsg.Substring(indexOfMail+1);
                                int index = msgFromServerTogetEmail.IndexOf('$');
                                string EmailofReciever = msgFromServerTogetEmail.Substring(0, index);

                                String messagewithoutPreFix = tempMsg.Substring(index+indexOfMail + 2);
                                int IndexOfPost = messagewithoutPreFix.LastIndexOf('$');
                                String Extension = messagewithoutPreFix.Substring(IndexOfPost + 2);
                                String OriginalMessage = messagewithoutPreFix.Substring(0, IndexOfPost);
                                if(!Directory.Exists(@"c:\DowloadFromChat"))
                                {
                                    Directory.CreateDirectory(@"c:\DowloadFromChat");
                                }
                                string times = DateTime.Now.TimeOfDay.ToString(@"hh\.mm");
                                string date = DateTime.Now.Date.ToString("m")+"_"+times.ToString();
                                FileStream file = File.Create(@"c:\DowloadFromChat\File_"+date+"." + Extension);
                                file.Write(System.Text.Encoding.ASCII.GetBytes(OriginalMessage), 0, OriginalMessage.Length);
                                file.Close();
                                GC.Collect();
                                LengthOfFile = null;
                                totalSize = 0;
                                count = 0;
                                i++;
                                if (ListofOpenedUser.Count != 0)
                                {
                                    
                                    if (ListofOpenedUser.Any(item => item.Key.ToLower() == EmailofReciever.ToLower()))
                                    {
                                        ListofOpenedUser[EmailofReciever].UpdateChatMessageBox(@"File has been saved at C:\Users\sandeep singh\Documents\DowloadFromChat\File_" + DateTime.Now.Date + "." + Extension);

                                    }
                                    else
                                    {
                                        ChatWindow.EmailOfSender = EmailOfUser.ToLower();
                                        ChatWindow.EmailOfReceiver = EmailofReciever.ToLower();
                                        ChatWindow.NameofReciever = sql.GetUserName(EmailofReciever);
                                        ChatWindow window = new ChatWindow();
                                        ListofOpenedUser.Add(EmailofReciever.ToLower(), window);
                                        globalForm.Invoke((MethodInvoker)delegate ()
                                        {
                                            window.Text = EmailofReciever;
                                            window.Show();
                                        });
                                        window.UpdateChatMessageBox(@"File has been saved at C:\Users\sandeep singh\Documents\DowloadFromChat\File_" + DateTime.Now.Date + "." + Extension);

                                    }
                                }
                                else
                                {
                                    ChatWindow.EmailOfSender = EmailOfUser.ToLower();
                                    ChatWindow.EmailOfReceiver = EmailofReciever.ToLower();
                                    ChatWindow.NameofReciever = sql.GetUserName(EmailofReciever);
                                    ChatWindow window = new ChatWindow();
                                    ListofOpenedUser.Add(EmailofReciever.ToLower(), window);
                                    globalForm.Invoke((MethodInvoker)delegate ()
                                    {
                                        window.Text = EmailofReciever;
                                        window.Show();
                                    });
                                    window.UpdateChatMessageBox(@"File has been saved at C:\Users\sandeep singh\Documents\DowloadFromChat\File_" + DateTime.Now.Date + "." + Extension);

                                }

                                count = 0;
                            }

                        }
                    }
                }
            }
            catch(FileLoadException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch (Exception )
            {
                MessageBox.Show("Server is not responding! Please try after some time", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void UserPic_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                PictureBoxForm.img = UserPic.Image;
                PictureBoxForm form = new PictureBoxForm();
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
