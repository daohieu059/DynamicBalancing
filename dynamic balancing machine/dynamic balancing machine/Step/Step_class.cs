using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dynamic_balancing_machine.Step
{

    class Step_class
    {
        public Control S { get; private set; }

        public void Back(Form ParentForm, string currentImageBox, string previousImageBox, string previousPageName, string progressbar)
        {
            // resolve images
            PictureBox currentPictureBox = (PictureBox)ParentForm.Controls.Find(currentImageBox, false)[0];
            currentPictureBox.Image = Properties.Resources.Pending;

            PictureBox previousPictureBox = (PictureBox)ParentForm.Controls.Find(previousImageBox, false)[0];
            previousPictureBox.Image = Properties.Resources.Current;

            // resolve pages
            ParentForm.Controls.Find("PanelProcess", false)[0].Controls.Find(previousPageName, false)[0].BringToFront();

            ProgressBar progressbar1 = (ProgressBar)ParentForm.Controls.Find(progressbar, false)[0];
            progressbar1.Value -= 33;
        }

        public void Forward(Form ParentForm, string currentImageBox, string nextImageBox, string nextPageName, string progressbar)
        {
            // resolve images 
            PictureBox currentPictureBox = (PictureBox)ParentForm.Controls.Find(currentImageBox, false)[0];
            currentPictureBox.Image = Properties.Resources.Complete_check;

            PictureBox nextPictureBox = (PictureBox)ParentForm.Controls.Find(nextImageBox, false)[0];
            nextPictureBox.Image = Properties.Resources.Current;

            // resolve pages
            ParentForm.Controls.Find("PanelProcess", false)[0].Controls.Find(nextPageName, false)[0].BringToFront();

            ProgressBar progressbar1 = (ProgressBar)ParentForm.Controls.Find(progressbar, false)[0];
            progressbar1.Value += 33;
        }
        public void Finish(Form ParentForm, string step1, string step2, string step3, string step4, string main, string progressbar)
        {
            // resolve images
            PictureBox step_1 = (PictureBox)ParentForm.Controls.Find(step1, false)[0];
            step_1.Image = Properties.Resources.Current;
            PictureBox step_2 = (PictureBox)ParentForm.Controls.Find(step2, false)[0];
            step_2.Image = Properties.Resources.Pending;
            PictureBox step_3 = (PictureBox)ParentForm.Controls.Find(step3, false)[0];
            step_3.Image = Properties.Resources.Pending;
            PictureBox step_4 = (PictureBox)ParentForm.Controls.Find(step4, false)[0];
            step_4.Image = Properties.Resources.Pending;

            // resolve pages
            ParentForm.Controls.Find("PanelProcess", false)[0].Controls.Find(main, false)[0].BringToFront();

            ProgressBar progressbar1 = (ProgressBar)ParentForm.Controls.Find(progressbar, false)[0];
            progressbar1.Value = 0;
        }
        public TextBox TextBox(Form ParentForm, string txtBox, string Pagename)
        {
            TextBox textBox = (TextBox)ParentForm.Controls.Find("PanelProcess", false)[0].Controls.Find(Pagename, false)[0].Controls.Find(txtBox, false)[0];
            return textBox;
        }
        public TextBox TextBox1(Form ParentForm, string txt, string pnl, string Pagename)
        {
            TextBox TextBox = (TextBox)ParentForm.Controls.Find("PanelProcess", false)[0].Controls.Find(Pagename, false)[0].Controls.Find(pnl, false)[0].Controls.Find(txt, false)[0];
            return TextBox;
        }
        public Label Label(Form ParentForm,  string lbl, string pnl, string Pagename)
        {
            Label label = (Label)ParentForm.Controls.Find("PanelProcess", false)[0].Controls.Find(Pagename, false)[0].Controls.Find(pnl, false)[0].Controls.Find(lbl, false)[0];
            return label;
        }
        public void findUser(Form ParentForm, string txtBox, string Pagename)
        {
            UserControl userControl = (UserControl)ParentForm.Controls.Find("PanelProcess", false)[0].Controls.Find(Pagename, false)[0];
        }
        
    }
}
