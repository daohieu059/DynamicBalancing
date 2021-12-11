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
        public void Finish(Form ParentForm, string currentImageBox, string nextPageName, string progressbar)
        {
            // resolve images
            PictureBox currentPictureBox = (PictureBox)ParentForm.Controls.Find(currentImageBox, false)[0];
            currentPictureBox.Image = Properties.Resources.Complete_check;

            // resolve pages
            ParentForm.Controls.Find("PanelProcess", false)[0].Controls.Find(nextPageName, false)[0].BringToFront();

            ProgressBar progressbar1 = (ProgressBar)ParentForm.Controls.Find(progressbar, false)[0];
            progressbar1.Value = 100;
        }
        public TextBox Transfer(Form ParentForm, string txtBox, string Pagename)
        {
            TextBox textBox = (TextBox)ParentForm.Controls.Find("PanelProcess", false)[0].Controls.Find(Pagename, false)[0].Controls.Find(txtBox, false)[0];
            return textBox;
        }
        public void findUser(Form ParentForm, string txtBox, string Pagename)
        {
            UserControl userControl = (UserControl)ParentForm.Controls.Find("PanelProcess", false)[0].Controls.Find(Pagename, false)[0];
        }
    }
}
