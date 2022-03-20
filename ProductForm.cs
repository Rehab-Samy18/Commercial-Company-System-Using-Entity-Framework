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

        private void ProductForm_Load(object sender, EventArgs e)
        {
            EF_FinalProjectEntities Ent = new EF_FinalProjectEntities();
            foreach (Product P in Ent.Products)
            {
                comboBox1.Items.Add(P.Prod_ID.ToString());
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ID = int.Parse(comboBox1.Text.ToString());
            EF_FinalProjectEntities Ent = new EF_FinalProjectEntities();
            Product Pr = (from P in Ent.Products
                          where P.Prod_ID == ID
                          select P).First();
            textBox1.Text = Pr.Prod_ID.ToString();
            textBox2.Text = Pr.Prod_Name;
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
                    comboBox1.Items.Add(PR.Prod_ID);
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
    }
}
