using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_MANAGEMENT_SYSTEM.Data
{
    public class PosContext
    {
        static SqlConnection db;
        public static void OpenConnection()
        {
            if (db == null)
            {
                db = new SqlConnection();
                db.ConnectionString = "Data Source = HONGTONGHEA\\SQLEXPRESS;Initial Catalog = POS; Integrated Security = true ";
                db.Open();
            }
        }
        public static SqlConnection GetConnection()
        {
            if (db == null)
            {
                OpenConnection();
            }
            return db;
        }
        public static void CloseConnection()
        {
            if (db != null)
            {
                db.Close();
            }
            db = null;
        }
    }
}
