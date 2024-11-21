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
    public class SaleService
    {
        public static DataTable GetAll()
        {
            SqlCommand command = new SqlCommand("spSaleGet", PosContext.GetConnection());
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter dapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            dapter.Fill(table);
            return table;
        }
        public static Sale Get(int saleid)
        {
            Sale sale = null;
            SqlCommand command = new SqlCommand("spSaleGet", PosContext.GetConnection());
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@saleid", saleid);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                sale = new Sale();
                sale.SaleId = Convert.ToInt32(reader["SaleId"].ToString());
                sale.TxnDate = Convert.ToDateTime(reader["TxnDate"].ToString());
                sale.RefNumber = reader["RefNumber"].ToString();
                sale.CustomerId = Convert.ToInt32(reader["CustomerId"].ToString());
                sale.EmployeeId = Convert.ToInt32(reader["EmployeeId"].ToString());
                sale.Note = reader["Note"].ToString();
            }
            reader.Close();
            return sale;
        }
        public static int Add(Sale sale)
        {
            int saleid = 0;
            try
            {
                SqlCommand command = new SqlCommand("spSaleAdd", PosContext.GetConnection());
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@txndate", sale.TxnDate);
                command.Parameters.AddWithValue("@refnumber", sale.RefNumber);
                command.Parameters.AddWithValue("@customerid", sale.CustomerId);
                command.Parameters.AddWithValue("@employeeid", sale.EmployeeId);
                command.Parameters.AddWithValue("@note", sale.Note);
                saleid = (int)command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return saleid;
        }
        public static void Update(Sale sale)
        {
            try
            {
                SqlCommand command = new SqlCommand("spSaleUpdate", PosContext.GetConnection());
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@saleid", sale.SaleId);
                command.Parameters.AddWithValue("@txndate", sale.TxnDate);
                command.Parameters.AddWithValue("@refnumber", sale.RefNumber);
                command.Parameters.AddWithValue("@customerid", sale.CustomerId);
                command.Parameters.AddWithValue("@employeeid", sale.EmployeeId);
                command.Parameters.AddWithValue("@note", sale.Note);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void Delete(int saleid)
        {
            try
            {
                SqlCommand command = new SqlCommand("spSaleDelete", PosContext.GetConnection());
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@saleid", saleid);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
