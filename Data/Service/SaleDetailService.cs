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
    public class SaleDetailService
    {
        public static DataTable Get(int saleid)
        {
            SqlCommand command = new SqlCommand("spSaleDetailGet", PosContext.GetConnection());
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@saleid", saleid);
            SqlDataAdapter dapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            dapter.Fill(table);
            return table;
        }
        public static void Add(SaleDetail saledetail)
        {
            try
            {

                SqlCommand command = new SqlCommand("spSaleDetailAdd", PosContext.GetConnection());
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@saleid ", saledetail.SaleId);
                command.Parameters.AddWithValue("@itemid", saledetail.ItemId);
                command.Parameters.AddWithValue("@description", saledetail.Description);
                command.Parameters.AddWithValue("@quantity", saledetail.Quantity);
                command.Parameters.AddWithValue("@price", saledetail.Price);
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
                SqlCommand command = new SqlCommand("spSaleDetailDelete", PosContext.GetConnection());
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@saleid ", saleid);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
