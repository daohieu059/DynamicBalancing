using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dynamic_balancing_machine
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tBoxUser.Focus();
        }
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (tBoxUser.Text == "demo" && tBoxPassword.Text == "123")
            {
                new MachineControlForm().Show();
                this.Hide();
            }
            else if (tBoxUser.Text.Length == 0 && tBoxPassword.Text.Length == 0)
            {
                MessageBox.Show("The User name and Passwword is empty.\r Please enter User name and Password!");
                tBoxUser.Focus();
            }    
            else if (tBoxUser.Text.Length == 0)
            {
                MessageBox.Show("The User name is empty.\rPlease enter User name!");                
                tBoxUser.Focus();
            }
            else if (tBoxPassword.Text.Length == 0)
            {
                MessageBox.Show("The Password is empty.\rPlease enter Password!");               
                tBoxPassword.Focus();
            }
            else
            {
                MessageBox.Show("The User name or Password you entered is incorrect. Try again!");
                tBoxUser.Clear();
                tBoxPassword.Clear();
                tBoxUser.Focus();
            }
        }

        private void labelExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
