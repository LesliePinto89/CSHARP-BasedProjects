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
            SharedFunctions.FullSizeWindow(this);
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

        private void Welcome_Click(object sender, RoutedEventArgs e)
        {
            SharedFunctions.GoHomeOnly(this);
        }

        private void Signout_Click(object sender, RoutedEventArgs e)
        {
            if (principleUser != null)
            {
                SharedFunctions.LogOffAndGoHome(this);
            }
        }

        private void Account_Click(object sender, RoutedEventArgs e)
        {
            SharedFunctions.BackToAccount(this);   
        }

        private void Data_Click(object sender, RoutedEventArgs e)
        {
            SharedFunctions.ViewAllRecords(this);
        }
    }
}