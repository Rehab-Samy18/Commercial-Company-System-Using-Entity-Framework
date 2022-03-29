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
    public partial class SupplyPerForm : Form
    {   
        public SupplyPerForm()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            EF_FinalProjectEntities Ent = new EF_FinalProjectEntities();
            dataGridView1.DataSource = Ent.SelectSupplyPermission();
        }

        private void SupplyPerForm_Load(object sender, EventArgs e)
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
            Supply_Permission SP = new Supply_Permission();
            Supply_Quantity SQ = new Supply_Quantity();

            if (textBox1.Text != "" && comboBox1.Text != "" && textBox3.Text != "" && comboBox2.Text != "" && comboBox3.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "")
            {
                Supply_Permission FindSupplyPer = Ent.Supply_Permission.Find(int.Parse(textBox1.Text), int.Parse(comboBox1.Text));
                if (FindSupplyPer == null)
                {
                    SP.SP_ID = int.Parse(textBox1.Text);
                    SQ.SP_ID = int.Parse(textBox1.Text);
                    SP.Prod_ID = SQ.Prod_ID = int.Parse(comboBox1.Text);
                    SQ.Supply_Quantity1 = int.Parse(textBox3.Text);
                    SP.S_ID = int.Parse(comboBox2.Text);
                    SP.WH_Name = comboBox3.Text;
                    SP.SP_Date = DateTime.Parse(textBox6.Text);
                    SQ.Prod_ProdDate = DateTime.Parse(textBox7.Text);
                    SQ.Prod_ExpDuration = int.Parse(textBox8.Text);

                    Warehouse WH = (from W in Ent.Warehouses
                                    where W.WH_Name == SP.WH_Name
                                    select W).FirstOrDefault();
                    Supplier Supp = (from S in Ent.Suppliers
                                     where S.S_ID == SP.S_ID
                                     select S).FirstOrDefault();
                    Product Prd = (from P in Ent.Products
                                   where P.Prod_ID == SP.Prod_ID
                                   select P).FirstOrDefault();
                    if (WH == null)
                    {
                        MessageBox.Show("There is no Warehouse with this name!");
                    }
                    else if (Supp == null)
                    {
                        MessageBox.Show("There is no Supplier with this ID!");
                    }
                    else if (Prd == null)
                    {
                        MessageBox.Show("There is no Product with this ID!");
                    }
                    else
                    {
                        Ent.Supply_Permission.Add(SP);
                        Ent.Supply_Quantity.Add(SQ);
                        Ent.SaveChanges();
                        MessageBox.Show("Supply Permission added successfully!");
                        textBox1.Text = comboBox1.Text = textBox3.Text = comboBox2.Text = comboBox3.Text = textBox6.Text = textBox7.Text = textBox8.Text = String.Empty;
                    }
                }
                else
                {
                    MessageBox.Show("Supply Permission is already existed!");
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
            int UpdatedSupplyPerId = int.Parse(textBox1.Text);
            int UpdatedSupplyPerProductId = int.Parse(comboBox1.Text);
            Supply_Permission SP = Ent.Supply_Permission.Find(UpdatedSupplyPerId,UpdatedSupplyPerProductId);

            if (comboBox1.Text != "" && textBox3.Text != "" && comboBox2.Text != "" && comboBox3.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "")
            {
                if (SP != null)
                {
                    SP.Prod_ID = int.Parse(comboBox1.Text);
                    SP.S_ID = int.Parse(comboBox2.Text);
                    SP.WH_Name = comboBox3.Text;
                    SP.SP_Date = DateTime.Parse(textBox6.Text);
                    int NewQuantity = int.Parse(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[4].Value.ToString());
                    Ent.UpdateSupplyQuantityWithDate(int.Parse(textBox1.Text), int.Parse(comboBox1.Text), NewQuantity, int.Parse(textBox3.Text),DateTime.Parse(textBox7.Text),int.Parse(textBox8.Text));
                    Warehouse WH = (from W in Ent.Warehouses
                                    where W.WH_Name == SP.WH_Name
                                    select W).FirstOrDefault();
                    Supplier Supp = (from S in Ent.Suppliers
                                     where S.S_ID == SP.S_ID
                                     select S).FirstOrDefault();
                    Product Prd = (from P in Ent.Products
                                   where P.Prod_ID == SP.Prod_ID
                                   select P).FirstOrDefault();
                    
                    
                    if (WH == null)
                    {
                        MessageBox.Show("There is no Warehouse with this name!");
                    }
                    else if (Supp == null)
                    {
                        MessageBox.Show("There is no Supplier with this ID!");
                    }
                    else if (Prd == null)
                    {
                        MessageBox.Show("There is no Product with this ID!");
                    }
                    else
                    {
                        
                        Ent.SaveChanges();
                        MessageBox.Show("Supply Permission updated successfully!");
                        textBox1.Text = comboBox1.Text = textBox3.Text = comboBox2.Text = comboBox3.Text = textBox6.Text = textBox7.Text = textBox8.Text = String.Empty;
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
            string SupplyName = dataGridView1.Rows[e.RowIndex].Cells["S_Name"].Value.ToString();
            EF_FinalProjectEntities Ent = new EF_FinalProjectEntities();
            
            Product Prod = (from P in Ent.Products
                             where P.Prod_Name == ProdName
                             select P).FirstOrDefault();
            Supplier sup = (from S in Ent.Suppliers
                            where S.S_Name == SupplyName
                            select S).FirstOrDefault();
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["SP_ID"].Value.ToString();
            comboBox1.Text = Prod.Prod_ID.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["Supply_Quantity"].Value.ToString();
            comboBox2.Text = sup.S_ID.ToString();
            comboBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["WH_Name"].Value.ToString();
            textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells["SP_Date"].Value.ToString();
            textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells["Prod_ProdDate"].Value.ToString();
            textBox8.Text = dataGridView1.Rows[e.RowIndex].Cells["Prod_ExpDuration"].Value.ToString();
        }
    }
}
