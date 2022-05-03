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
using Excel = Microsoft.Office.Interop.Excel;

namespace dynamic_balancing_machine.User_control
{
    public partial class Result_1Plane : UserControl
    {


        /*public int MyText
        {
            get { return Mode; }
            set { Mode = value; } 
        }*/
        int stt=1;
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
        double anpha_x, anpha_y;
        private void Result_1Plane_Load(object sender, EventArgs e)
        {          

            

        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            // transfer data Mode từ UserControl.Step1
            
            new Step_class().Back(ParentForm, "step4", "step3", "Calculator_1Plane", "StepProcess");

        }
        double Am_mcb, goc_mcb;
        private void btnRun_Click(object sender, EventArgs e)
        {            
            try
            {
                double A_anpha, goc_anpha, V, PhiV, Re_Am, Im_Am;
                
                TextBox AmAverage = new Step_class().TextBox1(ParentForm, "txtAmAverage_P1", "panel7", "DataAcquisition");
                TextBox Dolechpha = new Step_class().TextBox1(ParentForm, "txtDolechpha_P1", "panel7", "DataAcquisition");
                txtAm.Text = AmAverage.Text;
                txtPhase.Text = Dolechpha.Text;

                TextBox txtPhizero = new Step_class().TextBox1(ParentForm, "Phizero", "panel4", "Calculator_1Plane");
                TextBox txtPhi1 = new Step_class().TextBox1(ParentForm, "Phi1", "panel4", "Calculator_1Plane");
                TextBox Anphax = new Step_class().TextBox1(ParentForm, "Anpha_x", "panel4", "Calculator_1Plane");
                TextBox Anphay = new Step_class().TextBox1(ParentForm, "Anpha_y", "panel4", "Calculator_1Plane");
                lblAnpha_x.Text = Anphax.Text;
                lblAnpha_y.Text = Anphay.Text;
                anpha_x = double.Parse(lblAnpha_x.Text);
                anpha_y = double.Parse(lblAnpha_y.Text);
                A_anpha = Math.Sqrt(anpha_x * anpha_x + anpha_y * anpha_y);
                goc_anpha = Math.Atan2(anpha_y, anpha_x);

                V = double.Parse(txtAm.Text);
                if ((double.Parse(txtPhi1.Text) - double.Parse(txtPhizero.Text)) < 0)
                {
                    PhiV = double.Parse(txtPhase.Text) - double.Parse(txtPhizero.Text);
                }
                else
                {
                    PhiV = double.Parse(txtPhizero.Text) - double.Parse(txtPhase.Text);
                }
                PhiV = PhiV * Math.PI / 180;

                Re_Am = (V / A_anpha) * Math.Cos(PhiV - goc_anpha);
                Im_Am = (V / A_anpha) * Math.Sin(PhiV - goc_anpha);


                Am_mcb = Math.Sqrt(Re_Am * Re_Am + Im_Am * Im_Am);
                goc_mcb = Math.Atan2(Im_Am, Re_Am);

                txtM.Text = Am_mcb.ToString("f2");
                txtPhiM.Text = (goc_mcb * 180 / Math.PI).ToString("f2");
                txtPhiM_add.Text = (180 + goc_mcb * 180 / Math.PI).ToString("f2");

                draw_result(goc_mcb);

                //ListView

                ListViewItem item1 = new ListViewItem();
                item1.Text = stt.ToString();
                ListViewDatabase.Items.Add(item1);
                item1.SubItems.Add(txtM.Text);
                item1.SubItems.Add(txtPhiM.Text);
                item1.SubItems.Add(txtPhiM_add.Text);
                //ListViewDatabase.Items.AddRange(new ListViewItem[] { item1 });
                stt++;
            }
            catch { MessageBox.Show("Please data collection"); }
        }

        private void btnDiagnostic_Click(object sender, EventArgs e)
        {           
            try
            {
                TextBox txtAm = new Step_class().TextBox(ParentForm, "txtAm", "Calculator_1Plane");
                Am_mcb = double.Parse(txtAm.Text);
                TextBox txtGoc = new Step_class().TextBox(ParentForm, "txtGoc", "Calculator_1Plane");
                goc_mcb = double.Parse(txtGoc.Text);

                txtM.Text = Am_mcb.ToString("f2");
                txtPhiM.Text = (goc_mcb * 180 / Math.PI).ToString("f2");
                txtPhiM_add.Text = (180 + goc_mcb * 180 / Math.PI).ToString("f2");

                draw_result(goc_mcb);
            }
            catch { MessageBox.Show("Please data collection"); }
            
        }

