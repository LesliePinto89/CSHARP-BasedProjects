using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFBloodBank
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static tableUser logged; 

        public MainWindow()
        {
            SharedFunctions.FullSizeWindow(this);
            logged = Login.GetPrincipalUser();
            InitializeComponent();
            if (logged != null)
            {
                navLog.Content = "Sign out";
                label.Content = $"Welcome {logged.Username}";

                Button personalDetails = new Button
                {
                    Content = "My Account",
                    Margin = new Thickness(0, 0, 0, 10),
                    Background = new SolidColorBrush(Color.FromRgb(122, 180, 230)),
                    Foreground = Brushes.White
                };
                nav.Children.Add(personalDetails);
                personalDetails.Click += details_Click;
            }
        }


        private void details_Click(object sender, RoutedEventArgs e)
        {
            SharedFunctions.BackToAccount(this);
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

            if (logged != null)
            {
                label.Content = $"Welcome {logged.Username}";
            }
        }

        private void data_Click(object sender, RoutedEventArgs e)
        {
            SharedFunctions.ViewAllRecords(this);
        }

        private void navLog_Click(object sender, RoutedEventArgs e)
        {
            //This would appear as sign out
            logged = Login.GetPrincipalUser();
            if (logged != null)
            {
                LogOut();
                SharedFunctions.GoHomeOnly(this);
            }
            else //this appears as signin
            {
                Login log = new Login();
                this.Hide();
                log.Show();
            }
        }

        public void LogOut() {
            navLog.Content = "Sign in";
            label.Content = $"Welcome";
            Login.SetPrincipleUser(null);
        }

        private void welcomeIcon_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            this.Show();
        }
    }
}
