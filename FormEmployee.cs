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

namespace POS_MANAGEMENT_SYSTEM
{
    public partial class FormEmployee : Form
    {
        DataTable dtEmployee;
        public FormEmployee()
        {
            InitializeComponent();
        }
        private void FormEmployee_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
           FormEmployeeAddEdit FormAddEdit = new FormEmployeeAddEdit(null);
            if (FormAddEdit.ShowDialog() == DialogResult.OK)
            {
                loadData();
            }
        }

        private void loadData()
        {
            dtEmployee = EmployeeService.GetAll();

            DgEmployee.DataSource = dtEmployee;

            DgEmployee.Columns[0].Visible = true;
            DgEmployee.Columns[0].Width = 35;
            DgEmployee.Columns[0].HeaderText = "No";
            DgEmployee.Columns[1].Visible = true;
            DgEmployee.Columns[1].Width = 110;

            DgEmployee.Columns[2].Visible = true;
            DgEmployee.Columns[3].Visible = true;
            DgEmployee.Columns[4].Visible = true;
            DgEmployee.Columns[5].Visible = true;
            DgEmployee.Columns[5].Width = 90;
            DgEmployee.Columns[6].Visible = true;
            DgEmployee.Columns[7].Width = 100;
            DgEmployee.Columns[10].Visible = true;
            DgEmployee.Columns[10].Width = 80;
            DgEmployee.Columns[11].Visible = true;
            DgEmployee.Columns[12].Visible = false;
            DgEmployee.Columns[13].Visible = false;


        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            (DgEmployee.DataSource as DataTable).DefaultView.RowFilter = string.Format
           ("EmployeeName LIKE '%{0}%' " +
           "OR Sex LIKE '%{0}%' " +
           "OR Address LIKE '%{0}%'",
           txtSearch.Text);
        }

        private void DgEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgEmployee.SelectedRows.Count <= 0)
                return;

            int employeeid = Convert.ToInt32(DgEmployee.SelectedRows[0].Cells[0].Value);

            Employee selectedemployee = EmployeeService.Get(employeeid);

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DgEmployee.SelectedRows.Count <= 0)
                return;


            DialogResult confirm = MessageBox.Show("Are you sure to delete this record !",
                "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


            if (confirm != DialogResult.Yes)
                return;

            int employeeid = Convert.ToInt32(DgEmployee.SelectedRows[0].Cells["employeeid"].Value);
            EmployeeService.Delete(employeeid);


            MessageBox.Show("Employee has delete Successfully");

            loadData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (DgEmployee.SelectedRows.Count <= 0)
                return;


            int employeeid = Convert.ToInt32(DgEmployee.SelectedRows[0].Cells["employeeid"].Value);
            Employee selectedemployee = EmployeeService.Get(employeeid);
            FormEmployeeAddEdit FormAddEdit = new FormEmployeeAddEdit(selectedemployee);
            if (FormAddEdit.ShowDialog() == DialogResult.OK)
            {
                loadData();
                MessageBox.Show("Customer update successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
