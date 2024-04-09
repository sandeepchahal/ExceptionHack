using System;
using System.Configuration;
using System.Data.SqlClient;
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
                    var totalProcessTime = TimeSpan.Parse(reader["TotalProcessTime"].ToString());
                    dataGridView1.Rows[n].Cells[3].Value = totalProcessTime.ToString();

                    var userInteractionTime = reader["UserInteractionTime"];
                    if (userInteractionTime != DBNull.Value)
                    {
                        string interactionTime = Convert.ToDouble(userInteractionTime) >= 1000 
                            ? $"{(Convert.ToDouble(userInteractionTime) / 1000)} seconds" 
                            : $"{userInteractionTime} miliseconds";

                        dataGridView1.Rows[n].Cells[4].Value = interactionTime;
                    }
                    else
                    {
                        dataGridView1.Rows[n].Cells[4].Value = ""; // Or any default value you prefer
                    }

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
