using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPFBloodBank
{
    public partial class ViewDonorDetails : Window
    {
        private tableUser principleUser;
        private DonorDetail principleDonor;
        public ViewDonorDetails()
        {
            principleUser = Login.GetPrincipalUser();
            InitializeComponent();
            PopulateViewGUI();
        }


        public void PopulateViewGUI()
        {
            principleDonor = Account.GetDonorDetails();
            donorIDLabel.Content = $"Donor ID: {principleDonor.DonorID}";
            birthLabel.Content = $"DOB: {principleDonor.DOB}";
            genderLabel.Content = $"Gender: {principleDonor.Gender}";
            raceLabel.Content = $"Ethnicity: {principleDonor.Ethnicity}";
            bloodTypeLabel.Content = $"Blood Type: {principleDonor.BloodType}";
            rhFactorLabel.Content = $"RH Factor {principleDonor.RHFactor}";
            pastLabel.Content = $"History {principleDonor.MedicalHistory}";
        }

        private void homeFromReg_Click(object sender, RoutedEventArgs e)
        {
            MainWindow goHome = new MainWindow();
            this.Hide();
            goHome.Show();
        }

        private void ExitFromViewDonorDetails_Click(object sender, RoutedEventArgs e)
        {
            if (principleUser != null)
            {
                Login.SetPrincipleUser(null);
                MainWindow logOutToHome = new MainWindow();
                logOutToHome.LogOut();
                this.Hide();
                logOutToHome.Show();
            }
        }

        private void Account_Click(object sender, RoutedEventArgs e)
        {
            Account backToUserDetails = new Account();
            this.Hide();
            backToUserDetails.Show();

        }
    }
}