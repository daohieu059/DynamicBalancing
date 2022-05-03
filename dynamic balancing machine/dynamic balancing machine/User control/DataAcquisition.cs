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
        int time;
        int begin;
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
            cBoxCOM.SelectedIndex = 1;
            cBoxBaud.SelectedIndex = 7;
            cBoxDatabits.SelectedIndex = 2;
            cBoxStopbits.SelectedIndex = 0;
            cBoxParitybits.SelectedIndex = 0;
        }        

        private void NextButton_Click(object sender, EventArgs e)
        {
            TextBox textBox = new Step_class().TextBox(ParentForm, "txtMode", "Main");
            Mode = int.Parse(textBox.Text);
            if (Mode ==1)
            {
                new Step_class().Forward(ParentForm, "step2", "step3", "Calculator_1Plane", "StepProcess");
            }    
            else if (Mode==2)
            {
                new Step_class().Forward(ParentForm, "step2", "step3", "Calculator_2Plane", "StepProcess");
            }    
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            new Step_class().Back(ParentForm, "step2", "step1", "Main", "StepProcess");
        }

        private void btonConnect_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
                timer1.Enabled = false;i = 0;
                progressBar1.Value = 0;
                //serialPort1.DataReceived += new SerialDataReceivedEventHandler(serialPort1_DataReceived);
                btonConnect.Text = "Connect";
                btonConnect.ForeColor = Color.Green;

            }
            else
            {
                TextBox textBox = new Step_class().TextBox(ParentForm, "txtMode", "Main");
                Mode = int.Parse(textBox.Text);
                btonConnect.Text = "Disconnect";
                btonConnect.ForeColor = Color.Red;
                serialPort1.PortName = cBoxCOM.Text;
                serialPort1.BaudRate = Convert.ToInt32(cBoxBaud.Text);
                serialPort1.DataBits = Convert.ToInt32(cBoxDatabits.Text);
                serialPort1.StopBits = (StopBits)Enum.Parse(typeof(StopBits), cBoxStopbits.Text);
                serialPort1.Parity = (Parity)Enum.Parse(typeof(Parity), cBoxParitybits.Text);
                serialPort1.Open();
                progressBar1.Value = 100;

                /*serialPort1.DiscardInBuffer();
                Array.Clear(RX_1, 0, RX_1.Length);
                Array.Clear(RX_2, 0, RX_2.Length);
                Array.Clear(RX_3, 0, RX_3.Length);
                Array.Clear(rx_buffer, 0, rx_buffer.Length);
                Array.Clear(time, 0, time.Length);*/
                time = 0;i = 0;
                timer1.Enabled = true;
                timer1.Start();
            }
            if (serialPort1.IsOpen)
            {
                MessageBox.Show("Connect sucessfully");
            }
            else
            {
                MessageBox.Show("Disconnect sucessfully");
            }
        }

        /*double[] piezo = new double[1500];
        double[] quang = new double[1500];
        double[] piezo1 = new double[1500];
        double[] piezo2 = new double[1500];*/
        double[] piezo;
        double[] quang;
        double[] piezo1;
        double[] piezo2;
        string data = "";        
        double data1, data2, data3;
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //Nhan data            
            data = serialPort1.ReadLine();
            txtDataReceive.Text = data;
            string[] sub_data = data.Split(',');
            //textBox1.Text = sub_data[2];
            data1 = double.Parse(sub_data[1]) * 5 / 327;
            data2 = double.Parse(sub_data[2]) * 5 / 32768;
            data3 = double.Parse(sub_data[3]) * 5 / 32768;
            serialPort1.WriteLine(time.ToString());
            quang[i] = data1;
            piezo[i] = data2;
            
            //hien thi data va ve do thi
            if (Mode==1)
            {
                quang[i] = data1;
                piezo[i] = data2;
                i++;
                if (time == 1000)
                {                    
                    CreateGraph_1Plane(zed, piezo, quang);
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
                piezo[i] = data3;
                i++;
                if (time == 1000)
                {
                    CreateGraph_2Plane(zed, piezo1, piezo2, quang);
                    Array.Clear(quang, 0, quang.Length);
                    Array.Clear(piezo1, 0, piezo1.Length);
                    Array.Clear(piezo2, 0, piezo2.Length);
                    i = 0;
                    time = 0;
                }                
            }
        }

        
        private void timer1_Tick(object sender, EventArgs e)
        {
            time++;
        
        }

        public void CreateGraph_1Plane(ZedGraphControl zgc, double[] piezo, double[] quang)
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
            int[] cbquang = new int[100];
            int th = 0;
            double y0 = 0;
            double tb = 0;

            for (int i = 0; i < piezo.Length; i++)
            {
                tb += piezo[i];

            }
            double average = tb / piezo.Length;// tinh trung binh data

            double y11 = 0;
            double y1 = quang[0];
            for (int j = 0; j < quang.Length; j++)
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

            txtAmAverage_P1.Text = (Am_avrage * 10000 / (th - 1)).ToString("0.000");// nhân 1000 để tính toán
            txtAnphaAverage_P1.Text = (Pha1_average / (th - 1)).ToString("0.000");

            double Phi1_DFT = double.Parse(txtAnphaAverage_P1.Text);

            double Am1 = double.Parse(txtAmAverage_P1.Text) / 10000;// biên độ dft tb, chia 1000 để vẽ đồ thị
            double min = 0;
            int Poi = 0;
            // vẽ hình sin dựa vào biên độ và pha DFT
            // for (int i = 0; i < m.Length; i++)
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
            txtDolechpha_P1.Text = ((Poi - (cbquang[0])) * 360.000 / (cbquang[1] - cbquang[0])).ToString("0.000")
              /* + "  " + Poi.ToString("0.000")*/; // hiển thị pha trung bình và điểm nhỏ nhất của đồ thị vẽ lại

            // xuất tốc độ vật mẫu;
            //rate_object.Text = (60 * samplesPerChannelNumeric.Value * 1000 / ((cbquang[1] - cbquang[0]) * rateNumeric.Value)).ToString("0.000");


            LineItem myCurve = myPane.AddCurve("Piezo", list, Color.Blue, SymbolType.None);
            LineItem myCurve1 = myPane.AddCurve("cbquang", list1, Color.Green, SymbolType.None);            
            LineItem myCurve2 = myPane.AddCurve("DFT_Piezo", list2, Color.Red, SymbolType.None);
            zgc.AxisChange();
            zgc.Invalidate();
        }

        public void CreateGraph_2Plane(ZedGraphControl zgc, double[] piezo1, double[] piezo2, double[] quang)
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
            PointPairList list1 = new PointPairList();// cbquang
            PointPairList list2 = new PointPairList();// vẽ lại hài bậc 1
            PointPairList list3 = new PointPairList();//piezo2
            PointPairList list4 = new PointPairList();// cbquang
            PointPairList list5 = new PointPairList();// DFT piezo2


            // xử lí data      
            int[] cbquang = new int[100];
            int th = 0;
            double y0 = 0;
            double tb = 0;

            for (int i = 0; i < piezo1.Length; i++)
            {
                tb += piezo1[i];

            }
            double average = tb / piezo1.Length;// tinh trung binh data

            double y11 = 0;
            double y1 = quang[0];
            for (int j = 0; j < quang.Length; j++)
            {
                y11 = y1;
                y1 = quang[j];
                // piezo1[i1] = y1;
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
                y0 = piezo1[k];
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
                    a0[i] += piezo1[k];
                    a1[i] += piezo1[k] * Math.Cos(cycle * 2 * Math.PI * k / length);
                    b1[i] += piezo1[k] * Math.Sin(cycle * 2 * Math.PI * k / length);
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

            txtAmAverage_P1.Text = (Am_avrage * 10000 / (th - 1)).ToString("0.000");// nhân 1000 để tính toán
            txtAnphaAverage_P1.Text = (Pha1_average / (th - 1)).ToString("0.000");

            double Phi1_DFT = double.Parse(txtAnphaAverage_P1.Text);

            double Am1 = double.Parse(txtAmAverage_P1.Text) / 10000;// biên độ dft tb, chia 1000 để vẽ đồ thị
            double min = 0;
            int Poi = 0;
            // vẽ hình sin dựa vào biên độ và pha DFT
            // for (int i = 0; i < m.Length; i++)
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
            txtDolechpha_P1.Text = ((Poi - (cbquang[0])) * 360.000 / (cbquang[1] - cbquang[0])).ToString("0.000");
                         

            //piezo2

            int[] cbquang_2 = new int[100];
            int th_2 = 0;
            double y0_2 = 0;
            double tb_2 = 0;

            for (int i = 0; i < piezo2.Length; i++)
            {
                tb_2 += piezo2[i];

            }
            double average_2 = tb_2 / piezo2.Length;// tinh trung binh data

            double y11_2 = 0;
            double y1_2 = quang[0];
            for (int j = 0; j < quang.Length; j++)
            {
                y11_2 = y1_2;
                y1_2 = quang[j];
                // piezo2[i1] = y1_2;
                if (y1_2 >= 1)
                {
                    y1_2 = average_2 + 0.05;
                }
                else y1_2 = average_2 - 0.05;

                if (y11_2 == average_2 - 0.05 && y1_2 == average_2 + 0.05)
                {
                    cbquang_2[th_2] = j - 1;
                    th_2++;
                }

                list1.Add(j, y1_2);
            }
            // vẽ data từ cbquang_2 0 đến cbquang_2 finish
            for (int k = cbquang_2[0]; k < cbquang_2[th_2 - 1]; k++)
            {
                y0_2 = piezo2[k];
                list.Add(k, y0_2);

            }


            //tinhs DFT

            double[] a0_2 = new double[100];
            double[] a1_2 = new double[100];
            double[] b1_2 = new double[100];
            double[] Am_2 = new double[200];
            double[] phase_2 = new double[100];
            double Am_2_avrage = 0;
            double Pha2_average = 0;
            double A0_2 = 0;
            for (int i = 0; i < th_2; i++)
            {


                int start = cbquang_2[i];
                int end = cbquang_2[i + 1];
                int length = end - start;
                int cycle = 1;
                Am_2[i] = 0;

                //offset = 0;
                a0_2[i] = 0;
                a1_2[i] = 0;
                b1_2[i] = 0;
                for (int k = start; k < end; k++)
                {
                    a0_2[i] += piezo2[k];
                    a1_2[i] += piezo2[k] * Math.Cos(cycle * 2 * Math.PI * k / length);
                    b1_2[i] += piezo2[k] * Math.Sin(cycle * 2 * Math.PI * k / length);
                }
                a0_2[i] = a0_2[i] / length;
                a1_2[i] = 2 * a1_2[i] / length;
                b1_2[i] = 2 * b1_2[i] / length;
                phase_2[i] = Math.Atan(a1_2[i] / b1_2[i]);
                //offset = a0_2;

                if (a1_2[i] * b1_2[i] >= 0)
                {
                    if (a1_2[i] < 0) phase_2[i] -= Math.PI;
                }
                else
                {
                    if (a1_2[i] > 0) phase_2[i] += Math.PI;
                }
                Am_2[i] = Math.Sqrt(a1_2[i] * a1_2[i] + b1_2[i] * b1_2[i]);
                Am_2_avrage += Am_2[i];
                if (i < th_2 - 1)
                { Pha2_average += phase_2[i] * 180 / Math.PI; }

                A0_2 += a0_2[i];



            }

            txtAmAverage_P2_2P.Text = (Am_2_avrage * 10000 / (th_2 - 1)).ToString("0.000");// nhân 1000 để tính toán
            txtAnphaAverage_P2_2P.Text = (Pha2_average / (th_2 - 1)).ToString("0.000");

            double Phi2_DFT = double.Parse(txtAnphaAverage_P2_2P.Text);

            double Am2 = double.Parse(txtAmAverage_P2_2P.Text) / 10000;// biên độ dft tb, chia 1000 để vẽ đồ thị
            double min_2 = 0;
            int Poi_2 = 0;
            // vẽ hình sin dựa vào biên độ và pha DFT
            // for (int i = 0; i < m.Length; i++)
            for (int i = cbquang_2[0]; i < cbquang_2[th_2 - 1]; i++)
            {
                double p = Am2 * Math.Sin(2 * Math.PI * i / (cbquang_2[1] - cbquang_2[0]) + Phi2_DFT * Math.PI / 180);
                list4.Add(i, p + average_2);

            }
            // tìm giá trị nhỏ nhất của hàm sin vẽ lại từ DFT
            for (int k = cbquang_2[0]; k < cbquang_2[1]; k++)
            {
                double p = Am2 * Math.Sin(2 * Math.PI * k / (cbquang_2[1] - cbquang_2[0]) + Phi2_DFT * Math.PI / 180);
                if (p < min_2)
                {
                    min_2 = p;
                    Poi_2 = k;
                }
            }

            //  DFT.Text = Poi.ToString() + " " + cbquang_2[0].ToString() + "  " + cbquang_2[1].ToString();
            txtDolechpha_P2_2P.Text = ((Poi_2 - (cbquang_2[0])) * 360.000 / (cbquang_2[1] - cbquang_2[0])).ToString("0.000");

            LineItem myCurve = myPane.AddCurve("Piezo1", list, Color.Blue, SymbolType.None);
            LineItem myCurve1 = myPane.AddCurve("cbquang", list1, Color.Green, SymbolType.None);
            LineItem myCurve2 = myPane.AddCurve("DFT_Piezo1", list2, Color.Red, SymbolType.None);
            LineItem myCurve3 = myPane.AddCurve("Piezo2", list3, Color.Yellow, SymbolType.None);
            LineItem myCurve4 = myPane.AddCurve("cbquang", list4, Color.Green, SymbolType.None);
            LineItem myCurve5 = myPane.AddCurve("DFT_Piezo2", list5, Color.Pink, SymbolType.None);
            zgc.AxisChange();
            zgc.Invalidate();
        }

        

        private void drawingsignal(double[] time, double[] Piezo_1, double[] Piezo_2, double[] Quang)// drawing signal real time
        {


            GraphPane myPane = zed.GraphPane;
            myPane.CurveList.Clear();



            PointPairList piezo1_list = new PointPairList();
            PointPairList piezo2_list = new PointPairList();
            PointPairList quang_list = new PointPairList();


            Array.Resize<double>(ref Piezo_1, begin);
            Array.Resize<double>(ref Piezo_2, begin);
            Array.Resize<double>(ref Quang, begin);

            piezo1_list.Add(time, Piezo_1);
            piezo2_list.Add(time, Piezo_2);
            quang_list.Add(time, Quang);


            LineItem myCurve_1 = myPane.AddCurve("Piezo_1", piezo1_list, Color.Blue, SymbolType.None);
            LineItem myCurve_2 = myPane.AddCurve("Piezo_2", piezo2_list, Color.Green, SymbolType.None);
            LineItem myCurve_3 = myPane.AddCurve("Quang", quang_list, Color.Red, SymbolType.None);


            zed.AxisChange();
            zed.Invalidate();


        }
        private void btnSpeed_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.WriteLine(txtNumericSpeed.Text);
            }
            catch
            {
                MessageBox.Show("Please connect Com Port");
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.WriteLine("0");
            }
            catch
            {
                MessageBox.Show("Please connect Com Port");
            }
        }
    }
}
