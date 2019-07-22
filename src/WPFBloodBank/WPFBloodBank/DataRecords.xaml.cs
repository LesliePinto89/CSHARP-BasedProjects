using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace WPFBloodBank
{
    public partial class DataRecords : Window
    {
        public DataRecords()
        {
            InitializeComponent();
        }

        private void FindIt_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void welcomeIcon_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            SharedFunctions.GoHomeOnly(this);
        }

        private void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            using (var context = new UserRegistrationDBEntities())
            {
                /*var query = context.DonorDetails
                                   .Where(d => d.Ethnicity == "Bill")
                                   .FirstOrDefault<Student>();*/

                // this.DataContext = context.DonorDetails.Local;
                var DonorDetails = context.DonorDetails;
                List<DonorDetail> allDonors = new List<DonorDetail>();
                foreach (DonorDetail donor in DonorDetails) {
                    allDonors.Add(donor);
                }
                this.dataGrid.ItemsSource = allDonors;
            }
        }
    }
}