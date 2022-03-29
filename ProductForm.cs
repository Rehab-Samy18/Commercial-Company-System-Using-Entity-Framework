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
            Product_Measure PM = new Product_Measure();
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                Product FindProduct = Ent.Products.Find(int.Parse(textBox1.Text));
                if (FindProduct == null)
                {
                    PR.Prod_ID = int.Parse(textBox1.Text);
                    PR.Prod_Name = textBox2.Text;
                    Ent.Products.Add(PR);
                    Ent.SaveChanges();
                }
               
                Product_Measure ProdMes = Ent.Product_Measure.Find(int.Parse(textBox1.Text), textBox3.Text);
                if (ProdMes == null)
                {
                    PM.Prod_ID = int.Parse(textBox1.Text);
                    PM.Measure_Unit = textBox3.Text;
                    Ent.Product_Measure.Add(PM);
                    Ent.SaveChanges();
                    MessageBox.Show("Product added successfully!");
                }
                if (FindProduct != null && ProdMes != null)
                {
                    MessageBox.Show("Product already existed!");
                }
                
            }
            else
            {
                MessageBox.Show("Empty Data");
            }
            textBox1.Text = textBox2.Text = textBox3.Text = String.Empty;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            EF_FinalProjectEntities Ent = new EF_FinalProjectEntities();
            int UpdatedProductId = int.Parse(textBox1.Text);
            string UpdatedProductMeasure = textBox3.Text;
            Product PR = Ent.Products.Find(UpdatedProductId);
            if (textBox2.Text != "" && textBox3.Text != "")
            {
                if (PR != null)
                {
                    PR.Prod_Name = textBox2.Text;
                    string NewMeasure = (dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[2].Value).ToString();
                    Ent.UpdateMeasureUnit(int.Parse(textBox1.Text), NewMeasure, textBox3.Text);
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
            textBox1.Text = textBox2.Text = textBox3.Text = String.Empty;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            
            EF_FinalProjectEntities Ent = new EF_FinalProjectEntities();
            dataGridView1.DataSource = Ent.SelectAllProduct();
        }

        private void DataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["Prod_ID"].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["Prod_Name"].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["Measure_Unit"].Value.ToString();
        }
    }
}
