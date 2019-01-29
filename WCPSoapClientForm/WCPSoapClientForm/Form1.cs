using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace WCPSoapClientForm
{
    public partial class Form1 : Form
    {
        private readonly DataSet DSRes;
        public int[] ACc;
        public decimal[] AIc;
        public decimal[] ALc;
        public string DTc;
        public string CPCc;
        public int Dc;
        public decimal TWc; public int PrNal;
        public string GRZc; public string NSR;
        public string DSR; public string SrDSR;
        public string RMarshr; public decimal RM;
        public decimal LSR; public decimal WSR; public decimal HSR;
        public int KRPr; public int KOstPr;
        public decimal Hc;
        public decimal Lc;
        public decimal Wc;
        public string cstrU;
        public decimal IdPr;
        public string IdPrSTR;
        public string Wim;
        public Decimal NPR;
        public decimal[] IInt;
        public string VDocNum;
        public DateTime DDS;
        public Guid INPR1;
        public int Rrc;
        //public ServiceReference1.CheckRequestData b;

        public Form1()
        {

            InitializeComponent();
            DSRes = new DataSet();
        }

        private string StreamToString(Stream stream)
        {
            stream.Position = 0;
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                return reader.ReadToEnd();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var binding = new BasicHttpBinding();
            var endpoint = new EndpointAddress(new Uri(string.Format("http://{0}:5050/Service.asmx", "10.10.10.49"))); //Environment.MachineName))); //"192.168.20.30")));
            var serviceClient = new ServiceReference1.RASVSRClient(binding, endpoint);
            ServiceReference1.CheckRequestData request_send = new ServiceReference1.CheckRequestData()
            {
                AxlesCount = ACc ,//new int[] { 1, 2, 3 },
                AxlesInvervals = AIc,//new decimal[] { 1m, 2m, 3m },
                AxlesLoads = ALc,//new decimal[] { 1m, 2m, 3m },
                CheckDate = Convert.ToDateTime(DTc.ToString()),//DateTime.Now,
                CheckPointCode = CPCc.ToString(),//"001",
                Direction = Dc,//1,
                //Latitude = Convert.ToDecimal("123,5"),
                //Longitude = Convert.ToDecimal("127,5"),
                TotalWeight = TWc,//10m,
                VehicleRegNumber = GRZc,//"123ка77",
                TotalSize = new ServiceReference1.CheckRequestDataTotalSize()
                {
                    Height = Hc,//10m,
                    Length = Lc,//10m,
                    Width = Wc,//10m
                }
            };
            XmlSerializer formatter_input = new XmlSerializer(typeof(ServiceReference1.CheckRequestData));
            MemoryStream memoryStreamInput = new MemoryStream();
            formatter_input.Serialize(memoryStreamInput, request_send);
            textBox1.Text = StreamToString(memoryStreamInput);
            try
            {
                var rezRequest = serviceClient.Check(request_send);
                Rrc = rezRequest.Count;
                if (rezRequest.Count!=0)
                { 
                int INPR = 0;
                ConnectStr ResRegionSR = new ConnectStr();
                ResRegionSR.ConStr(1);
                cstrU = ResRegionSR.StP;
                MySqlConnection sqlConnectionT = new MySqlConnection(cstrU);
                //dataGridView1.DataSource = rezRequest;//ServiceReference1.CheckResultDataList;
                foreach (var b in rezRequest)//int i=0; i<rezRequest.Count; i++)
                {
                    //if (b.wr)
                    this.dataGridView1.Rows.Add(b.VehicleRegNumber.ToString(),
                        b.Resolution.DocumentNumber.ToString(),
                        b.Resolution.DocumentDateSign.ToString(),
                        b.DateFrom.ToString(),
                        b.DateTo.ToString(),                        
                        b.TripCount,
                        b.LeftTripCount,
                        b.Route.ToString(),
                        b.Dimensions.ToString(),
                        DecToStr(b.AxlesLoads),
                        b.FullWeight
                        );
                   
                        PrNal = b.RouteCheck.Code;
                        NSR = b.Resolution.DocumentNumber;
                        DSR = Convert.ToString(b.Resolution.DocumentDateSign);
                        SrDSR = Convert.ToString(b.DateTo);
                        RMarshr = b.Route;
                        RM = b.FullWeight;
                        KRPr = b.TripCount;
                        KOstPr = b.LeftTripCount;
                        LSR = b.Dimensions.Length;
                        WSR = b.Dimensions.Width;
                        HSR = b.Dimensions.Height;
                        //IdPrSTR = DateTime.Now.ToString("yyMMdd")+ IdPr.ToString() ;
                        // IdPr = Convert.ToDecimal(IdPrSTR.ToString());
                        INPR1 = Guid.NewGuid();
                        IdPrSTR = Convert.ToString(INPR1).Replace("-", "");

                        MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
                        cmd.CommandText = "INSERT INTO raptssprrazr "
                        + "("
                        + "idts, "
                        + "dateregsr, "
                        + "grzrasp, "
                        + "KemVid, "
                        + "VidPerevoz, "
                        + "GRZSR, "
                        + "NomSR, "
                        + "DateVidSR, "
                        + "SrokDeistvSR, "
                        + "RazrMarshr, "
                        + "RazrMassa, "
                        + "KolRazrPr, "
                        + "IspolzPR, "
                        + "LengthSR, "
                        + "WidthSR, "
                        + "HeightSR, "
                        + "NarushenMarshrSR, "
                        + "DateZapr, "
                        + "NomZapr) "
                        + "VALUES "
                        + "(" + IdPr + ", "
                        + "'" + b.DateFrom.ToString("o") + "', "
                        + "'" + GRZc + "', "
                        + "'ГБУ Севастопольский Автодор', "
                        + "'" + b.ShippingType + "', "
                        + "'" + b.VehicleRegNumber + "', "
                        + "'" + b.Resolution.DocumentNumber + "', "
                        + "'" + b.Resolution.DocumentDateSign.ToString("o") + "', "
                        + "'" + b.DateTo.ToString("o") + "', "
                        + "'" + b.Route + "', "
                        + "" + b.FullWeight + ", "
                        + "" + b.TripCount + ", "
                        + "" + b.LeftTripCount + ", "
                        + "" + b.Dimensions.Length + ", "
                        + "" + b.Dimensions.Width + ", "
                        + "" + b.Dimensions.Height + ", "
                        + "" + b.RouteCheck.Code + ", "
                        + "now(), "
                        + "'" + IdPrSTR + "');";
                        //Guid.NewGuid() 
                        cmd.Connection = sqlConnectionT;
                        if (sqlConnectionT.State == System.Data.ConnectionState.Closed)
                        { sqlConnectionT.Open(); }
                        //sqlConnectionT.Open();
                        cmd.ExecuteNonQuery();
                        /* sqlConnectionT.Close()*/
                        ;


                        //ConnectStr ResRegionSR = new ConnectStr();
                        //ResRegionSR.ConStr(1);
                        //cstrU = ResRegionSR.StP;
                        //MySqlConnection sqlConnectionT = new MySqlConnection(cstrU);

                        IInt = new decimal[b.AxlesInvervals.Length + 1];
                        IInt[0] = 0;
                        for (int iint = 0; iint < b.AxlesInvervals.Length; iint++)
                        { IInt[iint + 1] = b.AxlesInvervals[iint]; }
                        for (int iax = 0; iax < b.AxlesLoads.Length; iax++)
                        {

                            MySql.Data.MySqlClient.MySqlCommand cmd2 = new MySql.Data.MySqlClient.MySqlCommand();
                            cmd2.CommandText = "INSERT INTO rapsprazraxel( "
                            + "IDSR, "
                            + "NomAx, "
                            //+ "NomGr, "
                            + "MasAxSR, "
                            + "IntervalAxSR, "
                            + "SkatAxSR, "
                            + "CountRAxSR, "
                            + "Created, "
                            + "NSR) "
                            + "VALUES("
                            + "" + IdPrSTR + ", "
                            + "" + iax + ", "
                            //+ "DEFAULT, "
                            + "" + b.AxlesLoads[iax] + ", "
                            + "" + IInt[iax] + ", "
                            + "" + b.AxlesWeelsEx[iax] + ", "
                            + "" + b.AxlesWheels[iax] + ", "
                            + "now(), "
                            + "'" + b.Resolution.DocumentNumber + "'); ";
                            cmd2.Connection = sqlConnectionT;
                            if (sqlConnectionT.State == System.Data.ConnectionState.Closed)
                            { sqlConnectionT.Open(); }
                            //sqlConnectionT.Open();
                            cmd2.ExecuteNonQuery();
                        }
                        sqlConnectionT.Close();
                    }
               
                }            
                    else
                    {
                INPR1 = Guid.NewGuid();
                IdPrSTR = Convert.ToString(INPR1).Replace("-", "");
                    ConnectStr ResRegionSR = new ConnectStr();
                    ResRegionSR.ConStr(1);
                    cstrU = ResRegionSR.StP;
                    MySqlConnection sqlConnectionT = new MySqlConnection(cstrU);
                    MySql.Data.MySqlClient.MySqlCommand cmd3 = new MySql.Data.MySqlClient.MySqlCommand();
                cmd3.CommandText = "INSERT INTO raptssprrazr "
                + "("
                + "idts, "
                + "grzrasp, "
                + "DateZapr, "
                + "NomZapr) "
                + "VALUES "
                + "(" + IdPr + ", "
                + "'" + GRZc + "', "
                + "now(), "
                + "'" + IdPrSTR + "');";
                //Guid.NewGuid() 
                cmd3.Connection = sqlConnectionT;
                if (sqlConnectionT.State == System.Data.ConnectionState.Closed)
                { sqlConnectionT.Open(); }
                //sqlConnectionT.Open();
                cmd3.ExecuteNonQuery();
                /* sqlConnectionT.Close()*/
                ;
                sqlConnectionT.Close();
                }
                
            }
            catch (Exception ex){ }

        }
        private string DecToStr(decimal []Dax)
        {
            return String.Join("; ", Dax);
                    }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Rrc != 0)
            {
                int currentRow = dataGridView1.CurrentRow.Index; // номер строки, по которой кликнули
                VDocNum = dataGridView1[1, currentRow].Value.ToString(); //ID
                DDS = Convert.ToDateTime(dataGridView1[2, currentRow].Value.ToString());
                ConnectStr ResRegionSR = new ConnectStr();
                ResRegionSR.ConStr(1);
                cstrU = ResRegionSR.StP;
                MySqlConnection sqlConnectionT = new MySqlConnection(cstrU);
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
                cmd.CommandText = "UPDATE raptssprrazr SET PriznNal = 1 WHERE NomSR = '" + VDocNum + "' ;";
                cmd.Connection = sqlConnectionT;
                sqlConnectionT.Open();
                cmd.ExecuteNonQuery();
                sqlConnectionT.Close();


                var binding = new BasicHttpBinding();
                var endpoint = new EndpointAddress(new Uri(string.Format("http://{0}:5050/Service.asmx", "10.10.10.49"))); // "192.168.110.39"))); // ;Environment.MachineName))); // "192.168.20.30")));
                var serviceClient = new ServiceReference1.RASVSRClient(binding, endpoint);
                ServiceReference1.WriteOfTripDataRequest writeOfRequest = new ServiceReference1.WriteOfTripDataRequest()
                {
                    AxlesCount = ACc,//new int[] { 1, 2, 3 },
                    AxlesInvervals = AIc,//new decimal[] { 1m, 2m, 3m },
                    AxlesLoads = ALc,//new decimal[] { 1m, 2m, 3m },
                    TripDate = Convert.ToDateTime(DTc.ToString()),//DateTime.Now,
                    CheckPointCode = CPCc.ToString(),//"001",
                    Direction = Dc,//1,
                                   //Latitude = Convert.ToDecimal("123,5"),
                                   //Longitude = Convert.ToDecimal("127,5"),
                    TotalWeight = TWc,//10m,
                    DocumentDateSign = DDS,
                    DocumentNumber = VDocNum,
                    TotalSize = new ServiceReference1.CheckRequestDataTotalSize()
                    {
                        Height = Hc,//10m,
                        Length = Lc,//10m,
                        Width = Wc,//10m
                    }

                };
                using (MemoryStream memoryStreamInput = new MemoryStream())
                {
                    XmlSerializer formatter_input = new XmlSerializer(typeof(ServiceReference1.WriteOfTripDataRequest));
                    formatter_input.Serialize(memoryStreamInput, writeOfRequest);
                    textBox1.Text = StreamToString(memoryStreamInput);
                }
                try
                {
                    var rezRequest = serviceClient.WriteOfTrip(writeOfRequest);
                    using (MemoryStream memoryStreamOutput = new MemoryStream())
                    {
                        XmlSerializer formatter_output = new XmlSerializer(typeof(ServiceReference1.WriteOffAnswerData));
                        formatter_output.Serialize(memoryStreamOutput, rezRequest);
                        textBox1.Text += StreamToString(memoryStreamOutput);
                    }
                }
                catch (Exception ex) { }
            }
            else { this.Close(); }
        }
    }
}
