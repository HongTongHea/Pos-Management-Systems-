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
    public partial class FormSale : Form
    {
        DataTable dtSale;
        DataTable dtSaleDetail;

        BindingSource bsSale;
        public FormSale()
        {
            InitializeComponent();
        }

        private void FormSale_Load(object sender, EventArgs e)
        {
            LoadSale();
            LoadCustomer();
            LaodEmployee();
            LoadItem();

        }
        private void LoadSale()
        {
            dtSale = SaleService.GetAll();
            bsSale = new BindingSource();
            bsSale.DataSource = dtSale;

            txtId.DataBindings.Clear();
            txtId.DataBindings.Add(new Binding("Text", bsSale, "SaleId"));

            dtpTxnDate.DataBindings.Clear();
            dtpTxnDate.DataBindings.Add(new Binding("Text", bsSale, "TxnDate", true));

            txtRefNumber.DataBindings.Clear();
            txtRefNumber.DataBindings.Add(new Binding("Text", bsSale, "RefNumber"));

            cboCustomer.DataBindings.Clear();
            cboCustomer.DataBindings.Add(new Binding("SelectedValue", bsSale, "CustomerId"));

            cboEmployee.DataBindings.Clear();
            cboEmployee.DataBindings.Add(new Binding("SelectedValue", bsSale, "EmployeeId"));

            txtNote.DataBindings.Clear();
            txtNote.DataBindings.Add(new Binding("Text", bsSale, "Note"));

            LoadSaleDetail();
        }
        private void LoadSaleDetail()
        {
            int saleid = Convert.ToInt32(txtId.Text);
            dtSaleDetail = SaleDetailService.Get(saleid);


            dgSaleDetail.Columns[0].DataPropertyName = "SaleDetailId";
            dgSaleDetail.Columns[0].Visible = false;

            dgSaleDetail.Columns[1].DataPropertyName = "SaleId";
            dgSaleDetail.Columns[1].Visible = false;

            dgSaleDetail.Columns[2].DataPropertyName = "ItemId";
            dgSaleDetail.Columns[2].Visible = true;
            dgSaleDetail.Columns[2].HeaderText = "Item";
            dgSaleDetail.Columns[2].Width = 300;

            dgSaleDetail.Columns[3].DataPropertyName = "Description";
            dgSaleDetail.Columns[3].Visible = true;
            dgSaleDetail.Columns[3].HeaderText = "Description";
            dgSaleDetail.Columns[3].Width = 300;

            dgSaleDetail.Columns[4].DataPropertyName = "Quantity";
            dgSaleDetail.Columns[4].Visible = true;
            dgSaleDetail.Columns[4].HeaderText = "Quantity";
            dgSaleDetail.Columns[4].Width = 300;

            dgSaleDetail.Columns[5].DataPropertyName = "Price";
            dgSaleDetail.Columns[5].Visible = true;
            dgSaleDetail.Columns[5].HeaderText = "Price";
            dgSaleDetail.Columns[5].Width = 100;

            dgSaleDetail.DataSource = dtSaleDetail;


        }
        private void LoadCustomer()
        {
            DataTable dtCustomer = CustomerServices.GetAll();
            cboCustomer.DataSource = dtCustomer;
            cboCustomer.DisplayMember = "CustomerName";
            cboCustomer.ValueMember = "CustomerId";
        }
        private void LaodEmployee()
        {

            cboEmployee.DataSource = EmployeeService.GetAll();
            cboEmployee.DisplayMember = "EmployeeName";
            cboEmployee.ValueMember = "EmployeeId";
        }

        private void LoadItem()
        {

            DataGridViewComboBoxColumn colItem = (DataGridViewComboBoxColumn)dgSaleDetail.Columns[2];
            colItem.DataSource = ItemService.GetAll();
            colItem.DisplayMember = "ItemName";
            colItem.ValueMember = "ItemId";

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            dgSaleDetail.EndEdit();
            dtSaleDetail.AcceptChanges();

            DataRowView data = (DataRowView)bsSale.Current;

            if (data.IsNew)
            {
                Sale sale = new Sale();
                sale.TxnDate = dtpTxnDate.Value;
                sale.RefNumber = txtRefNumber.Text;

                // Correctly set the CustomerId and EmployeeId
                sale.CustomerId = Convert.ToInt32(cboCustomer.SelectedValue); // Fixed line
                sale.EmployeeId = Convert.ToInt32(cboEmployee.SelectedValue);

                sale.Note = txtNote.Text.Trim();

                int saleid = SaleService.Add(sale);

                foreach (DataRow row in dtSaleDetail.Rows)
                {
                    SaleDetail saledetail = new SaleDetail();
                    saledetail.SaleId = saleid;
                    saledetail.ItemId = Convert.ToInt32(row[2]);
                    saledetail.Description = row[3].ToString();
                    saledetail.Quantity = Convert.ToDouble(row[4]);
                    saledetail.Price = Convert.ToDouble(row[5]);

                    SaleDetailService.Add(saledetail);
                }
                MessageBox.Show("Sale has added successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Sale sale = new Sale();
                sale.SaleId = Convert.ToInt32(txtId.Text);
                sale.TxnDate = dtpTxnDate.Value;
                sale.RefNumber = txtRefNumber.Text;


                sale.CustomerId = Convert.ToInt32(cboCustomer.SelectedValue);
                sale.EmployeeId = Convert.ToInt32(cboEmployee.SelectedValue);

                sale.Note = txtNote.Text.Trim();

                SaleService.Update(sale);

                SaleDetailService.Delete(sale.SaleId);

                foreach (DataRow row in dtSaleDetail.Rows)
                {
                    SaleDetail saledetail = new SaleDetail();
                    saledetail.SaleId = sale.SaleId;
                    saledetail.ItemId = Convert.ToInt32(row[2]);
                    saledetail.Description = row[3].ToString();
                    saledetail.Quantity = Convert.ToDouble(row[4]);
                    saledetail.Price = Convert.ToDouble(row[5]);

                    SaleDetailService.Add(saledetail);
                }
                MessageBox.Show("Sale has updated successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            LoadSale();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            bsSale.AddNew();
            dtSaleDetail.Rows.Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (bsSale.Count <= 0)
                return;
            DataRowView datarow = (DataRowView)bsSale.Current;
            if (datarow.IsNew)
                return;
            DialogResult confirmation = MessageBox.Show(
            "Are you sure to delete this record?",
            "Confirmation",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);
            if (confirmation != DialogResult.Yes)
                return;
            SaleDetailService.Delete(Convert.ToInt32(txtId.Text));
            SaleService.Delete(Convert.ToInt32(txtId.Text));
            MessageBox.Show("Sale has deleted successfully");
            LoadSale();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            bsSale.MovePrevious();
            LoadSaleDetail();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            bsSale.MoveNext();
            LoadSaleDetail();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();
            if (dtSaleDetail != null && dtSaleDetail.Rows.Count > 0)
            {
                DataView dv = dtSaleDetail.DefaultView;
                dv.RowFilter = $"Convert(ItemId, 'System.String') LIKE '%{searchText}%' OR " +
                     $"Description LIKE '%{searchText}%' OR " +
                     $"Convert(Quantity, 'System.String') LIKE '%{searchText}%' OR " +
                     $"Convert(Price, 'System.String') LIKE '%{searchText}%'";
                dgSaleDetail.DataSource = dv;
            }
        }
    }
}
