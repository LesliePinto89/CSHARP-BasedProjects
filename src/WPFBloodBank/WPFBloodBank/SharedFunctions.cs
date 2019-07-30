using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WPFBloodBank
{
    public static class SharedFunctions 
    {
        private static List<TextBox> errorBoxes;
        private static List<string> errorMessages = new List<string>();

        public static void ResetBox(TextBox box)
        {
            if (box.Background == Brushes.Red)
                box.Background = Brushes.White;
        }

        public static void FullSizeWindow(Window current) {
            current.WindowState = WindowState.Maximized;
        }

        public static List<TextBox> GetFoundErrors()
        {
            return errorBoxes;
        }
            public static void CheckForErrors() {
                string errors = "";
                foreach (TextBox box in errorBoxes)
                    box.Background = Brushes.Red;
                foreach (String error in errorMessages)
                    errors += error + "\n";
                MessageBox.Show(errors);
                errorBoxes.Clear();
                errorMessages.Clear();  
        }

        public static void Clear(Window current)
        {
            foreach (TextBox tb in FindVisualChildren<TextBox>(current))
            {
                tb.Text = "";
            }
        }

        public static bool CheckEmptyOnly(Window current)
        {
            bool isEmpty = false;
            foreach (TextBox tb in FindVisualChildren<TextBox>(current))
            {
                if (tb.Text == "")
                    isEmpty = true;
                else
                {
                    isEmpty = false;
                    break;
                }
            }
            return isEmpty;
        }

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


        public static void AddErrors(TextBox box, string error)
        {
            errorBoxes.Add(box);
            errorMessages.Add(error);
        }

        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }


        public static bool PassedEmpty(Window current)
        {
            errorBoxes = new List<TextBox>();
            foreach (TextBox tb in FindVisualChildren<TextBox>(current))
            {
                    if (tb.Text == "")
                    {
                    tb.Background = Brushes.Red;
                       errorBoxes.Add(tb);
                    }
            }

            if (errorBoxes.Count() == 0)
                return true;
            else
            {
                MessageBox.Show("Fill in manditory fields");
                errorBoxes.Clear();
                return false;
            }
        }




    }
}
