using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SNv1Forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string email = emailField.Text;
            string password = passwordField.Text;
            Program.LogIn(email, password);
            if (Program.currentUser != null)
            {
                Form2 form2 = new Form2();
                this.Hide();
                form2.Show();
                form2.Focus();
            }
            else
            {
                label1.Text = "Enter email and password correctly!";
                emailField.Text = "";
                passwordField.Text = "";
            }

        }
    }
}
