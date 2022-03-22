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
    public partial class SupplierForm : Form
    {
        public SupplierForm()
        {
            InitializeComponent();
        }


        private void Button1_Click(object sender, EventArgs e)
        {
            EF_FinalProjectEntities Ent = new EF_FinalProjectEntities();
            Supplier SP = new Supplier();

            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "")
            {
                Supplier FindSuplier = Ent.Suppliers.Find(int.Parse(textBox1.Text));
                if (FindSuplier == null)
                {
                    SP.S_ID = int.Parse(textBox1.Text);
                    SP.S_Name = textBox2.Text;
                    SP.S_Email = textBox3.Text;
                    SP.S_Phone = int.Parse(textBox4.Text);
                    SP.S_Mob = int.Parse(textBox5.Text);
                    SP.S_Fax = int.Parse(textBox6.Text);
                    SP.S_Website = textBox7.Text;
                    Ent.Suppliers.Add(SP);
                    Ent.SaveChanges();
                    MessageBox.Show("Supplier added successfully!");
                }
                else
                {
                    MessageBox.Show("Supplier is already existed!");
                }
            }
            else
            {
                MessageBox.Show("Empty Data");
            }
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = textBox7.Text = String.Empty;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            EF_FinalProjectEntities Ent = new EF_FinalProjectEntities();
            int UpdatedSupplierId = int.Parse(textBox1.Text);
            Supplier SP = Ent.Suppliers.Find(UpdatedSupplierId);
            if (textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "")
            {
                if (SP != null)
                {
                    SP.S_Name = textBox2.Text;
                    SP.S_Email = textBox3.Text;
                    SP.S_Phone = int.Parse(textBox4.Text);
                    SP.S_Mob = int.Parse(textBox5.Text);
                    SP.S_Fax = int.Parse(textBox6.Text);
                    SP.S_Website = textBox7.Text;
                    Ent.SaveChanges();
                    MessageBox.Show("Supplier updated successfully!");
                }
                else
                {
                    MessageBox.Show("Supplier is not existed!");
                }
            }
            else
            {
                MessageBox.Show("Empty Data!");
            }
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = textBox7.Text = String.Empty;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            EF_FinalProjectEntities Ent = new EF_FinalProjectEntities();
            dataGridView1.DataSource = Ent.SelectSupplier();
        }

        private void DataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["S_ID"].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["S_Name"].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["S_Email"].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["S_Phone"].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells["S_Mob"].Value.ToString();
            textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells["S_Fax"].Value.ToString();
            textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells["S_Website"].Value.ToString();
        }
    }
}
