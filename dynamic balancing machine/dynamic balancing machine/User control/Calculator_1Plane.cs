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
    public partial class Calculator_1Plane : UserControl
    {
        public Calculator_1Plane()
        {
            InitializeComponent();
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            new Step_class().Forward(ParentForm, "step3", "step4", "Result_1Plane", "StepProcess");            
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            new Step_class().Back(ParentForm, "step3", "step2", "DataAcquisition", "StepProcess");
        }
    }
}
