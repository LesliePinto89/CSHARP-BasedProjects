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
    public partial class Home : Form
    {
        private tableUser logged;

        public Home(tableUser loggedIn)
        {
            this.logged = loggedIn;
            InitializeComponent();
        }



        private void Home_Load(object sender, EventArgs e)
        {

            if (logged != null)
            {
                label1.Text = $"Welcome {logged.Username}";
            }  
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (logged != null)
            {
                Account anAccount = new Account(logged);
                this.Hide();
                anAccount.Show();
            }
        }
    }
}
