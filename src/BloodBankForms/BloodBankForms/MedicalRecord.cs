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
using System.Configuration;

namespace BloodBankForms
{
    public partial class MedicalRecord : Form
    {
        readonly string connectionString = ConfigurationManager.ConnectionStrings["ConnectionLink"].ConnectionString;

        public MedicalRecord()
        {
            InitializeComponent();
        }

        private void TxtBloodType_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtRHFactor_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtDonor_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtGender_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtMedicalHistory_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void submitDonorDetails_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))

            {

                if (txtNHSNumber.Text == "" || !txtNHSNumber.Text.All(Char.IsDigit))
                {
                    MessageBox.Show("Please type in a valid 10 digit NHS ID");
                }
                else { 

                    sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("AddUsers", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@NhsID", txtNHSNumber.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@DOB", dobPicker.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@Gender", txtGender.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@Ethnicity", txtEthnicity.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@BloodType", txtBloodType.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@RHFactor", txtRHFactor.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@MedicalHistory", txtMedicalHistory.Text.Trim());
                sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Your donor details jave been added to your account");
                Clear();
                    Login logF = new Login();
                    logF.Show();
                    this.Hide();

                }
            }

        }

        private void GpdrAgreeBox_CheckedChanged(object sender, EventArgs e)
        {
            if (gpdrAgreeBox.Checked == true)
            {
                gpdrAgreeBox.Enabled = true;
            }
        }

        private void TxtNHSNumber_TextChanged(object sender, EventArgs e)
        {
            if (txtNHSNumber.Text == "")
            {
                MessageBox.Show("Please type in your NHS number");
            }
        }


        void Clear()
        {
            txtNHSNumber.Text = dobPicker.Text = txtGender.Text = 
                txtEthnicity.Text = txtBloodType.Text = txtMedicalHistory.Text = txtRHFactor.Text = "";
        }
    }
}
