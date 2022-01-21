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
    public partial class Result_1Plane : UserControl
    {
        int Mode;
        public int MyText
        {
            get { return Mode; }
            set { Mode = value; } 
        }

        public Result_1Plane()
        {
            InitializeComponent();
            this.pnl1.SuspendLayout();
            this.pnl1.Controls.Add(this.pnlResult_1P);         
            this.pnl1.Size = new System.Drawing.Size(320, 320);
            this.pnl1.TabIndex = 20;
            

            this.pnlResult_1P.BackColor = System.Drawing.Color.Transparent;            
            this.pnlResult_1P.Size = new System.Drawing.Size(260, 260);
            this.pnlResult_1P.TabIndex = 3;
            
        }
        private void Result_1Plane_Paint(object sender, PaintEventArgs e)
        {
            draw();
        }

        private void Step3_Load(object sender, EventArgs e)
        {
            
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            // transfer data Mode từ UserControl.Step1
            //TextBox textBox = (TextBox)ParentForm.Controls.Find("PanelProcess", false)[0].Controls.Find("Step1", false)[0].Controls.Find("txtMode", false)[0];
            new Step_class().Back(ParentForm, "step4", "step3", "Calculator_1Plane", "StepProcess");

        }
               

        private void draw() 
        {
            Graphics f = pnl1.CreateGraphics();
            Graphics g = pnlResult_1P.CreateGraphics();

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

            // point in the circle
            //int R = 119, x_0 = 125, y_0 = 125, x, y;
            //double beta_1, beta_2;
            //beta_1 = goc_mcb * 180 / Math.PI;
            //beta_2 = 180 + goc_mcb * 180 / Math.PI;

            //x = x_0 + Convert.ToInt32(R * Math.Sin(Math.PI - anpha * Math.PI / 180)) - 7;
            //y = y_0 + Convert.ToInt32(R * Math.Cos(Math.PI - anpha * Math.PI / 180)) - 7;
            //g.FillEllipse(brRed, x, y, 14, 14);

            //x = x_0 + Convert.ToInt32(R * Math.Sin(Math.PI - beta_1 * Math.PI / 180)) - 6;
            //y = y_0 + Convert.ToInt32(R * Math.Cos(Math.PI - beta_1 * Math.PI / 180)) - 6;
            //g.FillEllipse(brRed, x, y, 12, 12);

            //x = x_0 + Convert.ToInt32(R * Math.Sin(Math.PI + beta_2 * Math.PI / 180)) - 6;
            //y = y_0 + Convert.ToInt32(R * Math.Cos(Math.PI + beta_2 * Math.PI / 180)) - 6;
            //g.FillEllipse(brBlue, x, y, 12, 12);

            //****************************** Label Result *************************//

            //lbResult0_R1.Text = lbResult0_M0.Text;
            //lbResult1_R1.Text = lbResult1_M0.Text;
            //lbResult2_R1.Text = lbResult2_M0.Text;

            //******************************** Dispose ***************************//
            f.Dispose();
            g.Dispose();
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
