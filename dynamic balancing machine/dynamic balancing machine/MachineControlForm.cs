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
using dynamic_balancing_machine.User_control;
using dynamic_balancing_machine.Step;


namespace dynamic_balancing_machine
{
    
    public partial class MachineControlForm : Form
    {
        //int Mode;

        public MachineControlForm()
        {
            InitializeComponent();

           
            PanelProcess.Controls.Add(new Main());
            PanelProcess.Controls.Add(new DataAcquisition());
            PanelProcess.Controls.Add(new Calculator_1Plane());
            PanelProcess.Controls.Add(new Result_1Plane());
            PanelProcess.Controls.Add(new Calculator_2Plane());
            PanelProcess.Controls.Add(new Result_2Plane());


            //PanelProcess.Controls.Add(new Calculator_2Plane());
            //Form

            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            

        }
        private void MachineControlForm_Load(object sender, EventArgs e)
        {
           this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 28, 28));
            
        }
        //Radius form
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

        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void MachineControlForm_MouseDown(object sender, MouseEventArgs e)
        {
            this.Opacity = 0.92;
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
            this.Opacity = 1;
        }     
                
        private void MoveSidePanel(Control c)
        {
            pnlNav.Height = c.Height;
            pnlNav.Top = c.Top;
            pnlNav.Left = c.Left;
            //c.BackColor = Color.FromArgb(35, 51, 69);

        }
        private void button_leave(Control c)
        {
            c.BackColor = Color.FromArgb(37, 40, 53);

        }
        private void btnHome_Click(object sender, EventArgs e)
        {
            MoveSidePanel(btnHome);
        }                
        
        private void btnExit_Click(object sender, EventArgs e)
        {
            MoveSidePanel(btnExit);
            Application.Exit();
        }
        
        private void btnLogout_Click(object sender, EventArgs e)
        {
            MoveSidePanel(btnLogout);
            this.Close();
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
       
        //Close, maximize, minimize

        private void ptBoxClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        private void ptBoxMinimize_Click_1(object sender, EventArgs e)
        {
            if (WindowState != FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Minimized;
            }
        }
        
        private void ptBoxMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                
                WindowState = FormWindowState.Maximized;
                ptBoxMaximize.Image = Properties.Resources.restore;
                this.Region = new Region(new Rectangle(0, 0, Width, Height));
                Invalidate();

            }
            else
            {
                WindowState = FormWindowState.Normal;
                ptBoxMaximize.Image = Properties.Resources.maximize;
                this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 28, 28));
                Invalidate();
            }
        }

        private void pnlTitle_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);            
        }
        
    }
}
