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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnShowHide_Click(object sender, EventArgs e)
        {
            if (txtPassword.UseSystemPasswordChar == false)
            {
                txtPassword.UseSystemPasswordChar = true;
                btnShowHide.Image = Properties.Resources.locked;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = false;
                btnShowHide.Image = Properties.Resources.unlocked;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (DoValidation())
            {
                Users user =
                UsersService.Login(txtUserName.Text.Trim(), txtPassword.Text.Trim());
                if (user == null)
                {
                    MessageBox.Show("Invalid Username and Password, Please enteragain.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                Dashboard dashboard = new Dashboard();
                //formMain.UserLogin = user;
                this.Hide();
                dashboard.ShowDialog();
                this.Close();
            }
            bool DoValidation()
            {
                bool result = true;
                if (txtUserName.Text.Trim() == "")
                {
                    epUsername.SetError(txtUserName, "Please enter username.");
                    result = false;
                }
            /*    else if(txtPassword.Text.Trim() == "");
                {
                    epUsername.SetError(txtPassword, "Password cannot blank, Please enterpassword");

                    result = false;
                }*/
                return result;
            }
        }
    }
}
