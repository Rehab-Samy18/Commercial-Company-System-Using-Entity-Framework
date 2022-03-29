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
    public partial class ExchangePerForm : Form
    {
        public ExchangePerForm()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            EF_FinalProjectEntities Ent = new EF_FinalProjectEntities();
            dataGridView1.DataSource = Ent.SelectExchangePermission();
        }

        private void ExchangePerForm_Load(object sender, EventArgs e)
        {
            EF_FinalProjectEntities Ent = new EF_FinalProjectEntities();
            foreach (Product P in Ent.Products)
            {
                comboBox1.Items.Add(P.Prod_ID.ToString());
            }
            foreach (Supplier S in Ent.Suppliers)
            {
                comboBox2.Items.Add(S.S_ID.ToString());
            }
            foreach (Warehouse W in Ent.Warehouses)
            {
                comboBox3.Items.Add(W.WH_Name.ToString());
            }
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            EF_FinalProjectEntities Ent = new EF_FinalProjectEntities();
            Exchange_Permission EP = new Exchange_Permission();
            Exchange_Quantity EQ = new Exchange_Quantity();

            if (textBox1.Text != "" && comboBox1.Text != "" && textBox3.Text != "" && comboBox2.Text != "" && comboBox3.Text != "" && textBox6.Text != "")
            {
                Exchange_Permission FindExchangePer = Ent.Exchange_Permission.Find(int.Parse(textBox1.Text), int.Parse(comboBox1.Text));
                if (FindExchangePer == null)
                {
                    EP.EP_ID = int.Parse(textBox1.Text);
                    EQ.EP_ID = int.Parse(textBox1.Text);
                    EP.Prod_ID = EQ.Prod_ID = int.Parse(comboBox1.Text);
                    EQ.Exchange_Quantity1 = int.Parse(textBox3.Text);
                    EP.C_ID = int.Parse(comboBox2.Text);
                    EP.WH_Name = comboBox3.Text;
                    EP.EP_Date = DateTime.Parse(textBox6.Text);

                    Warehouse WH = (from W in Ent.Warehouses
                                    where W.WH_Name == EP.WH_Name
                                    select W).FirstOrDefault();
                    Client CL = (from C in Ent.Clients
                                     where C.C_ID == EP.C_ID
                                     select C).FirstOrDefault();
                    Product Prd = (from P in Ent.Products
                                   where P.Prod_ID == EP.Prod_ID
                                   select P).FirstOrDefault();
                    if (WH == null)
                    {
                        MessageBox.Show("There is no Warehouse with this name!");
                    }
                    else if (CL == null)
                    {
                        MessageBox.Show("There is no Client with this ID!");
                    }
                    else if (Prd == null)
                    {
                        MessageBox.Show("There is no Product with this ID!");
                    }
                    else
                    {
                        Ent.Exchange_Permission.Add(EP);
                        Ent.Exchange_Quantity.Add(EQ);
                        Ent.SaveChanges();
                        MessageBox.Show("Exchange Permission added successfully!");
                        textBox1.Text = comboBox1.Text = textBox3.Text = comboBox2.Text = comboBox3.Text = textBox6.Text = String.Empty;
                    }
                }
                else
                {
                    MessageBox.Show("Exchange Permission is already existed!");
                }
            }
            else
            {
                MessageBox.Show("Empty Data");
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            EF_FinalProjectEntities Ent = new EF_FinalProjectEntities();
            int UpdatedExchangePerId = int.Parse(textBox1.Text);
            int UpdatedExchangePerProductId = int.Parse(comboBox1.Text);
            Exchange_Permission EP = Ent.Exchange_Permission.Find(UpdatedExchangePerId, UpdatedExchangePerProductId);

            if (comboBox1.Text != "" && textBox3.Text != "" && comboBox2.Text != "" && comboBox3.Text != "" && textBox6.Text != "")
            {
                if (EP != null)
                {
                    EP.Prod_ID = int.Parse(comboBox1.Text);
                    EP.C_ID = int.Parse(comboBox2.Text);
                    EP.WH_Name = comboBox3.Text;
                    EP.EP_Date = DateTime.Parse(textBox6.Text);
                    int NewQuantity = int.Parse(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[4].Value.ToString());
                    Ent.UpdateExchangeQuantity(int.Parse(textBox1.Text), int.Parse(comboBox1.Text), NewQuantity, int.Parse(textBox3.Text));

                    Warehouse WH = (from W in Ent.Warehouses
                                    where W.WH_Name == EP.WH_Name
                                    select W).FirstOrDefault();
                    Client CL = (from C in Ent.Clients
                                     where C.C_ID == EP.C_ID
                                     select C).FirstOrDefault();
                    Product Prd = (from P in Ent.Products
                                   where P.Prod_ID == EP.Prod_ID
                                   select P).FirstOrDefault();


                    if (WH == null)
                    {
                        MessageBox.Show("There is no Warehouse with this name!");
                    }
                    else if (CL == null)
                    {
                        MessageBox.Show("There is no Client with this ID!");
                    }
                    else if (Prd == null)
                    {
                        MessageBox.Show("There is no Product with this ID!");
                    }
                    else
                    {
                        Ent.SaveChanges();
                        MessageBox.Show("Exchange Permission updated successfully!");
                        textBox1.Text = comboBox1.Text = textBox3.Text = comboBox2.Text = comboBox3.Text = textBox6.Text = String.Empty;
                    }
                }
                else
                {
                    MessageBox.Show("Supply Permission is not existed!");
                }
            }
            else
            {
                MessageBox.Show("Empty Data!");
            }
        }

        private void DataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string ProdName = dataGridView1.Rows[e.RowIndex].Cells["Prod_Name"].Value.ToString();
            string SupplyName = dataGridView1.Rows[e.RowIndex].Cells["C_Name"].Value.ToString();
            EF_FinalProjectEntities Ent = new EF_FinalProjectEntities();

            Product Prod = (from P in Ent.Products
                            where P.Prod_Name == ProdName
                            select P).FirstOrDefault();
            Client CL = (from C in Ent.Clients
                            where C.C_Name == SupplyName
                            select C).FirstOrDefault();
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["EP_ID"].Value.ToString();
            comboBox1.Text = Prod.Prod_ID.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["Exchange_Quantity"].Value.ToString();
            comboBox2.Text = CL.C_ID.ToString();
            comboBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["WH_Name"].Value.ToString();
            textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells["EP_Date"].Value.ToString();
        }
    }
}
