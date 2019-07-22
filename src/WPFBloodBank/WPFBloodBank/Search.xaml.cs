using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPFBloodBank
{
    public partial class Search : Window
    {
        public Search()
        {
            InitializeComponent();
        }

        private void Data_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CancelSend_Click(object sender, RoutedEventArgs e)
        {
            SharedFunctions.GoHomeOnly(this);
        }

        private void homeFromReg_Click(object sender, RoutedEventArgs e)
        {
            SharedFunctions.GoHomeOnly(this);
        }
    }
}