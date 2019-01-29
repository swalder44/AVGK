using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using System.Data.Common;
//using PdfSharp.Pdf;
//using PdfSharp.Drawing;
using System.Diagnostics;
using System.Xml.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;

namespace AVGK
{
    public partial class Form3 : Form
    {
        public struct names
        {
            public string massFact;
            public string BaseDistance;
            public string BaseNumber;
            public string massPrev;
            public string massSR;
            public string PDKmass;
            public string BaseDistanceSR;
            public string factPremission;
            public string massK;
            public string massPrevSR;
            public string massSign;
            public string groupNumber;
            public string skatnost;
            public string BaseDistancePrevSign;
            public string BaseDistanceNorm;
            public string LoadAxisPermission;
            public string DifferencePermissionFact;
            public string AxisIntervalsNorm;
            public string AxisIntervalsPermission;
            public string SignExcessIntervalAxis;

        }
        public string aaa;
        public Int64 NPicKR = 0;
        public int ColPicKR;
        public Bitmap Im; public Bitmap ImPl; Bitmap ImAlt; Bitmap SkS; Bitmap ImAlt1; Bitmap ImAlt2; Bitmap Im1; Bitmap Im2; Bitmap SkF; Bitmap SkT;
        public int iPic = 2;
        public System.IO.Stream[] Pic = new System.IO.Stream[10];
        public int PicCount;
        public string zLB;
        public Int64 IDpish;
        public Int64 IDW;
        public string PLN;
        public int ss;
        public string TSh = "";
        public Guid proverka;
        public string proverka2;
        public decimal proverka3;
        public string NRUB; public string FFFT;
        public int TypNar; public string TypNarTXT; public double PPRNAR; public int iNar; public double MAXPREV = 0; public double MAXPREVPROTC = 0;
        public double[] PrevNar = new double[40];//0-9 нагр на ось; 10-16 нагр на тел; 17 Общ масса; 18-20 габариты; 21 скорость, полоса, ограничения 25 Срок действия поверки
                                                 //26- Количество осей 27-одиночн/автопоезд 28 ТТС/КТС/ТКТС 29 наличие с/р 30 Ось/группа/общ.масса/длина/ширина/высота
                                                 //31-№оси/группы 32-превышение поПДК или по СР 33 - степень превышения (%,м) 34- часть статьи 1-11 35 - выезд на встречку/выезд на обочину 36 - доп часть ПДД
        public double PrevDlPr; public int NOG; public string CodNar;

        public string[] XDate = new string[39];
        public names[] names3 = new names[10];
        public string[] names1 = new string[10];
        public string[] names2 = new string[10];
        public DataSet DSPR = new DataSet();
        public Zapros zapros = new Zapros();
        public string IDSravn = "";
        Stream ms = null;
        //Stream mstil = null;
        Stream nz = null;
        Stream onz = null;
        public string FFF;
        public string FF;
        public int COs;
        public string D1; public string D2;
        public int Cl;
        public string WM;
        public string cstr;
        public string z;
        public string zLPR;
        public string di; public string dii;
        public string odi; public string odii;
        public int KnPriv;
        public int IDTSIsh; public int IDTSKon;
        public string NDI; public string NDII;
        public string OII; public string OIID;
        public string OGRZ;
        public string OKL;
        public string NLP;
        public string OlDat;
        public int chang;
        public int IDSV;
        Stream msdop = null;       // Stream mstildop = null;
        Stream nzdop = null; Stream onzdop = null;
        public int KGr = 1;
        public static double widh;
        public static int location;
        public static int locOpisOs;
        public double[] l = new double[10];
        public double[] D = new double[10]; ///Группа из скольки колес
        public double[] DoubO = new double[10];///Двойные скаты на какой оси
        public double[] TypO = new double[10];///Тип оси
        public double[] PDKO = new double[10];///PDK оси
        public double[] PDKTel = new double[10];///пдк тележки
        public string[] A1 = new string[260];///Для акта
        public string[] A2 = new string[260];///Для акта связаного
        public string[] Ch = new string[260];///Для акта
        public int a1i = 0;
        public int a2i = 0;
        public int GNach;
        public int GEnd;
        public int j;
        public int Fx;
        public string Sk;
        public int[,] KN = new int[2, 10];
        public int[,] KNn = new int[2, 10];
        public int[,] KNR = new int[2, 10];
        public int[] KNM = new int[9];
        public double[] G2 = new double[10];
        public double[] G3 = new double[10];
        public double[] G5 = new double[10];
        public double[] G6 = new double[10];
        public double[] G7 = new double[10];
        public double[] D111 = new double[10];
        public double D1_2 = 0; public double D2_3 = 0;
        public double D3_4 = 0; public double D4_5 = 0;
        public double D5_6 = 0; public double D6_7 = 0;
        public double D7_8 = 0; public double ObshMass = 0;
        public double ADNagr = 0;
        public double RasstOs = 0;
        public double DLINATS = 0;
        public double SHIRTS = 0;
        public double VISTS = 0;
        public int DO = 0;
        public int TypeO = 0;
        public int KolOs = 0;
        public int TTS = 0;
        public int FPR = 0;
        public int rowIndex = 0;
        public int kol = 0;
        public int currentRowLeft;
        public int IDKLLeft = 0;
        public int kol3;
        public int rowIndex3;

        public int[] AC;
        public decimal[] AI;
        public decimal[] AL;
        public string DT;
        public string CPC;
        public int Dc;
        public decimal TW;
        public string GRZ;
        public decimal H;
        public decimal L;
        public decimal W;
        //public double? L1 = null;
        //public double? L2 = null;
        //public double? L3 = null;
        //public double? L4 = null;
        //public double? L5 = null;
        //public double? L6 = null;
        //public double? L7 = null;
        //public double? L8 = null;
        public int i = 1;
        static System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
        public Image bin;
        //private int column;
        //private int row;
        public int ic;
        public int icO;
        public int icC;
        public int GrO;
        private MySqlConnection connection;
        public MySqlConnection connection1;
        public MySqlConnection connection2;
        public MySqlConnection connectionR;
        private MySqlDataAdapter mySqlDataAdapter;
        public string NamU;
        public int KolOsR;
        public string NarOb;
        public double[,] PDK = new double[7, 10];
        public double[,] PDKGR = new double[7, 10];
        public double[,] BetOs = new double[22, 10];
        public double NarOsM;
        public string NarOs;
        public double NarGRM;
        public string NarObMS;
        public string LPPR;
        public decimal Lpr;
        public decimal Hpr;
        public decimal Wpr;
        public Form3(Form2 ownerForm)
        {
            InitializeComponent();

            pictureBox40.Location = AutoScrollOffset;
            SelfRef = this;
        }
        public static Form3 SelfRef
        {
            get;
            set;
        }

        public bool OpenConnection() //// Открытие соединения
        { try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server. Contact administrator");
                        break;
                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                    default:
                        MessageBox.Show(ex.Message);
                        break;
                }
                return false;
            }
        }
        public bool CloseConnection() //// Закрытие соединения
        { try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        #region З А Г Р У З К А
        public Form3()
        { InitializeComponent(); }
        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet1.AllCamNapr". При необходимости она может быть перемещена или удалена.
            //this.allCamNaprTableAdapter.Fill(this.dataSet1.AllCamNapr);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet1.wims_det_r". При необходимости она может быть перемещена или удалена.
            //this.wims_det_rTableAdapter.Fill(this.dataSet1.wims_det_r);

            pictureBox40.BackColor = Color.Transparent;
            //label73.Text = "Расположение: " + label83.Text + ", рубеж : " + label144.Text;// + ", " + label67.Text;
            //alphaBlendTextBox10.Text = dataGridView11[0, 0].Value.ToString();
        }
        #endregion загрузка 
        internal void Form3_LoadPMonit(int IDTS, string NUs)//// загрузка формы уже с пользователем и проездом
        {
            NamU = NUs;
            label161.Text = NamU;
            //wims_det_rBindingSource.Filter = string.Format("id = '" + IDTS + "'");
            label144.Text = Convert.ToString(IDTS);
            label154.Text = Convert.ToString(IDTS);
            alphaBlendTextBox25.Text = Convert.ToString(IDTS);
            //alphaBlendTextBox10.Text = Convert.ToString(IDTS);
            this.Cursor = Cursors.Arrow;
            ZagrPr(IDTS);
            if ((XDate[31] == "True" || XDate[30] == "True" || XDate[2] == "True" || XDate[4] == "True" || XDate[3] == "True") && Im != null && TypNar > 0)//&& ImPl,ImAlt )
            { button4.Visible = true; button5.Visible = true; button6.Visible = true; button9.Visible = true;   }
            else if ((XDate[31] == "False" || XDate[30] == "False" || XDate[2] == "False" || XDate[4] == "False" || XDate[3] == "False"))
            { button4.Visible = false; button5.Visible = false; button6.Visible = false; button9.Visible = false; }
        }
        public void ZagrPr(int IDTS)
        { 
            #region /////////////////////////////////////////// ЛЕВАЯ ЧАСТЬ (ИНФО О ПРОЕЗДЕ)
            MySqlCommand command = new MySqlCommand();
            ConnectStr conStr = new ConnectStr();
            conStr.ConStr(1);
            Zapros zapros = new Zapros();
            string connectionString;
            connectionString = conStr.StP;//"Data source=localhost;UserId=root;Password=1q2w3e$R;database=camloc;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            zapros.ZaprAllCamNaprLO(IDTS);
            string z = zapros.commandStringTest;

            command.CommandText = z;// commandString;
            command.Connection = connection;
            MySqlDataReader reader;

            int NumberIter = 0;
            KNn = new int[2, 9];
            KN = new int[2, 9];
            BetOs = new double[32, 10];
            int i1 = 0;

            label162.Text = "0"; label161.Text = "0"; label160.Text = "0"; label159.Text = "0";
            label158.Text = "0"; label157.Text = "0"; label156.Text = "0"; label155.Text = "0";

            label153.Text = "0"; label152.Text = "0"; label151.Text = "0"; label150.Text = "0";
            label149.Text = "0"; label148.Text = "0"; label147.Text = "0"; label146.Text = "0";
            label145.Text = "0";

            label154.Text = "0";
            //label47.Text = "0";
            label171.Text = "0"; label170.Text = "0"; label169.Text = "0"; label168.Text = "0";
            label167.Text = "0"; label166.Text = "0"; label165.Text = "0"; label164.Text = "0";
            label163.Text = "0";

            try
            {
                command.Connection.Open();
                reader = command.ExecuteReader();
                double pos = 0;
                while (reader.Read())
                {
                    ///////////////////  BetOs[22,9]
                    //Index               -0
                    //Unit                -1
                    //Group               -2
                    //Position            -3
                    //Weight              -4
                    //WeightLeft          -5
                    //WeightRight         -6
                    //WeightLimit         -7
                    //WheelCount          -8
                    ////////FootprintWidthLeft  -9
                    ////////FootprintWidthRight -10
                    //IsOverweight        -9
                    //Speed               -10
                    //Credence            -11
                    //MeasurementStatus   -12
                    //вес с погрешностью
                    //разница ВсП и Лимита
                    //разница ВсП и Лимита в %
                    ///////////////////
                    #region/////////////// Проход по представлению от Бетамонта //
                    label144.Text = Convert.ToString(Convert.ToDouble(reader["Weight"]) / 1000);
                    label154.Text = Convert.ToString(Convert.ToDouble(reader["Length"]) / 100);
                    if (NumberIter == 0)
                    {
                        string io = Convert.ToString(Convert.ToInt32(reader["wheelCount"]) / 2);
                        label153.Text = io;//Convert.ToString(Convert.ToInt32(reader["wheelCount"]) / 2);
                        string iio = Convert.ToString(Convert.ToDouble(reader["weightAxel"]) / 1000);
                        label171.Text = iio;//Convert.ToString(Convert.ToDouble(reader["weightAxel"]) / 1000);
                        //XDate[0] = reader["IsOverweightPartial"].ToString();
                        BetOs[0, 0] = 0;
                        BetOs[1, 0] = Convert.ToDouble(reader["Unit"]);
                        BetOs[2, 0] = Convert.ToDouble(reader["Group"]);
                        BetOs[3, 0] = 0;
                        BetOs[4, 0] = Convert.ToDouble(reader["weightAxel"]);
                        BetOs[5, 0] = Convert.ToDouble(reader["weightleft"]);
                        BetOs[6, 0] = Convert.ToDouble(reader["weightright"]);
                        BetOs[7, 0] = Convert.ToDouble(reader["weightlimitAxel"]);
                        if (reader["wheelcount"] != null && Convert.ToDouble(reader["wheelcount"]) > 1)
                        { BetOs[8, 0] = Convert.ToDouble(reader["wheelcount"]) / 2; }
                        else
                        { BetOs[8, 0] = 1; }
                        if (reader["isoverweightAxel"].ToString() == "false")
                        { BetOs[9, 0] = 0; }
                        else { BetOs[9, 0] = 1; }
                        BetOs[10, 0] = Convert.ToDouble(reader["SpeedAxel"].ToString());//.Substring(5,9));
                        BetOs[11, 0] = Convert.ToDouble(reader["credenceAxel"]);
                        //BetOs[12, 0] = Convert.ToDouble(reader["measurementstatus"]);
                        BetOs[13, 0] = Convert.ToDouble(reader["weightAxel"]) - Convert.ToDouble(reader["weightAxel"]) / 100 * 10;
                        BetOs[14, 0] = (Convert.ToDouble(reader["weightAxel"]) - Convert.ToDouble(reader["weightAxel"]) / 100 * 10) - Convert.ToDouble(reader["weightlimitAxel"]);
                        BetOs[15, 0] = (Convert.ToDouble(reader["weightlimitAxel"]) / (Convert.ToDouble(reader["weightAxel"]) - Convert.ToDouble(reader["weightAxel"]) / 100 * 10)) * 100;
                        if (Convert.ToString(reader["Os1M"]) != null && Convert.ToString(reader["Os1M"]) != "" && Convert.ToString(reader["Os1M"]) != " ")
                        { BetOs[16, 0] = Convert.ToDouble(reader["Os1M"]); }
                        else { BetOs[16, 0] = 0; }
                        BetOs[17, 0] = 0;
                    }
                    if (NumberIter == 1)
                    {
                        label152.Text = Convert.ToString(Convert.ToInt32(reader["wheelCount"]) / 2);
                        label162.Text = Convert.ToString((Convert.ToDouble(reader["position"]) / 100) - pos);
                        l[1] = (Convert.ToDouble(reader["position"]) / 100) - pos;
                        pos = Convert.ToDouble(reader["position"]) / 100;
                        label170.Text = Convert.ToString(Convert.ToDouble(reader["weightAxel"]) / 1000);
                        D1_2 = l[1];
                        BetOs[0, 1] = 0;
                        BetOs[1, 1] = Convert.ToDouble(reader["Unit"]);
                        BetOs[2, 1] = Convert.ToDouble(reader["Group"]);
                        BetOs[3, 1] = l[1];
                        BetOs[4, 1] = Convert.ToDouble(reader["weightAxel"]);
                        BetOs[5, 1] = Convert.ToDouble(reader["weightleft"]);
                        BetOs[6, 1] = Convert.ToDouble(reader["weightright"]);
                        BetOs[7, 1] = Convert.ToDouble(reader["weightlimitAxel"]);
                        if (reader["wheelcount"] != null && Convert.ToDouble(reader["wheelcount"]) > 1)
                        { BetOs[8, 1] = Convert.ToDouble(reader["wheelcount"]) / 2; }
                        else
                        { BetOs[8, 1] = 1; }
                        if (reader["isoverweightAxel"].ToString() == "false")
                        { BetOs[9, 1] = 0; }
                        else { BetOs[9, 1] = 1; }
                        BetOs[10, 1] = Convert.ToDouble(reader["SpeedAxel"].ToString());
                        //BetOs[10, 1] = Convert.ToDouble(reader["SpeedAxel"].ToString().Substring(5, 9));
                        BetOs[11, 1] = Convert.ToDouble(reader["credenceAxel"]);
                        //BetOs[12, 1] = Convert.ToDouble(reader["measurementstatus"]);
                        BetOs[13, 1] = Convert.ToDouble(reader["weightAxel"]) - Convert.ToDouble(reader["weightAxel"]) / 100 * 10;
                        BetOs[14, 1] = (Convert.ToDouble(reader["weightAxel"]) - Convert.ToDouble(reader["weightAxel"]) / 100 * 10) - Convert.ToDouble(reader["weightlimitAxel"]);
                        BetOs[15, 1] = (Convert.ToDouble(reader["weightlimitAxel"]) / (Convert.ToDouble(reader["weightAxel"]) - Convert.ToDouble(reader["weightAxel"]) / 100 * 10)) * 100;
                        if (Convert.ToString(reader["Os2M"]) != null && Convert.ToString(reader["Os2M"]) != "" && Convert.ToString(reader["Os2M"]) != " ")
                        { BetOs[16, 1] = Convert.ToDouble(reader["Os2M"]); }
                        else { BetOs[16, 1] = 0; }
                        if (Convert.ToString(reader["AxInt1"]) != null && Convert.ToString(reader["AxInt1"]) != "" && Convert.ToString(reader["AxInt1"]) != " ")
                        { BetOs[17, 1] = Convert.ToDouble(reader["AxInt1"]); }
                        else { BetOs[17, 1] = 0; }
                    }
                    if (NumberIter == 2)
                    {
                        label151.Text = Convert.ToString(Convert.ToInt32(reader["wheelCount"]) / 2);
                        label161.Text = Convert.ToString((Convert.ToDouble(reader["position"]) / 100) - pos);
                        l[2] = (Convert.ToDouble(reader["position"]) / 100) - pos;
                        pos = Convert.ToDouble(reader["position"]) / 100;
                        //l[2] = Convert.ToDouble(reader["position"]) / 100;
                        label169.Text = Convert.ToString(Convert.ToDouble(reader["weightAxel"]) / 1000);
                        D2_3 = l[2];
                        BetOs[0, 2] = 0;
                        BetOs[1, 2] = Convert.ToDouble(reader["Unit"]);
                        BetOs[2, 2] = Convert.ToDouble(reader["Group"]);
                        BetOs[3, 2] = l[2];
                        BetOs[4, 2] = Convert.ToDouble(reader["weightAxel"]);
                        BetOs[5, 2] = Convert.ToDouble(reader["weightleft"]);
                        BetOs[6, 2] = Convert.ToDouble(reader["weightright"]);
                        BetOs[7, 2] = Convert.ToDouble(reader["weightlimitAxel"]);
                        if (reader["wheelcount"] != null && Convert.ToDouble(reader["wheelcount"]) > 1)
                        { BetOs[8, 2] = Convert.ToDouble(reader["wheelcount"]) / 2; }
                        else
                        { BetOs[8, 2] = 1; }
                        if (reader["isoverweightAxel"].ToString() == "false")
                        { BetOs[9, 2] = 0; }
                        else { BetOs[9, 2] = 1; }
                        BetOs[10, 2] = Convert.ToDouble(reader["SpeedAxel"].ToString());//.Substring(5, 9));
                        BetOs[11, 2] = Convert.ToDouble(reader["credenceAxel"]);
                        //BetOs[12, 2] = Convert.ToDouble(reader["measurementstatus"]);
                        BetOs[13, 2] = Convert.ToDouble(reader["weightAxel"]) - Convert.ToDouble(reader["weightAxel"]) / 100 * 10;
                        BetOs[14, 2] = (Convert.ToDouble(reader["weightAxel"]) - Convert.ToDouble(reader["weightAxel"]) / 100 * 10) - Convert.ToDouble(reader["weightlimitAxel"]);
                        BetOs[15, 2] = (Convert.ToDouble(reader["weightlimitAxel"]) / (Convert.ToDouble(reader["weightAxel"]) - Convert.ToDouble(reader["weightAxel"]) / 100 * 10)) * 100;
                        if (Convert.ToString(reader["Os3M"]) != null && Convert.ToString(reader["Os3M"]) != "" && Convert.ToString(reader["Os3M"]) != " ")
                        { BetOs[16, 2] = Convert.ToDouble(reader["Os3M"]); }
                        else { BetOs[16, 2] = 0; }
                        if (Convert.ToString(reader["AxInt2"]) != null && Convert.ToString(reader["AxInt2"]) != "" && Convert.ToString(reader["AxInt2"]) != " ")
                        { BetOs[17, 2] = Convert.ToDouble(reader["AxInt2"]); }
                        else { BetOs[17, 2] = 0; }
                    }
                    if (NumberIter == 3)
                    {
                        label150.Text = Convert.ToString(Convert.ToInt32(reader["wheelCount"]) / 2);
                        label160.Text = Convert.ToString((Convert.ToDouble(reader["position"]) / 100) - pos);
                        l[3] = (Convert.ToDouble(reader["position"]) / 100) - pos;
                        pos = Convert.ToDouble(reader["position"]) / 100;
                        //l[3] = Convert.ToDouble(reader["position"]) / 100;
                        label168.Text = Convert.ToString(Convert.ToDouble(reader["weightAxel"]) / 1000);
                        D3_4 = l[3];
                        BetOs[0, 3] = 0;
                        BetOs[1, 3] = Convert.ToDouble(reader["Unit"]);
                        BetOs[2, 3] = Convert.ToDouble(reader["Group"]);
                        BetOs[3, 3] = l[3];
                        BetOs[4, 3] = Convert.ToDouble(reader["weightAxel"]);
                        BetOs[5, 3] = Convert.ToDouble(reader["weightleft"]);
                        BetOs[6, 3] = Convert.ToDouble(reader["weightright"]);
                        BetOs[7, 3] = Convert.ToDouble(reader["weightlimitAxel"]);
                        if (reader["wheelcount"] != null && Convert.ToDouble(reader["wheelcount"]) > 1)
                        { BetOs[8, 3] = Convert.ToDouble(reader["wheelcount"]) / 2; }
                        else
                        { BetOs[8, 3] = 1; }
                        if (reader["isoverweightAxel"].ToString() == "false")
                        { BetOs[9, 3] = 0; }
                        else { BetOs[9, 3] = 1; }
                        BetOs[10, 3] = Convert.ToDouble(reader["SpeedAxel"].ToString());//.Substring(5, 9));
                        BetOs[11, 3] = Convert.ToDouble(reader["credenceAxel"]);
                        //BetOs[12, 3] = Convert.ToDouble(reader["measurementstatus"]);
                        BetOs[13, 3] = Convert.ToDouble(reader["weightAxel"]) - Convert.ToDouble(reader["weightAxel"]) / 100 * 10;
                        BetOs[14, 3] = (Convert.ToDouble(reader["weightAxel"]) - Convert.ToDouble(reader["weightAxel"]) / 100 * 10) - Convert.ToDouble(reader["weightlimitAxel"]);
                        BetOs[15, 3] = (Convert.ToDouble(reader["weightlimitAxel"]) / (Convert.ToDouble(reader["weightAxel"]) - Convert.ToDouble(reader["weightAxel"]) / 100 * 10)) * 100;
                        if (Convert.ToString(reader["Os4M"]) != null && Convert.ToString(reader["Os4M"]) != "" && Convert.ToString(reader["Os4M"]) != " ")
                        { BetOs[16, 3] = Convert.ToDouble(reader["Os4M"]); }
                        else { BetOs[16, 3] = 0; }
                        if (Convert.ToString(reader["AxInt3"]) != null && Convert.ToString(reader["AxInt3"]) != "" && Convert.ToString(reader["AxInt3"]) != " ")
                        { BetOs[17, 3] = Convert.ToDouble(reader["AxInt3"]); }
                        else { BetOs[17, 3] = 0; }
                    }
                    if (NumberIter == 4)
                    {
                        label149.Text = Convert.ToString(Convert.ToInt32(reader["wheelCount"]) / 2);
                        label159.Text = Convert.ToString((Convert.ToDouble(reader["position"]) / 100) - pos);
                        l[4] = (Convert.ToDouble(reader["position"]) / 100) - pos;
                        pos = Convert.ToDouble(reader["position"]) / 100;
                        //l[4] = Convert.ToDouble(reader["position"]) / 100;
                        label167.Text = Convert.ToString(Convert.ToDouble(reader["weightAxel"]) / 1000);
                        D4_5 = l[4];
                        BetOs[0, 4] = 0;
                        BetOs[1, 4] = Convert.ToDouble(reader["Unit"]);
                        BetOs[2, 4] = Convert.ToDouble(reader["Group"]);
                        BetOs[3, 4] = l[4];
                        BetOs[4, 4] = Convert.ToDouble(reader["weightAxel"]);
                        BetOs[5, 4] = Convert.ToDouble(reader["weightleft"]);
                        BetOs[6, 4] = Convert.ToDouble(reader["weightright"]);
                        BetOs[7, 4] = Convert.ToDouble(reader["weightlimitAxel"]);
                        if (reader["wheelcount"] != null && Convert.ToDouble(reader["wheelcount"]) > 1)
                        { BetOs[8, 4] = Convert.ToDouble(reader["wheelcount"]) / 2; }
                        else
                        { BetOs[8, 4] = 1; }
                        if (reader["isoverweightAxel"].ToString() == "false")
                        { BetOs[9, 4] = 0; }
                        else { BetOs[9, 4] = 1; }
                        BetOs[10, 4] = Convert.ToDouble(reader["SpeedAxel"].ToString().Substring(5, 9));
                        BetOs[11, 4] = Convert.ToDouble(reader["credenceAxel"]);
                        //BetOs[12, 4] = Convert.ToDouble(reader["measurementstatus"]);
                        BetOs[13, 4] = Convert.ToDouble(reader["weightAxel"]) - Convert.ToDouble(reader["weightAxel"]) / 100 * 10;
                        BetOs[14, 4] = (Convert.ToDouble(reader["weightAxel"]) - Convert.ToDouble(reader["weightAxel"]) / 100 * 10) - Convert.ToDouble(reader["weightlimitAxel"]);
                        BetOs[15, 4] = (Convert.ToDouble(reader["weightlimitAxel"]) / (Convert.ToDouble(reader["weightAxel"]) - Convert.ToDouble(reader["weightAxel"]) / 100 * 10)) * 100;
                        if (Convert.ToString(reader["Os5M"]) != null && Convert.ToString(reader["Os5M"]) != "" && Convert.ToString(reader["Os5M"]) != " ")
                        { BetOs[16, 4] = Convert.ToDouble(reader["Os5M"]); }
                        else { BetOs[16, 4] = 0; }
                        if (Convert.ToString(reader["AxInt4"]) != null && Convert.ToString(reader["AxInt4"]) != "" && Convert.ToString(reader["AxInt4"]) != " ")
                        { BetOs[17, 4] = Convert.ToDouble(reader["AxInt4"]); }
                        else { BetOs[17, 4] = 0; }
                    }
                    if (NumberIter == 5)
                    {
                        label148.Text = Convert.ToString(Convert.ToInt32(reader["wheelCount"]) / 2);
                        label158.Text = Convert.ToString((Convert.ToDouble(reader["position"]) / 100) - pos);
                        l[5] = (Convert.ToDouble(reader["position"]) / 100) - pos;
                        pos = Convert.ToDouble(reader["position"]) / 100;
                        //l[5] = Convert.ToDouble(reader["position"]) / 100;
                        label166.Text = Convert.ToString(Convert.ToDouble(reader["weightAxel"]) / 1000);
                        D5_6 = l[5];
                        BetOs[0, 5] = 0;
                        BetOs[1, 5] = Convert.ToDouble(reader["Unit"]);
                        BetOs[2, 5] = Convert.ToDouble(reader["Group"]);
                        BetOs[3, 5] = l[5];
                        BetOs[4, 5] = Convert.ToDouble(reader["weightAxel"]);
                        BetOs[5, 5] = Convert.ToDouble(reader["weightleft"]);
                        BetOs[6, 5] = Convert.ToDouble(reader["weightright"]);
                        BetOs[7, 5] = Convert.ToDouble(reader["weightlimitAxel"]);
                        if (reader["wheelcount"] != null && Convert.ToDouble(reader["wheelcount"]) > 1)
                        { BetOs[8, 5] = Convert.ToDouble(reader["wheelcount"]) / 2; }
                        else
                        { BetOs[8, 5] = 1; }
                        if (reader["isoverweightAxel"].ToString() == "false")
                        { BetOs[9, 5] = 0; }
                        else { BetOs[9, 5] = 1; }
                        BetOs[10, 5] = Convert.ToDouble(reader["SpeedAxel"].ToString().Substring(5, 9));
                        BetOs[11, 5] = Convert.ToDouble(reader["credenceAxel"]);
                        //BetOs[12, 5] = Convert.ToDouble(reader["measurementstatus"]);
                        BetOs[13, 5] = Convert.ToDouble(reader["weightAxel"]) - Convert.ToDouble(reader["weightAxel"]) / 100 * 10;
                        BetOs[14, 5] = (Convert.ToDouble(reader["weightAxel"]) - Convert.ToDouble(reader["weightAxel"]) / 100 * 10) - Convert.ToDouble(reader["weightlimitAxel"]);
                        BetOs[15, 5] = (Convert.ToDouble(reader["weightlimitAxel"]) / (Convert.ToDouble(reader["weightAxel"]) - Convert.ToDouble(reader["weightAxel"]) / 100 * 10)) * 100;
                        if (Convert.ToString(reader["Os6M"]) != null && Convert.ToString(reader["Os6M"]) != "" && Convert.ToString(reader["Os6M"]) != " ")
                        { BetOs[16, 5] = Convert.ToDouble(reader["Os6M"]); }
                        else { BetOs[16, 5] = 0; }
                        if (Convert.ToString(reader["AxInt5"]) != null && Convert.ToString(reader["AxInt5"]) != "" && Convert.ToString(reader["AxInt5"]) != " ")
                        { BetOs[17, 5] = Convert.ToDouble(reader["AxInt5"]); }
                        else { BetOs[17, 5] = 0; }
                    }
                    if (NumberIter == 6)
                    {
                        label147.Text = Convert.ToString(Convert.ToInt32(reader["wheelCount"]) / 2);
                        label157.Text = Convert.ToString((Convert.ToDouble(reader["position"]) / 100) - pos);
                        l[6] = (Convert.ToDouble(reader["position"]) / 100) - pos;
                        pos = Convert.ToDouble(reader["position"]) / 100;
                        //l[6] = Convert.ToDouble(reader["position"]) / 100;
                        label165.Text = Convert.ToString(Convert.ToDouble(reader["weightAxel"]) / 1000);
                        D6_7 = l[6];
                        BetOs[0, 6] = 0;
                        BetOs[1, 6] = Convert.ToDouble(reader["Unit"]);
                        BetOs[2, 6] = Convert.ToDouble(reader["Group"]);
                        BetOs[3, 6] = l[6];
                        BetOs[4, 6] = Convert.ToDouble(reader["weightAxel"]);
                        BetOs[5, 6] = Convert.ToDouble(reader["weightleft"]);
                        BetOs[6, 6] = Convert.ToDouble(reader["weightright"]);
                        BetOs[7, 6] = Convert.ToDouble(reader["weightlimitAxel"]);
                        if (reader["wheelcount"] != null && Convert.ToDouble(reader["wheelcount"]) > 1)
                        { BetOs[8, 6] = Convert.ToDouble(reader["wheelcount"]) / 2; }
                        else
                        { BetOs[8, 6] = 1; }
                        if (reader["isoverweightAxel"].ToString() == "false")
                        { BetOs[9, 6] = 0; }
                        else { BetOs[9, 6] = 1; }
                        BetOs[10, 6] = Convert.ToDouble(reader["SpeedAxel"].ToString());//.Substring(5, 9));
                        BetOs[11, 6] = Convert.ToDouble(reader["credenceAxel"]);
                        //BetOs[12, 6] = Convert.ToDouble(reader["measurementstatus"]);
                        BetOs[13, 6] = Convert.ToDouble(reader["weightAxel"]) - Convert.ToDouble(reader["weightAxel"]) / 100 * 10;
                        BetOs[14, 6] = (Convert.ToDouble(reader["weightAxel"]) - Convert.ToDouble(reader["weightAxel"]) / 100 * 10) - Convert.ToDouble(reader["weightlimitAxel"]);
                        BetOs[15, 6] = (Convert.ToDouble(reader["weightlimitAxel"]) / (Convert.ToDouble(reader["weightAxel"]) - Convert.ToDouble(reader["weightAxel"]) / 100 * 10)) * 100;
                        if (Convert.ToString(reader["Os7M"]) != null && Convert.ToString(reader["Os7M"]) != "" && Convert.ToString(reader["Os7M"]) != " ")
                        { BetOs[16, 6] = Convert.ToDouble(reader["Os7M"]); }
                        else { BetOs[16, 6] = 0; }
                        if (Convert.ToString(reader["AxInt6"]) != null && Convert.ToString(reader["AxInt6"]) != "" && Convert.ToString(reader["AxInt6"]) != " ")
                        { BetOs[17, 6] = Convert.ToDouble(reader["AxInt6"]); }
                        else { BetOs[17, 6] = 0; }
                    }
                    if (NumberIter == 7)
                    {
                        label146.Text = Convert.ToString(Convert.ToInt32(reader["wheelCount"]) / 2);
                        label156.Text = Convert.ToString((Convert.ToDouble(reader["position"]) / 100) - pos);
                        l[7] = (Convert.ToDouble(reader["position"]) / 100) - pos;
                        pos = Convert.ToDouble(reader["position"]) / 100;
                        //l[7] = Convert.ToDouble(reader["position"]) / 100;
                        label164.Text = Convert.ToString(Convert.ToDouble(reader["weightAxel"]) / 1000);
                        D7_8 = l[7];
                        BetOs[0, 7] = 0;
                        BetOs[1, 7] = Convert.ToDouble(reader["Unit"]);
                        BetOs[2, 7] = Convert.ToDouble(reader["Group"]);
                        BetOs[3, 7] = l[7];
                        BetOs[4, 7] = Convert.ToDouble(reader["weightAxel"]);
                        BetOs[5, 7] = Convert.ToDouble(reader["weightleft"]);
                        BetOs[6, 7] = Convert.ToDouble(reader["weightright"]);
                        BetOs[7, 7] = Convert.ToDouble(reader["weightlimitAxel"]);
                        if (reader["wheelcount"] != null && Convert.ToDouble(reader["wheelcount"]) > 1)
                        { BetOs[8, 7] = Convert.ToDouble(reader["wheelcount"]) / 2; }
                        else
                        { BetOs[8, 7] = 1; }
                        if (reader["isoverweightAxel"].ToString() == "false")
                        { BetOs[9, 7] = 0; }
                        else { BetOs[9, 7] = 1; }
                        BetOs[10, 7] = Convert.ToDouble(reader["SpeedAxel"].ToString());//.Substring(5, 9));
                        BetOs[11, 7] = Convert.ToDouble(reader["credenceAxel"]);
                        //BetOs[12, 7] = Convert.ToDouble(reader["measurementstatus"]);
                        BetOs[13, 7] = Convert.ToDouble(reader["weightAxel"]) - Convert.ToDouble(reader["weightAxel"]) / 100 * 10;
                        BetOs[14, 7] = (Convert.ToDouble(reader["weightAxel"]) - Convert.ToDouble(reader["weightAxel"]) / 100 * 10) - Convert.ToDouble(reader["weightlimitAxel"]);
                        BetOs[15, 7] = (Convert.ToDouble(reader["weightlimitAxel"]) / (Convert.ToDouble(reader["weightAxel"]) - Convert.ToDouble(reader["weightAxel"]) / 100 * 10)) * 100;
                        if (Convert.ToString(reader["Os8M"]) != null && Convert.ToString(reader["Os8M"]) != "" && Convert.ToString(reader["Os8M"]) != " ")
                        { BetOs[16, 7] = Convert.ToDouble(reader["Os8M"]); }
                        else { BetOs[16, 7] = 0; }
                        if (Convert.ToString(reader["AxInt7"]) != null && Convert.ToString(reader["AxInt7"]) != "" && Convert.ToString(reader["AxInt7"]) != " ")
                        { BetOs[17, 7] = Convert.ToDouble(reader["AxInt7"]); }
                        else { BetOs[17, 7] = 0; }
                    }
                    if (NumberIter == 8)
                    {
                        label145.Text = Convert.ToString(Convert.ToInt32(reader["wheelCount"]) / 2);
                        label155.Text = Convert.ToString((Convert.ToDouble(reader["position"]) / 100) - pos);
                        l[8] = (Convert.ToDouble(reader["position"]) / 100) - pos;
                        pos = Convert.ToDouble(reader["position"]) / 100;
                        label163.Text = Convert.ToString(Convert.ToDouble(reader["weightAxel"]) / 1000);
                        BetOs[0, 8] = 0;
                        BetOs[1, 8] = Convert.ToDouble(reader["Unit"]);
                        BetOs[2, 8] = Convert.ToDouble(reader["Group"]);
                        BetOs[3, 8] = l[8];
                        BetOs[4, 8] = Convert.ToDouble(reader["weightAxel"]);
                        BetOs[5, 8] = Convert.ToDouble(reader["weightleft"]);
                        BetOs[6, 8] = Convert.ToDouble(reader["weightright"]);
                        BetOs[7, 8] = Convert.ToDouble(reader["weightlimitAxel"]);
                        if (reader["wheelcount"] != null && Convert.ToDouble(reader["wheelcount"]) > 1)
                        { BetOs[8, 8] = Convert.ToDouble(reader["wheelcount"]) / 2; }
                        else
                        { BetOs[8, 8] = 1; }
                        if (reader["isoverweightAxel"].ToString() == "false")
                        { BetOs[9, 8] = 0; }
                        else { BetOs[9, 8] = 1; }
                        BetOs[10, 8] = Convert.ToDouble(reader["SpeedAxel"].ToString());//.Substring(5, 9));
                        BetOs[11, 8] = Convert.ToDouble(reader["credenceAxel"]);
                        //BetOs[12, 8] = Convert.ToDouble(reader["measurementstatus"]);
                        BetOs[13, 8] = Convert.ToDouble(reader["weightAxel"]) - Convert.ToDouble(reader["weightAxel"]) / 100 * 10;
                        BetOs[14, 8] = (Convert.ToDouble(reader["weightAxel"]) - Convert.ToDouble(reader["weightAxel"]) / 100 * 10) - Convert.ToDouble(reader["weightlimitAxel"]);
                        BetOs[15, 8] = (Convert.ToDouble(reader["weightlimitAxel"]) / (Convert.ToDouble(reader["weightAxel"]) - Convert.ToDouble(reader["weightAxel"]) / 100 * 10)) * 100;
                        if (Convert.ToString(reader["Os9M"]) != null && Convert.ToString(reader["Os9M"]) != "" && Convert.ToString(reader["Os9M"]) != " ")
                        { BetOs[16, 8] = Convert.ToDouble(reader["Os9M"]); }
                        else { BetOs[16, 8] = 0; }
                        if (Convert.ToString(reader["AxInt8"]) != null && Convert.ToString(reader["AxInt8"]) != "" && Convert.ToString(reader["AxInt8"]) != " ")
                        { BetOs[17, 8] = Convert.ToDouble(reader["AxInt8"]); }
                        else { BetOs[17, 8] = 0; }
                    }


                    KNn[0, i1] = Convert.ToInt32(reader["group"]);
                    i1 = i1 + 1;
                    TSh = TSh + Convert.ToString(reader["group"]);
                    NumberIter = NumberIter + 1;

                    IDW = Convert.ToInt64(reader["ID_wim"].ToString());
                    PLN = reader["PlatformId"].ToString();
                    IDpish = Convert.ToInt64(reader["ID_wim"]);
                    #endregion///////////////////////////////////////////////////


                    #region //////////////////////////////////////////////        Заполнение переменных для рисунка  осей             /////////////////////////////////
                    NPicKR = Convert.ToInt64(reader["Class3"]);
                    ColPicKR = Convert.ToInt32(reader["ClassScheme3"]);
                    KolOs = Convert.ToInt32(reader["AxleCount"].ToString());
                    ObshMass = Convert.ToInt32(reader["Weight"].ToString());
                    alphaBlendTextBox13.Text = Convert.ToString(Math.Round(Convert.ToDouble(reader["AxleCount"].ToString())));
                    alphaBlendTextBox11.Text = Convert.ToString(Math.Round(Convert.ToDouble(reader["Class"].ToString())));
                    label18.Visible = true;
                    label18.Text = reader["PlatformId"].ToString();
                    if (Convert.ToInt64(reader["PlatformId"].ToString()) == 2952855555)
                    { NRUB = "PK2"; }
                    else { NRUB = "PK1"; }
                    maskedTextBox1.Text = reader["Plate"].ToString();
                    alphaBlendTextBox1.Text = reader["Plate"].ToString();
                    alphaBlendTextBox25.Text = reader["ID"].ToString();
                    alphaBlendTextBox80.Text = reader["Speed"].ToString();
                    alphaBlendTextBox13.Text = reader["AxleCount"].ToString();
                    alphaBlendTextBox26.Text = reader["datepr"].ToString().Substring(0, 10);
                    alphaBlendTextBox33.Text = reader["timepr"].ToString();
                    alphaBlendTextBox107.Text = reader["Created"].ToString();
                    dateTimePicker1.Value = Convert.ToDateTime(reader["Created"].ToString()).AddHours(-1);
                    dateTimePicker2.Value = Convert.ToDateTime(reader["Created"].ToString()).AddHours(+1);
                    Lpr = Convert.ToDecimal(reader["Length"].ToString());
                    Hpr = Convert.ToDecimal(reader["Width"].ToString());
                    Wpr = Convert.ToDecimal(reader["Height"].ToString());
                    Cl = Convert.ToInt32(reader["Class"].ToString());
                    XDate[0] = reader["IsOverweightPartial"].ToString();
                    XDate[1] = reader["IsOverweight"].ToString();
                    XDate[2] = reader["IsExceededLength"].ToString();
                    XDate[3] = reader["IsExceededWidth"].ToString();
                    XDate[4] = reader["IsExceededHeight"].ToString();
                    label19.Text = "Запись о проезде изменена " + reader["DateChang"].ToString() + ".";
                    label21.Text = reader["DateChang"].ToString();
                    label22.Text = reader["NameUs"].ToString();
                    label24.Text = reader["OldGRZ"].ToString();
                    label26.Text = reader["OldIDPR"].ToString();
                    label28.Text = reader["DateChang"].ToString();
                    label84.Text = reader["Plate"].ToString();
                    alphaBlendTextBox53.Text = reader["nameapvk"].ToString();//Наименование комплекса
                    alphaBlendTextBox63.Text = reader["Vladel"].ToString();//Владелец комплекса
                    alphaBlendTextBox54.Text = reader["TipSI"].ToString();//Тип СИ комплекса
                    alphaBlendTextBox55.Text = reader["Model"].ToString();//Марка и модель комплекса
                    alphaBlendTextBox56.Text = reader["sernum"].ToString();//Заводской № комплекса
                    if (Convert.ToInt64(reader["kodapvk"].ToString())== 2952855555)
                    { alphaBlendTextBox58.Text = "2920002"; }
                    else if(Convert.ToInt64(reader["kodapvk"].ToString()) == 2952855553)
                    { alphaBlendTextBox58.Text = "2920001"; }
                    else 
                    { alphaBlendTextBox58.Text = reader["kodapvk"].ToString(); }

                        //alphaBlendTextBox58.Text = reader["kodapvk"].ToString();//Код комплекса
                    alphaBlendTextBox57.Text = reader["NomSvidTipaSI"].ToString();//№ свид.типа комплекса
                    alphaBlendTextBox60.Text = reader["DateVidSTSI"].ToString();//Дата выд СТК № комплекса
                    alphaBlendTextBox59.Text = reader["RegNomSTSI"].ToString();//Рег№ СТК комплекса
                    alphaBlendTextBox62.Text = reader["NomSPSI"].ToString();//№ свид.о поверке комплекса
                    alphaBlendTextBox61.Text = reader["DateVidSPSI"].ToString();//Дата выд СПК № комплекса
                    alphaBlendTextBox64.Text = reader["SrokSPSI"].ToString();//Срок СПК комплекса
                    alphaBlendTextBox29.Text = reader["namead"].ToString();//№ и назван дороги
                    alphaBlendTextBox32.Text = reader["ad_znachen"].ToString();//значение дороги
                    alphaBlendTextBox103.Text = reader["CheckPointCode"].ToString();//уникальный код комплекса
                    alphaBlendTextBox104.Text = reader["KodNapr"].ToString();//код направления
                    alphaBlendTextBox105.Text = reader["shir"].ToString();//код направления
                    alphaBlendTextBox106.Text = reader["dolg"].ToString();//код направления
                    alphaBlendTextBox35.Text = reader["dislocationapvk"].ToString();//Дислокация дороги
                    alphaBlendTextBox31.Text = "D: " + reader["dolg"].ToString() + " ; Sh: " + reader["shir"].ToString();//Географ координаты дороги
                    alphaBlendTextBox65.Text = reader["partad"].ToString();//Контролируемый участок дороги
                    alphaBlendTextBox30.Text = reader["namenapr"].ToString();//Направление дороги
                    alphaBlendTextBox34.Text = reader["npolos"].ToString();//№ полосы дороги
                    alphaBlendTextBox66.Text = reader["maxosnagr"].ToString();//Макс ос. нагр. дороги
                    //// ПО С/РАЗР ДАТА И НОМЕР ЗАПРОСА
                    alphaBlendTextBox109.Text = reader["DateZapr"].ToString();
                    alphaBlendTextBox108.Text = reader["NomZapr"].ToString();

                    if (Convert.ToDateTime(reader["SrokSPSI"].ToString()) >= DateTime.Now)
                    { PrevNar[25] = 1; }
                    else { PrevNar[25] = 0; }
                    PrevNar[26] = Convert.ToInt32(reader["AxleCount"].ToString());


                    if (reader["maxosnagr"].ToString() == "6")
                    { XDate[5] = "1"; }
                    else if (reader["maxosnagr"].ToString() == "10")
                    { XDate[5] = "2"; }
                    else if (reader["maxosnagr"].ToString() == "11.5")//|| reader["maxosnagr"].ToString() == "11,5")
                    { XDate[5] = "3"; }

                    if (reader["SpeedRubej"].ToString() == "0")
                    { XDate[6] = "";
                        XDate[7] = "0";
                        XDate[8] = "False";
                    }
                    if (reader["SpeedRubej"].ToString() != "0")
                    {
                        XDate[6] = reader["SpeedRubej"].ToString();
                        if (Convert.ToDouble(reader["Speed"].ToString()) - Convert.ToDouble(reader["SpeedRubej"].ToString()) > 0)
                        {
                            XDate[7] = Convert.ToString(Convert.ToDouble(reader["Speed"].ToString()) - Convert.ToDouble(reader["SpeedRubej"].ToString()));
                            XDate[8] = "True";
                        }

                        if (Convert.ToDouble(reader["Speed"].ToString()) - Convert.ToDouble(reader["SpeedRubej"].ToString()) <= 0)
                        {
                            XDate[7] = "0";
                            XDate[8] = "False";
                        }
                    }
                    /////////////////////// Длина превыш
                    //if (Convert.ToDouble(alphaBlendTextBox37.Text.ToString()) - Convert.ToDouble(alphaBlendTextBox41.Text.ToString()) > 0)
                    //{
                    //    XDate[9] = Convert.ToString(Convert.ToDouble(alphaBlendTextBox37.Text.ToString()) - Convert.ToDouble(alphaBlendTextBox41.Text.ToString()));
                    //   // XDate[10] = "True";
                    //}
                    //if (Convert.ToDouble(alphaBlendTextBox37.Text.ToString()) - Convert.ToDouble(alphaBlendTextBox41.Text.ToString()) <= 0)
                    //{
                    //    XDate[9] = "0";
                    //    //XDate[8] = "False";
                    //}
                    //////////////////// Ширина превыш
                    //if (Convert.ToDouble(alphaBlendTextBox43.Text.ToString()) - Convert.ToDouble(alphaBlendTextBox44.Text.ToString()) > 0)
                    //{
                    //    XDate[10] = Convert.ToString(Convert.ToDouble(alphaBlendTextBox43.Text.ToString()) - Convert.ToDouble(alphaBlendTextBox44.Text.ToString()));
                    //    // XDate[10] = "True";
                    //}
                    //if (Convert.ToDouble(alphaBlendTextBox43.Text.ToString()) - Convert.ToDouble(alphaBlendTextBox44.Text.ToString()) <= 0)
                    //{
                    //    XDate[10] = "0";
                    //    //XDate[8] = "False";
                    //}
                    /////////////////// Высота превыш
                    //if (Convert.ToDouble(alphaBlendTextBox48.Text.ToString()) - Convert.ToDouble(alphaBlendTextBox47.Text.ToString()) > 0)
                    //{
                    //    XDate[11] = Convert.ToString(Convert.ToDouble(alphaBlendTextBox48.Text.ToString()) - Convert.ToDouble(alphaBlendTextBox47.Text.ToString()));
                    //    // XDate[10] = "True";
                    //}
                    //if (Convert.ToDouble(alphaBlendTextBox48.Text.ToString()) - Convert.ToDouble(alphaBlendTextBox47.Text.ToString()) <= 0)
                    //{
                    //    XDate[11] = "0";
                    //    //XDate[8] = "False";
                    //}
                    ///////////////////////////////// Данные о СР
                    if (reader["PriznNal"].ToString() == "0" || reader["PriznNal"].ToString() == "False" || reader["PriznNal"].ToString() == null || reader["PriznNal"].ToString() == "")
                    {
                        XDate[12] = "False";
                        alphaBlendTextBox69.Text = "Не выдавалось";// XDate[12].ToString();
                        PrevNar[29] = 1;
                        XDate[13] = "";

                        XDate[14] = "";
                        XDate[15] = "";
                        XDate[16] = "";
                        XDate[17] = "";
                        XDate[18] = "";
                        XDate[19] = "0";
                        XDate[20] = "0";
                        XDate[21] = "0";
                    }
                    else
                    {
                        XDate[12] = reader["PriznNal"].ToString();
                        alphaBlendTextBox69.Text = "Выдано";// XDate[12].ToString();
                        PrevNar[29] = 2;
                        XDate[13] = reader["NomSR"].ToString();
                        alphaBlendTextBox74.Text = XDate[13].ToString();
                        XDate[14] = reader["dateregsr"].ToString();
                        alphaBlendTextBox71.Text = reader["VidPerevoz"].ToString();
                        alphaBlendTextBox72.Text = reader["GRZSR"].ToString();
                        alphaBlendTextBox76.Text = reader["RazrMarshr"].ToString();
                        alphaBlendTextBox77.Text = reader["OsjbUslDvSR"].ToString();
                        alphaBlendTextBox78.Text = reader["KolRazrPr"].ToString();
                        alphaBlendTextBox79.Text = reader["IspolzPR"].ToString();

                        XDate[15] = reader["KemVid"].ToString();
                        alphaBlendTextBox70.Text = XDate[15].ToString();
                        XDate[16] = reader["DateVidSR"].ToString();
                        alphaBlendTextBox73.Text = XDate[16].ToString();
                        XDate[17] = reader["SrokDeistvSR"].ToString();
                        alphaBlendTextBox75.Text = XDate[17].ToString();
                        XDate[18] = reader["NarushenMarshrSR"].ToString();
                        XDate[19] = reader["LengthSR"].ToString();
                        XDate[20] = reader["WidthSR"].ToString();
                        XDate[21] = reader["HeightSR"].ToString();
                    }
                    XDate[25] = ((Convert.ToDouble(reader["Weight"].ToString()) - (Convert.ToDouble(reader["Weight"].ToString()) / 100 * 5)) / 1000).ToString();
                    if (reader["RazrMassa"].ToString() != null && reader["RazrMassa"].ToString() != "" && reader["RazrMassa"].ToString() != " ")
                    { XDate[26] = reader["RazrMassa"].ToString(); }
                    else { XDate[26] = "0"; }
                    /////////////////////// Длина превыш
                    //if (Convert.ToDouble(alphaBlendTextBox37.Text.ToString()) - Convert.ToDouble(XDate[19].ToString()) > 0)
                    //{
                    //    XDate[22] = Convert.ToString(Convert.ToDouble(alphaBlendTextBox37.Text.ToString()) - Convert.ToDouble(XDate[19].ToString()));
                    //    // XDate[10] = "True";
                    //}
                    //if (Convert.ToDouble(alphaBlendTextBox37.Text.ToString()) - Convert.ToDouble(XDate[19].ToString()) <= 0)
                    //{
                    //    XDate[22] = "0";
                    //    //XDate[8] = "False";
                    //}
                    //////////////////// Ширина превыш
                    //if (Convert.ToDouble(alphaBlendTextBox43.Text.ToString()) - Convert.ToDouble(XDate[20].ToString()) > 0)
                    //{
                    //    XDate[23] = Convert.ToString(Convert.ToDouble(alphaBlendTextBox43.Text.ToString()) - Convert.ToDouble(XDate[20].ToString()));
                    //    // XDate[10] = "True";
                    //}
                    //if (Convert.ToDouble(alphaBlendTextBox43.Text.ToString()) - Convert.ToDouble(XDate[20].ToString()) <= 0)
                    //{
                    //    XDate[23] = "0";
                    //    //XDate[8] = "False";
                    //}
                    /////////////////// Высота превыш
                    //if (Convert.ToDouble(alphaBlendTextBox48.Text.ToString()) - Convert.ToDouble(XDate[21].ToString()) > 0)
                    //{
                    //    XDate[24] = Convert.ToString(Convert.ToDouble(alphaBlendTextBox48.Text.ToString()) - Convert.ToDouble(XDate[21].ToString()));
                    //    // XDate[10] = "True";
                    //}
                    //if (Convert.ToDouble(alphaBlendTextBox48.Text.ToString()) - Convert.ToDouble(XDate[21].ToString()) <= 0)
                    //{
                    //    XDate[24] = "0";
                    //    //XDate[8] = "False";
                    //}
                    alphaBlendTextBox67.Text = reader["NormPravAktAD"].ToString();//Нормативн акт дороги
                    alphaBlendTextBox68.Text = reader["ogranich"].ToString();//особ. условия. дороги
                    alphaBlendTextBox80.Text = "" + reader["Speed"].ToString() + " км/ч";// reader["velocity"].ToString();//скорость
                    alphaBlendTextBox68.Text = reader["ogranich"].ToString();//особ. условия. дороги
                                                                             //alphaBlendTextBox69.Text = reader["PriznNal"].ToString();//Признак наличия СР
                                                                             //alphaBlendTextBox70.Text = reader["KemVid"].ToString();//Кем выдано СР
                                                                             //alphaBlendTextBox71.Text = reader["VidPerevoz"].ToString();//Вид перевозки в СР
                                                                             //alphaBlendTextBox72.Text = reader["GRZSR"].ToString();//ГРЗ в СР
                                                                             //alphaBlendTextBox74.Text = reader["NomSR"].ToString();//№ СР
                                                                             //alphaBlendTextBox73.Text = reader["DateVidSR"].ToString();//Дата выдачи СР
                                                                             //alphaBlendTextBox75.Text = reader["SrokDeistvSR"].ToString();//Срок действия СР
                                                                             //alphaBlendTextBox76.Text = reader["RazrMarshr"].ToString();//Разрешенный маршрут в СР
                                                                             //alphaBlendTextBox77.Text = reader["OsjbUslDvSR"].ToString();//Особые условия движения СР
                                                                             //alphaBlendTextBox78.Text = reader["KolRazrPr"].ToString();//Разрешено поездок СР
                                                                             //alphaBlendTextBox79.Text = reader["IspolzPR"].ToString();//выполнено поездок СР
                    for (int iDist = 1; iDist < KolOs + 1; iDist++)
                    {
                        D111[iDist] = BetOs[3, iDist];
                    }
                    pictureBox39.Visible = false;
                    pictureBox38.Visible = false;
                    pictureBox37.Visible = false;
                    pictureBox36.Visible = false;
                    pictureBox35.Visible = false;
                    pictureBox34.Visible = false;
                    pictureBox33.Visible = false;
                    pictureBox32.Visible = false;
                    pictureBox31.Visible = false;
                    label154.Visible = false;
                    label144.Visible = false;
                    label18.Visible = false;

                    #endregion //////////////////////////////////////////////
                    //////////////////////////////////////////////////////////////////////////////////////////////
                    #region /////////////////////////////////// Длина межосев  //////////////////////////////////////////
                    //for (int il = 1; il < 9; il++)
                    //{
                    //    if (Convert.ToDouble(reader["axles_" + (il) + "_" + (il + 1) + "_base"].ToString()) > 800)
                    //    {
                    //        l[il] = Convert.ToDouble(reader["axles_" + (il) + "_" + (il + 1) + "_base"].ToString()) / 100 - 1.6;
                    //    }
                    //    else if (Convert.ToDouble(reader["axles_" + (il) + "_" + (il + 1) + "_base"].ToString()) > 600)
                    //    {
                    //        l[il] = Convert.ToDouble(reader["axles_" + (il) + "_" + (il + 1) + "_base"].ToString()) / 100 - 0.6;
                    //    }
                    //    else if (Convert.ToDouble(reader["axles_" + (il) + "_" + (il + 1) + "_base"].ToString()) > 220)
                    //    {
                    //        l[il] = Convert.ToDouble(reader["axles_" + (il) + "_" + (il + 1) + "_base"].ToString()) / 100 + 0.1;
                    //    }
                    //    else if (Convert.ToDouble(reader["axles_" + (il) + "_" + (il + 1) + "_base"].ToString()) > 0)
                    //    {
                    //        l[il] = Convert.ToDouble(reader["axles_" + (il) + "_" + (il + 1) + "_base"].ToString()) / 100 + 0.4;
                    //    }
                    //    else
                    //    {
                    //        l[il] = 0;
                    //    }
                    //}

                    #endregion/////////////////////////////////////////////////}

                    //////////////////#region //////////////////////////////////////////////         рисунок осей             /////////////////////////////////
                    ////////////////////label52.Text = Trimming(label1701.Text;10);
                    //////////////////pictureBox30.Visible = false;//скобка
                    //////////////////pictureBox41.Visible = false;//стрелка
                    ////////////////////label154.Visible = false;//надпись общ.длина
                    //////////////////string s = label154.Text;
                    //////////////////double i;
                    //////////////////if (label154.Text != "")
                    //////////////////    i = Convert.ToDouble(s.ToString());//.Substring(0, 4));
                    //////////////////else i = 0;
                    //////////////////if (i > 0)
                    //////////////////{
                    //////////////////    double loc2 = 0;
                    //////////////////    string TO;
                    //////////////////    //TO = "Общая длина ТС - " + s.ToString().Substring(0, 5) + "м. ";
                    //////////////////    TO = "Общая длина ТС - " + Convert.ToDouble(s) + " м. " + "\n" + "Общий вес: " + Math.Round(Convert.ToDouble(ObshMass) / 1000, 3) + " т. ";
                    //////////////////    loc2 = 20 * i + 100;
                    //////////////////    int loc3 = Convert.ToInt32(loc2);
                    //////////////////    pictureBox30.Width = loc3 - 40;
                    //////////////////    int newloc = 57 + loc3 / 2;
                    //////////////////    pictureBox30.Location = new Point(350, 150);
                    //////////////////    double loc = Convert.ToDouble(label154.Text) * 100;
                    //////////////////    location = 57 + Convert.ToInt32(20 * loc / 100);
                    //////////////////    pictureBox41.Location = new Point(Convert.ToInt32(loc2) + 300, 120);
                    //////////////////    pictureBox41.Visible = true;
                    //////////////////    label142.Text = TO;
                    //////////////////    label142.Location = new Point((loc3 / 2 + 250), 175); //location / 2 + 90), 285);
                    //////////////////    label142.BackColor = Color.Transparent;
                    //////////////////    pictureBox30.Visible = true;
                    //////////////////    label142.Visible = true;
                    //////////////////    //pictureBox42.Visible = true;
                    //////////////////}

                    ////////////////////////////////////////////////////////////// ПЕРВАЯ ОСЬ
                    //////////////////s = Convert.ToString(Convert.ToDouble(label171.Text.ToString()) * 1000);
                    ////////////////////label195.Visible = true;
                    //////////////////i = 0;
                    //////////////////if (label154.Text != "")
                    //////////////////{ i = Convert.ToInt32(s); }//Convert.ToInt32(znachenie); 
                    //////////////////else i = 0;
                    //////////////////if (i > 0)
                    //////////////////{
                    //////////////////    double loc = Convert.ToDouble(label154.Text) * 100;
                    //////////////////    location = 370 + Convert.ToInt32(20 * loc / 100);
                    //////////////////    pictureBox31.Location = new Point(location, 110);
                    //////////////////    pictureBox31.Image = AVGK.Properties.Resources._33777Ч1;
                    //////////////////    label171.Location = new Point(location, 138);
                    //////////////////    if ((i > 0) && (i < 9000))
                    //////////////////    {
                    //////////////////        if ((label153.Text != "") && (Convert.ToInt32(label153.Text) > 1))
                    //////////////////        { pictureBox31.Image = AVGK.Properties.Resources._33777Ч2; }
                    //////////////////        else if ((label153.Text != ""))
                    //////////////////        { pictureBox31.Image = AVGK.Properties.Resources._33777Ч1; }
                    //////////////////    }
                    //////////////////    else if ((i > 0) && (i > 9000))
                    //////////////////    {
                    //////////////////        if ((label153.Text != "") && (Convert.ToInt32(label153.Text) > 1))
                    //////////////////        { pictureBox31.Image = AVGK.Properties.Resources._33777К2; }
                    //////////////////        else if ((label153.Text != ""))
                    //////////////////        { pictureBox31.Image = AVGK.Properties.Resources._33777К1; }
                    //////////////////    }
                    //////////////////    pictureBox31.BringToFront();
                    //////////////////    pictureBox31.Visible = true;
                    //////////////////    label154.Visible = true;
                    //////////////////    label171.Visible = true;
                    //////////////////    label153.Visible = false;
                    //////////////////    label154.Visible = false; label144.Visible = false;
                    //////////////////}
                    //////////////////else
                    //////////////////{
                    //////////////////    label154.Visible = false;
                    //////////////////    label171.Visible = false;
                    //////////////////    label153.Visible = false;
                    //////////////////    label144.Visible = false;
                    //////////////////}

                    ////////////////////////////////////////////////////////////// ВТОРАЯ ОСЬ
                    //////////////////label152.Visible = true;
                    //////////////////s = Convert.ToString(Convert.ToDouble(label170.Text.ToString()) * 1000);
                    //////////////////i = 0;
                    //////////////////if (label170.Text != "")
                    //////////////////{
                    //////////////////    i = Convert.ToInt32(s);
                    //////////////////    if (i > 0)
                    //////////////////    {
                    //////////////////        double loc1 = 0;
                    //////////////////        //loc1 = location - 40 - 20 * ((Convert.ToDouble(label162.Text) + 0.4) * 100 + 40) / 100;// + 45;
                    //////////////////        loc1 = location - 40 - 20 * (l[1] * 100 + 40) / 100;// + 45;
                    //////////////////        int loc = Convert.ToInt32(Math.Round(loc1));
                    //////////////////        pictureBox32.Location = new Point(loc, 110);//50 + loc, 223);
                    //////////////////        //double locLOs = location - 40 - (20 * ((Convert.ToDouble(label162.Text) + 0.4) * 100 + 40) / 2) / 100;// + 45;
                    //////////////////        double locLOs = location - 40 - (20 * (l[1] / 2 * 100 + 40)) / 100;// + 45;
                    //////////////////        int locL = Convert.ToInt32(Math.Round(locLOs));
                    //////////////////        label162.Location = new Point(locL, 90);
                    //////////////////        label170.Location = new Point(loc, 138);

                    //////////////////        if ((i > 0) && (i < 9000))
                    //////////////////        {
                    //////////////////            if ((label152.Text != "") && (Convert.ToInt32(label152.Text) > 1))
                    //////////////////            { pictureBox32.Image = AVGK.Properties.Resources._33777Ч2; }
                    //////////////////            else if ((label152.Text != ""))
                    //////////////////            { pictureBox32.Image = AVGK.Properties.Resources._33777Ч1; }
                    //////////////////        }
                    //////////////////        else if ((i > 0) && (i > 9000))
                    //////////////////        {
                    //////////////////            if ((label152.Text != "") && (Convert.ToInt32(label152.Text) > 1))
                    //////////////////            { pictureBox32.Image = AVGK.Properties.Resources._33777К2; }
                    //////////////////            else if ((label152.Text != ""))
                    //////////////////            { pictureBox32.Image = AVGK.Properties.Resources._33777К1; }
                    //////////////////        }
                    //////////////////        pictureBox32.BringToFront();
                    //////////////////        pictureBox32.Visible = true;
                    //////////////////        label162.Visible = true;
                    //////////////////        label170.Visible = true;
                    //////////////////        label152.Visible = false;
                    //////////////////    }
                    //////////////////    else
                    //////////////////    {
                    //////////////////        label162.Visible = false;
                    //////////////////        label170.Visible = false;
                    //////////////////        label152.Visible = false;
                    //////////////////    }
                    //////////////////}
                    //////////////////else
                    //////////////////{
                    //////////////////    i = 0;
                    //////////////////    label162.Visible = false;
                    //////////////////    label170.Visible = false;
                    //////////////////    pictureBox32.Visible = false;
                    //////////////////}
                    ////////////////////////////////////////////////////////////// ТРЕТЬЯ ОСЬ
                    //////////////////s = Convert.ToString(Convert.ToDouble(label169.Text.ToString()) * 1000);
                    //////////////////i = 0;
                    //////////////////if (label169.Text != "")
                    //////////////////{
                    //////////////////    i = Convert.ToInt32(s);
                    //////////////////    if (i > 0)
                    //////////////////    {
                    //////////////////        label151.Visible = true;
                    //////////////////        double loc1 = 0;
                    //////////////////        loc1 = location - 40 - (20 * ((l[2] + l[1]) * 100 + 40) / 100);
                    //////////////////        //loc1 = location - 40 - (20 * (((Convert.ToDouble(label162.Text) + 0.4) + (Convert.ToDouble(label161.Text) + 0.4)) * 100 + 40) / 100);
                    //////////////////        int loc = Convert.ToInt32(Math.Round(loc1));
                    //////////////////        pictureBox33.Location = new Point(loc, 110);
                    //////////////////        //double locLOs = location - 40 - (20 * (((Convert.ToDouble(label162.Text) + 0.4) + (Convert.ToDouble(label161.Text) + 0.4) / 2) * 100 + 40)) / 100;
                    //////////////////        double locLOs = location - 40 - (20 * ((l[1] + l[2] / 2) * 100 + 40)) / 100;
                    //////////////////        int locL = Convert.ToInt32(Math.Round(locLOs));
                    //////////////////        label161.Location = new Point(locL, 90);
                    //////////////////        label169.Location = new Point(loc, 138);

                    //////////////////        if ((i > 0) && (i < 9000))
                    //////////////////        {
                    //////////////////            if ((label151.Text != "") && (Convert.ToInt32(label151.Text) > 1))
                    //////////////////            { pictureBox33.Image = AVGK.Properties.Resources._33777Ч2; }
                    //////////////////            else if (label151.Text != "")
                    //////////////////            { pictureBox33.Image = AVGK.Properties.Resources._33777Ч1; }
                    //////////////////        }
                    //////////////////        else if ((i > 0) && (i > 9000))
                    //////////////////        {
                    //////////////////            if ((label151.Text != "") && (Convert.ToInt32(label151.Text) > 1))
                    //////////////////            { pictureBox33.Image = AVGK.Properties.Resources._33777К2; }
                    //////////////////            else if (label151.Text != "")
                    //////////////////            { pictureBox33.Image = AVGK.Properties.Resources._33777К1; }
                    //////////////////        }
                    //////////////////        pictureBox33.BringToFront();
                    //////////////////        pictureBox33.Visible = true;
                    //////////////////        label161.Visible = true;
                    //////////////////        label169.Visible = true;
                    //////////////////        label151.Visible = false;
                    //////////////////    }
                    //////////////////    else
                    //////////////////    {
                    //////////////////        label161.Visible = false;
                    //////////////////        label169.Visible = false;
                    //////////////////        label151.Visible = false;
                    //////////////////    }
                    //////////////////}
                    //////////////////else
                    //////////////////{
                    //////////////////    i = 0;
                    //////////////////    label161.Visible = false;
                    //////////////////    label169.Visible = false;
                    //////////////////    pictureBox33.Visible = false;
                    //////////////////}
                    //////////////////////////////////////////////////////////////// ЧЕТВЕРТАЯ ОСЬ
                    //////////////////s = Convert.ToString(Convert.ToDouble(label168.Text.ToString()) * 1000);
                    //////////////////i = 0;
                    //////////////////if (label168.Text != "")
                    //////////////////{
                    //////////////////    i = Convert.ToInt32(s);
                    //////////////////    if (i > 0)
                    //////////////////    {
                    //////////////////        label150.Visible = true;
                    //////////////////        double loc1 = 0;
                    //////////////////        loc1 = location - 40 - (20 * ((l[3] + l[2] + l[1]) * 100 + 40) / 100);
                    //////////////////        //loc1 = location - 40 - (20 * (((Convert.ToDouble(label162.Text) + 0.4) + (Convert.ToDouble(label161.Text) + 0.4) + (Convert.ToDouble(label160.Text) + 0.4)) * 100 + 40) / 100);
                    //////////////////        int loc = Convert.ToInt32(Math.Round(loc1));
                    //////////////////        pictureBox34.Location = new Point(loc, 110);
                    //////////////////        double locLOs = location - 40 - (20 * ((l[1] + l[2] + l[3] / 2) * 100 + 40)) / 100;
                    //////////////////        int locL = Convert.ToInt32(Math.Round(locLOs));
                    //////////////////        label160.Location = new Point(locL, 90);
                    //////////////////        label168.Location = new Point(loc, 138);

                    //////////////////        if ((i > 0) && (i < 9000))
                    //////////////////        {
                    //////////////////            if ((label150.Text != "") && (Convert.ToInt32(label150.Text) > 1))
                    //////////////////            { pictureBox34.Image = AVGK.Properties.Resources._33777Ч2; }
                    //////////////////            else if (label150.Text != "")
                    //////////////////            { pictureBox34.Image = AVGK.Properties.Resources._33777Ч1; }
                    //////////////////        }
                    //////////////////        else if ((i > 0) && (i > 9000))
                    //////////////////        {
                    //////////////////            if ((label150.Text != "") && (Convert.ToInt32(label150.Text) > 1))
                    //////////////////            { pictureBox34.Image = AVGK.Properties.Resources._33777К2; }
                    //////////////////            else if (label150.Text != "")
                    //////////////////            { pictureBox34.Image = AVGK.Properties.Resources._33777К1; }
                    //////////////////        }
                    //////////////////        pictureBox34.BringToFront();
                    //////////////////        pictureBox34.Visible = true;
                    //////////////////        label160.Visible = true;
                    //////////////////        label168.Visible = true;
                    //////////////////        label150.Visible = false;
                    //////////////////    }
                    //////////////////    else
                    //////////////////    {
                    //////////////////        label160.Visible = false;
                    //////////////////        label168.Visible = false;
                    //////////////////        label150.Visible = false;
                    //////////////////    }
                    //////////////////}
                    //////////////////else
                    //////////////////{
                    //////////////////    i = 0;
                    //////////////////    label160.Visible = false;
                    //////////////////    label168.Visible = false;
                    //////////////////    pictureBox33.Visible = false;
                    //////////////////}

                    ////////////////////////////////////////////////////////////// ПЯТАЯ ОСЬ
                    //////////////////s = Convert.ToString(Convert.ToDouble(label167.Text.ToString()) * 1000);
                    //////////////////i = 0;
                    //////////////////if (label167.Text != "")
                    //////////////////{
                    //////////////////    i = Convert.ToInt32(s);
                    //////////////////    if (i > 0)
                    //////////////////    {
                    //////////////////        label149.Visible = true;
                    //////////////////        double loc1 = 0;
                    //////////////////        loc1 = location - 40 - (20 * ((l[1] + l[2] + l[3] + l[4]) * 100 + 40) / 100);
                    //////////////////        int loc = Convert.ToInt32(Math.Round(loc1));
                    //////////////////        pictureBox35.Location = new Point(loc, 110);
                    //////////////////        double locLOs = location - 40 - (20 * ((l[1] + l[2] + l[3] + l[4] / 2) * 100 + 40)) / 100;
                    //////////////////        int locL = Convert.ToInt32(Math.Round(locLOs));
                    //////////////////        label159.Location = new Point(locL, 90);
                    //////////////////        label167.Location = new Point(loc, 138);

                    //////////////////        if ((i > 0) && (i < 9000))
                    //////////////////        {
                    //////////////////            if ((label149.Text != "") && (Convert.ToInt32(label149.Text) > 1))
                    //////////////////            { pictureBox35.Image = AVGK.Properties.Resources._33777Ч2; }
                    //////////////////            else if (label149.Text != "")
                    //////////////////            { pictureBox35.Image = AVGK.Properties.Resources._33777Ч1; }
                    //////////////////        }
                    //////////////////        else if ((i > 0) && (i > 9000))
                    //////////////////        {
                    //////////////////            if ((label149.Text != "") && (Convert.ToInt32(label149.Text) > 1))
                    //////////////////            { pictureBox35.Image = AVGK.Properties.Resources._33777К2; }
                    //////////////////            else if (label149.Text != "")
                    //////////////////            { pictureBox35.Image = AVGK.Properties.Resources._33777К1; }
                    //////////////////        }
                    //////////////////        pictureBox35.BringToFront();
                    //////////////////        pictureBox35.Visible = true;
                    //////////////////        label159.Visible = true;
                    //////////////////        label167.Visible = true;
                    //////////////////        label149.Visible = false;
                    //////////////////    }
                    //////////////////    else
                    //////////////////    {
                    //////////////////        label159.Visible = false;
                    //////////////////        label167.Visible = false;
                    //////////////////        label149.Visible = false;
                    //////////////////    }
                    //////////////////}
                    //////////////////else
                    //////////////////{
                    //////////////////    i = 0;
                    //////////////////    label159.Visible = false;
                    //////////////////    label167.Visible = false;
                    //////////////////    pictureBox33.Visible = false;
                    //////////////////}

                    ////////////////////////////////////////////////////////////// ШЕСТАЯ ОСЬ
                    //////////////////s = Convert.ToString(Convert.ToDouble(label166.Text.ToString()) * 1000);
                    //////////////////i = 0;
                    //////////////////if (label166.Text != "")
                    //////////////////{
                    //////////////////    i = Convert.ToInt32(s);
                    //////////////////    if (i > 0)
                    //////////////////    {
                    //////////////////        label148.Visible = true;
                    //////////////////        double loc1 = 0;
                    //////////////////        loc1 = location - 40 - (20 * ((l[1] + l[2] + l[3] + l[4] + l[5]) * 100 + 40) / 100);
                    //////////////////        int loc = Convert.ToInt32(Math.Round(loc1));
                    //////////////////        pictureBox36.Location = new Point(loc, 110);
                    //////////////////        double locLOs = location - 40 - (20 * ((l[1] + l[2] + l[3] + l[4] + l[5] / 2) * 100 + 40)) / 100;
                    //////////////////        int locL = Convert.ToInt32(Math.Round(locLOs));
                    //////////////////        label158.Location = new Point(locL, 90);
                    //////////////////        label166.Location = new Point(loc, 138);

                    //////////////////        if ((i > 0) && (i < 9000))
                    //////////////////        {
                    //////////////////            if ((label148.Text != "") && (Convert.ToInt32(label148.Text) > 1))
                    //////////////////            { pictureBox36.Image = AVGK.Properties.Resources._33777Ч2; }
                    //////////////////            else if (label148.Text != "")
                    //////////////////            { pictureBox36.Image = AVGK.Properties.Resources._33777Ч1; }
                    //////////////////        }
                    //////////////////        else if ((i > 0) && (i > 9000))
                    //////////////////        {
                    //////////////////            if ((label148.Text != "") && (Convert.ToInt32(label148.Text) > 1))
                    //////////////////            { pictureBox36.Image = AVGK.Properties.Resources._33777К2; }
                    //////////////////            else if (label148.Text != "")
                    //////////////////            { pictureBox36.Image = AVGK.Properties.Resources._33777К1; }
                    //////////////////        }
                    //////////////////        pictureBox36.BringToFront();
                    //////////////////        pictureBox36.Visible = true;
                    //////////////////        label158.Visible = true;
                    //////////////////        label166.Visible = true;
                    //////////////////        label148.Visible = false;
                    //////////////////    }
                    //////////////////    else
                    //////////////////    {
                    //////////////////        label158.Visible = false;
                    //////////////////        label166.Visible = false;
                    //////////////////        label148.Visible = false;
                    //////////////////    }
                    //////////////////}
                    //////////////////else
                    //////////////////{
                    //////////////////    i = 0;
                    //////////////////    label158.Visible = false;
                    //////////////////    label166.Visible = false;
                    //////////////////    pictureBox33.Visible = false;
                    //////////////////}

                    ////////////////////////////////////////////////////////////// СЕДЬМАЯ ОСЬ
                    //////////////////s = Convert.ToString(Convert.ToDouble(label165.Text.ToString()) * 1000);
                    //////////////////i = 0;
                    //////////////////if (label165.Text != "")
                    //////////////////{
                    //////////////////    i = Convert.ToInt32(s);
                    //////////////////    if (i > 0)
                    //////////////////    {
                    //////////////////        label147.Visible = true;
                    //////////////////        double loc1 = 0;
                    //////////////////        loc1 = location - 40 - (20 * ((l[1] + l[2] + l[3] + l[4] + l[5] + l[6]) * 100 + 40) / 100);
                    //////////////////        int loc = Convert.ToInt32(Math.Round(loc1));
                    //////////////////        pictureBox37.Location = new Point(loc, 110);
                    //////////////////        double locLOs = location - 40 - (20 * ((l[1] + l[2] + l[3] + l[4] + l[5] + l[6] / 2) * 100 + 40)) / 100;
                    //////////////////        int locL = Convert.ToInt32(Math.Round(locLOs));
                    //////////////////        label157.Location = new Point(locL, 90);
                    //////////////////        label165.Location = new Point(loc, 138);

                    //////////////////        if ((i > 0) && (i < 9000))
                    //////////////////        {
                    //////////////////            if ((label147.Text != "") && (Convert.ToInt32(label147.Text) > 1))
                    //////////////////            { pictureBox37.Image = AVGK.Properties.Resources._33777Ч2; }
                    //////////////////            else if (label147.Text != "")
                    //////////////////            { pictureBox37.Image = AVGK.Properties.Resources._33777Ч1; }
                    //////////////////        }
                    //////////////////        else if ((i > 0) && (i > 9000))
                    //////////////////        {
                    //////////////////            if ((label147.Text != "") && (Convert.ToInt32(label147.Text) > 1))
                    //////////////////            { pictureBox37.Image = AVGK.Properties.Resources._33777К2; }
                    //////////////////            else if (label147.Text != "")
                    //////////////////            { pictureBox37.Image = AVGK.Properties.Resources._33777К1; }
                    //////////////////        }
                    //////////////////        pictureBox37.BringToFront();
                    //////////////////        pictureBox37.Visible = true;
                    //////////////////        label157.Visible = true;
                    //////////////////        label165.Visible = true;
                    //////////////////        label147.Visible = false;
                    //////////////////    }
                    //////////////////    else
                    //////////////////    {
                    //////////////////        label157.Visible = false;
                    //////////////////        label165.Visible = false;
                    //////////////////        label147.Visible = false;
                    //////////////////    }
                    //////////////////}
                    //////////////////else
                    //////////////////{
                    //////////////////    i = 0;
                    //////////////////    label157.Visible = false;
                    //////////////////    label165.Visible = false;
                    //////////////////    pictureBox33.Visible = false;
                    //////////////////}
                    ////////////////////////////////////////////////////////////// ВОСЬМАЯ ОСЬ
                    //////////////////s = Convert.ToString(Convert.ToDouble(label164.Text.ToString()) * 1000);
                    //////////////////i = 0;
                    //////////////////if (label164.Text != "")
                    //////////////////{
                    //////////////////    i = Convert.ToInt32(s);
                    //////////////////    if (i > 0)
                    //////////////////    {
                    //////////////////        label146.Visible = true;
                    //////////////////        double loc1 = 0;
                    //////////////////        loc1 = location - 40 - (20 * ((l[1] + l[2] + l[3] + l[4] + l[5] + l[6] + l[7]) * 100 + 40) / 100);
                    //////////////////        int loc = Convert.ToInt32(Math.Round(loc1));
                    //////////////////        pictureBox38.Location = new Point(loc, 110);
                    //////////////////        double locLOs = location - 40 - (20 * ((l[1] + l[2] + l[3] + l[4] + l[5] + l[6] + l[7] / 2) * 100 + 40)) / 100;
                    //////////////////        int locL = Convert.ToInt32(Math.Round(locLOs));
                    //////////////////        label156.Location = new Point(locL, 90);
                    //////////////////        label164.Location = new Point(loc, 138);

                    //////////////////        if ((i > 0) && (i < 9000))
                    //////////////////        {
                    //////////////////            if ((label146.Text != "") && (Convert.ToInt32(label146.Text) > 1))
                    //////////////////            { pictureBox38.Image = AVGK.Properties.Resources._33777Ч2; }
                    //////////////////            else if (label146.Text != "")
                    //////////////////            { pictureBox38.Image = AVGK.Properties.Resources._33777Ч1; }
                    //////////////////        }
                    //////////////////        else if ((i > 0) && (i > 9000))
                    //////////////////        {
                    //////////////////            if ((label146.Text != "") && (Convert.ToInt32(label146.Text) > 1))
                    //////////////////            { pictureBox38.Image = AVGK.Properties.Resources._33777К2; }
                    //////////////////            else if (label146.Text != "")
                    //////////////////            { pictureBox38.Image = AVGK.Properties.Resources._33777К1; }
                    //////////////////        }
                    //////////////////        pictureBox38.BringToFront();
                    //////////////////        pictureBox38.Visible = true;
                    //////////////////        label156.Visible = true;
                    //////////////////        label164.Visible = true;
                    //////////////////        label146.Visible = false;
                    //////////////////    }
                    //////////////////    else
                    //////////////////    {
                    //////////////////        label156.Visible = false;
                    //////////////////        label164.Visible = false;
                    //////////////////        label146.Visible = false;
                    //////////////////    }
                    //////////////////}
                    //////////////////else
                    //////////////////{
                    //////////////////    i = 0;
                    //////////////////    label156.Visible = false;
                    //////////////////    label164.Visible = false;
                    //////////////////    pictureBox33.Visible = false;
                    //////////////////}
                    ////////////////////////////////////////////////////////////// ДЕВЯТАЯ ОСЬ
                    //////////////////s = Convert.ToString(Convert.ToDouble(label163.Text.ToString()) * 1000);
                    //////////////////i = 0;
                    //////////////////if (label163.Text != "")
                    //////////////////{
                    //////////////////    i = Convert.ToInt32(s);
                    //////////////////    if (i > 0)
                    //////////////////    {
                    //////////////////        label145.Visible = true;
                    //////////////////        double loc1 = 0;
                    //////////////////        loc1 = location - 40 - (20 * ((l[1] + l[2] + l[3] + l[4] + l[5] + l[6] + l[7] + l[8]) * 100 + 40) / 100);
                    //////////////////        int loc = Convert.ToInt32(Math.Round(loc1));
                    //////////////////        pictureBox39.Location = new Point(loc, 110);
                    //////////////////        double locLOs = location - 40 - (20 * ((l[1] + l[2] + l[3] + l[4] + l[5] + l[6] + l[7] + l[8] / 2) * 100 + 40)) / 100;
                    //////////////////        int locL = Convert.ToInt32(Math.Round(locLOs));
                    //////////////////        label155.Location = new Point(locL, 90);
                    //////////////////        label163.Location = new Point(loc, 138);

                    //////////////////        if ((i > 0) && (i < 9000))
                    //////////////////        {
                    //////////////////            if ((label145.Text != "") && (Convert.ToInt32(label145.Text) > 1))
                    //////////////////            { pictureBox39.Image = AVGK.Properties.Resources._33777Ч2; }
                    //////////////////            else if (label145.Text != "")
                    //////////////////            { pictureBox39.Image = AVGK.Properties.Resources._33777Ч1; }
                    //////////////////        }
                    //////////////////        else if ((i > 0) && (i > 9000))
                    //////////////////        {
                    //////////////////            if ((label145.Text != "") && (Convert.ToInt32(label145.Text) > 1))
                    //////////////////            { pictureBox39.Image = AVGK.Properties.Resources._33777К2; }
                    //////////////////            else if (label145.Text != "")
                    //////////////////            { pictureBox39.Image = AVGK.Properties.Resources._33777К1; }
                    //////////////////        }
                    //////////////////        pictureBox39.BringToFront();
                    //////////////////        pictureBox39.Visible = true;
                    //////////////////        label155.Visible = true;
                    //////////////////        label163.Visible = true;
                    //////////////////        label145.Visible = false;
                    //////////////////    }
                    //////////////////    else
                    //////////////////    {
                    //////////////////        label155.Visible = false;
                    //////////////////        label163.Visible = false;
                    //////////////////        label145.Visible = false;
                    //////////////////    }
                    //////////////////}
                    //////////////////else
                    //////////////////{
                    //////////////////    i = 0;
                    //////////////////    label155.Visible = false;
                    //////////////////    label163.Visible = false;
                    //////////////////    pictureBox33.Visible = false;
                    //////////////////}
                    //////////////////#endregion              ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                }
                reader.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: \r\n{0}", ex.ToString());
            }
            finally
            {
                command.Connection.Close();
            }

            #region //////////////////////////////////////////////         рисунок осей             /////////////////////////////////
            //label52.Text = Trimming(label1701.Text;10);
            pictureBox30.Visible = false;//скобка
            pictureBox41.Visible = false;//стрелка
                                         //label154.Visible = false;//надпись общ.длина
            string s = label154.Text;
            double i;
            if (label154.Text != "")
                i = Convert.ToDouble(s.ToString());//.Substring(0, 4));
            else i = 0;
            if (i > 0)
            {
                double loc2 = 0;
                string TO;
                //TO = "Общая длина ТС - " + s.ToString().Substring(0, 5) + "м. ";
                TO = "Общая длина ТС - " + Convert.ToDouble(s) + " м. " + "\n" + "Общий вес: " + Math.Round(Convert.ToDouble(ObshMass) / 1000, 3) + " т. ";
                loc2 = 20 * i + 100;
                int loc3 = Convert.ToInt32(loc2);
                pictureBox30.Width = loc3 - 40;
                int newloc = 57 + loc3 / 2;
                pictureBox30.Location = new Point(350, 150);
                double loc = Convert.ToDouble(label154.Text) * 100;
                location = 57 + Convert.ToInt32(20 * loc / 100);
                pictureBox41.Location = new Point(Convert.ToInt32(loc2) + 300, 120);
                pictureBox41.Visible = true;
                label142.Text = TO;
                label142.Location = new Point((loc3 / 2 + 250), 175); //location / 2 + 90), 285);
                label142.BackColor = Color.Transparent;
                pictureBox30.Visible = true;
                label142.Visible = true;
                //pictureBox42.Visible = true;
            }

            //////////////////////////////////////////// ПЕРВАЯ ОСЬ
            s = Convert.ToString(Convert.ToDouble(label171.Text.ToString()) * 1000);
            //label195.Visible = true;
            i = 0;
            if (label154.Text != "")
            { i = Convert.ToInt32(s); }//Convert.ToInt32(znachenie); 
            else i = 0;
            if (i > 0)
            {
                double loc = Convert.ToDouble(label154.Text) * 100;
                location = 370 + Convert.ToInt32(20 * loc / 100);
                pictureBox31.Location = new Point(location, 110);
                pictureBox31.Image = AVGK.Properties.Resources._33777Ч1;
                label171.Location = new Point(location, 138);
                if ((i > 0) && (i < 9000))
                {
                    if ((label153.Text != "") && (Convert.ToInt32(label153.Text) > 1))
                    { pictureBox31.Image = AVGK.Properties.Resources._33777Ч2; }
                    else if ((label153.Text != ""))
                    { pictureBox31.Image = AVGK.Properties.Resources._33777Ч1; }
                }
                else if ((i > 0) && (i > 9000))
                {
                    if ((label153.Text != "") && (Convert.ToInt32(label153.Text) > 1))
                    { pictureBox31.Image = AVGK.Properties.Resources._33777К2; }
                    else if ((label153.Text != ""))
                    { pictureBox31.Image = AVGK.Properties.Resources._33777К1; }
                }
                pictureBox31.BringToFront();
                pictureBox31.Visible = true;
                label154.Visible = true;
                label171.Visible = true;
                label153.Visible = false;
                label154.Visible = false; label144.Visible = false;
            }
            else
            {
                label154.Visible = false;
                label171.Visible = false;
                label153.Visible = false;
                label144.Visible = false;
            }

            //////////////////////////////////////////// ВТОРАЯ ОСЬ
            label152.Visible = true;
            s = Convert.ToString(Convert.ToDouble(label170.Text.ToString()) * 1000);
            i = 0;
            if (label170.Text != "")
            {
                i = Convert.ToInt32(s);
                if (i > 0)
                {
                    double loc1 = 0;
                    //loc1 = location - 40 - 20 * ((Convert.ToDouble(label162.Text) + 0.4) * 100 + 40) / 100;// + 45;
                    loc1 = location - 40 - 20 * (l[1] * 100 + 40) / 100;// + 45;
                    int loc = Convert.ToInt32(Math.Round(loc1));
                    pictureBox32.Location = new Point(loc, 110);//50 + loc, 223);
                                                                //double locLOs = location - 40 - (20 * ((Convert.ToDouble(label162.Text) + 0.4) * 100 + 40) / 2) / 100;// + 45;
                    double locLOs = location - 40 - (20 * (l[1] / 2 * 100 + 40)) / 100;// + 45;
                    int locL = Convert.ToInt32(Math.Round(locLOs));
                    label162.Location = new Point(locL, 90);
                    label170.Location = new Point(loc, 138);

                    if ((i > 0) && (i < 9000))
                    {
                        if ((label152.Text != "") && (Convert.ToInt32(label152.Text) > 1))
                        { pictureBox32.Image = AVGK.Properties.Resources._33777Ч2; }
                        else if ((label152.Text != ""))
                        { pictureBox32.Image = AVGK.Properties.Resources._33777Ч1; }
                    }
                    else if ((i > 0) && (i > 9000))
                    {
                        if ((label152.Text != "") && (Convert.ToInt32(label152.Text) > 1))
                        { pictureBox32.Image = AVGK.Properties.Resources._33777К2; }
                        else if ((label152.Text != ""))
                        { pictureBox32.Image = AVGK.Properties.Resources._33777К1; }
                    }
                    pictureBox32.BringToFront();
                    pictureBox32.Visible = true;
                    label162.Visible = true;
                    label170.Visible = true;
                    label152.Visible = false;
                }
                else
                {
                    label162.Visible = false;
                    label170.Visible = false;
                    label152.Visible = false;
                }
            }
            else
            {
                i = 0;
                label162.Visible = false;
                label170.Visible = false;
                pictureBox32.Visible = false;
            }
            //////////////////////////////////////////// ТРЕТЬЯ ОСЬ
            s = Convert.ToString(Convert.ToDouble(label169.Text.ToString()) * 1000);
            i = 0;
            if (label169.Text != "")
            {
                i = Convert.ToInt32(s);
                if (i > 0)
                {
                    label151.Visible = true;
                    double loc1 = 0;
                    loc1 = location - 40 - (20 * ((l[2] + l[1]) * 100 + 40) / 100);
                    //loc1 = location - 40 - (20 * (((Convert.ToDouble(label162.Text) + 0.4) + (Convert.ToDouble(label161.Text) + 0.4)) * 100 + 40) / 100);
                    int loc = Convert.ToInt32(Math.Round(loc1));
                    pictureBox33.Location = new Point(loc, 110);
                    //double locLOs = location - 40 - (20 * (((Convert.ToDouble(label162.Text) + 0.4) + (Convert.ToDouble(label161.Text) + 0.4) / 2) * 100 + 40)) / 100;
                    double locLOs = location - 40 - (20 * ((l[1] + l[2] / 2) * 100 + 40)) / 100;
                    int locL = Convert.ToInt32(Math.Round(locLOs));
                    label161.Location = new Point(locL, 90);
                    label169.Location = new Point(loc, 138);

                    if ((i > 0) && (i < 9000))
                    {
                        if ((label151.Text != "") && (Convert.ToInt32(label151.Text) > 1))
                        { pictureBox33.Image = AVGK.Properties.Resources._33777Ч2; }
                        else if (label151.Text != "")
                        { pictureBox33.Image = AVGK.Properties.Resources._33777Ч1; }
                    }
                    else if ((i > 0) && (i > 9000))
                    {
                        if ((label151.Text != "") && (Convert.ToInt32(label151.Text) > 1))
                        { pictureBox33.Image = AVGK.Properties.Resources._33777К2; }
                        else if (label151.Text != "")
                        { pictureBox33.Image = AVGK.Properties.Resources._33777К1; }
                    }
                    pictureBox33.BringToFront();
                    pictureBox33.Visible = true;
                    label161.Visible = true;
                    label169.Visible = true;
                    label151.Visible = false;
                }
                else
                {
                    label161.Visible = false;
                    label169.Visible = false;
                    label151.Visible = false;
                }
            }
            else
            {
                i = 0;
                label161.Visible = false;
                label169.Visible = false;
                pictureBox33.Visible = false;
            }
            ////////////////////////////////////////////// ЧЕТВЕРТАЯ ОСЬ
            s = Convert.ToString(Convert.ToDouble(label168.Text.ToString()) * 1000);
            i = 0;
            if (label168.Text != "")
            {
                i = Convert.ToInt32(s);
                if (i > 0)
                {
                    label150.Visible = true;
                    double loc1 = 0;
                    loc1 = location - 40 - (20 * ((l[3] + l[2] + l[1]) * 100 + 40) / 100);
                    //loc1 = location - 40 - (20 * (((Convert.ToDouble(label162.Text) + 0.4) + (Convert.ToDouble(label161.Text) + 0.4) + (Convert.ToDouble(label160.Text) + 0.4)) * 100 + 40) / 100);
                    int loc = Convert.ToInt32(Math.Round(loc1));
                    pictureBox34.Location = new Point(loc, 110);
                    double locLOs = location - 40 - (20 * ((l[1] + l[2] + l[3] / 2) * 100 + 40)) / 100;
                    int locL = Convert.ToInt32(Math.Round(locLOs));
                    label160.Location = new Point(locL, 90);
                    label168.Location = new Point(loc, 138);

                    if ((i > 0) && (i < 9000))
                    {
                        if ((label150.Text != "") && (Convert.ToInt32(label150.Text) > 1))
                        { pictureBox34.Image = AVGK.Properties.Resources._33777Ч2; }
                        else if (label150.Text != "")
                        { pictureBox34.Image = AVGK.Properties.Resources._33777Ч1; }
                    }
                    else if ((i > 0) && (i > 9000))
                    {
                        if ((label150.Text != "") && (Convert.ToInt32(label150.Text) > 1))
                        { pictureBox34.Image = AVGK.Properties.Resources._33777К2; }
                        else if (label150.Text != "")
                        { pictureBox34.Image = AVGK.Properties.Resources._33777К1; }
                    }
                    pictureBox34.BringToFront();
                    pictureBox34.Visible = true;
                    label160.Visible = true;
                    label168.Visible = true;
                    label150.Visible = false;
                }
                else
                {
                    label160.Visible = false;
                    label168.Visible = false;
                    label150.Visible = false;
                }
            }
            else
            {
                i = 0;
                label160.Visible = false;
                label168.Visible = false;
                pictureBox33.Visible = false;
            }

            //////////////////////////////////////////// ПЯТАЯ ОСЬ
            s = Convert.ToString(Convert.ToDouble(label167.Text.ToString()) * 1000);
            i = 0;
            if (label167.Text != "")
            {
                i = Convert.ToInt32(s);
                if (i > 0)
                {
                    label149.Visible = true;
                    double loc1 = 0;
                    loc1 = location - 40 - (20 * ((l[1] + l[2] + l[3] + l[4]) * 100 + 40) / 100);
                    int loc = Convert.ToInt32(Math.Round(loc1));
                    pictureBox35.Location = new Point(loc, 110);
                    double locLOs = location - 40 - (20 * ((l[1] + l[2] + l[3] + l[4] / 2) * 100 + 40)) / 100;
                    int locL = Convert.ToInt32(Math.Round(locLOs));
                    label159.Location = new Point(locL, 90);
                    label167.Location = new Point(loc, 138);

                    if ((i > 0) && (i < 9000))
                    {
                        if ((label149.Text != "") && (Convert.ToInt32(label149.Text) > 1))
                        { pictureBox35.Image = AVGK.Properties.Resources._33777Ч2; }
                        else if (label149.Text != "")
                        { pictureBox35.Image = AVGK.Properties.Resources._33777Ч1; }
                    }
                    else if ((i > 0) && (i > 9000))
                    {
                        if ((label149.Text != "") && (Convert.ToInt32(label149.Text) > 1))
                        { pictureBox35.Image = AVGK.Properties.Resources._33777К2; }
                        else if (label149.Text != "")
                        { pictureBox35.Image = AVGK.Properties.Resources._33777К1; }
                    }
                    pictureBox35.BringToFront();
                    pictureBox35.Visible = true;
                    label159.Visible = true;
                    label167.Visible = true;
                    label149.Visible = false;
                }
                else
                {
                    label159.Visible = false;
                    label167.Visible = false;
                    label149.Visible = false;
                }
            }
            else
            {
                i = 0;
                label159.Visible = false;
                label167.Visible = false;
                pictureBox33.Visible = false;
            }

            //////////////////////////////////////////// ШЕСТАЯ ОСЬ
            s = Convert.ToString(Convert.ToDouble(label166.Text.ToString()) * 1000);
            i = 0;
            if (label166.Text != "")
            {
                i = Convert.ToInt32(s);
                if (i > 0)
                {
                    label148.Visible = true;
                    double loc1 = 0;
                    loc1 = location - 40 - (20 * ((l[1] + l[2] + l[3] + l[4] + l[5]) * 100 + 40) / 100);
                    int loc = Convert.ToInt32(Math.Round(loc1));
                    pictureBox36.Location = new Point(loc, 110);
                    double locLOs = location - 40 - (20 * ((l[1] + l[2] + l[3] + l[4] + l[5] / 2) * 100 + 40)) / 100;
                    int locL = Convert.ToInt32(Math.Round(locLOs));
                    label158.Location = new Point(locL, 90);
                    label166.Location = new Point(loc, 138);

                    if ((i > 0) && (i < 9000))
                    {
                        if ((label148.Text != "") && (Convert.ToInt32(label148.Text) > 1))
                        { pictureBox36.Image = AVGK.Properties.Resources._33777Ч2; }
                        else if (label148.Text != "")
                        { pictureBox36.Image = AVGK.Properties.Resources._33777Ч1; }
                    }
                    else if ((i > 0) && (i > 9000))
                    {
                        if ((label148.Text != "") && (Convert.ToInt32(label148.Text) > 1))
                        { pictureBox36.Image = AVGK.Properties.Resources._33777К2; }
                        else if (label148.Text != "")
                        { pictureBox36.Image = AVGK.Properties.Resources._33777К1; }
                    }
                    pictureBox36.BringToFront();
                    pictureBox36.Visible = true;
                    label158.Visible = true;
                    label166.Visible = true;
                    label148.Visible = false;
                }
                else
                {
                    label158.Visible = false;
                    label166.Visible = false;
                    label148.Visible = false;
                }
            }
            else
            {
                i = 0;
                label158.Visible = false;
                label166.Visible = false;
                pictureBox33.Visible = false;
            }

            //////////////////////////////////////////// СЕДЬМАЯ ОСЬ
            s = Convert.ToString(Convert.ToDouble(label165.Text.ToString()) * 1000);
            i = 0;
            if (label165.Text != "")
            {
                i = Convert.ToInt32(s);
                if (i > 0)
                {
                    label147.Visible = true;
                    double loc1 = 0;
                    loc1 = location - 40 - (20 * ((l[1] + l[2] + l[3] + l[4] + l[5] + l[6]) * 100 + 40) / 100);
                    int loc = Convert.ToInt32(Math.Round(loc1));
                    pictureBox37.Location = new Point(loc, 110);
                    double locLOs = location - 40 - (20 * ((l[1] + l[2] + l[3] + l[4] + l[5] + l[6] / 2) * 100 + 40)) / 100;
                    int locL = Convert.ToInt32(Math.Round(locLOs));
                    label157.Location = new Point(locL, 90);
                    label165.Location = new Point(loc, 138);

                    if ((i > 0) && (i < 9000))
                    {
                        if ((label147.Text != "") && (Convert.ToInt32(label147.Text) > 1))
                        { pictureBox37.Image = AVGK.Properties.Resources._33777Ч2; }
                        else if (label147.Text != "")
                        { pictureBox37.Image = AVGK.Properties.Resources._33777Ч1; }
                    }
                    else if ((i > 0) && (i > 9000))
                    {
                        if ((label147.Text != "") && (Convert.ToInt32(label147.Text) > 1))
                        { pictureBox37.Image = AVGK.Properties.Resources._33777К2; }
                        else if (label147.Text != "")
                        { pictureBox37.Image = AVGK.Properties.Resources._33777К1; }
                    }
                    pictureBox37.BringToFront();
                    pictureBox37.Visible = true;
                    label157.Visible = true;
                    label165.Visible = true;
                    label147.Visible = false;
                }
                else
                {
                    label157.Visible = false;
                    label165.Visible = false;
                    label147.Visible = false;
                }
            }
            else
            {
                i = 0;
                label157.Visible = false;
                label165.Visible = false;
                pictureBox33.Visible = false;
            }
            //////////////////////////////////////////// ВОСЬМАЯ ОСЬ
            s = Convert.ToString(Convert.ToDouble(label164.Text.ToString()) * 1000);
            i = 0;
            if (label164.Text != "")
            {
                i = Convert.ToInt32(s);
                if (i > 0)
                {
                    label146.Visible = true;
                    double loc1 = 0;
                    loc1 = location - 40 - (20 * ((l[1] + l[2] + l[3] + l[4] + l[5] + l[6] + l[7]) * 100 + 40) / 100);
                    int loc = Convert.ToInt32(Math.Round(loc1));
                    pictureBox38.Location = new Point(loc, 110);
                    double locLOs = location - 40 - (20 * ((l[1] + l[2] + l[3] + l[4] + l[5] + l[6] + l[7] / 2) * 100 + 40)) / 100;
                    int locL = Convert.ToInt32(Math.Round(locLOs));
                    label156.Location = new Point(locL, 90);
                    label164.Location = new Point(loc, 138);

                    if ((i > 0) && (i < 9000))
                    {
                        if ((label146.Text != "") && (Convert.ToInt32(label146.Text) > 1))
                        { pictureBox38.Image = AVGK.Properties.Resources._33777Ч2; }
                        else if (label146.Text != "")
                        { pictureBox38.Image = AVGK.Properties.Resources._33777Ч1; }
                    }
                    else if ((i > 0) && (i > 9000))
                    {
                        if ((label146.Text != "") && (Convert.ToInt32(label146.Text) > 1))
                        { pictureBox38.Image = AVGK.Properties.Resources._33777К2; }
                        else if (label146.Text != "")
                        { pictureBox38.Image = AVGK.Properties.Resources._33777К1; }
                    }
                    pictureBox38.BringToFront();
                    pictureBox38.Visible = true;
                    label156.Visible = true;
                    label164.Visible = true;
                    label146.Visible = false;
                }
                else
                {
                    label156.Visible = false;
                    label164.Visible = false;
                    label146.Visible = false;
                }
            }
            else
            {
                i = 0;
                label156.Visible = false;
                label164.Visible = false;
                pictureBox33.Visible = false;
            }
            //////////////////////////////////////////// ДЕВЯТАЯ ОСЬ
            s = Convert.ToString(Convert.ToDouble(label163.Text.ToString()) * 1000);
            i = 0;
            if (label163.Text != "")
            {
                i = Convert.ToInt32(s);
                if (i > 0)
                {
                    label145.Visible = true;
                    double loc1 = 0;
                    loc1 = location - 40 - (20 * ((l[1] + l[2] + l[3] + l[4] + l[5] + l[6] + l[7] + l[8]) * 100 + 40) / 100);
                    int loc = Convert.ToInt32(Math.Round(loc1));
                    pictureBox39.Location = new Point(loc, 110);
                    double locLOs = location - 40 - (20 * ((l[1] + l[2] + l[3] + l[4] + l[5] + l[6] + l[7] + l[8] / 2) * 100 + 40)) / 100;
                    int locL = Convert.ToInt32(Math.Round(locLOs));
                    label155.Location = new Point(locL, 90);
                    label163.Location = new Point(loc, 138);

                    if ((i > 0) && (i < 9000))
                    {
                        if ((label145.Text != "") && (Convert.ToInt32(label145.Text) > 1))
                        { pictureBox39.Image = AVGK.Properties.Resources._33777Ч2; }
                        else if (label145.Text != "")
                        { pictureBox39.Image = AVGK.Properties.Resources._33777Ч1; }
                    }
                    else if ((i > 0) && (i > 9000))
                    {
                        if ((label145.Text != "") && (Convert.ToInt32(label145.Text) > 1))
                        { pictureBox39.Image = AVGK.Properties.Resources._33777К2; }
                        else if (label145.Text != "")
                        { pictureBox39.Image = AVGK.Properties.Resources._33777К1; }
                    }
                    pictureBox39.BringToFront();
                    pictureBox39.Visible = true;
                    label155.Visible = true;
                    label163.Visible = true;
                    label145.Visible = false;
                }
                else
                {
                    label155.Visible = false;
                    label163.Visible = false;
                    label145.Visible = false;
                }
            }
            else
            {
                i = 0;
                label155.Visible = false;
                label163.Visible = false;
                pictureBox33.Visible = false;
            }
            #endregion              ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////




            if (ColPicKR < 16)
            {
                pictureBox40.Image = null;
                pictureBox29.Image = null;
                for (i = 0; i < ColPicKR; i++)
                {
                    if (i != 0)
                    { NPicKR = NPicKR - 1; }

                    MySqlCommand commandLB = new MySqlCommand();
                    ConnectStr conStrLB = new ConnectStr();
                    conStrLB.ConStr(1);
                    Zapros zaprosLB = new Zapros();
                    string connectionStringLB;//, commandString;
                    connectionStringLB = conStrLB.StP;//"Data source=localhost;UserId=root;Password=1q2w3e$R;database=camloc;";
                    MySqlConnection connectionLB = new MySqlConnection(connectionStringLB);
                    if (Convert.ToDateTime(alphaBlendTextBox26.Text.ToString() + " " + alphaBlendTextBox33.Text.ToString()) < Convert.ToDateTime("29.04.2018 11:42:00"))
                    {
                        zaprosLB.ZaprBitmap(NPicKR, label18.Text.ToString(), Convert.ToInt64(IDpish));
                        zLB = zaprosLB.commandStringTest;
                        commandLB.CommandText = zLB;// commandString;
                        commandLB.Connection = connectionLB;

                        MySqlDataReader readerLB;
                        try
                        {
                            commandLB.Connection.Open();
                            readerLB = commandLB.ExecuteReader();
                            //pictureBox40.Image = null;
                            //pictureBox29.Image = null;
                            //Pic = new Stream();
                            while (readerLB.Read())
                            {

                                if (readerLB["name"].ToString() != "Video")
                                {

                                    if (readerLB["name"].ToString() == "Image")
                                    {
                                        pictureBox40.Image = StrToImg(readerLB["dataavailable"].ToString());
                                        Im = new Bitmap(StrToImg(readerLB["dataavailable"].ToString()));
                                    }
                                    if (readerLB["name"].ToString() == "ImgPlate")
                                    {
                                        pictureBox29.Image = StrToImg(readerLB["dataavailable"].ToString());
                                        ImPl = new Bitmap(StrToImg(readerLB["dataavailable"].ToString()));
                                    }
                                    if (readerLB["name"].ToString() == "ImageAlt")
                                    { ImAlt = new Bitmap(StrToImg(readerLB["dataavailable"].ToString())); }
                                    if (readerLB["name"].ToString() == "ScanS")
                                    { SkS = new Bitmap(StrToImg(readerLB["dataavailable"].ToString())); }
                                    if (readerLB["name"].ToString() == "ImageAlt1")
                                    { ImAlt1 = new Bitmap(StrToImg(readerLB["dataavailable"].ToString())); }
                                    if (readerLB["name"].ToString() == "ImageAlt2")
                                    { ImAlt2 = new Bitmap(StrToImg(readerLB["dataavailable"].ToString())); }
                                    if (readerLB["name"].ToString() == "Image1")
                                    { Im1 = new Bitmap(StrToImg(readerLB["dataavailable"].ToString())); }
                                    if (readerLB["name"].ToString() == "Image2")
                                    { Im2 = new Bitmap(StrToImg(readerLB["dataavailable"].ToString())); }
                                    if (readerLB["name"].ToString() == "ScanF")
                                    { SkF = new Bitmap(StrToImg(readerLB["dataavailable"].ToString())); }
                                    if (readerLB["name"].ToString() == "ScanT")
                                    { SkT = new Bitmap(StrToImg(readerLB["dataavailable"].ToString())); }


                                    //Pic[i] = StrToImg(readerLB["dataavailable"].ToString());
                                    PicCount = PicCount + 1;
                                }
                            }
                            readerLB.Close();
                        }
                        catch (MySqlException ex)
                        {
                            Console.WriteLine("Error: \r\n{0}", ex.ToString());
                        }
                        finally
                        {
                            commandLB.Connection.Close();
                        }
                    }
                    else
                    {
                        zaprosLB.ZaprBitmapPHOTO(NPicKR, label18.Text.ToString(), Convert.ToInt64(IDpish));
                        zLB = zaprosLB.commandStringTest;
                        commandLB.CommandText = zLB;// commandString;
                        commandLB.Connection = connectionLB;

                        MySqlDataReader readerLB;
                        try
                        {
                            commandLB.Connection.Open();
                            readerLB = commandLB.ExecuteReader();
                            pictureBox40.Image = null;
                            pictureBox29.Image = null;
                            //Pic = new Stream();
                            while (readerLB.Read())
                            {
                                if (readerLB["name"].ToString() != "Video")
                                {

                                    if (readerLB["name"].ToString() == "Image")
                                    {
                                        //string st9 = @"G:\" + readerLB["dataavailable"].ToString().Substring(13, readerLB["dataavailable"].ToString().Length - 13);
                                        string st9 = readerLB["dataavailable"].ToString();
                                        pictureBox40.Image = new Bitmap (@""+ st9);
                                        Im = new Bitmap(@""+st9);
                                    }
                                    if (readerLB["name"].ToString() == "ImgPlate")
                                    {
                                        //string st9 = @"G:\" + readerLB["dataavailable"].ToString().Substring(13, readerLB["dataavailable"].ToString().Length - 13);
                                        string st9 = readerLB["dataavailable"].ToString();
                                        pictureBox29.Image = new Bitmap(@""+st9);
                                        ImPl = new Bitmap(@""+st9);
                                    }
                                    if (readerLB["name"].ToString() == "ImageAlt")

                                    //{ string st9 = @"G:\" + readerLB["dataavailable"].ToString().Substring(13, readerLB["dataavailable"].ToString().Length - 13);
                                    { string st9 = readerLB["dataavailable"].ToString();
                                    ImAlt = new Bitmap(@""+ st9); }
                                        if (readerLB["name"].ToString() == "ScanS")
                                    //{ string st9 = @"G:\" + readerLB["dataavailable"].ToString().Substring(13, readerLB["dataavailable"].ToString().Length - 13);
                                    {
                                        string st9 = readerLB["dataavailable"].ToString();
                                        SkS = new Bitmap(@""+ st9); }
                                        if (readerLB["name"].ToString() == "ImageAlt1")
                                    //{ string st9 = @"G:\" + readerLB["dataavailable"].ToString().Substring(13, readerLB["dataavailable"].ToString().Length - 13);
                                    {
                                        string st9 = readerLB["dataavailable"].ToString();
                                        ImAlt1 = new Bitmap(@""+ st9); }
                                        if (readerLB["name"].ToString() == "ImageAlt2")
                                    //{ string st9 = @"G:\" + readerLB["dataavailable"].ToString().Substring(13, readerLB["dataavailable"].ToString().Length - 13);
                                    {
                                        string st9 = readerLB["dataavailable"].ToString();
                                        ImAlt2 = new Bitmap(@""+ st9); }
                                        if (readerLB["name"].ToString() == "Image1")
                                    //{ string st9 = @"G:\" + readerLB["dataavailable"].ToString().Substring(13, readerLB["dataavailable"].ToString().Length - 13);
                                    {
                                        string st9 = readerLB["dataavailable"].ToString();
                                        Im1 = new Bitmap(@""+ st9); }
                                        if (readerLB["name"].ToString() == "Image2")
                                    //{ string st9 = @"G:\" + readerLB["dataavailable"].ToString().Substring(13, readerLB["dataavailable"].ToString().Length - 13);
                                    {
                                        string st9 = readerLB["dataavailable"].ToString();
                                        Im2 = new Bitmap(@""+ st9); }
                                        if (readerLB["name"].ToString() == "ScanF")
                                    //{ string st9 = @"G:\" + readerLB["dataavailable"].ToString().Substring(13, readerLB["dataavailable"].ToString().Length - 13);
                                    {
                                        string st9 = readerLB["dataavailable"].ToString();
                                        SkF = new Bitmap(@""+ st9); }
                                        if (readerLB["name"].ToString() == "ScanT")
                                    //{ string st9 = @"G:\" + readerLB["dataavailable"].ToString().Substring(13, readerLB["dataavailable"].ToString().Length - 13);
                                    {
                                        string st9 = readerLB["dataavailable"].ToString();
                                        SkT = new Bitmap(@""+ st9); }

                                        PicCount = PicCount + 1;
                                }
                            }
                            readerLB.Close();
                        }
                        catch (MySqlException ex)
                        {
                            Console.WriteLine("Error: \r\n{0}", ex.ToString());
                        }
                        finally
                        {
                            commandLB.Connection.Close();
                        }
                    }
                }
            }

            #region От старой программы - позже к этому вернемся
            #region ///// Заполнение переменных о выбранном проезде для определения класса и расчета ПДК :)
            //KolOs = Convert.ToInt32(reader["axles_count"]);
            AC = new int[KolOs];
            AI = new decimal[(KolOs - 1)];
            AL = new decimal[KolOs];
            
            for (ic = 1; ic < KolOs + 1; ic++)
            {
                AC[ic - 1] = ic;
                if (ic < KolOs)
                { AI[ic - 1] = Convert.ToDecimal(BetOs[3, ic]); }
                AL[ic - 1] = Convert.ToDecimal((Math.Round(BetOs[4, ic - 1] - BetOs[4, ic - 1] / 100 * 10 / 1000, 3)));
                DT = alphaBlendTextBox107.Text.ToString();
                CPC = label18.Text.ToString();
                Dc = 1;
                TW = Convert.ToDecimal(ObshMass) / 1000;
                GRZ = maskedTextBox1.Text.ToString();
                if (Hpr != 0)
                { H = Hpr / 100; }
                else { H = 0; }
                if (Lpr != 0)
                { L = Lpr / 100; }
                else { L = 0; }
                if (Wpr != 0)
                { W = Wpr / 100; }
                else { W = 0; }
            }

            for (ic = 1; ic < KolOs + 1; ic++)
                if (ic < 9)
                {
                    if (l[ic] > 0)
                    {
                        D[ic] = (l[ic] + 0.3);
                    }
                    DoubO[ic] = (Convert.ToInt32(BetOs[8, ic - 1]));
                    switch (ic)
                    {
                        case 1:
                            if (D[ic] >= 2.5)
                            { TypO[ic] = 1; }
                            else if (D[ic] > 0 && D[ic] < 2.5)
                            {
                                if (KolOs == 2)
                                {
                                    TypO[ic] = 1;
                                }
                                else
                                {
                                    TypO[ic] = 2;
                                }
                                ////////////////////TypO[ic] = 2;
                            }
                            break;
                        case 2:
                            if (D[ic] >= 2.5)
                            {
                                if (D[ic - 1] >= 2.5)
                                { TypO[ic] = 1; }
                                else if (D[ic - 1] > 0 && D[ic - 1] < 2.5)
                                {
                                    TypO[ic] = 2;
                                }
                            }
                            else if (D[ic] > 0 && D[ic] < 2.5)
                            {
                                if (D[ic - 1] >= 2.5)
                                { TypO[ic] = 2; }
                                else if (D[ic - 1] > 0 && D[ic - 1] < 2.5)
                                {
                                    TypO[ic] = 3;
                                    TypO[ic - 1] = 3;
                                }

                            }
                            if (KolOs == 2)
                            {
                                TypO[ic] = 1;
                            }
                            break;
                        case 3:
                            if (D[ic] >= 2.5)
                            {
                                if (D[ic + 1] >= 2.5)
                                {
                                    if (D[ic - 1] >= 2.5)
                                    { TypO[ic] = 1;
                                    }
                                    else if (D[ic - 1] > 0 && D[ic - 1] < 2.5)
                                    {
                                        if (D[ic - 2] > 0 && D[ic - 2] < 2.5)
                                        {
                                            TypO[ic] = 3;
                                            TypO[ic - 1] = 3;
                                            TypO[ic - 2] = 3;
                                        }
                                        else { TypO[ic] = 2; TypO[ic - 1] = 2;
                                        }
                                    }
                                }
                                else if (D[ic + 1] >= 0 && D[ic + 1] < 2.5)
                                {
                                    if (D[ic - 1] >= 2.5)
                                    { TypO[ic] = 1; }
                                    else if (D[ic - 1] > 0 && D[ic - 1] < 2.5)
                                    {
                                        if (D[ic - 2] > 0 && D[ic - 2] < 2.5)
                                        {
                                            TypO[ic] = 3;
                                            TypO[ic - 1] = 3;
                                            TypO[ic - 2] = 3;
                                        }
                                        else { TypO[ic] = 2; TypO[ic - 1] = 2; }
                                    }
                                }
                            }
                            else if (D[ic] >= 0 && D[ic] < 2.5)
                            {
                                if (D[ic - 1] >= 2.5)
                                { TypO[ic] = 2; }
                                else if (D[ic - 1] > 0 && D[ic - 1] < 2.5)
                                {
                                    if (D[ic - 2] > 0 && D[ic - 2] < 2.5)
                                    {
                                        if (D[ic] == 0)
                                        { TypO[ic] = 3; TypO[ic - 1] = 3; TypO[ic - 2] = 3; break; }
                                        else { TypO[ic] = 4; TypO[ic - 1] = 4; TypO[ic - 2] = 4; }
                                    }
                                    else
                                    {
                                        if (D[ic] == 0)
                                        { TypO[ic] = 2; TypO[ic - 1] = 2; break; }
                                        else { TypO[ic] = 3; TypO[ic - 1] = 3; }
                                    }
                                }
                            }
                            break;

                        default:
                            if (D[ic] >= 2.50)
                            {
                                if (D[ic - 1] >= 2.50)
                                { TypO[ic] = 1; }
                                else if (D[ic - 1] > 0 && D[ic - 1] < 2.50)
                                {
                                    if (D[ic - 2] > 0 && D[ic - 2] < 2.50)
                                    {
                                        if (D[ic - 3] > 0 && D[ic - 3] < 2.50)
                                        {
                                            TypO[ic] = 4; TypO[ic - 1] = 4; TypO[ic - 2] = 4; TypO[ic - 3] = 4;
                                        }
                                        else { TypO[ic] = 3; TypO[ic - 1] = 3; TypO[ic - 2] = 3; }
                                    }
                                    else { TypO[ic] = 2; TypO[ic - 1] = 2; }
                                }
                            }
                            else if (D[ic] >= 0 && D[ic] < 2.50)
                            {
                                if (D[ic - 1] >= 2.50)
                                {
                                    if (D[ic] == 0)
                                    { TypO[ic] = 1; TypO[ic - 1] = 1; break; }
                                    else
                                    { TypO[ic] = 2; }
                                }
                                else if (D[ic - 1] > 0 && D[ic - 1] < 2.50)
                                {
                                    if (D[ic - 2] > 0 && D[ic - 2] < 2.50)
                                    {
                                        if (D[ic - 3] > 0 && D[ic - 3] < 2.50)
                                        {
                                            if (D[ic] == 0)
                                            { TypO[ic] = 4; TypO[ic - 1] = 4; TypO[ic - 2] = 4; TypO[ic - 3] = 4; break; }
                                            else { TypO[ic] = 5; TypO[ic - 1] = 5; TypO[ic - 2] = 5; TypO[ic - 3] = 5; }
                                        }
                                        else
                                        {
                                            if (D[ic] == 0)
                                            { TypO[ic] = 3; TypO[ic - 1] = 3; TypO[ic - 2] = 3; break; }
                                            else { TypO[ic] = 4; TypO[ic - 1] = 4; TypO[ic - 2] = 4; }
                                        }
                                    }
                                    else
                                    {
                                        if (D[ic] == 0)
                                        { TypO[ic] = 2; TypO[ic - 1] = 2; break; }
                                        else { TypO[ic] = 3; TypO[ic - 1] = 3; }
                                    }
                                }
                                else
                                {
                                    if (D[ic] == 0)
                                    { TypO[ic] = 1; TypO[ic - 1] = 1; break; }

                                }
                            }
                            break;
                    }
                }


            //ADNagr = 0;
            //RasstOs = 0;
            //DO = 0;
            //TypeO = 0;

            //TTS = 0;
            for (ic = KolOs + 1; ic < 9; ic++)
            {
                D[ic] = 0;
                DoubO[ic] = 0;
                TypO[ic] = 0;
            }
            //Cl = Convert.ToInt32(reader["vehicle_class"].ToString());
            //ObshMass = Convert.ToDouble(reader["total_weight"].ToString());

            names2 = new string[KolOs];
            names3 = new names[KolOs];
            for (int KO = 1; KO <= KolOs; KO++)
            {
                if (KO < 9)
                {
                    D111[KO] = BetOs[3, KO];
                    if (KO != KolOs)
                    {
                        names2[KO - 1] = Convert.ToString(BetOs[3, KO] / 100);
                    }
                    //names1[KO-1] = Convert.ToString(Convert.ToInt32(reader["o" + (KO) + "m"].ToString()));
                }
            }

            //D1_2 = Convert.ToDouble(reader["axles_1_2_base"].ToString());
            //D2_3 = Convert.ToDouble(reader["axles_2_3_base"].ToString());
            //D3_4 = Convert.ToDouble(reader["axles_3_4_base"].ToString());
            //D4_5 = Convert.ToDouble(reader["axles_4_5_base"].ToString());
            //D5_6 = Convert.ToDouble(reader["axles_5_6_base"].ToString());
            //D6_7 = Convert.ToDouble(reader["axles_6_7_base"].ToString());
            //D7_8 = Convert.ToDouble(reader["axles_7_8_base"].ToString());
            DLINATS = Convert.ToDouble(Lpr.ToString());
            SHIRTS = Convert.ToDouble(Hpr.ToString());
            VISTS = Convert.ToDouble(Wpr.ToString());
            #endregion ////////////////////////////////////////////////////////////////////////////////////////////////////

            #region                   //////////////////////////      заполнение таблицы данными о ТС      ////////////////////////////
            if (KolOs > 0)
            {
                GrO = 0;
                dataGridView1.RowCount = KolOs;
                for (ic = 0; ic < (KolOs); ic++)
                {
                    names3[ic].massFact = Convert.ToString(Math.Round(BetOs[4, ic] / 1000, 3));
                    if (ic > 0)
                    {
                        names3[ic].BaseDistance = Convert.ToString(BetOs[3, ic]);
                    }
                    else { names3[ic].BaseDistance = "0"; }
                    names3[ic].BaseNumber = Convert.ToString(ic + 1);
                    names3[ic].groupNumber = Convert.ToString(GrO + 1);
                    names3[ic].skatnost = Convert.ToString(Convert.ToInt32(BetOs[8, ic]) + "/" + (Convert.ToInt32(BetOs[8, ic])) * 2);
                    names3[ic].BaseDistanceSR = Convert.ToString(BetOs[17, ic]);
                    names3[ic].massSR = Convert.ToString(BetOs[16, ic]); ;
                    names3[ic].BaseDistanceNorm = "";
                    names3[ic].BaseDistancePrevSign = "";
                    names3[ic].factPremission = "false";
                    names3[ic].massK = Convert.ToString((Math.Round((BetOs[4, ic] - (BetOs[4, ic] / 100 * 10)) / 1000, 3)));
                    names3[ic].LoadAxisPermission = Convert.ToString(BetOs[16, ic]);
                    names3[ic].AxisIntervalsPermission = Convert.ToString(BetOs[17, ic]);
                    names3[ic].massPrevSR = Convert.ToString(Convert.ToDouble(names3[ic].massK) - Convert.ToDouble(names3[ic].massSR));
                    if (Convert.ToDouble(names3[ic].massPrevSR) <= 0)
                    { names3[ic].massPrevSR = "0"; }
                    else if (names3[ic].factPremission == "false")
                    { names3[ic].massPrevSR = "0"; }


                    dataGridView1[0, ic].Value = ic + 1;
                    string Sk = Convert.ToInt32(BetOs[8, ic]) + "/" + (Convert.ToInt32(BetOs[8, ic])) * 2;
                    dataGridView1[2, ic].Value = Sk;
                    if (ic > 0)
                    {
                        if (BetOs[3, ic] > 2.5)
                        {
                            //if (ic > 1 && Convert.ToDouble(reader["base" + (ic - 1) + "_" + (ic)]) < 2.5)
                            //{
                            //    GrO = GrO + 1;
                            //    dataGridView1[3, ic].Value = (Convert.ToDouble(reader["base" + (ic-1) + "_" + (ic)]));
                            //    dataGridView1[1, ic].Value = GrO;
                            //    //dataGridView1[1, ic].Value = "";
                            //    dataGridView1[4, ic].Value = (Convert.ToDouble(reader["base" + (ic) + "_" + (ic + 1)]) + 0.03);
                            //    dataGridView1[5, ic].Value = (Math.Round(Convert.ToDouble(reader["axle_" + (ic + 1) + "_leftside_load"]) / 1000, 3));
                            //    dataGridView1[6, ic].Value = (Math.Round(Convert.ToDouble(reader["axle_" + (ic + 1) + "_rightside_load"]) / 1000, 3));
                            //    dataGridView1[7, ic].Value = (Math.Round(Convert.ToDouble(reader["o" + (ic + 1) + "m"]) / 1000, 3));
                            //    dataGridView1[8, ic].Value = (Math.Round((Convert.ToDouble(reader["o" + (ic + 1) + "m"]) - (Convert.ToDouble(reader["o" + (ic + 1) + "m"]) / 100 * 5)) / 1000, 3));
                            //    dataGridView1[9, ic].Value = (9);
                            //    ////dataGridView1[11, ic].Value = Math.Round(((Convert.ToDouble(reader["o" + (ic + 1) + "m"]) - (Convert.ToDouble(reader["o" + (ic + 1) + "m"]) / 100 * 5)) / (9000 / 100) - 100), 3);
                            //    //dataGridView1[11, ic].Value = Math.Round((Math.Round((Convert.ToDouble(reader["o" + (ic + 1) + "m"]) - (Convert.ToDouble(reader["o" + (ic + 1) + "m"]) / 100 * 5)) / 1000, 3)) / (9 / 100) - 100, 3);
                            //    //dataGridView1[12, ic].Value = Math.Round((((Convert.ToDouble(reader["o" + (ic + 1) + "m"]) - (Convert.ToDouble(reader["o" + (ic + 1) + "m"]) / 100 * 5)) - (9000)) / 1000), 3);
                            //}
                            //else
                            //{
                            GrO = GrO + 1;
                            dataGridView1[3, ic].Value = (BetOs[3, ic]);
                            dataGridView1[1, ic].Value = GrO;
                            //dataGridView1[1, ic].Value = "";
                            dataGridView1[4, ic].Value = (BetOs[3, ic] + 0.03);
                            dataGridView1[5, ic].Value = (Math.Round(BetOs[5, ic] / 1000, 3));
                            dataGridView1[6, ic].Value = (Math.Round(BetOs[6, ic] / 1000, 3));
                            dataGridView1[7, ic].Value = (Math.Round(BetOs[4, ic] / 1000, 3));
                            dataGridView1[8, ic].Value = (Math.Round((BetOs[4, ic] - BetOs[4, ic] / 100 * 10) / 1000, 3));
                            //dataGridView1[9, ic].Value = (9);
                            ////dataGridView1[11, ic].Value = Math.Round(((Convert.ToDouble(reader["o" + (ic + 1) + "m"]) - (Convert.ToDouble(reader["o" + (ic + 1) + "m"]) / 100 * 5)) / (9000 / 100) - 100), 3);
                            //dataGridView1[11, ic].Value = Math.Round((Math.Round((Convert.ToDouble(reader["o" + (ic + 1) + "m"]) - (Convert.ToDouble(reader["o" + (ic + 1) + "m"]) / 100 * 5)) / 1000, 3)) / (9 / 100) - 100, 3);
                            //dataGridView1[12, ic].Value = Math.Round((((Convert.ToDouble(reader["o" + (ic + 1) + "m"]) - (Convert.ToDouble(reader["o" + (ic + 1) + "m"]) / 100 * 5)) - (9000)) / 1000), 3);

                            //}
                        }
                        else if (BetOs[3, ic] > 2.5)
                        {
                            KGr = KGr + 1;
                            //GrO = GrO; ///+ 1;
                            dataGridView1[3, ic].Value = (BetOs[3, ic]);
                            dataGridView1[1, ic - 1].Value = GrO;
                            dataGridView1[1, ic].Value = GrO;
                            dataGridView1[4, ic].Value = (BetOs[3, ic] + 0.03);
                            dataGridView1[5, ic].Value = (Math.Round(BetOs[5, ic] / 1000, 3));
                            dataGridView1[6, ic].Value = (Math.Round(BetOs[6, ic] / 1000, 3));
                            dataGridView1[7, ic].Value = (Math.Round(BetOs[4, ic] / 1000, 2));
                            dataGridView1[8, ic].Value = (Math.Round((BetOs[4, ic] - BetOs[4, ic] / 100 * 10) / 1000, 3));
                            //dataGridView1[9, ic].Value = (9);
                            ////dataGridView1[11, ic].Value = Math.Round(((Convert.ToDouble(reader["o" + (ic + 1) + "m"]) - (Convert.ToDouble(reader["o" + (ic + 1) + "m"]) / 100 * 5)) / (9000 / 100) - 100), 3);
                            //dataGridView1[11, ic].Value = Math.Round((Math.Round((Convert.ToDouble(reader["o" + (ic + 1) + "m"]) - (Convert.ToDouble(reader["o" + (ic + 1) + "m"]) / 100 * 5)) / 1000, 3)) / (9 / 100) - 100, 3);
                            //dataGridView1[12, ic].Value = Math.Round((((Convert.ToDouble(reader["o" + (ic + 1) + "m"]) - (Convert.ToDouble(reader["o" + (ic + 1) + "m"]) / 100 * 5)) - (9000)) / 1000), 3);
                        }
                        else
                        {
                            KGr = KGr + 1;
                            dataGridView1[3, ic].Value = (BetOs[3, ic]);
                            dataGridView1[1, ic - 1].Value = GrO;
                            dataGridView1[1, ic].Value = GrO;
                            dataGridView1[4, ic].Value = (BetOs[3, ic] + 0.03);
                            dataGridView1[5, ic].Value = (Math.Round(BetOs[5, ic] / 1000, 3));
                            dataGridView1[6, ic].Value = (Math.Round(BetOs[6, ic] / 1000, 3));
                            dataGridView1[7, ic].Value = (Math.Round(BetOs[4, ic] / 1000, 3));
                            dataGridView1[8, ic].Value = (Math.Round((BetOs[4, ic] - BetOs[4, ic] / 100 * 10) / 1000, 3));
                            //dataGridView1[9, ic].Value = (9);
                            ////dataGridView1[11, ic].Value = Math.Round(((Convert.ToDouble(reader["o" + (ic + 1) + "m"]) - (Convert.ToDouble(reader["o" + (ic + 1) + "m"]) / 100 * 5)) / (9000 / 100) - 100), 3);
                            //dataGridView1[11, ic].Value = Math.Round((Math.Round((Convert.ToDouble(reader["o" + (ic + 1) + "m"]) - (Convert.ToDouble(reader["o" + (ic + 1) + "m"]) / 100 * 5)) / 1000, 3)) / (9 / 100) - 100, 3);
                            //dataGridView1[12, ic].Value = Math.Round((((Convert.ToDouble(reader["o" + (ic + 1) + "m"]) - (Convert.ToDouble(reader["o" + (ic + 1) + "m"]) / 100 * 5)) - (9000)) / 1000), 3);
                        }
                    }
                    else
                    {
                        //KGr = KGr++;
                        GrO = GrO + 1;
                        dataGridView1[1, ic].Value = GrO;
                        dataGridView1[3, ic].Value = "-";
                        dataGridView1[4, ic].Value = "-";
                        dataGridView1[5, ic].Value = (Math.Round(BetOs[5, ic] / 1000, 3));
                        dataGridView1[6, ic].Value = (Math.Round(BetOs[6, ic] / 1000, 3));
                        dataGridView1[7, ic].Value = (Math.Round(BetOs[4, ic] / 1000, 3));
                        dataGridView1[8, ic].Value = (Math.Round((BetOs[4, ic] - BetOs[4, ic] / 100 * 10) / 1000, 3));
                        //dataGridView1[9, ic].Value = (9);
                        ////dataGridView1[11, ic].Value = Math.Round(((Convert.ToDouble(reader["o" + (ic + 1) + "m"]) - (Convert.ToDouble(reader["o" + (ic + 1) + "m"]) / 100 * 5)) / (9000 / 100) - 100), 3);
                        //dataGridView1[11, ic].Value = Math.Round((Math.Round((Convert.ToDouble(reader["o" + (ic + 1) + "m"]) - (Convert.ToDouble(reader["o" + (ic + 1) + "m"]) / 100 * 5)) / 1000, 3)) / (9 / 100)-100, 3);
                        //dataGridView1[12, ic].Value = Math.Round((((Convert.ToDouble(reader["o" + (ic + 1) + "m"]) - (Convert.ToDouble(reader["o" + (ic + 1) + "m"]) / 100 * 5)) - (9000)) / 1000), 3);
                    }
                    if (Convert.ToDouble(dataGridView1[11, ic].Value) < 0)
                    { dataGridView1[11, ic].Value = 0; }
                }
            }
            #endregion  ////////////////////////////////////////////////////////////////////////////////////

            #region/////////////////////////////////////////            заполнение таблицы групп осей

            if (GrO > 0)
            {
                //int NOs = 1;
                //GrO = 0;
                dataGridView2.RowCount = GrO;
                KN[1, 0] = Convert.ToInt32(TypO[1]);
                KN[0, 0] = 1;
                /////////////////////////////////////////////       Заполняем первую строку ///////////////////////////////////////////////////
                if (KN[1, 0] == 1)
                {
                    dataGridView2[0, 0].Value = 1;
                    dataGridView2[1, 0].Value = TypO[1];
                    Sk = Convert.ToInt32(BetOs[8, 0]) + "/" + (Convert.ToInt32(BetOs[8, 0])) * 2;
                    dataGridView2[2, 0].Value = Sk;

                    dataGridView2[3, 0].Value = "-";
                    dataGridView2[4, 0].Value = "-";
                    dataGridView2[5, 0].Value = (Math.Round(BetOs[5, 0] / 1000, 3));
                    dataGridView2[6, 0].Value = (Math.Round(BetOs[6, 0] / 1000, 3));
                    dataGridView2[7, 0].Value = (Math.Round(BetOs[4, 0] / 1000, 3));
                    dataGridView2[8, 0].Value = (Math.Round((BetOs[4, 0] - (BetOs[4, 0] / 100 * 10)) / 1000, 3));
                }
                else if (KN[1, 0] > 1)
                {
                    D1_2 = 0;
                    D2_3 = 0;
                    D3_4 = 0;
                    D4_5 = 0;
                    D5_6 = 0;
                    for (ic = 0; ic < TypO[1]; ic++)
                    {
                        D1_2 = D1_2 + BetOs[8, ic];
                        D2_3 = D2_3 + (Math.Round(BetOs[5, ic] / 1000, 3));
                        D3_4 = D3_4 + (Math.Round(BetOs[6, ic] / 1000, 3));
                        D4_5 = D4_5 + (Math.Round(BetOs[4, ic] / 1000, 3));
                        D5_6 = D5_6 + BetOs[3, ic];
                    }
                    dataGridView2[0, 0].Value = 1;
                    dataGridView2[1, 0].Value = TypO[1];
                    Sk = D1_2 / TypO[1] + "/" + (D1_2 * 2) / TypO[1];
                    dataGridView2[2, 0].Value = Sk;
                    dataGridView2[3, 0].Value = D5_6 / (TypO[1] - 1);// BetOs[3, 0];
                    dataGridView2[4, 0].Value = (D5_6 / (TypO[1] - 1) + 0.03); ;
                    dataGridView2[5, 0].Value = D2_3;
                    dataGridView2[6, 0].Value = D3_4;
                    dataGridView2[7, 0].Value = D4_5;
                    dataGridView2[8, 0].Value = (D4_5) - (D4_5 / 100 * 10);
                }
                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                //////////////////////// Заполняем строки таблицы больше чем первая

                for (ic = 1; ic < GrO; ic++)
                {
                    Sk = "";
                    for (j = 0; j <= ic; j++)
                    {
                        Sk = Sk + Convert.ToString(KN[1, j]);
                    }
                    Sk = Sk + "1";
                    Fx = 0;
                    for (j = 0; j < Sk.Length; j++)
                    {
                        Fx = Fx + int.Parse(Convert.ToString(Sk[j]));
                    }
                    KN[1, ic] = Convert.ToInt32(TypO[Fx]);//Количество
                    KN[0, ic] = Fx; //Позиция                            
                }
                //////////////////////////////////////////////////////////////////////

                for (ic = 1; ic < GrO; ic++)
                {
                    if (KN[1, ic] == 1)
                    {
                        dataGridView2[0, ic].Value = ic + 1;
                        dataGridView2[1, ic].Value = TypO[KN[0, ic]];
                        Sk = Convert.ToInt32(BetOs[8, ic]) + "/" + Convert.ToInt32(BetOs[8, ic] * 2);
                        dataGridView2[2, ic].Value = Sk;
                        dataGridView2[3, ic].Value = BetOs[3, KN[0, ic] - 1];
                        dataGridView2[4, ic].Value = (BetOs[3, KN[0, ic] - 1] + 0.03); ;
                        dataGridView2[5, ic].Value = (Math.Round(BetOs[5, ic] / 1000, 3));
                        dataGridView2[6, ic].Value = (Math.Round(BetOs[6, ic] / 1000, 3));
                        dataGridView2[7, ic].Value = (Math.Round(BetOs[4, ic] / 1000, 3));
                        dataGridView2[8, ic].Value = (Math.Round((BetOs[4, ic] - (BetOs[4, ic] / 100 * 10)) / 1000, 3));
                    }
                    else if (KN[1, ic] > 1)
                    {
                        D1_2 = 0;
                        D2_3 = 0;
                        D3_4 = 0;
                        D4_5 = 0;
                        D5_6 = 0;
                        for (icC = KN[0, ic]; icC <= (KN[0, ic] - 1 + KN[1, ic]); icC++)
                        {
                            D1_2 = D1_2 + BetOs[8, icC - 1];
                            D2_3 = D2_3 + (Math.Round(BetOs[5, icC - 1] / 1000, 3));
                            D3_4 = D3_4 + (Math.Round(BetOs[6, icC - 1] / 1000, 3));
                            D4_5 = D4_5 + (Math.Round(BetOs[4, icC - 1] / 1000, 3));
                            if (KN[1, ic] > 2)
                            { D5_6 = D5_6 + BetOs[3, icC]; }// KN[0, ic]]; }
                            else { D5_6 = BetOs[3, KN[0, ic]]; }
                        }
                        dataGridView2[0, ic].Value = ic + 1;
                        dataGridView2[1, ic].Value = TypO[KN[0, ic]];
                        Sk = (Math.Floor(Convert.ToInt32(D1_2) / TypO[KN[0, ic]])) + "/" + Math.Floor((Convert.ToInt32(D1_2) / TypO[KN[0, ic]]) * 2);
                        dataGridView2[2, ic].Value = Sk;

                        //////////////////а = 0.9876;
                        //////////////////b = 0.98(а, сокращенное до 2 - х знаков после запятой).
                        ////////////////////////b = Math.Truncate(a * 100) / 100;
                        if (KN[1, ic] > 2)
                        {
                            dataGridView2[3, ic].Value = D5_6 / (TypO[KN[0, ic]] - 1);// BetOs[3, 0];
                            dataGridView2[4, ic].Value = (D5_6 / (TypO[KN[0, ic]] - 1) + 0.03);
                        }
                        else
                        {
                            dataGridView2[3, ic].Value = D5_6;// BetOs[3, 0];
                            dataGridView2[4, ic].Value = (D5_6 + 0.03);
                        }
                        //if (BetOs[3, ic] >= BetOs[3, ic+1])
                        //{
                        //    dataGridView2[3, ic].Value = BetOs[3, ic+1];
                        //    dataGridView2[4, ic].Value = (BetOs[3, ic+1] + 0.03);
                        //}
                        //else
                        //{
                        //    dataGridView2[3, ic].Value = BetOs[3, ic];
                        //    dataGridView2[4, ic].Value = (BetOs[3, ic] + 0.03);
                        //}

                        //dataGridView2[3, ic].Value = Convert.ToDouble(reader["base" + (ic+1) + "_" + (ic + 2)]);
                        //    dataGridView2[4, ic].Value = (Convert.ToDouble(reader["base" + (ic+1) + "_" + (ic + 2)]) + 0.03); ;
                        dataGridView2[5, ic].Value = D2_3;
                        dataGridView2[6, ic].Value = D3_4;
                        dataGridView2[7, ic].Value = D4_5;
                        dataGridView2[8, ic].Value = (Math.Round(D4_5 - (Convert.ToDouble(D4_5) / 100 * 10), 3));
                    }
                }
                //////////////////////////////////////////////////////////////
            }
            #endregion                  ////////////////////////////////////////////////////////////////////////////////////////////////////

            //////          ////////////////////////////////////////////////////// Запрос класса ТС (левый)   //////////////////////////
            ZKL();
            //////////////////////////////////////////////////////// Запрос ПДК Общ массы
            ZObPDK();
            //////////////////////////////////////////////////////// Запрос ПДК Габаритов
            ZGabarPDK();
            ////////          ////////////////////////////////////////////////////// Запрос изменена ли запись   //////////////////////////
            ZIzm(IDTS);
            ////ZIzmR(Convert.ToInt32(alphaBlendTextBox10.Text));
            //#endregion Левая часть
            #region /////////////////////////////////// Загр ПР ЧАСТИ  ////////////////////////////////////////   

            //PRSpisPr();

            #endregion //////////////////////////////////////////////////////////

        }


        public void PRSpisPr()
        {

            ConnectStr conStrR = new ConnectStr();
            Zapros zapros1 = new Zapros();
            COs = KolOs;// Convert.ToInt32(alphaBlendTextBox13.Text);
            D1 = dateTimePicker1.Value.ToString("yyyy.MM.dd HH:mm:ss");
            D2 = dateTimePicker2.Value.ToString("yyyy.MM.dd HH:mm:ss");
            //Cl = Convert.ToInt32(alphaBlendTextBox11.Text);
            //int IDTSO = 0;
            conStrR.ConStr(1);
            zapros1.ZaprPrCamTabLoc(COs, D1, D2, Cl, WM);
            cstr = conStrR.StP;
            z = zapros1.commandStringTest;
            //MessageBox.Show(cstr);
            connection1 = new MySqlConnection(cstr);

            //if (this.OpenConnection() == true)
            //{
            mySqlDataAdapter = new MySqlDataAdapter(z, connection1);
            //mySqlDataAdapter = new MySqlDataAdapter("SELECT * from `raptnapr`", connection);
            DataSet DSPR = new DataSet();
            mySqlDataAdapter.Fill(DSPR);
            // DS.Tables[0].DefaultView.RowFilter = string.Format("`№ комплекса` LIKE '%{0}%'", "BU");
            //dataGridView11.DataSource = DS.Tables[0];
            dataGridView11.DataSource = DSPR.Tables[0];
            int ss = 0;
            for (ss = 1; ss < 12; ss++)
            { dataGridView11.Columns[ss].Visible = false; }
            ss = 0;
            for (ss = 14; ss < 20; ss++)
            { dataGridView11.Columns[ss].Visible = false; }
            dataGridView11.Columns[21].Visible = false;
            ss = 0;
            for (ss = 23; ss < 28; ss++)
            { dataGridView11.Columns[ss].Visible = false; }
            ss = 0;
            for (ss = 29; ss < 35; ss++)
            { dataGridView11.Columns[ss].Visible = false; }
            for (ss = 36; ss < 38; ss++)
            { dataGridView11.Columns[ss].Visible = false; }

            ss = 0;
            for (ss = 39; ss < 201; ss++)
            { dataGridView11.Columns[ss].Visible = false; }
            dataGridView11.Refresh();

            alphaBlendTextBox10.Text = dataGridView11[0, 0].Value.ToString(); //dataGridView11[0, 0].Value.ToString();
            toolStripLabel18.Text = dataGridView11.Rows.Count.ToString();
            //alphaBlendTextBox6.Text = dataGridView11[3, 0].Value.ToString();
            //alphaBlendTextBox9.Text = dataGridView11[4, 0].Value.ToString().Substring(0, 10);
            ////////////////////ZagrdataGridView11(Convert.ToInt32(dataGridView11[0, 0].Value.ToString()));

            connection1.Close();
            //this.CloseConnection();
            //}
            //////////////////////////////////////

        }
        #endregion /////////////////////////////////// Длина межосев  //////////////////////////////////////////


        private void label41_TextChanged(object sender, EventArgs e)
        {
            //DataView MyDataView = new DataView(this.DataSet2.pmonitor);
            //MyDataView.RowFilter = "IDTS =" + Convert.ToInt32(label41.Text);
            //this.pmonitorBindingSource.DataSource = MyDataView;
        }



        #region/////////////////////////////////////////////            Карусель  рисунков 
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (iPic > 0 && iPic <= PicCount)
            {
                if (iPic == 1)
                {
                    iPic = iPic - 1;
                    pictureBox40.Image = null;
                    pictureBox40.Image = Im;
                }
                if (iPic == 2)
                {
                    iPic = iPic - 1;
                    pictureBox40.Image = null;
                    pictureBox40.Image = ImAlt;
                }
                if (iPic == 3)
                {
                    iPic = iPic - 1;
                    pictureBox40.Image = null;
                    pictureBox40.Image = ImPl;
                }
                if (iPic == 4)
                {
                    iPic = iPic - 1;
                    pictureBox40.Image = null;
                    pictureBox40.Image = SkS;
                }
                if (iPic == 5)
                {
                    iPic = iPic - 1;
                    pictureBox40.Image = null;
                    pictureBox40.Image = SkF;
                }
                if (iPic == 6)
                {
                    iPic = iPic - 1;
                    pictureBox40.Image = null;
                    pictureBox40.Image = SkT;
                }
                if (iPic == 7)
                {
                    iPic = iPic - 1;
                    pictureBox40.Image = null;
                    pictureBox40.Image = ImAlt1;
                }
                if (iPic == 8)
                {
                    iPic = iPic - 1;
                    pictureBox40.Image = null;
                    pictureBox40.Image = Im1;
                }
                if (iPic == 9)
                {
                    iPic = iPic - 1;
                    pictureBox40.Image = null;
                    pictureBox40.Image = ImAlt2;
                }
                if (iPic == 10)
                {
                    iPic = iPic - 1;
                    pictureBox40.Image = null;
                    pictureBox40.Image = Im2;
                }
            }
            else
            {
                iPic = PicCount;
            }

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (iPic > 0 && iPic <= PicCount)
            {
                if (iPic == 10)
                {
                    iPic = iPic + 1;
                    pictureBox40.Image = null;
                    pictureBox40.Image = Im;
                }
                if (iPic == 9)
                {
                    iPic = iPic + 1;
                    pictureBox40.Image = null;
                    pictureBox40.Image = ImAlt;
                }
                if (iPic == 8)
                {
                    iPic = iPic + 1;
                    pictureBox40.Image = null;
                    pictureBox40.Image = ImPl;
                }
                if (iPic == 7)
                {
                    iPic = iPic + 1;
                    pictureBox40.Image = null;
                    pictureBox40.Image = SkS;
                }
                if (iPic == 6)
                {
                    iPic = iPic + 1;
                    pictureBox40.Image = null;
                    pictureBox40.Image = SkF;
                }
                if (iPic == 5)
                {
                    iPic = iPic + 1;
                    pictureBox40.Image = null;
                    pictureBox40.Image = SkT;
                }
                if (iPic == 4)
                {
                    iPic = iPic + 1;
                    pictureBox40.Image = null;
                    pictureBox40.Image = ImAlt1;
                }
                if (iPic == 3)
                {
                    iPic = iPic + 1;
                    pictureBox40.Image = null;
                    pictureBox40.Image = Im1;
                }
                if (iPic == 2)
                {
                    iPic = iPic + 1;
                    pictureBox40.Image = null;
                    pictureBox40.Image = ImAlt2;
                }
                if (iPic == 1)
                {
                    iPic = iPic + 1;
                    pictureBox40.Image = null;
                    pictureBox40.Image = Im2;
                }
            }
            else
            {
                iPic = 1;
            }

        }




        //    byte[] arrayimg = Convert.FromBase64String(StrImg);
        //Image imageStr = Image.FromStream(new MemoryStream(arrayimg));
        //    pictureBox40.Image = Pic[i];
        //}
        //if (i < 3)
        //    i = i + 1;
        //else if (i == 3) i = 1;
        //if (i == 2)
        //{
        //    if (onz != null)
        //    {
        //        pictureBox40.DataBindings.Clear();
        //        pictureBox40.Image = Image.FromStream(onz);
        //    }
        //    else { i = i++; }//pictureBox40.Image = null;
        //}
        //if (i == 3)
        //{
        //    if (ms != null)
        //    {
        //        pictureBox40.DataBindings.Clear();
        //        pictureBox40.Image = Image.FromStream(ms);
        //    }

        //    else { i = 1; }//pictureBox40.Image = null; }
        //}
        //if (i == 1)
        //{
        //    if (nz != null)
        //    {
        //        pictureBox40.DataBindings.Clear();
        //        pictureBox40.Image = Image.FromStream(nz);
        //    }
        //    else { i = i++; }//pictureBox40.Image = null; }
        //}

        //}
        #endregion/////////////////////////////////////////////
        #region/////////////////////////////////////////////            П Р А В А Я   Ч А С Т Ь

        #endregion///////////////////////////////////////////// 
        private void pictureBox40_Click(object sender, EventArgs e)
        {
            if (Form2.SelfRef.iz == 1)
            {
                FormPic newfrm = new FormPic(this.pictureBox40.Image);
                newfrm.Show();
            }
        }

        public void comboBox4_TextChanged(object sender, EventArgs e)
        {

        }
        #region/////////////////////////////////////////////            П Р А В А Я   Карусель рисунков
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (i < 3)
                i = i + 1;
            else if (i == 3) i = 1;
            if (i == 2)
            {
                if (nzdop != null)
                {
                    pictureBox43.DataBindings.Clear();
                    pictureBox43.Image = Image.FromStream(nzdop);
                }
                else { i = i++; }//pictureBox43.Image = null;
            }
            if (i == 3)
            {
                if (msdop != null)
                {
                    pictureBox43.DataBindings.Clear();
                    pictureBox43.Image = Image.FromStream(msdop);
                }

                else { i = 1; }//pictureBox43.Image = null; }
            }
            if (i == 1)
            {
                if (onzdop != null)
                {
                    pictureBox43.DataBindings.Clear();
                    pictureBox43.Image = Image.FromStream(onzdop);
                }
                else { i = i++; }//pictureBox43.Image = null; }
            }

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (i > 1)
                i = i - 1;
            else if (i == 1) i = 3;
            if (i == 2)
            {
                if (nzdop != null)
                {
                    pictureBox43.DataBindings.Clear();
                    pictureBox43.Image = Image.FromStream(nzdop);
                }
                else { i = i - 1; }//pictureBox43.Image = null;
            }
            if (i == 3)
            {
                if (msdop != null)
                {
                    pictureBox43.DataBindings.Clear();
                    pictureBox43.Image = Image.FromStream(msdop);
                }

                else { i = i - 1; }//pictureBox43.Image = null; }
            }
            if (i == 1)
            {
                if (onzdop != null)
                {
                    pictureBox43.DataBindings.Clear();
                    pictureBox43.Image = Image.FromStream(onzdop);
                }
                else { i = 3; }//pictureBox43.Image = null; }
            }
        }
        #endregion///////////////////////////////////////////// 
        public void dataGridView11_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //ConnectStr conStr = new ConnectStr();
            //Zapros zapros = new Zapros();

            int currentRow = dataGridView11.CurrentRow.Index; // номер строки, по которой кликнули
            alphaBlendTextBox10.Text = dataGridView11[0, currentRow].Value.ToString();
            //alphaBlendTextBox6.Text = dataGridView11[13, currentRow].Value.ToString();
            //alphaBlendTextBox9.Text = dataGridView11[12, currentRow].Value.ToString().Substring(0, 10);
            //ZagrdataGridView11(Convert.ToInt32(alphaBlendTextBox10.Text));
        }
        #region/////////////////////////////////////////////   загрузка всех параметров проезда для связки //////////////////  
        public void ZagrdataGridView11(int IDp)
        {
            MySqlCommand commandR = new MySqlCommand();
            ConnectStr conStrR = new ConnectStr();
            conStrR.ConStr(1);
            Zapros zaprosR = new Zapros();
            string connectionStringR;//, commandString;
            connectionStringR = conStrR.StP;//"Data source=localhost;UserId=root;Password=1q2w3e$R;database=camloc;";
            MySqlConnection connectionR = new MySqlConnection(connectionStringR);
            zaprosR.RDLYAIZMENENIYA(IDp);
            //zaprosR.ZaprAllCamNaprL(IDp);
            string zR = zaprosR.commandStringTest;
            commandR.CommandText = zR;// commandString;
            commandR.Connection = connectionR;
            MySqlDataReader readerR;
            try
            {
                commandR.Connection.Open();
                readerR = commandR.ExecuteReader();
                while (readerR.Read())
                {
                    //if (Convert.ToDouble(readerR["changerec"].ToString()) == 1)
                    //{
                    alphaBlendTextBox8.Text = readerR["namead"].ToString();
                    alphaBlendTextBox7.Text = readerR["namenapr"].ToString();
                    alphaBlendTextBox2.Text = readerR["npolos"].ToString();
                    //alphaBlendTextBox4.Text = readerR["vehicle_class"].ToString();
                    alphaBlendTextBox3.Text = readerR["nameapvk"].ToString();
                    label30.Text = readerR["Plate"].ToString();
                    label31.Text = readerR["Created"].ToString();
                    label124.Text = readerR["dislocationapvk"].ToString();
                    maskedTextBox2.Text = readerR["Plate"].ToString();
                    label30.Visible = false;
                    label31.Visible = false;
                }
                readerR.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: \r\n{0}", ex.ToString());
            }
            //MySqlCommand commandLB = new MySqlCommand();
            //ConnectStr conStrLB = new ConnectStr();
            //conStrLB.ConStr(1);
            Zapros zaprosLB = new Zapros();
            //string connectionStringLB;//, commandString;
            //connectionStringLB = conStrLB.StP;//"Data source=localhost;UserId=root;Password=1q2w3e$R;database=camloc;";
            //MySqlConnection connectionLB = new MySqlConnection(connectionStringLB);
            zaprosLB.ZaprBitmap(NPicKR, label18.Text.ToString(), Convert.ToInt64(alphaBlendTextBox25.Text.ToString()));
            zLB = zaprosLB.commandStringTest;
            commandR.CommandText = zLB;// commandString;
            //commandR.Connection = connectionLB;

            MySqlDataReader readerLB;
            try
            {
                //commandR.Connection.Open();
                readerLB = commandR.ExecuteReader();
                pictureBox40.Image = null;
                pictureBox29.Image = null;
                while (readerLB.Read())
                {
                    if (readerLB["name"].ToString() == "Image")
                    {
                        pictureBox43.Image = StrToImg(readerLB["dataavailable"].ToString());
                    }
                    if (readerLB["name"].ToString() == "ImgPlate")
                    {
                        pictureBox1.Image = StrToImg(readerLB["dataavailable"].ToString());
                    }

                }
                readerLB.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: \r\n{0}", ex.ToString());
            }
            //finally
            //{
            //    commandLB.Connection.Close();
            //}

            finally
            {
                commandR.Connection.Close();
            }
            #endregion///////////////////////////////////////////// 




        }
        #region/////////////////////////////////////////////   загрузка фото в правую часть  
        public void ZPHOTOPR()
        {
            pictureBox43.Image = null;
            pictureBox43.Invalidate();
            pictureBox1.Image = null;
            pictureBox1.Invalidate();
            MySqlCommand command = new MySqlCommand();
            ConnectStr conStr = new ConnectStr();
            Zapros zapros = new Zapros();
            conStr.ConStr(1);
            zapros.ZaprPhotoDopLoc(Convert.ToInt32(alphaBlendTextBox10.Text));
            MySqlConnection connection = new MySqlConnection(cstr);
            string z = zapros.commandStringTest;
            command.CommandText = z;// commandString;
            command.Connection = connection;
            command.CommandTimeout = 1000;
            MySqlDataReader reader;
            try
            {
                command.Connection.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    //pictureBox43.Image = null;
                    //pictureBox1.Image = null;
                    di = reader["detection_id"].ToString();
                    dii = reader["detection_image_id"].ToString();
                    if (reader["Obz"] != System.DBNull.Value) { msdop = new MemoryStream((byte[])reader["Obz"]); }
                    if (reader["lp_image"] != System.DBNull.Value) { nzdop = new MemoryStream((byte[])reader["lp_image"]); }
                    if (reader["ObzLob"] != System.DBNull.Value) { onzdop = new MemoryStream((byte[])reader["ObzLob"]); }
                    pictureBox43.Image = Image.FromStream(msdop);
                    if (nzdop != null)
                    {
                        pictureBox1.Image = Image.FromStream(nzdop);
                    }

                    #region ///// Заполнение переменных о выбранном проезде для определения класса и расчета ПДК :)
                    KolOs = Convert.ToInt32(reader["axles_count"]);
                    for (ic = 1; ic < KolOs + 1; ic++)
                    {
                        if (Convert.ToDouble(reader["axles_" + (ic) + "_" + (ic + 1) + "_base"]) > 0)
                        {
                            D[ic] = (Convert.ToDouble(reader["axles_" + (ic) + "_" + (ic + 1) + "_base"]) + 3);
                        }
                        switch (ic)
                        {
                            case 1:
                                if (D[ic] >= 250)
                                { TypO[ic] = 1;
                                }
                                else if (D[ic] > 0 && D[ic] < 250)
                                {
                                    TypO[ic] = 2;
                                }
                                break;
                            case 2:
                                if (D[ic] >= 250)
                                {
                                    if (D[ic - 1] >= 250)
                                    { TypO[ic] = 1;
                                    }
                                    else if (D[ic - 1] > 0 && D[ic - 1] < 250)
                                    {
                                        TypO[ic] = 2;
                                    }
                                }
                                else if (D[ic] > 0 && D[ic] < 250)
                                {
                                    if (D[ic - 1] >= 250)
                                    { TypO[ic] = 2;
                                    }
                                    else if (D[ic - 1] > 0 && D[ic - 1] < 250)
                                    {
                                        TypO[ic] = 3;
                                        TypO[ic - 1] = 3;
                                    }

                                }
                                break;
                            case 3:
                                if (D[ic] >= 250)
                                {
                                    if (D[ic - 1] >= 250)
                                    { TypO[ic] = 1;
                                    }
                                    else if (D[ic - 1] > 0 && D[ic - 1] < 250)
                                    {
                                        if (D[ic - 2] > 0 && D[ic - 2] < 250)
                                        {
                                            TypO[ic] = 3;
                                            TypO[ic - 1] = 3;
                                            TypO[ic - 2] = 3;
                                        }
                                        else { TypO[ic] = 2; TypO[ic - 1] = 2; }
                                    }
                                }
                                else if (D[ic] >= 0 && D[ic] < 250)
                                {
                                    if (D[ic - 1] >= 250)
                                    { TypO[ic] = 2;
                                    }
                                    else if (D[ic - 1] > 0 && D[ic - 1] < 250)
                                    {
                                        if (D[ic - 2] > 0 && D[ic - 2] < 250)
                                        {
                                            if (D[ic] == 0)
                                            { TypO[ic] = 3; TypO[ic - 1] = 3; TypO[ic - 2] = 3; break;
                                            }
                                            else { TypO[ic] = 4; TypO[ic - 1] = 4; TypO[ic - 2] = 4; }
                                        }
                                        else
                                        {
                                            if (D[ic] == 0)
                                            { TypO[ic] = 2; TypO[ic - 1] = 2; break;
                                            }
                                            else { TypO[ic] = 3; TypO[ic - 1] = 3; }
                                        }
                                    }
                                }
                                break;

                            default:
                                if (D[ic] >= 250)
                                {
                                    if (D[ic - 1] >= 250)
                                    { TypO[ic] = 1;
                                    }
                                    else if (D[ic - 1] > 0 && D[ic - 1] < 250)
                                    {
                                        if (D[ic - 2] > 0 && D[ic - 2] < 250)
                                        {
                                            if (D[ic - 3] > 0 && D[ic - 3] < 250)
                                            {
                                                TypO[ic] = 4; TypO[ic - 1] = 4; TypO[ic - 2] = 4; TypO[ic - 3] = 4;
                                            }
                                            else { TypO[ic] = 3; TypO[ic - 1] = 3; TypO[ic - 2] = 3; }
                                        }
                                        else { TypO[ic] = 2; TypO[ic - 1] = 2; }
                                    }
                                }
                                else if (D[ic] >= 0 && D[ic] < 250)
                                {
                                    if (D[ic - 1] >= 250)
                                    { TypO[ic] = 2;
                                    }
                                    else if (D[ic - 1] > 0 && D[ic - 1] < 250)
                                    {
                                        if (D[ic - 2] > 0 && D[ic - 2] < 250)
                                        {
                                            if (D[ic - 3] > 0 && D[ic - 3] < 250)
                                            {
                                                if (D[ic] == 0)
                                                { TypO[ic] = 4; TypO[ic - 1] = 4; TypO[ic - 2] = 4; TypO[ic - 3] = 4; break;
                                                }
                                                else { TypO[ic] = 5; TypO[ic - 1] = 5; TypO[ic - 2] = 5; TypO[ic - 3] = 5; }
                                            }
                                            else
                                            {
                                                if (D[ic] == 0)
                                                { TypO[ic] = 3; TypO[ic - 1] = 3; TypO[ic - 2] = 3; break;
                                                }
                                                else { TypO[ic] = 4; TypO[ic - 1] = 4; TypO[ic - 2] = 4; }
                                            }
                                        }
                                        else
                                        {
                                            if (D[ic] == 0)
                                            { TypO[ic] = 2; TypO[ic - 1] = 2; break;
                                            }
                                            else { TypO[ic] = 3; TypO[ic - 1] = 3; }
                                        }
                                    }
                                }
                                break;
                        }
                    }
                    ADNagr = 0;
                    RasstOs = 0;
                    TypeO = 0;
                    TTS = 0;
                    for (ic = KolOs + 1; ic < 9; ic++)
                    {
                        D[ic] = 0;
                        DoubO[ic] = 0;
                        TypO[ic] = 0;
                    }
                    Cl = Convert.ToInt32(reader["vehicle_class"].ToString());
                    ObshMass = Convert.ToDouble(reader["total_weight"].ToString());
                    //////////D1_2 = Convert.ToDouble(reader["axles_1_2_base"].ToString());
                    //////////D2_3 = Convert.ToDouble(reader["axles_2_3_base"].ToString());
                    //////////D3_4 = Convert.ToDouble(reader["axles_3_4_base"].ToString());
                    //////////D4_5 = Convert.ToDouble(reader["axles_4_5_base"].ToString());
                    //////////D5_6 = Convert.ToDouble(reader["axles_5_6_base"].ToString());
                    //////////D6_7 = Convert.ToDouble(reader["axles_6_7_base"].ToString());
                    //////////D7_8 = Convert.ToDouble(reader["axles_7_8_base"].ToString());
                    #endregion                  ////////////////////////////////////////////////////////////////////////////////////////////////////
                }
                reader.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: \r\n{0}", ex.ToString());
            }
            finally
            {
                command.Connection.Close();
            }
            ZKLR();
        }

        #endregion/////////////////////////////////////////////  

        #region/////////////////////////////////////////////   загрузка фото в LEFT часть  
        public void ZPHOTOLEFT()
        { if (KnPriv == 0)
            {
                MySqlCommand command = new MySqlCommand();
                ConnectStr conStr = new ConnectStr();
                conStr.ConStr(1);
                Zapros zapros = new Zapros();
                string connectionString;//, commandString;
                connectionString = conStr.StP;
                MySqlConnection connection = new MySqlConnection(connectionString);
                zapros.ZaprPhotoDopLoc(Convert.ToInt32(alphaBlendTextBox25.Text));
                string z = zapros.commandStringTest;
                command.CommandText = z;// commandString;
                command.Connection = connection;
                MySqlDataReader reader;
                try
                {
                    command.Connection.Open();
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        odi = reader["detection_id"].ToString();
                        odii = reader["detection_image_id"].ToString();
                        if (reader["Obz"] != System.DBNull.Value) { ms = new MemoryStream((byte[])reader["Obz"]); }
                        if (reader["lp_image"] != System.DBNull.Value) { nz = new MemoryStream((byte[])reader["lp_image"]); }
                        if (reader["ObzLob"] != System.DBNull.Value) { onz = new MemoryStream((byte[])reader["ObzLob"]); }
                        pictureBox40.Image = Image.FromStream(ms);
                        if (nz != null)
                        {
                            pictureBox29.Image = Image.FromStream(nz);
                        }
                    }
                    reader.Close();
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Error: \r\n{0}", ex.ToString());
                }
                finally
                {
                    command.Connection.Close();
                }
            }
            else
            {
                MySqlCommand command = new MySqlCommand();
                ConnectStr conStr = new ConnectStr();
                conStr.ConStr(1);
                Zapros zapros = new Zapros();
                string connectionString;//, commandString;
                connectionString = conStr.StP;
                MySqlConnection connection = new MySqlConnection(connectionString);
                zapros.ZaprPhotoDopLoc(Convert.ToInt32(alphaBlendTextBox25.Text));
                string z = zapros.commandStringTest;
                command.CommandText = z;// commandString;
                command.Connection = connection;
                MySqlDataReader reader;
                try
                {
                    command.Connection.Open();
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader["Obz"] != System.DBNull.Value) { ms = new MemoryStream((byte[])reader["Obz"]); }
                        if (reader["lp_image"] != System.DBNull.Value) { nz = new MemoryStream((byte[])reader["lp_image"]); }
                        if (reader["ObzLob"] != System.DBNull.Value) { onz = new MemoryStream((byte[])reader["ObzLob"]); }
                        pictureBox40.Image = Image.FromStream(ms);
                        if (nz != null)
                        {
                            pictureBox29.Image = Image.FromStream(nz);
                        }
                    }
                    reader.Close();
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Error: \r\n{0}", ex.ToString());
                }
                finally
                {
                    command.Connection.Close();
                }
            }
        }
        #endregion/////////////////////////////////////////////  

        private void button11_Click(object sender, EventArgs e)//////  Кнопка "СВЯЗАТЬ ПРОЕЗДЫ"
        {
            if (KnPriv == 0)
            {
                Ch = new string[260];
                Ch[0] = alphaBlendTextBox25.Text;//ID проезда выбранного для редактирования ТС
                Ch[1] = IDKLLeft.ToString();//ID класса выбранного для редактирования ТС
                Ch[2] = IDKLLeft.ToString();//ID комплекса выбранного для редактирования ТС
                IDTSIsh = Convert.ToInt32(alphaBlendTextBox25.Text);
                IDTSKon = Convert.ToInt32(alphaBlendTextBox10.Text);
                NDI = di;
                NDII = dii;
                OII = odi;
                OIID = odii;
                OGRZ = maskedTextBox1.Text;//label13.Text + label12.Text + label11.Text + label10.Text + label8.Text + label7.Text + label5.Text + label9.Text + label6.Text;
                OKL = alphaBlendTextBox4.Text;
                NLP = label30.Text;
                OlDat = label31.Text;
                chang = 1;
            }
            else if (KnPriv == 1)
            {
                Ch = new string[260];
                IDTSIsh = Convert.ToInt32(alphaBlendTextBox25.Text);
                IDTSKon = Convert.ToInt32(alphaBlendTextBox10.Text);
                OGRZ = alphaBlendTextBox16.Text;
                OKL = alphaBlendTextBox4.Text;
                NLP = label24.Text;
                OlDat = "";
                chang = 0;
            }
            IDTSIsh = Convert.ToInt32(alphaBlendTextBox25.Text);
            MySqlCommand command = new MySqlCommand();
            ConnectStr conStr = new ConnectStr();
            Zapros zapros = new Zapros();
            conStr.ConStr(1);
            string connectionString;//, commandString;
            connectionString = conStr.StP;//"Data source=localhost;UserId=root;Password=1q2w3e$R;database=camloc;";
            MySqlConnection connection2 = new MySqlConnection(connectionString);
            zapros.ZaprObrabotLoc(IDTSIsh, IDTSKon, NDI, NDII, OII, OIID, OGRZ, OKL, NLP, NamU, OlDat, chang);
            string z = zapros.commandStringTest;
            command.CommandText = z;// commandString;
            command.Connection = connection2;
            try
            {
                command.Connection.Open();
                command.ExecuteNonQuery();
                command.Connection.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: \r\n{0}", ex.ToString());
            }
            finally
            {
                command.Connection.Close();
            }

            MySqlCommand command1 = new MySqlCommand();
            ConnectStr conStr1 = new ConnectStr();
            Zapros zapros1 = new Zapros();
            conStr1.ConStr(1);
            zapros1.ZaprObrSvyazLoc(IDTSIsh, NamU, 1);
            MySqlConnection connection1 = new MySqlConnection(cstr);
            string z1 = zapros.commandStringTest;
            command1.CommandText = z1;
            command1.Connection = connection1;
            try
            {
                command1.Connection.Open();
                command1.ExecuteNonQuery();
                command1.Connection.Close();
            }
            catch (MySqlException ex)
            { Console.WriteLine("Error: \r\n{0}", ex.ToString()); }
            finally
            { command1.Connection.Close(); }

            ZIzm(IDTSIsh);
        }
        private void pictureBox1_Click(object sender, EventArgs e)/////  Щелчек на номере (для редактирования)
        {
            maskedTextBox1.Visible = true;
            button1.Visible = true;
            button2.Visible = true;
        }
        private void button1_Click(object sender, EventArgs e)////////  Кнопка "Принять изменения ГРЗ"
        {
            string OGRZ = maskedTextBox1.Text;// label13.Text + label12.Text + label11.Text + label10.Text + label8.Text + label7.Text + label5.Text + label9.Text + label6.Text;
            int IDTSIsh = Convert.ToInt32(alphaBlendTextBox25.Text);
            //string NLPDO= maskedTextBox1.Text;
            string NLP = maskedTextBox1.Text.Replace(" ", "");
            if (NLP.Length < 9)
            {
                DialogResult result = MessageBox.Show("Введеный Вами номерной знак имеет структуру, \n отличную от << А 000 АА 000 >> (9 символов)\n Вы действительно хотите сохранить введеный знак?", "Изменение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {

                }
                if (result == DialogResult.Yes)
                {
                    chang = 2;
                    MySqlCommand command = new MySqlCommand();
                    ConnectStr conStr = new ConnectStr();
                    Zapros zapros = new Zapros();
                    conStr.ConStr(1);
                    //string connectionString2;//, commandString;
                    cstr = conStr.StP;//"Data source=localhost;UserId=root;Password=1q2w3e$R;database=camloc;";
                    //MySqlConnection connection2 = new MySqlConnection(connectionString2);
                    zapros.ZaprObrGRZLoc(IDTSIsh, OGRZ, NLP, NamU, chang);
                    MySqlConnection connection = new MySqlConnection(cstr);
                    string z = zapros.commandStringTest;
                    command.CommandText = z;
                    command.Connection = connection;
                    try
                    { command.Connection.Open();
                        command.ExecuteNonQuery();
                        command.Connection.Close(); }
                    catch (MySqlException ex)
                    { Console.WriteLine("Error: \r\n{0}", ex.ToString()); }
                    finally
                    { command.Connection.Close(); }
                }
            }
            else { chang = 2;
                MySqlCommand command = new MySqlCommand();
                ConnectStr conStr = new ConnectStr();
                Zapros zapros = new Zapros();
                conStr.ConStr(1);
                cstr = conStr.StP;
                zapros.ZaprObrGRZLoc(IDTSIsh, OGRZ, NLP, NamU, chang);
                MySqlConnection connection = new MySqlConnection(cstr);
                string z = zapros.commandStringTest;
                command.CommandText = z;
                command.Connection = connection;
                try
                {
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }
                catch (MySqlException ex)
                { Console.WriteLine("Error: \r\n{0}", ex.ToString()); }
                finally
                { command.Connection.Close(); }
            }
            //maskedTextBox1.Visible = false;           
            button1.Visible = false;
            button2.Visible = false;
            //Timer=(100);
            ZIzm(IDTSIsh);
        }
        private void button2_Click(object sender, EventArgs e)////////  Кнопка "Отменить изменения ГРЗ"
        {
            maskedTextBox1.Text = alphaBlendTextBox1.Text;
            //maskedTextBox1.Visible = false;            
            button1.Visible = false;
            button2.Visible = false;
        }
        private void pictureBox43_Click(object sender, EventArgs e)//////       нажимаем на фото справа для увеличения (просмотра)
        {
            if (Form2.SelfRef.iz == 1)
            {
                FormPic newfrm = new FormPic(this.pictureBox43.Image);
                newfrm.Show();
            }
        }
        private void alphaBlendTextBox10_TextChanged(object sender, EventArgs e)////////////// при изменении значения ID в правой части
        {
            ZPHOTOPR();
        }
        private void label62_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (FPR == 0)
            {
                Button btn = sender as Button;
                btn.Text = "Отменить фильтр";
                FPR = 1;
                tabControl1.Visible = true;
                //checkBox11.Checked = false;
                //timer2.Enabled = false;
                StopSearchPR();
                dataGridView11.Refresh();
                //this.button11.Text = "Отменить фильтр";
            }
            else if (FPR == 1)
            {
                Button btn = sender as Button;
                btn.Text = "Применить";
                //checkBox11.Checked = true;
                FPR = 0;
                tabControl1.Visible = false;
                //timer2.Enabled = true;
                dateTimePicker1.Value = Convert.ToDateTime("2017.10.09 00:00:00");
                dateTimePicker2.Value = dateTimePicker1.Value.AddHours(+1);
                //dateTimePicker1.Value = Convert.ToDateTime("2017.10.09 00:00:00");
                //dateTimePicker2.Value = Convert.ToDateTime("2017.10.09 00:10:00");
                label122.Text = "";
                rowIndex = 0;
                kol = 0;
                //    IDLF = 0;
                //    checkBox9.Checked = true;
                //    //this.button11.Text = "Применить";
            }
            //MessageBox.Show("Фильтр по выбору времени и комплекса");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("В разработке (выбрасывает проезд в формате XML)");
            #region ////////////////////////////////////// Запрос XML для федералов и регионалов по СПЕЦРАЗРЕШЕНИЮ    ////////////////////////////////
            //////try
            //////{
            //////                //string[] names = { "John", "Paul", "George", "Pete" };
            //////    XNamespace rpvk3 = "http://gucmp.ru/services/smev/pvk/resolutions/1.0.7";
            //////    XDocument doc = new XDocument(
            //////    new XElement(rpvk3 + "CheckRequestData",
            //////    new XAttribute(XNamespace.Xmlns + "rpvk3", "http://gucmp.ru/services/smev/pvk/resolutions/1.0.7"),
            //////                    new XElement(rpvk3 + "CheckPointCode", alphaBlendTextBox103.Text.ToString()),
            //////                    new XElement(rpvk3 + "VehicleRegNumber", alphaBlendTextBox1.Text.ToString()),
            //////                    new XElement(rpvk3 + "Direction", alphaBlendTextBox104.Text.ToString()),
            //////                    new XElement(rpvk3 + "Latitude", alphaBlendTextBox105.Text.ToString()),
            //////                    new XElement(rpvk3 + "Longitude", alphaBlendTextBox106.Text.ToString()),
            //////                    new XElement(rpvk3 + "CheckDate", Convert.ToDateTime(alphaBlendTextBox107.Text).ToString("yyyy-MM-ddTHH:mm:ss.FFF")), //alphaBlendTextBox107.Text.ToString()),//2016-06-29T13:02:06.473935+05:00
            //////                    new XElement(rpvk3 + "TotalWeight", alphaBlendTextBox36.Text.ToString()),
            //////                    new XElement(rpvk3 + "TotalSize",
            //////                        new XElement(rpvk3 + "Length", alphaBlendTextBox37.Text.ToString()),
            //////                        new XElement(rpvk3 + "Width", alphaBlendTextBox43.Text.ToString()),
            //////                        new XElement(rpvk3 + "Height", alphaBlendTextBox46.Text.ToString())),                                
            //////                    new XElement(rpvk3 + "AxlesCount", alphaBlendTextBox13.Text.ToString()),                               
            //////                    from n in names1
            //////                    select new XElement(rpvk3 + "AxlesLoads", n),
            //////                    from n in names2
            //////                    select new XElement(rpvk3 + "AxlesInvervals", n)));
            //////    doc.Save(@"C:\\Users\\cherednikov\\Desktop\\АКТЫ\\Request0.xml");
            //////     MessageBox.Show("XML файл успешно сохранен.", "Выполнено.");
            //////}
            //////catch
            //////{
            //////    MessageBox.Show("Невозможно сохранить XML файл.", "Ошибка.");
            //////}
            #endregion ////////////////////////////////////////////////////////////////     ////////////////////////////////
            #region ////////////////////////////////////// Запрос XML для АНГЕЛОВ    ////////////////////////////////
            if (alphaBlendTextBox1.Text != "" && (XDate[31] == "True" || XDate[30] == "True" || XDate[2] == "True" || XDate[4] == "True" || XDate[3] == "True") && Im != null && TypNar > 0)//&& ImPl,ImAlt )
            {
                try
                {
                    //string[] names = { "John", "Paul", "George", "Pete" };
                    XNamespace rpvk1 = "urn:smtp-violation";
                    XDocument doc = new XDocument(
                    new XElement("CaseData",
                    //new XAttribute(XNamespace.Xmlns + "", "urn:smtp-violation"),
                    new XAttribute(XNamespace.Xmlns + "xsi", "http://www.w3.org/2001/XMLSchema-instance"),
            //new XAttribute(XNamespace.Xmlns + "xsd", "http://www.w3.org/2001/XMLSchema"),
            new XElement("CaseViolation",
            new XElement("EquipmentName", alphaBlendTextBox53.Text.ToString()),
            new XElement("EquipmentID", alphaBlendTextBox58.Text.ToString()),
            new XElement("EquipmentType", alphaBlendTextBox54.Text.ToString()),
            new XElement("EquipmentSeriaNumber", alphaBlendTextBox56.Text.ToString()),
            new XElement("EquipmentOwner", alphaBlendTextBox63.Text.ToString()),
            new XElement("CertificateStatementSuchMeasurementNumber", alphaBlendTextBox57.Text.ToString()), //alphaBlendTextBox107.Text.ToString()),//2016-06-29T13:02:06.473935+05:00
            new XElement("CertificateStatementSuchMeasurementDate", alphaBlendTextBox60.Text.ToString()),
            new XElement("CertificateStatementSuchMeasurementRegistrationNumber", alphaBlendTextBox59.Text.ToString()),
            new XElement("CheckingDocNumber", alphaBlendTextBox62.Text.ToString()),
            new XElement("CheckingCertificateDate", alphaBlendTextBox61.Text.ToString()),
            new XElement("CheckingValid", alphaBlendTextBox64.Text.ToString()),
            new XElement("Place", alphaBlendTextBox35.Text.ToString()), //alphaBlendTextBox107.Text.ToString()),//2016-06-29T13:02:06.473935+05:00
            new XElement("HighwayName", alphaBlendTextBox29.Text.ToString()),
            new XElement("FactID", alphaBlendTextBox25.Text.ToString()),
            new XElement("ViolationDateTime", alphaBlendTextBox107.Text.ToString()),
            new XElement("StateNumber", alphaBlendTextBox1.Text.ToString()),
            new XElement("MovementDirection", alphaBlendTextBox30.Text.ToString()),
            new XElement("QuantityAxes", alphaBlendTextBox13.Text.ToString()),
            new XElement("ActID", Convert.ToString(alphaBlendTextBox58.Text.ToString() + " - " + alphaBlendTextBox25.Text.ToString())),
            new XElement("SpecialPermissionSign", XDate[12].ToString()),//alphaBlendTextBox69.Text.ToString()),
            new XElement("SpecialPermissionNumber", XDate[13].ToString()),//alphaBlendTextBox74.Text.ToString()),
            new XElement("SpecialPermissionRegistrationDate", XDate[14].ToString()),//alphaBlendTextBox73.Text.ToString()),
            new XElement("ExcessAxesSign", XDate[31].ToString()),//XDate[0].ToString()),//alphaBlendTextBox106.Text.ToString()),//!!!!!!!!!!!!!!!
            new XElement("ExcessFullWeightSign", XDate[30].ToString()),//XDate[1].ToString()),//Convert.ToString(Convert.ToDateTime(alphaBlendTextBox28.Text).ToString())), //alphaBlendTextBox107.Text.ToString()),//2016-06-29T13:02:06.473935+05:00
            new XElement("ExcessLengthSign", XDate[2].ToString()),//!!!!!!!!!!!!!!!!!!
            new XElement("ExcessHeightSign", XDate[4].ToString()),//!!!!!!!!!!!!!!!!!!!!!!!!alphaBlendTextBox36.Text.ToString()),
            new XElement("ExcessWidthSign", XDate[3].ToString()),//!!!!!!!!!!!!!!!!!!!!!!!!alphaBlendTextBox103.Text.ToString()),
            new XElement("ResolvedLoadAxisMax", alphaBlendTextBox66.Text.ToString()),
            new XElement("TrackCategory", alphaBlendTextBox66.Text.ToString()), //alphaBlendTextBox32.Text.ToString()),
            new XElement("TrackType", XDate[5].ToString()),//alphaBlendTextBox105.Text.ToString()),//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            new XElement("SpecialPermissionCompany", XDate[15].ToString()),//alphaBlendTextBox70.Text.ToString()),
            new XElement("SpecialPermissionStartDate", XDate[16].ToString()),//Convert.ToString(Convert.ToDateTime(alphaBlendTextBox73.Text).ToString("yyyy-MM-ddTHH:mm:ss.FFF"))), //alphaBlendTextBox107.Text.ToString()),//2016-06-29T13:02:06.473935+05:00
            new XElement("SpecialPermissionEndDate", XDate[17].ToString()),//Convert.ToString(Convert.ToDateTime(alphaBlendTextBox75.Text).ToString("yyyy-MM-ddTHH:mm:ss.FFF"))),// alphaBlendTextBox36.Text.ToString()),
            new XElement("RouteViolationSign", XDate[18].ToString()),//!!!!!!!!!!!!!!!!!!!!alphaBlendTextBox1.Text.ToString()),
            new XElement("TripCountFact", alphaBlendTextBox79.Text.ToString()),
            new XElement("RoadType", alphaBlendTextBox32.Text.ToString()), //alphaBlendTextBox32.Text.ToString()),//!!!!!!!!!!!!!!!!!!!!!!
            new XElement("ExcessFactMedia", NRUB + "_" + alphaBlendTextBox25.Text + "_" + DateTime.Now.ToString("ddMMyyyy") + "_1.Jpeg"),//!!!!!!!!!!!!!!!!!!!!!!alphaBlendTextBox106.Text.ToString()),
            new XElement("ExcessFactMedia", NRUB + "_" + alphaBlendTextBox25.Text + "_" + DateTime.Now.ToString("ddMMyyyy") + "_2.Jpeg"),//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!Convert.ToDateTime(alphaBlendTextBox107.Text).ToString("yyyy-MM-ddTHH:mm:ss.FFF")), //alphaBlendTextBox107.Text.ToString()),//2016-06-29T13:02:06.473935+05:00
            new XElement("ExcessFactMedia", NRUB + "_" + alphaBlendTextBox25.Text + "_" + DateTime.Now.ToString("ddMMyyyy") + "_3.Jpeg")),//!!!!!!!!!!!!!!!!!!!!!!!!!!!//alphaBlendTextBox36.Text.ToString())),
            new XElement("SpeedViolation",
            new XElement("Speed", alphaBlendTextBox80.Text.ToString()),
            new XElement("SpeedWIM", XDate[6].ToString()),//(Convert.ToDouble(alphaBlendTextBox80.Text.ToString()) - Convert.ToDouble(alphaBlendTextBox80.Text.ToString()) / 100 * 10)),//!!!!!!!!!!!!!!!!!!alphaBlendTextBox43.Text.ToString()),
            new XElement("DifferenceSpeedPermissionFact", XDate[7].ToString()),//alphaBlendTextBox43.Text.ToString()),//!!!!!!!!!!!!!!!!!!!!
            new XElement("ExcessSpeed", XDate[8].ToString())),//alphaBlendTextBox46.Text.ToString())),//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            new XElement("DimensionViolation",
            new XElement("LengthNorm", alphaBlendTextBox41.Text.ToString()),
            new XElement("WidthNorm", alphaBlendTextBox44.Text.ToString()),
            new XElement("HeightNorm", alphaBlendTextBox47.Text.ToString()),
            new XElement("ExtraLength", alphaBlendTextBox37.Text.ToString()),
            new XElement("ExtraWidth", alphaBlendTextBox43.Text.ToString()),
            new XElement("LengthPermission", XDate[19].ToString()),//!!!!!!!!!!!!!!!!!!alphaBlendTextBox43.Text.ToString()),
            new XElement("WidthPermission", XDate[20].ToString()),
            new XElement("HeightPermission", XDate[21].ToString()),//!!!!!!!!!!!!!!!!!!!alphaBlendTextBox43.Text.ToString()),
            new XElement("LengthFact", alphaBlendTextBox42.Text.ToString()),
            new XElement("WidthFact", alphaBlendTextBox45.Text.ToString()),
            new XElement("HeightFact", alphaBlendTextBox48.Text.ToString()),
            new XElement("DifferenceLengthNormaFact", XDate[9].ToString()),//alphaBlendTextBox40.Text.ToString()),//!!!!!!!!!!!!!!!!!!!!!!!
            new XElement("DifferenceWidthNormaFact", XDate[10].ToString()),//alphaBlendTextBox50.Text.ToString()),//!!!!!!!!!!!!!!!!!!!!!!!
            new XElement("DifferenceHeightNormaFact", XDate[11].ToString()),//alphaBlendTextBox52.Text.ToString()),//!!!!!!!!!!!!!!!!!!!!!!!!
            new XElement("DifferenceLengthPermissionFact", XDate[22].ToString()),//alphaBlendTextBox43.Text.ToString()),//!!!!!!!!!!!!!!!!!!!!
            new XElement("DifferenceWidthPermissionFact", XDate[23].ToString()),//alphaBlendTextBox46.Text.ToString()),//!!!!!!!!!!!!!!!!!!!!!!!!
            new XElement("DifferenceHeightPermissionFact", XDate[24].ToString())),//alphaBlendTextBox46.Text.ToString())),//!!!!!!!!!!!!!!!!!!!!!!!!
                                                                                  //new XElement("AxlesCount", alphaBlendTextBox13.Text.ToString()),
            from n in names3
            select new XElement("LoadAxisViolation",
            new XElement("AxisNumber", n.BaseNumber),//Convert.ToString(names1.Length.ToString())),// alphaBlendTextBox43.Text.ToString()),
            new XElement("LoadAxisFact", n.massFact),//alphaBlendTextBox43.Text.ToString()),
            new XElement("LoadAxisPermission", n.massSR), //alphaBlendTextBox46.Text.ToString()),
            new XElement("ExtraAxis", n.massK),//alphaBlendTextBox37.Text.ToString()),
            new XElement("DifferenceNormFact", n.massPrev),//alphaBlendTextBox43.Text.ToString()),
            new XElement("DifferencePermissionFact", n.massPrevSR),//alphaBlendTextBox43.Text.ToString()),
            new XElement("SignExcessLoadAxis", n.massSign),//alphaBlendTextBox37.Text.ToString()),
            new XElement("AxisIntervalsNorm", n.BaseDistanceNorm),//alphaBlendTextBox43.Text.ToString()),
            new XElement("AxisIntervalsPermission", n.BaseDistanceSR),//alphaBlendTextBox43.Text.ToString()),
            new XElement("AxisIntervalsFact", n.BaseDistance),//alphaBlendTextBox46.Text.ToString()),
            new XElement("DiffInterPermissionFact", n.factPremission),//alphaBlendTextBox46.Text.ToString()),
            new XElement("LoadAxisNormForFact", n.PDKmass),//alphaBlendTextBox43.Text.ToString()),
            new XElement("SignExcessIntervalAxis", n.BaseDistancePrevSign),//alphaBlendTextBox43.Text.ToString()),
            new XElement("AxisWheelsExFact", n.skatnost),//alphaBlendTextBox46.Text.ToString()),
            new XElement("AxisWheelsNumFact", n.groupNumber)),//alphaBlendTextBox46.Text.ToString())),
            new XElement("FullWeightViolation",
            new XElement("FullWeightNorm", alphaBlendTextBox23.Text.ToString()),
            new XElement("ExtraFullWeight", XDate[25].ToString()),
            new XElement("FullWeightPermission", XDate[26].ToString()),//alphaBlendTextBox46.Text.ToString()),
            new XElement("FullWeightFact", alphaBlendTextBox22.Text.ToString()),
            new XElement("DifferenceFullWeightNormaFact", XDate[27].ToString()),
            new XElement("DifferenceFullWeightPermissionFact", XDate[28].ToString())),//alphaBlendTextBox43.Text.ToString())),
            new XElement("nViolationCode", CodNar.ToString()),
            new XElement("ActPdf", Convert.ToString(alphaBlendTextBox58.Text + "-" + alphaBlendTextBox25.Text + "_" + DateTime.Now.ToString("ddMMyyyy") + ".pdf"))));
                    //from n in names2                
                    //    select new XElement("AxlesInvervals", n);        C:\Users\chere\Desktop\
                    doc.Save(@"F:\archiv\AKT\" + NRUB + "_" + alphaBlendTextBox25.Text + "_" + DateTime.Now.ToString("ddMMyyyy") + ".xml");
                    //doc.Save(@"C:\\Users\\cherednikov\\Desktop\\АКТЫ\\" + NRUB + "_" + alphaBlendTextBox25.Text + "_" + DateTime.Now.ToString("ddMMyyyy") + ".xml");
                    PDF();
                    //aaa = @"C:\\Users\\cherednikov\\Desktop\\АКТЫ\\" + DateTime.Now.ToString("dd_MM_yyyy") + "\\";
                    //CopyFolderYesterdayFiles(@"C:\\Users\\cherednikov\\Desktop\\АКТЫ\\", aaa);
                    string aaa = @"F:\\archiv\\AKT\\" + DateTime.Now.ToString("dd_MM_yyyy");
                    CopyFolderYesterdayFiles(@"F:\\archiv\\AKT\\", aaa);

                    //GetMail();


                    MySqlCommand command = new MySqlCommand();
                    ConnectStr conStr = new ConnectStr();
                    Zapros zapros = new Zapros();
                    conStr.ConStr(1);
                    cstr = conStr.StP;
                    zapros.ZaprObrOTPRLoc(Convert.ToInt32(alphaBlendTextBox25.Text.ToString()), NamU, 4);
                    MySqlConnection connection = new MySqlConnection(cstr);
                    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
                    string z = zapros.commandStringTest;
                    cmd.CommandText = z;
                    cmd.Connection = connection;

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    Close();

                    //command.CommandText = z;
                    //command.Connection = connection;
                    //try
                    //{
                    //    command.Connection.Open();
                    //    command.ExecuteNonQuery();
                    //    command.Connection.Close();
                    //}
                    //catch (MySqlException ex)
                    //{ Console.WriteLine("Error: \r\n{0}", ex.ToString()); }
                    //finally
                    //{ command.Connection.Close(); }

                    MessageBox.Show("XML файл успешно сохранен.", "Выполнено.");
                    // + alphaBlendTextBox58.Text + "
                }
                catch
                {
                    MessageBox.Show("Невозможно сохранить XML файл.", "Ошибка.");
                }
            }
            else { MessageBox.Show("Невозможно выполнить отправку файлов (не все данные корректны, либо не хватает данных).", "Ошибка."); }
            #endregion ////////////////////////////////////////////////////////////////     ////////////////////////////////
        }

        static void CopyFolderYesterdayFiles(string sourceFolder, string destFolder)
        {
            DateTime YesterdayDate = DateTime.Today.Date;
            //DirectoryInfo dirInfo = new DirectoryInfo(@"C:\\Users\\cherednikov\\Desktop\\АКТЫ\\");
            DirectoryInfo dirInfo = new DirectoryInfo(@"F:\\archiv\\AKT\\");
            if (!Directory.Exists(destFolder))
            {
                Directory.CreateDirectory(destFolder);
            }
            FileInfo[] files = dirInfo.GetFiles("*_" + DateTime.Today.Date.ToString("ddMMyyyy") + ".xml");//.AddDays(-1).ToString("yyyyMMdd") + "_*.xml");//sourceFolder);

            //DirectoryInfo directory = new DirectoryInfo(@"C:\\Users\\cherednikov\\Desktop\\АКТЫ\\" + YesterdayDate.ToString("ddMMyyyy"));//file => file.LastWriteTime.Date == YesterdayDate );
            DirectoryInfo directory = new DirectoryInfo(@"F:\\archiv\\AKT\\" + YesterdayDate.ToString("ddMMyyyy"));//file => file.LastWriteTime.Date == YesterdayDate );

            foreach (FileInfo file in files)
                File.Copy(file.FullName, Path.Combine(destFolder, file.Name));

            string[] folders = Directory.GetDirectories(sourceFolder);

            foreach (FileInfo file in files)
                File.Delete(file.FullName);

            FileInfo[] filesP = dirInfo.GetFiles("*_" + DateTime.Today.Date.ToString("ddMMyyyy") + ".pdf");//.AddDays(-1).ToString("yyyyMMdd") + "_*.xml");//sourceFolder);

            //DirectoryInfo directoryP = new DirectoryInfo(@"C:\\Users\\cherednikov\\Desktop\\АКТЫ\\" + YesterdayDate.ToString("ddMMyyyy"));//file => file.LastWriteTime.Date == YesterdayDate );
            DirectoryInfo directoryP = new DirectoryInfo(@"F:\\archiv\\AKT\\" + YesterdayDate.ToString("ddMMyyyy"));//file => file.LastWriteTime.Date == YesterdayDate );

            foreach (FileInfo file in filesP)
                File.Copy(file.FullName, Path.Combine(destFolder, file.Name));

            string[] foldersP = Directory.GetDirectories(sourceFolder);

            foreach (FileInfo file in filesP)
                File.Delete(file.FullName);
            FileInfo[] filesI = dirInfo.GetFiles("*_" + DateTime.Today.Date.ToString("ddMMyyyy") + "_*.Jpeg");//.AddDays(-1).ToString("yyyyMMdd") + "_*.xml");//sourceFolder);

            //DirectoryInfo directoryI = new DirectoryInfo(@"C:\\Users\\cherednikov\\Desktop\\АКТЫ\\" + YesterdayDate.ToString("ddMMyyyy"));//file => file.LastWriteTime.Date == YesterdayDate );
            DirectoryInfo directoryI = new DirectoryInfo(@"F:\\archiv\\AKT\\" + YesterdayDate.ToString("ddMMyyyy"));//file => file.LastWriteTime.Date == YesterdayDate );

            foreach (FileInfo file in filesI)
                File.Copy(file.FullName, Path.Combine(destFolder, file.Name));

            string[] foldersI = Directory.GetDirectories(sourceFolder);

            foreach (FileInfo file in filesI)
                File.Delete(file.FullName);
        }

        //public bool CheckRequestData(VehicleContainer inputModel)
        //{

        //    string NamF = DateTime.Now.ToString("yyyyMMdd") + "_" + DateTime.Now.ToString("HHmmss") + "_" + inputModel.CreatedBy.PlatformId + "_" + inputModel.ID;
        //    //string NamF = DateTime.Now + "_" + inputModel.ID;
        //    XmlSerializer serializer = new XmlSerializer(typeof(VehicleContainer));
        //    FileStream stream = new FileStream(@"F:\archiv\XML\" + NamF.ToString() + ".xml", FileMode.CreateNew);
        //    serializer.Serialize(stream, inputModel);
        //    string aaa = @"F:\archiv\XML\" + DateTime.Now.AddDays(-1).ToString("yyyyMMdd");
        //    CopyFolderYesterdayFiles(@"F:\archiv\XML", aaa);

        //A1[7] = alphaBlendTextBox56.Text;A1[11] = alphaBlendTextBox63.Text; A1[12] = alphaBlendTextBox57.Text;A1[15] = alphaBlendTextBox62.Text;
        //A1[9] = alphaBlendTextBox35.Text;A1[19] = alphaBlendTextBox29.
        private void button5_Click(object sender, EventArgs e)//// Создаем новый PDF документ
        {
            PDF();
        }
        public void PDF()
        {
            //PPRNAR = PrevNar[0];
            //iNar = 0;
            //for (int PrNar=1; PrNar<=27; PrNar++)
            //{
            //    if (PrevNar[PrNar] > PPRNAR)
            //    {
            //        PPRNAR = PrevNar[PrNar];
            //        iNar = PrNar;
            //    }
            //    if (iNar>=0 && iNar < 10)
            //    { TypNar = 1; }
            //    if (iNar >= 10 && iNar < 17)
            //    { TypNar = 2; }
            //    if (iNar == 17 )
            //    { TypNar = 3; }
            //    if (iNar >= 18 && iNar < 21)
            //    { TypNar = 4; }
            //    if (iNar > 20)
            //    { TypNar = 5; }
            //}


            //MNAKT();
            A1[259] = NRUB + "_" + alphaBlendTextBox25.Text;
            A1[0] = NRUB + "-" + alphaBlendTextBox25.Text;
            //A1[0] =  + alphaBlendTextBox58.Text + " - " + alphaBlendTextBox25.Text;
            A1[250] = DateTime.Now.ToString("dd.MM.yyyyг.");
            //A1[252] = alphaBlendTextBox63.Text;
            A1[1] = Convert.ToDateTime(alphaBlendTextBox26.Text).ToString("dd.MM.yyyyг.");//alphaBlendTextBox26.Text;//
            A1[2] = alphaBlendTextBox33.Text;//DateTime.Now.ToString(" HH:mm:ss");
            A1[3] = alphaBlendTextBox25.Text;
            A1[4] = alphaBlendTextBox53.Text; A1[5] = alphaBlendTextBox54.Text; /*"Комплекс измерительный автоматического весового и габаритного контроля";*/ A1[6] = alphaBlendTextBox55.Text; A1[7] = alphaBlendTextBox56.Text; /*"001/02/2018 ";*/ A1[8] = alphaBlendTextBox58.Text;
            A1[9] = alphaBlendTextBox35.Text;/*"51 км. + 106 м.";*/ A1[10] = alphaBlendTextBox31.Text; A1[11] = alphaBlendTextBox63.Text;/*" Betamont s.r.o. "*/; A1[12] = alphaBlendTextBox57.Text;/*"123456"*/; A1[13] = alphaBlendTextBox60.Text;
            A1[14] = alphaBlendTextBox59.Text; A1[15] = alphaBlendTextBox62.Text;/*"Тets - 123"*/; A1[16] = alphaBlendTextBox61.Text; A1[17] = alphaBlendTextBox64.Text; A1[18] = alphaBlendTextBox32.Text;
            A1[19] = alphaBlendTextBox29.Text;/*"г. Севастополь, а/д Симферополь-Бахчисарай-Севастополь 51 км. + 106 м.";*/ A1[20] = alphaBlendTextBox65.Text; A1[21] = alphaBlendTextBox30.Text; A1[22] = alphaBlendTextBox66.Text + " тонн/ось"; A1[23] = alphaBlendTextBox67.Text;
            A1[24] = alphaBlendTextBox68.Text; A1[25] = alphaBlendTextBox1.Text; A1[26] = FFFT;// alphaBlendTextBox12.Text;
            A1[27] = alphaBlendTextBox11.Text; A1[28] = alphaBlendTextBox13.Text;
            A1[29] = FF; A1[30] = alphaBlendTextBox69.Text; A1[31] = alphaBlendTextBox70.Text; A1[32] = alphaBlendTextBox71.Text; A1[33] = alphaBlendTextBox72.Text;
            A1[34] = alphaBlendTextBox74.Text; A1[35] = alphaBlendTextBox73.Text; A1[36] = alphaBlendTextBox75.Text; A1[37] = "-";/*alphaBlendTextBox27.Text;*/ A1[38] = alphaBlendTextBox76.Text;
            A1[39] = alphaBlendTextBox79.Text; A1[40] = alphaBlendTextBox77.Text; A1[41] = TypNarTXT.ToString();/*alphaBlendTextBox28.Text;*/ A1[42] = MAXPREVPROTC.ToString();/*alphaBlendTextBox24.Text;*/
            A1[43] = MAXPREV.ToString();/*alphaBlendTextBox27.Text;*/ A1[44] = "- 0.60 м"; A1[45] = "- 0.10 м"; A1[46] = "- 0.06 м"; A1[47] = alphaBlendTextBox42.Text;
            A1[48] = alphaBlendTextBox45.Text; A1[49] = alphaBlendTextBox48.Text; A1[50] = alphaBlendTextBox37.Text; A1[51] = alphaBlendTextBox43.Text; A1[52] = alphaBlendTextBox46.Text;
            A1[53] = alphaBlendTextBox41.Text; A1[54] = alphaBlendTextBox44.Text; A1[55] = alphaBlendTextBox47.Text; A1[56] = "-"; A1[57] = "-";
            A1[58] = "-"; A1[59] = "-"; /*alphaBlendTextBox39.Text;*/ A1[60] = "-";/*alphaBlendTextBox49.Text;*/ A1[61] = "-";/*alphaBlendTextBox51.Text;*/ A1[62] = "-";/*alphaBlendTextBox40.Text;*/
            A1[63] = "-";/*alphaBlendTextBox50.Text;*/ A1[64] = "-";/*alphaBlendTextBox52.Text;*/ A1[65] = "- 5%"; A1[66] = alphaBlendTextBox22.Text; A1[67] = alphaBlendTextBox36.Text;
            A1[68] = alphaBlendTextBox23.Text; A1[69] = "-"; A1[70] = alphaBlendTextBox24.Text; A1[71] = alphaBlendTextBox27.Text;

            A1[72] = dataGridView1[0, 0].Value.ToString(); A1[73] = dataGridView1[2, 0].Value.ToString(); A1[74] = dataGridView1[1, 0].Value.ToString(); A1[75] = dataGridView1[3, 0].Value.ToString(); A1[76] = dataGridView1[4, 0].Value.ToString();
            A1[77] = dataGridView1[7, 0].Value.ToString(); A1[78] = dataGridView1[8, 0].Value.ToString(); A1[79] = dataGridView1[9, 0].Value.ToString(); A1[80] = "-";/*dataGridView1[10, 0].Value.ToString();*/
            A1[81] = dataGridView1[11, 0].Value.ToString(); A1[82] = dataGridView1[12, 0].Value.ToString();
            if (Convert.ToInt32(alphaBlendTextBox13.Text) > 1)
            {
                A1[83] = dataGridView1[0, 1].Value.ToString(); A1[84] = dataGridView1[2, 1].Value.ToString(); A1[85] = dataGridView1[1, 1].Value.ToString(); A1[86] = dataGridView1[3, 1].Value.ToString(); A1[87] = dataGridView1[4, 1].Value.ToString();
                A1[88] = dataGridView1[7, 1].Value.ToString(); A1[89] = dataGridView1[8, 1].Value.ToString(); A1[90] = dataGridView1[9, 1].Value.ToString(); A1[91] = "-";/*dataGridView1[1, 10].Value.ToString();*/
                A1[92] = dataGridView1[11, 1].Value.ToString(); A1[93] = dataGridView1[12, 1].Value.ToString();
            }
            if (Convert.ToInt32(alphaBlendTextBox13.Text) > 2)
            {
                A1[94] = dataGridView1[0, 2].Value.ToString(); A1[95] = dataGridView1[2, 2].Value.ToString(); A1[96] = dataGridView1[1, 2].Value.ToString(); A1[97] = dataGridView1[3, 2].Value.ToString(); A1[98] = dataGridView1[4, 2].Value.ToString();
                A1[99] = dataGridView1[7, 2].Value.ToString(); A1[100] = dataGridView1[8, 2].Value.ToString(); A1[101] = dataGridView1[9, 2].Value.ToString(); A1[102] = "-";/*dataGridView1[2, 10].Value.ToString(); */
                A1[103] = dataGridView1[11, 2].Value.ToString(); A1[104] = dataGridView1[12, 2].Value.ToString();
            }
            if (Convert.ToInt32(alphaBlendTextBox13.Text) > 3)
            {
                A1[105] = dataGridView1[0, 3].Value.ToString(); A1[106] = dataGridView1[2, 3].Value.ToString(); A1[107] = dataGridView1[1, 3].Value.ToString(); A1[108] = dataGridView1[3, 3].Value.ToString(); A1[109] = dataGridView1[4, 3].Value.ToString();
                A1[110] = dataGridView1[7, 3].Value.ToString(); A1[111] = dataGridView1[8, 3].Value.ToString(); A1[112] = dataGridView1[9, 3].Value.ToString(); //A1[113] = "-";/*dataGridView1[10,3].Value.ToString();*/ 
                A1[114] = dataGridView1[11, 3].Value.ToString();
                A1[115] = dataGridView1[12, 3].Value.ToString();
            }
            if (Convert.ToInt32(alphaBlendTextBox13.Text) > 4)
            {
                A1[116] = dataGridView1[0, 4].Value.ToString(); A1[117] = dataGridView1[2, 4].Value.ToString(); A1[118] = dataGridView1[1, 4].Value.ToString(); A1[119] = dataGridView1[3, 4].Value.ToString(); A1[120] = dataGridView1[4, 4].Value.ToString();
                A1[121] = dataGridView1[7, 4].Value.ToString(); A1[122] = dataGridView1[8, 4].Value.ToString(); A1[123] = dataGridView1[9, 4].Value.ToString(); //A1[124] = "-";/*dataGridView1[10, 4].Value.ToString(); */
                A1[125] = dataGridView1[11, 4].Value.ToString();
                A1[126] = dataGridView1[12, 4].Value.ToString();
            }
            if (Convert.ToInt32(alphaBlendTextBox13.Text) > 5)
            {
                A1[127] = dataGridView1[0, 5].Value.ToString(); A1[128] = dataGridView1[2, 5].Value.ToString(); A1[129] = dataGridView1[1, 5].Value.ToString(); A1[130] = dataGridView1[3, 5].Value.ToString(); A1[131] = dataGridView1[4, 5].Value.ToString();
                A1[132] = dataGridView1[7, 5].Value.ToString(); A1[133] = dataGridView1[8, 5].Value.ToString(); A1[134] = dataGridView1[9, 5].Value.ToString(); //A1[135] = "-";/* dataGridView1[10, 5].Value.ToString();*/ 
                A1[136] = dataGridView1[11, 5].Value.ToString();
                A1[137] = dataGridView1[12, 5].Value.ToString();
            }
            if (Convert.ToInt32(alphaBlendTextBox13.Text) > 6)
            {
                A1[138] = dataGridView1[0, 6].Value.ToString(); A1[139] = dataGridView1[2, 6].Value.ToString(); A1[140] = dataGridView1[1, 6].Value.ToString(); A1[141] = dataGridView1[3, 6].Value.ToString(); A1[142] = dataGridView1[4, 6].Value.ToString();
                A1[143] = dataGridView1[7, 6].Value.ToString(); A1[144] = dataGridView1[8, 6].Value.ToString(); A1[145] = dataGridView1[9, 6].Value.ToString();// A1[146] = "-";/*dataGridView1[10, 6].Value.ToString();*/ 
                A1[147] = dataGridView1[11, 6].Value.ToString();
                A1[148] = dataGridView1[12, 6].Value.ToString();
            }
            if (Convert.ToInt32(alphaBlendTextBox13.Text) > 7)
            {
                A1[149] = dataGridView1[0, 7].Value.ToString(); A1[150] = dataGridView1[2, 7].Value.ToString(); A1[151] = dataGridView1[1, 7].Value.ToString(); A1[152] = dataGridView1[3, 7].Value.ToString(); A1[153] = dataGridView1[4, 7].Value.ToString();
                A1[154] = dataGridView1[7, 7].Value.ToString(); A1[155] = dataGridView1[8, 7].Value.ToString(); A1[156] = dataGridView1[9, 7].Value.ToString(); //A1[157] = "-";/*dataGridView1[10, 7].Value.ToString(); */
                A1[158] = dataGridView1[11, 7].Value.ToString();
                A1[159] = dataGridView1[12, 7].Value.ToString();
            }
            if (Convert.ToInt32(alphaBlendTextBox13.Text) > 8)
            {
                A1[160] = dataGridView1[0, 8].Value.ToString(); A1[161] = dataGridView1[2, 8].Value.ToString(); A1[162] = dataGridView1[1, 8].Value.ToString(); A1[163] = dataGridView1[3, 8].Value.ToString(); A1[164] = dataGridView1[4, 8].Value.ToString();
                A1[165] = dataGridView1[7, 8].Value.ToString(); A1[166] = dataGridView1[8, 8].Value.ToString(); A1[167] = dataGridView1[9, 8].Value.ToString(); //A1[168] = dataGridView1[10, 8].Value.ToString(); 
                A1[169] = dataGridView1[11, 8].Value.ToString();
                A1[170] = dataGridView1[12, 8].Value.ToString();
            }

            A1[171] = dataGridView2[0, 0].Value.ToString(); A1[172] = dataGridView2[2, 0].Value.ToString(); A1[173] = dataGridView2[1, 0].Value.ToString(); /*A1[174] = dataGridView2[3, 0].Value.ToString();*/ A1[175] = dataGridView2[4, 0].Value.ToString();
            A1[176] = dataGridView2[7, 0].Value.ToString(); A1[177] = dataGridView2[8, 0].Value.ToString(); A1[178] = dataGridView2[9, 0].Value.ToString(); A1[179] = "-";/*dataGridView2[10,0].Value.ToString(); */
            A1[180] = dataGridView2[11, 0].Value.ToString();
            A1[181] = dataGridView2[12, 0].Value.ToString();
            if (Convert.ToInt32(dataGridView2.RowCount) > 1)
            {
                A1[182] = dataGridView2[0, 1].Value.ToString(); A1[183] = dataGridView2[2, 1].Value.ToString(); A1[184] = dataGridView2[1, 1].Value.ToString(); /*A1[185] = dataGridView2[3, 1].Value.ToString();*/ A1[186] = dataGridView2[4, 1].Value.ToString();
                A1[187] = dataGridView2[7, 1].Value.ToString(); A1[188] = dataGridView2[8, 1].Value.ToString(); A1[189] = dataGridView2[9, 1].Value.ToString(); A1[190] = "-";/*dataGridView2[10, 1].Value.ToString(); */
                A1[191] = dataGridView2[11, 1].Value.ToString();
                A1[192] = dataGridView2[12, 1].Value.ToString();
            }
            if (Convert.ToInt32(dataGridView2.RowCount) > 2)
            {
                A1[193] = dataGridView2[0, 2].Value.ToString(); A1[194] = dataGridView2[2, 2].Value.ToString(); A1[195] = dataGridView2[1, 2].Value.ToString(); /*A1[196] = dataGridView2[3, 2].Value.ToString();*/ A1[197] = dataGridView2[4, 2].Value.ToString();
                A1[198] = dataGridView2[7, 2].Value.ToString(); A1[199] = dataGridView2[8, 2].Value.ToString(); A1[200] = dataGridView2[9, 2].Value.ToString(); A1[201] = "-";/*dataGridView2[10, 2].Value.ToString(); */
                A1[202] = dataGridView2[11, 2].Value.ToString();
                A1[203] = dataGridView2[12, 2].Value.ToString();
            }
            if (Convert.ToInt32(dataGridView2.RowCount) > 3)
            {
                A1[204] = dataGridView2[0, 3].Value.ToString(); A1[205] = dataGridView2[2, 3].Value.ToString(); A1[206] = dataGridView2[1, 3].Value.ToString(); /*A1[207] = dataGridView2[3, 3].Value.ToString();*/ A1[208] = dataGridView2[4, 3].Value.ToString();
                A1[209] = dataGridView2[7, 3].Value.ToString(); A1[210] = dataGridView2[8, 3].Value.ToString(); A1[211] = dataGridView2[9, 3].Value.ToString(); //A1[212] = dataGridView2[10,3].Value.ToString(); 
                A1[213] = dataGridView2[11, 3].Value.ToString();
                A1[214] = dataGridView2[12, 3].Value.ToString();
            }
            if (Convert.ToInt32(dataGridView2.RowCount) > 4)
            {
                A1[215] = dataGridView2[0, 4].Value.ToString(); A1[216] = dataGridView2[2, 4].Value.ToString(); A1[217] = dataGridView2[1, 4].Value.ToString(); /*A1[218] = dataGridView2[3, 4].Value.ToString();*/ A1[219] = dataGridView2[4, 4].Value.ToString();
                A1[220] = dataGridView2[7, 4].Value.ToString(); A1[221] = dataGridView2[8, 4].Value.ToString(); A1[222] = dataGridView2[9, 4].Value.ToString(); //A1[223] = dataGridView2[10,4].Value.ToString(); 
                A1[224] = dataGridView2[11, 4].Value.ToString();
                A1[225] = dataGridView2[12, 4].Value.ToString();
            }
            if (Convert.ToInt32(dataGridView2.RowCount) > 5)
            {
                A1[226] = dataGridView2[0, 5].Value.ToString(); A1[227] = dataGridView2[2, 5].Value.ToString(); A1[228] = dataGridView2[1, 5].Value.ToString(); /*A1[229] = dataGridView2[3, 5].Value.ToString();*/ A1[230] = dataGridView2[4, 5].Value.ToString();
                A1[231] = dataGridView2[7, 5].Value.ToString(); A1[232] = dataGridView2[8, 5].Value.ToString(); A1[233] = dataGridView2[9, 5].Value.ToString(); //A1[234] = dataGridView2[10, 5].Value.ToString(); 
                A1[235] = dataGridView2[11, 5].Value.ToString();
                A1[236] = dataGridView2[12, 5].Value.ToString();
            }
            A1[218] = alphaBlendTextBox109.Text; A1[229] = alphaBlendTextBox108.Text;
            A1[237] = "-"; A1[238] = "-"; A1[239] = "-"; A1[240] = "-";
            A1[241] = "-"; A1[242] = "-"; A1[243] = "-"; A1[244] = "-"; A1[245] = "В автоматическом режиме составлен настоящий акт № " + NRUB + "-" + alphaBlendTextBox25.Text;
            A1[246] = "Настоящий акт отправлен в ЦАФАП ОДД ГИБДД ГУ МВД по г. Севастополь"; A1[247] = "-"; A1[248] = "-"; A1[249] = "-";
            //A1[1] = "ФИГАСЕ";
            AKT_PDF AKT = new AKT_PDF();
            AKT.FormPDF(Im, ImPl, ImAlt, A1, NRUB);
            // ... и запускам сразу в программе просмотра pdf файлов
            //////////////////////////Process.Start(@"F:\" + A1[0] + "_" + DateTime.Now.ToString("ddMMyyyy") + ".pdf");

            //using (var client = new WebClient())
            //{
            //    client.DownloadFile(@"C:\source.txt", @"C:\destionation.txt");
            //}
            //    \\Win - d3j6pr1h9qk\akt
            //MessageBox.Show("В разработке (Формирует печатное постановление о нарушении в формате PDF)");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("В разработке (Формирует печатное постановление о нарушении в формате Word)");
        }
        #region //////////////////////////////////////////////////////////////// Запрос изменена ли запись    ////////////////////////////////
        public void ZIzm(int IDTS) ////////////////////////////////////////////////////// Запрос изменена ли запись   //////////////////////////
        {
            MySqlCommand command2 = new MySqlCommand();
            ConnectStr conStr2 = new ConnectStr();
            conStr2.ConStr(1);
            Zapros zapros2 = new Zapros();
            string connectionString2;//, commandString;
            connectionString2 = conStr2.StP;//"Data source=localhost;UserId=root;Password=1q2w3e$R;database=camloc;";
            MySqlConnection connection2 = new MySqlConnection(connectionString2);
            zapros2.ZaprAllCamNaprLO(IDTS);
            string z2 = zapros2.commandStringTest;
            command2.CommandText = z2;// commandString;
            command2.Connection = connection2;
            MySqlDataReader reader2;
            try
            {
                command2.Connection.Open();
                reader2 = command2.ExecuteReader();
                while (reader2.Read())
                {
                    string nom = "";
                    label32.Text = "";
                    nom = reader2["Plate"].ToString();
                    //odi = reader2["detection_id"].ToString();
                    //odii = reader2["detection_image_id"].ToString();
                    maskedTextBox1.Text = reader2["Plate"].ToString();
                    //if (nom.Length > 3)
                    //{
                    //    label13.Text = nom.Substring(0, 1);
                    //    label12.Text = nom.Substring(1, 1);
                    //    label11.Text = nom.Substring(2, 1);
                    //    if (nom.Length >= 4)
                    //    { label10.Text = nom.Substring(3, 1); }
                    //    else { label10.Text = "-"; }
                    //    if (nom.Length >= 5)
                    //    { label8.Text = nom.Substring(4, 1); }
                    //    else { label8.Text = "-"; }
                    //    if (nom.Length >= 6)
                    //    { label7.Text = nom.Substring(5, 1); }
                    //    else { label7.Text = "-"; }
                    //    if (nom.Length >= 7)
                    //    { label5.Text = nom.Substring(6, 1); }
                    //    else { label5.Text = "-"; }
                    //    if (nom.Length >= 8)
                    //    { label9.Text = nom.Substring(7, 1); }
                    //    else { label9.Text = "-"; }
                    //    if (nom.Length == 9)
                    //    { label6.Text = nom.Substring(8, 1); }
                    //    else { label6.Text = ""; }
                    //}
                    //else
                    //{   label13.Text = "-"; label12.Text = "-"; label11.Text = "-";    }

                    if (Convert.ToDouble(reader2["ChangeType"].ToString()) == 1)
                    {
                        comboBox4.Focus();
                        //// скрываем правую вкладку открываем вкладку конкретного проезда
                        this.tabPage10.Hide();
                        tabControl3.TabPages.Remove(tabPage10);
                        tabControl3.TabPages.Insert(0, tabPage14);
                        this.tabPage14.Show();
                        tabControl3.SelectedTab = tabPage14;
                        label15.Visible = false;
                        dateTimePicker1.Visible = false;
                        label16.Visible = false;
                        dateTimePicker2.Visible = false;
                        label14.Visible = false;
                        comboBox4.Visible = false;
                        button3.Visible = false;
                        comboBox5.Visible = false;
                        textBox6.Visible = false;
                        label121.Visible = false;
                        label120.Visible = false;
                        tabControl1.TabPages.Insert(0, tabPage2);
                        this.tabPage2.Show();
                        tabControl1.TabPages.Insert(0, tabPage3);
                        this.tabPage3.Show();
                        groupBox5.Text = "    Данные о связанном проезде";
                        //tabControl1.SelectedTab = tabPage14;

                        //////////////////////////////////////////////////////////   ////////////////////////////////////////////////////////////////////
                        if (reader2["OldIDPR"].ToString() != null || reader2["OldIDPR"].ToString() != "")
                        { IDSV = Convert.ToInt32(reader2["OldIDPR"].ToString()); }//// получаем номер связанного проезда (если он есть)
                        else { IDSV = 0; }
                        KnPriv = 1;
                        /// в переменные загоняем изменения для отвязки
                        IDTSKon = 0;
                        //////NDI = reader2["OldIdIm"].ToString();
                        //////NDII = reader2["OldIdImDet"].ToString();
                        //////OII = reader2["detection_id"].ToString(); 
                        //////OIID = reader2["detection_image_id"].ToString();
                        //////di= reader2["OldIdIm"].ToString();
                        //////dii=reader2["OldIdImDet"].ToString();
                        //////odi = reader2["detection_id"].ToString();
                        //////odii = reader2["detection_image_id"].ToString();
                        OGRZ = "";
                        OKL = "";
                        NLP = reader2["OldGRZ"].ToString();
                        OlDat = "";
                        chang = 0;
                        /////////////////////////////////
                        label17.Text = "Отвязать связанные проезды";
                        button11.BackgroundImage = AVGK.Properties.Resources._18695;
                        label19.Text = "Запись о проезде изменена " + reader2["DateChang"].ToString() + ".";
                        label21.Text = reader2["DateChang"].ToString();
                        label22.Text = reader2["NameUs"].ToString();
                        label24.Text = reader2["OldGRZ"].ToString();
                        label26.Text = reader2["OldIDPR"].ToString();
                        label28.Text = reader2["DateChang"].ToString();
                        label84.Text = reader2["Plate"].ToString();
                        alphaBlendTextBox53.Text = reader2["nameapvk"].ToString();//Наименование комплекса
                        alphaBlendTextBox63.Text = reader2["Vladel"].ToString();//Владелец комплекса
                        alphaBlendTextBox54.Text = reader2["TipSI"].ToString();//Тип СИ комплекса
                        alphaBlendTextBox55.Text = reader2["Model"].ToString();//Марка и модель комплекса
                        alphaBlendTextBox56.Text = reader2["sernum"].ToString();//Заводской № комплекса
                        if (Convert.ToInt64(reader2["kodapvk"].ToString()) == 2952855555)
                        { alphaBlendTextBox58.Text = "2920002";
                        }
                        else if (Convert.ToInt64(reader2["kodapvk"].ToString()) == 2952855553)
                        { alphaBlendTextBox58.Text = "2920001";
                        }
                        else
                        { alphaBlendTextBox58.Text = reader2["kodapvk"].ToString(); }

                            // alphaBlendTextBox58.Text = reader2["kodapvk"].ToString();//Код комплекса
                        alphaBlendTextBox57.Text = reader2["NomSvidTipaSI"].ToString();//№ свид.типа комплекса
                        alphaBlendTextBox60.Text = reader2["DateVidSTSI"].ToString();//Дата выд СТК № комплекса
                        alphaBlendTextBox59.Text = reader2["RegNomSTSI"].ToString();//Рег№ СТК комплекса
                        alphaBlendTextBox62.Text = reader2["NomSPSI"].ToString();//№ свид.о поверке комплекса
                        alphaBlendTextBox61.Text = reader2["DateVidSPSI"].ToString();//Дата выд СПК № комплекса
                        alphaBlendTextBox64.Text = reader2["SrokSPSI"].ToString();//Срок СПК комплекса
                        alphaBlendTextBox29.Text = reader2["namead"].ToString();//№ и назван дороги
                        alphaBlendTextBox32.Text = reader2["ad_znachen"].ToString();//значение дороги
                        alphaBlendTextBox103.Text = reader2["CheckPointCode"].ToString();//уникальный код комплекса
                        alphaBlendTextBox104.Text = reader2["KodNapr"].ToString();//код направления
                        alphaBlendTextBox105.Text = reader2["shir"].ToString();//код направления
                        alphaBlendTextBox106.Text = reader2["dolg"].ToString();//код направления
                        alphaBlendTextBox35.Text = reader2["dislocationapvk"].ToString();//Дислокация дороги
                        alphaBlendTextBox31.Text = "D: " + reader2["dolg"].ToString() + " ; Sh: " + reader2["shir"].ToString();//Географ координаты дороги
                        alphaBlendTextBox65.Text = reader2["partad"].ToString();//Контролируемый участок дороги
                        alphaBlendTextBox30.Text = reader2["namenapr"].ToString();//Направление дороги
                        alphaBlendTextBox34.Text = reader2["npolos"].ToString();//№ полосы дороги
                        alphaBlendTextBox66.Text = reader2["maxosnagr"].ToString();//Макс ос. нагр. дороги
                        alphaBlendTextBox67.Text = reader2["NormPravAktAD"].ToString();//Нормативн акт дороги
                        alphaBlendTextBox68.Text = reader2["ogranich"].ToString();//особ. условия. дороги
                        alphaBlendTextBox80.Text = "" + reader2["Speed"].ToString() + " км/ч";// reader2["velocity"].ToString();//скорость
                        alphaBlendTextBox68.Text = reader2["ogranich"].ToString();//особ. условия. дороги
                        //alphaBlendTextBox69.Text = "Отсутствует";// reader2["PriznNal"].ToString();//Признак наличия СР
                        //alphaBlendTextBox70.Text = reader2["KemVid"].ToString();//Кем выдано СР
                        //alphaBlendTextBox71.Text = reader2["VidPerevoz"].ToString();//Вид перевозки в СР
                        //alphaBlendTextBox72.Text = reader2["GRZSR"].ToString();//ГРЗ в СР
                        //alphaBlendTextBox74.Text = reader2["NomSR"].ToString();//№ СР
                        //alphaBlendTextBox73.Text = reader2["DateVidSR"].ToString();//Дата выдачи СР
                        //alphaBlendTextBox75.Text = reader2["SrokDeistvSR"].ToString();//Срок действия СР
                        //alphaBlendTextBox76.Text = reader2["RazrMarshr"].ToString();//Разрешенный маршрут в СР
                        //alphaBlendTextBox77.Text = reader2["OsjbUslDvSR"].ToString();//Особые условия движения СР
                        //alphaBlendTextBox78.Text = reader2["KolRazrPr"].ToString();//Разрешено поездок СР
                        //alphaBlendTextBox79.Text = reader2["IspolzPR"].ToString();//выполнено поездок СР

                        label19.Visible = true; label20.Visible = true;
                        label21.Visible = true; label22.Visible = true; label23.Visible = true; label24.Visible = true; label25.Visible = true;
                        label26.Visible = true; label27.Visible = true; label28.Visible = true; label29.Visible = true;
                    }
                    else
                    {
                        //// скрываем правую вкладку конкретного проезда
                        comboBox4.Focus();
                        tabControl3.TabPages.Insert(1, tabPage10);
                        this.tabPage10.Show();

                        this.tabPage14.Hide();
                        tabControl3.TabPages.Remove(tabPage14);
                        label15.Visible = true;
                        dateTimePicker1.Visible = true;
                        label16.Visible = true;
                        dateTimePicker2.Visible = true;
                        label14.Visible = true;
                        comboBox4.Visible = true;
                        button3.Visible = true;
                        comboBox5.Visible = true;
                        textBox6.Visible = true;
                        label121.Visible = true;
                        label120.Visible = true;
                        this.tabPage2.Hide();
                        tabControl1.TabPages.Remove(tabPage2);
                        this.tabPage3.Hide();
                        tabControl1.TabPages.Remove(tabPage3);
                        groupBox5.Text = "           Выборка для связывания";
                        //////////////////////////////////////////////////////////////////
                        IDSV = 0;
                        KnPriv = 0;
                        label17.Text = "Cвязать :";
                        button11.BackgroundImage = AVGK.Properties.Resources.link;
                        label19.Visible = false;
                        label20.Visible = false;
                        label21.Visible = false; label22.Visible = false; label23.Visible = false; label24.Visible = false; label25.Visible = false;
                        label26.Visible = false; label27.Visible = false; label28.Visible = false; label29.Visible = false;
                        //di = reader2["detection_id"].ToString();
                        //dii = reader2["detection_image_id"].ToString();
                        //odi = reader2["OldIdIm"].ToString();
                        //odii = reader2["OldIdImDet"].ToString();
                    }
                    label73.Text = reader2["dislocationapvk"].ToString();
                    ADNagr = Convert.ToDouble(reader2["maxosnagr"].ToString());
                    Cl = Convert.ToInt32(reader2["Class"].ToString());
                }
                reader2.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: \r\n{0}", ex.ToString());
            }
            finally
            {
                command2.Connection.Close();
            }
            #endregion ///////////////////////////////////////
            #region //////////////////////////////////////////////////////////////// заполняем ПДК по осям и превышения (левая)    ////////////////////////////////
            ZOsPDK();
            //dataGridView1.RowCount = Convert.ToInt32(alphaBlendTextBox13.Text);
            for (ic = 0; ic < (KolOs); ic++) //Convert.ToInt32(alphaBlendTextBox13.Text)); ic++)
            {

                if (ic < 8)
                {
                    if (PDKO[ic + 1] != 0)
                    {
                        dataGridView1[9, ic].Value = PDKO[ic + 1];
                        dataGridView1[10, ic].Value = names3[ic].massSR;
                        //XDate[25] = reader["IsOverweightPartial"].ToString();
                        if (Math.Round(Convert.ToDouble(dataGridView1[8, ic].Value) / (PDKO[ic + 1] / 100) - 100, 2) > 0)
                        {
                            dataGridView1[11, ic].Value = Math.Floor(Math.Round(Convert.ToDouble(dataGridView1[8, ic].Value) / (PDKO[ic + 1] / 100) - 100, 2));
                            dataGridView1[12, ic].Value = Math.Round(Convert.ToDouble(dataGridView1[8, ic].Value) - PDKO[ic + 1], 2);
                            if (Math.Floor(Math.Round(Convert.ToDouble(dataGridView1[8, ic].Value) / (PDKO[ic + 1] / 100) - 100, 2)) >= 3)
                            {
                                XDate[31] = "True";
                                PrevNar[ic] = Convert.ToDouble(dataGridView1[11, ic].Value);
                                PrevNar[37] = 1;
                            }
                            else { XDate[31] = "False"; }
                            dataGridView1.Rows[ic].DefaultCellStyle.BackColor = Color.Red;
                        }
                        else
                        {
                            dataGridView1[11, ic].Value = "-";
                            //dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                            dataGridView1[12, ic].Value = "-";
                        }
                    }
                    else
                    {
                        dataGridView1[9, ic].Value = PDKTel[ic + 1] / Convert.ToInt32(TypO[ic + 1]);
                        dataGridView1[10, ic].Value = names3[ic].massSR;
                        if (Math.Round(Convert.ToDouble(dataGridView1[8, ic].Value) / (Convert.ToDouble(dataGridView1[9, ic].Value) / 100) - 100, 2) > 0)
                        {
                            dataGridView1[11, ic].Value = Math.Floor(Math.Round(Convert.ToDouble(dataGridView1[8, ic].Value) / (Convert.ToDouble(dataGridView1[9, ic].Value) / 100) - 100, 2));
                            dataGridView1[12, ic].Value = Math.Round(Convert.ToDouble(dataGridView1[8, ic].Value) - Convert.ToDouble(dataGridView1[9, ic].Value), 2);
                            if (Math.Floor(Math.Round(Convert.ToDouble(dataGridView1[8, ic].Value) / (PDKO[ic + 1] / 100) - 100, 2)) >= 3)
                            {
                                XDate[31] = "True";
                                PrevNar[ic] = Convert.ToDouble(dataGridView1[11, ic].Value);
                                PrevNar[37] = 1;
                            }
                            else { XDate[31] = "False"; }
                            dataGridView1.Rows[ic].DefaultCellStyle.BackColor = Color.Red;
                        }
                        else
                        {
                            dataGridView1[11, ic].Value = "-";
                            dataGridView1[12, ic].Value = "-";

                        }
                    }
                }
                names3[ic].massPrev = Convert.ToString(Math.Round(Convert.ToDouble(dataGridView1[8, ic].Value) - Convert.ToDouble(dataGridView1[9, ic].Value), 2));
                names3[ic].PDKmass = Convert.ToString(dataGridView1[9, ic].Value);
                if (Convert.ToDouble(names3[ic].massPrev) > 3) {
                    names3[ic].massSign = "true";
                    PrevNar[ic] = Convert.ToDouble(dataGridView1[11, ic].Value);
                    PrevNar[37] = 1;
                }
                else { names3[ic].massSign = "false";
                    names3[ic].massPrev = "0";
                }

            }
            #endregion //////////////////////////
            #region //////////////////////////////////////////////////////////////// заполняем ПДК по тележкам и превышения (левая)    ////////////////////////////////
            //for (ic = 0; ic < GrO; ic++)
            //{

            KNR[1, 0] = Convert.ToInt32(TypO[1]);
            KNR[0, 0] = 1;
            ///////////////////////////////////////////       Заполняем первую строку ///////////////////////////////////////////////////
            if (KNR[1, 0] == 1)
            {
                dataGridView2[9, 0].Value = PDKO[1];// / Convert.ToInt32(TypO[ic + 1]);
                if (Math.Round(Convert.ToDouble(dataGridView2[8, 0].Value) / (Convert.ToDouble(dataGridView2[9, 0].Value) / 100) - 100, 2) > 0)
                {
                    dataGridView2[11, 0].Value = Math.Floor(Math.Round(Convert.ToDouble(dataGridView2[8, 0].Value) / (Convert.ToDouble(dataGridView2[9, 0].Value) / 100) - 100, 2));
                    dataGridView2[12, 0].Value = Math.Round(Convert.ToDouble(dataGridView2[8, 0].Value) - Convert.ToDouble(dataGridView2[9, 0].Value), 2);
                    if (Math.Floor(Math.Round(Convert.ToDouble(dataGridView2[8, 0].Value) / (Convert.ToDouble(dataGridView2[9, 0].Value) / 100) - 100, 2)) >= 3)
                    {
                        XDate[31] = "True";
                        PrevNar[10] = Convert.ToDouble(dataGridView2[11, 0].Value);
                        PrevNar[37] = 1;
                    }
                    else { XDate[31] = "False"; }

                    dataGridView2.Rows[0].DefaultCellStyle.BackColor = Color.Red;
                }
                else
                {
                    dataGridView2[11, 0].Value = "-";
                    dataGridView2[12, 0].Value = "-";
                }
            }
            else if (KNR[1, 0] > 1)
            {
                D1_2 = 0;

                for (icC = 1; icC <= TypO[1]; icC++)
                {
                    D1_2 = D1_2 + PDKTel[icC];
                }
                dataGridView2[9, 0].Value = D1_2 / TypO[1];//icC;// / Convert.ToInt32(TypO[ic + 1]);
                if (Math.Round(Convert.ToDouble(dataGridView2[8, 0].Value) / (Convert.ToDouble(dataGridView2[9, 0].Value) / 100) - 100, 2) > 0)
                {
                    dataGridView2[11, 0].Value = Math.Floor(Math.Round(Convert.ToDouble(dataGridView2[8, 0].Value) / (Convert.ToDouble(dataGridView2[9, 0].Value) / 100) - 100, 2));
                    dataGridView2[12, 0].Value = Math.Round(Convert.ToDouble(dataGridView2[8, 0].Value) - Convert.ToDouble(dataGridView2[9, 0].Value), 2);
                    if (Math.Floor(Math.Round(Convert.ToDouble(dataGridView2[8, 0].Value) / (Convert.ToDouble(dataGridView2[9, 0].Value) / 100) - 100, 2)) >= 3)
                    {
                        XDate[31] = "True";
                        PrevNar[10] = Convert.ToDouble(dataGridView2[11, 0].Value);
                        PrevNar[37] = 1;
                    }
                    else { XDate[31] = "False"; }
                    dataGridView2.Rows[0].DefaultCellStyle.BackColor = Color.Red;
                }
                else
                {
                    dataGridView2[11, 0].Value = "-";
                    dataGridView2[12, 0].Value = "-";
                }
            }
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ////////////////////// Заполняем строки таблицы больше чем первая 

            for (ic = 1; ic < GrO; ic++)
            {
                Sk = "";
                for (j = 0; j <= ic; j++)
                {
                    Sk = Sk + Convert.ToString(KNR[1, j]);
                }
                Sk = Sk + "1";
                Fx = 0;
                for (j = 0; j < Sk.Length; j++)
                {
                    Fx = Fx + int.Parse(Convert.ToString(Sk[j]));
                }
                KNR[1, ic] = Convert.ToInt32(TypO[Fx]);//Количество
                KNR[0, ic] = Fx; //Позиция
            }
            ////////////////////////////////////////////////////////////////////
            for (ic = 1; ic < GrO; ic++)
            {
                if (KNR[1, ic] == 1)
                {
                    dataGridView2[9, ic].Value = PDKO[KNR[0, ic]];// / Convert.ToInt32(TypO[ic + 1]);
                    dataGridView2[10, ic].Value = names3[ic].massSR;
                    if (Math.Round(Convert.ToDouble(dataGridView2[8, ic].Value) / (Convert.ToDouble(dataGridView2[9, ic].Value) / 100) - 100, 2) > 0)
                    {
                        dataGridView2[11, ic].Value = Math.Floor(Math.Round(Convert.ToDouble(dataGridView2[8, ic].Value) / (Convert.ToDouble(dataGridView2[9, ic].Value) / 100) - 100, 2));
                        dataGridView2[12, ic].Value = Math.Round(Convert.ToDouble(dataGridView2[8, ic].Value) - Convert.ToDouble(dataGridView2[9, ic].Value), 2);
                        if (Math.Floor(Math.Round(Convert.ToDouble(dataGridView2[8, ic].Value) / (Convert.ToDouble(dataGridView2[9, ic].Value) / 100) - 100, 2)) >= 3)
                        {
                            XDate[31] = "True";
                            PrevNar[ic + 10] = Convert.ToDouble(dataGridView2[11, ic].Value);
                            PrevNar[37] = 1;
                        }
                        else { XDate[31] = "False"; }
                        dataGridView2.Rows[ic].DefaultCellStyle.BackColor = Color.Red;
                    }
                    else
                    {
                        dataGridView2[11, ic].Value = "-";
                        dataGridView2[12, ic].Value = "-";
                    }
                }
                else if (KNR[1, ic] > 1)
                {
                    D1_2 = 0;

                    for (icC = KNR[0, ic]; icC < (KNR[0, ic] - 1 + KNR[1, ic]); icC++)
                    {
                        if (icC < 8)
                        {
                            D1_2 = PDKTel[icC + 1];

                        }
                    }

                    dataGridView2[9, ic].Value = D1_2;// / Convert.ToInt32(TypO[ic + 1]);
                    dataGridView2[10, 0].Value = Convert.ToString(Convert.ToDouble(names3[0].massSR));
                    dataGridView2[10, ic].Value = Convert.ToString(Convert.ToDouble(names3[ic].massSR) * KNR[1, ic]);
                    if (Math.Round(Convert.ToDouble(dataGridView2[8, ic].Value) / (Convert.ToDouble(dataGridView2[9, ic].Value) / 100) - 100, 2) > 0)
                    {
                        dataGridView2[11, ic].Value = Math.Floor(Math.Round(Convert.ToDouble(dataGridView2[8, ic].Value) / (Convert.ToDouble(dataGridView2[9, ic].Value) / 100) - 100, 2));
                        dataGridView2[12, ic].Value = Math.Round(Convert.ToDouble(dataGridView2[8, ic].Value) - Convert.ToDouble(dataGridView2[9, ic].Value), 2);
                        if (Math.Floor(Math.Round(Convert.ToDouble(dataGridView2[8, ic].Value) / (Convert.ToDouble(dataGridView2[9, ic].Value) / 100) - 100, 2)) >= 3)
                        {
                            XDate[31] = "True";
                            PrevNar[ic + 10] = Convert.ToDouble(dataGridView2[11, ic].Value);
                            PrevNar[37] = 1;
                        }
                        else { XDate[31] = "False"; }
                        dataGridView2.Rows[ic].DefaultCellStyle.BackColor = Color.Red;
                    }
                    else
                    {
                        dataGridView2[11, ic].Value = "-";
                        dataGridView2[12, ic].Value = "-";
                        //}
                    }
                }
                ////////////////////////////////////////////////////////////////////////
            }
            ///////////////////////////////////////////////////// ТИП НАРУШЕНИЯ
            PPRNAR = PrevNar[0];
            iNar = 0;
            for (int PrNar = 1; PrNar <= 25; PrNar++)
            {
                if (PrevNar[PrNar] > PPRNAR)
                {
                    PPRNAR = PrevNar[PrNar];
                    iNar = PrNar;
                }
            }
            if (iNar >= 0 && iNar < 10)
            {
                PrevNar[31] = iNar;
                TypNar = 1;
                TypNarTXT = "Превышение нагрузки на ось";
                MAXPREV = Convert.ToDouble(dataGridView1[12, iNar].Value); ;
                MAXPREVPROTC = Convert.ToDouble(dataGridView1[11, iNar].Value);
                PrevNar[30] = 1;
                if (PrevNar[29] == 1)
                { PrevNar[32] = 1;
                    if (MAXPREVPROTC >= 2 && MAXPREVPROTC <= 10)
                    { PrevNar[34] = 1; PrevNar[33] = MAXPREVPROTC; }
                    else if (MAXPREVPROTC >= 11 && MAXPREVPROTC <= 20)
                    { PrevNar[34] = 2; PrevNar[33] = MAXPREVPROTC; }
                    else if (MAXPREVPROTC >= 21 && MAXPREVPROTC <= 50)
                    { PrevNar[34] = 3; PrevNar[33] = MAXPREVPROTC; }
                    else if (MAXPREVPROTC >= 51)
                    { PrevNar[34] = 6; PrevNar[33] = MAXPREVPROTC; }
                }
                else if (PrevNar[29] == 2)
                { PrevNar[32] = 2;
                    if (MAXPREVPROTC >= 11 && MAXPREVPROTC <= 20)
                    { PrevNar[34] = 4; PrevNar[33] = MAXPREVPROTC; }
                    else if (MAXPREVPROTC >= 21 && MAXPREVPROTC <= 50)
                    { PrevNar[34] = 5; PrevNar[33] = MAXPREVPROTC; }
                    else if (MAXPREVPROTC >= 51)
                    { PrevNar[34] = 6; PrevNar[33] = MAXPREVPROTC; }
                }


            }
            else if (iNar >= 10 && iNar < 17)
            {
                PrevNar[31] = iNar-9;
                TypNar = 2;
                TypNarTXT = "Превышение нагрузки на группу осей";
                MAXPREV = Convert.ToDouble(dataGridView2[12, iNar - 10].Value); ;
                MAXPREVPROTC = Convert.ToDouble(dataGridView2[11, iNar - 10].Value);
                PrevNar[30] = 2;
                if (PrevNar[29] == 1)
                { PrevNar[32] = 1;
                    if (MAXPREVPROTC >= 2 && MAXPREVPROTC <= 10)
                    { PrevNar[34] = 1; PrevNar[33] = MAXPREVPROTC; }
                    else if (MAXPREVPROTC >= 11 && MAXPREVPROTC <= 20)
                    { PrevNar[34] = 2; PrevNar[33] = MAXPREVPROTC; }
                    else if (MAXPREVPROTC >= 21 && MAXPREVPROTC <= 50)
                    { PrevNar[34] = 3; PrevNar[33] = MAXPREVPROTC; }
                    else if (MAXPREVPROTC >= 51)
                    { PrevNar[34] = 6; PrevNar[33] = MAXPREVPROTC; }
                }
                else if (PrevNar[29] == 2)
                { PrevNar[32] = 2;
                    if (MAXPREVPROTC >= 11 && MAXPREVPROTC <= 20)
                    { PrevNar[34] = 4; PrevNar[33] = MAXPREVPROTC; }
                    else if (MAXPREVPROTC >= 21 && MAXPREVPROTC <= 50)
                    { PrevNar[34] = 5; PrevNar[33] = MAXPREVPROTC; }
                    else if (MAXPREVPROTC >= 51)
                    { PrevNar[34] = 6; PrevNar[33] = MAXPREVPROTC; }
                }

            }
            else if (iNar == 17)
            {
                PrevNar[31] = 00;
                TypNar = 3;
                TypNarTXT = "Превышение общей массы АТС";
                MAXPREV = Convert.ToDouble(alphaBlendTextBox27.Text.ToString());
                MAXPREVPROTC = Convert.ToDouble(alphaBlendTextBox24.Text.ToString());
                PrevNar[30] = 3;
                if (PrevNar[29] == 1)
                { PrevNar[32] = 1;
                    if (MAXPREVPROTC >= 2 && MAXPREVPROTC <= 10)
                    { PrevNar[34] = 1; PrevNar[33] = MAXPREVPROTC; }
                    else if (MAXPREVPROTC >= 11 && MAXPREVPROTC <= 20)
                    { PrevNar[34] = 2; PrevNar[33] = MAXPREVPROTC; }
                    else if (MAXPREVPROTC >= 21 && MAXPREVPROTC <= 50)
                    { PrevNar[34] = 3; PrevNar[33] = MAXPREVPROTC; }
                    else if (MAXPREVPROTC >= 51)
                    { PrevNar[34] = 6; PrevNar[33] = MAXPREVPROTC; }
                }
                else if (PrevNar[29] == 2)
                { PrevNar[32] = 2;
                    if (MAXPREVPROTC >= 11 && MAXPREVPROTC <= 20)
                    { PrevNar[34] = 4; PrevNar[33] = MAXPREVPROTC; }
                    else if (MAXPREVPROTC >= 21 && MAXPREVPROTC <= 50)
                    { PrevNar[34] = 5; PrevNar[33] = MAXPREVPROTC; }
                    else if (MAXPREVPROTC >= 51)
                    { PrevNar[34] = 6; PrevNar[33] = MAXPREVPROTC; }
                }
            }
            else if (iNar >= 18 && iNar < 21)
            {
                TypNar = 4;
                TypNarTXT = "Превышение габаритов АТС";

                //MAXPREV;
                //MAXPREVPROTC;
                PrevNar[30] = 4;
                if (PrevNar[29] == 1)
                { PrevNar[32] = 1;
                    if (PrevDlPr >= 1 && PrevDlPr <= 10)
                    { PrevNar[34] = 1; PrevNar[33] = PrevDlPr; }
                    else if (PrevDlPr >= 11 && PrevDlPr <= 20)
                    { PrevNar[34] = 2; PrevNar[33] = PrevDlPr; }
                    else if (PrevDlPr >= 21 && PrevDlPr <= 50)
                    { PrevNar[34] = 3; PrevNar[33] = PrevDlPr; }
                    else if (PrevDlPr >= 51)
                    { PrevNar[34] = 6; PrevNar[33] = PrevDlPr; }
                }
                else if (PrevNar[29] == 2)
                { PrevNar[32] = 2;
                    if (PrevDlPr >= 11 && PrevDlPr <= 20)
                    { PrevNar[34] = 4; PrevNar[33] = PrevDlPr; }
                    else if (PrevDlPr >= 21 && PrevDlPr <= 50)
                    { PrevNar[34] = 5; PrevNar[33] = PrevDlPr; }
                    else if (PrevDlPr >= 51)
                    { PrevNar[34] = 6; PrevNar[33] = PrevDlPr; }
                }
            }
            else if (iNar > 20 && iNar < 25)
            {
                TypNar = 5;
                TypNarTXT = "Превышение скорости движения АТС";
            }
            if (PrevNar[37] == 1 && PrevNar[38] == 0)
            { PrevNar[28] = 1; }
            else if (PrevNar[37] == 0 && PrevNar[38] == 1)
            { PrevNar[28] = 2; }
            else if (PrevNar[37] == 1 && PrevNar[38] == 1)
            { PrevNar[28] = 3; }

            if (KolOs < 10)
            {
                if (PrevNar[34] < 10) { CodNar = PrevNar[25].ToString() + "0" + PrevNar[26].ToString() + PrevNar[27].ToString() + PrevNar[28].ToString() + PrevNar[29].ToString() + PrevNar[30].ToString() + "0" + PrevNar[31].ToString() + PrevNar[32].ToString() + PrevNar[33].ToString() + "0" + PrevNar[34].ToString() + "00"; }

                else { CodNar = PrevNar[25].ToString() + "0" + PrevNar[26].ToString() + PrevNar[27].ToString() + PrevNar[28].ToString() + PrevNar[29].ToString() + PrevNar[30].ToString() + "0" + PrevNar[31].ToString() + PrevNar[32].ToString() + PrevNar[33].ToString() + PrevNar[34].ToString() + "00"; }
            }
            else
            {
                if (PrevNar[34] < 10) { CodNar = PrevNar[25].ToString() + PrevNar[26].ToString() + PrevNar[27].ToString() + PrevNar[28].ToString() + PrevNar[29].ToString() + PrevNar[30].ToString() + PrevNar[31].ToString() + PrevNar[32].ToString() + PrevNar[33].ToString() + "0" + PrevNar[34].ToString() + "00"; }

                else { CodNar = PrevNar[25].ToString() + PrevNar[26].ToString() + PrevNar[27].ToString() + PrevNar[28].ToString() + PrevNar[29].ToString() + PrevNar[30].ToString() + PrevNar[31].ToString() + PrevNar[32].ToString() + PrevNar[33].ToString() + PrevNar[34].ToString() + "00"; }
            }
                CodNar = CodNar;
            //    }
            //}
            //  ZKL();
            ////////////////ZPHOTOLEFT();            
            ////////////////if (IDSV > 0)
            ////////////////{ ZIzmR(IDSV); }
            ////////////////else { ZIzmR(Convert.ToInt32(alphaBlendTextBox10.Text));}
        }
        #endregion ///////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////
        
        public void ZIzmR(int IDTS)////////////////////////////  Запрос Связанного проезда (если таковой есть)
        {
            if (KnPriv != 1)
            {
                ConnectStr conStrR = new ConnectStr();
                Zapros zapros1 = new Zapros();
                COs = KolOs;//Convert.ToInt32(alphaBlendTextBox13.Text);
                D1 = dateTimePicker1.Value.ToString("yyyy.MM.dd HH:mm:ss");
                D2 = dateTimePicker2.Value.ToString("yyyy.MM.dd HH:mm:ss");
                //Cl = Convert.ToInt32(alphaBlendTextBox11.Text);
                WM = label18.Text;
                conStrR.ConStr(1);
                zapros1.ZaprPrCamTabLoc(COs, D1, D2, Cl, WM);
                cstr = conStrR.StP;
                z = zapros1.commandStringTest;
                //MessageBox.Show(cstr);
                connection1 = new MySqlConnection(cstr);

                //if (this.OpenConnection() == true)
                //{
                mySqlDataAdapter = new MySqlDataAdapter(z, connection1);
                //mySqlDataAdapter = new MySqlDataAdapter("SELECT * from `raptnapr`", connection);
                //DataSet DS = new DataSet();
                mySqlDataAdapter.Fill(DSPR);
                dataGridView11.DataSource = DSPR.Tables[0];
                //dataGridView11.DataSource = DS.Tables[0];
                dataGridView11.Columns[1].Visible = false;
                dataGridView11.Columns[4].Visible = false;
                dataGridView11.Columns[6].Visible = false;
                int ss = 0;
                for (ss = 7; ss < 10; ss++)
                { dataGridView11.Columns[ss].Visible = false; }
                dataGridView11.Columns[11].Visible = false;
                dataGridView11.Columns[14].Visible = false;
                for (ss = 16; ss < 70; ss++)
                { dataGridView11.Columns[ss].Visible = false; }
                dataGridView11.Refresh();
                alphaBlendTextBox10.Text = dataGridView11[0, 0].Value.ToString(); //dataGridView11[0, 0].Value.ToString();
                alphaBlendTextBox6.Text = dataGridView11[3, 0].Value.ToString();
                alphaBlendTextBox9.Text = dataGridView11[4, 0].Value.ToString().Substring(0, 10);
                ZagrdataGridView11(Convert.ToInt32(dataGridView11[0, 0].Value.ToString()));

                connection1.Close();
                //this.CloseConnection();
                //}
                //////////////////////////////////////
            }
            else
            {
                MySqlCommand command2 = new MySqlCommand();
                ConnectStr conStr2 = new ConnectStr();
                conStr2.ConStr(1);
                Zapros zapros2 = new Zapros();
                string connectionString2;//, commandString;
                connectionString2 = conStr2.StP;//"Data source=localhost;UserId=root;Password=1q2w3e$R;database=camloc;";
                MySqlConnection connection2 = new MySqlConnection(connectionString2);
                zapros2.ZaprAllCamNaprL(IDTS, "0" , "0",0);

                string z2 = zapros2.commandStringTest;


                command2.CommandText = z2;// commandString;
                command2.Connection = connection2;
                MySqlDataReader reader2;
                try
                {
                    command2.Connection.Open();
                    reader2 = command2.ExecuteReader();
                    while (reader2.Read())
                    {
                        //alphaBlendTextBox10.Text = IDTS.ToString();
                        //alphaBlendTextBox9.Text = reader2["datepr"].ToString().Substring(0, 10);
                        //alphaBlendTextBox6.Text = reader2["timepr"].ToString();
                        //alphaBlendTextBox8.Text = reader2["namead"].ToString();
                        //alphaBlendTextBox7.Text = reader2["namenapr"].ToString();
                        //alphaBlendTextBox2.Text = reader2["npolos"].ToString();
                        ////alphaBlendTextBox4.Text = reader2["vehicle_class"].ToString();
                        //alphaBlendTextBox3.Text = reader2["nameapvk"].ToString();
                        //alphaBlendTextBox16.Text = reader2["lp"].ToString();
                        ////alphaBlendTextBox5.Text = "Автопоезд";//reader2["timepr"].ToString();
                        //alphaBlendTextBox21.Text = reader2["vehicle_class"].ToString();
                        //alphaBlendTextBox15.Text = reader2["velocity"].ToString();
                        //alphaBlendTextBox14.Text = reader2["axles_count"].ToString();
                        //alphaBlendTextBox20.Text = Convert.ToString(Convert.ToInt32(reader2["total_weight"].ToString()) / 100);
                        //alphaBlendTextBox18.Text = Convert.ToString(Convert.ToDouble(reader2["length"].ToString())*10);
                        //alphaBlendTextBox17.Text = reader2["s_width"].ToString();
                        //alphaBlendTextBox19.Text = reader2["s_height"].ToString();
                        //label124.Text = reader2["dislocationapvk"].ToString();
                        //alphaBlendTextBox92.Text = reader2["nameapvk"].ToString();//Наименование комплекса
                        //alphaBlendTextBox81.Text = reader2["Vladel"].ToString();//Владелец комплекса
                        //alphaBlendTextBox91.Text = reader2["TipSI"].ToString();//Тип СИ комплекса
                        //alphaBlendTextBox90.Text = reader2["Model"].ToString();//Марка и модель комплекса
                        //alphaBlendTextBox89.Text = reader2["sernum"].ToString();//Заводской № комплекса
                        //alphaBlendTextBox88.Text = reader2["kodapvk"].ToString();//Код комплекса
                        //alphaBlendTextBox87.Text = reader2["NomSvidTipaSI"].ToString();//№ свид.типа комплекса
                        //alphaBlendTextBox86.Text = reader2["DateVidSTSI"].ToString();//Дата выд СТК № комплекса
                        //alphaBlendTextBox85.Text = reader2["RegNomSTSI"].ToString();//Рег№ СТК комплекса
                        //alphaBlendTextBox84.Text = reader2["NomSPSI"].ToString();//№ свид.о поверке комплекса
                        //alphaBlendTextBox83.Text = reader2["DateVidSPSI"].ToString();//Дата выд СПК № комплекса
                        //alphaBlendTextBox82.Text = reader2["SrokSPSI"].ToString();//Срок СПК комплекса
                        //alphaBlendTextBox102.Text = reader2["namead"].ToString();//№ и назван дороги
                        //alphaBlendTextBox101.Text = reader2["ad_znachen"].ToString();//значение дороги
                        //alphaBlendTextBox99.Text = reader2["dislocationapvk"].ToString();//Дислокация дороги
                        //alphaBlendTextBox100.Text = "D: " + reader2["dolg"].ToString() + " ; Sh: " + reader2["shir"].ToString();//Географ координаты дороги
                        //alphaBlendTextBox96.Text = reader2["partad"].ToString();//Контролируемый участок дороги
                        //alphaBlendTextBox97.Text = reader2["namenapr"].ToString();//Направление дороги
                        //alphaBlendTextBox98.Text = reader2["npolos"].ToString();//№ полосы дороги
                        //alphaBlendTextBox94.Text = reader2["maxosnagr"].ToString();//Макс ос. нагр. дороги
                        //alphaBlendTextBox95.Text = reader2["NormPravAktAD"].ToString();//Нормативн акт дороги
                        //alphaBlendTextBox93.Text = reader2["ogranich"].ToString();//особ. условия. дороги
                        //alphaBlendTextBox80.Text = "" + reader2["Скорость"].ToString() + " км/ч";// reader2["velocity"].ToString();//скорость
                        //alphaBlendTextBox68.Text = reader2["ogranich"].ToString();//особ. условия. дороги
                        //alphaBlendTextBox69.Text = reader2["PriznNal"].ToString();//Признак наличия СР
                        //alphaBlendTextBox70.Text = reader2["KemVid"].ToString();//Кем выдано СР
                        //alphaBlendTextBox71.Text = reader2["VidPerevoz"].ToString();//Вид перевозки в СР
                        //alphaBlendTextBox72.Text = reader2["GRZSR"].ToString();//ГРЗ в СР
                        //alphaBlendTextBox74.Text = reader2["NomSR"].ToString();//№ СР
                        //alphaBlendTextBox73.Text = reader2["DateVidSR"].ToString();//Дата выдачи СР
                        //alphaBlendTextBox75.Text = reader2["SrokDeistvSR"].ToString();//Срок действия СР
                        //alphaBlendTextBox76.Text = reader2["RazrMarshr"].ToString();//Разрешенный маршрут в СР
                        //alphaBlendTextBox77.Text = reader2["OsjbUslDvSR"].ToString();//Особые условия движения СР
                        //alphaBlendTextBox78.Text = reader2["KolRazrPr"].ToString();//Разрешено поездок СР
                        //alphaBlendTextBox79.Text = reader2["IspolzPR"].ToString();//выполнено поездок СР

                        //if (reader2["Obz"] != System.DBNull.Value) { msdop = new MemoryStream((byte[])reader2["Obz"]); }
                        //if (reader2["lp_image"] != System.DBNull.Value) { nzdop = new MemoryStream((byte[])reader2["lp_image"]); }
                        //if (reader2["ObzLob"] != System.DBNull.Value) { onzdop = new MemoryStream((byte[])reader2["ObzLob"]); }
                        //pictureBox43.Image = Image.FromStream(msdop);

                        ///Пишем номер связанного пр.
                        string nom = "";
                        //label32.Text = "";
                        nom = reader2["lp"].ToString();
                        alphaBlendTextBox16.Text = reader2["lp"].ToString();
                        odi = reader2["detection_id"].ToString();
                        odii = reader2["detection_image_id"].ToString();
                        //di = reader2["OldIdIm"].ToString();
                        //dii = reader2["OldIdImDet"].ToString();
                        if (nom.Length > 3)
                        {
                            maskedTextBox2.Text= reader2["lp"].ToString();
                            //label224.Text = nom.Substring(0, 1);
                            //label223.Text = nom.Substring(1, 1);
                            //label222.Text = nom.Substring(2, 1);
                            //if (nom.Length >= 4)
                            //{ label221.Text = nom.Substring(3, 1); }
                            //else { label221.Text = "-"; }
                            //if (nom.Length >= 5)
                            //{ label219.Text = nom.Substring(4, 1); }
                            //else { label219.Text = "-"; }
                            //if (nom.Length >= 6)
                            //{ label218.Text = nom.Substring(5, 1); }
                            //else { label218.Text = "-"; }
                            //if (nom.Length >= 7)
                            //{ label216.Text = nom.Substring(6, 1); }
                            //else { label216.Text = "-"; }
                            //if (nom.Length >= 8)
                            //{ label220.Text = nom.Substring(7, 1); }
                            //else { label220.Text = "-"; }
                            //if (nom.Length == 9)
                            //{ label217.Text = nom.Substring(8, 1); }
                            //else { label217.Text = ""; }
                        }
                        else
                        {
                            //label13.Text = "-";
                            //label12.Text = "-";
                            //label11.Text = "-";
                        }

                    }
                    reader2.Close();
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Error: \r\n{0}", ex.ToString());
                }
                finally
                {
                    command2.Connection.Close();
                }
                //ZPHOTOPR();
           
            MySqlCommand command = new MySqlCommand();
            ConnectStr conStr = new ConnectStr();
            Zapros zapros = new Zapros();
            conStr.ConStr(1);
            zapros.ZaprPhotoDopLoc(Convert.ToInt32(alphaBlendTextBox10.Text));
            cstr = conStr.StP;
            //connectionString = "Data source=localhost;UserId=root;Password=1q2w3e$R;database=camloc;";
            MySqlConnection connection = new MySqlConnection(cstr);
            z = zapros.commandStringTest;
            command.CommandText = z;// commandString;
            command.Connection = connection;
            MySqlDataReader reader;
            try
            {
                command.Connection.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                        alphaBlendTextBox15.Text= "" + reader["Скорость"].ToString() + " км/ч";
                        alphaBlendTextBox20.Text = Math.Round(Convert.ToDouble(reader["total_weight"].ToString()) / 1000, 2).ToString();
                        alphaBlendTextBox14.Text = reader["axles_count"].ToString();
                        alphaBlendTextBox16.Text = reader["lp"].ToString();
                        alphaBlendTextBox18.Text = Math.Round(Convert.ToDouble(reader["Длина ТС"].ToString())/100,2).ToString();
                        alphaBlendTextBox19.Text = reader["s_height"].ToString(); //высота
                        alphaBlendTextBox17.Text = reader["s_width"].ToString();

                        di = reader["detection_id"].ToString();
                    dii = reader["detection_image_id"].ToString();
                    if (reader["Obz"] != System.DBNull.Value) { msdop = new MemoryStream((byte[])reader["Obz"]); }
                    if (reader["lp_image"] != System.DBNull.Value) { nzdop = new MemoryStream((byte[])reader["lp_image"]); }
                    if (reader["ObzLob"] != System.DBNull.Value) { onzdop = new MemoryStream((byte[])reader["ObzLob"]); }
                    pictureBox43.Image = Image.FromStream(msdop);

                    #region ///// Заполнение переменных о выбранном проезде для определения класса и расчета ПДК :)
                    KolOs = Convert.ToInt32(reader["axles_count"]);
                    for (ic = 1; ic < KolOs + 1; ic++)
                    {
                        if (Convert.ToDouble(reader["axles_" + (ic) + "_" + (ic + 1) + "_base"]) > 0)
                        {
                            D[ic] = (Convert.ToDouble(reader["axles_" + (ic) + "_" + (ic + 1) + "_base"]) + 3);
                        }
                        //DoubO[ic] = (Convert.ToInt32(reader["dbl" + (ic)]));
                        switch (ic)
                        {
                            case 1:
                                if (D[ic] >= 250)
                                { TypO[ic] = 1; }
                                else if (D[ic] > 0 && D[ic] < 250)
                                {
                                    TypO[ic] = 2;
                                }
                                break;
                            case 2:
                                if (D[ic] >= 250)
                                {
                                    if (D[ic - 1] >= 250)
                                    { TypO[ic] = 1; }
                                    else if (D[ic - 1] > 0 && D[ic - 1] < 250)
                                    {
                                        TypO[ic] = 2;
                                    }
                                }
                                else if (D[ic] > 0 && D[ic] < 250)
                                {
                                    if (D[ic - 1] >= 250)
                                    { TypO[ic] = 2; }
                                    else if (D[ic - 1] > 0 && D[ic - 1] < 250)
                                    {
                                        TypO[ic] = 3;
                                        TypO[ic - 1] = 3;
                                    }

                                }
                                break;
                            case 3:
                                if (D[ic] >= 250)
                                {
                                    if (D[ic - 1] >= 250)
                                    { TypO[ic] = 1; }
                                    else if (D[ic - 1] > 0 && D[ic - 1] < 250)
                                    {
                                        if (D[ic - 2] > 0 && D[ic - 2] < 250)
                                        {
                                            TypO[ic] = 3;
                                            TypO[ic - 1] = 3;
                                            TypO[ic - 2] = 3;
                                        }
                                        else { TypO[ic] = 2; TypO[ic - 1] = 2; }
                                    }
                                }
                                else if (D[ic] >= 0 && D[ic] < 250)
                                {
                                    if (D[ic - 1] >= 250)
                                    { TypO[ic] = 2; }
                                    else if (D[ic - 1] > 0 && D[ic - 1] < 250)
                                    {
                                        if (D[ic - 2] > 0 && D[ic - 2] < 250)
                                        {
                                            if (D[ic] == 0)
                                            { TypO[ic] = 3; TypO[ic - 1] = 3; TypO[ic - 2] = 3; break; }
                                            else { TypO[ic] = 4; TypO[ic - 1] = 4; TypO[ic - 2] = 4; }
                                        }
                                        else
                                        {
                                            if (D[ic] == 0)
                                            { TypO[ic] = 2; TypO[ic - 1] = 2; break; }
                                            else { TypO[ic] = 3; TypO[ic - 1] = 3; }
                                        }
                                    }
                                }
                                break;

                            default:
                                if (D[ic] >= 250)
                                {
                                    if (D[ic - 1] >= 250)
                                    { TypO[ic] = 1; }
                                    else if (D[ic - 1] > 0 && D[ic - 1] < 250)
                                    {
                                        if (D[ic - 2] > 0 && D[ic - 2] < 250)
                                        {
                                            if (D[ic - 3] > 0 && D[ic - 3] < 250)
                                            {
                                                TypO[ic] = 4; TypO[ic - 1] = 4; TypO[ic - 2] = 4; TypO[ic - 3] = 4;
                                            }
                                            else { TypO[ic] = 3; TypO[ic - 1] = 3; TypO[ic - 2] = 3; }
                                        }
                                        else { TypO[ic] = 2; TypO[ic - 1] = 2; }
                                    }
                                }
                                else if (D[ic] >= 0 && D[ic] < 250)
                                {
                                    if (D[ic - 1] >= 250)
                                    { TypO[ic] = 2; }
                                    else if (D[ic - 1] > 0 && D[ic - 1] < 250)
                                    {
                                        if (D[ic - 2] > 0 && D[ic - 2] < 250)
                                        {
                                            if (D[ic - 3] > 0 && D[ic - 3] < 250)
                                            {
                                                if (D[ic] == 0)
                                                { TypO[ic] = 4; TypO[ic - 1] = 4; TypO[ic - 2] = 4; TypO[ic - 3] = 4; break; }
                                                else { TypO[ic] = 5; TypO[ic - 1] = 5; TypO[ic - 2] = 5; TypO[ic - 3] = 5; }
                                            }
                                            else
                                            {
                                                if (D[ic] == 0)
                                                { TypO[ic] = 3; TypO[ic - 1] = 3; TypO[ic - 2] = 3; break; }
                                                else { TypO[ic] = 4; TypO[ic - 1] = 4; TypO[ic - 2] = 4; }
                                            }
                                        }
                                        else
                                        {
                                            if (D[ic] == 0)
                                            { TypO[ic] = 2; TypO[ic - 1] = 2; break; }
                                            else { TypO[ic] = 3; TypO[ic - 1] = 3; }
                                        }
                                    }
                                }
                                break;
                        }
                    }

                    ADNagr = 0;
                    RasstOs = 0;
                    //DO = 0;
                    TypeO = 0;

                    TTS = 0;
                    for (ic = KolOs + 1; ic < 9; ic++)
                    {
                        D[ic] = 0;
                        DoubO[ic] = 0;
                        TypO[ic] = 0;
                    }
                    Cl = Convert.ToInt32(reader["vehicle_class"].ToString());
                    ObshMass = Convert.ToDouble(reader["total_weight"].ToString());
                        for (int KO = 1; KO <= KolOs; KO++)
                        {
                            D111[KO] = Convert.ToDouble(reader["axles_" + KO + "_" + (KO + 1) + "_base"].ToString());
                        }

                        //D1_2 = Convert.ToDouble(reader["axles_1_2_base"].ToString());
                        //D2_3 = Convert.ToDouble(reader["axles_2_3_base"].ToString());
                        //D3_4 = Convert.ToDouble(reader["axles_3_4_base"].ToString());
                        //D4_5 = Convert.ToDouble(reader["axles_4_5_base"].ToString());
                        //D5_6 = Convert.ToDouble(reader["axles_5_6_base"].ToString());
                        //D6_7 = Convert.ToDouble(reader["axles_6_7_base"].ToString());
                        //D7_8 = Convert.ToDouble(reader["axles_7_8_base"].ToString());


                        #endregion ////////////////////////////////////////////////////////////////////////////////////////////////////
                        #region                   //////////////////////////      заполнение таблицы данными о ТС      ////////////////////////////
                        if (Convert.ToInt32(reader["axles_count"]) > 0)
                    {
                        GrO = 0;
                        dataGridView4.RowCount = Convert.ToInt32(reader["axles_count"]);
                        for (ic = 0; ic < (Convert.ToInt32(reader["axles_count"])); ic++)
                        {
                            dataGridView4[0, ic].Value = ic + 1;
                            string Sk = Convert.ToInt32(reader["dbl" + (ic + 1)]) + "/" + (Convert.ToInt32(reader["dbl" + (ic + 1)])) * 2;
                            dataGridView4[2, ic].Value = Sk;
                            if (ic > 0)
                            {
                                if (Convert.ToDouble(reader["base" + (ic) + "_" + (ic + 1)]) > 2.5)
                                {
                                    GrO = GrO + 1;
                                    dataGridView4[3, ic].Value = (Convert.ToDouble(reader["base" + (ic) + "_" + (ic + 1)]));
                                    dataGridView4[1, ic].Value = GrO;
                                    //dataGridView4[1, ic].Value = "";
                                    dataGridView4[4, ic].Value = (Convert.ToDouble(reader["base" + (ic) + "_" + (ic + 1)]) + 0.03);
                                    dataGridView4[5, ic].Value = (Math.Round(Convert.ToDouble(reader["axle_" + (ic + 1) + "_leftside_load"]) / 1000, 3));
                                    dataGridView4[6, ic].Value = (Math.Round(Convert.ToDouble(reader["axle_" + (ic + 1) + "_rightside_load"]) / 1000, 3));
                                    dataGridView4[7, ic].Value = (Math.Round(Convert.ToDouble(reader["o" + (ic + 1) + "m"]) / 1000, 3));
                                    dataGridView4[8, ic].Value = (Math.Round((Convert.ToDouble(reader["o" + (ic + 1) + "m"]) - (Convert.ToDouble(reader["o" + (ic + 1) + "m"]) / 100 * 10)) / 1000, 3));
                                    dataGridView4[9, ic].Value = (9);
                                    //dataGridView4[11, ic].Value = Math.Round(((Convert.ToDouble(reader["o" + (ic + 1) + "m"]) - (Convert.ToDouble(reader["o" + (ic + 1) + "m"]) / 100 * 5)) / (9000 / 100) - 100), 3);
                                    dataGridView4[11, ic].Value = Math.Round((Math.Round((Convert.ToDouble(reader["o" + (ic + 1) + "m"]) - (Convert.ToDouble(reader["o" + (ic + 1) + "m"]) / 100 * 10)) / 1000, 3)) / (9 / 100) - 100, 3);
                                    dataGridView4[12, ic].Value = Math.Round((((Convert.ToDouble(reader["o" + (ic + 1) + "m"]) - (Convert.ToDouble(reader["o" + (ic + 1) + "m"]) / 100 * 10)) - (9000)) / 1000), 3);
                                }
                                else if (Convert.ToDouble(reader["base" + (ic - 1) + "_" + (ic)]) > 2.5)
                                {
                                    KGr = KGr++;
                                    //GrO = GrO; ///+ 1;
                                    dataGridView4[3, ic].Value = (Convert.ToDouble(reader["base" + (ic) + "_" + (ic + 1)]));
                                    dataGridView4[1, ic - 1].Value = GrO;
                                    dataGridView4[1, ic].Value = GrO;
                                    dataGridView4[4, ic].Value = (Convert.ToDouble(reader["base" + (ic) + "_" + (ic + 1)]) + 0.03);
                                    dataGridView4[5, ic].Value = (Math.Round(Convert.ToDouble(reader["axle_" + (ic + 1) + "_leftside_load"]) / 1000, 3));
                                    dataGridView4[6, ic].Value = (Math.Round(Convert.ToDouble(reader["axle_" + (ic + 1) + "_rightside_load"]) / 1000, 3));
                                    dataGridView4[7, ic].Value = (Math.Round(Convert.ToDouble(reader["o" + (ic + 1) + "m"]) / 1000, 2));
                                    dataGridView4[8, ic].Value = (Math.Round((Convert.ToDouble(reader["o" + (ic + 1) + "m"]) - (Convert.ToDouble(reader["o" + (ic + 1) + "m"]) / 100 * 10)) / 1000, 3));
                                    dataGridView4[9, ic].Value = (9);
                                    //dataGridView4[11, ic].Value = Math.Round(((Convert.ToDouble(reader["o" + (ic + 1) + "m"]) - (Convert.ToDouble(reader["o" + (ic + 1) + "m"]) / 100 * 5)) / (9000 / 100) - 100), 3);
                                    dataGridView4[11, ic].Value = Math.Round((Math.Round((Convert.ToDouble(reader["o" + (ic + 1) + "m"]) - (Convert.ToDouble(reader["o" + (ic + 1) + "m"]) / 100 * 10)) / 1000, 3)) / (9 / 100) - 100, 3);
                                    dataGridView4[12, ic].Value = Math.Round((((Convert.ToDouble(reader["o" + (ic + 1) + "m"]) - (Convert.ToDouble(reader["o" + (ic + 1) + "m"]) / 100 * 10)) - (9000)) / 1000), 3);
                                }
                                else
                                {
                                    KGr = KGr++;
                                    dataGridView4[3, ic].Value = (Convert.ToDouble(reader["base" + (ic) + "_" + (ic + 1)]));
                                    dataGridView4[1, ic - 1].Value = GrO;
                                    dataGridView4[1, ic].Value = GrO;
                                    dataGridView4[4, ic].Value = (Convert.ToDouble(reader["base" + (ic) + "_" + (ic + 1)]) + 0.03);
                                    dataGridView4[5, ic].Value = (Math.Round(Convert.ToDouble(reader["axle_" + (ic + 1) + "_leftside_load"]) / 1000, 3));
                                    dataGridView4[6, ic].Value = (Math.Round(Convert.ToDouble(reader["axle_" + (ic + 1) + "_rightside_load"]) / 1000, 3));
                                    dataGridView4[7, ic].Value = (Math.Round(Convert.ToDouble(reader["o" + (ic + 1) + "m"]) / 1000, 3));
                                    dataGridView4[8, ic].Value = (Math.Round((Convert.ToDouble(reader["o" + (ic + 1) + "m"]) - (Convert.ToDouble(reader["o" + (ic + 1) + "m"]) / 100 * 10)) / 1000, 3));
                                    dataGridView4[9, ic].Value = (9);
                                    //dataGridView4[11, ic].Value = Math.Round(((Convert.ToDouble(reader["o" + (ic + 1) + "m"]) - (Convert.ToDouble(reader["o" + (ic + 1) + "m"]) / 100 * 5)) / (9000 / 100) - 100), 3);
                                    dataGridView4[11, ic].Value = Math.Round((Math.Round((Convert.ToDouble(reader["o" + (ic + 1) + "m"]) - (Convert.ToDouble(reader["o" + (ic + 1) + "m"]) / 100 * 10)) / 1000, 3)) / (9 / 100) - 100, 3);
                                    dataGridView4[12, ic].Value = Math.Round((((Convert.ToDouble(reader["o" + (ic + 1) + "m"]) - (Convert.ToDouble(reader["o" + (ic + 1) + "m"]) / 100 * 10)) - (9000)) / 1000), 3);
                                }
                            }
                            else
                            {
                                KGr = KGr++;
                                GrO = GrO + 1;
                                dataGridView4[1, ic].Value = GrO;
                                dataGridView4[3, ic].Value = "-";
                                dataGridView4[4, ic].Value = "-";
                                dataGridView4[5, ic].Value = (Math.Round(Convert.ToDouble(reader["axle_" + (ic + 1) + "_leftside_load"]) / 1000, 3));
                                dataGridView4[6, ic].Value = (Math.Round(Convert.ToDouble(reader["axle_" + (ic + 1) + "_rightside_load"]) / 1000, 3));
                                dataGridView4[7, ic].Value = (Math.Round(Convert.ToDouble(reader["o" + (ic + 1) + "m"]) / 1000, 3));
                                dataGridView4[8, ic].Value = (Math.Round((Convert.ToDouble(reader["o" + (ic + 1) + "m"]) - (Convert.ToDouble(reader["o" + (ic + 1) + "m"]) / 100 * 10)) / 1000, 3));
                                dataGridView4[9, ic].Value = (9);
                                //dataGridView4[11, ic].Value = Math.Round(((Convert.ToDouble(reader["o" + (ic + 1) + "m"]) - (Convert.ToDouble(reader["o" + (ic + 1) + "m"]) / 100 * 5)) / (9000 / 100) - 100), 3);
                                dataGridView4[11, ic].Value = Math.Round((Math.Round((Convert.ToDouble(reader["o" + (ic + 1) + "m"]) - (Convert.ToDouble(reader["o" + (ic + 1) + "m"]) / 100 * 10)) / 1000, 3)) / (9 / 100) - 100, 3);
                                dataGridView4[12, ic].Value = Math.Round((((Convert.ToDouble(reader["o" + (ic + 1) + "m"]) - (Convert.ToDouble(reader["o" + (ic + 1) + "m"]) / 100 * 10)) - (9000)) / 1000), 3);
                            }
                            if (Convert.ToDouble(dataGridView4[11, ic].Value) < 0)
                            { dataGridView4[11, ic].Value = 0; }
                        }
                    }
                    #endregion  ////////////////////////////////////////////////////////////////////////////////////

                    #region/////////////////////////////////////////            заполнение таблицы групп осей



                    if (GrO > 0)
                    {
                            for (i = 0; i < KolOs;i++)
                            {
                                KNR[1, i] = 0;
                                KNR[0, i] = 0;
                            }

                        //int NOs = 1;
                        //GrO = 0;
                        dataGridView3.RowCount = GrO;
                        KNR[1, 0] = Convert.ToInt32(TypO[1]);
                        KNR[0, 0] = 1;
                        ///////////////////////////////////////////       Заполняем первую строку ///////////////////////////////////////////////////
                        if (KNR[1, 0] == 1)
                        {
                            dataGridView3[0, 0].Value = 1;
                            dataGridView3[1, 0].Value = TypO[1];
                            Sk = Convert.ToInt32(reader["dbl1"]) + "/" + (Convert.ToInt32(reader["dbl1"])) * 2;
                            dataGridView3[2, 0].Value = Sk;

                            dataGridView3[3, 0].Value = Convert.ToDouble(reader["base" + (1) + "_" + (2)]);
                            dataGridView3[4, 0].Value = (Convert.ToDouble(reader["base" + (1) + "_" + (2)]) + 0.03); ;
                            dataGridView3[5, 0].Value = (Math.Round(Convert.ToDouble(reader["axle_" + (1) + "_leftside_load"]) / 1000, 3));
                            dataGridView3[6, 0].Value = (Math.Round(Convert.ToDouble(reader["axle_" + (1) + "_rightside_load"]) / 1000, 3));
                            dataGridView3[7, 0].Value = (Math.Round(Convert.ToDouble(reader["o" + (1) + "m"]) / 1000, 3));
                            dataGridView3[8, 0].Value = (Math.Round((Convert.ToDouble(reader["o" + (1) + "m"]) - (Convert.ToDouble(reader["o" + (1) + "m"]) / 100 * 10)) / 1000, 3));
                        }
                        else if (KNR[1, 0] > 1)
                        {
                                D1_2 = 0;
                                D2_3 = 0;
                                D3_4 = 0;
                                D4_5 = 0;
                                for (ic = 1; ic <= TypO[1]; ic++)
                            {
                                D1_2 = D1_2 + Convert.ToDouble(reader["dbl" + (ic)]);
                                D2_3 = D2_3 + (Math.Round(Convert.ToDouble(reader["axle_" + (ic) + "_leftside_load"]) / 1000, 3));
                                D3_4 = D3_4 + (Math.Round(Convert.ToDouble(reader["axle_" + (ic) + "_rightside_load"]) / 1000, 3));
                                D4_5 = D4_5 + (Math.Round(Convert.ToDouble(reader["o" + (ic) + "m"]) / 1000, 3));
                            }

                            dataGridView3[0, 0].Value = 1;
                            dataGridView3[1, 0].Value = TypO[1];
                            Sk = D1_2 + "/" + D1_2 * 2;
                            dataGridView3[2, 0].Value = Sk;

                            dataGridView3[3, 0].Value = Convert.ToDouble(reader["base" + (1) + "_" + (2)]);
                            dataGridView3[4, 0].Value = (Convert.ToDouble(reader["base" + (1) + "_" + (2)]) + 0.03); ;
                            dataGridView3[5, 0].Value = D2_3;
                            dataGridView3[6, 0].Value = D3_4;
                            dataGridView3[7, 0].Value = D4_5;
                            dataGridView3[8, 0].Value = (D4_5) - (D4_5 / 100 * 10);

                        }
                        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                        ////////////////////// Заполняем строки таблицы больше чем первая

                        for (ic = 1; ic < GrO; ic++)
                        {
                            Sk = "";
                            for (j = 0; j <= ic; j++)
                            {
                                Sk = Sk + Convert.ToString(KNR[1, j]);
                            }
                            Sk = Sk + "1";
                            Fx = 0;
                            for (j = 0; j < Sk.Length; j++)
                            {
                                Fx = Fx + int.Parse(Convert.ToString(Sk[j]));
                            }
                            KNR[1, ic] = Convert.ToInt32(TypO[Fx]);//Количество
                            KNR[0, ic] = Fx; //Позиция

                        }
                        ////////////////////////////////////////////////////////////////////

                        for (ic = 1; ic < GrO; ic++)
                        {
                            if (KNR[1, ic] == 1)
                            {
                                dataGridView3[0, ic].Value = ic + 1;
                                dataGridView3[1, ic].Value = TypO[ic + 1];
                                Sk = Convert.ToInt32(reader["dbl" + (ic + 1)]) + "/" + (Convert.ToInt32(reader["dbl" + (ic + 1)])) * 2;
                                dataGridView3[2, ic].Value = Sk;

                                dataGridView3[3, ic].Value = Convert.ToDouble(reader["base" + (ic + 1) + "_" + (ic + 2)]);
                                dataGridView3[4, ic].Value = (Convert.ToDouble(reader["base" + (ic + 1) + "_" + (ic + 2)]) + 0.03); ;
                                dataGridView3[5, ic].Value = (Math.Round(Convert.ToDouble(reader["axle_" + (ic + 1) + "_leftside_load"]) / 1000, 3));
                                dataGridView3[6, ic].Value = (Math.Round(Convert.ToDouble(reader["axle_" + (ic + 1) + "_rightside_load"]) / 1000, 3));
                                dataGridView3[7, ic].Value = (Math.Round(Convert.ToDouble(reader["o" + (ic + 1) + "m"]) / 1000, 3));
                                dataGridView3[8, ic].Value = (Math.Round((Convert.ToDouble(reader["o" + (ic + 1) + "m"]) - (Convert.ToDouble(reader["o" + (ic + 1) + "m"]) / 100 * 10)) / 1000, 3));
                            }
                            else if (KNR[1, ic] > 1)
                            {
                                D1_2 = 0;
                                D2_3 = 0;
                                D3_4 = 0;
                                D4_5 = 0;
                                for (icC = KNR[0, ic]; icC <= (KNR[0, ic] - 1 + KNR[1, ic]); icC++)
                                {
                                    D1_2 = D1_2 + Convert.ToDouble(reader["dbl" + (icC)]);
                                    D2_3 = D2_3 + (Math.Round(Convert.ToDouble(reader["axle_" + (icC) + "_leftside_load"]) / 1000, 3));
                                    D3_4 = D3_4 + (Math.Round(Convert.ToDouble(reader["axle_" + (icC) + "_rightside_load"]) / 1000, 3));
                                    D4_5 = D4_5 + (Math.Round(Convert.ToDouble(reader["o" + (icC) + "m"]) / 1000, 3));
                                }
                                dataGridView3[0, ic].Value = ic + 1;
                                dataGridView3[1, ic].Value = TypO[KNR[0, ic]];
                                Sk = Convert.ToInt32(D1_2) + "/" + (Convert.ToInt32(D1_2)) * 2;
                                dataGridView3[2, ic].Value = Sk;
                                    if (Convert.ToDouble(reader["base" + (ic + 1) + "_" + (ic + 2)])>= Convert.ToDouble(reader["base" + (ic + 2) + "_" + (ic + 3)]))
                                    {
                                dataGridView3[3, ic].Value = Convert.ToDouble(reader["base" + (ic + 2) + "_" + (ic + 3)]);
                                dataGridView3[4, ic].Value = (Convert.ToDouble(reader["base" + (ic + 2) + "_" + (ic + 3)]) + 0.03); 
                                    }
                                    else {
                                        dataGridView3[3, ic].Value = Convert.ToDouble(reader["base" + (ic + 1) + "_" + (ic + 2)]);
                                        dataGridView3[4, ic].Value = (Convert.ToDouble(reader["base" + (ic + 1) + "_" + (ic + 2)]) + 0.03);
                                    }
                                dataGridView3[5, ic].Value = D2_3;
                                dataGridView3[6, ic].Value = D3_4;
                                dataGridView3[7, ic].Value = D4_5;
                                dataGridView3[8, ic].Value = (Math.Round(D4_5 - (Convert.ToDouble(D4_5) / 100 * 10), 3));
                            }
                        }
                        ////////////////////////////////////////////////////////////////////////
                    }
                    #endregion                  ////////////////////////////////////////////////////////////////////////////////////////////////////



                }

                reader.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: \r\n{0}", ex.ToString());
            }
            finally
            {
                command.Connection.Close();
            }
                ////////////////////////////////////////   Нужно запросить ПДК Правого проезда и заполнить ПДК в Таблицах справа
                #region //////////////////////////////////////////////////////////////// заполняем ПДК по осям и превышения (ПРАВАЯ)    ////////////////////////////////
                ZOsPDK();
                //dataGridView1.RowCount = Convert.ToInt32(alphaBlendTextBox13.Text);
                for (ic = 0; ic < (Convert.ToInt32(alphaBlendTextBox14.Text)); ic++)
                {
                    if (PDKO[ic + 1] != 0)
                    {
                        dataGridView4[9, ic].Value = PDKO[ic + 1];
                        if (Math.Round(Convert.ToDouble(dataGridView4[8, ic].Value) / (PDKO[ic + 1] / 100) - 100, 2) > 0)
                        {
                            dataGridView4[11, ic].Value = Math.Round(Convert.ToDouble(dataGridView4[8, ic].Value) / (PDKO[ic + 1] / 100) - 100, 2);
                            dataGridView4[12, ic].Value = Math.Round(Convert.ToDouble(dataGridView4[8, ic].Value) - PDKO[ic + 1], 2);
                            dataGridView4.Rows[ic].DefaultCellStyle.BackColor = Color.Red;
                        }
                        else
                        {
                            dataGridView4[11, ic].Value = "-";
                            dataGridView4[12, ic].Value = "-";
                        }
                    }
                    else
                    {
                        dataGridView4[9, ic].Value = PDKTel[ic + 1] / Convert.ToInt32(TypO[ic + 1]);
                        if (Math.Round(Convert.ToDouble(dataGridView4[8, ic].Value) / (Convert.ToDouble(dataGridView4[9, ic].Value) / 100) - 100, 2) > 0)
                        {
                            dataGridView4[11, ic].Value = Math.Round(Convert.ToDouble(dataGridView4[8, ic].Value) / (Convert.ToDouble(dataGridView4[9, ic].Value) / 100) - 100, 2);
                            dataGridView4[12, ic].Value = Math.Round(Convert.ToDouble(dataGridView4[8, ic].Value) - Convert.ToDouble(dataGridView4[9, ic].Value), 2);
                            dataGridView4.Rows[ic].DefaultCellStyle.BackColor = Color.Red;
                        }
                        else
                        {
                            dataGridView4[11, ic].Value = "-";
                            dataGridView4[12, ic].Value = "-";
                        }
                    }
                }
                #endregion //////////////////////////
                #region //////////////////////////////////////////////////////////////// заполняем ПДК по тележкам и превышения (левая)    ////////////////////////////////
                //for (ic = 0; ic < GrO; ic++)
                //                   Очищаем массив      {
                for (i = 0; i < KolOs; i++)
                {
                    KNR[1, i] = 0;
                    KNR[0, i] = 0;
                }

                KNR[1, 0] = Convert.ToInt32(TypO[1]);
                KNR[0, 0] = 1;
                ///////////////////////////////////////////       Заполняем первую строку ///////////////////////////////////////////////////
                if (KNR[1, 0] == 1)
                {
                    dataGridView3[9, 0].Value = PDKO[1];// / Convert.ToInt32(TypO[ic + 1]);
                    if (Math.Round(Convert.ToDouble(dataGridView3[8, 0].Value) / (Convert.ToDouble(dataGridView3[9, 0].Value) / 100) - 100, 2) > 0)
                    {
                        dataGridView3[11, 0].Value = Math.Round(Convert.ToDouble(dataGridView3[8, 0].Value) / (Convert.ToDouble(dataGridView3[9, 0].Value) / 100) - 100, 2);
                        dataGridView3[12, 0].Value = Math.Round(Convert.ToDouble(dataGridView3[8, 0].Value) - Convert.ToDouble(dataGridView3[9, 0].Value), 2);
                        dataGridView3.Rows[0].DefaultCellStyle.BackColor = Color.Red;
                    }
                    else
                    {
                        dataGridView3[11, 0].Value = "-";
                        dataGridView3[12, 0].Value = "-";
                    }
                }
                else if (KNR[1, 0] > 1)
                {
                    D1_2 = 0;
                    for (icC = 1; icC <= TypO[1]; icC++)
                    {
                        D1_2 = D1_2 + PDKTel[icC];
                    }

                    dataGridView3[9, 0].Value = D1_2 / icC;// / Convert.ToInt32(TypO[ic + 1]);
                    if (Math.Round(Convert.ToDouble(dataGridView3[8, 0].Value) / (Convert.ToDouble(dataGridView3[9, 0].Value) / 100) - 100, 2) > 0)
                    {
                        dataGridView3[11, 0].Value = Math.Round(Convert.ToDouble(dataGridView3[8, 0].Value) / (Convert.ToDouble(dataGridView3[9, 0].Value) / 100) - 100, 2);
                        dataGridView3[12, 0].Value = Math.Round(Convert.ToDouble(dataGridView3[8, 0].Value) - Convert.ToDouble(dataGridView3[9, 0].Value), 2);
                        dataGridView3.Rows[0].DefaultCellStyle.BackColor = Color.Red;
                    }
                    else
                    {
                        dataGridView3[11, 0].Value = "-";
                        dataGridView3[12, 0].Value = "-";
                    }

                }
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                ////////////////////// Заполняем строки таблицы больше чем первая

                for (ic = 1; ic < GrO; ic++)
                {
                    Sk = "";
                    for (j = 0; j <= ic; j++)
                    {
                        Sk = Sk + Convert.ToString(KNR[1, j]);
                    }
                    Sk = Sk + "1";
                    Fx = 0;
                    for (j = 0; j < Sk.Length; j++)
                    {
                        Fx = Fx + int.Parse(Convert.ToString(Sk[j]));
                    }
                    KNR[1, ic] = Convert.ToInt32(TypO[Fx]);//Количество
                    KNR[0, ic] = Fx; //Позиция

                }
                ////////////////////////////////////////////////////////////////////

                for (ic = 1; ic < GrO; ic++)
                {
                    if (KNR[1, ic] == 1)
                    {
                        dataGridView3[9, ic].Value = PDKO[ic + 1];// / Convert.ToInt32(TypO[ic + 1]);
                        if (Math.Round(Convert.ToDouble(dataGridView3[8, ic].Value) / (Convert.ToDouble(dataGridView3[9, ic].Value) / 100) - 100, 2) > 0)
                        {
                            dataGridView3[11, ic].Value = Math.Round(Convert.ToDouble(dataGridView3[8, ic].Value) / (Convert.ToDouble(dataGridView3[9, ic].Value) / 100) - 100, 2);
                            dataGridView3[12, ic].Value = Math.Round(Convert.ToDouble(dataGridView3[8, ic].Value) - Convert.ToDouble(dataGridView3[9, ic].Value), 2);
                            dataGridView3.Rows[ic].DefaultCellStyle.BackColor = Color.Red;
                        }
                        else
                        {
                            dataGridView3[11, ic].Value = "-";
                            dataGridView3[12, ic].Value = "-";
                        }
                    }
                    else if (KNR[1, ic] > 1)
                    {
                        D1_2 = 0;

                        for (icC = KNR[0, ic]; icC < (KNR[0, ic] - 1 + KNR[1, ic]); icC++)
                        {
                            D1_2 = PDKTel[icC + 1];
                        }

                        dataGridView3[9, ic].Value = D1_2;// / Convert.ToInt32(TypO[ic + 1]);
                        if (Math.Round(Convert.ToDouble(dataGridView3[8, ic].Value) / (Convert.ToDouble(dataGridView3[9, ic].Value) / 100) - 100, 2) > 0)
                        {
                            dataGridView3[11, ic].Value = Math.Round(Convert.ToDouble(dataGridView3[8, ic].Value) / (Convert.ToDouble(dataGridView3[9, ic].Value) / 100) - 100, 2);
                            dataGridView3[12, ic].Value = Math.Round(Convert.ToDouble(dataGridView3[8, ic].Value) - Convert.ToDouble(dataGridView3[9, ic].Value), 2);
                            dataGridView3.Rows[ic].DefaultCellStyle.BackColor = Color.Red;
                        }
                        else
                        {
                            dataGridView3[11, ic].Value = "-";
                            dataGridView3[12, ic].Value = "-";
                            //}
                        }
                    }
                    ////////////////////////////////////////////////////////////////////////
                }
                #endregion ///////////////////////////////////////////

                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            }
        }

        #region/////////////////////////////////////////////   Кл. запрос класса Левый
        public void ZKL()
        {
          
                MySqlCommand command2 = new MySqlCommand();
            ConnectStr conStr2 = new ConnectStr();
            conStr2.ConStr(1);
            Zapros zapros2 = new Zapros();
            string connectionString2;//, commandString;
            connectionString2 = conStr2.StP;//"Data source=localhost;UserId=root;Password=1q2w3e$R;database=camloc;";
            MySqlConnection connection2 = new MySqlConnection(connectionString2);
            zapros2.KlassTS(D111, D1_2, D2_3, D3_4, D4_5,D5_6, D6_7, D7_8, KolOs, ObshMass);
            string z2 = zapros2.commandStringTest;
            command2.CommandText = z2;
            command2.Connection = connection2;
            MySqlDataReader reader2;
            try
            {
                command2.Connection.Open();
                reader2 = command2.ExecuteReader();
                while (reader2.Read())
                {
                    alphaBlendTextBox11.Text = reader2["Klass"].ToString();
                    IDKLLeft= Convert.ToInt32(reader2["idklassts"].ToString());
                    FFF = reader2["naimklassts"].ToString();
                    if (FFF.ToString() == "*Автопоезд*" || FFF.ToString() == "*с прицепом*")
                    { FFFT = "Автопоезд"; PrevNar[27] = 2; }
                    else { FFFT = "Одиночное"; PrevNar[27] = 1; }
                    
                    FF = reader2["tipschema"].ToString();
                    alphaBlendTextBox12.Text = FFF+ ", схема: " + FF ;
                    if (reader2["tipschema"].ToString().Length == 1)
                    {TTS = 1  ;}
                    else if (reader2["tipschema"].ToString().Length > 1)
                    { TTS = 2; }

                    //alphaBlendTextBox6.Text = reader2["timepr"].ToString();
                    //alphaBlendTextBox8.Text = reader2["namead"].ToString();
                    //alphaBlendTextBox7.Text = reader2["namenapr"].ToString();
                    //alphaBlendTextBox2.Text = reader2["npolos"].ToString();
                    //alphaBlendTextBox4.Text = reader2["vehicle_class"].ToString();
                    //alphaBlendTextBox3.Text = reader2["nameapvk"].ToString();
                    //alphaBlendTextBox16.Text = reader2["lp"].ToString();
                    //alphaBlendTextBox5.Text = "Автопоезд";//reader2["timepr"].ToString();
                    //alphaBlendTextBox21.Text = reader2["vehicle_class"].ToString();
                    //alphaBlendTextBox15.Text = reader2["velocity"].ToString();
                    //alphaBlendTextBox14.Text = reader2["axles_count"].ToString();
                    //alphaBlendTextBox20.Text = Convert.ToString(Convert.ToInt32(reader2["total_weight"].ToString()) / 1000);
                    //alphaBlendTextBox18.Text = reader2["length"].ToString();
                    //alphaBlendTextBox17.Text = reader2["s_width"].ToString();
                    //alphaBlendTextBox9.Text = reader2["s_height"].ToString();
                    //label124.Text = reader2["dislocationapvk"].ToString();
                    //if (reader2["Obz"] != System.DBNull.Value) { msdop = new MemoryStream((byte[])reader2["Obz"]); }
                    //if (reader2["lp_image"] != System.DBNull.Value) { nzdop = new MemoryStream((byte[])reader2["lp_image"]); }
                    //if (reader2["ObzLob"] != System.DBNull.Value) { onzdop = new MemoryStream((byte[])reader2["ObzLob"]); }
                    //pictureBox43.Image = Image.FromStream(msdop);

                    /////Пишем номер связанного пр.
                    //string nom = "";
                    ////label32.Text = "";
                    //nom = reader2["lp"].ToString();
                    //alphaBlendTextBox16.Text = reader2["lp"].ToString();
                    //odi = reader2["detection_id"].ToString();
                    //odii = reader2["detection_image_id"].ToString();
                    ////di = reader2["OldIdIm"].ToString();
                    ////dii = reader2["OldIdImDet"].ToString();
                    //if (nom.Length > 3)
                    //{
                    //    label224.Text = nom.Substring(0, 1);
                    //    label223.Text = nom.Substring(1, 1);
                    //    label222.Text = nom.Substring(2, 1);
                    //    if (nom.Length >= 4)
                    //    { label221.Text = nom.Substring(3, 1); }
                    //    else { label221.Text = "-"; }
                    //    if (nom.Length >= 5)
                    //    { label219.Text = nom.Substring(4, 1); }
                    //    else { label219.Text = "-"; }
                    //    if (nom.Length >= 6)
                    //    { label218.Text = nom.Substring(5, 1); }
                    //    else { label218.Text = "-"; }
                    //    if (nom.Length >= 7)
                    //    { label216.Text = nom.Substring(6, 1); }
                    //    else { label216.Text = "-"; }
                    //    if (nom.Length >= 8)
                    //    { label220.Text = nom.Substring(7, 1); }
                    //    else { label220.Text = "-"; }
                    //    if (nom.Length == 9)
                    //    { label217.Text = nom.Substring(8, 1); }
                    //    else { label217.Text = ""; }
                    //}
                    //else
                    //{
                    //    label13.Text = "-";
                    //    label12.Text = "-";
                    //    label11.Text = "-";
                    //}

                }
                reader2.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: \r\n{0}", ex.ToString());
            }
            finally
            {
                command2.Connection.Close();
            }
            //ZPHOTOPR();
        }
        #endregion///////////////////////////////////////////// 

        #region/////////////////////////////////////////////   Кл. запрос класса ПРАВЫЙ
        public void ZKLR()
        {

            MySqlCommand command2 = new MySqlCommand();
            ConnectStr conStr2 = new ConnectStr();
            conStr2.ConStr(1);
            Zapros zapros2 = new Zapros();
            string connectionString2;//, commandString;
            connectionString2 = conStr2.StP;//"Data source=localhost;UserId=root;Password=1q2w3e$R;database=camloc;";
            MySqlConnection connection2 = new MySqlConnection(connectionString2);
            zapros2.KlassTS(D111, D1_2, D2_3, D3_4, D4_5, D5_6, D6_7, D7_8, KolOs, ObshMass);
            string z2 = zapros2.commandStringTest;
            command2.CommandText = z2;
            command2.Connection = connection2;
            MySqlDataReader reader2;
            try
            {
                command2.Connection.Open();
                reader2 = command2.ExecuteReader();
                while (reader2.Read())
                {
                    alphaBlendTextBox4.Text = reader2["Klass"].ToString();
                    string FFF;
                    string FF;
                    FFF = reader2["naimklassts"].ToString();
                    FF = reader2["tipschema"].ToString();
                    alphaBlendTextBox5.Text = FFF + ", схема: " + FF;
                    //alphaBlendTextBox6.Text = reader2["timepr"].ToString();
                    //alphaBlendTextBox8.Text = reader2["namead"].ToString();
                    //alphaBlendTextBox7.Text = reader2["namenapr"].ToString();
                    //alphaBlendTextBox2.Text = reader2["npolos"].ToString();
                    //alphaBlendTextBox4.Text = reader2["vehicle_class"].ToString();
                    //alphaBlendTextBox3.Text = reader2["nameapvk"].ToString();
                    //alphaBlendTextBox16.Text = reader2["lp"].ToString();
                    //alphaBlendTextBox5.Text = "Автопоезд";//reader2["timepr"].ToString();
                    //alphaBlendTextBox21.Text = reader2["vehicle_class"].ToString();
                    //alphaBlendTextBox15.Text = reader2["velocity"].ToString();
                    //alphaBlendTextBox14.Text = reader2["axles_count"].ToString();
                    //alphaBlendTextBox20.Text = Convert.ToString(Convert.ToInt32(reader2["total_weight"].ToString()) / 1000);
                    //alphaBlendTextBox18.Text = reader2["length"].ToString();
                    //alphaBlendTextBox17.Text = reader2["s_width"].ToString();
                    //alphaBlendTextBox9.Text = reader2["s_height"].ToString();
                    //label124.Text = reader2["dislocationapvk"].ToString();
                    //if (reader2["Obz"] != System.DBNull.Value) { msdop = new MemoryStream((byte[])reader2["Obz"]); }
                    //if (reader2["lp_image"] != System.DBNull.Value) { nzdop = new MemoryStream((byte[])reader2["lp_image"]); }
                    //if (reader2["ObzLob"] != System.DBNull.Value) { onzdop = new MemoryStream((byte[])reader2["ObzLob"]); }
                    //pictureBox43.Image = Image.FromStream(msdop);

                    /////Пишем номер связанного пр.
                    //string nom = "";
                    ////label32.Text = "";
                    //nom = reader2["lp"].ToString();
                    //alphaBlendTextBox16.Text = reader2["lp"].ToString();
                    //odi = reader2["detection_id"].ToString();
                    //odii = reader2["detection_image_id"].ToString();
                    ////di = reader2["OldIdIm"].ToString();
                    ////dii = reader2["OldIdImDet"].ToString();
                    //if (nom.Length > 3)
                    //{
                    //    label224.Text = nom.Substring(0, 1);
                    //    label223.Text = nom.Substring(1, 1);
                    //    label222.Text = nom.Substring(2, 1);
                    //    if (nom.Length >= 4)
                    //    { label221.Text = nom.Substring(3, 1); }
                    //    else { label221.Text = "-"; }
                    //    if (nom.Length >= 5)
                    //    { label219.Text = nom.Substring(4, 1); }
                    //    else { label219.Text = "-"; }
                    //    if (nom.Length >= 6)
                    //    { label218.Text = nom.Substring(5, 1); }
                    //    else { label218.Text = "-"; }
                    //    if (nom.Length >= 7)
                    //    { label216.Text = nom.Substring(6, 1); }
                    //    else { label216.Text = "-"; }
                    //    if (nom.Length >= 8)
                    //    { label220.Text = nom.Substring(7, 1); }
                    //    else { label220.Text = "-"; }
                    //    if (nom.Length == 9)
                    //    { label217.Text = nom.Substring(8, 1); }
                    //    else { label217.Text = ""; }
                    //}
                    //else
                    //{
                    //    label13.Text = "-";
                    //    label12.Text = "-";
                    //    label11.Text = "-";
                    //}

                }
                reader2.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: \r\n{0}", ex.ToString());
            }
            finally
            {
                command2.Connection.Close();
            }
            //ZPHOTOPR();
        }
        #endregion///////////////////////////////////////////// 

        #region/////////////////////////////////////////////   Общ.масса запрос ПДК 
        public void ZObPDK()
        {

            MySqlCommand command2 = new MySqlCommand();
            ConnectStr conStr2 = new ConnectStr();
            conStr2.ConStr(1);
            Zapros zapros2 = new Zapros();
            string connectionString2;//, commandString;
            connectionString2 = conStr2.StP;//"Data source=localhost;UserId=root;Password=1q2w3e$R;database=camloc;";
            MySqlConnection connection2 = new MySqlConnection(connectionString2);
            zapros2.PDObshMass(KolOs, TTS);
            string z2 = zapros2.commandStringTest;
            command2.CommandText = z2;
            command2.Connection = connection2;
            MySqlDataReader reader2;
            try
            {
                command2.Connection.Open();
                reader2 = command2.ExecuteReader();
                while (reader2.Read())
                {
                    alphaBlendTextBox22.Text = Convert.ToString(Math.Round(ObshMass / 1000, 2));
                    alphaBlendTextBox36.Text = Convert.ToString((Math.Round(ObshMass / 1000, 2))- (Math.Round(ObshMass / 1000, 2)/100*5));
                    alphaBlendTextBox23.Text = Convert.ToString(Math.Round(Convert.ToDouble(reader2["pdmassts"].ToString()), 2));
                    if (Convert.ToDouble(alphaBlendTextBox36.Text)<= Convert.ToDouble(alphaBlendTextBox23.Text))
                    { alphaBlendTextBox28.Text = "Не выявлено"; 
                    alphaBlendTextBox27.Visible = false;
                    alphaBlendTextBox24.Visible = false;
                    }
                    else if (Convert.ToDouble(alphaBlendTextBox36.Text) > Convert.ToDouble(alphaBlendTextBox23.Text))
                    { alphaBlendTextBox28.Text = "Превышение по общей массе";
                        alphaBlendTextBox27.Visible = true;
                        alphaBlendTextBox24.Visible = true;
                        alphaBlendTextBox27.Text = Convert.ToString(Convert.ToDouble(alphaBlendTextBox36.Text) - Convert.ToDouble(alphaBlendTextBox23.Text));//"11.34 тонн";
                        //alphaBlendTextBox24.Text = Convert.ToString(((Convert.ToDouble(alphaBlendTextBox36.Text)-(Convert.ToDouble(alphaBlendTextBox23.Text))/Convert.ToDouble(alphaBlendTextBox23.Text)*100)*(-1)));//"70";
                        alphaBlendTextBox24.Text = Convert.ToString(Math.Floor(Math.Round(Convert.ToDouble(alphaBlendTextBox36.Text) / (Convert.ToDouble(alphaBlendTextBox23.Text) / 100) - 100, 2)));
                        if (Convert.ToDouble(alphaBlendTextBox24.Text)>=3)
                            {
                            XDate[30] = "True"; PrevNar[17] = Convert.ToDouble(alphaBlendTextBox24.Text);
                            PrevNar[37] = 1;
                        }
                        else
                        {
                            XDate[30] = "False";
                        }
                        label46.Visible = true;
                        label45.Visible = true;
                        label27.Visible = true;
                        label24.Visible = true;
                    }
                    if ((Convert.ToDouble(alphaBlendTextBox36.Text)) - (Convert.ToDouble(alphaBlendTextBox23.Text)) <= 0)
                    {
                        XDate[27] = "0";
                    }
                    else
                    {
                        XDate[27] = Convert.ToString((Convert.ToDouble(alphaBlendTextBox36.Text)) - (Convert.ToDouble(alphaBlendTextBox23.Text)));
                    }
                    XDate[28] = Convert.ToString(Convert.ToDouble(XDate[25]) - Convert.ToDouble(XDate[26]));
                    if (Convert.ToDouble(XDate[28]) <= 0)
                    {
                        XDate[28] = "0";
                    }
                    else if (XDate[12]=="False")
                    { XDate[28] = "0"; }
                }
                reader2.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: \r\n{0}", ex.ToString());
            }
            finally
            {
                command2.Connection.Close();
            }
        }
        #endregion///////////////////////////////////////////// 
        #region/////////////////////////////////////////////   Габариты запрос ПДК 
        public void ZGabarPDK()
        {
            alphaBlendTextBox42.Text = Convert.ToString(Math.Round(DLINATS/100 , 2));
            alphaBlendTextBox37.Text = Convert.ToString((Math.Round(DLINATS/100 , 2)) - 0.6);//длина
            if (TTS == 1) { alphaBlendTextBox41.Text = Convert.ToString(12.00); }
            else if (TTS == 2) { alphaBlendTextBox41.Text = Convert.ToString(20.00); }
            alphaBlendTextBox45.Text = Convert.ToString(Math.Round(SHIRTS / 100, 2));
            if ((Math.Round(SHIRTS / 100, 2) - 0.1) > 0)
            {
                alphaBlendTextBox43.Text = Convert.ToString((Math.Round(SHIRTS / 100, 2)) - 0.1);//ширина
            }
            else { alphaBlendTextBox43.Text = "0"; }
            //alphaBlendTextBox45.Text = Convert.ToString(0.00);
            //alphaBlendTextBox43.Text = Convert.ToString(0.00);
            alphaBlendTextBox44.Text = Convert.ToString(2.60);

            alphaBlendTextBox48.Text = Convert.ToString(Math.Round(VISTS / 100, 2));
            if ((Math.Round(VISTS / 100, 2) - 0.06)>0)
            {
                alphaBlendTextBox46.Text = Convert.ToString((Math.Round(VISTS / 100, 2)) - 0.06);//высота
            }
            else { alphaBlendTextBox46.Text = "0"; }
            //alphaBlendTextBox48.Text = Convert.ToString(0.00);
            //alphaBlendTextBox46.Text = Convert.ToString(0.00);
            alphaBlendTextBox47.Text = Convert.ToString(4.00);
            alphaBlendTextBox38.Text = "Не проверялось";
            ///////////////////// Длина превыш
            if (Convert.ToDouble(alphaBlendTextBox37.Text.ToString()) - Convert.ToDouble(alphaBlendTextBox41.Text.ToString()) > 0)
            {
                XDate[9] = Convert.ToString(Convert.ToDouble(alphaBlendTextBox37.Text.ToString()) - Convert.ToDouble(alphaBlendTextBox41.Text.ToString()));
                // XDate[10] = "True";
                PrevNar[38] = 1;
                PrevDlPr= Convert.ToDouble(Math.Floor(Math.Round(Convert.ToDouble(alphaBlendTextBox37.Text.ToString())/ Convert.ToDouble(alphaBlendTextBox41.Text.ToString())/100-100,2)));
            }
            if (Convert.ToDouble(alphaBlendTextBox37.Text.ToString()) - Convert.ToDouble(alphaBlendTextBox41.Text.ToString()) <= 0)
            {
                XDate[9] = "0";
                //XDate[8] = "False";
            }
            ////////////////// Ширина превыш
            if (Convert.ToDouble(alphaBlendTextBox43.Text.ToString()) - Convert.ToDouble(alphaBlendTextBox44.Text.ToString()) > 0)
            {
                XDate[10] = Convert.ToString(Convert.ToDouble(alphaBlendTextBox43.Text.ToString()) - Convert.ToDouble(alphaBlendTextBox44.Text.ToString()));
                // XDate[10] = "True";
            }
            if (Convert.ToDouble(alphaBlendTextBox43.Text.ToString()) - Convert.ToDouble(alphaBlendTextBox44.Text.ToString()) <= 0)
            {
                XDate[10] = "0";
                //XDate[8] = "False";
            }
            ///////////////// Высота превыш
            if (Convert.ToDouble(alphaBlendTextBox48.Text.ToString()) - Convert.ToDouble(alphaBlendTextBox47.Text.ToString()) > 0)
            {
                XDate[11] = Convert.ToString(Convert.ToDouble(alphaBlendTextBox48.Text.ToString()) - Convert.ToDouble(alphaBlendTextBox47.Text.ToString()));
                // XDate[10] = "True";
            }
            if (Convert.ToDouble(alphaBlendTextBox48.Text.ToString()) - Convert.ToDouble(alphaBlendTextBox47.Text.ToString()) <= 0)
            {
                XDate[11] = "0";
                //XDate[8] = "False";
            }
            ////////////////////////// И по СР
            ///////////////////// Длина превыш
            if (XDate[12].ToString() != "False")
            {
                if (Convert.ToDouble(alphaBlendTextBox37.Text.ToString()) - Convert.ToDouble(XDate[19].ToString()) > 0)
                {
                    XDate[22] = Convert.ToString(Convert.ToDouble(alphaBlendTextBox37.Text.ToString()) - Convert.ToDouble(XDate[19].ToString()));
                    // XDate[10] = "True";
                    PrevNar[38] = 1;
                    PrevDlPr = Convert.ToDouble(Math.Floor(Math.Round(Convert.ToDouble(alphaBlendTextBox37.Text.ToString()) / Convert.ToDouble(alphaBlendTextBox19.Text.ToString()) / 100 - 100, 2)));
                }
                if (Convert.ToDouble(alphaBlendTextBox37.Text.ToString()) - Convert.ToDouble(XDate[19].ToString()) <= 0)
                {
                    XDate[22] = "0";
                    //XDate[8] = "False";
                }
                ////////////////// Ширина превыш
                if (Convert.ToDouble(alphaBlendTextBox43.Text.ToString()) - Convert.ToDouble(XDate[20].ToString()) > 0)
                {
                    XDate[23] = Convert.ToString(Convert.ToDouble(alphaBlendTextBox43.Text.ToString()) - Convert.ToDouble(XDate[20].ToString()));
                    // XDate[10] = "True";
                }
                if (Convert.ToDouble(alphaBlendTextBox43.Text.ToString()) - Convert.ToDouble(XDate[20].ToString()) <= 0)
                {
                    XDate[23] = "0";
                    //XDate[8] = "False";
                }
                ///////////////// Высота превыш
                if (Convert.ToDouble(alphaBlendTextBox48.Text.ToString()) - Convert.ToDouble(XDate[21].ToString()) > 0)
                {
                    XDate[24] = Convert.ToString(Convert.ToDouble(alphaBlendTextBox48.Text.ToString()) - Convert.ToDouble(XDate[21].ToString()));
                    // XDate[10] = "True";
                }
                if (Convert.ToDouble(alphaBlendTextBox48.Text.ToString()) - Convert.ToDouble(XDate[21].ToString()) <= 0)
                {
                    XDate[24] = "0";
                    //XDate[8] = "False";
                }
            }
            else
            {
                XDate[22] = "0";
                XDate[23] = "0";
                XDate[24] = "0";
            }

            //if (Convert.ToDouble(alphaBlendTextBox36.Text) <= Convert.ToDouble(alphaBlendTextBox23.Text))
            ////////////{ alphaBlendTextBox38.Text = "Не проверялось"; }
            ////////////else if (Convert.ToDouble(alphaBlendTextBox36.Text) > Convert.ToDouble(alphaBlendTextBox23.Text))
            ////////////{
            ////////////    alphaBlendTextBox28.Text = "Превышение";
            ////////////    alphaBlendTextBox27.Text = Convert.ToString(Convert.ToDouble(alphaBlendTextBox36.Text) - Convert.ToDouble(alphaBlendTextBox23.Text));
            ////////////    alphaBlendTextBox24.Text = Convert.ToString(Convert.ToDouble(alphaBlendTextBox36.Text) / (Convert.ToDouble(alphaBlendTextBox23.Text) / 100));
            ////////////    label46.Visible = true;
            ////////////    label45.Visible = true;
            ////////////}


            //MySqlCommand command2 = new MySqlCommand();
            //ConnectStr conStr2 = new ConnectStr();
            //conStr2.ConStr(1);
            //Zapros zapros2 = new Zapros();
            //string connectionString2;//, commandString;
            //connectionString2 = conStr2.StP;//"Data source=localhost;UserId=root;Password=1q2w3e$R;database=camloc;";
            //MySqlConnection connection2 = new MySqlConnection(connectionString2);
            //zapros2.PDObshMass(KolOs, TTS);
            //string z2 = zapros2.commandStringTest;
            //command2.CommandText = z2;
            //command2.Connection = connection2;
            //MySqlDataReader reader2;
            //try
            //{
            //    command2.Connection.Open();
            //    reader2 = command2.ExecuteReader();
            //    while (reader2.Read())
            //    {
            //        alphaBlendTextBox22.Text = Convert.ToString(Math.Round(ObshMass / 1000, 2));
            //        alphaBlendTextBox36.Text = Convert.ToString((Math.Round(ObshMass / 1000, 2)) - (Math.Round(ObshMass / 1000, 2) / 100 * 5));
            //        alphaBlendTextBox23.Text = Convert.ToString(Math.Round(Convert.ToDouble(reader2["pdmassts"].ToString()), 2));
            //        if (Convert.ToDouble(alphaBlendTextBox36.Text) <= Convert.ToDouble(alphaBlendTextBox23.Text))
            //        { alphaBlendTextBox28.Text = "Не превышено"; }
            //        else if (Convert.ToDouble(alphaBlendTextBox36.Text) > Convert.ToDouble(alphaBlendTextBox23.Text))
            //        {
            //            alphaBlendTextBox28.Text = "Превышение";
            //            alphaBlendTextBox27.Text = Convert.ToString(Convert.ToDouble(alphaBlendTextBox36.Text) - Convert.ToDouble(alphaBlendTextBox23.Text));
            //            alphaBlendTextBox24.Text = Convert.ToString(Convert.ToDouble(alphaBlendTextBox36.Text) / (Convert.ToDouble(alphaBlendTextBox23.Text) / 100));
            //            label46.Visible = true;
            //            label45.Visible = true;
            //        }
            //    }
            //    reader2.Close();
            //}
            //catch (MySqlException ex)
            //{
            //    Console.WriteLine("Error: \r\n{0}", ex.ToString());
            //}
            //finally
            //{
            //    command2.Connection.Close();
            //}
        }
        #endregion///////////////////////////////////////////// 
        #region/////////////////////////////////////////////   Осевая масса запрос ПДК 
        public void ZOsPDK()
        {
            for (ic = 1; ic < KolOs + 1; ic++)
            {
                if (ic < 9)
                {
                    MySqlCommand command2 = new MySqlCommand();
                    ConnectStr conStr2 = new ConnectStr();
                    conStr2.ConStr(1);
                    Zapros zapros2 = new Zapros();
                    string connectionString2;//, commandString;
                    connectionString2 = conStr2.StP;//"Data source=localhost;UserId=root;Password=1q2w3e$R;database=camloc;";
                    MySqlConnection connection2 = new MySqlConnection(connectionString2);
                    if (D[ic] > 0)
                    {
                        if (Convert.ToInt32(TypO[ic]) > 1 && D[ic - 1] == 0)
                        {
                            zapros2.PDOsNagr(Convert.ToInt32(DoubO[ic]), Convert.ToInt32(TypO[ic]), ADNagr, (D[ic]*100));

                        }
                        else if (Convert.ToInt32(TypO[ic]) > 1 && D[ic - 1] <= D[ic])
                        {
                            zapros2.PDOsNagr(Convert.ToInt32(DoubO[ic]), Convert.ToInt32(TypO[ic]), ADNagr, (D[ic - 1]*100));

                        }
                        else if (Convert.ToInt32(TypO[ic]) > 1 && D[ic - 1] > D[ic])
                        {
                            zapros2.PDOsNagr(Convert.ToInt32(DoubO[ic]), Convert.ToInt32(TypO[ic]), ADNagr, (D[ic] * 100));

                        }
                        else if (Convert.ToInt32(TypO[ic]) == 1)
                        {
                            zapros2.PDOsNagr(Convert.ToInt32(DoubO[ic]), Convert.ToInt32(TypO[ic]), ADNagr, (D[ic] * 100));

                        }
                    }
                    //zapros2.PDOsNagr(Convert.ToInt32(DoubO[ic]), Convert.ToInt32(TypO[ic]), ADNagr, D[ic]); }
                    else { zapros2.PDOsNagr(Convert.ToInt32(DoubO[ic]), Convert.ToInt32(TypO[ic]), ADNagr, (D[ic - 1] * 100)); }

                    string z2 = zapros2.commandStringTest;
                    command2.CommandText = z2;
                    command2.Connection = connection2;
                    MySqlDataReader reader2;
                    try
                    {
                        command2.Connection.Open();
                        reader2 = command2.ExecuteReader();
                        while (reader2.Read())
                        {
                            PDKO[ic] = Convert.ToDouble(reader2["pdo"].ToString());
                            PDKTel[ic] = Convert.ToDouble(reader2["pdt"].ToString());

                            //alphaBlendTextBox22.Text = Convert.ToString(Math.Round(ObshMass / 1000, 2));
                            //alphaBlendTextBox36.Text = Convert.ToString((Math.Round(ObshMass / 1000, 2)) - (Math.Round(ObshMass / 1000, 2) / 100 * 5));
                            //alphaBlendTextBox23.Text = Convert.ToString(Math.Round(Convert.ToDouble(reader2["pdmassts"].ToString()), 2));
                            //if (Convert.ToDouble(alphaBlendTextBox36.Text) <= Convert.ToDouble(alphaBlendTextBox23.Text))
                            //{ alphaBlendTextBox28.Text = "Не превышено"; }
                            //else if (Convert.ToDouble(alphaBlendTextBox36.Text) > Convert.ToDouble(alphaBlendTextBox23.Text))
                            //{
                            //    alphaBlendTextBox28.Text = "Превышение";
                            //    alphaBlendTextBox27.Text = Convert.ToString(Convert.ToDouble(alphaBlendTextBox36.Text) - Convert.ToDouble(alphaBlendTextBox23.Text));
                            //    alphaBlendTextBox24.Text = Convert.ToString(Convert.ToDouble(alphaBlendTextBox36.Text) / (Convert.ToDouble(alphaBlendTextBox23.Text) / 100));
                            //    label46.Visible = true;
                            //    label45.Visible = true;
                            //}
                        }
                        reader2.Close();
                    }
                    catch (MySqlException ex)
                    {
                        Console.WriteLine("Error: \r\n{0}", ex.ToString());
                    }
                    finally
                    {
                        command2.Connection.Close();
                    }
                }
            }
        }
        #endregion///////////////////////////////////////////// 

        #region /////////////////////////////////////////// УЗНАЕМ МАКСИМАЛЬНЫЙ НОМЕР АКТА
        public void MNAKT()
        { 
        MySqlCommand command = new MySqlCommand();
        ConnectStr conStr = new ConnectStr();
        conStr.ConStr(1);
            Zapros zapros = new Zapros();
        string connectionString;
        connectionString = conStr.StP;//"Data source=localhost;UserId=root;Password=1q2w3e$R;database=camloc;";
            MySqlConnection connection = new MySqlConnection(connectionString);
        zapros.MaxAktNum();
            string z = zapros.commandStringTest;

        command.CommandText = z;// commandString;
            command.Connection = connection;
            MySqlDataReader reader;
            try
            {
                command.Connection.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {

                    A1[0] = Convert.ToString(Convert.ToInt32(reader["MNA"].ToString()) + 1);
                }
                reader.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: \r\n{0}", ex.ToString());
            }
            finally
            {
                command.Connection.Close();
            }

        }
        #endregion///////////////////////////////////////////// 

       
#region ////////////////////////////////////////////// Делаем фильтр и все ссылк к нему (до строки ////////////////////////)
        private void StopSearchPR()  // 
        {
            label122.Text = "";
            //dateTimePicker9.Value = dateTimePicker6.Value;
            //dateTimePicker10.Value = dateTimePicker5.Value;
            string TXTFLEFT = "";
            TXTFLEFT = "datetime_local >= '" + dateTimePicker1.Value + "' and datetime_local <= '" + dateTimePicker2.Value + "'";
            if (textBox6.Text != "")
            {
                TXTFLEFT = TXTFLEFT + "and lp LIKE '*" + textBox6.Text + "*'";
                //DataView dv;
                //dv = new DataView(DS.Tables[0], "(datetime_local >= '" + dateTimePicker7.Value + "' and datetime_local <= '" + dateTimePicker8.Value + "' and lp LIKE '*" + textBoxGRZ.Text + "*') ", "", DataViewRowState.CurrentRows);
                //dataGridView8.DataSource = dv;
            }
            string w = comboBox5.Text;
            if (w != "")
            {
                string MOb = "";
                switch (w)
                {
                    case "<1000 кг":
                        MOb = " and ObshM < 1";
                        //SP = " and [SpeedTS] > 19 and [SpeedTS] < 40";
                        break;
                    case "1000-3000 кг":
                        MOb = " and ObshM > 1 and ObshM < 3 ";
                        //SP = " and [SpeedTS] > 39 and [SpeedTS] < 60";
                        break;
                    case "3000-5000 кг":
                        MOb = " and ObshM > 3 and ObshM < 5 ";
                        //SP = " and [SpeedTS] > 59 and [SpeedTS] < 80";
                        break;
                    case "5000-10000 кг":
                        MOb = " and ObshM > 5 and ObshM < 10 ";
                        //SP = " and [SpeedTS] > 79 and [SpeedTS] < 100";
                        break;
                    case "10000-20000 кг":
                        MOb = " and ObshM > 10 and ObshM < 20 ";
                        //SP = " and [SpeedTS] > 99 ";
                        break;
                    case "20000-30000 кг":
                        MOb = " and ObshM > 20 and ObshM < 30 ";
                        //SP = " and [SpeedTS] > 99 ";
                        break;
                    case ">30000 кг":
                        MOb = " and ObshM > 30";
                        //SP = " and [SpeedTS] > 99 ";
                        break;
                    default:
                        MOb = "";
                        //SP = "";
                        break;
                }
                TXTFLEFT = TXTFLEFT + MOb;
            }
            //if (checkBox10.Checked == true)
            //{
            //    TXTFLEFT = TXTFLEFT + " and validityInvert =-1";
            //}
            //string CBKL = comboBox9.Text;
            //if (CBKL != "")
            //{
            //    fGRZ = "";
            //    switch (CBKL)
            //    {
            //        case "Легковой автомобиль":
            //            fGRZ = " and (vehicle_class = 1 or vehicle_class = 2 or vehicle_class = 30 or vehicle_class = 3 or vehicle_class = 34  or vehicle_class = 4) and axles_count < 4";
            //            //SP = " and [SpeedTS] > 19 and [SpeedTS] < 40";
            //            break;
            //        case "Микроавтобус":
            //            fGRZ = " and (vehicle_class = 2 or vehicle_class = 40 or vehicle_class = 5)";
            //            //SP = " and [SpeedTS] > 19 and [SpeedTS] < 40";
            //            break;
            //        //case "Легковой автомобиль с прицепом(1 - ось)":
            //        //    fGRZ = " and vehicle_class = 3 and vehicle_class = 34";
            //        //    //SP = " and [SpeedTS] > 19 and [SpeedTS] < 40";
            //        //    break;
            //        //case "Легковой автомобиль с прицепом(2 - оси)":
            //        //    fGRZ = " and vehicle_class = 4 and vehicle_class = 34";
            //        //    //SP = " and [SpeedTS] > 19 and [SpeedTS] < 40";
            //        //    break;
            //        //case "Микроавтобус(длиння база)":
            //        //    fGRZ = " and vehicle_class = 5 and vehicle_class = 40";
            //        //    //SP = " and [SpeedTS] > 19 and [SpeedTS] < 40";
            //        //    break;
            //        //case "Микроавтобус(длиння база) с прицепом(1 - ось)":
            //        //    fGRZ = " and vehicle_class = 5 and vehicle_class = 40";
            //        //    //SP = " and [SpeedTS] > 19 and [SpeedTS] < 40";
            //        //    break;
            //        //case "Микроавтобус(д.б.) с прицепом(2 - оси)":
            //        //    fGRZ = " and vehicle_class = 5 and vehicle_class = 40";
            //        //    //SP = " and [SpeedTS] > 19 and [SpeedTS] < 40";
            //        //    break;
            //        case "Грузовой автомобиль":
            //            fGRZ = " and (vehicle_class = 5 or vehicle_class = 40 or vehicle_class = 6 or vehicle_class = 34 or vehicle_class = 7 or vehicle_class = 8 or vehicle_class = 13 or vehicle_class = 37 or vehicle_class = 22 or vehicle_class = 19 or vehicle_class = 33 or vehicle_class = 20)";
            //            //SP = " or [SpeedTS] > 19 and [SpeedTS] < 40";
            //            break;
            //        case "Автопоезд (Седельный тягач с полуприцепом)":
            //            fGRZ = " and (vehicle_class = 26 or vehicle_class = 22 or vehicle_class = 11 or vehicle_class = 23 or vehicle_class = 25 or vehicle_class = 56 or vehicle_class = 29)";
            //            //SP = " and [SpeedTS] > 19 and [SpeedTS] < 40";
            //            break;
            //        case "Автобус":
            //            fGRZ = " and vehicle_class = 27";
            //            //SP = " and [SpeedTS] > 19 and [SpeedTS] < 40";
            //            break;
            //        default:
            //            fGRZ = "";
            //            //SP = "";
            //            break;
            //    }
            //    TXTFLEFT = TXTFLEFT + fGRZ;
            //}
            string NAVGK = comboBox4.Text;

            if (NAVGK != "")
            {
                TXTFLEFT = TXTFLEFT + "and [№ комплекса] LIKE '" + comboBox4.SelectedValue.ToString() + "*'";
            }

            DataView dvPR;
            //////////////////////////////////dvPR = new DataView(DSPR.Tables[0], TXTFLEFT, "", DataViewRowState.CurrentRows);
            //////////////////////////////////dataGridView11.DataSource = dvPR;
            //else
            //{
            //    //DataView dv;
            //    //dv = new DataView(DS.Tables[0], "(datetime_local >= '" + dateTimePicker7.Value + "' and datetime_local <= '" + dateTimePicker8.Value + "') ", "", DataViewRowState.CurrentRows);
            //    //dataGridView8.DataSource = dv;
            //}


            ////////////DataView dv;
            ////////////dv = new DataView(DS.Tables[0], "(datetime_local >= '" + dateTimePicker7.Value + "' and datetime_local <= '" + dateTimePicker8.Value + "') and "
            ////////////    + "IDWim LIKE '" + comboBox2.ValueMember + "*'", "", DataViewRowState.CurrentRows);
            ////////////dataGridView8.DataSource = dv;
            //this.allCamNaprBindingSource.Filter = "(datetime_local >= '" + dateTimePicker7.Value + "' and datetime_local <= '" + dateTimePicker8.Value + "' and "
            //+ "validityInvert = " + V + ")";// and lp LIKE " + textBoxGRZ.Text + "
            //pmonitorBindingSource.Filter = string.Format("DatchN LIKE '" + toolStripComboBox2.Text + "*' and SpecTS LIKE '"
            //    + toolStripComboBox1.Text.Remove(0, 3) + "*' and [DateZ] >= Convert('{1}','System.DateTime') " +
            //    "and [DateZ] <= Convert('{2}','System.DateTime') and GRZRasp LIKE '*" + toolStripTextBox2.Text + "*' {3} {4} {5} {6} {7}",
            //    toolStripTextBox1.Text, dateTimePicker1.Value.Date, dateTimePicker2.Value.Date.AddDays(1), ChValid, PF, SP, MOb, fGRZ);

            //toolStripLabel10.Text = dataGridView2.RowCount.ToString();
            //Otrisovka();
            ////////////and [Valid]={4}
            ////////////pMonitBindingSource.Filter = string.Format("[DateZ] <= Convert('{0}','System.DateTime')", dateTimePicker2.Value.Date);

            if (toolStripLabel18.Text != "")
            {
                kol = Convert.ToInt32(toolStripLabel18.Text);
            }
            if (dataGridView11.RowCount > 0)
            {
                rowIndex = dataGridView11.SelectedCells[0].RowIndex;
                if (kol > rowIndex)
                { kol = 0; }
                int Sum = 0;
                for (int i = 0; i < dataGridView11.Rows.Count; i++)
                {
                    Sum = Sum + 1;
                }
                if (Sum - kol < Sum)
                { kol = Sum - kol; }
                dataGridView11.CurrentCell = dataGridView11[0, rowIndex + kol];
                currentRowLeft = rowIndex + kol;
                //this.allCamNaprBindingSource.Filter = "(datetime_local >= '" + dateTimePicker1.Value + "' and datetime_local <= '" + dateTimePicker2.Value + "')";
                //dataGridView8.Refresh();
                toolStripLabel18.Text = "" + (Convert.ToInt32(Sum)).ToString();

            }
            else
            {
                //DataView dvM;
                dvPR = new DataView(DSPR.Tables[0], "(datetime_local >= '" + dateTimePicker1.Value + "' and datetime_local <= '" + dateTimePicker2.Value + "') ", "", DataViewRowState.CurrentRows);
                dataGridView11.DataSource = dvPR;
                label122.Text = "ЗАПИСИ УДОВЛЕТВОРЯЮЩИЕ ЗАПРОСУ НЕ НАЙДЕНЫ";
            }
        }
        #endregion /////////////////////////////////////////////////

        private void dataGridView11_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int currentRow = dataGridView11.CurrentRow.Index; // номер строки, по которой кликнули
            alphaBlendTextBox10.Text = dataGridView11[0, currentRow].Value.ToString();
            alphaBlendTextBox6.Text = dataGridView11[13, currentRow].Value.ToString();
            alphaBlendTextBox9.Text = dataGridView11[12, currentRow].Value.ToString().Substring(0, 10);
            ZagrdataGridView11(Convert.ToInt32(alphaBlendTextBox10.Text));
        }

        private void toolStripLabel18_TextChanged(object sender, EventArgs e)
        {
            int Sum = 0;
            for (int i = 0; i < dataGridView11.Rows.Count; i++)
            {
                if (Convert.ToInt32(dataGridView11.Rows[i].Cells[26].Value) == 0)
                {
                    Sum = Sum + 1;
                }
            }
            toolStripLabel20.Text = "" + (Convert.ToInt32(Sum)).ToString();
        }

        private void maskedTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
         
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && (number < 'А' || number > 'я'))
            {
                maskedTextBox1.BackColor = Color.DeepPink;
                e.Handled = true;
                
            }
            else
            {
                maskedTextBox1.BackColor = Color.White;
            }
         
        }

        private void maskedTextBox1_Click(object sender, EventArgs e)
        {
            button1.Visible = true;
            button2.Visible = true;
        }

        private void maskedTextBox2_Click(object sender, EventArgs e)
        {
            LPPR = "";
            button7.Visible = true;
            button8.Visible = true;
            LPPR = maskedTextBox2.Text;
        }

        private void button7_Click(object sender, EventArgs e)////////  Кнопка "Отменить изменения ГРЗ ПРАВАЯ"
        {
            maskedTextBox2.Text = LPPR;
            //maskedTextBox1.Visible = false;            
            button7.Visible = false;
            button8.Visible = false;
        }

        private void button8_Click(object sender, EventArgs e)////////  Кнопка "Принять изменения ГРЗ ПРАВАЯ"
        {
            string OGRZ = LPPR;
            int IDTSIsh = Convert.ToInt32(alphaBlendTextBox10.Text);
            //string NLPDO= maskedTextBox1.Text;
            string NLP = maskedTextBox2.Text.Replace(" ", "");
            if (NLP.Length < 9)
            {
                DialogResult result = MessageBox.Show("Введеный Вами номерной знак имеет структуру, \n отличную от << А 000 АА 000 >> \n Вы действительно хотите сохранить введеный знак?", "Изменение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {

                }
                if (result == DialogResult.Yes)
                {
                    chang = 2;
                    MySqlCommand command = new MySqlCommand();
                    ConnectStr conStr = new ConnectStr();
                    Zapros zapros = new Zapros();
                    conStr.ConStr(1);
                    zapros.ZaprObrGRZLoc(IDTSIsh, OGRZ, NLP, NamU, chang);
                    MySqlConnection connection = new MySqlConnection(cstr);
                    string z = zapros.commandStringTest;
                    command.CommandText = z;
                    command.Connection = connection;
                    try
                    {
                        command.Connection.Open();
                        command.ExecuteNonQuery();
                        command.Connection.Close();
                    }
                    catch (MySqlException ex)
                    { Console.WriteLine("Error: \r\n{0}", ex.ToString()); }
                    finally
                    { command.Connection.Close(); }
                }
            }
            else
            {
                chang = 2;
                MySqlCommand command = new MySqlCommand();
                ConnectStr conStr = new ConnectStr();
                Zapros zapros = new Zapros();
                conStr.ConStr(1);
                zapros.ZaprObrGRZLoc(IDTSIsh, OGRZ, NLP, NamU, chang);
                MySqlConnection connection = new MySqlConnection(cstr);
                string z = zapros.commandStringTest;
                command.CommandText = z;
                command.Connection = connection;
                try
                {
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }
                catch (MySqlException ex)
                { Console.WriteLine("Error: \r\n{0}", ex.ToString()); }
                finally
                { command.Connection.Close(); }
            }
            //maskedTextBox1.Visible = false;           
            button7.Visible = false;
            button8.Visible = false;
            //Timer=(100);
            PRSpisPr();
            //ZIzm(IDTSIsh);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            int IDT= Convert.ToInt32(alphaBlendTextBox25.Text);
            //int[] AC, decimal[] AI, decimal[] AL, string DT, string CPC, int D, decimal TW, string GRZ, decimal H, decimal L, decimal W
            WCPSoapClientForm.Form1 FRMALEX = new WCPSoapClientForm.Form1();
            FRMALEX.ACc = AC; FRMALEX.AIc = AI; FRMALEX.ALc = AL; FRMALEX.DTc = DT; FRMALEX.CPCc = CPC;
            FRMALEX.Dc = Dc; FRMALEX.TWc = TW; FRMALEX.GRZc = GRZ; FRMALEX.Hc = H; FRMALEX.Lc = L; FRMALEX.Wc = W; 
            FRMALEX.IdPr = Convert.ToInt32(alphaBlendTextBox25.Text);
            FRMALEX.ShowDialog(); //Show();
            //ConsoleApp1.Program.Main();

            MySqlCommand command = new MySqlCommand();
            ConnectStr conStr = new ConnectStr();
            Zapros zapros = new Zapros();
            conStr.ConStr(1);
            zapros.ZaprObrSpRazrLoc(IDT, NamU, 1);
            MySqlConnection connection = new MySqlConnection(cstr);
            string z = zapros.commandStringTest;
            command.CommandText = z;
            command.Connection = connection;
            try
            {
                command.Connection.Open();
                command.ExecuteNonQuery();
                command.Connection.Close();
            }
            catch (MySqlException ex)
            { Console.WriteLine("Error: \r\n{0}", ex.ToString()); }
            finally
            { command.Connection.Close(); }
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            Form3_LoadPMonit(IDT, NamU);
            //ZagrPr(IDT);

        }

        ////////#region/////////////////////////////////////////////   загрузка всех параметров проезда для K(ПРАВЫЙ) //////////////////  
        ////////public void ZagrdataGridView1(int IDp)
        ////////{
        ////////    MySqlCommand commandLPR = new MySqlCommand();
        ////////    ConnectStr conStrLPR = new ConnectStr();
        ////////    conStrLPR.ConStr(1);
        ////////    Zapros zaprosLPR = new Zapros();
        ////////    string connectionStringLPR;//, commandString;
        ////////    connectionStringLPR = conStrLPR.StP;//"Data source=localhost;UserId=root;Password=1q2w3e$R;database=camloc;";
        ////////    MySqlConnection connectionLPR = new MySqlConnection(connectionStringLPR);
        ////////    zaprosLPR.RDLYAIZMENENIYA(IDp);
        ////////    zLPR = zaprosLPR.commandStringTest;
        ////////    commandLPR.CommandText = zLPR;// commandString;
        ////////    commandLPR.Connection = connectionLPR;
        ////////    MySqlDataReader readerLPR;
        ////////    try
        ////////    {
        ////////        commandLPR.Connection.Open();
        ////////        readerLPR = commandLPR.ExecuteReader();
        ////////        while (readerLPR.Read())
        ////////        {
        ////////            //if (readerLPR["Obz"] != System.DBNull.Value) { ms = new MemoryStream((byte[])readerLPR["Obz"]); }
        ////////            //if (readerLPR["lp_image"] != System.DBNull.Value) { nz = new MemoryStream((byte[])readerLPR["lp_image"]); }
        ////////            ////if (reader["ObzLob"] != System.DBNull.Value) { onzdop = new MemoryStream((byte[])reader["ObzLob"]); }
        ////////            //pictureBox40.Image = Image.FromStream(ms);
        ////////            //pictureBox29.Image = Image.FromStream(nz);
        ////////            #region ///// Заполнение переменных о выбранном проезде для определения класса и расчета ПДК :)
        ////////            KolOsR = Convert.ToInt32(readerLPR["axles_count"]);
        ////////            D = new double[10];
        ////////            TypO = new double[10];
        ////////            DoubO = new double[10];
        ////////            NarOb = "";
        ////////            for (ic = 1; ic < KolOsR + 1; ic++)
        ////////            {
        ////////                int DBL = 0;
        ////////                if (Convert.ToInt32(readerLPR["dbl" + (ic)]) == 0)
        ////////                {
        ////////                    DBL = 1;// (Convert.ToInt32( readerL["dbl" + (ic)]));
        ////////                }
        ////////                else
        ////////                {
        ////////                    DBL = (Convert.ToInt32(readerLPR["dbl" + (ic)]));
        ////////                }
        ////////                if (ic == KolOsR)
        ////////                {
        ////////                    DoubO[ic] = DBL;// (Convert.ToInt32( readerL["dbl" + (ic)]));
        ////////                    if (D[ic - 1] >= 245)
        ////////                    { TypO[ic] = 1; }
        ////////                    else if (D[ic - 1] > 0 && D[ic - 1] < 245)
        ////////                    {
        ////////                        if (D[ic - 2] > 0 && D[ic - 2] < 245)
        ////////                        {
        ////////                            if (D[ic - 3] > 0 && D[ic - 3] < 245)
        ////////                            {
        ////////                                TypO[ic] = 4; TypO[ic - 1] = 4; TypO[ic - 2] = 4; TypO[ic - 3] = 4;
        ////////                            }
        ////////                            else { TypO[ic] = 3; TypO[ic - 1] = 3; TypO[ic - 2] = 3; }
        ////////                        }
        ////////                        else { TypO[ic] = 2; TypO[ic - 1] = 2; }
        ////////                    }
        ////////                    break;
        ////////                }
        ////////                if (ic <= 9)
        ////////                {
        ////////                    if (Convert.ToDouble(readerLPR["axles_" + (ic) + "_" + (ic + 1) + "_base"]) > 0)
        ////////                    {
        ////////                        D[ic] = (Convert.ToDouble(readerLPR["axles_" + (ic) + "_" + (ic + 1) + "_base"]) + 6);//+ 3);
        ////////                    }
        ////////                    DoubO[ic] = DBL;// (Convert.ToInt32( readerL["dbl" + (ic)]));
        ////////                    switch (ic)
        ////////                    {
        ////////                        case 1:
        ////////                            if (D[ic] >= 245)
        ////////                            { TypO[ic] = 1; }
        ////////                            else if (D[ic] > 0 && D[ic] < 245)
        ////////                            {
        ////////                                if (KolOsR == 2)
        ////////                                {
        ////////                                    TypO[ic] = 1;
        ////////                                }
        ////////                                else
        ////////                                {
        ////////                                    TypO[ic] = 2;
        ////////                                }
        ////////                            }
        ////////                            break;
        ////////                        case 2:
        ////////                            if (D[ic] >= 245)
        ////////                            {
        ////////                                if (D[ic - 1] >= 245)
        ////////                                { TypO[ic] = 1; }
        ////////                                else if (D[ic - 1] > 0 && D[ic - 1] < 245)
        ////////                                {
        ////////                                    TypO[ic] = 2;
        ////////                                }
        ////////                            }
        ////////                            else if (D[ic] > 0 && D[ic] < 245)
        ////////                            {
        ////////                                if (D[ic - 1] >= 245)
        ////////                                { TypO[ic] = 2; }
        ////////                                else if (D[ic - 1] > 0 && D[ic - 1] < 245)
        ////////                                {
        ////////                                    TypO[ic] = 3;
        ////////                                    TypO[ic - 1] = 3;
        ////////                                }

        ////////                            }
        ////////                            if (KolOsR == 2)
        ////////                            {
        ////////                                TypO[ic] = 1;
        ////////                            }
        ////////                            break;
        ////////                        case 3:
        ////////                            if (D[ic] >= 245)
        ////////                            {
        ////////                                if (D[ic - 1] >= 245)
        ////////                                { TypO[ic] = 1; }
        ////////                                else if (D[ic - 1] > 0 && D[ic - 1] < 245)
        ////////                                {
        ////////                                    if (D[ic - 2] > 0 && D[ic - 2] < 245)
        ////////                                    {
        ////////                                        TypO[ic] = 3;
        ////////                                        TypO[ic - 1] = 3;
        ////////                                        TypO[ic - 2] = 3;
        ////////                                    }
        ////////                                    else { TypO[ic] = 2; TypO[ic - 1] = 2; }
        ////////                                }
        ////////                            }
        ////////                            else if (D[ic] >= 0 && D[ic] < 245)
        ////////                            {
        ////////                                if (D[ic - 1] >= 245)
        ////////                                { TypO[ic] = 2; }
        ////////                                else if (D[ic - 1] > 0 && D[ic - 1] < 245)
        ////////                                {
        ////////                                    if (D[ic - 2] > 0 && D[ic - 2] < 245)
        ////////                                    {
        ////////                                        if (D[ic] == 0)
        ////////                                        { TypO[ic] = 3; TypO[ic - 1] = 3; TypO[ic - 2] = 3; break; }
        ////////                                        else { TypO[ic] = 4; TypO[ic - 1] = 4; TypO[ic - 2] = 4; }
        ////////                                    }
        ////////                                    else
        ////////                                    {
        ////////                                        if (D[ic] == 0)
        ////////                                        { TypO[ic] = 2; TypO[ic - 1] = 2; break; }
        ////////                                        else { TypO[ic] = 3; TypO[ic - 1] = 3; }
        ////////                                    }
        ////////                                }
        ////////                            }
        ////////                            break;

        ////////                        default:
        ////////                            if (D[ic] >= 245)
        ////////                            {
        ////////                                if (D[ic - 1] >= 245)
        ////////                                { TypO[ic] = 1; }
        ////////                                else if (D[ic - 1] > 0 && D[ic - 1] < 245)
        ////////                                {
        ////////                                    if (D[ic - 2] > 0 && D[ic - 2] < 245)
        ////////                                    {
        ////////                                        if (D[ic - 3] > 0 && D[ic - 3] < 245)
        ////////                                        {
        ////////                                            TypO[ic] = 4; TypO[ic - 1] = 4; TypO[ic - 2] = 4; TypO[ic - 3] = 4;
        ////////                                        }
        ////////                                        else { TypO[ic] = 3; TypO[ic - 1] = 3; TypO[ic - 2] = 3; }
        ////////                                    }
        ////////                                    else { TypO[ic] = 2; TypO[ic - 1] = 2; }
        ////////                                }
        ////////                            }
        ////////                            else if (D[ic] >= 0 && D[ic] < 245)
        ////////                            {
        ////////                                if (D[ic - 1] >= 245)
        ////////                                {
        ////////                                    if (D[ic] == 0)
        ////////                                    { TypO[ic] = 1; TypO[ic - 1] = 1; break; }
        ////////                                    else
        ////////                                    { TypO[ic] = 2; }
        ////////                                }
        ////////                                else if (D[ic - 1] > 0 && D[ic - 1] < 245)
        ////////                                {
        ////////                                    if (D[ic - 2] > 0 && D[ic - 2] < 245)
        ////////                                    {
        ////////                                        if (D[ic - 3] > 0 && D[ic - 3] < 245)
        ////////                                        {
        ////////                                            if (D[ic] == 0)
        ////////                                            { TypO[ic] = 4; TypO[ic - 1] = 4; TypO[ic - 2] = 4; TypO[ic - 3] = 4; break; }
        ////////                                            else { TypO[ic] = 5; TypO[ic - 1] = 5; TypO[ic - 2] = 5; TypO[ic - 3] = 5; }
        ////////                                        }
        ////////                                        else
        ////////                                        {
        ////////                                            if (D[ic] == 0)
        ////////                                            { TypO[ic] = 3; TypO[ic - 1] = 3; TypO[ic - 2] = 3; break; }
        ////////                                            else { TypO[ic] = 4; TypO[ic - 1] = 4; TypO[ic - 2] = 4; }
        ////////                                        }
        ////////                                    }
        ////////                                    else
        ////////                                    {
        ////////                                        if (D[ic] == 0)
        ////////                                        { TypO[ic] = 2; TypO[ic - 1] = 2; break; }
        ////////                                        else { TypO[ic] = 3; TypO[ic - 1] = 3; }
        ////////                                    }
        ////////                                }
        ////////                                else
        ////////                                {
        ////////                                    if (D[ic] == 0)
        ////////                                    { TypO[ic] = 1; TypO[ic - 1] = 1; break; }

        ////////                                }
        ////////                            }
        ////////                            break;
        ////////                    }
        ////////                }

        ////////            }

        ////////            ADNagr = 0;
        ////////            RasstOs = 0;
        ////////            //DO = 0;
        ////////            TypeO = 0;

        ////////            TTS = 0;
        ////////            for (ic = KolOsR + 1; ic < 9; ic++)
        ////////            {
        ////////                D[ic] = 0;
        ////////                DoubO[ic] = 0;
        ////////                TypO[ic] = 0;
        ////////            }
        ////////            ADNagr = Convert.ToDouble(readerLPR["maxosnagr"].ToString()) / 1000;
        ////////            Cl = Convert.ToInt32(readerLPR["vehicle_class"].ToString());
        ////////            ObshMass = Convert.ToDouble(readerLPR["total_weight"].ToString());

        ////////            names2 = new string[KolOs];
        ////////            names1 = new string[KolOs];
        ////////            for (int KO = 1; KO <= KolOsR; KO++)
        ////////            {
        ////////                if (KO <= 8)
        ////////                {
        ////////                    D111[KO] = Convert.ToDouble(readerLPR["axles_" + KO + "_" + (KO + 1) + "_base"].ToString());
        ////////                    if (KO != KolOs)
        ////////                    {
        ////////                        names2[KO - 1] = Convert.ToString(Convert.ToDouble(readerLPR["axles_" + KO + "_" + (KO + 1) + "_base"].ToString()) / 100);
        ////////                    }
        ////////                }
        ////////            }
        ////////            D1_2 = Convert.ToDouble(readerLPR["axles_1_2_base"].ToString());
        ////////            D2_3 = Convert.ToDouble(readerLPR["axles_2_3_base"].ToString());
        ////////            D3_4 = Convert.ToDouble(readerLPR["axles_3_4_base"].ToString());
        ////////            D4_5 = Convert.ToDouble(readerLPR["axles_4_5_base"].ToString());
        ////////            D5_6 = Convert.ToDouble(readerLPR["axles_5_6_base"].ToString());
        ////////            D6_7 = Convert.ToDouble(readerLPR["axles_6_7_base"].ToString());
        ////////            D7_8 = Convert.ToDouble(readerLPR["axles_7_8_base"].ToString());
        ////////            DLINATS = Convert.ToDouble(readerLPR["length"].ToString());
        ////////            #endregion///////////////////////////////////////////// 
        ////////            PDK = new double[7, 10];
        ////////            PDKGR = new double[7, 10];
        ////////            KN = new int[2, 9];
        ////////            KNR = new int[2, 9];
        ////////            PDKO = new double[10];///PDK оси
        ////////            PDKTel = new double[10];///пдк тележки
        ////////            #region                   //////////////////////////      заполнение таблицы данными о ТС      ////////////////////////////
        ////////            if (Convert.ToInt32(readerLPR["axles_count"]) > 0)
        ////////            {
        ////////                GrO = 0;
        ////////                dataGridView1.RowCount = Convert.ToInt32(readerLPR["axles_count"]);
        ////////                for (ic = 0; ic < (Convert.ToInt32(readerLPR["axles_count"])); ic++)
        ////////                {
        ////////                    names1[ic] = Convert.ToString(Math.Round(Convert.ToDouble(readerLPR["o" + (ic + 1) + "m"]) / 1000, 3));
        ////////                    PDK[0, ic] = ic + 1;

        ////////                    dataGridView1[0, ic].Value = PDK[0, ic];
        ////////                    string Sk = Convert.ToInt32(readerLPR["dbl" + (ic + 1)]) + "/" + (Convert.ToInt32(readerLPR["dbl" + (ic + 1)])) * 2;
        ////////                    dataGridView1[2, ic].Value = Sk;

        ////////                    if (ic > 0)
        ////////                    {
        ////////                        if (Convert.ToDouble(readerLPR["base" + (ic) + "_" + (ic + 1)]) > 2.4)
        ////////                        {
        ////////                            GrO = GrO + 1;
        ////////                            PDK[1, ic] = GrO;
        ////////                            PDK[2, ic] = (Math.Round((Convert.ToDouble(readerLPR["o" + (ic + 1) + "m"]) - (Convert.ToDouble(readerLPR["o" + (ic + 1) + "m"]) / 100 * 5)) / 1000, 3));

        ////////                        }
        ////////                        else if (ic > 1 && Convert.ToDouble(readerLPR["base" + (ic - 1) + "_" + (ic)]) > 2.4)
        ////////                        {
        ////////                            KGr = KGr++;
        ////////                            PDK[1, ic - 1] = GrO;
        ////////                            PDK[1, ic] = GrO;
        ////////                            PDK[2, ic] = (Math.Round((Convert.ToDouble(readerLPR["o" + (ic + 1) + "m"]) - (Convert.ToDouble(readerLPR["o" + (ic + 1) + "m"]) / 100 * 5)) / 1000, 3));
        ////////                        }
        ////////                        else
        ////////                        {
        ////////                            KGr = KGr++;
        ////////                            PDK[1, ic - 1] = GrO;
        ////////                            PDK[1, ic] = GrO;
        ////////                            PDK[2, ic] = (Math.Round((Convert.ToDouble(readerLPR["o" + (ic + 1) + "m"]) - (Convert.ToDouble(readerLPR["o" + (ic + 1) + "m"]) / 100 * 5)) / 1000, 3));
        ////////                        }
        ////////                    }
        ////////                    else
        ////////                    {
        ////////                        GrO = GrO + 1;
        ////////                        PDK[1, ic] = GrO;
        ////////                        PDK[2, ic] = (Math.Round((Convert.ToDouble(readerLPR["o" + (ic + 1) + "m"]) - (Convert.ToDouble(readerLPR["o" + (ic + 1) + "m"]) / 100 * 5)) / 1000, 3));
        ////////                    }
        ////////                    if (Convert.ToDouble(PDK[4, ic]) < 0)
        ////////                    { PDK[4, ic] = 0; }
        ////////                }
        ////////            }
        ////////            #endregion  ////////////////////////////////////////////////////////////////////////////////////

        ////////            #region/////////////////////////////////////////            заполнение таблицы групп осей
        ////////            if (GrO > 0)
        ////////            {
        ////////                //int NOs = 1;
        ////////                KN[1, 0] = Convert.ToInt32(TypO[1]);
        ////////                KN[0, 0] = 1;
        ////////                ////////////////////////////////////////////////////////////////
        ////////                for (ic = 1; ic < GrO; ic++)
        ////////                {
        ////////                    Sk = "";
        ////////                    for (j = 0; j <= ic; j++)
        ////////                    {
        ////////                        Sk = Sk + Convert.ToString(KN[1, j]);
        ////////                    }
        ////////                    Sk = Sk + "1";
        ////////                    Fx = 0;
        ////////                    for (j = 0; j < Sk.Length; j++)
        ////////                    {
        ////////                        Fx = Fx + int.Parse(Convert.ToString(Sk[j]));
        ////////                    }
        ////////                    KN[1, ic] = Convert.ToInt32(TypO[Fx]);//Количество
        ////////                    KN[0, ic] = Fx; //Позиция                            
        ////////                }
        ////////                //////////////////////////////////////////////////////////////////
        ////////                /////////////////////////////////////////////       Заполняем первую строку ///////////////////////////////////////////////////
        ////////                if (KN[1, 0] == 1)
        ////////                {
        ////////                    PDKGR[0, 0] = 1;
        ////////                    PDKGR[1, 0] = TypO[1];
        ////////                    PDKGR[2, 0] = (Math.Round((Convert.ToDouble(readerLPR["o" + (1) + "m"]) - (Convert.ToDouble(readerLPR["o" + (1) + "m"]) / 100 * 5)) / 1000, 3));
        ////////                }
        ////////                else if (KN[1, 0] > 1)
        ////////                {
        ////////                    D4_5 = 0;
        ////////                    for (icC = 1; icC <= (KN[0, 0] - 1 + KN[1, 0]); icC++)//ic <= TypO[1]; ic++)
        ////////                    {
        ////////                        D4_5 = D4_5 + (Math.Round(Convert.ToDouble(readerLPR["o" + (icC) + "m"]) / 1000, 3));
        ////////                    }
        ////////                    PDKGR[0, 0] = 1;
        ////////                    PDKGR[1, 0] = KN[1, 0];//TypO[1];
        ////////                    PDKGR[2, 0] = (D4_5) - (D4_5 / 100 * 5);
        ////////                }
        ////////                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        ////////                //////////////////////// Заполняем строки таблицы больше чем первая

        ////////                for (ic = 1; ic < GrO; ic++)
        ////////                {
        ////////                    if (KN[1, ic] == 1)
        ////////                    {
        ////////                        PDKGR[0, ic] = ic + 1;
        ////////                        PDKGR[1, ic] = KN[1, ic]; //TypO[ic + 1];
        ////////                        PDKGR[2, ic] = (Math.Round((Convert.ToDouble(readerLPR["o" + (ic + 1) + "m"]) - (Convert.ToDouble(readerLPR["o" + (ic + 1) + "m"]) / 100 * 5)) / 1000, 3));
        ////////                    }
        ////////                    else if (KN[1, ic] > 1)
        ////////                    {
        ////////                        D1_2 = 0;
        ////////                        D2_3 = 0;
        ////////                        D3_4 = 0;
        ////////                        D4_5 = 0;
        ////////                        for (icC = KN[0, ic]; icC <= (KN[0, ic] - 1 + KN[1, ic]); icC++)
        ////////                        {
        ////////                            D4_5 = D4_5 + (Math.Round(Convert.ToDouble(readerLPR["o" + (icC) + "m"]) / 1000, 3));
        ////////                        }
        ////////                        PDKGR[0, ic] = ic + 1;
        ////////                        PDKGR[1, ic] = KN[1, ic];//TypO[KN[0, ic]];
        ////////                        PDKGR[2, ic] = (Math.Round(D4_5 - (Convert.ToDouble(D4_5) / 100 * 5), 3));
        ////////                    }
        ////////                }
        ////////                //////////////////////////////////////////////////////////////////////////
        ////////            }
        ////////            /////////////////////////////////////////////////// ПРОБА ЗАПОЛНЕНИЯ ТИПОСХЕМЫ К (ЛЕВАЯ) ////////////////////////////
        ////////            if (GrO > 0)
        ////////            {
        ////////                alphaBlendTextBox38.Text = KolOsR + " (" + KN[1, 0]; // readerL["axles_count"].ToString() + " (" + Convert.ToString(TypO[1]);
        ////////                for (ic = 1; ic < GrO; ic++)
        ////////                {
        ////////                    alphaBlendTextBox38.Text = alphaBlendTextBox38.Text + "+" + KN[1, ic];
        ////////                }
        ////////                alphaBlendTextBox38.Text = alphaBlendTextBox38.Text + ")";
        ////////            }
        ////////            //////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////            /////////////////////////////////////////////////////////////////////////////////////////////////////////////// ПДК

        ////////            #endregion                  ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////            alphaBlendTextBox9.Text = readerLPR["datepr"].ToString();
        ////////            alphaBlendTextBox6.Text = readerLPR["timepr"].ToString();
        ////////            alphaBlendTextBox8.Text = readerLPR["namead"].ToString();
        ////////            alphaBlendTextBox7.Text = readerLPR["namenapr"].ToString();
        ////////            alphaBlendTextBox5.Text = readerLPR["partad"].ToString();
        ////////            alphaBlendTextBox3.Text = readerLPR["nameapvk"].ToString();
        ////////            //alphaBlendTextBox38.Text = readerLPR["car_layout"].ToString();
        ////////            //label73.Text = readerL["nameapvk"].ToString() + ", " + readerL["dislocationapvk"].ToString();
        ////////            alphaBlendTextBox2.Text = readerLPR["npolos"].ToString();
        ////////            //label141.Text = readerL["n1"].ToString();
        ////////            //label140.Text = readerL["n2"].ToString();
        ////////            //label139.Text = readerL["n3"].ToString();
        ////////            //label138.Text = readerL["n4"].ToString();
        ////////            //label135.Text = readerL["n5"].ToString();
        ////////            //label133.Text = readerL["n6"].ToString();
        ////////            //label127.Text = readerL["n7"].ToString();
        ////////            //label137.Text = readerL["n8"].ToString();
        ////////            //label131.Text = readerL["n9"].ToString();
        ////////            //label162.Text = Convert.ToString(Convert.ToDouble(readerL["base1_2"].ToString())); label161.Text = Convert.ToString(Convert.ToDouble(readerL["base2_3"].ToString())); label160.Text = Convert.ToString(Convert.ToDouble(readerL["base3_4"].ToString())); label159.Text = Convert.ToString(Convert.ToDouble(readerL["base4_5"].ToString()));
        ////////            //label158.Text = Convert.ToString(Convert.ToDouble(readerL["base5_6"].ToString())); label157.Text = Convert.ToString(Convert.ToDouble(readerL["base6_7"].ToString())); label156.Text = Convert.ToString(Convert.ToDouble(readerL["base7_8"].ToString())); label155.Text = Convert.ToString(Convert.ToDouble(readerL["base8_9"].ToString()));

        ////////            //label153.Text = readerL["dbl1"].ToString(); label152.Text = readerL["dbl2"].ToString(); label151.Text = readerL["dbl3"].ToString(); label150.Text = readerL["dbl4"].ToString();
        ////////            //label149.Text = readerL["dbl5"].ToString(); label148.Text = readerL["dbl6"].ToString(); label147.Text = readerL["dbl7"].ToString(); label146.Text = readerL["dbl8"].ToString();
        ////////            //label145.Text = readerL["dbl9"].ToString();
        ////////            label39.Text = readerLPR["total_weight"].ToString();
        ////////            //label154.Text = Convert.ToString(Convert.ToDouble(readerL["base1_n"].ToString()));
        ////////            //label171.Text = Convert.ToString(Math.Round(Convert.ToDouble(Convert.ToDouble(readerL["o1m"].ToString()) / 1000), 2)); label170.Text = Convert.ToString(Math.Round(Convert.ToDouble(Convert.ToDouble(readerL["o2m"].ToString()) / 1000), 2)); label169.Text = Convert.ToString(Math.Round(Convert.ToDouble(Convert.ToDouble(readerL["o3m"].ToString()) / 1000), 2)); label168.Text = Convert.ToString(Math.Round(Convert.ToDouble(Convert.ToDouble(readerL["o4m"].ToString()) / 1000), 2));
        ////////            //label167.Text = Convert.ToString(Math.Round(Convert.ToDouble(Convert.ToDouble(readerL["o5m"].ToString()) / 1000), 2)); label166.Text = Convert.ToString(Math.Round(Convert.ToDouble(Convert.ToDouble(readerL["o6m"].ToString()) / 1000), 2)); label165.Text = Convert.ToString(Math.Round(Convert.ToDouble(Convert.ToDouble(readerL["o7m"].ToString()) / 1000), 2)); label164.Text = Convert.ToString(Math.Round(Convert.ToDouble(Convert.ToDouble(readerL["o8m"].ToString()) / 1000), 2));
        ////////            //label163.Text = Convert.ToString(Math.Round(Convert.ToDouble(Convert.ToDouble(readerL["o9m"].ToString()) / 1000), 2));
        ////////        }

        ////////        readerLPR.Close();
        ////////    }
        ////////    catch (MySqlException ex)
        ////////    {
        ////////        Console.WriteLine("Error: \r\n{0}", ex.ToString());
        ////////    }
        ////////    finally
        ////////    {
        ////////        commandLPR.Connection.Close();
        ////////    }
        ////////    //////          ////////////////////////////////////////////////////// Запрос класса ТС (левый)   //////////////////////////
        ////////    ZKLR();
        ////////    ////////////////////////////////////////////////////// Запрос ПДК Общ массы
        ////////    ZObPDKR();

        ////////    ///////////////////////////////////////////////////////////////////////////////////////////////////////// ПДК
        ////////    ZOsPDKR();
        ////////    for (ic = 0; ic < (KolOsR); ic++) //Convert.ToInt32(alphaBlendTextBox13.Text)); ic++)
        ////////    {
        ////////        if (PDKO[ic + 1] != 0)
        ////////        {
        ////////            PDK[3, ic] = PDKO[ic + 1];
        ////////            if (Math.Round(Convert.ToDouble(PDK[2, ic]) / (PDKO[ic + 1] / 100) - 100, 2) > 0)
        ////////            {
        ////////                PDK[5, ic] = Math.Round(Convert.ToDouble(PDK[2, ic]) / (PDKO[ic + 1] / 100) - 100, 2);
        ////////                PDK[4, ic] = Math.Round(Convert.ToDouble(PDK[2, ic]) - PDKO[ic + 1], 2);
        ////////            }
        ////////            else
        ////////            {
        ////////                PDK[4, ic] = 0;
        ////////                PDK[5, ic] = 0;
        ////////            }
        ////////        }
        ////////        else
        ////////        {
        ////////            PDK[3, ic] = PDKTel[ic + 1] / Convert.ToInt32(TypO[ic + 1]);
        ////////            if (Math.Round(Convert.ToDouble(PDK[2, ic]) / (Convert.ToDouble(PDK[3, ic]) / 100) - 100, 2) > 0)
        ////////            {
        ////////                PDK[5, ic] = Math.Round(Convert.ToDouble(PDK[2, ic]) / (Convert.ToDouble(PDK[3, ic]) / 100) - 100, 2);
        ////////                PDK[4, ic] = Math.Round(Convert.ToDouble(PDK[2, ic]) - Convert.ToDouble(PDK[3, ic]), 2);
        ////////            }
        ////////            else
        ////////            {
        ////////                PDK[4, ic] = 0;
        ////////                PDK[5, ic] = 0;
        ////////            }
        ////////        }
        ////////    }

        ////////    #region //////////////////////////////////////////////////////////////// заполняем ПДК по тележкам и превышения (левая)    ////////////////////////////////
        ////////    KNR[1, 0] = Convert.ToInt32(TypO[1]);
        ////////    KNR[0, 0] = 1;
        ////////    ///////////////////////////////////////////       Заполняем первую строку ///////////////////////////////////////////////////
        ////////    if (KNR[1, 0] == 1)
        ////////    {
        ////////        PDKGR[3, 0] = PDKO[1];
        ////////        if (Math.Round(PDKGR[2, 0] / (PDKGR[3, 0] / 100) - 100, 2) > 0)
        ////////        {
        ////////            PDKGR[5, 0] = Math.Round(Convert.ToDouble(PDKGR[2, 0]) / (PDKGR[3, 0] / 100) - 100, 2);
        ////////            PDKGR[4, 0] = Math.Round(Convert.ToDouble(PDKGR[2, 0]) - PDKGR[3, 0], 2);
        ////////        }
        ////////        else
        ////////        {
        ////////            PDKGR[5, 0] = 0;
        ////////            PDKGR[4, 0] = 0;
        ////////        }
        ////////    }
        ////////    else if (KNR[1, 0] > 1)
        ////////    {
        ////////        for (icC = 1; icC <= TypO[1]; icC++)
        ////////        {
        ////////            D1_2 = D1_2 + PDKTel[icC];
        ////////        }
        ////////        PDKGR[3, 0] = D1_2 / icC; ;
        ////////        if (Math.Round(PDKGR[2, 0] / (PDKGR[3, 0] / 100) - 100, 2) > 0)
        ////////        {
        ////////            PDKGR[5, 0] = Math.Round(Convert.ToDouble(PDKGR[2, 0]) / (PDKGR[3, 0] / 100) - 100, 2);
        ////////            PDKGR[4, 0] = Math.Round(Convert.ToDouble(PDKGR[2, 0]) - PDKGR[3, 0], 2);
        ////////        }
        ////////        else
        ////////        {
        ////////            PDKGR[5, 0] = 0;
        ////////            PDKGR[4, 0] = 0;
        ////////        }
        ////////    }
        ////////    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////    ////////////////////// Заполняем строки таблицы больше чем первая
        ////////    for (ic = 1; ic < GrO; ic++)
        ////////    {
        ////////        Sk = "";
        ////////        for (j = 0; j <= ic; j++)
        ////////        {
        ////////            Sk = Sk + Convert.ToString(KNR[1, j]);
        ////////        }
        ////////        Sk = Sk + "1";
        ////////        Fx = 0;
        ////////        for (j = 0; j < Sk.Length; j++)
        ////////        {
        ////////            Fx = Fx + int.Parse(Convert.ToString(Sk[j]));
        ////////        }
        ////////        KNR[1, ic] = Convert.ToInt32(TypO[Fx]);//Количество
        ////////        KNR[0, ic] = Fx; //Позиция
        ////////    }
        ////////    ////////////////////////////////////////////////////////////////////
        ////////    for (ic = 1; ic < GrO; ic++)
        ////////    {
        ////////        if (KNR[1, ic] == 1)
        ////////        {
        ////////            PDKGR[3, ic] = PDKO[KN[0, ic]];///ic + 1];
        ////////            if (Math.Round(PDKGR[2, ic] / (PDKGR[3, ic] / 100) - 100, 2) > 0)
        ////////            {
        ////////                PDKGR[5, ic] = Math.Round(Convert.ToDouble(PDKGR[2, ic]) / (PDKGR[3, ic] / 100) - 100, 2);
        ////////                PDKGR[4, ic] = Math.Round(Convert.ToDouble(PDKGR[2, ic]) - PDKGR[3, ic], 2);
        ////////            }
        ////////            else
        ////////            {
        ////////                PDKGR[5, ic] = 0;
        ////////                PDKGR[4, ic] = 0;
        ////////            }
        ////////        }
        ////////        else if (KNR[1, ic] > 1 && KNR[1, ic] < 4)
        ////////        {
        ////////            D1_2 = 0;

        ////////            for (icC = KNR[0, ic]; icC < (KNR[0, ic] - 1 + KNR[1, ic]); icC++)
        ////////            {
        ////////                D1_2 = PDKTel[icC + 1];
        ////////            }
        ////////            PDKGR[3, ic] = D1_2;
        ////////            if (Math.Round(PDKGR[2, ic] / (PDKGR[3, ic] / 100) - 100, 2) > 0)
        ////////            {
        ////////                PDKGR[5, ic] = Math.Round(Convert.ToDouble(PDKGR[2, ic]) / (PDKGR[3, ic] / 100) - 100, 2);
        ////////                PDKGR[4, ic] = Math.Round(Convert.ToDouble(PDKGR[2, ic]) - PDKGR[3, ic], 2);
        ////////            }
        ////////            else
        ////////            {
        ////////                PDKGR[5, ic] = 0;
        ////////                PDKGR[4, ic] = 0;
        ////////            }
        ////////        }
        ////////        else if (KNR[1, ic] > 3)
        ////////        {

        ////////            PDKGR[3, ic] = PDKO[KN[0, ic]] * Convert.ToInt32(TypO[KN[0, ic]]);
        ////////            if (Math.Round(PDKGR[2, ic] / (PDKGR[3, ic] / 100) - 100, 2) > 0)
        ////////            {
        ////////                PDKGR[5, ic] = Math.Round(Convert.ToDouble(PDKGR[2, ic]) / (PDKGR[3, ic] / 100) - 100, 2);
        ////////                PDKGR[4, ic] = Math.Round(Convert.ToDouble(PDKGR[2, ic]) - PDKGR[3, ic], 2);
        ////////            }
        ////////            else
        ////////            {
        ////////                PDKGR[5, ic] = 0;
        ////////                PDKGR[4, ic] = 0;
        ////////            }
        ////////        }
        ////////        ////////////////////////////////////////////////////////////////////////
        ////////    }
        ////////    #endregion //////////////////////////

        ////////    #region ///////////////////////////////////////////////////////// заполняем ячейки перевеса - какая ось и на сколько ////////////////////////
        ////////    alphaBlendTextBox39.Text = "";
        ////////    NarOsM = 0;
        ////////    NarOs = "";
        ////////    NarGRM = 0;
        ////////    for (ic = 0; ic < KolOsR; ic++)
        ////////    {
        ////////        NarOsM = NarOsM + PDK[4, ic];
        ////////        NarGRM = NarGRM + PDKGR[4, ic];
        ////////    }
        ////////    if (NarOsM > 0)
        ////////    {
        ////////        NarOs = NarObMS + " Превышения по осевым нагрузкам: ";
        ////////        for (ic = 0; ic < KolOsR; ic++)
        ////////        {
        ////////            if (PDK[4, ic] > 0)
        ////////            {
        ////////                NarOs = NarOs + " ось " + PDK[0, ic] + " - " + PDK[4, ic] + "т. (" + PDK[5, ic] + "%); ";
        ////////                alphaBlendTextBox39.Text = "Имеется перевес";
        ////////            }
        ////////        }
        ////////        if (NarGRM > 0)
        ////////        {
        ////////            string PRGR = "";
        ////////            for (ic = 0; ic < KolOsR; ic++)
        ////////            {
        ////////                if (PDKGR[4, ic] > 0 && PDKGR[1, ic] > 1)
        ////////                {
        ////////                    PRGR = " Превышения по группам осей: ";
        ////////                }
        ////////            }
        ////////            NarOs = NarOs + PRGR;// " Превышения по группам осей: ";
        ////////            for (ic = 0; ic < KolOsR; ic++)
        ////////            {
        ////////                if (PDKGR[4, ic] > 0 && PDKGR[1, ic] > 1)
        ////////                {
        ////////                    NarOs = NarOs + " гр. " + PDKGR[0, ic] + " - " + PDKGR[4, ic] + "т. (" + PDKGR[5, ic] + "%); ";
        ////////                }
        ////////            }
        ////////        }
        ////////    }
        ////////    else
        ////////    {
        ////////        if (NarGRM > 0)
        ////////        {
        ////////            NarOs = NarObMS + " Превышения по группам осей: ";
        ////////            for (ic = 0; ic < KolOsR; ic++)
        ////////            {
        ////////                if (PDKGR[4, ic] > 0 && PDKGR[1, ic] > 1)
        ////////                {
        ////////                    NarOs = NarOs + " гр. " + PDKGR[0, ic] + " - " + PDKGR[4, ic] + "т. (" + PDKGR[5, ic] + "%); ";
        ////////                    alphaBlendTextBox39.Text = alphaBlendTextBox28.Text + "Имеется перевес";
        ////////                }
        ////////            }
        ////////        }
        ////////        else
        ////////        {
        ////////            alphaBlendTextBox39.Text = "Нет ";
        ////////        }
        ////////    }

        ////////    ///////////////////////////////////////////////////////////  проход по рисункам  //////////////////////////
        ////////    for (ic = 0; ic < KolOsR; ic++)
        ////////    {
        ////////        switch (ic)
        ////////        {
        ////////            //////////////////////////////////////////////////////// 1 Ось ////////////////////////////////////////////
        ////////            case 0:
        ////////                if (PDK[4, ic] <= 0)
        ////////                {
        ////////                    if ((label195.Text != "") && (Convert.ToInt32(label195.Text) > 1))
        ////////                    { pictureBox44.Image = AVGK.Properties.Resources._33777Ч2; }
        ////////                    else if ((label195.Text != ""))
        ////////                    { pictureBox44.Image = AVGK.Properties.Resources._33777Ч1; }
        ////////                }
        ////////                else if (PDK[4, ic] > 0)
        ////////                {
        ////////                    if ((label195.Text != "") && (Convert.ToInt32(label195.Text) > 1))
        ////////                    { pictureBox44.Image = AVGK.Properties.Resources._33777К2; }
        ////////                    else if ((label195.Text != ""))
        ////////                    { pictureBox44.Image = AVGK.Properties.Resources._33777К1; }
        ////////                }
        ////////                break;
        ////////            ///////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////            //////////////////////////////////////////////////////// 2 Ось ////////////////////////////////////////////
        ////////            case 1:
        ////////                if (PDK[4, ic] <= 0)
        ////////                {
        ////////                    if ((label194.Text != "") && (Convert.ToInt32(label194.Text) > 0))
        ////////                    { pictureBox45.Image = AVGK.Properties.Resources._33777Ч2; }
        ////////                    else if ((label194.Text != ""))
        ////////                    { pictureBox45.Image = AVGK.Properties.Resources._33777Ч1; }
        ////////                }
        ////////                else if (PDK[4, ic] > 0)
        ////////                {
        ////////                    if ((label194.Text != "") && (Convert.ToInt32(label194.Text) > 0))
        ////////                    { pictureBox45.Image = AVGK.Properties.Resources._33777К2; }
        ////////                    else if ((label194.Text != ""))
        ////////                    { pictureBox45.Image = AVGK.Properties.Resources._33777К1; }
        ////////                }
        ////////                break;
        ////////            ///////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////            //////////////////////////////////////////////////////// 3 Ось ////////////////////////////////////////////
        ////////            case 2:
        ////////                if (PDK[4, ic] <= 0)
        ////////                {
        ////////                    if ((label193.Text != "") && (Convert.ToInt32(label193.Text) > 1))
        ////////                    { pictureBox46.Image = AVGK.Properties.Resources._33777Ч2; }
        ////////                    else if (label193.Text != "")
        ////////                    { pictureBox46.Image = AVGK.Properties.Resources._33777Ч1; }
        ////////                }
        ////////                else if (PDK[4, ic] > 0)
        ////////                {
        ////////                    if ((label193.Text != "") && (Convert.ToInt32(label193.Text) > 1))
        ////////                    { pictureBox46.Image = AVGK.Properties.Resources._33777К2; }
        ////////                    else if (label193.Text != "")
        ////////                    { pictureBox46.Image = AVGK.Properties.Resources._33777К1; }
        ////////                }
        ////////                break;
        ////////            ///////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////            //////////////////////////////////////////////////////// 4 Ось ////////////////////////////////////////////
        ////////            case 3:
        ////////                if (PDK[4, ic] <= 0)
        ////////                {
        ////////                    if ((label192.Text != "") && (Convert.ToInt32(label192.Text) > 0))
        ////////                    { pictureBox47.Image = AVGK.Properties.Resources._33777Ч2; }
        ////////                    else if ((label192.Text != ""))
        ////////                    { pictureBox47.Image = AVGK.Properties.Resources._33777Ч1; }
        ////////                }
        ////////                else if (PDK[4, ic] > 0)
        ////////                {
        ////////                    if ((label192.Text != "") && (Convert.ToInt32(label192.Text) > 0))
        ////////                    { pictureBox47.Image = AVGK.Properties.Resources._33777К2; }
        ////////                    else if ((label192.Text != ""))
        ////////                    { pictureBox47.Image = AVGK.Properties.Resources._33777К1; }
        ////////                }
        ////////                break;
        ////////            ///////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////            //////////////////////////////////////////////////////// 5 Ось ////////////////////////////////////////////
        ////////            case 4:
        ////////                if (PDK[4, ic] <= 0)
        ////////                {
        ////////                    if ((label191.Text != "") && (Convert.ToInt32(label191.Text) > 0))
        ////////                    { pictureBox48.Image = AVGK.Properties.Resources._33777Ч2; }
        ////////                    else if ((label191.Text != ""))
        ////////                    { pictureBox48.Image = AVGK.Properties.Resources._33777Ч1; }
        ////////                }
        ////////                else if (PDK[4, ic] > 0)
        ////////                {
        ////////                    if ((label191.Text != "") && (Convert.ToInt32(label191.Text) > 0))
        ////////                    { pictureBox48.Image = AVGK.Properties.Resources._33777К2; }
        ////////                    else if ((label191.Text != ""))
        ////////                    { pictureBox48.Image = AVGK.Properties.Resources._33777К1; }
        ////////                }
        ////////                break;
        ////////            ///////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////            //////////////////////////////////////////////////////// 6 Ось ////////////////////////////////////////////
        ////////            case 5:
        ////////                if (PDK[4, ic] <= 0)
        ////////                {
        ////////                    if ((label190.Text != "") && (Convert.ToInt32(label190.Text) > 0))
        ////////                    { pictureBox49.Image = AVGK.Properties.Resources._33777Ч2; }
        ////////                    else if ((label190.Text != ""))
        ////////                    { pictureBox49.Image = AVGK.Properties.Resources._33777Ч1; }
        ////////                }
        ////////                else if (PDK[4, ic] > 0)
        ////////                {
        ////////                    if ((label190.Text != "") && (Convert.ToInt32(label190.Text) > 0))
        ////////                    { pictureBox49.Image = AVGK.Properties.Resources._33777К2; }
        ////////                    else if ((label190.Text != ""))
        ////////                    { pictureBox49.Image = AVGK.Properties.Resources._33777К1; }
        ////////                }
        ////////                break;
        ////////            ///////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////            //////////////////////////////////////////////////////// 7 Ось ////////////////////////////////////////////
        ////////            case 6:
        ////////                if (PDK[4, ic] <= 0)
        ////////                {
        ////////                    if ((label189.Text != "") && (Convert.ToInt32(label189.Text) > 0))
        ////////                    { pictureBox50.Image = AVGK.Properties.Resources._33777Ч2; }
        ////////                    else if ((label189.Text != ""))
        ////////                    { pictureBox50.Image = AVGK.Properties.Resources._33777Ч1; }
        ////////                }
        ////////                else if (PDK[4, ic] > 0)
        ////////                {
        ////////                    if ((label189.Text != "") && (Convert.ToInt32(label189.Text) > 0))
        ////////                    { pictureBox50.Image = AVGK.Properties.Resources._33777К2; }
        ////////                    else if ((label189.Text != ""))
        ////////                    { pictureBox50.Image = AVGK.Properties.Resources._33777К1; }
        ////////                }
        ////////                break;
        ////////            ///////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////            //////////////////////////////////////////////////////// 8 Ось ////////////////////////////////////////////
        ////////            case 7:
        ////////                if (PDK[4, ic] <= 0)
        ////////                {
        ////////                    if ((label188.Text != "") && (Convert.ToInt32(label188.Text) > 0))
        ////////                    { pictureBox51.Image = AVGK.Properties.Resources._33777Ч2; }
        ////////                    else if ((label188.Text != ""))
        ////////                    { pictureBox51.Image = AVGK.Properties.Resources._33777Ч1; }
        ////////                }
        ////////                else if (PDK[4, ic] > 0)
        ////////                {
        ////////                    if ((label188.Text != "") && (Convert.ToInt32(label188.Text) > 0))
        ////////                    { pictureBox51.Image = AVGK.Properties.Resources._33777К2; }
        ////////                    else if ((label188.Text != ""))
        ////////                    { pictureBox51.Image = AVGK.Properties.Resources._33777К1; }
        ////////                }
        ////////                break;
        ////////            ///////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////            //////////////////////////////////////////////////////// 9 Ось ////////////////////////////////////////////
        ////////            case 8:
        ////////                if (PDK[4, ic] <= 0)
        ////////                {
        ////////                    if ((label187.Text != "") && (Convert.ToInt32(label187.Text) > 0))
        ////////                    { pictureBox52.Image = AVGK.Properties.Resources._33777Ч2; }
        ////////                    else if ((label187.Text != ""))
        ////////                    { pictureBox52.Image = AVGK.Properties.Resources._33777Ч1; }
        ////////                }
        ////////                else if (PDK[4, ic] <= 0)
        ////////                {
        ////////                    if ((label187.Text != "") && (Convert.ToInt32(label187.Text) > 0))
        ////////                    { pictureBox52.Image = AVGK.Properties.Resources._33777К2; }
        ////////                    else if ((label187.Text != ""))
        ////////                    { pictureBox52.Image = AVGK.Properties.Resources._33777К1; }
        ////////                }
        ////////                break;
        ////////                ///////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////        }
        ////////    }
        ////////    #endregion ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////    //////alphaBlendTextBox13.Text = alphaBlendTextBox13.Text + ")";
        ////////    #region /////////////////////////////////////////////////////////////// Запрос ПДК Габаритов
        ////////    //ZGabarPDKL();
        ////////    label124.Text = "";
        ////////    if (NarOb != "" || NarOs != "")
        ////////    {
        ////////        label124.Text = NarOb + NarOs;
        ////////        //if (NarObMS != "")
        ////////        //{
        ////////        //    label83.Text = NarOb + NarOs;
        ////////        //}
        ////////        //else
        ////////        //{
        ////////        //    label83.Text = NarOb;
        ////////        //}
        ////////    }
        ////////    else
        ////////    {
        ////////        label124.Text = "Не выявлено";
        ////////    }
        ////////}
        ////////#endregion///////////////////////////////////////////// 

        ////////#region/////////////////////////////////////////////   Общ.масса запрос ПДК R
        ////////public void ZObPDKR()
        ////////{

        ////////    MySqlCommand command2 = new MySqlCommand();
        ////////    ConnectStr conStr2 = new ConnectStr();
        ////////    conStr2.ConStr(1);
        ////////    Zapros zapros2 = new Zapros();
        ////////    string connectionString2;//, commandString;
        ////////    connectionString2 = conStr2.StP;//"Data source=localhost;UserId=root;Password=1q2w3e$R;database=camloc;";
        ////////    MySqlConnection connection2 = new MySqlConnection(connectionString2);
        ////////    zapros2.PDObshMass(KolOsR, TTS);
        ////////    string z2 = zapros2.commandStringTest;
        ////////    command2.CommandText = z2;
        ////////    command2.Connection = connection2;
        ////////    MySqlDataReader reader2;
        ////////    try
        ////////    {
        ////////        command2.Connection.Open();
        ////////        reader2 = command2.ExecuteReader();
        ////////        while (reader2.Read())
        ////////        {
        ////////            double Mo = 0;
        ////////            //alphaBlendTextBox22.Text = Convert.ToString(Math.Round(ObshMass / 1000, 2));
        ////////            Mo = (Math.Round(ObshMass / 1000, 2)) - (Math.Round(ObshMass / 1000, 2) / 100 * 5);
        ////////            //alphaBlendTextBox24.Text = Convert.ToString(Math.Round(Convert.ToDouble(reader2["pdmassts"].ToString()), 2));
        ////////            //if (Math.Round(Mo, 2) <= Convert.ToDouble(alphaBlendTextBox24.Text))
        ////////            //{
        ////////            //    NarObMS = "";
        ////////            //    // label86.Text = "";
        ////////            //    //alphaBlendTextBox28.Text = "Не превышено";
        ////////            //    //alphaBlendTextBox23.Text = "Не превышено";
        ////////            //}
        ////////            //else if (Convert.ToDouble(alphaBlendTextBox24.Text) < Math.Round(Mo, 2))
        ////////            //{
        ////////            //    NarObMS = "Превышение общей массы ТС на " + NarObM + "т.(" + NarObMPr + "%). ";
        ////////            //    //NarOb = NarOb + "Превышение общей массы ТС на " + NarObM + "т.(" + NarObMPr + "%). ";
        ////////            //    //label86.Text = label86.Text + "Превышение общей массы ТС";
        ////////            //    NarObM = Math.Round(Mo, 2) - Convert.ToDouble(alphaBlendTextBox24.Text);
        ////////            //    NarObMPr = Math.Round((Math.Round(Mo, 2) / (Convert.ToDouble(alphaBlendTextBox24.Text) / 100)), 2) - 100;
        ////////            //    //label46.Visible = true;
        ////////            //    //label45.Visible = true;
        ////////            //}
        ////////        }
        ////////        reader2.Close();
        ////////    }
        ////////    catch (MySqlException ex)
        ////////    {
        ////////        Console.WriteLine("Error: \r\n{0}", ex.ToString());
        ////////    }
        ////////    finally
        ////////    {
        ////////        command2.Connection.Close();
        ////////    }
        ////////}
        ////////#endregion///////////////////////////////////////////// 
        ////////#region/////////////////////////////////////////////   Габариты запрос ПДК R
        ////////public void ZGabarPDKR()
        ////////{
        ////////    //alphaBlendTextBox42.Text = Convert.ToString(Math.Round(DLINATS / 10, 2));
        ////////    //alphaBlendTextBox37.Text = Convert.ToString((Math.Round(DLINATS / 10, 2)) - 0.6);//длина
        ////////    //if (TTS == 1) { alphaBlendTextBox41.Text = Convert.ToString(12.00); }
        ////////    //else if (TTS == 2) { alphaBlendTextBox41.Text = Convert.ToString(20.00); }
        ////////    ////////alphaBlendTextBox45.Text = Convert.ToString(Math.Round(DLINATS / 100, 2));
        ////////    ////////alphaBlendTextBox43.Text = Convert.ToString((Math.Round(DLINATS / 100, 2)) - 0.1);//ширина
        ////////    //alphaBlendTextBox45.Text = Convert.ToString(0.00);
        ////////    //alphaBlendTextBox43.Text = Convert.ToString(0.00);
        ////////    //alphaBlendTextBox44.Text = Convert.ToString(2.60);

        ////////    ////////alphaBlendTextBox48.Text = Convert.ToString(Math.Round(DLINATS / 100, 2));
        ////////    ////////alphaBlendTextBox46.Text = Convert.ToString((Math.Round(DLINATS / 100, 2)) - 0.06);//высота
        ////////    //alphaBlendTextBox48.Text = Convert.ToString(0.00);
        ////////    //alphaBlendTextBox46.Text = Convert.ToString(0.00);
        ////////    //alphaBlendTextBox47.Text = Convert.ToString(4.00);
        ////////    //alphaBlendTextBox38.Text = "Не проверялось";
        ////////    ////if (Convert.ToDouble(alphaBlendTextBox36.Text) <= Convert.ToDouble(alphaBlendTextBox23.Text))
        ////////    ////////////{ alphaBlendTextBox38.Text = "Не проверялось"; }
        ////////    ////////////else if (Convert.ToDouble(alphaBlendTextBox36.Text) > Convert.ToDouble(alphaBlendTextBox23.Text))
        ////////    ////////////{
        ////////    ////////////    alphaBlendTextBox28.Text = "Превышение";
        ////////    ////////////    alphaBlendTextBox27.Text = Convert.ToString(Convert.ToDouble(alphaBlendTextBox36.Text) - Convert.ToDouble(alphaBlendTextBox23.Text));
        ////////    ////////////    alphaBlendTextBox24.Text = Convert.ToString(Convert.ToDouble(alphaBlendTextBox36.Text) / (Convert.ToDouble(alphaBlendTextBox23.Text) / 100));
        ////////    ////////////    label46.Visible = true;
        ////////    ////////////    label45.Visible = true;
        ////////    ////////////}


        ////////    //MySqlCommand command2 = new MySqlCommand();
        ////////    //ConnectStr conStr2 = new ConnectStr();
        ////////    //conStr2.ConStr(1);
        ////////    //Zapros zapros2 = new Zapros();
        ////////    //string connectionString2;//, commandString;
        ////////    //connectionString2 = conStr2.StP;//"Data source=localhost;UserId=root;Password=1q2w3e$R;database=camloc;";
        ////////    //MySqlConnection connection2 = new MySqlConnection(connectionString2);
        ////////    //zapros2.PDObshMass(KolOs, TTS);
        ////////    //string z2 = zapros2.commandStringTest;
        ////////    //command2.CommandText = z2;
        ////////    //command2.Connection = connection2;
        ////////    //MySqlDataReader reader2;
        ////////    //try
        ////////    //{
        ////////    //    command2.Connection.Open();
        ////////    //    reader2 = command2.ExecuteReader();
        ////////    //    while (reader2.Read())
        ////////    //    {
        ////////    //        alphaBlendTextBox22.Text = Convert.ToString(Math.Round(ObshMass / 1000, 2));
        ////////    //        alphaBlendTextBox36.Text = Convert.ToString((Math.Round(ObshMass / 1000, 2)) - (Math.Round(ObshMass / 1000, 2) / 100 * 5));
        ////////    //        alphaBlendTextBox23.Text = Convert.ToString(Math.Round(Convert.ToDouble(reader2["pdmassts"].ToString()), 2));
        ////////    //        if (Convert.ToDouble(alphaBlendTextBox36.Text) <= Convert.ToDouble(alphaBlendTextBox23.Text))
        ////////    //        { alphaBlendTextBox28.Text = "Не превышено"; }
        ////////    //        else if (Convert.ToDouble(alphaBlendTextBox36.Text) > Convert.ToDouble(alphaBlendTextBox23.Text))
        ////////    //        {
        ////////    //            alphaBlendTextBox28.Text = "Превышение";
        ////////    //            alphaBlendTextBox27.Text = Convert.ToString(Convert.ToDouble(alphaBlendTextBox36.Text) - Convert.ToDouble(alphaBlendTextBox23.Text));
        ////////    //            alphaBlendTextBox24.Text = Convert.ToString(Convert.ToDouble(alphaBlendTextBox36.Text) / (Convert.ToDouble(alphaBlendTextBox23.Text) / 100));
        ////////    //            label46.Visible = true;
        ////////    //            label45.Visible = true;
        ////////    //        }
        ////////    //    }
        ////////    //    reader2.Close();
        ////////    //}
        ////////    //catch (MySqlException ex)
        ////////    //{
        ////////    //    Console.WriteLine("Error: \r\n{0}", ex.ToString());
        ////////    //}
        ////////    //finally
        ////////    //{
        ////////    //    command2.Connection.Close();
        ////////    //}
        ////////}
        ////////#endregion///////////////////////////////////////////// 
        ////////#region/////////////////////////////////////////////   Осевая масса запрос ПДК R
        ////////public void ZOsPDKR()
        ////////{
        ////////    for (ic = 1; ic < KolOsR + 1; ic++)
        ////////    {
        ////////        if (ic <= 9)
        ////////        {
        ////////            MySqlCommand command2 = new MySqlCommand();
        ////////            ConnectStr conStr2 = new ConnectStr();
        ////////            conStr2.ConStr(1);
        ////////            Zapros zapros2 = new Zapros();
        ////////            string connectionString2;//, commandString;
        ////////            connectionString2 = conStr2.StP;//"Data source=localhost;UserId=root;Password=1q2w3e$R;database=camloc;";
        ////////            MySqlConnection connection2 = new MySqlConnection(connectionString2);
        ////////            if (D[ic] > 0)
        ////////            {
        ////////                if (Convert.ToInt32(TypO[ic]) > 1 && D[ic - 1] == 0)
        ////////                {
        ////////                    zapros2.PDOsNagr(Convert.ToInt32(DoubO[ic]), Convert.ToInt32(TypO[ic]), ADNagr, D[ic]);

        ////////                }
        ////////                else if (Convert.ToInt32(TypO[ic]) > 1 && D[ic - 1] <= D[ic])
        ////////                {
        ////////                    zapros2.PDOsNagr(Convert.ToInt32(DoubO[ic]), Convert.ToInt32(TypO[ic]), ADNagr, D[ic - 1]);

        ////////                }
        ////////                else if (Convert.ToInt32(TypO[ic]) > 1 && D[ic - 1] > D[ic])
        ////////                {
        ////////                    zapros2.PDOsNagr(Convert.ToInt32(DoubO[ic]), Convert.ToInt32(TypO[ic]), ADNagr, D[ic]);

        ////////                }
        ////////                else if (Convert.ToInt32(TypO[ic]) == 1)
        ////////                {
        ////////                    if (D[ic] < 250)
        ////////                    {
        ////////                        D[ic] = 250;
        ////////                    }
        ////////                    zapros2.PDOsNagr(Convert.ToInt32(DoubO[ic]), Convert.ToInt32(TypO[ic]), ADNagr, D[ic]);

        ////////                }
        ////////            }
        ////////            //zapros2.PDOsNagr(Convert.ToInt32(DoubO[ic]), Convert.ToInt32(TypO[ic]), ADNagr, D[ic]); }
        ////////            else { zapros2.PDOsNagr(Convert.ToInt32(DoubO[ic]), Convert.ToInt32(TypO[ic]), ADNagr, D[ic - 1]); }

        ////////            string z2 = zapros2.commandStringTest;
        ////////            command2.CommandText = z2;
        ////////            command2.Connection = connection2;
        ////////            MySqlDataReader reader2;
        ////////            try
        ////////            {
        ////////                command2.Connection.Open();
        ////////                reader2 = command2.ExecuteReader();
        ////////                while (reader2.Read())
        ////////                {
        ////////                    PDKO[ic] = Convert.ToDouble(reader2["pdo"].ToString());
        ////////                    PDKTel[ic] = Convert.ToDouble(reader2["pdt"].ToString());
        ////////                }
        ////////                reader2.Close();
        ////////            }
        ////////            catch (MySqlException ex)
        ////////            {
        ////////                Console.WriteLine("Error: \r\n{0}", ex.ToString());
        ////////            }
        ////////            finally
        ////////            {
        ////////                command2.Connection.Close();
        ////////            }
        ////////        }
        ////////    }
        ////////}

        ////////#endregion///////////////////////////////////////////// 
        #endregion //////////////////////////
        public Image StrToImg(string StrImg)
        {
            byte[] arrayimg = Convert.FromBase64String(StrImg);
            Image imageStr = Image.FromStream(new MemoryStream(arrayimg));
           
            return imageStr;
        }
        //функция преобразования изображения в строку
        #region ///////////////////////////////// отправка файлов на почту //////////////////////
        public void GetMail()
        {
           // SmtpClient client = new SmtpClient("smtp.mail.ru", 2525); // Здесь указываем смтп сервер и порт, который мы будем использовать 
           // client.Credentials = new System.Net.NetworkCredential("rasvgksev@bdsev.ru", "148GeVpKm"); // Указываем логин и пароль для авторизации

           // string msgFrom = "rasvgksev@bdsev.ru"; // Указываем поле, от кого письмо 
           // string msgTo = "rasvgksev@bdsev.ru"; // Указываем поле, кому письмо будет отправлено 
           // string msgSubject = "Письмо из c#"; // Указываем тему пиьсма

           // string msgBody = String.Format("", ToString(), "Для подписи тестовое"); // Тут мы формируем тело письма


           // MailMessage msg = new MailMessage(msgFrom, msgTo, msgSubject, msgBody); // Создаем письмо, из всего, что сделали выше
           // Directory.GetFiles(aaa, "*.*").ToList().ForEach(name => msg.Attachments.Add(new Attachment(name, MediaTypeNames.Text.Plain)));
           // try
           //{
           //     client.Send(msg); // Отправляем письмо 
           // }
           // catch
           // {
           // }
        }
        #endregion /////////////////////////////////////////
    }

}
//}
