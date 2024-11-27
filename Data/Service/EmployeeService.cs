using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS_MANAGEMENT_SYSTEM.Data.Model;
using System.Windows.Forms;
using System.Net;

namespace POS_MANAGEMENT_SYSTEM.Data.Service
{

    public class EmployeeService
    {
        public static DataTable GetAll()
        {
            SqlCommand command = new SqlCommand("spEmployeeGet", PosContext.GetConnection());
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
            
        }
        public static Employee Get(int employeeid)
        {
            Employee employee = null;
            SqlCommand command = new SqlCommand("spEmployeeGet", PosContext.GetConnection());
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@employeeId", employeeid);

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                employee = new Employee();
                employee.EmployeeId = Convert.ToInt32(reader["EmployeeId"].ToString());
                employee.EmployeeName = reader["EmployeeName"].ToString();
                employee.Sex = reader["Sex"].ToString();
                employee.DoB = Convert.ToDateTime(reader["DoB"]);
                employee.Address = reader["Address"].ToString();
                employee.MaritalStatus = reader["MaritalStatus"].ToString();
                employee.HaveSpouse = Convert.ToBoolean(reader["HaveSpouse"]);
                employee.NumberOfChildren = Convert.ToInt32(reader["NumberOfChildren"]);
                employee.HiredDate = Convert.ToDateTime(reader["HiredDate"]);
                employee.Position = reader["Position"].ToString();
                employee.Department = reader["Department"].ToString();
                employee.Salary = Convert.ToDouble(reader["Salary"]);

            }

            reader.Close();

            return employee;
        }
        public static void Add(Employee employee)

        {
            try
            {
                SqlCommand command = new SqlCommand("spEmployeeAdd", PosContext.GetConnection());
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@employeeName", employee.EmployeeName);
                command.Parameters.AddWithValue("@sex", employee.Sex);
                command.Parameters.AddWithValue("@dob", employee.DoB);
                command.Parameters.AddWithValue("@Address", employee.Address);
                command.Parameters.AddWithValue("@maritalstatus", employee.MaritalStatus);
                command.Parameters.AddWithValue("@havespouse", employee.HaveSpouse);
                command.Parameters.AddWithValue("@numberofchildren", employee.NumberOfChildren);
                command.Parameters.AddWithValue("@hireddate", employee.HiredDate);
                command.Parameters.AddWithValue("@position", employee.Position);
                command.Parameters.AddWithValue("@department", employee.Department);
                command.Parameters.AddWithValue("@salary", employee.Salary);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        public static void Update(Employee employee)

        {
            try
            {
                SqlCommand command = new SqlCommand("spEmployeeUpdate", PosContext.GetConnection());
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@employeeId", employee.EmployeeId);
                command.Parameters.AddWithValue("@employeeName", employee.EmployeeName);
                command.Parameters.AddWithValue("@sex", employee.Sex);
                command.Parameters.AddWithValue("@dob", employee.DoB);
                command.Parameters.AddWithValue("@Address", employee.Address);
                command.Parameters.AddWithValue("@maritalstatus", employee.MaritalStatus);
                command.Parameters.AddWithValue("@havespouse", employee.HaveSpouse);
                command.Parameters.AddWithValue("@numberofchildren", employee.NumberOfChildren);
                command.Parameters.AddWithValue("@hireddate", employee.HiredDate);
                command.Parameters.AddWithValue("@position", employee.Position);
                command.Parameters.AddWithValue("@department", employee.Department);
                command.Parameters.AddWithValue("@salary", employee.Salary);

                command.ExecuteNonQuery();
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }
        public static void Delete(int employeeid)
        {
            SqlCommand command = new SqlCommand("spEmployeeDelete", PosContext.GetConnection());
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@EmployeeId", employeeid);

            command.ExecuteNonQuery();
        }

    }

}
