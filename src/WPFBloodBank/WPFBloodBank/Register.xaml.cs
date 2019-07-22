using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

using System.ComponentModel.DataAnnotations;



namespace WPFBloodBank
{

    public partial class Register : Window
    {
        private List<TextBox> errorBoxes = new List<TextBox>();
        private List<string> errorMessages = new List<string>();
        private bool registered = false;


        public Register()
        {
            InitializeComponent();
        }

        public void ResetBox(TextBox box)
        {
            if (box.Background == Brushes.Red)
                box.Background = Brushes.White;
        }

        List<TextBox> AllTextBoxes(DependencyObject parent)
        {
            var list = new List<TextBox>();
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                if (child is TextBox)
                    list.Add(child as TextBox);
                list.AddRange(AllTextBoxes(child));
            }
            return list;
        }

        public bool PassedEmpty()
        {
            List<Control> errorBoxes = new List<Control>();

            foreach (var box in AllTextBoxes(this))
            {
                
                    if (box.Text == "")
                    {
                    box.Background = Brushes.Red;
                    errorBoxes.Add(box);
                    }
            }

            if (errorBoxes.Count() == 0)
                return true;
            else
                MessageBox.Show("Fill in manditory fields");
            return false;
        }

        public void AddValidateDetails()
        {
            var databaseContext = new UserRegistrationDBEntities();
            var user = new tableUser()
            {
                FirstName = first.Text.Trim(),
                LastName = last.Text.Trim(),
                Contact = number.Text.Trim(),
                Address = location.Text.Trim(),
                Username = alias.Text.Trim(),
                Password = pass.Text.Trim(),
                Email = mail.Text.Trim()
               
            };
            databaseContext.tableUsers.Add(user);
            databaseContext.SaveChanges();
            MessageBox.Show("Registered successfully");
            registered = true;
            Login.SetPrincipleUser(user);
            Clear();
            SharedFunctions.GoHomeOnly(this);
        }

        public void AddErrors(TextBox box, string error)
        {
            errorBoxes.Add(box);
            errorMessages.Add(error);
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            bool passedEmptyBoxesStage = PassedEmpty();
            var emailAtr = new EmailAddressAttribute();
            if (passedEmptyBoxesStage)
            {
                if (!number.Text.All(Char.IsDigit))
                    AddErrors(number, "Contact: Type in only numbers");

                if (pass.Text != confirm.Text)
                    AddErrors(pass, "Password confirmation does not match");

                if (emailAtr.IsValid(mail.Text) == false)
                    AddErrors(mail, "Please write your email in the format: user@provider.domain");

                if (errorBoxes.Count() == 0)
                    AddValidateDetails();
                else
                {
                    string errors = "";
                    foreach (TextBox box in errorBoxes)
                    box.Background = Brushes.Red;
                    foreach (String error in errorMessages)
                        errors += error + "\n";
                    MessageBox.Show(errors);
                }
            }
            //All fields where blank, leave all red, but change as input
            else
                Clear();
        }

        void Clear()
        {
            first.Text = last.Text = number.Text =
                location.Text = alias.Text = pass.Text =
                confirm.Text = mail.Text = "";
        }

        private void First_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (registered == false)
                ResetBox(sender as TextBox);
        }

        private void TextBox2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (registered == false)
                ResetBox(sender as TextBox);
        }

        private void Number_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (registered == false)
                ResetBox(sender as TextBox);
        }

        private void Location_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (registered == false)
                ResetBox(sender as TextBox);
        }

        private void Alias_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (registered == false)
                ResetBox(sender as TextBox);
        }

        private void Pass_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (registered == false)
                ResetBox(sender as TextBox);
        }

        private void Confirm_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (registered == false)
                ResetBox(sender as TextBox);
        }

        private void Mail_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (registered == false)
                ResetBox(sender as TextBox);
        }

        private void homeFromReg_Click(object sender, RoutedEventArgs e)
        {
            SharedFunctions.GoHomeOnly(this);
        }
    }
}