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


namespace dynamic_balancing_machine
{
    public partial class MachineControlForm : Form
    {
        
        public MachineControlForm()
        {
            InitializeComponent();
            

            PanelProcess.Controls.Add(new Step1());
            PanelProcess.Controls.Add(new Step2());
            PanelProcess.Controls.Add(new Step3());
            PanelProcess.Controls.Add(new Step4());
            PanelProcess.Controls.Add(new DataAcquisition2());
            //Form
            
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;


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
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void MachineControlForm_Load(object sender, EventArgs e)
        {
            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 28, 28));
            pnlNav.Height = btnExit.Height;
            pnlNav.Top = btnExit.Top;
            pnlNav.Left = btnExit.Left;
            btnExit.BackColor = Color.FromArgb(35, 51, 69);          

        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnHome.Height;
            pnlNav.Top = btnHome.Top;
            pnlNav.Left = btnHome.Left;
            btnHome.BackColor = Color.FromArgb(35, 51, 69);
        }
                
        private void btnHome_Leave(object sender, EventArgs e)
        {
            btnHome.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnExit.Height;
            pnlNav.Top = btnExit.Top;
            pnlNav.Left = btnExit.Left;
            btnExit.BackColor = Color.FromArgb(35, 51, 69);
            Application.Exit();
        }

        private void btnExit_Leave(object sender, EventArgs e)
        {
            btnExit.BackColor = Color.FromArgb(24, 30, 54);
        }

        //Close, maximize, minimize

        private void ptBoxClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        private void ptBoxMinimize_Click_1(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
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
    }
}
