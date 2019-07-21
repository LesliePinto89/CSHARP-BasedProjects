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

        }

        private void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            using (var context = new UserRegistrationDBEntities())
            {
                /*var query = context.DonorDetails
                                   .Where(d => d.Ethnicity == "Bill")
                                   .FirstOrDefault<Student>();*/

               // this.DataContext = context.DonorDetails.Local;
                dataGrid.ItemsSource = context.DonorDetails.Local;

                /*var query = from s in context.DonorDetails
                select s;*/
            }
        }
    }
}