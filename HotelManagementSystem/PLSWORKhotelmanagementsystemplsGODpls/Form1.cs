using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Villa90_s_Hotel_Management_System
{
    public partial class Form1 : Form
    {
        string gdr, query;
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=c:\users\rm\documents\visual studio 2013\Projects\PLSWORKhotelmanagementsystemplsGODpls\PLSWORKhotelmanagementsystemplsGODpls\DatabaseOfVilla90.mdf;Integrated Security=True");
        SqlCommand cmd;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                query = "select * from Login where Username = '" + txtusername.Text + "'";
                cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtusername.Text = dr["username"].ToString();
                    txtpassword.Text = dr["password"].ToString();
                }
                if (txtusername.Text == "GMvilla90s" && txtpassword.Text == "villa90gm123")
                {
                    MessageBox.Show("Login complete");
                }
                else
                {
                    MessageBox.Show("Login failed", " failed", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtpassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtusername_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

    }
}
