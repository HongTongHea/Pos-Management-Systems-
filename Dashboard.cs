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
    public partial class Dashboard : Form
    {
        FormCustomer formcustomer;

        FormDashboard formdashboard;


        public Dashboard()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            FormLogin formLogin = new FormLogin();
            formLogin.Show();
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Time.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void lblDashboard_Click(object sender, EventArgs e)
        {
            if (formdashboard == null)
            {
                formdashboard = new FormDashboard();
                formdashboard.TopLevel = false;
                formdashboard.FormBorderStyle = FormBorderStyle.None;
                formdashboard.Dock = DockStyle.Fill;

                pnMain.Controls.Add(formdashboard);
                formdashboard.Show();
                formdashboard.BringToFront();
            }
            else
            {
                formdashboard.BringToFront();
            }
        }

        private void lblCustomer_Click(object sender, EventArgs e)
        {
            if (formcustomer == null)
            {
                formcustomer = new FormCustomer();
                formcustomer.TopLevel = false;
                formcustomer.FormBorderStyle = FormBorderStyle.None;
                formcustomer.Dock = DockStyle.Fill;

                pnMain.Controls.Add(formcustomer);
                formcustomer.Show();
                formcustomer.BringToFront();
            }
            else
            {
                formcustomer.BringToFront();
            }
        }
    }
}
