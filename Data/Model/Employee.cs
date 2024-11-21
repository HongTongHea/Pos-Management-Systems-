using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_MANAGEMENT_SYSTEM.Data.Model
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Sex { get; set; }
        public DateTime DoB { get; set; }
        public string Address { get; set; }
        public string MaritalStatus { get; set; }
        public bool HaveSpouse { get; set; }
        public int NumberOfChildren { get; set; }
        public DateTime HiredDate { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }
        public double Salary { get; set; }
    }
}
