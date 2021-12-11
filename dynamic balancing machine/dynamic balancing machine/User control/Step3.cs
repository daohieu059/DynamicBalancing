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
    public partial class Step3 : UserControl
    {
        int Mode;
        public int MyText
        {
            get { return Mode; }
            set { Mode = value; } 
        }

        public Step3()
        {
            InitializeComponent();
            
        }
        
        private void Step3_Load(object sender, EventArgs e)
        {

        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            new Step_class().Forward(ParentForm, "step3", "step4", "Step4", "StepProcess");
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            // transfer data Mode từ UserControl.Step1
            //TextBox textBox = (TextBox)ParentForm.Controls.Find("PanelProcess", false)[0].Controls.Find("Step1", false)[0].Controls.Find("txtMode", false)[0];
            TextBox textBox = new Step_class().TextBox(ParentForm, "txtMode", "Step1");
            Mode = int.Parse(textBox.Text);
            if (Mode ==1)            
            {
                new Step_class().Back(ParentForm, "step3", "step2", "Step2", "StepProcess");
            }
            else if (Mode == 2)
            {
                new Step_class().Back(ParentForm, "step3", "step2", "DataAcquisition2", "StepProcess");
            }
            
            
        }
    }
}
