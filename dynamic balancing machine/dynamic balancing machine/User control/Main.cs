using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dynamic_balancing_machine.Step;


namespace dynamic_balancing_machine.User_control
{
    
    public partial class Main : UserControl
    {
        int Mode;
        public int MyText
        {
            get { return int.Parse(this.txtMode.Text); } 
        }
        public Main()
        {
            InitializeComponent();
        }
        

        private void NextButton_Click(object sender, EventArgs e)
        {
            
            
            if ((Mode != 1)&(Mode != 2))
            {
                labelWarn.Visible = false;
                labelWarn.Text = "   "+"Vui lòng chọn chế độ cân bằng";
                labelWarn.ForeColor = Color.LightGray;
                labelWarn.Visible = true;
                                
            }  
            else
            {
                new Step_class().Forward(ParentForm, "step1", "step2", "DataAcquisition", "StepProcess");
                labelWarn.Visible = false;
            }


        }
        private PictureBox SetImage(string containerName)
        {
            return (PictureBox)ParentForm.Controls.Find(containerName, true)[0];
        }


        private void btn1Plane_Click(object sender, EventArgs e)
        {
            Mode = 1;
            btn1Plane.BackColor = Color.FromArgb(111, 190, 214);
            btn2Plane.BackColor = Color.FromArgb(37, 42, 64);
            txtMode.Text = Mode.ToString();
            txtMode.Visible = true;
        }

        private void btn2Plane_Click(object sender, EventArgs e)
        {
            Mode = 2;
            btn1Plane.BackColor = Color.FromArgb(37, 42, 64);
            btn2Plane.BackColor = Color.FromArgb(111, 190, 214);
            txtMode.Text = Mode.ToString();
            txtMode.Visible = true;
        }

    }
}
