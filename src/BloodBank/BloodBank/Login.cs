using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace BloodBank
{


    public partial class Login : Form
    {
        readonly string connectionString = ConfigurationManager.ConnectionStrings["ConnectionLink"].ConnectionString;

        public Login()
        {
            InitializeComponent();
        }

        private void register_Click(object sender, EventArgs e)
        {
            Registration regF = new Registration();
            regF.Show();
            this.Hide();
        }

        private void login_Click(object sender, EventArgs e)
        {


            if (txtUsername.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Fill in manditory fields");
            }

            else
            {
                SqlConnection sqlConnection = new SqlConnection(connectionString);


                string loginQuery = "select * from tableUser where Username = @Username and Password = @Password ";
                SqlCommand sqlCommand = new SqlCommand(loginQuery, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());
                sqlConnection.Open();

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    if (sqlDataReader.HasRows == true)
                    {
                        MessageBox.Show("Login Successfully Done");
                    }
                }
                if (sqlDataReader.HasRows == false)
                {
                    MessageBox.Show("Access Denied, password username mismatched");
                }
            }
        }
    }
}
