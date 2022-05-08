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
using System.IO.Ports;
using ZedGraph;
namespace dynamic_balancing_machine.User_control
{
    public partial class DataAcquisition : UserControl
    {
        int Mode;
        int t = 0;        
        int i = 0;
        public DataAcquisition()
        {
            InitializeComponent();
            string[] BaudRate = { "1200", "2400", "4800", "9600", "19200", "38400", "57600", "115200" };
            cBoxBaud.Items.AddRange(BaudRate);
            string[] DataBits = { "6", "7", "8" };
            cBoxDatabits.Items.AddRange(DataBits);
            string[] StopBits = { "One", "Two" };
            cBoxStopbits.Items.AddRange(StopBits);
            string[] ParityBits = { "None", "Odd", "Even" };
            cBoxParitybits.Items.AddRange(ParityBits);
        }
       
        private void DataAcquisition_Load(object sender, EventArgs e)
        {            
            Control.CheckForIllegalCrossThreadCalls = false;
            cBoxCOM.DataSource = SerialPort.GetPortNames();
            //cBoxCOM.SelectedIndex = 1;
            cBoxBaud.SelectedIndex = 7;
            cBoxDatabits.SelectedIndex = 2;
            cBoxStopbits.SelectedIndex = 0;
            cBoxParitybits.SelectedIndex = 0;
        }        

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
                timer1.Enabled = false;i = 0;
                progressBar1.Value = 0;
                //serialPort1.DataReceived += new SerialDataReceivedEventHandler(serialPort1_DataReceived);
                btnConnect.Text = "Connect";
                btnConnect.ForeColor = Color.Green;
                MessageBox.Show("Disconnect sucessfully");

            }
            else
            {
                TextBox textBox = new Step_class().TextBox(ParentForm, "txtMode", "Main");
                Mode = int.Parse(textBox.Text);
                btnConnect.Text = "Disconnect";
                btnConnect.ForeColor = Color.Red;
                MessageBox.Show("Connect sucessfully");
                serialPort1.PortName = cBoxCOM.Text;
                serialPort1.BaudRate = Convert.ToInt32(cBoxBaud.Text);
                serialPort1.DataBits = Convert.ToInt32(cBoxDatabits.Text);
                serialPort1.StopBits = (StopBits)Enum.Parse(typeof(StopBits), cBoxStopbits.Text);
                serialPort1.Parity = (Parity)Enum.Parse(typeof(Parity), cBoxParitybits.Text);
                serialPort1.Open();
                progressBar1.Value = 100;

                
                t = 0;i = 0;
                timer1.Enabled = true;
                timer1.Start();
            }
            
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            TextBox textBox = new Step_class().TextBox(ParentForm, "txtMode", "Main");
            Mode = int.Parse(textBox.Text);
            if (Mode == 1)
            {
                new Step_class().Forward(ParentForm, "step2", "step3", "Calculator_1Plane", "StepProcess");
            }
            else if (Mode == 2)
            {
                new Step_class().Forward(ParentForm, "step2", "step3", "Calculator_2Plane", "StepProcess");
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            new Step_class().Back(ParentForm, "step2", "step1", "Main", "StepProcess");
        }

        private void btnReturnStep4_Click(object sender, EventArgs e)
        {
            NextButton.Visible = true;
            BackButton.Visible = true;
            btnReturnStep4.Visible = false;
            if (Mode == 1)
            {
                ParentForm.Controls.Find("PanelProcess", false)[0].Controls.Find("Result_1plane", false)[0].BringToFront();
            }
            else if (Mode == 2)
            {
                ParentForm.Controls.Find("PanelProcess", false)[0].Controls.Find("Result_2plane", false)[0].BringToFront();
            }
            
        }

        double[] piezo = new double[1500];
        double[] quang = new double[1500];
        double[] piezo1 = new double[1500];
        double[] piezo2 = new double[1500];
        /*double[] piezo;
        double[] quang;
        double[] piezo1;
        double[] piezo2;*/
        string data = "";        
        double data1, data2, data3;
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //Nhan data            
            data = serialPort1.ReadLine();
            txtDataReceive1.Text = data;
            txtDataReceive2.Text = data;
            string[] sub_data = data.Split(',');
            //txtAmAverage_P2_2P.Text = sub_data[4];

