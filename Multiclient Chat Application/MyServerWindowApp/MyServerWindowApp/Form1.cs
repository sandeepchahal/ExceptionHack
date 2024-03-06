using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyServerWindowApp
{
    public partial class Form1 : Form
    {
        private Dictionary<string, Socket> ListofUsers = new Dictionary<string, Socket>();
        bool Connected = false;
        Socket ListenerSocket = default(Socket);
        bool Islistening = false;
        public Form1()
        {
            InitializeComponent();
        }
        private delegate void UpdateLogCallback(string msg);
        private delegate void UpdateLogCallbackForListBox(string msg);



        private void Form1_Load(object sender, EventArgs e)
        {
            IpTextBox.Text = "127.0.0.1";
            PortTextBox.Text = "11000";
        }
        private void UpdateLog(string strMessage)
        {
            waitingLbl.Text = strMessage;
        }
        private void UpdateListBoxLog(string strMessage)
        {
            listBox.Items.Add(strMessage);
        }
        public void InitializeConnection()
        {
            int port =Convert.ToInt16(PortTextBox.Text);
            IPAddress Ipaddress = IPAddress.Parse(IpTextBox.Text);
            ListenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ep = new IPEndPoint(Ipaddress, port);
            ListenerSocket.Bind(ep);
            ListenerSocket.Listen(100);
            this.Invoke(new UpdateLogCallback(this.UpdateLog), new object[] { "Server has started"});
            Connected = true;
            Islistening = true;
            Socket ClientSocket = default(Socket);
            int counter = 0;
            while (Islistening)
            {
                counter++;
                ClientSocket = ListenerSocket.Accept();
                byte[] messageToClient = Encoding.ASCII.GetBytes("Wsdrf@#%uevl");
                ClientSocket.Send(messageToClient);
                System.Threading.Thread AddUserThread = new System.Threading.Thread(new System.Threading.ThreadStart(() => AddUsers(ClientSocket)));
                AddUserThread.Start();
            }


        }
        private void AddUsers(Socket client)
        {
            String SenderEmail = null;
            while (SenderEmail == null)
            {
                byte[] messageByte = new byte[1024];
                int size = client.Receive(messageByte);
                if (size != 0)
                {
                    String TransmitClientMessage = System.Text.Encoding.ASCII.GetString(messageByte, 0, size);
                    int index = TransmitClientMessage.IndexOf('$');
                    SenderEmail = TransmitClientMessage.Substring(0, index).ToLower();
                    if (!ListofUsers.Any(h => h.Key == SenderEmail))
                    {
                        ListofUsers.Add(SenderEmail.ToLower(),client);
                        this.Invoke(new UpdateLogCallbackForListBox(this.UpdateListBoxLog), new object[] { SenderEmail+" Has connected" });
                    }
                }
            }
            System.Threading.Thread ReceiveThread = new System.Threading.Thread(new System.Threading.ThreadStart(() => BroadCastMessage(client)));
            ReceiveThread.Start();
            Thread.CurrentThread.Abort();
        }
        public void BroadCastMessage(Socket client)
        {
            Socket SenderSocket = default(Socket);
            String LengthOfFile = null;
            int count = 0;
            long totalSize = 0;
            bool IsFile = false;
            String MessageRecieved = null;
            int IndexOfLengthOfFile = 0;
            
            while (Islistening)
            {
                byte[] buffer = new byte[10000000];
                int bytesize = client.Receive(buffer);
                if (bytesize >0)
                {
                    string messageFromClient = System.Text.Encoding.ASCII.GetString(buffer, 0, bytesize);

                    if (count == 0)
                    {
                        IndexOfLengthOfFile = messageFromClient.IndexOf('$');
                        LengthOfFile = messageFromClient.Substring(0, IndexOfLengthOfFile);
                        if (IndexOfLengthOfFile > 0)
                        {
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
                    }
                    if (IsFile == false)
                    {
                        if (messageFromClient.Substring(IndexOfLengthOfFile + 1) == "Di@sc@on@ne@ct@")
                        {
                            this.Invoke(new UpdateLogCallbackForListBox(this.UpdateListBoxLog), new object[] { messageFromClient.Substring(0, IndexOfLengthOfFile) + " has disconnected Permanently " });
                            ListofUsers.Remove(messageFromClient.Substring(0, IndexOfLengthOfFile).ToLower());
                            Thread.CurrentThread.Abort();
                        }
                        else
                        {
                            string m = messageFromClient.Substring(IndexOfLengthOfFile + 1);
                            int Mindex = m.IndexOf('$');
                            if (Mindex > 0)
                            {
                                String Mail = messageFromClient.Substring(0, IndexOfLengthOfFile);
                                if (ListofUsers.Any(t => t.Key.ToLower() == Mail.ToLower()))
                                {
                                    SenderSocket = ListofUsers[Mail.ToLower()];
                                    if (SenderSocket != null)
                                    {
                                        count = 0;
                                        byte[] message = System.Text.Encoding.ASCII.GetBytes(messageFromClient.Substring(IndexOfLengthOfFile + 1));
                                        SenderSocket.Send(message, 0, message.Length, SocketFlags.None);
                                    }
                                }
                                else
                                {
                                    String UsernotAvail = Mail.ToLower() + "$User is not available! Message can not be transferred";
                                    string mailsender = m.Substring(0, Mindex);
                                    SenderSocket = ListofUsers[mailsender.ToLower()];
                                    SenderSocket.Send(System.Text.Encoding.ASCII.GetBytes(UsernotAvail), 0, UsernotAvail.Length, SocketFlags.None);
                                    count = 0;
                                }
                            }
                            
                        }

                    }
                    else // send File to reciver user
                    {
                        totalSize += bytesize;
                        MessageRecieved += messageFromClient;
                        if (LengthOfFile == totalSize.ToString() || totalSize > Convert.ToInt64(LengthOfFile))
                        {
                            String TempMessage = messageFromClient.Substring(IndexOfLengthOfFile + 1);
                            int indexForMail = TempMessage.IndexOf('$');
                            string EmailofReciever = TempMessage.Substring(0, indexForMail);
                            SenderSocket = ListofUsers[EmailofReciever];
                            if(SenderSocket!=null)
                            {
                                SenderSocket.Send(System.Text.Encoding.ASCII.GetBytes(MessageRecieved), 0, MessageRecieved.Length, SocketFlags.None);
                                MessageRecieved = null;
                                LengthOfFile = null;
                                count = 0;
                                totalSize = 0;
                            }
                        }
                    }
                }
            }
            Thread.CurrentThread.Abort();
        }

        private void ListeningBtn_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(PortTextBox.Text) && !String.IsNullOrEmpty(IpTextBox.Text))
            {
                if (!Connected)
                {
                    Thread startingThread = new Thread(() => InitializeConnection());
                    startingThread.Start();
                    ListeningBtn.Text = "Disconnect";
                    IpTextBox.Enabled = false;
                    PortTextBox.Enabled = false;
                }
                else
                {
                    
                    ListeningBtn.Text = "Connect";
                    string message = "server has disconnected!";
                    foreach (var item in ListofUsers)
                    {
                        item.Value.Send(System.Text.Encoding.ASCII.GetBytes(message), 0, message.Length, SocketFlags.None);
                        item.Value.Shutdown(SocketShutdown.Both);
                    }
                    ListofUsers.Clear();
                    this.Invoke(new UpdateLogCallback(this.UpdateLog), new object[] { "Server has disconnected" });
                    Islistening = false;
                    Connected = false;

                    ListenerSocket.Shutdown(SocketShutdown.Both);
                    ListenerSocket.Close();
                    ListenerSocket.Dispose();
                    GC.Collect();
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Islistening = false;
                foreach (var item in ListofUsers)
                {
                    item.Value.Shutdown(SocketShutdown.Both);
                }
                ListofUsers.Clear();
                GC.Collect();
                Environment.Exit(0);
               
            }
            catch
            {
                GC.Collect();

                Environment.Exit(0);
            }
        }
    }
}
