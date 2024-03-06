using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MulticlientChat
{
    public partial class PictureBoxForm : Form
    {
        public static Image img = null;
        public PictureBoxForm()
        {
            InitializeComponent();
        }

        private void PictureBoxForm_Load(object sender, EventArgs e)
        {
            try
            {
                if (img != null) {

                    Bitmap map = new Bitmap(img);
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox1.Image = map;
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
