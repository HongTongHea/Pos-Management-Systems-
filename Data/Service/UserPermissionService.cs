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
    public class UserPermissionService
    {
        public static DataTable Get(int userid)
        {
            SqlCommand command = new SqlCommand("spUserPermissionGet", PosContext.GetConnection());
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@userid", userid);
            SqlDataAdapter dapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            dapter.Fill(table);
            return table;
        }
        public static void Add(UserPermission permission)
        {
            try
            {
                SqlCommand command = new SqlCommand("spUserPermissionAdd", PosContext.GetConnection());
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@userid", permission.UserId);
                command.Parameters.AddWithValue("@permissionname", permission.PermissionName);
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
                SqlCommand command = new SqlCommand("spUserPermissionDelete", PosContext.GetConnection());
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@userid ", userid);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
