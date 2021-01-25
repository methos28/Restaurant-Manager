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

    
    public partial class sign_up : Form
    {
        
        Form1 form = new Form1();

        public sign_up()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void sgnup_usr_TextChanged(object sender, EventArgs e)
        {
        
        }

        private void sgnup2_Click(object sender, EventArgs e)
        {
            //Adding Sign UP info on DATABASE
            
            String usr = sgnup_usr.Text;
            String pswd = sgnup_pswd.Text;
            String cnf = cnft.Text;
            String eml = emlt.Text;
            String cntct = cnt.Text;
            Form1 form = new Form1();


            data db = new data();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO `dbs_personal`(`Username`, `Password`, `Email`, `Contact`) VALUES (@usn , @pswd, @eml, @cnt)",db.getConnection());

            cmd.Parameters.Add("@usn", MySqlDbType.VarChar).Value = usr;
            cmd.Parameters.Add("@pswd", MySqlDbType.VarChar).Value = pswd;
            cmd.Parameters.Add("@eml", MySqlDbType.VarChar).Value = eml;
            cmd.Parameters.Add("@cnt", MySqlDbType.VarChar).Value = cntct;

            db.openConnection();
            if (usr == "" || pswd == "" || eml == "" || cntct == "")
            {

                MessageBox.Show("You havent Entered the required Information");

            }
            else if(cnf == "" || cnf != pswd )
            {
                MessageBox.Show("Password and Confirm Password Should be same ");
            }
            else if (cmd.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Information Added Successfully");
                this.Close();
                
            }
            else
            {
                MessageBox.Show("Error");
            }
            db.closeConnection();


        }

        private void sign_up_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
