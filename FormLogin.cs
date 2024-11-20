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
    }
}
