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
using System.Data.SqlClient;

using Excel = Microsoft.Office.Interop.Excel;

namespace dynamic_balancing_machine.User_control
{
    public partial class Calculator_1Plane : UserControl
    {
        SQLClass sqlclass = new SQLClass();
        SqlConnection sqlcon = new SqlConnection(@"Data Source=LAPTOP-OUODJF98\SQLEXPRESS;Initial Catalog=DynamicBalanceMachine;Integrated Security=True");
        public Calculator_1Plane()
        {
            InitializeComponent();
        }

        private void Calculator_1Plane_Load(object sender, EventArgs e)
        {
            //LoadDataSQL();
            
        }        

        private void NextButton_Click(object sender, EventArgs e)
        {
            new Step_class().Forward(ParentForm, "step3", "step4", "Result_1Plane", "StepProcess");            
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            new Step_class().Back(ParentForm, "step3", "step2", "DataAcquisition", "StepProcess");
        }

        
        private void btn1Plane_Load_Click(object sender, EventArgs e)
        {            
            if (radioButton1.Checked==true|radioButton2.Checked==true|radioButton3.Checked==true)
            {
                TextBox AmAverage = new Step_class().TextBox1(ParentForm, "txtAmAverage_P1", "panel7", "DataAcquisition");
                TextBox Dolechpha = new Step_class().TextBox1(ParentForm, "txtDolechpha_P1", "panel7", "DataAcquisition");

                if (radioButton1.Checked == true)
                {
                    txtPhizero.Text = Dolechpha.Text;
                }
                else if (radioButton2.Checked == true)
                {
                    txtA1.Text = AmAverage.Text;
                    txtPhi1.Text = Dolechpha.Text;
                }
                else if (radioButton3.Checked == true)
                {
                    if(txtM.Text.Length!=0 && txtPhiM.Text.Length !=0)
                    {
                        txtA2.Text = AmAverage.Text;
                        txtPhi2.Text = Dolechpha.Text;
                    }   
                    else MessageBox.Show("Please enter M and Phi M");

                }                
            }
            else MessageBox.Show("Please Chose 1 Item");
        }

        // tính toán biên độ và pha ban đầu

        double A_anpha;
        double goc_anpha;

        private void btnDiagnostic_Click(object sender, EventArgs e)
        {
            try
            {
                double A1, phi1, A2, phi2, M, phiM, B, theta, anpha_x, anpha_y;

                A1 = double.Parse(txtA1.Text);
                A2 = double.Parse(txtA2.Text);
                if ((double.Parse(txtPhi1.Text) - double.Parse(txtPhizero.Text)) < 0)
                {
                    phi1 = double.Parse(txtPhi1.Text) - double.Parse(txtPhizero.Text);
                    phi2 = double.Parse(txtPhi2.Text) - double.Parse(txtPhizero.Text);

                }
                else
                {
                    phi1 = double.Parse(txtPhizero.Text) - double.Parse(txtPhi1.Text);
                    phi2 = double.Parse(txtPhizero.Text) - double.Parse(txtPhi2.Text);
                }




                M = double.Parse(txtM.Text);
                phiM = double.Parse(txtPhiM.Text);

                phi1 = phi1 * Math.PI / 180;
                phi2 = phi2 * Math.PI / 180;
                phiM = phiM * Math.PI / 180;

                double re = A2 * Math.Cos(phi2) - A1 * Math.Cos(phi1);
                double im = A2 * Math.Sin(phi2) - A1 * Math.Sin(phi1);
                double A = Math.Sqrt(re * re + im * im);
                double goc = Math.Atan2(im, re);


                //anpha_x = (A2 * Math.Cos(phi1) - A1 * Math.Cos(phi0)) / (M * Math.Cos(phiM));
                //anpha_y = (A2 * Math.Sin(phi1) - A1 * Math.Sin(phi0)) / (M * Math.Sin(phiM));
                anpha_x = (A / M) * Math.Cos(goc - phiM);
                anpha_y = (A / M) * Math.Sin(goc - phiM);
                A_anpha = Math.Sqrt(anpha_x * anpha_x + anpha_y * anpha_y);
                goc_anpha = Math.Atan2(anpha_y, anpha_x);
                
                lblAnpha_x.Text = anpha_x.ToString("0.000");
                lblAnpha_y.Text = anpha_y.ToString("0.000");

                B = (A1 / A_anpha) * Math.Cos(phi1 - goc_anpha);
                theta = (A1 / A_anpha) * Math.Sin(phi1 - goc_anpha);

                double Am_B = Math.Sqrt(B * B + theta * theta);
                double goc_theta = Math.Atan2(theta, B);

                txtAm.Text = Am_B.ToString();
                txtGoc.Text = goc_theta.ToString();

                Phizero.Text = txtPhizero.Text;
                Phi1.Text = txtPhi1.Text;
                Anpha_x.Text = anpha_x.ToString("0.000");
                Anpha_y.Text = anpha_y.ToString("0.000");
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
                ListViewItem item1 = new ListViewItem("Phi zero");
                item1.SubItems.Add(Phizero.Text);
                ListViewItem item2 = new ListViewItem("Phi V1");
                item2.SubItems.Add(Phi1.Text);
                ListViewItem item3 = new ListViewItem("Anpha x");
                item3.SubItems.Add(Anpha_x.Text);
                ListViewItem item4 = new ListViewItem("Anpha y");
                item4.SubItems.Add(Anpha_y.Text);


                ListViewDatabase.Items.AddRange(new ListViewItem[] { item1, item2, item3, item4 });

                SaveExcel_function(ListViewDatabase);
            }
            catch
            {
                MessageBox.Show("Please data collection before saving database");
            }
        }

