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
    public partial class Rooms : Form
    {
        string query;
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=c:\users\rm\documents\visual studio 2013\Projects\PLSWORKhotelmanagementsystemplsGODpls\PLSWORKhotelmanagementsystemplsGODpls\DatabaseOfVilla90.mdf;Integrated Security=True");
        SqlCommand cmd;
        public Rooms()
        {
            InitializeComponent();
        }

       

        
        

        

       
        private void BTNexit_Click(object sender, EventArgs e)
        {

            this.Hide();
            Reservations f = new Reservations();
            f.ShowDialog();
        }

        

        private void CMBroomtype_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TXTroomno_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Rooms_Load_1(object sender, EventArgs e)
        {
            CMBroomtype.Items.Add("Standard Double");
            CMBroomtype.Items.Add("Standard Triple");
            CMBroomtype.Items.Add("Standard Twin room");
            CMBroomtype.Items.Add("Deluxe Double");
            CMBroomtype.Items.Add("Deluxe Triple");
            CMBroomtype.Items.Add("Deluxe Twin room");

            con.Open();
            string query = "select * from Rooms";
            cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(dr);

            dataGridView1.DataSource = dt;

            con.Close();
        }

        private void BTNadd_Click_1(object sender, EventArgs e)
        {
            try
            {

                con.Open();
                query = "insert into Rooms (RoomNo, RoomType)values ('" + TXTroomno.Text + "','" + CMBroomtype.Text + "')";
                cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully  updated the Rooms", "success", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BTNclear_Click(object sender, EventArgs e)
        {

            TXTroomno.Clear();
            CMBroomtype.Text = "";
        }

        private void BTNupdate_Click_1(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                query = "Update Rooms set RoomType='" + CMBroomtype.Text + "'";
                cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfulyy updated the Rooms", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSEARCH_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                query = "select * from Rooms where RoomNo= '" + TXTroomno.Text + "'";

                cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    TXTroomno.Text = dr["RoomNo"].ToString();
                    CMBroomtype.Text = dr["RoomType"].ToString();
                }
                else
                {
                    MessageBox.Show("Room not found", "Not found", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BTNdelete_Click_1(object sender, EventArgs e)
        {
            
            try
            {
                if (MessageBox.Show("Are you sure you want to delete this Room", "Confirm deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
                {
                    con.Open();
                    query = "Delete from Rooms where RoomNo= '" + TXTroomno.Text + "'";
                    cmd = new SqlCommand(query, con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        MessageBox.Show("Deletion Complete");
                    }
                    else
                    {
                        MessageBox.Show("deletion complete", "deleted", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }

                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        
        }

        private void BTNexit_Click_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
