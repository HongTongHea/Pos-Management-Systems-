using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_MANAGEMENT_SYSTEM.Data.Model
{
    public class Sale
    {
        public int SaleId { get; set; }
        public DateTime TxnDate { get; set; }
        public string RefNumber { get; set; }
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public string Note { get; set; }
    }
}
