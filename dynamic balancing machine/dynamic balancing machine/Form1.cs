using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.SqlClient;

namespace dynamic_balancing_machine
{
    public partial class Form1 : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
        int nLeftRect,
        int nTopRect,
        int nRightRect,
        int nBottomRect,
        int nWidthEllipse,
        int nHeightEllipse
        );
        public Form1()
        {
            InitializeComponent();
            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tBoxUser.Focus();
            
        }

        //Login
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            //SqlConnection con = new SqlConnection(@"Data Source=dynamicbalancmachine.database.windows.net;Initial Catalog=DBMk18;Persist Security Info=True;User ID=daotrunghieu059;Password=090220Hieu!");
            //con.Open();
            //SqlCommand cmd = new SqlCommand("SELECT * FROM Table_user WHERE user_name = '" + tBoxUser.Text + "' AND pass = '" + tBoxPassword.Text + "'", con);
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //con.Close();
            //int i = 0;
            //if (dt != null)
            //{
                //foreach (DataRow dr in dt.Rows)
                //{
                    //i++;
                //}
            //}
            //textBox1.Text = i.ToString();
            if (tBoxUser.Text != "Username")
            {
                if (tBoxPassword.Text != "Password")
                {
                    if (tBoxUser.Text == "d" && tBoxPassword.Text == "f")
                    {
                        MachineControlForm machineControlForm = new MachineControlForm();
                        machineControlForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        labelError("Incorrect User name or Password entered\r      Please try again!");
                        tBoxUser.Clear();
                        tBoxPassword.UseSystemPasswordChar = false;
                        tBoxPassword.Text = "Password";
                        tBoxPassword.ForeColor = Color.DarkGray;
                        tBoxUser.Focus();
                    }
                }
                else
                {
                    labelError("Please enter Password");
                    tBoxPassword.Focus();
                }                
            }
            else
            {
                labelError("Please enter Username");                
                tBoxUser.Focus();
            }    
            
        }

        private void labelError(string message)
        {
            lblError.Text = "      " + message;
            lblError.Visible = true;
        }
        private void labelExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tBoxUser_Enter(object sender, EventArgs e)
        {
            if (tBoxUser.Text == "Username"&&tBoxUser.ForeColor == Color.DarkGray)
            {
                tBoxUser.Text = "";
                tBoxUser.ForeColor = Color.LightGray;
            }    
        }

        private void tBoxUser_Leave(object sender, EventArgs e)
        {
            if (tBoxUser.Text == "")
            {
                tBoxUser.Text = "Username";
                tBoxUser.ForeColor = Color.DarkGray;
            }
        }

        private void tBoxPassword_Enter(object sender, EventArgs e)
        {
            
            if (tBoxPassword.Text == "Password" && tBoxPassword.ForeColor == Color.DarkGray)
            {
                tBoxPassword.Text = "";
                tBoxPassword.ForeColor = Color.LightGray;
                if (cBoxShowPass.Checked == false)
                {
                    tBoxPassword.UseSystemPasswordChar = true;
                }
                
            }
        }

        private void tBoxPassword_Leave(object sender, EventArgs e)
        {
            if (tBoxPassword.Text == "")
            {
                tBoxPassword.Text = "Password";
                tBoxPassword.ForeColor = Color.DarkGray;                
                tBoxPassword.UseSystemPasswordChar = false;
            }
        }

        private void cBoxShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxShowPass.Checked == false && ((tBoxPassword.Text=="Password"&&tBoxPassword.ForeColor==Color.DarkGray) ==false))
            {                
                tBoxPassword.UseSystemPasswordChar = true;
            }
            else tBoxPassword.UseSystemPasswordChar = false;
        }

        private void ptBoxClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void ptBoxMinimize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal) 
            {
                WindowState = FormWindowState.Minimized;
            }
        }

    }
}
