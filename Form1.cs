using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Net.Sockets;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using _excel = Microsoft.Office.Interop.Excel;
using System.Data.SqlClient;
namespace GRipperDesign
{
    public partial class Form1 : Form
    {
        int Count = 0, Count2 = 0, Cavity_mass = 0,TopView_index=0;
        int surface_form_index = 0, Demolding_Force = 0, Cup_number = 0, ForceperCup = 0;
        int[] betre_diameter = new int[12] { 2, 4, 6, 8, 10, 13, 16, 20, 25, 32, 40, 50 };
        int Price = 0,PadDiameter =0;
        string PadSerial = "";
        Double Cup_diameter = 0, Force_to_lb = 0, PSI = 88;
        bool link = false;
        int Box_A = 0, Box_B = 0, Box_C = 0, Box_Area = 0,Hardness =0, BoxRegression =0;
        int demold_f = 0;

        //Socket
        int port; //Port number of server
        char message; //Message to send
        int byteCount; //Raw bytes to send
        NetworkStream stream; //Link stream
        NetworkStream stream2; //Link stream
        byte[] sendData = new byte[5]; //Raw data to send
        byte[] readData = new byte[1];
        TcpClient client; //TCP client variable
        public Form1()
        {
            InitializeComponent();
            //Thread t1 = new Thread(new ThreadStart(Thread1));
            //t1.Start();


        }

