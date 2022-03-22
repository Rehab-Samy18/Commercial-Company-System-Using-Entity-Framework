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
    public partial class ClientForm : Form
    {
        public ClientForm()
        {
            InitializeComponent();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            EF_FinalProjectEntities Ent = new EF_FinalProjectEntities();
            Client CL = new Client();

            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "")
            {
                Client FindClient = Ent.Clients.Find(int.Parse(textBox1.Text));
                if (FindClient == null)
                {
                    CL.C_ID = int.Parse(textBox1.Text);
                    CL.C_Name = textBox2.Text;
                    CL.C_Email = textBox3.Text;
                    CL.C_Phone = int.Parse(textBox4.Text);
                    CL.C_Mob = int.Parse(textBox5.Text);
                    CL.C_Fax = int.Parse(textBox6.Text);
                    CL.C_Website = textBox7.Text;
                    Ent.Clients.Add(CL);
                    Ent.SaveChanges();
                    MessageBox.Show("Client added successfully!");
                }
                else
                {
                    MessageBox.Show("Client is already existed!");
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
            int UpdatedClientId = int.Parse(textBox1.Text);
            Client CL = Ent.Clients.Find(UpdatedClientId);
            if (textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "")
            {
                if (CL != null)
                {
                    CL.C_Name = textBox2.Text;
                    CL.C_Email = textBox3.Text;
                    CL.C_Phone = int.Parse(textBox4.Text);
                    CL.C_Mob = int.Parse(textBox5.Text);
                    CL.C_Fax = int.Parse(textBox6.Text);
                    CL.C_Website = textBox7.Text;
                    Ent.SaveChanges();
                    MessageBox.Show("Client updated successfully!");
                }
                else
                {
                    MessageBox.Show("Client is not existed!");
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
            dataGridView1.DataSource = Ent.SelectClient();
        }

        private void DataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["C_ID"].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["C_Name"].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["C_Email"].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["C_Phone"].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells["C_Mob"].Value.ToString();
            textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells["C_Fax"].Value.ToString();
            textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells["C_Website"].Value.ToString();
        }
    }
}
