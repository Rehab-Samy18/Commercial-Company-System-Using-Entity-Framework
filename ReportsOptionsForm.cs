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
    public partial class ReportsOptionsForm : Form
    {
        public ReportsOptionsForm()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            WHReport WHR = new WHReport();
            WHR.Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            ProductReportForm PRF = new ProductReportForm();
            PRF.Show();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            LongTimeProductForm LTPF = new LongTimeProductForm();
            LTPF.Show();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            ExpProductSoonForm EPSF = new ExpProductSoonForm();
            EPSF.Show();
        }
    }
}