        private void FinishButton_Click(object sender, EventArgs e)
        {

        }

        private void btnSaveDatabase_Click(object sender, EventArgs e)
        {
            if(btnSaveDatabase.Text == "Database")
            {
                ListViewDatabase.Visible = true;
                ListViewDatabase.Location = new Point(330, 62);
                btnSaveDatabase.Text = "Save Database";
                btnReturn.Visible = true;
                //ListViewDatabase.Items.Clear();


            }
            else if (btnSaveDatabase.Text == "Save Database")
            {
                DialogResult dl = MessageBox.Show("Are you sure you want to save the data?", "Notify", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dl == DialogResult.Yes)
                    SaveExcel_function(ListViewDatabase);                
                                
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            btnSaveDatabase.Text = "Database";
            ListViewDatabase.Visible = false;
            btnReturn.Visible = false;
            draw(); draw_result(goc_mcb);
        }
        

        static void SaveExcel_function(ListView dataTable)
        {
            // save item
            SaveFileDialog fsave = new SaveFileDialog();
            fsave.Filter = "Excel Workbook|*.xlsx";
            fsave.ShowDialog();
            // process
            if (fsave.FileName != "")
            {
                // create excel app
                Excel.Application app = new Excel.Application();
                // create 1 workbook
                Excel.Workbook wb = app.Workbooks.Add(Type.Missing);
                // create sheet
                Excel._Worksheet sheet = null;
                try
                {
                    // read data from ListView export excel file 
                    sheet = wb.ActiveSheet;
                    sheet.Name = "data1";
                    sheet.Range[sheet.Cells[1, 1], sheet.Cells[1, dataTable.Columns.Count]].Merge();
                    sheet.Cells[1, 1].Value = "Database of balance 1 Plane";
                    sheet.Cells[1, 1].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    sheet.Cells[1, 1].Font.Size = 20;
                    sheet.Cells[1, 1].Borders.Weight = Excel.XlBorderWeight.xlThin;
                    // title
                    for (int i = 1; i <= dataTable.Columns.Count; i++)
                    {
                        sheet.Cells[2, i] = dataTable.Columns[i - 1].Text;
                        sheet.Cells[2, i].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        sheet.Cells[2, i].Font.Bold = true;
                        sheet.Cells[2, i].Borders.Weight = Excel.XlBorderWeight.xlThin;
                    }
                    // create data
                    for (int i = 1; i <= dataTable.Items.Count; i++)
                    {
                        ListViewItem item = dataTable.Items[i - 1];
                        sheet.Cells[i + 2, 1] = item.Text;
                        sheet.Cells[i + 2, 1].Borders.Weight = Excel.XlBorderWeight.xlThin;
                        for (int j = 2; j <= dataTable.Columns.Count; j++)
                        {
                            sheet.Cells[i + 2, j] = item.SubItems[j - 1].Text;
                            sheet.Cells[i + 2, j].Borders.Weight = Excel.XlBorderWeight.xlThin;
                        }
                    }
                    // save
                    wb.SaveAs(fsave.FileName);
                    MessageBox.Show("Sucess!", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                finally
                {
                    app.Quit();
                    wb = null;
                }
            }
            else
            {
            }

        }

        private void draw_result(double PhiB)
        {            
            int R = 125, x_0 = 130, y_0 = 130, x, y;
            double beta_1, beta_2;
            beta_1 = PhiB * 180 / Math.PI;
            beta_2 = 180 + PhiB * 180 / Math.PI;
            Graphics g = pnlResult_1P.CreateGraphics();

            SolidBrush brRed = new SolidBrush(Color.Red);
            x = x_0 + Convert.ToInt32(R * Math.Sin(Math.PI - beta_1 * Math.PI / 180)) - 5;
            y = y_0 + Convert.ToInt32(R * Math.Cos(Math.PI - beta_1 * Math.PI / 180)) - 5;
            g.FillEllipse(brRed, x, y, 10, 10);

            x = x_0 + Convert.ToInt32(R * Math.Sin(Math.PI + beta_2 * Math.PI / 180)) - 5;
            y = y_0 + Convert.ToInt32(R * Math.Cos(Math.PI + beta_2 * Math.PI / 180)) - 5;
            

            g.Dispose();            
            brRed.Dispose();
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
            //SolidBrush drawBrush = new SolidBrush(Color.Black);

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
