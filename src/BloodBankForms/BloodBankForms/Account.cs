using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BloodBankForms
{
    public partial class Account : Form
    {
        private tableUser currentUser;
        public Account(tableUser logged)
        {
            this.currentUser = logged;
            InitializeComponent();
        }

        private void Account_Load(object sender, EventArgs e)
        {
            label1.Text = $"First Name: {currentUser.FirstName}";
            label2.Text = $"Last Name: {currentUser.LastName}";
            label3.Text = $"Contact: {currentUser.Contact}";
            label4.Text = $"Address: {currentUser.Address}";
            label5.Text = $"Username: {currentUser.Username}";
            label6.Text = $"Email {currentUser.Email}";
        }
    }
}
