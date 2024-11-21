using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_MANAGEMENT_SYSTEM.Data.Service
{
    public class ItemService
    {
        public static DataTable GetAll()
        {
            SqlCommand command = new SqlCommand("spItemGet", PosContext.GetConnection());
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter dapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            dapter.Fill(table);
            return table;
        }

    }
}
