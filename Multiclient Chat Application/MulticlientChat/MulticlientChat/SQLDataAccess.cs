using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MulticlientChat
{
    class SQLDataAccess
    {
        public DataTable GetListOfUsers(string email)
        {
            try
            {
                DataTable dt = new DataTable("ChatUsers");
                string query = "select * from Chat where Email <>'"+email+"'and Available='T'";

                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ChatConnectionString"].ToString());
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(dt);
                conn.Close();
                return dt;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        public int UpdateAvailableStatus(string email,string status)
        {
            try
            {
                int result = 0;
                string query = "Update Chat SET Available=@available where Email='" + email + "'";
                string CS = ConfigurationManager.ConnectionStrings["ChatConnectionString"].ToString();
                SqlConnection conn = new SqlConnection(CS);
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@available", status);
                conn.Open();
                result = cmd.ExecuteNonQuery();
                if (result > 0)
                    return 0;
                else
                    return 1;
            }
            catch (Exception )
            {
                return -1;
            }

        }
        public string GetUserName(string Email)
        {
            try
            {
                string query = "select * from Chat where Email ='" + Email + "'";
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ChatConnectionString"].ToString());
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    return reader["DisplayName"].ToString();
                }
                return null;
            }
            catch(Exception)
            {
                return null;
            }
        }

        public string GetUserStatus(string Email)
        {
            try
            {
                string query = "select * from Chat where Email ='" + Email + "'";
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ChatConnectionString"].ToString());
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    return reader["StatusOfUser"].ToString();
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public byte[] GetUserImage(string Email)
        {
            try
            {
                string query = "select * from Chat where Email ='" + Email + "'";
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ChatConnectionString"].ToString());
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    return (byte[])reader["Image"];
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public int UpdateUserInfoWithoutImage(string DisplayName, string status, string email)
        {
            try
            {
                int result = 0;
                string query = "Update Chat SET DisplayName=@DN, StatusOfUser=@Status where Email='" + email + "'";
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ChatConnectionString"].ToString());
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@DN", DisplayName);
                cmd.Parameters.AddWithValue("@Status", status);
                
                conn.Open();
                result = cmd.ExecuteNonQuery();
                if (result > 0)
                    return 0;
                else
                    return 1;

            }
            catch (Exception )
            {
                return -1;
            }
        }
        public bool DeleteALLDataFromLocal()
        {
            try
            {
                string query = "DELETE * FROM LocalUserInfo";
                SqlCeConnection conn = new SqlCeConnection(ConfigurationManager.ConnectionStrings["LocalUserChat"].ToString());
                SqlCeCommand cmd = new SqlCeCommand(query, conn);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                conn.Close();
                if (rows > 0)
                    return true;
                else
                    return false;
            }catch(Exception )
            {
                return false;
            }
        }
        public int UpdateUserInfo(string DisplayName,string status,byte[]image,string email)
        {
            try
            {
                int result = 0;
                string query = "Update Chat SET DisplayName=@DN, StatusOfUser=@Status, Image=@Image where Email='"+email+"'";
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ChatConnectionString"].ToString());
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@DN", DisplayName);
                cmd.Parameters.AddWithValue("@Status", status);
                cmd.Parameters.AddWithValue("@Image", image);
                conn.Open();
                result = cmd.ExecuteNonQuery();
                 if (result > 0)
                    return 0;
                 else
                    return 1;
                
            }
            catch (Exception)
            {
                return -1;
            }
        }
        public int RegisterUser(string DisplayName,string Email,string Status)
        {
            try
            {
                int result = 0;
                string query = "insert into Chat(Email,DisplayName,StatusOfUser) values (@Email ,@DisplayName,@status)";
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ChatConnectionString"].ToString()))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", Email);
                        cmd.Parameters.AddWithValue("@DisplayName", DisplayName);
                        cmd.Parameters.AddWithValue("@status", Status);

                        conn.Open();
                        result = cmd.ExecuteNonQuery();
                    }
                    if (result > 0)
                        return 0;
                    else
                        return 1;
                }
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public int RegisterUser(string DisplayName, string Email,string status,byte[] image)
        {
            try
            {
                int result = 0;
                string query = "insert into Chat(Email,DisplayName,StatusOfUser,Image) values (@Email ,@DisplayName,@status,@image)";
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ChatConnectionString"].ToString()))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", Email);
                        cmd.Parameters.AddWithValue("@DisplayName", DisplayName);
                        cmd.Parameters.AddWithValue("@status", status);
                        cmd.Parameters.AddWithValue("@image", image);
                        conn.Open();
                        result = cmd.ExecuteNonQuery();
                    }
                    if (result > 0)
                        return 0;
                    else
                        return 1;
                }
            }catch(Exception)
            {
                return -1;
            }
        }
        public string GetUserEmailFromLocal()
        {
            try
            {
               
                String ConnectionString = ConfigurationManager.ConnectionStrings["LocalUserChat"].ToString();
                String query = "select * from LocalUserInfo";
                using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
                {
                    using (SqlCeCommand cmd = new SqlCeCommand(query, conn))
                    {
                        conn.Open();
                        SqlCeDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            if (!String.IsNullOrEmpty(reader["Email"].ToString()))
                            {
                                return reader["Email"].ToString();
                            }
                            else
                            {
                                return null;
                            }
                        }
                    }
                }
                return null;
            }catch(Exception ex)
            {
                return null;
            }
        }
        public int AddEmailToLocal(string Email,string DisplayName,string status)
        {
            try
            {
                string query = "insert into LocalUserInfo(Email,Status) values (@Email,@Status)";
                string connectionString = ConfigurationManager.ConnectionStrings["LocalUserChat"].ToString();
                using (SqlCeConnection conn = new SqlCeConnection(connectionString))
                {
                    using (SqlCeCommand cmd = new SqlCeCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", Email);
                        
                        cmd.Parameters.AddWithValue("@Status", status);
                        conn.Open();
                        int result = cmd.ExecuteNonQuery();
                        if (result == 0)
                            return 0;
                        else
                            return 1;
                    }
                    
                }
            }
            catch (Exception)
            {
                return -1;
            }
        }
        public int CheckEmailFromServerDB(string Email)
        {
            try
            {
                String ConnectionString = ConfigurationManager.ConnectionStrings["ChatConnectionString"].ToString();
                string query = "select Email from Chat";
                SqlConnection conn = new SqlConnection(ConnectionString);
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader Reader = cmd.ExecuteReader();
                while (Reader.Read())
                {
                    if (Reader["Email"].ToString().ToLower() == Email.ToLower())
                    {
                        return 0;
                    }
                }
                return 1;
            }catch(Exception)
            {
                return -1;
            }
        }
       
    }
}
