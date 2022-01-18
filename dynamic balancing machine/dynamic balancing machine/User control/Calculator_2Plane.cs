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
    public partial class Calculator_2Plane : UserControl
    {
        public Calculator_2Plane()
        {
            InitializeComponent();
        }

        private void BackButton_Click_1(object sender, EventArgs e)
        {
            new Step_class().Back(ParentForm, "step3", "step2", "DataAcquisition", "StepProcess");
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            new Step_class().Forward(ParentForm, "step3", "step4", "Result_2Plane", "StepProcess");
        }
    }
}