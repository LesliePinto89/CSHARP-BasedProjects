using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
namespace WPFBloodBank
{
    public static class SharedFunctions 
    {
        public static void BackToAccount(Window current)
        {
            Account originalPage = new Account();
            current.Hide();
            originalPage.Show();
        }

        public static void GoHomeOnly(Window current)
        {
            MainWindow welcomePage = new MainWindow();
            current.Hide();
            welcomePage.Show();
        }

        public static void ViewAllRecords(Window current)
        {
            DataRecords records = new DataRecords();
            current.Hide();
            records.Show();
        }

        public static void LogOffAndGoHome(Window current)
        {
            Login.SetPrincipleUser(null);
            MainWindow welcomePage = new MainWindow();
            welcomePage.LogOut();
            current.Hide();
            welcomePage.Show();
        }


    }
}
