using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPFBloodBank
{
    public partial class RegisterMedical : Window
    {
        private tableUser principleUser = Login.GetPrincipalUser();
        public RegisterMedical()
        {
            InitializeComponent();
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            var databaseContext = new UserRegistrationDBEntities();
            var user = new DonorDetail()

            {
                DonorID = Int32.Parse(donorIDText.Text.Trim()),
                DOB = Convert.ToDateTime(birthText.Text.Trim()),
                Gender = genderText.Text.Trim(),
                Ethnicity = ethnicityText.Text.Trim(),
                BloodType = bloodTypeText.Text.Trim(),
                RHFactor = rhFactorText.Text.Trim(),
                MedicalHistory = historyText.Text.Trim(),
                NhsID = principleUser.NhsID

            };
            databaseContext.DonorDetails.Add(user);
            databaseContext.SaveChanges();
            MessageBox.Show("Donor Data Added");
            Account loadAccountSummary = new Account();
            this.Hide();
            loadAccountSummary.Show();
        }

        private void Account_Click(object sender, RoutedEventArgs e)
        {
            goBackToAccount();
        }

        private void CancelSend_Click(object sender, RoutedEventArgs e)
        {
            goBackToAccount();

        }

        public void goBackToAccount() {
            Account originalPage = new Account();
            this.Hide();
            originalPage.Show();
        }

        private void homeFromReg_Click(object sender, RoutedEventArgs e)
        {
            MainWindow welcomePage = new MainWindow();
            this.Hide();
            welcomePage.Show();
        }

    }
}