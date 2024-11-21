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
    public partial class FormCustomer : Form
    {
        DataTable dtCustomr;
        public FormCustomer()
        {
            InitializeComponent();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {

        }
        private void loadData()
        {
            dtCustomr = CustomerServices.GetAll();

            DgCustomer.DataSource = dtCustomr;

            DgCustomer.Columns[0].Visible = true;
            DgCustomer.Columns[0].Width = 70;
            DgCustomer.Columns[0].HeaderText = "ID";
            DgCustomer.Columns[1].Visible = true;
            DgCustomer.Columns[1].HeaderText = "Customer Name";
            DgCustomer.Columns[1].Width = 150;

            DgCustomer.Columns[2].Visible = true;
            DgCustomer.Columns[2].Width = 150;
            DgCustomer.Columns[3].Visible = true;

            DgCustomer.Columns[4].Visible = true;
            DgCustomer.Columns[4].Width = 150;
            DgCustomer.Columns[5].Visible = true;
            DgCustomer.Columns[5].Width = 150;
            DgCustomer.Columns[6].Visible = true;
        }


        private void FormCustomer_Load(object sender, EventArgs e)
        {
            loadData();
        }
    }
}
