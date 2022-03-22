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
    public partial class ProductForm : Form
    {
        public ProductForm()
        {
            InitializeComponent();
        }


        private void Button1_Click(object sender, EventArgs e)
        {
            EF_FinalProjectEntities Ent = new EF_FinalProjectEntities();
            Product PR = new Product();

            if (textBox1.Text != "" && textBox2.Text != "")
            {
                Product FindProduct = Ent.Products.Find(int.Parse(textBox1.Text));
                if (FindProduct == null)
                {
                    PR.Prod_ID = int.Parse(textBox1.Text);
                    PR.Prod_Name = textBox2.Text;
                    Ent.Products.Add(PR);
                    Ent.SaveChanges();
                    MessageBox.Show("Product added successfully!");
                }
                else
                {
                    MessageBox.Show("Product is already existed!");
                }
            }
            else
            {
                MessageBox.Show("Empty Data");
            }
            textBox1.Text = textBox2.Text = String.Empty;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            EF_FinalProjectEntities Ent = new EF_FinalProjectEntities();
            int UpdatedProductId = int.Parse(textBox1.Text);
            Product PR = Ent.Products.Find(UpdatedProductId);
            if (textBox2.Text != "")
            {
                if (PR != null)
                {
                    PR.Prod_Name = textBox2.Text;
                    Ent.SaveChanges();
                    MessageBox.Show("Product updated successfully!");
                }
                else
                {
                    MessageBox.Show("Product is not existed!");
                }
            }
            else
            {
                MessageBox.Show("Empty Data!");
            }
            textBox1.Text = textBox2.Text = String.Empty;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            
            EF_FinalProjectEntities Ent = new EF_FinalProjectEntities();
            dataGridView1.DataSource = Ent.SelectProduct();
            
        }

        private void DataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["Prod_ID"].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["Prod_Name"].Value.ToString();
        }
    }
}
