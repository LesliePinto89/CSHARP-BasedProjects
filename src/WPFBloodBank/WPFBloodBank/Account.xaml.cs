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
        private static tableUser principleUser;

        public static DonorDetail GetDonorDetails()
        {
            using (var context = new UserRegistrationDBEntities())
            {
                var getEntry = context.DonorDetails;
                foreach (DonorDetail aspect in getEntry) {
                    if (aspect.NhsID == principleUser.NhsID)
                        return aspect;
                      }
            }
            return null;   
        }

        public bool AlreadyGaveDonorData() {
            using (var context = new UserRegistrationDBEntities()) { 
           var getEntry = context.DonorDetails
        .Where(c => c.NhsID == principleUser.NhsID)
        .Select(c => c.NhsID).ToArray();
                if (getEntry.Contains(principleUser.NhsID)) { return true; }
            }
            return false;    
        }

        public Account( )
        {
            SharedFunctions.FullSizeWindow(this);
            principleUser = Login.GetPrincipalUser();
            InitializeComponent();
            if (AlreadyGaveDonorData())
            {
                medical.Content = "View Donor Details";
            }
            populateGUI();
        }

        private void ExitFromDetails_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (principleUser != null)
            {
                SharedFunctions.LogOffAndGoHome(this);
            }
        }

        public void populateGUI() {
            label.Content = $"Hi {principleUser.Username}, These are your user details";
            accountFirstLabel.Content = $"First Name: {principleUser.FirstName}";
            accountLastLabel.Content = $"Last Name: {principleUser.LastName}";
            accountNumberLabel.Content = $"Contact: {principleUser.Contact}";
            accountLocationLabel.Content = $"Address: {principleUser.Address}";
            accountAliasLabel.Content = $"Username: {principleUser.Username}";
            accountMailLabel.Content = $"Email {principleUser.Email}";
        }

        private void Welcome_Click(object sender, RoutedEventArgs e)
        {
            //Go home but stay logged in
            SharedFunctions.GoHomeOnly(this);
        }

        private void Medical_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            if (medical.Content.Equals("View Donor Details"))
            {
                ViewDonorDetails getDetails = new ViewDonorDetails();
                getDetails.Show();
            }
            else {
                RegisterMedical addDetails = new RegisterMedical();
                addDetails.Show();
            }
        }

        private void Data_Click(object sender, RoutedEventArgs e)
        {
            SharedFunctions.ViewAllRecords(this);
        }
    }
}