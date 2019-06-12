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

namespace BloodBank
{
    public partial class Registration : Form
    {
        //string connectionString = @"Data source=LESLIEOWNING-PC;initial catalog=UserRegistrationDB; Integrated Security =True;";

        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionLink"].ConnectionString;
        public Registration()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Registration_Load(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (txtUsername.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Fill in manditory fields");
            }

            else if (txtPassword.Text != txtPasswordConfirm.Text)
            {

                MessageBox.Show("Password does not match");
            }

            else
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))

                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand("AddUsers", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@FirstName", txtFirstName.Text.Trim());
                    sqlCommand.Parameters.AddWithValue("@LastName", txtLastName.Text.Trim());
                    sqlCommand.Parameters.AddWithValue("@Contact", txtContact.Text.Trim());
                    sqlCommand.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                    sqlCommand.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());
                    sqlCommand.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());
                    sqlCommand.Parameters.AddWithValue("@Mobile", txtMobile.Text.Trim());
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Successful");
                    clear();
                }
            }
        }

        void clear() {
            txtFirstName.Text = txtLastName.Text = txtContact.Text = txtAddress.Text = txtUsername.Text = txtPassword.Text = "";
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
