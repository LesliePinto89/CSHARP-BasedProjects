using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Windows;

namespace WPFBloodBank
{
    public partial class Account : Window
    {
        private tableUser activeUser;

        public Account(tableUser current)
        {
            this.activeUser = current;
            InitializeComponent();
            populateGUI();
        }

        private void exitFromDetails_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (activeUser != null)
            {
                MainWindow logOutToHome = new MainWindow();
                this.Hide();
                logOutToHome.Show();
            }

        }

        public void populateGUI() {
            accountFirstLabel.Content = $"First Name: {activeUser.FirstName}";
            accountLastLabel.Content = $"Last Name: {activeUser.LastName}";
            accountNumberLabel.Content = $"Contact: {activeUser.Contact}";
            accountLocationLabel.Content = $"Address: {activeUser.Address}";
            accountAliasLabel.Content = $"Username: {activeUser.Username}";
            accountMailLabel.Content = $"Email {activeUser.Email}";
        }

        private void welcomeIcon_Click(object sender, RoutedEventArgs e)
        {
            MainWindow goHomeStaylogged = new MainWindow(activeUser);
            this.Hide ();
            goHomeStaylogged.Show();
        }
    }
}