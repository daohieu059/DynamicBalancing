using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using ZedGraph;
using System.IO.Ports;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Send_receiveData
{
    public partial class Form1 : Form
    {
        
        string data ="";

        string adc1;
        
        double adc1_val, adc2_val, adc3_val;

        int begin = 0;

        byte[] rx_buffer = new byte[7000];
        double[] RX_1 = new double[1000];
        double[] RX_2 = new double[1000];
        double[] RX_3 = new double[1000];
        double[] time = new double[1000];
        List<int> ListInt = new List<int>();
        

        public Form1()
        {
            InitializeComponent();
            string[] BaudRate = { "1200", "2400", "4800", "9600", "115200", "19200", "38400", "57600"};
            cBoxBaud.Items.AddRange(BaudRate);
            string[] DataBits = { "6", "7", "8" };
            cBoxDatabits.Items.AddRange(DataBits);
            string[] StopBits = { "One", "Two" };
            cBoxStopbits.Items.AddRange(StopBits);
            string[] ParityBits = { "None", "Odd", "Even" };
            cBoxParitybits.Items.AddRange(ParityBits);

        }

        public void Form1_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            cBoxCOM.DataSource = SerialPort.GetPortNames();
            cBoxCOM.SelectedIndex = 1;
            cBoxBaud.SelectedIndex = 4;
            cBoxDatabits.SelectedIndex = 2;
            cBoxStopbits.SelectedIndex = 0;
            cBoxParitybits.SelectedIndex = 0;


            GraphPane myPane = zedGraphControl1.GraphPane;
            myPane.CurveList.Clear();

            myPane.Title.Text = " Đồ thị kiểm tra";
            myPane.XAxis.Title.Text = "X Value";
            myPane.YAxis.Title.Text = "My Y Axis";
            myPane.XAxis.Scale.Min = 0;
            myPane.XAxis.Scale.Max = 1000;
            myPane.YAxis.Scale.Min = 0;
            myPane.YAxis.Scale.Max = 5000;



        }
        int i = 0;
        //string filePath = @"C:\data.txt";
        public void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {

            int bufferSize = serialPort1.BytesToRead;
            tBoxADC1.Text = bufferSize.ToString() +"////"+  RX_1.Length.ToString();

            /*while (serialPort1.BytesToRead > 0)
            {
                string[] sub_data = serialPort1.ReadLine().Split(',');
                //Rxbuffer_box.Text += sub_data[0] + " " + sub_data[1] + " " + sub_data[2];
               
            }
            */
      
            /*using (StreamWriter sw = File.AppendText(filePath))
            {
                sw.WriteLine(adc1.ToString());
            }*/
        

              if (bufferSize > 7000)
              {

                    tBoxDataReceive.Clear();
                    serialPort1.Read(rx_buffer, 0, 7000);
                    int[] ints = Array.ConvertAll(rx_buffer, Convert.ToInt32);
                    //string ascii = System.Text.Encoding.ASCII.GetString(rx_buffer);

                    int count = 0;
                    for(int j = 0; j < 7; j++)
                    {
                        if(ints[j] == 9)
                        {
                            count = j;
                        }
                    }

                    begin = 0;

                    for (int i = 0; i<(1000-count); i++)
                    {     
                        int k = count + i * 7;
                        time[begin] = begin;
                        RX_1[begin] = (ints[k+1]) * 256 + ints[k + 2];
                        RX_2[begin] = (ints[k+3]) * 256 + ints[k + 4];
                        RX_3[begin] = (ints[k+5]) * 256 + ints[k + 6];
                        begin++;
                    }
                    tBoxDataReceive.Text = RX_1[0].ToString() + "  " + RX_2[0].ToString() + "  " + RX_3[0].ToString() +"\r\n";
                    
                drawingsignal(time, RX_1, RX_2, RX_3);
              }
        }




        private void ShowData(object sender, EventArgs e)
        {
            tBoxDataReceive.Text = data;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
                progressBar1.Value = 0;
                //serialPort1.DataReceived += new SerialDataReceivedEventHandler(serialPort1_DataReceived);
                btonConnect.Text = "Connect";
                btonConnect.ForeColor = Color.Green ;

            }
            else
            {
                btonConnect.Text = "Disconnect";
                btonConnect.ForeColor = Color.Red;                
                serialPort1.PortName = cBoxCOM.Text;
                serialPort1.BaudRate = Convert.ToInt32(cBoxBaud.Text);                
                serialPort1.DataBits = Convert.ToInt32(cBoxDatabits.Text);                
                serialPort1.StopBits = (StopBits)Enum.Parse(typeof(StopBits), cBoxStopbits.Text);                
                serialPort1.Parity = (Parity)Enum.Parse(typeof(Parity), cBoxParitybits.Text);
                serialPort1.Open();
                progressBar1.Value = 100;

                serialPort1.DiscardInBuffer();
                Array.Clear(RX_1, 0, RX_1.Length);
                Array.Clear(RX_2, 0, RX_2.Length);
                Array.Clear(RX_3, 0, RX_3.Length);
                Array.Clear(rx_buffer, 0, rx_buffer.Length);
                Array.Clear(time, 0, time.Length);

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

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }
        private void button3_Click(object sender, EventArgs e)
        {
            serialPort1.WriteLine("s");
        }

        private void zedGraphControl1_Load(object sender, EventArgs e)
        {

        }
        private void drawingsignal(double[] time, double[] Piezo_1, double[] Piezo_2, double[] Quang)// drawing signal real time
        {
            

            GraphPane myPane = zedGraphControl1.GraphPane;
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

            
            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();


        }
    }

    
}