            /*data1 = double.Parse(sub_data[1]) * 5 / 32768;
            data2 = double.Parse(sub_data[2]) * 5 / 32768;
            data3 = double.Parse(sub_data[3]) * 5 / 32768;           
            
            
            //hien thi data va ve do thi
            /*if (Mode==1)
            {
                quang[i] = data1;
                piezo[i] = data2;
                i++;
                if (t == 500)
                {
                    CreateGraph(zed, piezo, quang, Color.Green, Color.Blue, txtAmAverage_1P, txtAnphaAverage_1P, txtDolechpha_1P, i);
                    Array.Clear(quang, 0, quang.Length);
                    Array.Clear(piezo, 0, piezo.Length);
                    i = 0;
                    time = 0;
                }                
            }
            else if (Mode == 2)
            {
                quang[i] = data1;
                piezo1[i] = data2;
                piezo2[i] = data3;
                i++;
                if (time == 1000)
                {
                    CreateGraph(zed, piezo1, quang, Color.Green, Color.Blue, txtAmAverage_P1_2P, txtAnphaAverage_P1_2P, txtDolechpha_P1_2P, i);
                    CreateGraph(zed, piezo2, quang, Color.Yellow, Color.Pink, txtAmAverage_P2_2P, txtAnphaAverage_P2_2P, txtDolechpha_P2_2P, i);
                    Array.Clear(quang, 0, quang.Length);
                    Array.Clear(piezo1, 0, piezo1.Length);
                    Array.Clear(piezo2, 0, piezo2.Length);
                    i = 0;
                    time = 0;
                }                
            }*/
        }

        
        private void timer1_Tick(object sender, EventArgs e)
        {
            t++;
        
        }

        public void CreateGraph(ZedGraphControl zgc, double[] piezo, double[] quang, Color pie, Color dft, 
            TextBox txtAmAverage, TextBox txtAnphaAverage, TextBox txtDolechpha, int len)
        {
            // vẽ đồ thị
            GraphPane myPane = zgc.GraphPane;
            myPane.CurveList.Clear();
            // Set the titles and axis labels
            myPane.Title.Text = "Data";
            myPane.XAxis.Title.Text = "X Value";
            myPane.YAxis.Title.Text = "Y Value";

            // Make up some data points from the Sine function
            PointPairList list = new PointPairList();// data thô
            PointPairList list1 = new PointPairList();// data và cbquang
            PointPairList list2 = new PointPairList();// vẽ lại hài bậc 1

            

            // xử lí data      
            int[] cbquang = new int[500];
            int th = 0;
            double y0 = 0;
            double tb = 0;

            for (int i = 0; i < len; i++)
            {
                tb += piezo[i];

            }
            double average = tb / len;// tinh trung binh data

            double y11 = 0;
            double y1 = quang[0];
            for (int j = 0; j < len; j++)
            {
                y11 = y1;
                y1 = quang[j];
                // piezo[i1] = y1;
                if (y1 >= 1)
                {
                    y1 = average + 0.05;
                }
                else y1 = average - 0.05;

                if (y11 == average - 0.05 && y1 == average + 0.05)
                {
                    cbquang[th] = j - 1;
                    th++;
                }
                list1.Add(j, y1);
            }
            // vẽ data từ cbquang 0 đến cbquang finish
            for (int k = cbquang[0]; k < cbquang[th - 1]; k++)
            {
                y0 = piezo[k];
                list.Add(k, y0);

            }


            //tinhs DFT

            double[] a0 = new double[100];
            double[] a1 = new double[100];
            double[] b1 = new double[100];
            double[] Am = new double[200];
            double[] phase = new double[100];
            double Am_avrage = 0;
            double Pha1_average = 0;
            double A0 = 0;
            for (int i = 0; i < th; i++)
            {


                int start = cbquang[i];
                int end = cbquang[i + 1];
                int length = end - start;
                int cycle = 1;
                Am[i] = 0;

                //offset = 0;
                a0[i] = 0;
                a1[i] = 0;
                b1[i] = 0;
                for (int k = start; k < end; k++)
                {
                    a0[i] += piezo[k];
                    a1[i] += piezo[k] * Math.Cos(cycle * 2 * Math.PI * k / length);
                    b1[i] += piezo[k] * Math.Sin(cycle * 2 * Math.PI * k / length);
                }
                a0[i] = a0[i] / length;
                a1[i] = 2 * a1[i] / length;
                b1[i] = 2 * b1[i] / length;
                phase[i] = Math.Atan(a1[i] / b1[i]);
                //offset = a0;

                if (a1[i] * b1[i] >= 0)
                {
                    if (a1[i] < 0) phase[i] -= Math.PI;
                }
                else
                {
                    if (a1[i] > 0) phase[i] += Math.PI;
                }
                Am[i] = Math.Sqrt(a1[i] * a1[i] + b1[i] * b1[i]);
                Am_avrage += Am[i];
                if (i < th - 1)
                { Pha1_average += phase[i] * 180 / Math.PI; }

                A0 += a0[i];



            }

            txtAmAverage.Text = (Am_avrage * 10000 / (th - 1)).ToString("0.000");// nhân 1000 để tính toán
            txtAnphaAverage.Text = (Pha1_average / (th - 1)).ToString("0.000");

            double Phi1_DFT = double.Parse(txtAnphaAverage.Text);

            double Am1 = double.Parse(txtAmAverage.Text) / 10000;// biên độ dft tb, chia 1000 để vẽ đồ thị
            double min = 0;
            int Poi = 0;
            // vẽ hình sin dựa vào biên độ và pha DFT
            for (int i = cbquang[0]; i < cbquang[th - 1]; i++)
            {
                double p = Am1 * Math.Sin(2 * Math.PI * i / (cbquang[1] - cbquang[0]) + Phi1_DFT * Math.PI / 180);
                list2.Add(i, p + average);

            }
            // tìm giá trị nhỏ nhất của hàm sin vẽ lại từ DFT
            for (int k = cbquang[0]; k < cbquang[1]; k++)
            {
                double p = Am1 * Math.Sin(2 * Math.PI * k / (cbquang[1] - cbquang[0]) + Phi1_DFT * Math.PI / 180);
                if (p < min)
                {
                    min = p;
                    Poi = k;
                }
            }

            //  DFT.Text = Poi.ToString() + " " + cbquang[0].ToString() + "  " + cbquang[1].ToString();
            txtDolechpha.Text = ((Poi - (cbquang[0])) * 360.000 / (cbquang[1] - cbquang[0])).ToString("0.000")
              /* + "  " + Poi.ToString("0.000")*/; // hiển thị pha trung bình và điểm nhỏ nhất của đồ thị vẽ lại

            // xuất tốc độ vật mẫu;
            txtRateobject.Text = (60 * i / ((cbquang[1] - cbquang[0]) * t/1000)).ToString("0.000");

            if (Mode==1)
            {
                LineItem myCurve = myPane.AddCurve("Piezo", list, pie, SymbolType.None);
                LineItem myCurve1 = myPane.AddCurve("cbquang", list1, Color.Red, SymbolType.None);
                LineItem myCurve2 = myPane.AddCurve("DFT_Piezo", list2, dft, SymbolType.None);
            }    
            else if (Mode==2)
            {
                if(pie==Color.Green)
                {
                    LineItem myCurve = myPane.AddCurve("Piezo1", list, pie, SymbolType.None);                    
                    LineItem myCurve2 = myPane.AddCurve("DFT_Piezo1", list2, dft, SymbolType.None);
                }  
                else
                {
                    LineItem myCurve = myPane.AddCurve("Piezo2", list, pie, SymbolType.None);                    
                    LineItem myCurve2 = myPane.AddCurve("DFT_Piezo2", list2, dft, SymbolType.None);
                }
                LineItem myCurve1 = myPane.AddCurve("cbquang", list1, Color.Red, SymbolType.None);
            }
            zgc.AxisChange();
            zgc.Invalidate();
        }

        private void btnSpeed_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort1.IsOpen)
                {
                    /*int x = int.Parse(txtNumericSpeed.Text);
                    int chuc = x / 10;
                    int donvi = x % 10;
                    byte[] DO_Chars = { (byte)(chuc+48), (byte)(donvi+48)};                
                    serialPort1.Write(DO_Chars, 0,2);*/

                    double x = double.Parse(txtNumericSpeed.Text);
                    if (x > 50 | x < 0)
                    {
                        MessageBox.Show("please enter the frequency again!");
                    }
                    else
                    {
                        int chuc = (int)(x / 10);
                        x = x - chuc * 10;
                        int donvi = (int)x;
                        x = x - donvi;
                        int phay = (int)(x * 10);
                        byte[] DO_Chars = { (byte)(chuc + 48), (byte)(donvi + 48), (byte)(phay + 48) };
                        DialogResult dl = MessageBox.Show("Are you sure you want to RUN the machine at this frequency?", "Notify", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dl == DialogResult.Yes)
                            serialPort1.Write(DO_Chars, 0, 3);
                    }
                    //serialPort1.WriteLine(txtNumericSpeed.Text);
                }
                else
                {
                    MessageBox.Show("Please connect Serial Com Port");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                byte[] DO_Chars = { (byte)48, (byte)48 };
                DialogResult dl = MessageBox.Show("Are you sure you want to STOP the machine?", "Notify", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dl == DialogResult.Yes)
                    serialPort1.Write(DO_Chars, 0, 2);

                //serialPort1.WriteLine("0");
            }
            else
            {
                MessageBox.Show("Please connect Serial Com Port");
            }
        }
    }
}
