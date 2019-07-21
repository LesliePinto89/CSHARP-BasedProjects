using System;
using System.Linq;
using System.Windows.Forms;
using System.Configuration;

namespace BloodBankForms
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
                MessageBox.Show("Fill in manditory fields");

            else
            {
                var context = new UserRegistrationDBEntities();
                var typedUsername = txtUsername.Text.Trim();
                var typedPassword = txtPassword.Text.Trim();
                var user = context.tableUsers.FirstOrDefault(x => x.Username == typedUsername);

                if (user != null)
                {
                    if (typedPassword == user.Password)
                    {
                        MessageBox.Show("Login Successfully Done");
                        Home loadHome = new Home(user);
                        this.Hide();
                        loadHome.Show();
                    }
                    else
                        MessageBox.Show("Incorrect Password");
                }
                else
                    MessageBox.Show("Access Denied, incorrect credentials");
            }
        }
    }
}