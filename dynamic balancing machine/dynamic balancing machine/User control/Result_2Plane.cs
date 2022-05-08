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
    public partial class Result_2Plane : UserControl
    {
        int stt = 1;
        public Result_2Plane()
        {
            InitializeComponent();
            
        }
        private void Result_2Plane_Paint(object sender, PaintEventArgs e)
        {
            draw();
        }

        double AnPha11, PhiAnPha11;
        double AnPha12, PhiAnPha12;
        double AnPha21, PhiAnPha21;
        double AnPha22, PhiAnPha22;
        double Am_det, Phi_det;
        

        private void Result_2Plane_Load(object sender, EventArgs e)
        {            
                        
        }

        private void FinishButton_Click(object sender, EventArgs e)
        {
            new Step_class().Finish(ParentForm, "step1", "step2", "step3", "step4", "Main", "StepProcess");
            stt = 1;
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            new Step_class().Back(ParentForm, "step4", "step3", "Calculator_2Plane", "StepProcess");
        }

        private void btnGetdata_Click(object sender, EventArgs e)
        {
            ParentForm.Controls.Find("PanelProcess", false)[0].Controls.Find("DataAcquisition", false)[0].BringToFront();
            Button next = (Button)ParentForm.Controls.Find("PanelProcess", false)[0].Controls.Find("DataAcquisition", false)[0].Controls.Find("NextButton", false)[0];
            Button back = (Button)ParentForm.Controls.Find("PanelProcess", false)[0].Controls.Find("DataAcquisition", false)[0].Controls.Find("BackButton", false)[0];
            Button re = (Button)ParentForm.Controls.Find("PanelProcess", false)[0].Controls.Find("DataAcquisition", false)[0].Controls.Find("btnReturnStep4", false)[0];
            next.Visible = false;
            back.Visible = false;
            re.Visible = true;

        }

        double B1, PhiB1;
        double B2, PhiB2;
        // vị trí mất cân bằng calib
        private void btnDiagnostic_Click(object sender, EventArgs e)
        {
            try
            {
                //hien thi ket qua mat 1
                TextBox txtV1 = new Step_class().TextBox(ParentForm, "txtV1", "Calculator_2Plane");
                B1 = double.Parse(txtV1.Text);

                TextBox txtPhiV1 = new Step_class().TextBox(ParentForm, "txtPhiV1", "Calculator_2Plane");
                PhiB1 = double.Parse(txtPhiV1.Text);

                txtM1.Text = B1.ToString("f2");
                txtPhiM1.Text = (PhiB1 * 180 / Math.PI).ToString("f2");
                txtPhiM1_add.Text = (180 + PhiB1 * 180 / Math.PI).ToString("f2");

                //hien thi ket qua mat 2
                TextBox txtV2 = new Step_class().TextBox(ParentForm, "txtV2", "Calculator_2Plane");
                B2 = double.Parse(txtV1.Text);

                TextBox txtPhiV2 = new Step_class().TextBox(ParentForm, "txtPhiV2", "Calculator_2Plane");
                PhiB2 = double.Parse(txtPhiV2.Text);

                txtM2.Text = B2.ToString("f2");
                txtPhiM2.Text = (PhiB2 * 180 / Math.PI).ToString("f2");
                txtPhiM2_add.Text = (180 + PhiB2 * 180 / Math.PI).ToString("f2");

                //draw point
                draw_result(PhiB1, PhiB2);
            }
            catch { MessageBox.Show("Please data collection"); }            
        }

        // vị trí mất cân bằng test lại        
        private void btnRun_Click(object sender, EventArgs e)
        {
            try
            {
                double V1_2P, Phi1_2P, V2_2P, Phi2_2P;
                
                TextBox AmAverage1 = new Step_class().TextBox1(ParentForm, "txtAmAverage_P1", "panel7", "DataAcquisition");
                TextBox Dolechpha1 = new Step_class().TextBox1(ParentForm, "txtDolechpha_P1", "panel7", "DataAcquisition");
                TextBox AmAverage2 = new Step_class().TextBox1(ParentForm, "txtAmAverage_P2_2P", "panel7", "DataAcquisition");
                TextBox Dolechpha2 = new Step_class().TextBox1(ParentForm, "txtDolechpha_P2_2P", "panel7", "DataAcquisition");
                txtAm1.Text = AmAverage1.Text;
                txtAm2.Text = AmAverage2.Text;
                txtPhase1.Text = Dolechpha1.Text;
                txtPhase2.Text = Dolechpha2.Text;

                TextBox Phizero_1 = new Step_class().TextBox1(ParentForm, "Phizero_1", "panel4", "Calculator_2Plane");
                TextBox Phizero_2 = new Step_class().TextBox1(ParentForm, "Phizero_2", "panel4", "Calculator_2Plane");
                TextBox Phi_10 = new Step_class().TextBox1(ParentForm, "Phi_V10", "panel4", "Calculator_2Plane");
                TextBox Phi_20 = new Step_class().TextBox1(ParentForm, "Phi_V20", "panel4", "Calculator_2Plane");

                TextBox Anpha_11 = new Step_class().TextBox1(ParentForm, "Anpha_11", "panel4", "Calculator_2Plane");
                TextBox Anpha_12 = new Step_class().TextBox1(ParentForm, "Anpha_12", "panel4", "Calculator_2Plane");
                TextBox Anpha_21 = new Step_class().TextBox1(ParentForm, "Anpha_21", "panel4", "Calculator_2Plane");
                TextBox Anpha_22 = new Step_class().TextBox1(ParentForm, "Anpha_22", "panel4", "Calculator_2Plane");
                TextBox PhiAn_11 = new Step_class().TextBox1(ParentForm, "PhiAn_11", "panel4", "Calculator_2Plane");
                TextBox PhiAn_12 = new Step_class().TextBox1(ParentForm, "PhiAn_12", "panel4", "Calculator_2Plane");
                TextBox PhiAn_21 = new Step_class().TextBox1(ParentForm, "PhiAn_21", "panel4", "Calculator_2Plane");
                TextBox PhiAn_22 = new Step_class().TextBox1(ParentForm, "PhiAn_22", "panel4", "Calculator_2Plane");
                TextBox A_detload = new Step_class().TextBox1(ParentForm, "A_detload", "panel4", "Calculator_2Plane");
                TextBox Phi_detload = new Step_class().TextBox1(ParentForm, "Phi_detload", "panel4", "Calculator_2Plane");
                AnPha11 = double.Parse(Anpha_11.Text);
                AnPha12 = double.Parse(Anpha_12.Text);
                AnPha21 = double.Parse(Anpha_21.Text);
                AnPha22 = double.Parse(Anpha_22.Text);
                PhiAnPha11 = double.Parse(PhiAn_11.Text);
                PhiAnPha12 = double.Parse(PhiAn_12.Text);
                PhiAnPha21 = double.Parse(PhiAn_21.Text);
                PhiAnPha22 = double.Parse(PhiAn_22.Text);
                Am_det = double.Parse(A_detload.Text);
                Phi_det = double.Parse(Phi_detload.Text);

                lblAnpha_11.Text = AnPha11.ToString("0.000") + " < " + (PhiAnPha11 * 180 / Math.PI).ToString("0.000");
                lblAnpha_12.Text = AnPha12.ToString("0.000") + " < " + (PhiAnPha12 * 180 / Math.PI).ToString("0.000");
                lblAnpha_21.Text = AnPha21.ToString("0.000") + " < " + (PhiAnPha21 * 180 / Math.PI).ToString("0.000");
                lblAnpha_22.Text = AnPha22.ToString("0.000") + " < " + (PhiAnPha22 * 180 / Math.PI).ToString("0.000");

                V1_2P = double.Parse(txtAm1.Text);
                V2_2P = double.Parse(txtAm2.Text);
                if ((double.Parse(Phi_10.Text) - double.Parse(Phizero_1.Text)) < 0)
                {
                    Phi1_2P = double.Parse(txtPhase1.Text) - double.Parse(Phizero_1.Text);
                }
                else
                {
                    Phi1_2P = double.Parse(Phizero_1.Text) - double.Parse(txtPhase1.Text);
                }
                if ((double.Parse(Phi_20.Text) - double.Parse(Phizero_2.Text)) < 0)
                {
                    Phi2_2P = double.Parse(txtPhase2.Text) - double.Parse(Phizero_2.Text);
                }
                else
                {
                    Phi2_2P = double.Parse(Phizero_2.Text) - double.Parse(txtPhase2.Text);
                }
                Phi1_2P = Phi1_2P * Math.PI / 180;
                Phi2_2P = Phi2_2P * Math.PI / 180;

                // tính lượng mất cân bằng B1
                List<double> balance1 = new List<double>();
                balance1 = Calcualtor_Mcb2P_B1(AnPha12, PhiAnPha12, AnPha22, PhiAnPha22, Am_det, Phi_det, V1_2P, Phi1_2P, V2_2P, Phi2_2P);
                B1 = balance1[0];
                PhiB1 = balance1[1];

                /*double re1, im1, re2, im2;
                re1 = B1 * Math.Cos(PhiB1) - double.Parse(Am_mcb1.Text) * Math.Cos(double.Parse(phi_mcb1.Text) * Math.PI / 180);
                im1 = B1 * Math.Sin(PhiB1) - double.Parse(Am_mcb1.Text) * Math.Sin(double.Parse(phi_mcb1.Text) * Math.PI / 180);
                B1 = Math.Sqrt(re1 * re1 + im1 * im1);
                PhiB1 = Math.Atan2(im1, re1);*/

                txtM1.Text = B1.ToString("f2");
                txtPhiM1.Text = (PhiB1 * 180 / Math.PI).ToString("f2");
                txtPhiM1_add.Text = (180 + PhiB1 * 180 / Math.PI).ToString("f2");


                // tính lượng mất cân bằng B2
                List<double> balance2 = new List<double>();
                balance2 = Calcualtor_Mcb2P_B2(AnPha11, PhiAnPha11, AnPha21, PhiAnPha21, Am_det, Phi_det, V1_2P, Phi1_2P, V2_2P, Phi2_2P);
                B2 = balance2[0];
                PhiB2 = balance2[1];

                /*re2 = B2 * Math.Cos(PhiB2) - double.Parse(Am_mcb2.Text) * Math.Cos(double.Parse(phi_mcb2.Text) * Math.PI / 180);
                im2 = B2 * Math.Sin(PhiB2) - double.Parse(Am_mcb2.Text) * Math.Sin(double.Parse(phi_mcb2.Text) * Math.PI / 180);
                B2 = Math.Sqrt(re2 * re2 + im2 * im2);
                PhiB2 = Math.Atan2(im2, re2);*/

                txtM2.Text = B2.ToString("f2");
                txtPhiM2.Text = (PhiB2 * 180 / Math.PI).ToString("f2");
                txtPhiM2_add.Text = (180 + PhiB2 * 180 / Math.PI).ToString("f2");

                //draw point
                draw(); draw_result(PhiB1, PhiB2);

                //ListView
                ListViewItem item1 = new ListViewItem();
                item1.Text = stt.ToString();
                ListViewDatabase.Items.Add(item1);
                item1.SubItems.Add(txtM1.Text);
                item1.SubItems.Add(txtPhiM1.Text);
                item1.SubItems.Add(txtPhiM1_add.Text);
                item1.SubItems.Add(txtM2.Text);
                item1.SubItems.Add(txtPhiM2.Text);
                item1.SubItems.Add(txtPhiM2_add.Text);
                stt++;
            }
            catch { MessageBox.Show("Please data collection"); }            
        }

        private void btnSaveDatabase_Click(object sender, EventArgs e)
        {
            if (btnSaveDatabase.Text == "Database")
            {
                ListViewDatabase.Visible = true;
                ListViewDatabase.Location = new Point(153, 61);
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (ListViewDatabase.SelectedItems.Count > 0)
            {
                DialogResult dl = MessageBox.Show("Do you want to delete?", "Notify", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dl == DialogResult.Yes)
                {
                    ListViewDatabase.Items.Remove(ListViewDatabase.SelectedItems[0]);
                    stt--;
                }
            }
        }


        private void btnReturn_Click(object sender, EventArgs e)
        {
            btnSaveDatabase.Text = "Database";
            ListViewDatabase.Visible = false;
            btnReturn.Visible = false;
            draw(); draw_result(PhiB1, PhiB2);
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
                    sheet.Cells[1, 1].Value = "Database of balance 2 Plane";
                    sheet.Cells[1, 1].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    sheet.Cells[1, 1].Font.Size = 20;
                    sheet.Cells[1, 1].Borders.Weight = Excel.XlBorderWeight.xlThin;

                    sheet.Range[sheet.Cells[2, 2], sheet.Cells[2, 4]].Merge();
                    sheet.Cells[2, 2].Value = "Plane 1";
                    sheet.Cells[2, 2].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    sheet.Cells[2, 2].Font.Size = 20;
                    sheet.Cells[2, 2].Borders.Weight = Excel.XlBorderWeight.xlThin;

                    sheet.Range[sheet.Cells[2, 5], sheet.Cells[2, 7]].Merge();
                    sheet.Cells[2, 5].Value = "Plane 2";
                    sheet.Cells[2, 5].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    sheet.Cells[2, 5].Font.Size = 20;
                    sheet.Cells[2, 5].Borders.Weight = Excel.XlBorderWeight.xlThin;
                    // title
                    /*for (int i = 1; i <= dataTable.Columns.Count; i++)
                    {
                        sheet.Cells[3, i] = dataTable.Columns[i - 1].Text;
                        sheet.Cells[3, i].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        sheet.Cells[3, i].Font.Bold = true;
                        sheet.Cells[3, i].Borders.Weight = Excel.XlBorderWeight.xlThin;
                    }*/
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
        //hàm tính det
        public List<double> Calculator_det(double a11, double phia11, double a12, double phia12, double a21, double phia21, double a22, double phia22)
        {
            List<double> det = new List<double>();
            double anpha_x1, anpha_y1, anpha_x2, anpha_y2, re, im, bien_hieu, pha_hieu, anpha_x, anpha_y;
            anpha_x1 = (a11 * a22) * Math.Cos(phia11 + phia22);// tính tích hai số phức có pha và biên độ
            anpha_y1 = (a11 * a22) * Math.Sin(phia11 + phia22);//z11*z22
            anpha_x2 = (a21 * a12) * Math.Cos(phia21 + phia12);//z12*z21
            anpha_y2 = (a21 * a12) * Math.Sin(phia21 + phia12);
            re = anpha_x1 - anpha_x2;//(z11*z22-z12*z21)
            im = anpha_y1 - anpha_y2;
            bien_hieu = Math.Sqrt(re * re + im * im);
            pha_hieu = Math.Atan2(im, re);
            // 1/ (z11*z22-z12*z21)

            anpha_x = (1 / bien_hieu) * Math.Cos(0 - pha_hieu);
            anpha_y = (1 / bien_hieu) * Math.Sin(0 - pha_hieu);

            det.Add(Math.Sqrt(anpha_x * anpha_x + anpha_y * anpha_y));
            det.Add(Math.Atan2(anpha_y, anpha_x));
            return det;

        }

        // hàm tính lượng mất cân bằng mặt 1
        public List<double> Calcualtor_Mcb2P_B1(double a12, double phia12, double a22, double phia22, double det_bien, double det_pha,
            double A10, double Phi10, double A20, double Phi20)
        {
            List<double> balance1 = new List<double>();
            double anpha_x1, anpha_y1, anpha_x2, anpha_y2, re, im, tich_1, pha_tich_1, anpha_x, anpha_y;
            // tính (Z22*A10)+ (-z21*A20)

            anpha_x1 = (a22 * A10) * Math.Cos(phia22 + Phi10);// tính tích hai số phức có pha và biên độ
            anpha_y1 = (a22 * A10) * Math.Sin(phia22 + Phi10);//z11*z22
            anpha_x2 = -(a12 * A20) * Math.Cos(phia12 + Phi20);//z12*z21
            anpha_y2 = -(a12 * A20) * Math.Sin(phia12 + Phi20);
            re = anpha_x1 + anpha_x2;//(z11*z22-z12*z21)
            im = anpha_y1 + anpha_y2;
            tich_1 = Math.Sqrt(re * re + im * im);
            pha_tich_1 = Math.Atan2(im, re);

            anpha_x = (det_bien * tich_1) * Math.Cos(pha_tich_1 + det_pha);// tính tích hai số phức có pha và biên độ
            anpha_y = (det_bien * tich_1) * Math.Sin(pha_tich_1 + det_pha);


            balance1.Add(Math.Sqrt(anpha_x * anpha_x + anpha_y * anpha_y));
            balance1.Add(Math.Atan2(anpha_y, anpha_x));
            return balance1;

        }
        // hàm tính mất cân bằng mặt 2
        public List<double> Calcualtor_Mcb2P_B2(double a11, double phia11, double a21, double phia21, double det_bien, double det_pha,
            double A10, double Phi10, double A20, double Phi20)
        {
            List<double> balance2 = new List<double>();
            double anpha_x1, anpha_y1, anpha_x2, anpha_y2, re, im, tich_1, pha_tich_1, anpha_x, anpha_y;
            // tính (Z22*A10)+ (-z21*A20)

            anpha_x1 = -(a21 * A10) * Math.Cos(phia21 + Phi10);// tính tích hai số phức có pha và biên độ
            anpha_y1 = -(a21 * A10) * Math.Sin(phia21 + Phi10);//z11*z22
            anpha_x2 = (a11 * A20) * Math.Cos(phia11 + Phi20);//z12*z21
            anpha_y2 = (a11 * A20) * Math.Sin(phia11 + Phi20);
            re = anpha_x1 + anpha_x2;//(z11*z22-z12*z21)
            im = anpha_y1 + anpha_y2;
            tich_1 = Math.Sqrt(re * re + im * im);
            pha_tich_1 = Math.Atan2(im, re);

            anpha_x = (det_bien * tich_1) * Math.Cos(pha_tich_1 + det_pha);// tính tích hai số phức có pha và biên độ
            anpha_y = (det_bien * tich_1) * Math.Sin(pha_tich_1 + det_pha);


            balance2.Add(Math.Sqrt(anpha_x * anpha_x + anpha_y * anpha_y));
            balance2.Add(Math.Atan2(anpha_y, anpha_x));
            return balance2;

        }

        private void draw_result(double PhiB1, double PhiB2)
        {
            //hien thi ket qua mat 1

            int R = 125, x_0 = 130, y_0 = 130, x, y;
            double beta_1, beta_2;
            beta_1 = PhiB1 * 180 / Math.PI;
            beta_2 = 180 + PhiB1 * 180 / Math.PI;
            Graphics g = pnlResult_P1.CreateGraphics();

            SolidBrush brRed = new SolidBrush(Color.Red);
            x = x_0 + Convert.ToInt32(R * Math.Sin(Math.PI - beta_1 * Math.PI / 180)) - 5;
            y = y_0 + Convert.ToInt32(R * Math.Cos(Math.PI - beta_1 * Math.PI / 180)) - 5;
            g.FillEllipse(brRed, x, y, 10, 10);

            x = x_0 + Convert.ToInt32(R * Math.Sin(Math.PI + beta_2 * Math.PI / 180)) - 5;
            y = y_0 + Convert.ToInt32(R * Math.Cos(Math.PI + beta_2 * Math.PI / 180)) - 5;

            //hien thi ket qua mat 2        
            double beta_3, beta_4;
            beta_3 = PhiB2 * 180 / Math.PI;
            beta_4 = 180 + PhiB2 * 180 / Math.PI;
            Graphics g1 = pnlResult_P2.CreateGraphics();

            x = x_0 + Convert.ToInt32(R * Math.Sin(Math.PI - beta_3 * Math.PI / 180)) - 5;
            y = y_0 + Convert.ToInt32(R * Math.Cos(Math.PI - beta_3 * Math.PI / 180)) - 5;
            g1.FillEllipse(brRed, x, y, 10, 10);

            x = x_0 + Convert.ToInt32(R * Math.Sin(Math.PI + beta_4 * Math.PI / 180)) - 5;
            y = y_0 + Convert.ToInt32(R * Math.Cos(Math.PI + beta_4 * Math.PI / 180)) - 5;

            g.Dispose();
            g1.Dispose();
            brRed.Dispose();
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
            SolidBrush drawBrush = new SolidBrush(Color.FromArgb(46, 51, 73));

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


            g.FillRectangle(drawBrush, 0, 0, 260, 260); // re fill - clear pannel
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
            drawBrush.Dispose();
            //*************************** End simulation drawing ***************************//        
        }

        
    }
}
