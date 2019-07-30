using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WPFBloodBank
{
    public partial class DataRecords : Window

    {
        public DataRecords()
        {
            InitializeComponent();
            SharedFunctions.FullSizeWindow(this);
        }

        private void FindIt_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Search userCheck = new Search();
            this.Hide();
            userCheck.Show();
        }

        private void welcomeIcon_Click(object sender, System.Windows.RoutedEventArgs e)
        {
           
            SharedFunctions.GoHomeOnly(this);
        }

 

 
        private void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            if (Search.TriggeredSearch()==false)
            {
                using (var context = new UserRegistrationDBEntities())
                {
                    var DonorDetails = context.DonorDetails;
                    List<DonorDetail> allDonors = new List<DonorDetail>();
                    foreach (DonorDetail donor in DonorDetails)
                    {
                        allDonors.Add(donor);
                    }
                    this.dataGrid.ItemsSource = allDonors;
                }
            }
            else {
                if (Search.FoundMatches().Count() == 0) {
                    Label error = new Label
                    {
                        Content = $"No entries found"
                    };

                }
                else { 
                this.dataGrid.ItemsSource = Search.FoundMatches();
                    }
            }
        }
    }
}