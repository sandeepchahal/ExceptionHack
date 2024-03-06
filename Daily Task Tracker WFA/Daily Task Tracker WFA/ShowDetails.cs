using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Daily_Task_Tracker_WFA
{
    public partial class ShowDetails : Form
    {
        public ShowDetails()
        {
            InitializeComponent();
        }

        private void ShowDetails_Load(object sender, EventArgs e)
        {
            FillGridView();
        }
        public void FillGridView()
        {
            try
            {
                dataGridView1.Rows.Clear();
                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DailyTaskDBConnectionString"].ToString());
                SqlCommand cmd = new SqlCommand("Select * from DailyTaskTracker", connection);
                connection.Open();
                 SqlDataReader reader= cmd.ExecuteReader();
                while(reader.Read())
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = reader["ApplicationName"].ToString();
                    dataGridView1.Rows[n].Cells[1].Value = reader["StartTime"].ToString();
                    dataGridView1.Rows[n].Cells[2].Value = reader["ExitTime"].ToString();
                    dataGridView1.Rows[n].Cells[3].Value = reader["TotalProcessTime"].ToString();
                    dataGridView1.Rows[n].Cells[4].Value = (Convert.ToInt64(reader["UserInteractionTime"]) / 1000).ToString();


                }
                connection.Close();
            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
