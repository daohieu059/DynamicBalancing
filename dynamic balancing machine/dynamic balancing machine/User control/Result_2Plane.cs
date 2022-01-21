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
    public partial class Result_2Plane : UserControl
    {
        public Result_2Plane()
        {
            InitializeComponent();
            
        }
        private void Result_2Plane_Paint(object sender, PaintEventArgs e)
        {
            draw();
        }

        private void FinishButton_Click_1(object sender, EventArgs e)
        {
            new Step_class().Finish(ParentForm, "step4", "Result_2Plane", "StepProcess");
        }

        private void BackButton_Click_1(object sender, EventArgs e)
        {
            new Step_class().Back(ParentForm, "step4", "step3", "Calculator_2Plane", "StepProcess");
        }        

        private void draw()
        {
            //Plane 1
            Graphics f = pnl1.CreateGraphics();
            Graphics g = pnlResult_P1.CreateGraphics();

            Pen pen2 = new Pen(Color.FromArgb(237, 216, 8), 2.5f);
            Pen pen1 = new Pen(Color.FromArgb(237, 216, 8), 1.5f);
            pen1.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

            SolidBrush br = new SolidBrush(Color.Transparent);
            SolidBrush brRed = new SolidBrush(Color.Red);
            SolidBrush brBlue = new SolidBrush(Color.Blue);
            SolidBrush brGreen = new SolidBrush(Color.Green);
            SolidBrush brWhite = new SolidBrush(Color.White);
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            // Create string to draw.
            String string1 = "0", string2 = "90", string3 = "180", string4 = "270";
            // Create font and brush.
            //Font drawFont = new Font("Arial", 9);
            Font drawFont = new Font("Arial", 10, FontStyle.Bold);
            // Create point for upper-left corner of drawing.
            PointF drawPoint1 = new PointF(155.0F, 10.0F);
            PointF drawPoint2 = new PointF(292.0F, 152.0F);
            PointF drawPoint3 = new PointF(148.0F, 295.0F);
            PointF drawPoint4 = new PointF(5F, 152.0F);
            // Draw string to screen.
            f.DrawString(string1, drawFont, brWhite, drawPoint1);
            f.DrawString(string2, drawFont, brWhite, drawPoint2);
            f.DrawString(string3, drawFont, brWhite, drawPoint3);
            f.DrawString(string4, drawFont, brWhite, drawPoint4);


            g.FillRectangle(br, 0, 0, 260, 260); // re fill - clear pannel
            // draw circle
            g.DrawEllipse(pen2, 5, 5, 250, 250);
            g.DrawEllipse(pen1, 30, 30, 200, 200);
            g.DrawEllipse(pen1, 55, 55, 150, 150);
            g.DrawEllipse(pen1, 80, 80, 100, 100);
            g.DrawEllipse(pen1, 105, 105, 50, 50);
            // draw border

            g.DrawLine(pen1, new Point(130, 5), new Point(130, 255));
            g.DrawLine(pen1, new Point(5, 130), new Point(255, 130));
            g.DrawLine(pen1, new Point(41, 41), new Point(219, 219));
            g.DrawLine(pen1, new Point(41, 219), new Point(219, 41));

            
            //Plane 2
            Graphics f1 = pnl2.CreateGraphics();
            Graphics g1 = pnlResult_P2.CreateGraphics();                 
            
            // Draw string to screen.
            f1.DrawString(string1, drawFont, brWhite, drawPoint1);
            f1.DrawString(string2, drawFont, brWhite, drawPoint2);
            f1.DrawString(string3, drawFont, brWhite, drawPoint3);
            f1.DrawString(string4, drawFont, brWhite, drawPoint4);


            g1.FillRectangle(br, 0, 0, 260, 260); // re fill - clear pannel
            // draw circle
            g1.DrawEllipse(pen2, 5, 5, 250, 250);
            g1.DrawEllipse(pen1, 30, 30, 200, 200);
            g1.DrawEllipse(pen1, 55, 55, 150, 150);
            g1.DrawEllipse(pen1, 80, 80, 100, 100);
            g1.DrawEllipse(pen1, 105, 105, 50, 50);
            // draw border

            g1.DrawLine(pen1, new Point(130, 5), new Point(130, 255));
            g1.DrawLine(pen1, new Point(5, 130), new Point(255, 130));
            g1.DrawLine(pen1, new Point(41, 41), new Point(219, 219));
            g1.DrawLine(pen1, new Point(41, 219), new Point(219, 41));



            //******************************** Dispose ***************************//
            f.Dispose();
            g.Dispose();
            f1.Dispose();
            g1.Dispose();
            pen1.Dispose();
            pen2.Dispose();
            br.Dispose();
            brRed.Dispose();
            brBlue.Dispose();
            brGreen.Dispose();
            brWhite.Dispose();
            //*************************** End simulation drawing ***************************//        
        }

        
    }
}
