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
        //private List<TextBox> errorBoxes = new List<TextBox>();
        //private List<string> errorMessages = new List<string>();
        private bool registered = false;


        public Register()
        {
            InitializeComponent();
            SharedFunctions.FullSizeWindow(this);
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
            SharedFunctions.Clear(this);
            SharedFunctions.GoHomeOnly(this);
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            bool passedEmptyBoxesStage = SharedFunctions.PassedEmpty(this);
            var emailAtr = new EmailAddressAttribute();
            if (passedEmptyBoxesStage)
            {
                if (!number.Text.All(Char.IsDigit))
                    SharedFunctions.AddErrors(number, "Contact: Type in only numbers");

                if (pass.Text != confirm.Text)
                    SharedFunctions.AddErrors(pass, "Password confirmation does not match");

                if (emailAtr.IsValid(mail.Text) == false)
                    SharedFunctions.AddErrors(mail, "Please write your email in the format: user@provider.domain");

                if (SharedFunctions.GetFoundErrors().Count() == 0)
                    AddValidateDetails();
                else
                {
                    SharedFunctions.CheckForErrors();

                }
            }
            //All fields where blank, leave all red, but change as input
            else
                SharedFunctions.Clear(this);
        }

        private void First_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (registered == false)
               SharedFunctions.ResetBox(sender as TextBox);
        }

        private void TextBox2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (registered == false)
                SharedFunctions.ResetBox(sender as TextBox);
        }

        private void Number_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (registered == false)
                SharedFunctions.ResetBox(sender as TextBox);
        }

        private void Location_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (registered == false)
                SharedFunctions.ResetBox(sender as TextBox);
        }

        private void Alias_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (registered == false)
                SharedFunctions.ResetBox(sender as TextBox);
        }

        private void Pass_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (registered == false)
                SharedFunctions.ResetBox(sender as TextBox);
        }

        private void Confirm_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (registered == false)
                SharedFunctions.ResetBox(sender as TextBox);
        }

        private void Mail_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (registered == false)
                SharedFunctions.ResetBox(sender as TextBox);
        }

        private void homeFromReg_Click(object sender, RoutedEventArgs e)
        {
            SharedFunctions.GoHomeOnly(this);
        }

        private void Data_Click(object sender, RoutedEventArgs e)
        {
            SharedFunctions.ViewAllRecords(this);

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            SharedFunctions.GoHomeOnly(this);
        }
    }
}