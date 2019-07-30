using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows;

namespace WPFBloodBank
{
    public partial class Login : Window
    {
        private static tableUser user = null;

        public static tableUser GetPrincipalUser()
        {
            return user;
        }

        public static void SetPrincipleUser(tableUser principle) {
            user = principle;
        }
        public Login()
        {
            InitializeComponent();
            SharedFunctions.FullSizeWindow(this);
        }

        private void Data_Click(object sender, RoutedEventArgs e)
        {
            SharedFunctions.ViewAllRecords(this);
        }

        private void Signup_Click(object sender, RoutedEventArgs e)
        {
            Register signup = new Register();
            this.Hide();
            signup.Show();
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            if (alias.Text == "" || pass.Text == "")
                MessageBox.Show("Fill in manditory fields");

            else
            {
                var context = new UserRegistrationDBEntities();
                var typedUsername = alias.Text.Trim();
                var typedPassword = pass.Text.Trim();
                var user = context.tableUsers.FirstOrDefault(x => x.Username == typedUsername);

                SetPrincipleUser(user);
                if (user != null)
                {
                    if (typedPassword != user.Password)
                    {
                        MessageBox.Show("Incorrect Password");
                        
                    }
                    else
                        SharedFunctions.GoHomeOnly(this);
                }
                else
                    MessageBox.Show("Access Denied, incorrect credentials");
            }
        }

        private void GoFromLog_Click(object sender, RoutedEventArgs e)
        {
            //Go home without attempting to login
            SharedFunctions.GoHomeOnly(this);
        }

        private void Alias_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void Pass_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }
    }
}