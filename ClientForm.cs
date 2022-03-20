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

        private void ClientForm_Load(object sender, EventArgs e)
        {
            EF_FinalProjectEntities Ent = new EF_FinalProjectEntities();
            foreach (Client C in Ent.Clients)
            {
                comboBox1.Items.Add(C.C_ID.ToString());
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ID = int.Parse(comboBox1.Text.ToString());
            EF_FinalProjectEntities Ent = new EF_FinalProjectEntities();
            Client Cl = (from C in Ent.Clients
                            where C.C_ID == ID
                            select C).First();
            textBox1.Text = Cl.C_ID.ToString();
            textBox2.Text = Cl.C_Name;
            textBox3.Text = Cl.C_Email;
            textBox4.Text = Cl.C_Phone.ToString();
            textBox5.Text = Cl.C_Mob.ToString();
            textBox6.Text = Cl.C_Fax.ToString();
            textBox7.Text = Cl.C_Website;
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
                    comboBox1.Items.Add(CL.C_ID);
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
    }
}
