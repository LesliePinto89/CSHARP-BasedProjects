using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.ComponentModel.DataAnnotations;

namespace BloodBankForms
{
    public partial class Registration : Form
    {
        private List<TextBox> errorBoxes = new List<TextBox>();
        private List<string> errorMessages = new List<string>();
        private bool registered = false;
        public Registration()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {}

        private void TxtFirstName_TextChanged(object sender, EventArgs e)
        {
            if (registered == false)
                ResetBox(sender as TextBox);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (registered == false)
                ResetBox(sender as TextBox);
        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (registered == false)
                ResetBox(sender as TextBox);
        }

        private void label2_Click(object sender, EventArgs e)
        {}

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (registered == false)
                ResetBox(sender as TextBox);
        }

        private void Registration_Load(object sender, EventArgs e)
        { }
        private void TxtAddress_TextChanged(object sender, EventArgs e)
        {
            if(registered==false)
            ResetBox(sender as TextBox);
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (registered == false)
                ResetBox(sender as TextBox);
        }

        private void label6_Click(object sender, EventArgs e)
        {}

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (registered == false)
                ResetBox(sender as TextBox);
        }

        private void label7_Click(object sender, EventArgs e)
        {}
        private void label8_Click(object sender, EventArgs e)
        {}

        private void TxtEmail_TextChanged(object sender, EventArgs e)
        {
            if (registered == false)
                ResetBox(sender as TextBox);
        }

        public void ResetBox(TextBox box) {
            if (box.BackColor == Color.Red)
                box.BackColor = Color.White;
        }
        public bool PassedEmpty() {
            List<Control> errorBoxes = new List<Control> ();
            foreach (Control control in this.Controls) {
                if (control is TextBox)
                      if (control.Text == "")
                {
                        control.BackColor = Color.Red;
                        errorBoxes.Add(control);
                }
            }

            if (errorBoxes.Count() == 0)
                return true;
            else
                MessageBox.Show("Fill in manditory fields");
            return false;
        }

        public void AddValidateDetails() {
            var databaseContext = new UserRegistrationDBEntities();
            var user = new tableUser()
            {
                FirstName = txtFirstName.Text.Trim(),
                LastName = txtLastName.Text.Trim(),
                Contact = txtContact.Text.Trim(),
                Address = txtAddress.Text.Trim(),
                Username = txtUsername.Text.Trim(),
                Password = txtPassword.Text.Trim(),
                Email = txtEmail.Text.Trim()
            };
            databaseContext.tableUsers.Add(user);
            databaseContext.SaveChanges();
            registered = true;

            Clear();
            Home home = new Home(user);
            home.Show();
            this.Hide();
        }

        public void AddErrors(TextBox box, string error) {
            errorBoxes.Add(box);
            errorMessages.Add(error);
        }
        public void submit_Click(object sender, EventArgs e)
        {
            bool passedEmptyBoxesStage = PassedEmpty();
            var emailAtr = new EmailAddressAttribute();
            if (passedEmptyBoxesStage)
            {
                if (!txtContact.Text.All(Char.IsDigit))
                    AddErrors(txtContact, "Contact: Type in only numbers");
               
                 if (txtPassword.Text != txtPasswordConfirm.Text)
                    AddErrors(txtPassword, "Password confirmation does not match");

                 if (emailAtr.IsValid(txtEmail.Text) ==false)
                    AddErrors(txtEmail, "Please write your email in the format: user@provider.domain");

                if (errorBoxes.Count() == 0)
                    AddValidateDetails();
                else
                {
                    string errors = "";
                    foreach (TextBox box in errorBoxes)
                        box.BackColor = Color.Red;
                    foreach (String error in errorMessages)
                        errors += error + "\n";
                    MessageBox.Show(errors);
                }
            }
            //All fields where blank, leave all red, but change as input
            else
                Clear();
        }

        void Clear() {
            txtFirstName.Text = txtLastName.Text = txtContact.Text = 
                txtAddress.Text = txtUsername.Text = txtPassword.Text = 
                txtPasswordConfirm.Text = txtEmail.Text = "";
        }
    }
}