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
    public partial class Reservations : Form
    {

        string gdr, query, query2;
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=c:\users\rm\documents\visual studio 2013\Projects\PLSWORKhotelmanagementsystemplsGODpls\PLSWORKhotelmanagementsystemplsGODpls\DatabaseOfVilla90.mdf;Integrated Security=True");
        SqlCommand cmd;
        public Reservations()
        {
            InitializeComponent();
        }

        private void btnSEARCH_Click(object sender, EventArgs e)
        {
           
        }

        private void btnSAVE_Click(object sender, EventArgs e)
        {

           
        }

        private void btnUPDATE_Click(object sender, EventArgs e)
        {
            
        }

        private void btnDELETE_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to delete this information", "confirm deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
                {
                    con.Open();
                    query = "Delete from Guest where NIC= '" + txtNIC.Text + "'";
                    cmd = new SqlCommand(query, con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        MessageBox.Show("Deletion complete");
                    }
                    else
                    {
                        MessageBox.Show("Deletion complete", " deleted", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }
                    txtNIC.Clear();
                    txtFULLNAME.Clear();
                    txtCONTACT.Clear();
                    cmbboxTITLE.Text = "";
                    txtEMAIL.Clear();
                    txtCOUNTRY.Clear();
                    txtTRAVELAGENT.Clear();
                    dtpDOB.CustomFormat = "";
                    rbMALE.Checked = false;
                    rbFEMALE.Checked = false;
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEXIT_Click(object sender, EventArgs e)
        {
            
        }

        private void btnCLEAR_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //try
            //{
            var ArrivalDate = DateTime.Today;
            int nights = int.Parse(TXTnights.Text);
            var DepartureDate = ArrivalDate.AddDays(1 + nights);

            con.Open();
            query = " insert into Reservation ( RoomNo, GuestNIC, ArrivalDate, DepartureDate, Nights, NumberOfAdults, NumberOfChildren, RoomType, Rate) values ('" + txtRoomNo.Text + "', '" + txtNationalidentity.Text + "', '" + ArrivalDate + "', '" + DepartureDate + "', '" + nights + "', '" + TXTadults.Text + "', '" + txtCHILDREN.Text + "','" + cmbRoomType.Text + "', '" + txtRate.Text + "')";
            cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully added the Reservation", "success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            con.Close();
        }
        /* }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }*/

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                query = " Select * from Reservation where GuestNIC= '" + txtNationalidentity.Text + "'";
                cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    dtparrivaldate.Text = dr["ArrivalDate"].ToString();
                    dtpdeparturedate.Text = dr["DepartureDate"].ToString();
                    TXTnights.Text = dr["Nights"].ToString();
                    TXTadults.Text = dr["NumebrOfAdults"].ToString();
                    txtCHILDREN.Text = dr["NumberOfChildren"].ToString();
                    cmbRoomType.Text = dr["RoomType"].ToString();
                    txtRoomNo.Text = dr["RoomNO"].ToString();
                    txtRate.Text = dr["Rate"].ToString();
                }
                
                else
                {
                    MessageBox.Show("Reservation not found", "Not found", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                query = "Update Reservation set ArrivalDate = '"+ dtparrivaldate.Value +"', DepartureDate = '" +dtpdeparturedate.Value+ "', Nights = '"+ TXTnights.Text +"', NumberOfAdults = '"+ TXTadults.Text +"', NumberOfChildren = '"+ txtCHILDREN.Text +"', RoomType = '"+ cmbRoomType.Text +"', RoomNO = '"+ txtRoomNo.Text +"', Rate = '"+ txtRate.Text +"' Where GuestNIC = '"+ txtNationalidentity.Text +"'";
                cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully updated the Reservation", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
            }
             
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to delete this Resrevation", "confirm deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
                {
                    con.Open();
                    query = "Delete from Reservation where GuestNIC= '" + txtNationalidentity.Text + "'";
                    cmd = new SqlCommand(query, con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        MessageBox.Show("Deletion completed");

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

        private void button5_Click(object sender, EventArgs e)
        {
            txtNationalidentity.Clear();
            dtparrivaldate.CustomFormat = "";
            dtpdeparturedate.CustomFormat = "";
            TXTnights.Clear();
            TXTadults.Clear();
            txtCHILDREN.Clear();
            cmbRoomType.Text = "";
            txtRoomNo.Clear();
            txtRate.Clear();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = new Form1();
            f.ShowDialog();

        }

        private void btnSAVE_Click_1(object sender, EventArgs e)
        {
         try
            {
            con.Open();
            query = " insert into Guest(NIC, FullName, Title, Contact, Email, Agent, Gender, Country, DOB)values ('"+ txtNIC.Text +"', '"+ txtFULLNAME.Text +"', '" + cmbboxTITLE.Text + "', '"+txtCONTACT.Text+"', '"+txtEMAIL.Text+"', '"+ txtTRAVELAGENT.Text +"', '"+ gdr +"', '"+txtCOUNTRY.Text+"', '"+ dtpDOB.Value +"')";
            cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully added the Guest", "success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            con.Close();
        }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSEARCH_Click_1(object sender, EventArgs e)
        {
         try
            {
                con.Open();
                query = " Select * from Guest where NIC= '" + txtNIC.Text + "'";
                cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtFULLNAME.Text = dr["FullName"].ToString();
                    cmbboxTITLE.Text = dr["Title"].ToString();
                    txtCONTACT.Text = dr["Contact"].ToString();
                    txtEMAIL.Text = dr["Email"].ToString();
                    txtTRAVELAGENT.Text = dr["Agent"].ToString();
                    txtCOUNTRY.Text = dr["Country"].ToString();
                    dtpDOB.Text = dr["DOB"].ToString();
                    if (dr["Gender"].ToString() == "Female")
                    {
                        rbFEMALE.Checked = true;
                    }
                    else
                    {
                        rbMALE.Checked = true;
                    }
                }
                else
                {
                    MessageBox.Show("Guest not found", "Not found", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void btnUPDATE_Click_1(object sender, EventArgs e)
        {
        try
            {
                if (rbMALE.Checked)
                {
                    gdr = "Male";
                }
                else if (rbFEMALE.Checked)
                {
                    gdr = "Female";
                }
                else
                {
                    MessageBox.Show("Please select the Gender");
                }
                con.Open();
                query = "update Guest set FullName = '" + txtFULLNAME.Text + "', Title ='" + cmbboxTITLE.Text + "', Contact ='" + txtCONTACT.Text + "', Email ='" + txtEMAIL.Text + "', Agent = '" + txtTRAVELAGENT.Text + "', Gender ='" + gdr + "', Country ='" + txtCOUNTRY.Text + "', DOB ='" + dtpDOB.Value + "' where NIC ='" + txtNIC.Text + "'";
                cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully updated the Guest", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEXIT_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = new Form1();
            f.ShowDialog();
        }

        private void btnNEXT_Click(object sender, EventArgs e)
        {
        
        }

        private void btnCLEAR_Click_1(object sender, EventArgs e)
        {
            txtNIC.Clear();
            txtFULLNAME.Clear();
            txtCONTACT.Clear();
            cmbboxTITLE.Text = "";
            txtEMAIL.Clear();
            txtCOUNTRY.Clear();
            txtTRAVELAGENT.Clear();
            dtpDOB.CustomFormat = "";
            rbMALE.Checked = false;
            rbFEMALE.Checked = false;
        }

        private void btnsearchdate_Click(object sender, EventArgs e)
        {
            con.Open();
            query = "select RoomNo, RoomType, ArrivalDate, DepartureDate from Reservation where RoomNo = '" + txtRoomNo.Text + "' and RoomType= '" + cmbRoomType.Text + "' and ArrivalDate= '" + dtparrivaldate.Value + "' and DeparturDate= '" + dtpdeparturedate.Value + "'";
            query2 = "select RoomType from Reservation where RoomType = '" + cmbRoomType.Text + "'";
            cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                
                DateTime OldArrivalDate = dr.GetDateTime(2);
                DateTime OldDepartureDate = dr.GetDateTime(3);
                DateTime ArrivalDate = DateTime.Parse(dtparrivaldate.Text);
                DateTime DepartureDate = DateTime.Parse(dtpdeparturedate.Text);

                
            }
            

            DataTable dt = new DataTable();
            dt.Load(dr);

            dataGridView2.DataSource = dt;
        }

        private void Reservations_Load(object sender, EventArgs e)
        {
            cmbboxTITLE.Items.Add("Mr");
            cmbboxTITLE.Items.Add("Mrs");
            cmbboxTITLE.Items.Add("Dr");
            cmbboxTITLE.Items.Add("Prof");
            cmbboxTITLE.Items.Add("Rev");
            cmbboxTITLE.Items.Add("Miss");
            cmbRoomType.Items.Add("Standard Double");
            cmbRoomType.Items.Add("Standard Triple");
            cmbRoomType.Items.Add("Standard Twin");
            cmbRoomType.Items.Add("Deluxe Double");
            cmbRoomType.Items.Add("Deluxe Triple");
            cmbRoomType.Items.Add("Deluxe Twin");

            con.Open();
            string query = "select RoomNo, RoomType, ArrivalDate, DepartureDate from Reservation";
            cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(dr);

            dataGridView2.DataSource = dt;

            con.Close();
           

            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

      
        }
    }

    

