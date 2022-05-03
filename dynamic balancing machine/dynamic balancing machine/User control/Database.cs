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
    
    public partial class Database : UserControl
    {
        int mode;
        public Database()
        {
            InitializeComponent();
        }

        private void Database_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            mode = 2;
            txtMode.Text = mode.ToString();
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            new Step_class().Forward(ParentForm, "step1", "step2", "DataAcquisition", "StepProcess");
        }
    }
}