        //void Thread1()
        //{
        //    NewForm.Show();
        //}
        public string conString = "Data Source=DESKTOP-A07LIUV;Initial Catalog=Vacuum_Components;Integrated Security=True";
        private int[] Getmodel()
        {
            int[] Modelcode = new int[3];
            Modelcode[0] = outerShape1.OuterShape_index;
            Modelcode[0] = Modelcode[0] + 1;
            Modelcode[1] = innerShape1.innerShape_index;
            Modelcode[2] = upperShape1.upperShape_index;
            Modelcode[2] = Modelcode[2] + 1;
            return Modelcode;
        }
        private DataSet GetDataSet(String Type,String NumberofCups, String DiameterOfcup, String cupPrice, String SuctionPrice)
        {
            int cup_p = 0, Suction_p = 0,total =0;
            cup_p = int.Parse(cupPrice);
            Suction_p = int.Parse(SuctionPrice);
            total = cup_p + Suction_p;
            DataSet ds = new DataSet();
            System.Data.DataTable dtbl = new System.Data.DataTable();
            dtbl.Columns.Add("รายการ");
            dtbl.Columns.Add("รายละเอียด");
            dtbl.Columns.Add("จำนวน");
            dtbl.Columns.Add("ราคา");
            dtbl.Columns.Add("ภาพ");
            

            dtbl.Rows.Add(Type ,"Cup Diameter: " + DiameterOfcup, NumberofCups, cupPrice);
            dtbl.Rows.Add("ZH07D", "Pressure: -88", NumberofCups, SuctionPrice);
            dtbl.Rows.Add("", "","Total",total.ToString());
            dtbl.TableName = "Table1";
            ds.Tables.Add(dtbl);
            return ds;
        }
        private void ExportDataSetToExcel(DataSet ds, string strPath)
        {
            int inHeaderLength = 3, inColumn = 0, inRow = 0;
            System.Reflection.Missing Default = System.Reflection.Missing.Value;
            //Create Excel File
            //strPath += @"\Excel" + DateTime.Now.ToString().Replace(':', '-') + ".xlsx";
            _excel.Application excelApp = new _excel.Application();
            _excel.Workbook excelWorkBook = excelApp.Workbooks.Add(1);
            foreach (System.Data.DataTable dtbl in ds.Tables)
            {
                //Create Excel WorkSheet
                _excel.Worksheet excelWorkSheet = excelWorkBook.Sheets.Add(Default, excelWorkBook.Sheets[excelWorkBook.Sheets.Count], 1, Default);
                excelWorkSheet.Name = dtbl.TableName;//Name worksheet

                //Write Column Name
                for (int i = 0; i < dtbl.Columns.Count; i++)
                    excelWorkSheet.Cells[inHeaderLength + 1, i + 1] = dtbl.Columns[i].ColumnName.ToUpper();

                //Write Rows
                for (int m = 0; m < dtbl.Rows.Count; m++)
                {
                    for (int n = 0; n < dtbl.Columns.Count; n++)
                    {
                        inColumn = n + 1;//
                        inRow = inHeaderLength + 2 + m;//2
                        excelWorkSheet.Cells[inRow, inColumn] = dtbl.Rows[m].ItemArray[n].ToString();
                        if (m % 2 == 0)
                            excelWorkSheet.get_Range("A" + inRow.ToString(), "I" + inRow.ToString()).Interior.Color = System.Drawing.ColorTranslator.FromHtml("#FCE4D6");
                    }
                    _excel.Range RowL = excelWorkSheet.get_Range("A5", "I6");
                    RowL.EntireRow.RowHeight = 80;
                }

                

                //merge E4 - I4
                _excel.Range M = excelWorkSheet.get_Range("E4", "I4");
                M.Merge(true);

                //Excel Header
                _excel.Range cellRang = excelWorkSheet.get_Range("A1", "I3");
                cellRang.Merge(false);
                cellRang.Interior.Color = System.Drawing.Color.White;
                cellRang.Font.Color = System.Drawing.Color.Gray;
                cellRang.HorizontalAlignment = _excel.XlHAlign.xlHAlignCenter;
                cellRang.VerticalAlignment = _excel.XlVAlign.xlVAlignCenter;
                cellRang.Font.Size = 26;
                excelWorkSheet.Cells[1, 1] = "GRIPPER DESIGH";
                excelWorkSheet.Shapes.AddPicture(@"C:\Users\palmdotax\source\repos\GRipperDesign\Picture\Draft\Flat.png", Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 200, 60, 200, 80);
                
                cellRang.EntireRow.RowHeight = 20;

                // add Vacuum Ejector pic
                
                excelWorkSheet.Shapes.AddPicture(@"C:\Users\palmdotax\source\repos\GRipperDesign\Picture\Draft\Vacuum Ejector.png", Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue,200,150,200,80);

                // add Draft design
                _excel.Range Df = excelWorkSheet.get_Range("A8", "I10");
                Df.Merge(false);
                Df.Interior.Color = System.Drawing.Color.White;
                Df.Font.Color = System.Drawing.Color.Gray;
                Df.HorizontalAlignment = _excel.XlHAlign.xlHAlignCenter;
                Df.VerticalAlignment = _excel.XlVAlign.xlVAlignCenter;
                Df.Font.Size = 26;
                Df.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
                Df.Interior.Color = System.Drawing.ColorTranslator.FromHtml("#ED7D31");
                excelWorkSheet.Cells[8,1] = "DRAFT DESIGH";
                //add df pic
                _excel.Range Dfp = excelWorkSheet.get_Range("A11", "I24");
                Dfp.Merge(false);
                excelWorkSheet.Shapes.AddPicture(@"C:\Users\palmdotax\source\repos\GRipperDesign\Picture\Draft\Gripper.png", Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 1, 300, 200, 80);
                excelWorkSheet.Shapes.AddPicture(@"C:\Users\palmdotax\source\repos\GRipperDesign\Picture\Draft\Vacuum pad Distance.png", Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 200, 300, 200, 80); 
                //Style table column names
                cellRang = excelWorkSheet.get_Range("A4", "G4");
                cellRang.Font.Bold = true;
                cellRang.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
                cellRang.Interior.Color = System.Drawing.ColorTranslator.FromHtml("#ED7D31");
                excelWorkSheet.get_Range("F4").EntireColumn.HorizontalAlignment = _excel.XlHAlign.xlHAlignRight;
                //Formate price column
                excelWorkSheet.get_Range("F5").EntireColumn.NumberFormat = "0.00";
                //Auto fit columns
                excelWorkSheet.Columns.AutoFit();
            }

            //Delete First Page
            excelApp.DisplayAlerts = false;
            Microsoft.Office.Interop.Excel.Worksheet lastWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)excelWorkBook.Worksheets[1];
            lastWorkSheet.Delete();
            excelApp.DisplayAlerts = true;

            //Set Defualt Page
            (excelWorkBook.Sheets[1] as _excel._Worksheet).Activate();

            excelWorkBook.SaveAs(@"C:\Users\palmdotax\source\repos\GRipperDesign\BOM.xlxs");
            excelWorkBook.Close();
            excelApp.Quit();

