﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
namespace EFProject
{
    public partial class WarehouseForm : Form
    {
        public WarehouseForm()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            EF_FinalProjectEntities Ent = new EF_FinalProjectEntities();
            Warehouse WH = new Warehouse();

            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                Warehouse FindWH = Ent.Warehouses.Find(textBox1.Text);
                if (FindWH == null)
                {
                    WH.WH_Name = textBox1.Text;
                    WH.WH_Address = textBox2.Text;
                    WH.WH_Manager = textBox3.Text;
                    Ent.Warehouses.Add(WH);
                    Ent.SaveChanges();
                    MessageBox.Show("Warehouse added successfully!");
                }
                else
                {
                    MessageBox.Show("Warehouse is already existed!");
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
            string UpdatedWhName = textBox1.Text;
            Warehouse W = Ent.Warehouses.Find(UpdatedWhName);
            if (textBox2.Text != "" && textBox3.Text != "")
            {
                if (W != null)
                {
                    W.WH_Address = textBox2.Text;
                    W.WH_Manager = textBox3.Text;
                    Ent.SaveChanges();
                    MessageBox.Show("Warehouse updated successfully!");
                }
                else
                {
                    MessageBox.Show("Warehouse is not existed!");
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
            dataGridView1.DataSource = Ent.SelectWarehouse();
            
        }

        private void DataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["WH_Name"].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["WH_Address"].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["WH_Manager"].Value.ToString();
        }
    }
}
