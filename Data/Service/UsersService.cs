using POS_MANAGEMENT_SYSTEM.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_MANAGEMENT_SYSTEM.Data.Service
{
    public class UsersService
    {
        public static DataTable GetAll()
        {
            SqlCommand command = new SqlCommand("spUserGet", PosContext.GetConnection());
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public static Users Get(int userid)
        {
            Users user = null;
            SqlCommand command = new SqlCommand("spUserGet", PosContext.GetConnection());
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@userid", userid);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                user = new Users();
                user.UserId = Convert.ToInt32(reader["UserId"].ToString());
                user.Username = reader["UserName"].ToString();
                user.Password = reader["Password"].ToString();
                user.IsAdmin = Convert.ToBoolean(reader["IsAdmin"]);
            }
            reader.Close();
            return user;
        }
        public static void Add(Users user)
        {
            try
            {
                SqlCommand command = new SqlCommand("spUserAdd", PosContext.GetConnection());
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@username ", user.Username);
                command.Parameters.AddWithValue("@password ", user.Password);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void Update(Users user)
        {
            try
            {
                SqlCommand command = new SqlCommand("spUserUpdate", PosContext.GetConnection());
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@userid ", user.UserId);
                command.Parameters.AddWithValue("@username ", user.Username);
                command.Parameters.AddWithValue("@password ", user.Password);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void Delete(int userid)
        {
            try
            {
                SqlCommand command = new SqlCommand("spUserDelete", PosContext.GetConnection());
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@userid", userid);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static Users Login(string username, string password)
        {
            Users user = null;
            SqlCommand command = new SqlCommand("spUserLogin", PosContext.GetConnection());
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", password);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                user = new Users();
                user.UserId = Convert.ToInt32(reader["UserId"].ToString());
                user.Username = reader["UserName"].ToString();
                user.Password = reader["Password"].ToString();
                user.IsAdmin = Convert.ToBoolean(reader["IsAdmin"]);
            }
            reader.Close();
            return user;
        }
    }
}