            MessageBox.Show("Excel generated successfully \n As " + strPath);
        }
            public int CupNumber_calculation(int x, int y)
        {
            int xNumber = 0, yNumber = 0, CupNo = 0;
            xNumber = x / 200;
            yNumber = y / 200;
            CupNo = xNumber * yNumber;
            return CupNo;
        }
        public int ForceCavity_calculation(int Object_mass)
        {
            int Force = Object_mass * 10 * 4;
            return Force;
        }
        public int ForceCup_calculation(int F, int n_cups)
        {
            int Force = F;
            Force = Force / n_cups;
            System.Diagnostics.Debug.WriteLine("Force: {0}", Force);
            return Force;
        }
        public double SuctionDiameter_calculation(double F, double P)
        {
            double S_Diameter = 0;
            double result = 0;
            S_Diameter = F / P;
            // Convert Area to Diameter
            System.Diagnostics.Debug.WriteLine("Calculation AREA: {0}", S_Diameter);
            S_Diameter = S_Diameter / 3.14;
            S_Diameter = Math.Sqrt(S_Diameter);
            result = S_Diameter * 2;
            System.Diagnostics.Debug.WriteLine("Diameter(mm) {0}", S_Diameter);
            result = result * 2.45;
            //result = Math.Truncate(S_Diameter * 10) / 10;
            //result = Convert.ToInt32(S_Diameter);
            return result;
        }
       

        private void Form1_Load(object sender, EventArgs e)
        {
            button7.Hide();
            button8.Hide();
            button9.Hide();
            button10.Hide();
           
        }
      
        private void button1_Click(object sender, EventArgs e)
        {
            button7.Show();
            button9.Hide();
            button10.Hide();
            outerShape1.BringToFront();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        //Foeward
        private void button7_Click(object sender, EventArgs e)
        {

            Count++;
            if(Count == 1)
            {
                innerShape1.BringToFront();
                button8.Show();
                button9.Hide();
            }
            if (Count == 2)
            {
                upperShape1.BringToFront();
                // button7.Hide();
            }
            if (Count == 3)
            {
                topview1.BringToFront();
               
            }
            if (Count == 4)
            {
                // model
                int[] Code = Getmodel();
                System.Diagnostics.Debug.Write("ModelCode :");
                for (int p = 0; p < 3; p++)
                {
                    System.Diagnostics.Debug.Write(Code[p]);
                }
                TopView_index = topview1.Topshape.SelectedIndex;
                if(TopView_index == 0)
                {
                    combineShape1.BringToFront();
                    button7.Hide();
                    String[] text = new string[3];
                    text[0] = Code[0].ToString();
                    text[1] = Code[1].ToString();
                    text[2] = Code[2].ToString();
                    Image image = Image.FromFile(@"C:\Users\palmdotax\source\repos\GRipperDesign\Picture\Shape\s" + text[0]+ text[1] + text[2] +".png");
                    combineShape1.Set_picture.Image = image;
                }
                if (TopView_index == 1)
                {
                    combineBoxshape1.BringToFront();
                    button7.Hide();
                }
                
            }

        }
        // Back
        private void button8_Click(object sender, EventArgs e)
        {
            Count--;
            if (Count == 0)
            {
                outerShape1.BringToFront();
                button8.Hide();

            }
            if (Count == 1)
            {
                innerShape1.BringToFront();

            }
            if (Count == 2)
            {
                upperShape1.BringToFront();
                

            }
            if (Count == 3)
            {
                topview1.BringToFront();
                button7.Show();

            }
            if (Count == 4)
            {
                combineShape1.BringToFront();

            }
        }
        // B.O.M Print
        private void button10_Click(object sender, EventArgs e)
        {
            Price = Cup_number * Price;
            DataSet DsData = GetDataSet(PadSerial.ToString(), Cup_number.ToString(), PadDiameter.ToString(), Price.ToString(), "4000");
            ExportDataSetToExcel(DsData,"BOM.xlxs");
        }

        //prop
        private void button2_Click(object sender, EventArgs e)
        {
            button7.Hide();
            button8.Hide();
            button9.Hide();
            button10.Hide();
            rubberProperty1.BringToFront();
        }
        //Mold
        private void button3_Click(object sender, EventArgs e)
        {
            button7.Hide();
            button8.Hide();
            button9.Show();
            button10.Hide();
            mold1.BringToFront();
        }
        //factor
        private void button4_Click(object sender, EventArgs e)
        {
            button7.Hide();
            button8.Hide();
            button9.Hide();
            button10.Hide();
            factor1.BringToFront();
        }

        //เลือก Model Vacuumpads และ ราคา จาก Database
        void get_vacuumpadData(int Diameter,string types)
        {
            for(int Num =0; Num<12; Num++)
            {
                //System.Diagnostics.Debug.WriteLine(Num);
                if (betre_diameter[Num] > Diameter)//
                {
                    PadDiameter = betre_diameter[Num];
                    System.Diagnostics.Debug.WriteLine(Diameter);
                    break;
                }
            }
            //Connect database
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                
                //string sql = "SELECT Price FROM tblVacuumpads WHERE Diameter = 8 AND Types = 'Flat' ";
                string sql = "SELECT PadSerialnumber FROM tblVacuumpads WHERE Diameter = " + Diameter+"AND Types = '"+types+"'";
                SqlCommand cmd = new SqlCommand(sql, con);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        
                        PadSerial = reader.GetString(0);

                    }
                }

