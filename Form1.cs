using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EFProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            WarehouseForm WHF = new WarehouseForm();
            WHF.Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            ProductForm PF = new ProductForm();
            PF.Show();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            SupplierForm SF = new SupplierForm();
            SF.Show();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            ClientForm CF = new ClientForm();
            CF.Show();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            SupplyPerForm SPF = new SupplyPerForm();
            SPF.Show();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            ExchangePerForm EPF = new ExchangePerForm();
            EPF.Show();
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            ReportsOptionsForm ROF = new ReportsOptionsForm();
            ROF.Show();
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            TransactionForm TF = new TransactionForm();
            TF.Show();
        }
    }
}
