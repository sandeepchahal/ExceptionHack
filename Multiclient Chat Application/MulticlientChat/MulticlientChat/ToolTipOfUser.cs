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
    public partial class ToolTipOfUser : Form
    {
        public static String value =null;
        public static DataTable dt;
        public ToolTipOfUser()
        {
            InitializeComponent();
        }
        public bool ThumbnailCallback()
        {
            return false;
        }

        private void ToolTip_Load(object sender, EventArgs e)
        {
            try
            {
                UserEmailLbl.Text = "Email:";
                NameLbl.Text = "Name:";
                UserStatusLbl.Text = "Status:";


                UserEmailLbl.Visible = true;
                NameLbl.Visible = true;
                UserStatusLbl.Visible = true;
                pictureBox1.Visible = true;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    String valueOfDataTable = dt.Rows[i][2].ToString();
                    if (value == dt.Rows[i][2].ToString())
                    {
                        NameLbl.Text += ": " + dt.Rows[i][2].ToString();
                        UserEmailLbl.Text += ": " + dt.Rows[i][1].ToString();
                        String available = dt.Rows[i][5].ToString().ToLower();
                        if (available == "t")
                            UserStatusLbl.Text += ": Available";
                        else
                            UserStatusLbl.Text += ": Not Available";

                        if (!String.IsNullOrEmpty(dt.Rows[i][3].ToString()))
                        {
                            byte[] image = (byte[])dt.Rows[i][3];
                            if (image != null)
                            {
                                MemoryStream ms = new MemoryStream(image);

                                if (ms != null)
                                {
                                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                                    pictureBox1.Image = new Bitmap((Bitmap)Image.FromStream(ms, true, true));
                                }
                            }
                            else
                            {
                                {
                                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                                    Bitmap map = new Bitmap(Properties.Resources.no_image_icon);
                                }
                            }
                        }
                        else
                        {
                            Bitmap map = new Bitmap(Properties.Resources.no_image_icon);
                            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                            pictureBox1.Image = map;
                        }

                    }
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void ToolTipOfUser_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
            GC.Collect(); 
        }
    }
}
