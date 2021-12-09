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
    public partial class Step2 : UserControl
    {
        public Step2()
        {
            InitializeComponent();
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            new Step_class().Forward(ParentForm, "step2", "step3", "Step3", "StepProcess");            
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            new Step_class().Back(ParentForm, "step2", "step1", "Step1", "StepProcess");
        }
    }
}
