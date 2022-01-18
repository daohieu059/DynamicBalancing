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
    public partial class Result_1Plane : UserControl
    {
        int Mode;
        public int MyText
        {
            get { return Mode; }
            set { Mode = value; } 
        }

        public Result_1Plane()
        {
            InitializeComponent();
            
        }
        
        private void Step3_Load(object sender, EventArgs e)
        {

        }

        

        private void BackButton_Click(object sender, EventArgs e)
        {
            // transfer data Mode từ UserControl.Step1
            //TextBox textBox = (TextBox)ParentForm.Controls.Find("PanelProcess", false)[0].Controls.Find("Step1", false)[0].Controls.Find("txtMode", false)[0];
            new Step_class().Back(ParentForm, "step4", "step3", "Calculator_1Plane", "StepProcess");
                        
        }
    }
}
