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
    public partial class DataAcquisition : UserControl
    {
        int Mode;
        public DataAcquisition()
        {
            InitializeComponent();            
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            TextBox textBox = new Step_class().TextBox(ParentForm, "txtMode", "Main");
            Mode = int.Parse(textBox.Text);
            if (Mode ==1)
            {
                new Step_class().Forward(ParentForm, "step2", "step3", "Calculator_1Plane", "StepProcess");
            }    
            else if (Mode==2)
            {
                new Step_class().Forward(ParentForm, "step2", "step3", "Calculator_2Plane", "StepProcess");
            }    
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            new Step_class().Back(ParentForm, "step2", "step1", "Main", "StepProcess");
        }
    }
}
