﻿using System;
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
    public partial class Step4 : UserControl
    {
        public Step4()
        {
            InitializeComponent();
        }


        private void FinishButton_Click_1(object sender, EventArgs e)
        {
            new Step_class().Finish(ParentForm, "step4", "Step4", "StepProcess");
        }

        private void BackButton_Click_1(object sender, EventArgs e)
        {
            new Step_class().Back(ParentForm, "step4", "step3", "Step3", "StepProcess");
        }
    }
}
