﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace SDL_csharp
{
    public partial class UserControl2 : UserControl
    {
        public UserControl2()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }


        private void cate_UC_SelectedIndexChanged(object sender, EventArgs e)
        {
            String name = cate_UC.Text;
            data db = new data();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand cmd = new MySqlCommand("SELECT`ItemName` FROM `foodorder` WHERE `Catagory` = '" + name + "'", db.getConnection());
            db.openConnection();
            adapter.SelectCommand = cmd;
            adapter.Fill(table);
            listBox1.DataSource = table;
            listBox1.DisplayMember = "Itemname";
            db.closeConnection();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            quantity_t.ResetText();
            total_t.Clear();

            String list = listBox1.GetItemText(listBox1.SelectedItem);
            textBox1.Text = list;
            data db = new data();
            DataTable table = new DataTable();
            MySqlCommand cmd = new MySqlCommand("SELECT `Cost` FROM `foodorder` WHERE `ItemName` = '" + list + "'", db.getConnection());
            db.openConnection();
            MySqlDataReader da = cmd.ExecuteReader();
            while(da.Read()){
            textBox2.Text = da.GetValue(0).ToString();
            }
            db.closeConnection();

        }

        private void UserControl2_Load(object sender, EventArgs e)
        {

        }

        private void quantity_t_ValueChanged(object sender, EventArgs e)
        {
            int q = int.Parse(quantity_t.Value.ToString());
            int tcost = int.Parse(textBox2.Text);

            total_t.Text = (q * tcost).ToString();
        }

        private void quantity_t_Leave(object sender, EventArgs e)
        {
            quantity_t.Value.Equals("0");
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (quantity_t.Text == "")
            {
                MessageBox.Show(" Select Quantity to Add to Cart. ");
            }
            else if (total_t.Text == "")
            {
                MessageBox.Show(" You Havent Selected anything ");
            }
            else if(textBox1.Text == "")
            {
                MessageBox.Show(" You Havent Selected anything ");
            }
            else
            {
                int r;
                r = cartbox.Rows.Add();
                cartbox.Rows[r].Cells[0].Value = textBox1.Text;
                cartbox.Rows[r].Cells[1].Value = textBox2.Text;
                cartbox.Rows[r].Cells[2].Value = quantity_t.Text;
                cartbox.Rows[r].Cells[3].Value = total_t.Text;
            }


        }
    }
}