        // tạo biến loaddatabase một mặt
        double Phizero_1P, An_x, An_y, Phi1_1P;


        private void btnLoadDatabase_Click(object sender, EventArgs e)
        {
            try
            {
                LoadExcel_function(ListViewDatabase);
                double.TryParse(ListViewDatabase.Items[0].SubItems[1].Text, out Phizero_1P);
                double.TryParse(ListViewDatabase.Items[1].SubItems[1].Text, out Phi1_1P);
                double.TryParse(ListViewDatabase.Items[2].SubItems[1].Text, out An_x);
                double.TryParse(ListViewDatabase.Items[3].SubItems[1].Text, out An_y);

                Phizero.Text = Phizero_1P.ToString("0.000");
                Phi1.Text = Phi1_1P.ToString("0.000");
                Anpha_x.Text = An_x.ToString("0.000");
                Anpha_y.Text = An_y.ToString("0.000");              

                lblAnpha_x.Text = An_x.ToString("0.000");
                lblAnpha_y.Text = An_y.ToString("0.000");
                txtPhizero.Text = Phizero_1P.ToString("0.000");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLoadSQL_Click(object sender, EventArgs e)
        {
            LoadDataSQL();
        }

        private void btnSaveSQL_Click(object sender, EventArgs e)
        {
            UpdateDataSQL();
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
        private void UpdateDataSQL()
        {
            string phizero = Phizero.Text.Trim();
            string phi1 = Phi1.Text.Trim();
            string anphax = Anpha_x.Text.Trim();
            string anphay = Anpha_y.Text.Trim();
            sqlclass.excedata("update Parameters_1Plane set Value = " + phizero + " where Fields = 'Phi zero' ", sqlcon);
            sqlclass.excedata("update Parameters_1Plane set Value = " + phi1 + " where Fields = 'Phi V1' ", sqlcon);
            sqlclass.excedata("update Parameters_1Plane set Value = " + anphax + " where Fields = 'Anpha x' ", sqlcon);
            sqlclass.excedata("update Parameters_1Plane set Value = " + anphay + " where Fields = 'Anpha y' ", sqlcon);
        }

        private void LoadDataSQL()
        {
            sqlclass.Open_Connect(sqlcon);
            //var table_sinhvien = sqlclass.LoadData("select Field,Value from Parameters_1Plane");
            SqlCommand cmds = new SqlCommand("select * from Parameters_1Plane", sqlcon);
            /*cmds.CommandType = CommandType.Text;
            cmds.CommandText = "select * from Parameters_1Plane";
            cmds.Connection = sqlcon;*/
            SqlDataReader reader = cmds.ExecuteReader();
            ListViewDatabase.Items.Clear();
            while (reader.Read())
            {
                string Field = (string)reader["Fields"];
                float Value = (float)reader["Value"];
                ListViewItem item = new ListViewItem(Field);
                item.SubItems.Add(Value.ToString());
                ListViewDatabase.Items.Add(item);
            }
            reader.Close();
            sqlcon.Close();
            double.TryParse(ListViewDatabase.Items[0].SubItems[1].Text, out Phizero_1P);
            double.TryParse(ListViewDatabase.Items[1].SubItems[1].Text, out Phi1_1P);
            double.TryParse(ListViewDatabase.Items[2].SubItems[1].Text, out An_x);
            double.TryParse(ListViewDatabase.Items[3].SubItems[1].Text, out An_y);

            Phizero.Text = Phizero_1P.ToString("0.000");
            Phi1.Text = Phi1_1P.ToString("0.000");
            Anpha_x.Text = An_x.ToString("0.000");
            Anpha_y.Text = An_y.ToString("0.000");

            lblAnpha_x.Text = An_x.ToString("0.000");
            lblAnpha_y.Text = An_y.ToString("0.000");
            txtPhizero.Text = Phizero_1P.ToString("0.000");
        }

    }
}
