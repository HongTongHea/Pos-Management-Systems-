using POS_MANAGEMENT_SYSTEM.Data.Model;
using POS_MANAGEMENT_SYSTEM.Data.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_MANAGEMENT_SYSTEM
{
    public partial class FormCustomer : Form
    {
        DataTable dtCustomr;
        public FormCustomer()
        {
            InitializeComponent();
            loadData(); 
            txtSearch.TextChanged += new EventHandler(txtSearch_TextChanged);
        }
     

        private void FormCustomer_Load(object sender, EventArgs e)
        {
            loadData();
        }
        private void loadData()
        {
            dtCustomr = CustomerServices.GetAll();

            DgCustomer.DataSource = dtCustomr;

            DgCustomer.Columns[0].Visible = true;
            DgCustomer.Columns[0].Width = 45;
            DgCustomer.Columns[0].HeaderText = "No";
            DgCustomer.Columns[1].Visible = true;
            DgCustomer.Columns[1].HeaderText = "Customer Name";
            DgCustomer.Columns[1].Width = 150;
            DgCustomer.Columns[2].Visible = true;
            DgCustomer.Columns[2].Width = 150;
            DgCustomer.Columns[3].Visible = true;
            DgCustomer.Columns[3].Width = 150;
            DgCustomer.Columns[4].Visible = true;
            DgCustomer.Columns[4].Width = 150;
            DgCustomer.Columns[5].Visible = true;
            DgCustomer.Columns[5].Width =150;
            DgCustomer.Columns[6].Visible = false;

        }



        private void btnAddNew_Click(object sender, EventArgs e)
        {
            FormCustomerAddEdit FormAddEdit = new FormCustomerAddEdit(null);
            if (FormAddEdit.ShowDialog() == DialogResult.OK)
            {
                loadData();
            }
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            if (DgCustomer.SelectedRows.Count <= 0)
                return;


            int customerid = Convert.ToInt32(DgCustomer.SelectedRows[0].Cells["customerid"].Value);
            Customer selectedcustomer = CustomerServices.Get(customerid);
            FormCustomerAddEdit FormAddEdit = new FormCustomerAddEdit(selectedcustomer);
            if (FormAddEdit.ShowDialog() == DialogResult.OK)
            {
                loadData();
                MessageBox.Show("Customer update successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DgCustomer.SelectedRows.Count <= 0)
                return;


            DialogResult confirm = MessageBox.Show("Are you sure to delete this record !",
                "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


            if (confirm != DialogResult.Yes)
                return;

            int customerid = Convert.ToInt32(DgCustomer.SelectedRows[0].Cells["customerid"].Value);
            CustomerServices.Delete(customerid);


            MessageBox.Show("Customer has delete Successfully");

            loadData();
        }

        private void DgCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgCustomer.SelectedRows.Count <= 0)
                return;

            int customerid = Convert.ToInt32(DgCustomer.SelectedRows[0].Cells[0].Value);

            Customer selectedcustomer = CustomerServices.Get(customerid);


        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            (DgCustomer.DataSource as DataTable).DefaultView.RowFilter = string.Format
           ("CustomerName LIKE '%{0}%' " +
           "OR CompanyName LIKE '%{0}%' " +
           "OR Phone LIKE '%{0}%' " +
           "OR Email LIKE '%{0}%' " +
           "OR Address LIKE '%{0}%'", 
           txtSearch.Text);
        }
    }
}
