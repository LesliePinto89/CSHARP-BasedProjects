using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WPFBloodBank
{
    public partial class RegisterMedical : Window
    {
        private tableUser principleUser = Login.GetPrincipalUser();
        public RegisterMedical()
        {
            InitializeComponent();
            SharedFunctions.FullSizeWindow(this);
        }

        public void ValidateDonorDetails() {
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
            SharedFunctions.BackToAccount(this);
        }
        public static bool IsDate(string text)
        {
            try
            {
                DateTime dt = DateTime.Parse(text);
                if (dt.Day < 1 && dt.Day > 31)
                    return false;
                else
                    return true;
            }
            catch
            {
                return false;
            }
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            bool passedEmptyBoxesStage = SharedFunctions.PassedEmpty(this);
            if (passedEmptyBoxesStage)
            {
                if (IsDate(birthText.Text) ==false)
                    SharedFunctions.AddErrors(birthText, "Incorrect format: Example format - 12/06/1972");

                Match match = Regex.Match(bloodTypeText.Text, "^([A-Z]+\\-)(Positive|Negative)$");
                if (match.Success ==false)
                    SharedFunctions.AddErrors(bloodTypeText, "Incorrect format: Should be 1 or more letters, a '-' symbol, and then" +
                        "either Positive or Negative");

                if (SharedFunctions.GetFoundErrors().Count() == 0)
                    ValidateDonorDetails();
                else
                    SharedFunctions.CheckForErrors();
            }
        }

        private void Account_Click(object sender, RoutedEventArgs e)
        {
            SharedFunctions.BackToAccount(this);
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            SharedFunctions.BackToAccount(this);
        }

        private void homeFromReg_Click(object sender, RoutedEventArgs e)
        {
            SharedFunctions.GoHomeOnly(this);
           
        }

        private void BirthText_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            SharedFunctions.ResetBox(sender as TextBox);
        }

        private void GenderText_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            SharedFunctions.ResetBox(sender as TextBox);
        }

        private void EthnicityText_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            SharedFunctions.ResetBox(sender as TextBox);
        }

        private void BloodTypeText_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            SharedFunctions.ResetBox(sender as TextBox);
        }

        private void RhFactorText_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            SharedFunctions.ResetBox(sender as TextBox);
        }

        private void HistoryText_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            SharedFunctions.ResetBox(sender as TextBox);

        }
    }
}