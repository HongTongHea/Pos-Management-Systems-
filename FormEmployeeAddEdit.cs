using POS_MANAGEMENT_SYSTEM.Data.Model;
using POS_MANAGEMENT_SYSTEM.Data.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace POS_MANAGEMENT_SYSTEM
{
    public partial class FormEmployeeAddEdit : Form
    {
        Employee _employee;
        bool isnew;
        public FormEmployeeAddEdit(Employee employee)
        {
            InitializeComponent();
            if (employee == null)
            {
                lblTitle.Text = "Add Employee";
                btnSave.Text = "Save";


                _employee = new Employee();
                isnew = true;
            }
            else
            {
                lblTitle.Text = "Edit Employee";
                btnSave.Text = "Save";
                txtEmployeeName.Text = employee.EmployeeName;
                txtSex.Text = employee.Sex;
                dtEmployee.Value = employee.DoB;
                txtMartalStatus.Text = employee.MaritalStatus;
                checkBox1.Checked= employee.HaveSpouse;
                txtNumberOfChild.Text = employee.NumberOfChildren.ToString();
                txtPosition.Text = employee.Position;
                txtDepartment.Text = employee.Department;
                dtHiredDate.Value = employee.HiredDate;
                txtSalary.Text = employee.Salary.ToString("N2");
                txtAddress.Text = employee.Address;

                _employee = employee;
                isnew = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!Dovalidation())
                return;

            _employee.EmployeeName = txtEmployeeName.Text;
            _employee.Sex = txtSex.Text;
            _employee.DoB = dtEmployee.Value;
            _employee.MaritalStatus = txtMartalStatus.Text;
            _employee.HaveSpouse = checkBox1.Checked;
            _employee.NumberOfChildren = int.Parse(txtNumberOfChild.Text);
            _employee.HiredDate = dtHiredDate.Value;
            _employee.Position = txtPosition.Text;
            _employee.Department = txtDepartment.Text;
            _employee.Salary = double.Parse(txtSalary.Text);
            _employee.Address = txtAddress.Text;

            if (isnew)
            {
                EmployeeService.Add(_employee);
                MessageBox.Show("Employee add successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                EmployeeService.Update(_employee);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private bool Dovalidation()
        {
            bool result = true;
            if (string.IsNullOrWhiteSpace(txtEmployeeName.Text))
            {
                epEmployeeName.SetError(txtEmployeeName, "Employee Name is required");
                result = false;
            }
            else if (string.IsNullOrWhiteSpace(txtSex.Text))
            {
                epEmployeeName.SetError(txtSex, "Employeeis Sex required");
                result = false;
            }
            else if (string.IsNullOrWhiteSpace(txtPosition.Text))
            {
                epEmployeeName.SetError(txtPosition, "Position is required");
                result = false;
            }
            else if (string.IsNullOrWhiteSpace(txtPosition.Text))
            {
                epEmployeeName.SetError(txtPosition, "Position is required");
                result = false;
            }
            else if (string.IsNullOrWhiteSpace(txtDepartment.Text))
            {
                epEmployeeName.SetError(txtDepartment, "Department is required");
                result = false;
            }
            else if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                epEmployeeName.SetError(txtAddress, "Address is required");
                result = false;
            }
            return result;
        }

        
    }
}