                //Get Price
                string sql2 = "SELECT Price FROM tblVacuumpads WHERE Diameter = " + Diameter + "AND Types = '" + types + "'";
                SqlCommand cmd2 = new SqlCommand(sql2, con);

                using (SqlDataReader reader2 = cmd2.ExecuteReader())
                {
                    while (reader2.Read())
                    {

                        Price = reader2.GetInt32(0);
                        System.Diagnostics.Debug.WriteLine(Price);
                    }

                }

            }

        }

        void ConnectSoket()
        {

            const string Server = "127.0.0.1";
            port = 8000;
            //Attemps to make connection
            try
            {
                client = new TcpClient(Server, port);
                System.Diagnostics.Debug.WriteLine("Success");

            }
            catch (System.Net.Sockets.SocketException)
            {
                //Adds debug to list box and shows message box
                System.Diagnostics.Debug.WriteLine("Connection Failed");

            }

        }
        // Regression
        public int Regression_cal(int Ar, int HN)
        {
            // S + area + hardness + CR
            ushort AValue = Convert.ToUInt16(Ar);
            byte upperArea = (byte)(AValue >> 8);
            byte lowerArea = (byte)(AValue & 0xff);

            ushort HNValue = Convert.ToUInt16(HN);
            byte upperH = (byte)(HN >> 8);
            byte lowerH = (byte)(HN & 0xff);
            System.Diagnostics.Debug.WriteLine("up: {0}", upperArea);
            System.Diagnostics.Debug.WriteLine("low: {0}", lowerArea);
            
            // System.Diagnostics.Debug.WriteLine("Connect.....";
            ConnectSoket();
            //send
            try
            {
                //message = upperc; //Set message variable to input
                //byteCount = Encoding.ASCII.GetByteCount(message); //Measures bytes required to send ASCII data
                //sendData = new byte[byteCount]; //Prepares variable size for required data
                //sendData = Encoding.ASCII.GetBytes(message); //Sets the sendData variable to the actual binary data (from the ASCII)
                sendData[0] = 0x53;
                sendData[1] = upperArea;
                sendData[2] = lowerArea;
                sendData[3] = upperH;
                sendData[4] = lowerH;
                stream = client.GetStream(); //Opens up the network stream
                stream.Write(sendData, 0,5); //Transmits data onto the stream
                //System.Diagnostics.Debug.WriteLine("Massage: {0}", sendData[0]);
                //System.Diagnostics.Debug.WriteLine("Massage: {0}", sendData[1]);
                // System.Diagnostics.Debug.WriteLine("bytecount: {0}", byteCount);

            }
            catch (System.NullReferenceException) //Error if socket not open
            {
                //Adds debug to list box and shows message box
                // MessageBox.Show("Connection not installised");
                // listBox1.Items.Add("Failed to send data");
                System.Diagnostics.Debug.WriteLine("Failed to send data");
            }
            try
            {
                stream2 = client.GetStream();
                stream2.Read(readData,0,1);
                System.Diagnostics.Debug.WriteLine("Read: {0}", readData[0]);

            }
            catch(System.NullReferenceException)
            {
                System.Diagnostics.Debug.WriteLine("Failed to Read data");
            }
            demold_f = Convert.ToInt32(readData[0]);
            System.Diagnostics.Debug.WriteLine("Read_INT: {0}", demold_f);
            System.Diagnostics.Debug.WriteLine("END......");
            return BoxRegression;
        }
        //Save
        private void button9_Click(object sender, EventArgs e)
        {

            
            //Gripper
            int[] Code = Getmodel();
            // Box_area calculator
            if(combineBoxshape1.boxState2 ==1 && combineBoxshape1.boxState3 == 1 && combineBoxshape1.boxState4 == 1)
            {
                Box_A = combineBoxshape1.A_value;
                System.Diagnostics.Debug.WriteLine("A: {0}", Box_A);
                Box_B = combineBoxshape1.B_value;
                System.Diagnostics.Debug.WriteLine("B: {0}", Box_B);
                Box_C = combineBoxshape1.C_value;
                System.Diagnostics.Debug.WriteLine("C: {0}", Box_C);
                Box_Area = (2 * Box_A * Box_B) + (2 * Box_A * Box_C);
                System.Diagnostics.Debug.WriteLine("Area: {0}", Box_Area);
            }
            // Hardness
            if(rubberProperty1.HNState ==1)
            {
                Hardness = rubberProperty1.HN_value;
                System.Diagnostics.Debug.WriteLine("Hardness: {0}", Hardness);
            }
            Regression_cal(Box_Area, Hardness);
            //Vacuum Gripper
            if (combineBoxshape1.boxState == 1)
            {
                demold_f = demold_f / 10;

                System.Diagnostics.Debug.WriteLine("Vacuum Gripper");
                factor1.Gripper_type.Text = "Vacuum Gripper";
                Cavity_mass = combineBoxshape1.Mass_value;
                Cavity_mass = Cavity_mass + demold_f;
                System.Diagnostics.Debug.WriteLine("Mass: {0}", Cavity_mass);
                factor1.Mass_result.Text = Cavity_mass.ToString();
                Demolding_Force = ForceCavity_calculation(Cavity_mass);
                System.Diagnostics.Debug.WriteLine("Demolding Force: {0}", Demolding_Force);
                factor1.DemoldingForce.Text = Demolding_Force.ToString();
                Cup_number = CupNumber_calculation(900, 550);
                System.Diagnostics.Debug.WriteLine("Cup Number: {0}", Cup_number);
                draftVacuumGripper1.NumberOfVacuum.Text = Cup_number.ToString();
                ForceperCup = ForceCup_calculation(Demolding_Force, Cup_number);
                Force_to_lb = Convert.ToDouble(ForceperCup);
                Force_to_lb = Force_to_lb * 0.224;
                // Fixed Pressure
                // double PSI = 88;
                PSI = PSI * 0.145;
                Cup_diameter = SuctionDiameter_calculation(Force_to_lb, PSI);
                System.Diagnostics.Debug.WriteLine("Suction Diameter: {0}", Cup_diameter);
                draftVacuumGripper1.PadDiameter.Text = Cup_diameter.ToString();

                Image image = Image.FromFile(@"C:\Users\palmdotax\source\repos\GRipperDesign\Picture\Case1.png");
                factor1.Set_picture.Image = image;
                //Cup
                int newDiamenter = Convert.ToInt32(Cup_diameter);
                newDiamenter = newDiamenter * 10;
                System.Diagnostics.Debug.WriteLine("Convert: {0}", newDiamenter);
                get_vacuumpadData(newDiamenter, "Flat");
            }
            // Gripper แบบผังพืด
            else if (combineShape1.Support_value == 1)
            {
                Cavity_mass = combineShape1.Mass_value;
                System.Diagnostics.Debug.WriteLine("Rigid Gripper ผังผืด");
                factor1.Gripper_type.Text = "Rigid Gripper ผังผืด";

                Image image = Image.FromFile(@"C:\Users\palmdotax\source\repos\GRipperDesign\Picture\Gripper ผังผืด.png");
                factor1.Set_picture.Image = image;
            }
            // Rigid Gripper 
            else if (Code[2] == 3)
            {
                Cavity_mass = combineShape1.Mass_value;
                System.Diagnostics.Debug.WriteLine("Rigid Gripper");
                factor1.Gripper_type.Text = "Rigid Gripper";

                Image image = Image.FromFile(@"C:\Users\palmdotax\source\repos\GRipperDesign\Picture\Rigid Gripper.png");
                factor1.Set_picture.Image = image;
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("No recommended Gripper");
                factor1.Gripper_type.Text = "No recommended Gripper";
            }
           
        }
        // GripperShow
        private void button5_Click(object sender, EventArgs e)
        {
            
            button7.Hide();
            button8.Hide();
            button9.Hide();
            button10.Show();
            draftVacuumGripper1.BringToFront();
           
        }
    }
}
