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

        private void btn2Plane_Load_Click(object sender, EventArgs e)
        {            
            if (radioButton1.Checked == true | radioButton2.Checked == true | radioButton3.Checked == true | radioButton4.Checked == true)
            {
                TextBox AmAverage1 = new Step_class().TextBox1(ParentForm, "txtAmAverage_P1", "panel7", "DataAcquisition");
                TextBox Dolechpha1 = new Step_class().TextBox1(ParentForm, "txtDolechpha_P1", "panel7", "DataAcquisition");
                TextBox AmAverage2 = new Step_class().TextBox1(ParentForm, "txtAmAverage_P2_2P", "panel7", "DataAcquisition");
                TextBox Dolechpha2 = new Step_class().TextBox1(ParentForm, "txtDolechpha_P2_2P", "panel7", "DataAcquisition");
                if (radioButton1.Checked == true)
                {
                    txtPhizero1.Text = Dolechpha1.Text;
                    txtPhizero2.Text = Dolechpha2.Text;
                }
                else if (radioButton2.Checked == true)
                {
                    txtA10.Text = AmAverage1.Text;
                    txtA20.Text = AmAverage2.Text;
                    txtPhi10.Text = Dolechpha1.Text;
                    txtPhi20.Text = Dolechpha2.Text;
                }
                else if (radioButton3.Checked == true)
                {
                    if (txtM1.Text.Length != 0 && txtPhiM1.Text.Length != 0)
                    {
                        txtA11.Text = AmAverage1.Text;
                        txtA21.Text = AmAverage2.Text;
                        txtPhi11.Text = Dolechpha1.Text;
                        txtPhi21.Text = Dolechpha2.Text;
                    }
                    else MessageBox.Show("Please enter M1 and Phi M1");
                    
                }
                else if (radioButton4.Checked == true)
                {
                    if (txtM2.Text.Length != 0 && txtPhiM2.Text.Length != 0)
                    {
                        txtA12.Text = AmAverage1.Text;
                        txtA22.Text = AmAverage2.Text;
                        txtPhi12.Text = Dolechpha1.Text;
                        txtPhi22.Text = Dolechpha2.Text;
                    }
                    else MessageBox.Show("Please enter M2 and Phi M2");                    
                }
            }
            else MessageBox.Show("Please Chose 1 Item");
        }

        
        private void Calculator_2Plane_Load(object sender, EventArgs e)
        {
            txtV1.Text = "2";
            txtPhiV1.Text = "3.14";
            txtV2.Text = "2";
            txtPhiV2.Text = "6.28";
        }

        // tính an pha trong cân bằng 2 mặt
        double AnPha11, PhiAnPha11;
        double AnPha12, PhiAnPha12;
        double AnPha21, PhiAnPha21;
        double AnPha22, PhiAnPha22;
        double Am_det, Phi_det;
        double V1, PhiV1;// vị trí mất cân bằng calib


        double V2, PhiV2;


        private void btnDiagnostic_Click(object sender, EventArgs e)
        {
            try
            {
                double A10, Phi10, A20, Phi20, A11, Phi11, A21, Phi21, A12, Phi12, A22, Phi22;
                double M1, PhiM1, M2, PhiM2;

                // #1
                A10 = double.Parse(txtA10.Text);
                A20 = double.Parse(txtA20.Text);

                // #2
                A11 = double.Parse(txtA11.Text);
                A21 = double.Parse(txtA21.Text);
                M1 = double.Parse(txtM1.Text);
                PhiM1 = double.Parse(txtPhiM1.Text);
                // #3
                A12 = double.Parse(txtA12.Text);
                A22 = double.Parse(txtA22.Text);
                M2 = double.Parse(txtM2.Text);
                PhiM2 = double.Parse(txtPhiM2.Text);
                // hiệu chỉnh góc phi mặt phẳng 1
                if ((double.Parse(txtPhi10.Text) - double.Parse(txtPhizero1.Text)) < 0)
                {
                    Phi10 = double.Parse(txtPhi10.Text) - double.Parse(txtPhizero1.Text);
                    Phi11 = double.Parse(txtPhi11.Text) - double.Parse(txtPhizero1.Text);
                    Phi12 = double.Parse(txtPhi12.Text) - double.Parse(txtPhizero1.Text);

                }
                else
                {
                    Phi10 = double.Parse(txtPhizero1.Text) - double.Parse(txtPhi10.Text);
                    Phi11 = double.Parse(txtPhizero1.Text) - double.Parse(txtPhi11.Text);
                    Phi12 = double.Parse(txtPhizero1.Text) - double.Parse(txtPhi12.Text);

                }
                // hiệu chỉnh góc phi mặt phẳng 2
                if ((double.Parse(txtPhi20.Text) - double.Parse(txtPhizero2.Text)) < 0)
                {
                    Phi20 = double.Parse(txtPhi20.Text) - double.Parse(txtPhizero2.Text);
                    Phi21 = double.Parse(txtPhi21.Text) - double.Parse(txtPhizero2.Text);
                    Phi22 = double.Parse(txtPhi22.Text) - double.Parse(txtPhizero2.Text);

                }
                else
                {
                    Phi20 = double.Parse(txtPhizero2.Text) - double.Parse(txtPhi20.Text);
                    Phi21 = double.Parse(txtPhizero2.Text) - double.Parse(txtPhi21.Text);
                    Phi22 = double.Parse(txtPhizero2.Text) - double.Parse(txtPhi22.Text);

                }


                Phi10 = Phi10 * Math.PI / 180;
                Phi20 = Phi20 * Math.PI / 180;
                Phi11 = Phi11 * Math.PI / 180;
                Phi21 = Phi21 * Math.PI / 180;
                Phi12 = Phi12 * Math.PI / 180;
                Phi22 = Phi22 * Math.PI / 180;
                PhiM1 = PhiM1 * Math.PI / 180;
                PhiM2 = PhiM2 * Math.PI / 180;


                //********************************************************
                //tính toán anpha
                List<double> value = new List<double>();

                value = Calculator_Anpha2P(A10, Phi10, A11, Phi11, M1, PhiM1);
                AnPha11 = value[0];
                PhiAnPha11 = value[1];
                value = Calculator_Anpha2P(A10, Phi10, A12, Phi12, M1, PhiM1);
                AnPha12 = value[0];
                PhiAnPha12 = value[1];
                value = Calculator_Anpha2P(A20, Phi20, A21, Phi21, M2, PhiM2);
                AnPha21 = value[0];
                PhiAnPha21 = value[1];
                value = Calculator_Anpha2P(A20, Phi20, A22, Phi22, M2, PhiM2);
                AnPha22 = value[0];
                PhiAnPha22 = value[1];

                lblAnpha_11.Text = AnPha11.ToString("0.000") + " < " + (PhiAnPha11 * 180 / Math.PI).ToString("0.000");
                lblAnpha_12.Text = AnPha12.ToString("0.000") + " < " + (PhiAnPha12 * 180 / Math.PI).ToString("0.000");
                lblAnpha_21.Text = AnPha21.ToString("0.000") + " < " + (PhiAnPha21 * 180 / Math.PI).ToString("0.000");
                lblAnpha_22.Text = AnPha22.ToString("0.000") + " < " + (PhiAnPha22 * 180 / Math.PI).ToString("0.000");
                //database
                Anpha_11.Text = AnPha11.ToString("0.000"); PhiAn_11.Text = (PhiAnPha11).ToString("0.000");
                Anpha_12.Text = AnPha12.ToString("0.000"); PhiAn_12.Text = (PhiAnPha12).ToString("0.000");
                Anpha_21.Text = AnPha21.ToString("0.000"); PhiAn_21.Text = (PhiAnPha21).ToString("0.000");
                Anpha_22.Text = AnPha22.ToString("0.000"); PhiAn_22.Text = (PhiAnPha22).ToString("0.000");

                Phizero_1.Text = txtPhizero1.Text; Phizero_2.Text = txtPhizero2.Text;
                Phi_V10.Text = txtPhi10.Text; Phi_V20.Text = txtPhi20.Text;               

                // tính toán lượng mất cân bằng
                // tính det
                List<double> det = new List<double>();
                det = Calculator_det(AnPha11, PhiAnPha11, AnPha12, PhiAnPha12, AnPha21, PhiAnPha21, AnPha22, PhiAnPha22);
                Am_det = det[0];
                Phi_det = det[1];
                A_detload.Text = Am_det.ToString("0.0000"); Phi_detload.Text = Phi_det.ToString("0.0000");
                // tính lượng mất cân bằng B1
                List<double> balance1 = new List<double>();
                balance1 = Calcualtor_Mcb2P_B1(AnPha12, PhiAnPha12, AnPha22, PhiAnPha22, Am_det, Phi_det, A10, Phi10, A20, Phi20);
                V1 = balance1[0];
                PhiV1 = balance1[1];
                txtV1.Text = V1.ToString();
                txtPhiV1.Text = PhiV1.ToString();

                // tính lượng mất cân bằng B2
                List<double> balance2 = new List<double>();
                balance2 = Calcualtor_Mcb2P_B2(AnPha11, PhiAnPha11, AnPha21, PhiAnPha21, Am_det, Phi_det, A10, Phi10, A20, Phi20);
                V2 = balance2[0];
                PhiV2 = balance2[1];
                txtV2.Text = V2.ToString();
                txtPhiV2.Text = PhiV2.ToString();
            }
            catch { MessageBox.Show("Please data collection"); }
            
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = true;
            panel3.Visible = true;
            panel4.Visible = false;
        }

        private void btnDatabase_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = true;
        }


        private void btnSaveDatabase_Click(object sender, EventArgs e)
        {
            try
            {
                ListViewDatabase.Items.Clear();
                ListViewItem item1 = new ListViewItem("Phi zero 1");
                item1.SubItems.Add(Phizero_1.Text);
                ListViewItem item2 = new ListViewItem("Phi zero 2");
                item2.SubItems.Add(Phizero_2.Text);
                ListViewItem item3 = new ListViewItem("Phi V10");
                item3.SubItems.Add(Phi_V10.Text);
                ListViewItem item4 = new ListViewItem("Phi V20");
                item4.SubItems.Add(Phi_V20.Text);
                ListViewItem item5 = new ListViewItem("Anpha 11");
                item5.SubItems.Add(Anpha_11.Text);
                ListViewItem item6 = new ListViewItem("Phi 11");
                item6.SubItems.Add(PhiAn_11.Text);
                ListViewItem item7 = new ListViewItem("Anpha 12");
                item7.SubItems.Add(Anpha_12.Text);
                ListViewItem item8 = new ListViewItem("Phi 12");
                item8.SubItems.Add(PhiAn_12.Text);
                ListViewItem item9 = new ListViewItem("Anpha 21");
                item9.SubItems.Add(Anpha_21.Text);
                ListViewItem item10 = new ListViewItem("Phi 21");
                item10.SubItems.Add(PhiAn_21.Text);
                ListViewItem item11 = new ListViewItem("Anpha 22");
                item11.SubItems.Add(Anpha_22.Text);
                ListViewItem item12 = new ListViewItem("phi 22");
                item12.SubItems.Add(PhiAn_22.Text);
                ListViewItem item13 = new ListViewItem("Am_det");
                item13.SubItems.Add(A_detload.Text);
                ListViewItem item14 = new ListViewItem("Phi_det");
                item14.SubItems.Add(Phi_detload.Text);
                ListViewDatabase.Items.AddRange(new ListViewItem[] {
                item1, item2, item3, item4, item5, item6, item7, item8, item9,item10,item11,item12,item13,item14});

                SaveExcel_function(ListViewDatabase);
            }
            catch { MessageBox.Show("Please data collection before saving database"); }
        }

        double Phizero1_2P, Phizero2_2P, phiV10, phiV20, M11, phiM11, M12, phiM12, M21, phiM21, M22, phiM22, A_det, Ph_det;

        private void btnLoadDatabase_Click(object sender, EventArgs e)
        {
            try
            {
                LoadExcel_function(ListViewDatabase);
                double.TryParse(ListViewDatabase.Items[0].SubItems[1].Text, out Phizero1_2P);
                double.TryParse(ListViewDatabase.Items[1].SubItems[1].Text, out Phizero2_2P);
                double.TryParse(ListViewDatabase.Items[2].SubItems[1].Text, out phiV10);
                double.TryParse(ListViewDatabase.Items[3].SubItems[1].Text, out phiV20);
                double.TryParse(ListViewDatabase.Items[4].SubItems[1].Text, out M11);
                double.TryParse(ListViewDatabase.Items[5].SubItems[1].Text, out phiM11);
                double.TryParse(ListViewDatabase.Items[6].SubItems[1].Text, out M12);
                double.TryParse(ListViewDatabase.Items[7].SubItems[1].Text, out phiM12);
                double.TryParse(ListViewDatabase.Items[8].SubItems[1].Text, out M21);
                double.TryParse(ListViewDatabase.Items[9].SubItems[1].Text, out phiM21);
                double.TryParse(ListViewDatabase.Items[10].SubItems[1].Text, out M22); 
                double.TryParse(ListViewDatabase.Items[11].SubItems[1].Text, out phiM22); 
                double.TryParse(ListViewDatabase.Items[12].SubItems[1].Text, out A_det);
                double.TryParse(ListViewDatabase.Items[13].SubItems[1].Text, out Ph_det);

                Phizero_1.Text = Phizero1_2P.ToString("0.000"); Phizero_2.Text = Phizero2_2P.ToString("0.000");
                Phi_V10.Text = phiV10.ToString("0.000"); Phi_V20.Text = phiV20.ToString("0.000");
                Anpha_11.Text = M11.ToString("0.000"); PhiAn_11.Text = phiM11.ToString("0.000");
                Anpha_12.Text = M12.ToString("0.000"); PhiAn_12.Text = phiM12.ToString("0.000");
                Anpha_21.Text = M21.ToString("0.000"); PhiAn_21.Text = phiM21.ToString("0.000");
                Anpha_22.Text = M22.ToString("0.000"); PhiAn_22.Text = phiM22.ToString("0.000");
                A_detload.Text = A_det.ToString("0.000"); Phi_detload.Text = Ph_det.ToString("0.000");
                
                lblAnpha_11.Text = M11.ToString("0.000") + " < " + (phiM11 * 180 / Math.PI).ToString("0.000");
                lblAnpha_12.Text = M12.ToString("0.000") + " < " + (phiM12 * 180 / Math.PI).ToString("0.000");
                lblAnpha_21.Text = M21.ToString("0.000") + " < " + (phiM21 * 180 / Math.PI).ToString("0.000");
                lblAnpha_22.Text = M22.ToString("0.000") + " < " + (phiM22 * 180 / Math.PI).ToString("0.000");
                txtPhizero1.Text = Phizero1_2P.ToString("0.000");
                txtPhizero2.Text = Phizero2_2P.ToString("0.000");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // hàm tính anpha  ct = (v2-v1)/m
        public List<double> Calculator_Anpha2P(double V1, double PhiV1, double V2, double PhiV2, double m, double Phim)
        {
            List<double> value = new List<double>();
            double re, im, bien_do_hieu, goc_hieu, anpha_x, anpha_y;
            // tinh hiệu v2-v1
            re = V2 * Math.Cos(PhiV2) - V1 * Math.Cos(PhiV1);
            im = V2 * Math.Sin(PhiV2) - V1 * Math.Sin(PhiV1);
            bien_do_hieu = Math.Sqrt(re * re + im * im);
            goc_hieu = Math.Atan2(im, re);

            // (v2-v1)/m
            anpha_x = (bien_do_hieu / m) * Math.Cos(goc_hieu - Phim);
            anpha_y = (bien_do_hieu / m) * Math.Sin(goc_hieu - Phim);
            value.Add(Math.Sqrt(anpha_x * anpha_x + anpha_y * anpha_y));
            value.Add(Math.Atan2(anpha_y, anpha_x));
            return value;

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



        static void LoadExcel_function(ListView dataTable)
        {
            // open item
            OpenFileDialog fopen = new OpenFileDialog();
            fopen.Filter = "Excel Workbook|*.xlsx";
            fopen.ShowDialog();
            // process
            if (fopen.FileName != "")
            {
                dataTable.Items.Clear(); // clear list view
                Excel.Application app = new Excel.Application(); // create excel
                Excel.Workbook wb = app.Workbooks.Open(fopen.FileName);// open excel
                try
                {
                    // open sheet
                    Excel._Worksheet sheet = wb.Sheets[1];
                    Excel.Range range = sheet.UsedRange;
                    // read data
                    int rows = range.Rows.Count;
                    int cols = range.Columns.Count;
                    // data
                    for (int i = 3; i <= rows; i++)
                    {
                        ListViewItem item = new ListViewItem();
                        for (int j = 1; j <= cols; j++)
                        {
                            if (j == 1)
                                item.Text = range.Cells[i, j].Value.ToString();
                            else
                                item.SubItems.Add(range.Cells[i, j].Value.ToString());
                        }
                        dataTable.Items.Add(item);
                    }
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
    }
}