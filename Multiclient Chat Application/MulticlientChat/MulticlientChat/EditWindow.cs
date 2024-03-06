using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MulticlientChat
{
    public partial class EditWindow : Form
    {
        public static string UserName;
        public static string Status;
        public static string EmailofUser;
        public static Image image;
        string ImageFileName;
        public bool ThumbnailCallback()
        {
            return false;
        }
        public EditWindow()
        {

            InitializeComponent();
            try
            {
                SQLDataAccess sql = new SQLDataAccess();
                NametextBox.Text = UserName;
                StatustextBox.Text = Status;
                byte[] image = sql.GetUserImage(EmailofUser);
                if (image != null)
                {
                    MemoryStream ms = new MemoryStream(image);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    //Image myThumbnail = map.GetThumbnailImage(40, 40, myCallback, IntPtr.Zero);
                    pictureBox1.Image = new Bitmap((Bitmap)Image.FromStream(ms, true, true));
                }
                else
                {
                    Bitmap map = new Bitmap(Properties.Resources.no_image_icon);
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox1.Image = map;
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
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
                DialogResult result = file.ShowDialog();
                if (result == DialogResult.OK)
                {
                    ImageFileName = file.FileName;
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox1.Image = new Bitmap(file.FileName);
                    
                    button1.Text = "Change Pic";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SQLDataAccess sql = new SQLDataAccess();

                Image img = default(Image);
                if (ImageFileName != null)
                {
                    img = Image.FromFile(ImageFileName);
                    MemoryStream ms = new MemoryStream();
                    img.Save(ms, img.RawFormat);
                    int i = sql.UpdateUserInfo(NametextBox.Text, StatustextBox.Text, ms.ToArray(), EmailofUser);
                    if (i == 0)
                    {
                        ListOfUsersWindow.flagForUpdate = true;

                        this.Close();
                    }
                    else
                        MessageBox.Show("Not Done");
                }
                else
                {
                    int i = sql.UpdateUserInfoWithoutImage(NametextBox.Text, StatustextBox.Text, EmailofUser);
                    if (i == 0)
                    {
                        ListOfUsersWindow.flagForUpdate = true;

                        this.Close();
                    }
                    else
                        MessageBox.Show("server not responding! Please do after some time");

                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void EditWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                GC.Collect();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
