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
    public partial class FormCustomerAddEdit : Form
    {
        Customer _customer;
        bool isnew;
        public FormCustomerAddEdit(Customer customer)
        {
            InitializeComponent();
            
            if (customer == null)
            {
                lblTitle.Text = "Add Customer";
                btnSave.Text = "Save";
             

                _customer = new Customer();
                isnew = true;
            }
            else
            {
                lblTitle.Text = "Edit Customer";
                btnSave.Text = "Save";
                txtCustomerName.Text = customer.CustomerName;
                txtCompanyName.Text = customer.CompanyName;
                txtPhone.Text = customer.Phone;
                txtEmail.Text = customer.Email;
                txtAddress.Text = customer.Address;

                _customer = customer;
                isnew = false;
            }
        }

     

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!Dovalidation())
                return;

            _customer.CustomerName = txtCustomerName.Text;
            _customer.CompanyName = txtCompanyName.Text;
            _customer.Phone = txtPhone.Text;
            _customer.Email = txtEmail.Text;
            _customer.Address = txtAddress.Text;

            if (isnew)
            {
                CustomerServices.Add(_customer);
                MessageBox.Show("Customer add successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                CustomerServices.Update(_customer);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();

            
        }
        private bool Dovalidation()
        {
            bool result = true;

            if (string.IsNullOrWhiteSpace(txtCustomerName.Text))
            {
                epCustomerName.SetError(txtCustomerName, "Customer Name is required");
                result = false;
            }
            else if (string.IsNullOrWhiteSpace(txtCompanyName.Text))
            {
                epCustomerName.SetError(txtCompanyName, "Company Name is required");
                result = false;
            }
            else if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                epCustomerName.SetError(txtPhone, "Phone is required");
                result = false;
            }
            else if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                epCustomerName.SetError(txtEmail, "Email is required");
                result = false;
            }
            else if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                epCustomerName.SetError(txtAddress, "Address is required");
                result = false;
            }

            return result;

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }
    }
}
