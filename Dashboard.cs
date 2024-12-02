﻿using POS_MANAGEMENT_SYSTEM.Data.Model;
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
        FormSale formSale;
        FormEmployee formemployee;

        FormDashboard FormDashboard;

        public Dashboard()
        {
            InitializeComponent();
      
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

        private void lblDashboard_Click(object sender, EventArgs e)
        {
            if (FormDashboard == null)
            {
                FormDashboard = new FormDashboard();
                FormDashboard.TopLevel = false;
                FormDashboard.FormBorderStyle = FormBorderStyle.None;
                FormDashboard.Dock = DockStyle.Fill;
                pnMain.Controls.Add(FormDashboard);
                FormDashboard.Show();
                FormDashboard.BringToFront();
            }
            else
            {
                FormDashboard.BringToFront();
            }

        }

        private void lblEmployee_Click(object sender, EventArgs e)
        {
            if (formemployee == null)
            {
                formemployee = new FormEmployee();
                formemployee.TopLevel = false;
                formemployee.FormBorderStyle = FormBorderStyle.None;
                formemployee.Dock = DockStyle.Fill;
                pnMain.Controls.Add(formemployee);
                formemployee.Show();
                formemployee.BringToFront();
            }
            else
            {
                formemployee.BringToFront();
            }

        }

        private void lblSale_Click(object sender, EventArgs e)
        {
           
            if (formSale == null)
            {
                formSale = new FormSale();
                formSale.TopLevel = false;
                formSale.FormBorderStyle = FormBorderStyle.None;
                formSale.Dock = DockStyle.Fill;
                pnMain.Controls.Add(formSale);
                formSale.Show();
                formSale.BringToFront();
            }
            else
            {
                formSale.BringToFront();
            }
        }
    }
}
