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
    public partial class TransactionForm : Form
    {
        public TransactionForm()
        {
            InitializeComponent();
        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }

        private void ComboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ID = int.Parse(comboBox5.Text);
            EF_FinalProjectEntities Ent = new EF_FinalProjectEntities();
            Supply_Permission SP = (from S in Ent.Supply_Permission
                            where S.SP_ID == ID
                            select S).First();
            
            comboBox3.Items.Clear();
            comboBox3.Text = SP.WH_Name;
            comboBox1.Text = SP.Prod_ID.ToString();
        }

        private void TransactionForm_Load(object sender, EventArgs e)
        {
            EF_FinalProjectEntities Ent = new EF_FinalProjectEntities();
            foreach (Supply_Permission SP in Ent.Supply_Permission)
            {
                comboBox5.Items.Add(SP.SP_ID.ToString());
            }
            foreach (Warehouse WH in Ent.Warehouses)
            {
                comboBox4.Items.Add(WH.WH_Name.ToString());
            }
            foreach (Supplier S in Ent.Suppliers)
            {
                comboBox2.Items.Add(S.S_ID.ToString());
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            EF_FinalProjectEntities Ent = new EF_FinalProjectEntities();
            dataGridView1.DataSource = Ent.DisplayTransaction();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            EF_FinalProjectEntities Ent = new EF_FinalProjectEntities();
            Ent.TransactionProc1(int.Parse(comboBox1.Text), comboBox3.Text, comboBox4.Text, int.Parse(comboBox2.Text), int.Parse(textBox3.Text), DateTime.Parse(textBox7.Text), int.Parse(textBox8.Text));
            MessageBox.Show("تم تحويل الصنف بنجاح");
        }
    }
}
