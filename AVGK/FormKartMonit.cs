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
using System.Diagnostics;
using System.Xml.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;


namespace AVGK
{
    public partial class FormKartMonit : Form
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
        public string aaa; public string aa;
        public Int64 NPicKR = 0;
        public int ColPicKR;
        public string ImNN; public string ImPlN; string ImAltN; string ImObjN; public string ImPlREAN;
        public Bitmap Im; public Bitmap ImPl; Bitmap ImAlt; Bitmap ImObj; Bitmap SkS; Bitmap ImAlt1; Bitmap ImAlt2; Bitmap Im1; Bitmap Im2; Bitmap SkF; Bitmap SkT;
        public Bitmap ImREA; public Bitmap ImPlREA; Bitmap ImAltREA; Bitmap ImObjREA;
        public Bitmap[] ImN = new Bitmap[20]; int IIm = 0;
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
        public int TypNar = 0; public string TypNarTXT = ""; public double PPRNAR = 0; public int iNar; public double MAXPREV = 0; public double MAXPREVPROTC = 0;
        public double[] PrevNar = new double[40];//0-9 нагр на ось; 10-16 нагр на тел; 17 Общ масса; 18-20 габариты; 21 скорость, полоса, ограничения 25 Срок действия поверки
                                                 //26- Количество осей 27-одиночн/автопоезд 28 ТТС/КТС/ТКТС 29 наличие с/р 30 Ось/группа/общ.масса/длина/ширина/высота
                                                 //31-№оси/группы 32-превышение поПДК или по СР 33 - степень превышения (%,м) 34- часть статьи 1-11 35 - выезд на встречку/выезд на обочину 36 - доп часть ПДД
        public double[] PDKPik = new double[9];
        public string PNarSTEPEN;
        public string NS = "";
        public double PrevDlPr; public int NOG; public string CodNar;
        public string zR;
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
        public string IDTSIsh; public int IDTSKon; string DPR;
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
        public double[] PDKOsTel = new double[10];///пдк тележки
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
        public double D1_2 = 0; public double D1S_2S = 0; public double D2_3 = 0;
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
        public string tipoS;

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
        public int i = 1;
        static System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
        public Image bin;
        public int ic;
        public int icO;
        public int icC;
        public int GrO;
        private MySqlConnection connection;
        public MySqlConnection connection1;
        public MySqlConnection connection2;
        public MySqlConnection connectionR;
        private MySqlDataAdapter mySqlDataAdapter;
        public string NamU; string RazrG;
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
        public DataSet DSIstIzm = new DataSet();
        public MySqlConnection connectionIzm;
        public MySqlDataAdapter MySqlDataAdapterizm;
        public DataSet DSIstIzm1 = new DataSet();
        public MySqlConnection connectionIzm1;
        public MySqlDataAdapter MySqlDataAdapterizm1;
        public string[] Puti =  { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
        public string[] SPEED_ALL = new string[8];
        public string PDFN; public string PDFName; string bbb;
        public string UidANG;
        public string st9;
        public int Osh;
        public string GDAng; int AngStat = 0; public Guid INAng; public string CDD; public string NamPD; public int IDTS1; public string PT5;
        public string Gross; public string Part; public string Group; public string siz; public string speed; public int KLISPR; public string PLACE; public int KOGrNar;
        public string TypNarTXTM; public string EDIzmM;  public string MAXPREVM; public string MAXPREVPROTCM;
        public string NZaprF; int ChastNZapr; int KolZap; string SigAx = "False"; string SigGr = "False"; string SigAll = "False"; string PlID;
        public string NSPov; string DVPov; string ValidPov; double NagrTel; double SrednRTel; int KolGr;

        public FormKartMonit(Form2 ownerForm)
        {
            InitializeComponent();
            //////////////////////////////////////////////////////////////////////////////////
            pictureBox40.Location = AutoScrollOffset;
            SelfRef = this;
        }
        public static FormKartMonit SelfRef
        {
            get;
            set;
        }
        public bool OpenConnection() //// Открытие соединения
        {
            try
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
        {
            try
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
        public FormKartMonit()
        { InitializeComponent(); }
        private void FormKartMonit_Load(object sender, EventArgs e)
        {            
            pictureBox40.BackColor = Color.Transparent;           
        }
        #endregion загрузка 
        internal void FormKartMonit_LoadPMonit(int IDTS, string NUs, string Razr)//// загрузка формы уже с пользователем и проездом
        {
            IDTS1 = IDTS;
            RazrG = Razr;
            NamU = NUs;
            if (Razr=="0")
            {
                maskedTextBox1.ReadOnly = true;
            }
            else if (Razr == "1")
            {
                maskedTextBox1.ReadOnly = false;
            }
            label161.Text = NamU;
            label144.Text = Convert.ToString(IDTS);
            label154.Text = Convert.ToString(IDTS);
            alphaBlendTextBox25.Text = Convert.ToString(IDTS);
           this.Cursor = Cursors.Arrow;
            ZagrPr(IDTS);
            if ((XDate[31] == "True" || XDate[30] == "True" || XDate[2] == "True" || XDate[4] == "True" || XDate[3] == "True") && Im != null && TypNar > 0)//&& ImPl,ImAlt )
            { /*button4.Visible = true; button5.Visible = true; button6.Visible = true; button9.Visible = true;*/ }
            else if ((XDate[31] == "False" || XDate[30] == "False" || XDate[2] == "False" || XDate[4] == "False" || XDate[3] == "False"))
            { button4.Visible = false; /*button5.Visible = false;*/ button6.Visible = false; button9.Visible = false; }
        }
        public void ZagrPr(int IDTS)
        {
            MySqlCommand commandNSR = new MySqlCommand();
            ConnectStr conStrNSR = new ConnectStr();
            conStrNSR.ConStr(1);
            Zapros zaprosNSR = new Zapros();
            string connectionStringNSR;
            connectionStringNSR = conStrNSR.StP;//"Data source=localhost;UserId=root;Password=1q2w3e$R;database=camloc;";
            MySqlConnection connectionNSR = new MySqlConnection(connectionStringNSR);
            zaprosNSR.PrNalSR(IDTS);
            string zNSR = zaprosNSR.commandStringTest;
            commandNSR.CommandText = zNSR;// commandString;
            commandNSR.Connection = connectionNSR;
            MySqlDataReader readerNSR;
            int NSR = 0;
            try
            {
                commandNSR.Connection.Open();
                readerNSR = commandNSR.ExecuteReader();
                while (readerNSR.Read())
                {
                    NSR = 1;
                }
                readerNSR.Close();
            }
            catch (MySqlException ex)
            {
                NSR = 0;
                //Console.WriteLine("Error: \r\n{0}", ex.ToString());
            }
            finally
            {
                commandNSR.Connection.Close();
            }

            /////////////////////////////////////////
            //    запрос для формирования ячеек с сертификата поверки
            //MySqlCommand command = new MySqlCommand();
            //ConnectStr conStr = new ConnectStr();
            conStrNSR.ConStr(1);
            //Zapros zapros = new Zapros();
            string commandStringPoverka;
            connectionStringNSR = conStrNSR.StP;//"Data source=localhost;UserId=root;Password=1q2w3e$R;database=camloc;";
            commandStringPoverka = "SELECT " +
                                   "rap_svid_poverki_si.IDWim, " +
                                   "rap_svid_poverki_si.VidSPSI, " +
                                   "rap_svid_poverki_si.NomSPSI, " +
                                   "rap_svid_poverki_si.DateVidSPSI, " +
                                   "rap_svid_poverki_si.SrokSPSI, " +
                                   "rap_svid_poverki_si.PhotoSvidPSI " +
                                   "FROM rap_svid_poverki_si " +
                                   "WHERE rap_svid_poverki_si.IDWim = '" + PlID + "' " +
                                   "AND DATE_FORMAT(STR_TO_DATE(SrokSPSI, '%d.%m.%Y'), '%Y%m%d') > DATE_FORMAT(NOW(), '%Y%m%d')";
            //MySqlConnection connection = new MySqlConnection(connectionString);
            //zapros.ZaprAllCamNaprLO(IDTS, 0);
            //string z = zapros.commandStringTest;
            commandNSR.CommandText = commandStringPoverka;
            commandNSR.Connection = connectionNSR;
            MySqlDataReader readerPoverka;
            int NumberIter = 0;
            try
            {
                commandNSR.Connection.Open();
                readerPoverka = commandNSR.ExecuteReader();

                while (readerPoverka.Read())
                {
                    if (NumberIter == 0)
                    {
                        NSPov = readerPoverka["NomSPSI"].ToString();
                        DVPov = readerPoverka["DateVidSPSI"].ToString();
                        ValidPov = readerPoverka["SrokSPSI"].ToString();
                    }
                    if (NumberIter == 1)
                    {
                        NSPov = NSPov + " / " + readerPoverka["NomSPSI"].ToString();
                        DVPov = DVPov + " / " + readerPoverka["DateVidSPSI"].ToString();
                        ValidPov = ValidPov + " / " + readerPoverka["SrokSPSI"].ToString();
                    }
                    if (NumberIter == 2)
                    {
                        NSPov = NSPov + " / " + readerPoverka["NomSPSI"].ToString();
                        DVPov = DVPov + " / " + readerPoverka["DateVidSPSI"].ToString();
                        ValidPov = ValidPov + " / " + readerPoverka["SrokSPSI"].ToString();
                    }
                    NumberIter = NumberIter + 1;
                }
                readerPoverka.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: \r\n{0}", ex.ToString());
            }
            finally
            {
                commandNSR.Connection.Close();
            }
            ////////////////////////////////////////////////////

            #region /////////////////////////////////////////// ЛЕВАЯ ЧАСТЬ (ИНФО О ПРОЕЗДЕ)
            MySqlCommand command = new MySqlCommand();
            ConnectStr conStr = new ConnectStr();
            conStr.ConStr(1);
            Zapros zapros = new Zapros();
            string connectionString;
            connectionString = conStr.StP;//"Data source=localhost;UserId=root;Password=1q2w3e$R;database=camloc;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            zapros.ZaprAllCamNaprLO(IDTS, NSR);
            string z = zapros.commandStringTest;
            command.CommandText = z;// commandString;
            command.Connection = connection;
            MySqlDataReader reader;
            NumberIter = 0;
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
                    PlID = reader["PlatformId"].ToString();
                    KolZap = KolZap + 1;
                    KolOs = Convert.ToInt32(reader["AxleCount"].ToString());
                    ObshMass = Convert.ToInt32(reader["Weight"].ToString());

                    if (Convert.ToString(reader["UIDAng"].ToString()) != "")
                    {
                        AngStat = 1; GDAng = Convert.ToString(reader["UIDAng"].ToString());
                    }

                    if (Convert.ToInt32(reader["StatAng"].ToString()) == 2)
                    { GRZ = reader["OldGRZ"].ToString(); }
                    else
                    {
                        if (reader["PlateConfidence"].ToString() == "0")
                        { GRZ = reader["PlateRear"].ToString(); }
                        else
                        { GRZ = reader["Plate"].ToString(); }
                    }
                    Gross = reader["IsOverweightGross"].ToString();
                    Part = reader["IsOverweightPartial"].ToString();
                    Group = reader["IsOverweightGroup"].ToString();
                    siz = reader["IsOversized"].ToString();
                    speed = reader["IsOverspeed"].ToString();
                    KLISPR = Convert.ToInt32(reader["KlNew"].ToString());                   
                    //Cr11 = Convert.ToInt32(reader["CredenceExceeded"].ToString());
                    //Ind = Convert.ToInt32(reader["ChangeType"].ToString());
                    //StatAng = Convert.ToInt32(reader["StatAng"].ToString());

                    label144.Text = Convert.ToString(Convert.ToDouble(reader["Weight"]) / 1000);
                    label154.Text = Convert.ToString(Convert.ToDouble(reader["Length"]) / 100);
                    if (reader["CheckSumIsch"].ToString()!= reader["CheckSum"].ToString())
                    {
                        //label103.Visible = true;
                        //label104.Visible = true;
                    }
                    if (NumberIter == 0)
                    {
                        string io = Convert.ToString(Convert.ToInt32(reader["wheelCount"]) / 2);
                        label153.Text = io;//Convert.ToString(Convert.ToInt32(reader["wheelCount"]) / 2);
                        string iio = Convert.ToString(Convert.ToDouble(reader["weightAxel"]) / 1000);
                        label171.Text = iio;//Convert.ToString(Convert.ToDouble(reader["weightAxel"]) / 1000);
                        BetOs[0, 0] = 0;
                        BetOs[1, 0] = Convert.ToDouble(reader["Unit"]);
                        BetOs[2, 0] = Convert.ToDouble(reader["Group"]);
                        KolGr = Convert.ToInt32(reader["Group"]);
                        BetOs[3, 0] = 0;
                        BetOs[4, 0] = Convert.ToDouble(reader["weightAxel"]);
                        BetOs[5, 0] = Convert.ToDouble(reader["weightleft"]);
                        BetOs[6, 0] = Convert.ToDouble(reader["weightright"]);
                        BetOs[7, 0] = Convert.ToDouble(reader["weightlimitAxel"]);
                        if (reader["wheelcount"] != null && Convert.ToDouble(reader["wheelcount"]) > 1)
                        {
                            if (Convert.ToDouble(reader["wheelcount"]) / 2 > 2)
                            { BetOs[8, 0] = 2; label107.Visible = true; }
                            else { BetOs[8, 0] = Convert.ToDouble(reader["wheelcount"]) / 2; label107.Visible = false; }
                        }
                        else
                        { BetOs[8, 0] = 1; label107.Visible = true; }
                        if (reader["isoverweightAxel"].ToString() == "false")
                        { BetOs[9, 0] = 0; }
                        else { BetOs[9, 0] = 1; }
                        BetOs[10, 0] = Convert.ToDouble(reader["SpeedAxel"].ToString());//.Substring(5,9));
                        BetOs[11, 0] = Convert.ToDouble(reader["credenceAxel"]);
                        BetOs[13, 0] = Convert.ToDouble(reader["weightAxel"]) - Convert.ToDouble(reader["weightAxel"]) / 100 * 10;
                        BetOs[14, 0] = (Convert.ToDouble(reader["weightAxel"]) - Convert.ToDouble(reader["weightAxel"]) / 100 * 10) - Convert.ToDouble(reader["weightlimitAxel"]);
                        BetOs[15, 0] = (Convert.ToDouble(reader["weightlimitAxel"]) / (Convert.ToDouble(reader["weightAxel"]) - Convert.ToDouble(reader["weightAxel"]) / 100 * 10)) * 100;
                        //if (Convert.ToString(reader["Os1M"]) != null && Convert.ToString(reader["Os1M"]) != "" && Convert.ToString(reader["Os1M"]) != " ")
                        //{ BetOs[16, 0] = Convert.ToDouble(reader["Os1M"]); }
                        //else { BetOs[16, 0] = 0; }
                        //BetOs[17, 0] = 0;
                        if (Convert.ToString(reader["MasAxSR"]) != null && Convert.ToString(reader["MasAxSR"]) != "" && Convert.ToString(reader["MasAxSR"]) != " ")
                        { BetOs[16, 0] = Convert.ToDouble(reader["MasAxSR"]); }
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
                        KolGr = Convert.ToInt32(reader["Group"]);
                        BetOs[3, 1] = l[1];
                        BetOs[4, 1] = Convert.ToDouble(reader["weightAxel"]);
                        BetOs[5, 1] = Convert.ToDouble(reader["weightleft"]);
                        BetOs[6, 1] = Convert.ToDouble(reader["weightright"]);
                        BetOs[7, 1] = Convert.ToDouble(reader["weightlimitAxel"]);
                        if (reader["wheelcount"] != null && Convert.ToDouble(reader["wheelcount"]) > 1)
                        {
                            if (Convert.ToDouble(reader["wheelcount"]) / 2 > 2)
                            { BetOs[8, 1] = 2; label107.Visible = true; }
                            else { BetOs[8, 1] = Convert.ToDouble(reader["wheelcount"]) / 2; label107.Visible = false; }
                        }
                        else
                        { BetOs[8, 1] = 1; label107.Visible = true; }
                        if (reader["isoverweightAxel"].ToString() == "false")
                        { BetOs[9, 1] = 0; }
                        else { BetOs[9, 1] = 1; }
                        BetOs[10, 1] = Convert.ToDouble(reader["SpeedAxel"].ToString());
                        BetOs[11, 1] = Convert.ToDouble(reader["credenceAxel"]);
                        BetOs[13, 1] = Convert.ToDouble(reader["weightAxel"]) - Convert.ToDouble(reader["weightAxel"]) / 100 * 10;
                        BetOs[14, 1] = (Convert.ToDouble(reader["weightAxel"]) - Convert.ToDouble(reader["weightAxel"]) / 100 * 10) - Convert.ToDouble(reader["weightlimitAxel"]);
                        BetOs[15, 1] = (Convert.ToDouble(reader["weightlimitAxel"]) / (Convert.ToDouble(reader["weightAxel"]) - Convert.ToDouble(reader["weightAxel"]) / 100 * 10)) * 100;
                        //if (Convert.ToString(reader["Os2M"]) != null && Convert.ToString(reader["Os2M"]) != "" && Convert.ToString(reader["Os2M"]) != " ")
                        //{ BetOs[16, 1] = Convert.ToDouble(reader["Os2M"]); }
                        //else { BetOs[16, 1] = 0; }
                        //if (Convert.ToString(reader["AxInt1"]) != null && Convert.ToString(reader["AxInt1"]) != "" && Convert.ToString(reader["AxInt1"]) != " ")
                        //{ BetOs[17, 1] = Convert.ToDouble(reader["AxInt1"]); }
                        //else { BetOs[17, 1] = 0; }
                        if (Convert.ToString(reader["MasAxSR"]) != null && Convert.ToString(reader["MasAxSR"]) != "" && Convert.ToString(reader["MasAxSR"]) != " ")
                        { BetOs[16, 1] = Convert.ToDouble(reader["MasAxSR"]); }
                        else { BetOs[16, 1] = 0; }
                        if (Convert.ToString(reader["IntervalAxSR"]) != null && Convert.ToString(reader["IntervalAxSR"]) != "" && Convert.ToString(reader["IntervalAxSR"]) != " ")
                        { BetOs[17, 1] = Convert.ToDouble(reader["IntervalAxSR"]); }
                        else { BetOs[17, 1] = 0; }
                    }
                    if (NumberIter == 2)
                    {
                        label151.Text = Convert.ToString(Convert.ToInt32(reader["wheelCount"]) / 2);
                        label161.Text = Convert.ToString((Convert.ToDouble(reader["position"]) / 100) - pos);
                        l[2] = (Convert.ToDouble(reader["position"]) / 100) - pos;
                        pos = Convert.ToDouble(reader["position"]) / 100;
                        label169.Text = Convert.ToString(Convert.ToDouble(reader["weightAxel"]) / 1000);
                        D2_3 = l[2];
                        BetOs[0, 2] = 0;
                        BetOs[1, 2] = Convert.ToDouble(reader["Unit"]);
                        BetOs[2, 2] = Convert.ToDouble(reader["Group"]);
                        KolGr = Convert.ToInt32(reader["Group"]);
                        BetOs[3, 2] = l[2];
                        BetOs[4, 2] = Convert.ToDouble(reader["weightAxel"]);
                        BetOs[5, 2] = Convert.ToDouble(reader["weightleft"]);
                        BetOs[6, 2] = Convert.ToDouble(reader["weightright"]);
                        BetOs[7, 2] = Convert.ToDouble(reader["weightlimitAxel"]);
                        if (reader["wheelcount"] != null && Convert.ToDouble(reader["wheelcount"]) > 1)
                        {
                            if (Convert.ToDouble(reader["wheelcount"]) / 2 > 2)
                            { BetOs[8, 2] = 2; label107.Visible = true; }
                            else { BetOs[8, 2] = Convert.ToDouble(reader["wheelcount"]) / 2; label107.Visible = false; }
                        }
                        else
                        { BetOs[8, 2] = 1; label107.Visible = true; }
                        if (reader["isoverweightAxel"].ToString() == "false")
                        { BetOs[9, 2] = 0; }
                        else { BetOs[9, 2] = 1; }
                        BetOs[10, 2] = Convert.ToDouble(reader["SpeedAxel"].ToString());//.Substring(5, 9));
                        BetOs[11, 2] = Convert.ToDouble(reader["credenceAxel"]);
                        BetOs[13, 2] = Convert.ToDouble(reader["weightAxel"]) - Convert.ToDouble(reader["weightAxel"]) / 100 * 10;
                        BetOs[14, 2] = (Convert.ToDouble(reader["weightAxel"]) - Convert.ToDouble(reader["weightAxel"]) / 100 * 10) - Convert.ToDouble(reader["weightlimitAxel"]);
                        BetOs[15, 2] = (Convert.ToDouble(reader["weightlimitAxel"]) / (Convert.ToDouble(reader["weightAxel"]) - Convert.ToDouble(reader["weightAxel"]) / 100 * 10)) * 100;
                        //if (Convert.ToString(reader["Os3M"]) != null && Convert.ToString(reader["Os3M"]) != "" && Convert.ToString(reader["Os3M"]) != " ")
                        //{ BetOs[16, 2] = Convert.ToDouble(reader["Os3M"]); }
                        //else { BetOs[16, 2] = 0; }
                        //if (Convert.ToString(reader["AxInt2"]) != null && Convert.ToString(reader["AxInt2"]) != "" && Convert.ToString(reader["AxInt2"]) != " ")
                        //{ BetOs[17, 2] = Convert.ToDouble(reader["AxInt2"]); }
                        //else { BetOs[17, 2] = 0; }
                        if (Convert.ToString(reader["MasAxSR"]) != null && Convert.ToString(reader["MasAxSR"]) != "" && Convert.ToString(reader["MasAxSR"]) != " ")
                        { BetOs[16, 2] = Convert.ToDouble(reader["MasAxSR"]); }
                        else { BetOs[16, 2] = 0; }
                        if (Convert.ToString(reader["IntervalAxSR"]) != null && Convert.ToString(reader["IntervalAxSR"]) != "" && Convert.ToString(reader["IntervalAxSR"]) != " ")
                        { BetOs[17, 2] = Convert.ToDouble(reader["IntervalAxSR"]); }
                        else { BetOs[17, 2] = 0; }
                    }
                    if (NumberIter == 3)
                    {
                        label150.Text = Convert.ToString(Convert.ToInt32(reader["wheelCount"]) / 2);
                        label160.Text = Convert.ToString((Convert.ToDouble(reader["position"]) / 100) - pos);
                        l[3] = (Convert.ToDouble(reader["position"]) / 100) - pos;
                        pos = Convert.ToDouble(reader["position"]) / 100;
                        label168.Text = Convert.ToString(Convert.ToDouble(reader["weightAxel"]) / 1000);
                        D3_4 = l[3];
                        BetOs[0, 3] = 0;
                        BetOs[1, 3] = Convert.ToDouble(reader["Unit"]);
                        BetOs[2, 3] = Convert.ToDouble(reader["Group"]);
                        KolGr = Convert.ToInt32(reader["Group"]);
                        BetOs[3, 3] = l[3];
                        BetOs[4, 3] = Convert.ToDouble(reader["weightAxel"]);
                        BetOs[5, 3] = Convert.ToDouble(reader["weightleft"]);
                        BetOs[6, 3] = Convert.ToDouble(reader["weightright"]);
                        BetOs[7, 3] = Convert.ToDouble(reader["weightlimitAxel"]);
                        if (reader["wheelcount"] != null && Convert.ToDouble(reader["wheelcount"]) > 1)
                        {
                            if (Convert.ToDouble(reader["wheelcount"]) / 2 > 2)
                            { BetOs[8, 3] = 2; label107.Visible = true; }
                            else { BetOs[8, 3] = Convert.ToDouble(reader["wheelcount"]) / 2; label107.Visible = false; }
                        }
                        else
                        { BetOs[8, 3] = 1; label107.Visible = true; }
                        if (reader["isoverweightAxel"].ToString() == "false")
                        { BetOs[9, 3] = 0; }
                        else { BetOs[9, 3] = 1; }
                        BetOs[10, 3] = Convert.ToDouble(reader["SpeedAxel"].ToString());//.Substring(5, 9));
                        BetOs[11, 3] = Convert.ToDouble(reader["credenceAxel"]);
                        BetOs[13, 3] = Convert.ToDouble(reader["weightAxel"]) - Convert.ToDouble(reader["weightAxel"]) / 100 * 10;
                        BetOs[14, 3] = (Convert.ToDouble(reader["weightAxel"]) - Convert.ToDouble(reader["weightAxel"]) / 100 * 10) - Convert.ToDouble(reader["weightlimitAxel"]);
                        BetOs[15, 3] = (Convert.ToDouble(reader["weightlimitAxel"]) / (Convert.ToDouble(reader["weightAxel"]) - Convert.ToDouble(reader["weightAxel"]) / 100 * 10)) * 100;
                        //if (Convert.ToString(reader["Os4M"]) != null && Convert.ToString(reader["Os4M"]) != "" && Convert.ToString(reader["Os4M"]) != " ")
                        //{ BetOs[16, 3] = Convert.ToDouble(reader["Os4M"]); }
                        //else { BetOs[16, 3] = 0; }
                        //if (Convert.ToString(reader["AxInt3"]) != null && Convert.ToString(reader["AxInt3"]) != "" && Convert.ToString(reader["AxInt3"]) != " ")
                        //{ BetOs[17, 3] = Convert.ToDouble(reader["AxInt3"]); }
                        //else { BetOs[17, 3] = 0; }
                        if (Convert.ToString(reader["MasAxSR"]) != null && Convert.ToString(reader["MasAxSR"]) != "" && Convert.ToString(reader["MasAxSR"]) != " ")
                        { BetOs[16, 3] = Convert.ToDouble(reader["MasAxSR"]); }
                        else { BetOs[16, 3] = 0; }
                        if (Convert.ToString(reader["IntervalAxSR"]) != null && Convert.ToString(reader["IntervalAxSR"]) != "" && Convert.ToString(reader["IntervalAxSR"]) != " ")
                        { BetOs[17, 3] = Convert.ToDouble(reader["IntervalAxSR"]); }
                        else { BetOs[17, 3] = 0; }
                    }
                    if (NumberIter == 4)
                    {
                        label149.Text = Convert.ToString(Convert.ToInt32(reader["wheelCount"]) / 2);
                        label159.Text = Convert.ToString((Convert.ToDouble(reader["position"]) / 100) - pos);
                        l[4] = (Convert.ToDouble(reader["position"]) / 100) - pos;
                        pos = Convert.ToDouble(reader["position"]) / 100;
                        label167.Text = Convert.ToString(Convert.ToDouble(reader["weightAxel"]) / 1000);
                        D4_5 = l[4];
                        BetOs[0, 4] = 0;
                        BetOs[1, 4] = Convert.ToDouble(reader["Unit"]);
                        BetOs[2, 4] = Convert.ToDouble(reader["Group"]);
                        KolGr = Convert.ToInt32(reader["Group"]);
                        BetOs[3, 4] = l[4];
                        BetOs[4, 4] = Convert.ToDouble(reader["weightAxel"]);
                        BetOs[5, 4] = Convert.ToDouble(reader["weightleft"]);
                        BetOs[6, 4] = Convert.ToDouble(reader["weightright"]);
                        BetOs[7, 4] = Convert.ToDouble(reader["weightlimitAxel"]);
                        if (reader["wheelcount"] != null && Convert.ToDouble(reader["wheelcount"]) > 1)
                        {
                            if (Convert.ToDouble(reader["wheelcount"]) / 2 > 2)
                            { BetOs[8, 4] = 2; label107.Visible = true; }
                            else { BetOs[8, 4] = Convert.ToDouble(reader["wheelcount"]) / 2; label107.Visible = false; }
                        }
                        else
                        { BetOs[8, 4] = 1; label107.Visible = true; }
                        if (reader["isoverweightAxel"].ToString() == "false")
                        { BetOs[9, 4] = 0; }
                        else { BetOs[9, 4] = 1; }
                        BetOs[10, 4] = Convert.ToDouble(reader["SpeedAxel"].ToString());//.Substring(5, 9));
                        BetOs[11, 4] = Convert.ToDouble(reader["credenceAxel"]);
                        BetOs[13, 4] = Convert.ToDouble(reader["weightAxel"]) - Convert.ToDouble(reader["weightAxel"]) / 100 * 10;
                        BetOs[14, 4] = (Convert.ToDouble(reader["weightAxel"]) - Convert.ToDouble(reader["weightAxel"]) / 100 * 10) - Convert.ToDouble(reader["weightlimitAxel"]);
                        BetOs[15, 4] = (Convert.ToDouble(reader["weightlimitAxel"]) / (Convert.ToDouble(reader["weightAxel"]) - Convert.ToDouble(reader["weightAxel"]) / 100 * 10)) * 100;
                        //if (Convert.ToString(reader["Os5M"]) != null && Convert.ToString(reader["Os5M"]) != "" && Convert.ToString(reader["Os5M"]) != " ")
                        //{ BetOs[16, 4] = Convert.ToDouble(reader["Os5M"]); }
                        //else { BetOs[16, 4] = 0; }
                        //if (Convert.ToString(reader["AxInt4"]) != null && Convert.ToString(reader["AxInt4"]) != "" && Convert.ToString(reader["AxInt4"]) != " ")
                        //{ BetOs[17, 4] = Convert.ToDouble(reader["AxInt4"]); }
                        //else { BetOs[17, 4] = 0; }
                        if (Convert.ToString(reader["MasAxSR"]) != null && Convert.ToString(reader["MasAxSR"]) != "" && Convert.ToString(reader["MasAxSR"]) != " ")
                        { BetOs[16, 4] = Convert.ToDouble(reader["MasAxSR"]); }
                        else { BetOs[16, 4] = 0; }
                        if (Convert.ToString(reader["IntervalAxSR"]) != null && Convert.ToString(reader["IntervalAxSR"]) != "" && Convert.ToString(reader["IntervalAxSR"]) != " ")
                        { BetOs[17, 4] = Convert.ToDouble(reader["IntervalAxSR"]); }
                        else { BetOs[17, 4] = 0; }
                    }
                    if (NumberIter == 5)
                    {
                        label148.Text = Convert.ToString(Convert.ToInt32(reader["wheelCount"]) / 2);
                        label158.Text = Convert.ToString((Convert.ToDouble(reader["position"]) / 100) - pos);
                        l[5] = (Convert.ToDouble(reader["position"]) / 100) - pos;
                        pos = Convert.ToDouble(reader["position"]) / 100;
                        label166.Text = Convert.ToString(Convert.ToDouble(reader["weightAxel"]) / 1000);
                        D5_6 = l[5];
                        BetOs[0, 5] = 0;
                        BetOs[1, 5] = Convert.ToDouble(reader["Unit"]);
                        BetOs[2, 5] = Convert.ToDouble(reader["Group"]);
                        KolGr = Convert.ToInt32(reader["Group"]);
                        BetOs[3, 5] = l[5];
                        BetOs[4, 5] = Convert.ToDouble(reader["weightAxel"]);
                        BetOs[5, 5] = Convert.ToDouble(reader["weightleft"]);
                        BetOs[6, 5] = Convert.ToDouble(reader["weightright"]);
                        BetOs[7, 5] = Convert.ToDouble(reader["weightlimitAxel"]);
                        if (reader["wheelcount"] != null && Convert.ToDouble(reader["wheelcount"]) > 1)
                        {
                            if (Convert.ToDouble(reader["wheelcount"]) / 2 > 2)
                            { BetOs[8, 5] = 2; label107.Visible = true; }
                            else { BetOs[8, 5] = Convert.ToDouble(reader["wheelcount"]) / 2; label107.Visible = false; }
                        }
                        else
                        { BetOs[8, 5] = 1; label107.Visible = true; }
                        if (reader["isoverweightAxel"].ToString() == "false")
                        { BetOs[9, 5] = 0; }
                        else { BetOs[9, 5] = 1; }
                        BetOs[10, 5] = Convert.ToDouble(reader["SpeedAxel"].ToString());//.Substring(5, 9));
                        BetOs[11, 5] = Convert.ToDouble(reader["credenceAxel"]);
                        BetOs[13, 5] = Convert.ToDouble(reader["weightAxel"]) - Convert.ToDouble(reader["weightAxel"]) / 100 * 10;
                        BetOs[14, 5] = (Convert.ToDouble(reader["weightAxel"]) - Convert.ToDouble(reader["weightAxel"]) / 100 * 10) - Convert.ToDouble(reader["weightlimitAxel"]);
                        BetOs[15, 5] = (Convert.ToDouble(reader["weightlimitAxel"]) / (Convert.ToDouble(reader["weightAxel"]) - Convert.ToDouble(reader["weightAxel"]) / 100 * 10)) * 100;
                        //if (Convert.ToString(reader["Os6M"]) != null && Convert.ToString(reader["Os6M"]) != "" && Convert.ToString(reader["Os6M"]) != " ")
                        //{ BetOs[16, 5] = Convert.ToDouble(reader["Os6M"]); }
                        //else { BetOs[16, 5] = 0; }
                        //if (Convert.ToString(reader["AxInt5"]) != null && Convert.ToString(reader["AxInt5"]) != "" && Convert.ToString(reader["AxInt5"]) != " ")
                        //{ BetOs[17, 5] = Convert.ToDouble(reader["AxInt5"]); }
                        //else { BetOs[17, 5] = 0; }
                        if (Convert.ToString(reader["MasAxSR"]) != null && Convert.ToString(reader["MasAxSR"]) != "" && Convert.ToString(reader["MasAxSR"]) != " ")
                        { BetOs[16, 5] = Convert.ToDouble(reader["MasAxSR"]); }
                        else { BetOs[16, 5] = 0; }
                        if (Convert.ToString(reader["IntervalAxSR"]) != null && Convert.ToString(reader["IntervalAxSR"]) != "" && Convert.ToString(reader["IntervalAxSR"]) != " ")
                        { BetOs[17, 5] = Convert.ToDouble(reader["IntervalAxSR"]); }
                        else { BetOs[17, 5] = 0; }
                    }
                    if (NumberIter == 6)
                    {
                        label147.Text = Convert.ToString(Convert.ToInt32(reader["wheelCount"]) / 2);
                        label157.Text = Convert.ToString((Convert.ToDouble(reader["position"]) / 100) - pos);
                        l[6] = (Convert.ToDouble(reader["position"]) / 100) - pos;
                        pos = Convert.ToDouble(reader["position"]) / 100;
                        label165.Text = Convert.ToString(Convert.ToDouble(reader["weightAxel"]) / 1000);
                        D6_7 = l[6];
                        BetOs[0, 6] = 0;
                        BetOs[1, 6] = Convert.ToDouble(reader["Unit"]);
                        BetOs[2, 6] = Convert.ToDouble(reader["Group"]);
                        KolGr = Convert.ToInt32(reader["Group"]);
                        BetOs[3, 6] = l[6];
                        BetOs[4, 6] = Convert.ToDouble(reader["weightAxel"]);
                        BetOs[5, 6] = Convert.ToDouble(reader["weightleft"]);
                        BetOs[6, 6] = Convert.ToDouble(reader["weightright"]);
                        BetOs[7, 6] = Convert.ToDouble(reader["weightlimitAxel"]);
                        if (reader["wheelcount"] != null && Convert.ToDouble(reader["wheelcount"]) > 1)
                        {
                            if (Convert.ToDouble(reader["wheelcount"]) / 2 > 2)
                            { BetOs[8, 6] = 2; label107.Visible = true; }
                            else { BetOs[8, 6] = Convert.ToDouble(reader["wheelcount"]) / 2; label107.Visible = false; }
                        }
                        else
                        { BetOs[8, 6] = 1; label107.Visible = true; }
                        if (reader["isoverweightAxel"].ToString() == "false")
                        { BetOs[9, 6] = 0; }
                        else { BetOs[9, 6] = 1; }
                        BetOs[10, 6] = Convert.ToDouble(reader["SpeedAxel"].ToString());//.Substring(5, 9));
                        BetOs[11, 6] = Convert.ToDouble(reader["credenceAxel"]);
                        BetOs[13, 6] = Convert.ToDouble(reader["weightAxel"]) - Convert.ToDouble(reader["weightAxel"]) / 100 * 10;
                        BetOs[14, 6] = (Convert.ToDouble(reader["weightAxel"]) - Convert.ToDouble(reader["weightAxel"]) / 100 * 10) - Convert.ToDouble(reader["weightlimitAxel"]);
                        BetOs[15, 6] = (Convert.ToDouble(reader["weightlimitAxel"]) / (Convert.ToDouble(reader["weightAxel"]) - Convert.ToDouble(reader["weightAxel"]) / 100 * 10)) * 100;
                        //if (Convert.ToString(reader["Os7M"]) != null && Convert.ToString(reader["Os7M"]) != "" && Convert.ToString(reader["Os7M"]) != " ")
                        //{ BetOs[16, 6] = Convert.ToDouble(reader["Os7M"]); }
                        //else { BetOs[16, 6] = 0; }
                        //if (Convert.ToString(reader["AxInt6"]) != null && Convert.ToString(reader["AxInt6"]) != "" && Convert.ToString(reader["AxInt6"]) != " ")
                        //{ BetOs[17, 6] = Convert.ToDouble(reader["AxInt6"]); }
                        //else { BetOs[17, 6] = 0; }
                        if (Convert.ToString(reader["MasAxSR"]) != null && Convert.ToString(reader["MasAxSR"]) != "" && Convert.ToString(reader["MasAxSR"]) != " ")
                        { BetOs[16, 6] = Convert.ToDouble(reader["MasAxSR"]); }
                        else { BetOs[16, 6] = 0; }
                        if (Convert.ToString(reader["IntervalAxSR"]) != null && Convert.ToString(reader["IntervalAxSR"]) != "" && Convert.ToString(reader["IntervalAxSR"]) != " ")
                        { BetOs[17, 6] = Convert.ToDouble(reader["IntervalAxSR"]); }
                        else { BetOs[17, 6] = 0; }
                    }
                    if (NumberIter == 7)
                    {
                        label146.Text = Convert.ToString(Convert.ToInt32(reader["wheelCount"]) / 2);
                        label156.Text = Convert.ToString((Convert.ToDouble(reader["position"]) / 100) - pos);
                        l[7] = (Convert.ToDouble(reader["position"]) / 100) - pos;
                        pos = Convert.ToDouble(reader["position"]) / 100;
                        label164.Text = Convert.ToString(Convert.ToDouble(reader["weightAxel"]) / 1000);
                        D7_8 = l[7];
                        BetOs[0, 7] = 0;
                        BetOs[1, 7] = Convert.ToDouble(reader["Unit"]);
                        BetOs[2, 7] = Convert.ToDouble(reader["Group"]);
                        KolGr = Convert.ToInt32(reader["Group"]);
                        BetOs[3, 7] = l[7];
                        BetOs[4, 7] = Convert.ToDouble(reader["weightAxel"]);
                        BetOs[5, 7] = Convert.ToDouble(reader["weightleft"]);
                        BetOs[6, 7] = Convert.ToDouble(reader["weightright"]);
                        BetOs[7, 7] = Convert.ToDouble(reader["weightlimitAxel"]);
                        if (reader["wheelcount"] != null && Convert.ToDouble(reader["wheelcount"]) > 1)
                        {
                            if (Convert.ToDouble(reader["wheelcount"]) / 2 > 2)
                            { BetOs[8, 7] = 2; label107.Visible = true; }
                            else { BetOs[8, 7] = Convert.ToDouble(reader["wheelcount"]) / 2; label107.Visible = false; }
                        }
                        else
                        { BetOs[8, 7] = 1; label107.Visible = true; }
                        if (reader["isoverweightAxel"].ToString() == "false")
                        { BetOs[9, 7] = 0; }
                        else { BetOs[9, 7] = 1; }
                        BetOs[10, 7] = Convert.ToDouble(reader["SpeedAxel"].ToString());//.Substring(5, 9));
                        BetOs[11, 7] = Convert.ToDouble(reader["credenceAxel"]);
                       BetOs[13, 7] = Convert.ToDouble(reader["weightAxel"]) - Convert.ToDouble(reader["weightAxel"]) / 100 * 10;
                        BetOs[14, 7] = (Convert.ToDouble(reader["weightAxel"]) - Convert.ToDouble(reader["weightAxel"]) / 100 * 10) - Convert.ToDouble(reader["weightlimitAxel"]);
                        BetOs[15, 7] = (Convert.ToDouble(reader["weightlimitAxel"]) / (Convert.ToDouble(reader["weightAxel"]) - Convert.ToDouble(reader["weightAxel"]) / 100 * 10)) * 100;
                        //if (Convert.ToString(reader["Os8M"]) != null && Convert.ToString(reader["Os8M"]) != "" && Convert.ToString(reader["Os8M"]) != " ")
                        //{ BetOs[16, 7] = Convert.ToDouble(reader["Os8M"]); }
                        //else { BetOs[16, 7] = 0; }
                        //if (Convert.ToString(reader["AxInt7"]) != null && Convert.ToString(reader["AxInt7"]) != "" && Convert.ToString(reader["AxInt7"]) != " ")
                        //{ BetOs[17, 7] = Convert.ToDouble(reader["AxInt7"]); }
                        //else { BetOs[17, 7] = 0; }
                        if (Convert.ToString(reader["MasAxSR"]) != null && Convert.ToString(reader["MasAxSR"]) != "" && Convert.ToString(reader["MasAxSR"]) != " ")
                        { BetOs[16, 7] = Convert.ToDouble(reader["MasAxSR"]); }
                        else { BetOs[16, 7] = 0; }
                        if (Convert.ToString(reader["IntervalAxSR"]) != null && Convert.ToString(reader["IntervalAxSR"]) != "" && Convert.ToString(reader["IntervalAxSR"]) != " ")
                        { BetOs[17, 7] = Convert.ToDouble(reader["IntervalAxSR"]); }
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
                        KolGr = Convert.ToInt32(reader["Group"]);
                        BetOs[3, 8] = l[8];
                        BetOs[4, 8] = Convert.ToDouble(reader["weightAxel"]);
                        BetOs[5, 8] = Convert.ToDouble(reader["weightleft"]);
                        BetOs[6, 8] = Convert.ToDouble(reader["weightright"]);
                        BetOs[7, 8] = Convert.ToDouble(reader["weightlimitAxel"]);
                        if (reader["wheelcount"] != null && Convert.ToDouble(reader["wheelcount"]) > 1)
                        {
                            if (Convert.ToDouble(reader["wheelcount"]) / 2 > 2)
                            { BetOs[8, 8] = 2; label107.Visible = true; }
                            else { BetOs[8, 8] = Convert.ToDouble(reader["wheelcount"]) / 2; label107.Visible = false; }
                        }
                        else
                        { BetOs[8, 8] = 1; label107.Visible = true; }
                        if (reader["isoverweightAxel"].ToString() == "false")
                        { BetOs[9, 8] = 0; }
                        else { BetOs[9, 8] = 1; }
                        BetOs[10, 8] = Convert.ToDouble(reader["SpeedAxel"].ToString());//.Substring(5, 9));
                        BetOs[11, 8] = Convert.ToDouble(reader["credenceAxel"]);
                       BetOs[13, 8] = Convert.ToDouble(reader["weightAxel"]) - Convert.ToDouble(reader["weightAxel"]) / 100 * 10;
                        BetOs[14, 8] = (Convert.ToDouble(reader["weightAxel"]) - Convert.ToDouble(reader["weightAxel"]) / 100 * 10) - Convert.ToDouble(reader["weightlimitAxel"]);
                        BetOs[15, 8] = (Convert.ToDouble(reader["weightlimitAxel"]) / (Convert.ToDouble(reader["weightAxel"]) - Convert.ToDouble(reader["weightAxel"]) / 100 * 10)) * 100;
                        //if (Convert.ToString(reader["Os9M"]) != null && Convert.ToString(reader["Os9M"]) != "" && Convert.ToString(reader["Os9M"]) != " ")
                        //{ BetOs[16, 8] = Convert.ToDouble(reader["Os9M"]); }
                        //else { BetOs[16, 8] = 0; }
                        //if (Convert.ToString(reader["AxInt8"]) != null && Convert.ToString(reader["AxInt8"]) != "" && Convert.ToString(reader["AxInt8"]) != " ")
                        //{ BetOs[17, 8] = Convert.ToDouble(reader["AxInt8"]); }
                        //else { BetOs[17, 8] = 0; }
                        if (Convert.ToString(reader["MasAxSR"]) != null && Convert.ToString(reader["MasAxSR"]) != "" && Convert.ToString(reader["MasAxSR"]) != " ")
                        { BetOs[16, 8] = Convert.ToDouble(reader["MasAxSR"]); }
                        else { BetOs[16, 8] = 0; }
                        if (Convert.ToString(reader["IntervalAxSR"]) != null && Convert.ToString(reader["IntervalAxSR"]) != "" && Convert.ToString(reader["IntervalAxSR"]) != " ")
                        { BetOs[17, 8] = Convert.ToDouble(reader["IntervalAxSR"]); }
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
                    //if (reader["Class3"] != null && reader["Class3"].ToString() != "")
                    //{ NPicKR = Convert.ToInt64(reader["Class3"]); }
                    if (reader["Class3"] != DBNull.Value)
                    { NPicKR = Convert.ToInt64(reader["Class3"]); }
                    else
                    { NPicKR = 0; }
                    KolOs = Convert.ToInt32(reader["AxleCount"].ToString());
                    ObshMass = Convert.ToInt32(reader["Weight"].ToString());
                    alphaBlendTextBox13.Text = Convert.ToString(Math.Round(Convert.ToDouble(reader["AxleCount"].ToString())));
                    alphaBlendTextBox18.Text = alphaBlendTextBox13.Text;

                    if (reader["KlNew"].ToString().Length > 0)
                    {
                        alphaBlendTextBox11.Text = reader["KlNew"].ToString();
                        alphaBlendTextBox84.Text = reader["SubKateg"].ToString();
                    }
                    else
                    {

                        if (reader["Class2"].ToString().Length > 3) /*SUBSTR(allandnapr.Class2, 1, 2)*/
                        { alphaBlendTextBox11.Text = reader["Class2"].ToString().Substring(0, 2); alphaBlendTextBox84.Text = reader["Class2"].ToString().Substring(2); }// Convert.ToString(Math.Round(Convert.ToDouble(reader["Class"].ToString()))); }
                        else if (reader["Class2"].ToString().Length == 3)
                        { alphaBlendTextBox11.Text = reader["Class2"].ToString().Substring(0, 1); alphaBlendTextBox84.Text = reader["Class2"].ToString().Substring(1); }
                        else { alphaBlendTextBox11.Text = "12"; alphaBlendTextBox84.Text = "-"; }
                    }
                    alphaBlendTextBox19.Text = alphaBlendTextBox11.Text;
                    label18.Visible = true;
                    label18.Text = reader["PlatformId"].ToString();
                    ////if (Convert.ToInt64(reader["PlatformId"].ToString()) == 2952855555)
                    ////{ NRUB = "PK2"; }
                    ////else { NRUB = "PK1"; }
                    ////if (reader["Plate"].ToString() == "")
                    ////{ maskedTextBox1.Text = reader["PlateRear"].ToString(); }
                    ////else
                    ////{
                    ////    maskedTextBox1.Text = reader["Plate"].ToString();
                    ////}
                    ///
                    if (Convert.ToInt64(reader["PlatformId"].ToString()) == 2952855555)
                    { NRUB = "PK2"; }
                    else { NRUB = "PK1"; }
                    if (Convert.ToInt64(reader["PlatformId"].ToString()) == 2952855555)
                    { CPC = "2920002"; }
                    else if (Convert.ToInt64(reader["PlatformId"].ToString()) == 2952855553)
                    { CPC = "2920001"; }
                    else
                    { CPC = reader["PlatformId"].ToString(); }
                    if (reader["StatAng"].ToString() != "0")
                    {
                        GRZ = reader["OldGRZ"].ToString();
                        maskedTextBox1.Text = reader["OldGRZ"].ToString();
                        if (reader["PlateConfidence"].ToString() == "0")
                        { maskedTextBox1.Text = reader["PlateRear"].ToString(); }
                        else
                        { maskedTextBox1.Text = reader["Plate"].ToString(); }
                    }
                    else
                    {
                        if (reader["PlateConfidence"].ToString() == "0")
                        {
                            GRZ = reader["PlateRear"].ToString();
                            maskedTextBox1.Text = reader["PlateRear"].ToString();
                        }
                        else
                        {
                            GRZ = reader["Plate"].ToString();
                            maskedTextBox1.Text = reader["Plate"].ToString();
                        }
                    }

                    alphaBlendTextBox25.Text = reader["ID"].ToString();
                    alphaBlendTextBox80.Text = reader["Speed"].ToString();
                    alphaBlendTextBox16.Text = alphaBlendTextBox80.Text;
                    alphaBlendTextBox13.Text = reader["AxleCount"].ToString();
                    alphaBlendTextBox18.Text = alphaBlendTextBox13.Text;

                    alphaBlendTextBox26.Text = reader["datepr"].ToString().Substring(0, 10);
                    alphaBlendTextBox33.Text = reader["timepr"].ToString();
                    alphaBlendTextBox107.Text = reader["Created"].ToString();
                    Lpr = Convert.ToDecimal(reader["Length"].ToString());
                    Hpr = Convert.ToDecimal(reader["Width"].ToString());
                    Wpr = Convert.ToDecimal(reader["Height"].ToString());
                    Cl = Convert.ToInt32(reader["Class2"].ToString());
                    XDate[0] = reader["IsOverweightPartial"].ToString();
                    XDate[1] = reader["IsOverweight"].ToString();
                    XDate[2] = reader["IsExceededLength"].ToString();
                    XDate[3] = reader["IsExceededWidth"].ToString();
                    XDate[4] = reader["IsExceededHeight"].ToString();
                    label21.Text = reader["DateChang"].ToString();
                    label22.Text = reader["NameUs"].ToString();
                    label24.Text = reader["OldGRZ"].ToString();
                    label26.Text = reader["OldIDPR"].ToString();
                    label28.Text = reader["DateChang"].ToString();

                    if (reader["NamePDF"].ToString() != "")
                    { PDFN = reader["NamePDF"].ToString().Substring(0, 15); PDFName = reader["NamePDF"].ToString().Substring(17); }
                    else { PDFN = " "; PDFName = ""; }
                    UidANG = reader["UIDAng"].ToString();

                    if (Convert.ToString(reader["UIDAng"].ToString()) != "")
                    {
                        AngStat = 1; GDAng = Convert.ToString(reader["UIDAng"].ToString());
                    }

                    if (reader["Plate"].ToString() == "")
                    { label84.Text = reader["PlateRear"].ToString(); }
                    else
                    {
                        label84.Text = reader["Plate"].ToString();
                    }
                    CDD = Convert.ToDateTime(reader["Created"].ToString()).ToString("yyyyMMdd");
                    NLP = label84.Text.ToString();
                    DPR = Convert.ToDateTime(alphaBlendTextBox107.Text).ToString("yyyy.MM.dd HH:mm:ss");
                    alphaBlendTextBox53.Text = reader["nameapvk"].ToString();//Наименование комплекса
                    alphaBlendTextBox63.Text = reader["Vladel"].ToString();//Владелец комплекса
                    alphaBlendTextBox54.Text = reader["TipSI"].ToString();//Тип СИ комплекса
                    alphaBlendTextBox55.Text = reader["Model"].ToString();//Марка и модель комплекса
                    alphaBlendTextBox56.Text = reader["sernum"].ToString();//Заводской № комплекса
                    if (Convert.ToInt64(reader["kodapvk"].ToString()) == 2952855555)
                    { alphaBlendTextBox58.Text = "2920002"; }
                    else if (Convert.ToInt64(reader["kodapvk"].ToString()) == 2952855553)
                    { alphaBlendTextBox58.Text = "2920001"; }
                    else
                    { alphaBlendTextBox58.Text = reader["kodapvk"].ToString(); }
                    label1.Text = "";
                    Osh = 0;
                    if (reader["CredenceExceeded"].ToString() == "0"|| reader["CredenceExceeded"].ToString() == null)
                    { label1.Text = "Ошибок измерительного комплекса не обнаружено"; }
                    else if (reader["CredenceExceeded"].ToString() != "0" || reader["CredenceExceeded"].ToString()!= null)
                    {
                        Osh = Convert.ToInt32(reader["CredenceExceeded"].ToString());
                        //// перевод ошибок...........
                        string Oshib = Convert.ToString(Osh, 2);
                        if (Oshib != "0" && Oshib.Length > 9)
                        {
                            label1.Text = label1.Text.ToString() + "Ошибка на измерительном комплексе: ";
                            if (Oshib.Substring(Oshib.Length - 1) != "0")
                            { label1.Text = label1.Text.ToString() + " -не все данные были получены от датчиков;"; }
                            if (Convert.ToInt64(Oshib.Substring(Oshib.Length - 2)) > 9)
                            { label1.Text = label1.Text.ToString() + " -неравномерное движение ТС;"; }
                            if (Convert.ToInt64(Oshib.Substring(Oshib.Length - 3)) > 99)
                            { label1.Text = label1.Text.ToString() + " -размеры ТС выходит за допустимые пределы измерения;"; }
                            if (Convert.ToInt64(Oshib.Substring(Oshib.Length - 4)) > 999)
                            { label1.Text = label1.Text.ToString() + " -нагрузка на ось выходит за пределы измерения;"; }
                            if (Convert.ToInt64(Oshib.Substring(Oshib.Length - 5)) > 9999)
                            { label1.Text = label1.Text.ToString() + " -ошибка определения количества осей;"; }
                            if (Convert.ToInt64(Oshib.Substring(Oshib.Length - 6)) > 99999)
                            { label1.Text = label1.Text.ToString() + " -ошибка измерения межосевого расстояния;"; }
                            if (Convert.ToInt64(Oshib.Substring(Oshib.Length - 7)) > 999999)
                            { label1.Text = label1.Text.ToString() + " -ошибка измерения длины ТС;"; }
                            if (Convert.ToInt64(Oshib.Substring(Oshib.Length - 8)) > 9999999)
                            { label1.Text = label1.Text.ToString() + " -скорость ТС выходит за допустимые пределы измерения;"; }
                        }
                        else if (Oshib != "0" && Oshib.Length < 9)
                        {
                            label1.Text = label1.Text.ToString() + "Измерения транспортного средства не являются достоверными ";
                        }                       
                       ////.........................
                    }
                    if (maskedTextBox1.Text.ToString() == "" || maskedTextBox1.Text.ToString()==null)
                        {
                            label1.Text = label1.Text.ToString() + " Не распознан ГРЗ ТС";
                        }
                    alphaBlendTextBox1.Text = reader["Checksum"].ToString();
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
                    ////// ПО С/РАЗР ДАТА И НОМЕР ЗАПРОСА
                    
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
                    {
                        XDate[6] = "";
                        XDate[7] = "0";
                        XDate[8] = "False";
                    }
                    if (reader["SpeedRubej"].ToString() != "0")
                    {
                        XDate[6] = reader["SpeedRubej"].ToString();
                        if (Convert.ToDouble(reader["Speed"].ToString())-2 - Convert.ToDouble(reader["SpeedRubej"].ToString()) > 0)
                        {
                            XDate[7] = Convert.ToString(Convert.ToDouble(reader["Speed"].ToString())-2 - Convert.ToDouble(reader["SpeedRubej"].ToString()));
                            XDate[8] = "True";
                            SPEED_ALL[0] = "-2"; SPEED_ALL[1] = reader["Speed"].ToString(); SPEED_ALL[2] = Convert.ToString(Convert.ToDouble(reader["Speed"].ToString())-2);
                            SPEED_ALL[3] = reader["SpeedRubej"].ToString(); SPEED_ALL[6] = XDate[7].ToString();
                            SPEED_ALL[5] = Convert.ToString(Math.Round(Convert.ToDouble(reader["Speed"].ToString()) / Convert.ToDouble(reader["SpeedRubej"].ToString()) * 100 - 100, 0));
                        }
                        if (Convert.ToDouble(reader["Speed"].ToString()) - Convert.ToDouble(reader["SpeedRubej"].ToString()) <= 0)
                        {
                            XDate[7] = "0";
                            XDate[8] = "False";
                            SPEED_ALL[0] = "-2"; SPEED_ALL[1] = reader["Speed"].ToString(); SPEED_ALL[2] = Convert.ToString(Convert.ToDouble(reader["Speed"].ToString()) - 2);
                            SPEED_ALL[3] = reader["SpeedRubej"].ToString(); SPEED_ALL[6] = "-";
                            SPEED_ALL[5] = "-";
                        }
                    }
                    else
                    {
                        SPEED_ALL[0] = "-2"; SPEED_ALL[1] = reader["Speed"].ToString(); SPEED_ALL[2] = Convert.ToString(Convert.ToDouble(reader["Speed"].ToString()) - 2);
                        SPEED_ALL[3] = "-"; SPEED_ALL[6] = "-";
                        SPEED_ALL[5] = "-";
                    }
                    ///////////////////////////////// Данные о СР
                    if (reader["PriznNal"].ToString() == "0" || reader["PriznNal"].ToString() == "False" || reader["PriznNal"].ToString() == null || reader["PriznNal"].ToString() == "")
                    {
                        XDate[12] = "False";
                        if (reader["ChangeType"].ToString() != "17" && reader["ChangeType"].ToString() != "4")
                        { alphaBlendTextBox69.Text = "Не проверялось";}
                        else
                        { alphaBlendTextBox69.Text = "Не выдавалось";
                            //// ПО С/РАЗР ДАТА И НОМЕР ЗАПРОСА
                            alphaBlendTextBox109.Text = reader["DateZapr"].ToString();
                            alphaBlendTextBox108.Text = reader["NomZapr"].ToString();
                        }
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
                        SPEED_ALL[4] = "-";
                    }
                    else
                    {
                        XDate[12] = reader["PriznNal"].ToString();
                        alphaBlendTextBox69.Text = "Выдано";// XDate[12].ToString();
                        PrevNar[29] = 2;
                        XDate[13] = reader["NomSR"].ToString();
                        alphaBlendTextBox74.Text = XDate[13].ToString();
                        XDate[14] = reader["dateregsr"].ToString();
                        if (reader["VidPerevoz"].ToString() == "Local")
                        { alphaBlendTextBox71.Text = "региональная"; }
                        if (reader["VidPerevoz"].ToString() == "Interregional")
                        { alphaBlendTextBox71.Text = "межрегиональная"; }
                        if (reader["VidPerevoz"].ToString() == "International")
                        { alphaBlendTextBox71.Text = "международная"; }
                        alphaBlendTextBox72.Text = reader["GRZSR"].ToString();
                        alphaBlendTextBox76.Text = reader["RazrMarshr"].ToString();
                        alphaBlendTextBox77.Text = reader["OsjbUslDvSR"].ToString();
                        alphaBlendTextBox78.Text = reader["KolRazrPr"].ToString();
                        alphaBlendTextBox79.Text = reader["IspolzPR"].ToString();
                        alphaBlendTextBox83.Text = Convert.ToString(Convert.ToInt32(reader["OstatSR"].ToString())-1);
                        XDate[15] = reader["KemVid"].ToString();
                        alphaBlendTextBox70.Text = XDate[15].ToString();
                        XDate[16] = reader["DateVidSR"].ToString();
                        alphaBlendTextBox73.Text = XDate[16].ToString();//.Remove(11);
                        XDate[17] = reader["SrokDeistvSR"].ToString();
                        alphaBlendTextBox75.Text = XDate[17].ToString();//.Remove(11);
                        XDate[18] = reader["NarushenMarshrSR"].ToString();
                        XDate[19] = reader["LengthSR"].ToString();
                        XDate[20] = reader["WidthSR"].ToString();
                        XDate[21] = reader["HeightSR"].ToString();
                        if (reader["SpeedSR"].ToString() != "0")
                        {
                            SPEED_ALL[4] = reader["SpeedSR"].ToString();
                            if (Convert.ToDouble(reader["Speed"].ToString()) - 2 - Convert.ToDouble(reader["SpeedSR"].ToString()) > 0)
                            {
                                //XDate[7] = Convert.ToString(Convert.ToDouble(reader["Speed"].ToString()) - 2 - Convert.ToDouble(reader["SpeedRubej"].ToString()));
                                XDate[8] = "True";
                                SPEED_ALL[6] = Convert.ToString(Convert.ToDouble(reader["Speed"].ToString()) - 2 - Convert.ToDouble(reader["SpeedSR"].ToString()));
                                SPEED_ALL[5] = Convert.ToString(Math.Round(Convert.ToDouble(reader["Speed"].ToString()) / Convert.ToDouble(reader["SpeedSR"].ToString()) * 100 - 100, 0));
                            }
                            if (Convert.ToDouble(reader["Speed"].ToString()) - Convert.ToDouble(reader["SpeedSR"].ToString()) <= 0)
                            {
                                XDate[7] = "0";
                                XDate[8] = "False";
                                SPEED_ALL[6] = "-";
                                SPEED_ALL[5] = "-";
                            }
                        }

                        //// ПО С/РАЗР ДАТА И НОМЕР ЗАПРОСА
                        alphaBlendTextBox109.Text = reader["DateZapr"].ToString();
                        alphaBlendTextBox108.Text = reader["NomZapr"].ToString();
                    }
                    XDate[25] = ((Convert.ToDouble(reader["Weight"].ToString()) - (Convert.ToDouble(reader["Weight"].ToString()) / 100 * 5)) / 1000).ToString();
                    if (reader["RazrMassa"].ToString() != null && reader["RazrMassa"].ToString() != "" && reader["RazrMassa"].ToString() != " ")
                    { XDate[26] = reader["RazrMassa"].ToString(); }
                    else { XDate[26] = "0"; }                    
                    alphaBlendTextBox67.Text = reader["NormPravAktAD"].ToString();//Нормативн акт дороги
                    if (reader["ogranich"].ToString()!=" ")
                    { alphaBlendTextBox68.Text = reader["ogranich"].ToString(); }
                    else { alphaBlendTextBox68.Text = "-"; }
                     alphaBlendTextBox80.Text = "" + reader["Speed"].ToString() + " км/ч";// reader["velocity"].ToString();//скорость
                    alphaBlendTextBox16.Text = alphaBlendTextBox80.Text;
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

                    #endregion/////////////////////////////////////////////////}
                  
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
            //////pictureBox30.Visible = false;//скобка
            //////pictureBox41.Visible = false;//стрелка
            //////string s = label154.Text;
            //////double i;
            //////if (label154.Text != "")
            //////    i = Convert.ToDouble(s.ToString());//.Substring(0, 4));
            //////else i = 0;
            //////if (i > 0)
            //////{
            //////    double loc2 = 0;
            //////    string TO;
            //////   TO = "Общая длина ТС - " + Convert.ToDouble(s) + " м. " + "\n" + "Общий вес: " + Math.Round(Convert.ToDouble(ObshMass) / 1000, 3) + " т. ";
            //////    loc2 = 20 * i + 100;
            //////    int loc3 = Convert.ToInt32(loc2);
            //////    pictureBox30.Width = loc3 - 60;
            //////    int newloc = 57 + loc3 / 2;
            //////    pictureBox30.Location = new Point(350, 150);
            //////    double loc = Convert.ToDouble(label154.Text) * 100;
            //////    location = 57 + Convert.ToInt32(20 * loc / 100);
            //////    pictureBox41.Location = new Point(Convert.ToInt32(loc2) + 300, 120);
            //////    pictureBox41.Visible = true;
            //////    label142.Text = TO;
            //////    label142.Location = new Point((loc3 / 2 + 240), 175); //location / 2 + 90), 285);
            //////    label142.BackColor = Color.Transparent;
            //////    pictureBox30.Visible = true;
            //////    label142.Visible = true;
            //////}

            ////////////////////////////////////////////////// ПЕРВАЯ ОСЬ
            //////s = Convert.ToString(Convert.ToDouble(label171.Text.ToString()) * 1000);
            //////i = 0;
            //////if (label154.Text != "")
            //////{ i = Convert.ToInt32(s); }//Convert.ToInt32(znachenie); 
            //////else i = 0;
            //////if (i > 0)
            //////{
            //////    double loc = Convert.ToDouble(label154.Text) * 100;
            //////    location = 370 + Convert.ToInt32(20 * loc / 100);
            //////    pictureBox31.Location = new Point(location, 110);
            //////    pictureBox31.Image = AVGK.Properties.Resources._33777Ч1;
            //////    label171.Location = new Point(location, 138);
            //////    if ((i > 0) && (i < 9000))
            //////    {
            //////        if ((label153.Text != "") && (Convert.ToInt32(label153.Text) > 1))
            //////        { pictureBox31.Image = AVGK.Properties.Resources._33777Ч2; }
            //////        else if ((label153.Text != ""))
            //////        { pictureBox31.Image = AVGK.Properties.Resources._33777Ч1; }
            //////    }
            //////    else if ((i > 0) && (i > 9000))
            //////    {
            //////        if ((label153.Text != "") && (Convert.ToInt32(label153.Text) > 1))
            //////        { pictureBox31.Image = AVGK.Properties.Resources._33777К2; }
            //////        else if ((label153.Text != ""))
            //////        { pictureBox31.Image = AVGK.Properties.Resources._33777К1; }
            //////    }
            //////    pictureBox31.BringToFront();
            //////    pictureBox31.Visible = true;
            //////    label154.Visible = true;
            //////    label171.Visible = true;
            //////    label153.Visible = false;
            //////    label154.Visible = false; label144.Visible = false;
            //////}
            //////else
            //////{
            //////    label154.Visible = false;
            //////    label171.Visible = false;
            //////    label153.Visible = false;
            //////    label144.Visible = false;
            //////}

            ////////////////////////////////////////////////// ВТОРАЯ ОСЬ
            //////label152.Visible = true;
            //////s = Convert.ToString(Convert.ToDouble(label170.Text.ToString()) * 1000);
            //////i = 0;
            //////if (label170.Text != "")
            //////{
            //////    i = Convert.ToInt32(s);
            //////    if (i > 0)
            //////    {
            //////        double loc1 = 0;
            //////        loc1 = location - 20 - 20 * (l[1] * 100 + 40) / 100;// + 45;
            //////        int loc = Convert.ToInt32(Math.Round(loc1));
            //////        pictureBox32.Location = new Point(loc, 110);//50 + loc, 223);
            //////        double locLOs = location - 5 - (20 * (l[1] / 2 * 100 + 40)) / 100;// + 45;
            //////        int locL = Convert.ToInt32(Math.Round(locLOs));
            //////        label162.Location = new Point(locL, 90);
            //////        label170.Location = new Point(loc, 138);

            //////        if ((i > 0) && (i < 9000))
            //////        {
            //////            if ((label152.Text != "") && (Convert.ToInt32(label152.Text) > 1))
            //////            { pictureBox32.Image = AVGK.Properties.Resources._33777Ч2; }
            //////            else if ((label152.Text != ""))
            //////            { pictureBox32.Image = AVGK.Properties.Resources._33777Ч1; }
            //////        }
            //////        else if ((i > 0) && (i > 9000))
            //////        {
            //////            if ((label152.Text != "") && (Convert.ToInt32(label152.Text) > 1))
            //////            { pictureBox32.Image = AVGK.Properties.Resources._33777К2; }
            //////            else if ((label152.Text != ""))
            //////            { pictureBox32.Image = AVGK.Properties.Resources._33777К1; }
            //////        }
            //////        pictureBox32.BringToFront();
            //////        pictureBox32.Visible = true;
            //////        label162.Visible = true;
            //////        label170.Visible = true;
            //////        label152.Visible = false;
            //////    }
            //////    else
            //////    {
            //////        label162.Visible = false;
            //////        label170.Visible = false;
            //////        label152.Visible = false;
            //////    }
            //////}
            //////else
            //////{
            //////    i = 0;
            //////    label162.Visible = false;
            //////    label170.Visible = false;
            //////    pictureBox32.Visible = false;
            //////}
            ////////////////////////////////////////////////// ТРЕТЬЯ ОСЬ
            //////s = Convert.ToString(Convert.ToDouble(label169.Text.ToString()) * 1000);
            //////i = 0;
            //////if (label169.Text != "")
            //////{
            //////    i = Convert.ToInt32(s);
            //////    if (i > 0)
            //////    {
            //////        label151.Visible = true;
            //////        double loc1 = 0;
            //////        loc1 = location - 40 - (20 * ((l[2] + l[1]) * 100 + 40) / 100);
            //////        int loc = Convert.ToInt32(Math.Round(loc1));
            //////        pictureBox33.Location = new Point(loc, 110);
            //////        double locLOs = location - 30 - (20 * ((l[1] + l[2] / 2) * 100 + 40)) / 100;
            //////        int locL = Convert.ToInt32(Math.Round(locLOs));
            //////        label161.Location = new Point(locL, 90);
            //////        label169.Location = new Point(loc, 138);

            //////        if ((i > 0) && (i < 9000))
            //////        {
            //////            if ((label151.Text != "") && (Convert.ToInt32(label151.Text) > 1))
            //////            { pictureBox33.Image = AVGK.Properties.Resources._33777Ч2; }
            //////            else if (label151.Text != "")
            //////            { pictureBox33.Image = AVGK.Properties.Resources._33777Ч1; }
            //////        }
            //////        else if ((i > 0) && (i > 9000))
            //////        {
            //////            if ((label151.Text != "") && (Convert.ToInt32(label151.Text) > 1))
            //////            { pictureBox33.Image = AVGK.Properties.Resources._33777К2; }
            //////            else if (label151.Text != "")
            //////            { pictureBox33.Image = AVGK.Properties.Resources._33777К1; }
            //////        }
            //////        pictureBox33.BringToFront();
            //////        pictureBox33.Visible = true;
            //////        label161.Visible = true;
            //////        label169.Visible = true;
            //////        label151.Visible = false;
            //////    }
            //////    else
            //////    {
            //////        label161.Visible = false;
            //////        label169.Visible = false;
            //////        label151.Visible = false;
            //////    }
            //////}
            //////else
            //////{
            //////    i = 0;
            //////    label161.Visible = false;
            //////    label169.Visible = false;
            //////    pictureBox33.Visible = false;
            //////}
            //////////////////////////////////////////////////// ЧЕТВЕРТАЯ ОСЬ
            //////s = Convert.ToString(Convert.ToDouble(label168.Text.ToString()) * 1000);
            //////i = 0;
            //////if (label168.Text != "")
            //////{
            //////    i = Convert.ToInt32(s);
            //////    if (i > 0)
            //////    {
            //////        label150.Visible = true;
            //////        double loc1 = 0;
            //////        loc1 = location - 40 - (20 * ((l[3] + l[2] + l[1]) * 100 + 40) / 100);
            //////        int loc = Convert.ToInt32(Math.Round(loc1));
            //////        pictureBox34.Location = new Point(loc, 110);
            //////        double locLOs = location - 40 - (20 * ((l[1] + l[2] + l[3] / 2) * 100 + 40)) / 100;
            //////        int locL = Convert.ToInt32(Math.Round(locLOs));
            //////        label160.Location = new Point(locL, 90);
            //////        label168.Location = new Point(loc, 138);

            //////        if ((i > 0) && (i < 9000))
            //////        {
            //////            if ((label150.Text != "") && (Convert.ToInt32(label150.Text) > 1))
            //////            { pictureBox34.Image = AVGK.Properties.Resources._33777Ч2; }
            //////            else if (label150.Text != "")
            //////            { pictureBox34.Image = AVGK.Properties.Resources._33777Ч1; }
            //////        }
            //////        else if ((i > 0) && (i > 9000))
            //////        {
            //////            if ((label150.Text != "") && (Convert.ToInt32(label150.Text) > 1))
            //////            { pictureBox34.Image = AVGK.Properties.Resources._33777К2; }
            //////            else if (label150.Text != "")
            //////            { pictureBox34.Image = AVGK.Properties.Resources._33777К1; }
            //////        }
            //////        pictureBox34.BringToFront();
            //////        pictureBox34.Visible = true;
            //////        label160.Visible = true;
            //////        label168.Visible = true;
            //////        label150.Visible = false;
            //////    }
            //////    else
            //////    {
            //////        label160.Visible = false;
            //////        label168.Visible = false;
            //////        label150.Visible = false;
            //////    }
            //////}
            //////else
            //////{
            //////    i = 0;
            //////    label160.Visible = false;
            //////    label168.Visible = false;
            //////    pictureBox33.Visible = false;
            //////}

            ////////////////////////////////////////////////// ПЯТАЯ ОСЬ
            //////s = Convert.ToString(Convert.ToDouble(label167.Text.ToString()) * 1000);
            //////i = 0;
            //////if (label167.Text != "")
            //////{
            //////    i = Convert.ToInt32(s);
            //////    if (i > 0)
            //////    {
            //////        label149.Visible = true;
            //////        double loc1 = 0;
            //////        loc1 = location - 40 - (20 * ((l[1] + l[2] + l[3] + l[4]) * 100 + 40) / 100);
            //////        int loc = Convert.ToInt32(Math.Round(loc1));
            //////        pictureBox35.Location = new Point(loc, 110);
            //////        double locLOs = location - 40 - (20 * ((l[1] + l[2] + l[3] + l[4] / 2) * 100 + 40)) / 100;
            //////        int locL = Convert.ToInt32(Math.Round(locLOs));
            //////        label159.Location = new Point(locL, 90);
            //////        label167.Location = new Point(loc, 138);

            //////        if ((i > 0) && (i < 9000))
            //////        {
            //////            if ((label149.Text != "") && (Convert.ToInt32(label149.Text) > 1))
            //////            { pictureBox35.Image = AVGK.Properties.Resources._33777Ч2; }
            //////            else if (label149.Text != "")
            //////            { pictureBox35.Image = AVGK.Properties.Resources._33777Ч1; }
            //////        }
            //////        else if ((i > 0) && (i > 9000))
            //////        {
            //////            if ((label149.Text != "") && (Convert.ToInt32(label149.Text) > 1))
            //////            { pictureBox35.Image = AVGK.Properties.Resources._33777К2; }
            //////            else if (label149.Text != "")
            //////            { pictureBox35.Image = AVGK.Properties.Resources._33777К1; }
            //////        }
            //////        pictureBox35.BringToFront();
            //////        pictureBox35.Visible = true;
            //////        label159.Visible = true;
            //////        label167.Visible = true;
            //////        label149.Visible = false;
            //////    }
            //////    else
            //////    {
            //////        label159.Visible = false;
            //////        label167.Visible = false;
            //////        label149.Visible = false;
            //////    }
            //////}
            //////else
            //////{
            //////    i = 0;
            //////    label159.Visible = false;
            //////    label167.Visible = false;
            //////    pictureBox33.Visible = false;
            //////}

            ////////////////////////////////////////////////// ШЕСТАЯ ОСЬ
            //////s = Convert.ToString(Convert.ToDouble(label166.Text.ToString()) * 1000);
            //////i = 0;
            //////if (label166.Text != "")
            //////{
            //////    i = Convert.ToInt32(s);
            //////    if (i > 0)
            //////    {
            //////        label148.Visible = true;
            //////        double loc1 = 0;
            //////        loc1 = location - 40 - (20 * ((l[1] + l[2] + l[3] + l[4] + l[5]) * 100 + 40) / 100);
            //////        int loc = Convert.ToInt32(Math.Round(loc1));
            //////        pictureBox36.Location = new Point(loc, 110);
            //////        double locLOs = location - 40 - (20 * ((l[1] + l[2] + l[3] + l[4] + l[5] / 2) * 100 + 40)) / 100;
            //////        int locL = Convert.ToInt32(Math.Round(locLOs));
            //////        label158.Location = new Point(locL, 90);
            //////        label166.Location = new Point(loc, 138);

            //////        if ((i > 0) && (i < 9000))
            //////        {
            //////            if ((label148.Text != "") && (Convert.ToInt32(label148.Text) > 1))
            //////            { pictureBox36.Image = AVGK.Properties.Resources._33777Ч2; }
            //////            else if (label148.Text != "")
            //////            { pictureBox36.Image = AVGK.Properties.Resources._33777Ч1; }
            //////        }
            //////        else if ((i > 0) && (i > 9000))
            //////        {
            //////            if ((label148.Text != "") && (Convert.ToInt32(label148.Text) > 1))
            //////            { pictureBox36.Image = AVGK.Properties.Resources._33777К2; }
            //////            else if (label148.Text != "")
            //////            { pictureBox36.Image = AVGK.Properties.Resources._33777К1; }
            //////        }
            //////        pictureBox36.BringToFront();
            //////        pictureBox36.Visible = true;
            //////        label158.Visible = true;
            //////        label166.Visible = true;
            //////        label148.Visible = false;
            //////    }
            //////    else
            //////    {
            //////        label158.Visible = false;
            //////        label166.Visible = false;
            //////        label148.Visible = false;
            //////    }
            //////}
            //////else
            //////{
            //////    i = 0;
            //////    label158.Visible = false;
            //////    label166.Visible = false;
            //////    pictureBox33.Visible = false;
            //////}

            ////////////////////////////////////////////////// СЕДЬМАЯ ОСЬ
            //////s = Convert.ToString(Convert.ToDouble(label165.Text.ToString()) * 1000);
            //////i = 0;
            //////if (label165.Text != "")
            //////{
            //////    i = Convert.ToInt32(s);
            //////    if (i > 0)
            //////    {
            //////        label147.Visible = true;
            //////        double loc1 = 0;
            //////        loc1 = location - 40 - (20 * ((l[1] + l[2] + l[3] + l[4] + l[5] + l[6]) * 100 + 40) / 100);
            //////        int loc = Convert.ToInt32(Math.Round(loc1));
            //////        pictureBox37.Location = new Point(loc, 110);
            //////        double locLOs = location - 40 - (20 * ((l[1] + l[2] + l[3] + l[4] + l[5] + l[6] / 2) * 100 + 40)) / 100;
            //////        int locL = Convert.ToInt32(Math.Round(locLOs));
            //////        label157.Location = new Point(locL, 90);
            //////        label165.Location = new Point(loc, 138);

            //////        if ((i > 0) && (i < 9000))
            //////        {
            //////            if ((label147.Text != "") && (Convert.ToInt32(label147.Text) > 1))
            //////            { pictureBox37.Image = AVGK.Properties.Resources._33777Ч2; }
            //////            else if (label147.Text != "")
            //////            { pictureBox37.Image = AVGK.Properties.Resources._33777Ч1; }
            //////        }
            //////        else if ((i > 0) && (i > 9000))
            //////        {
            //////            if ((label147.Text != "") && (Convert.ToInt32(label147.Text) > 1))
            //////            { pictureBox37.Image = AVGK.Properties.Resources._33777К2; }
            //////            else if (label147.Text != "")
            //////            { pictureBox37.Image = AVGK.Properties.Resources._33777К1; }
            //////        }
            //////        pictureBox37.BringToFront();
            //////        pictureBox37.Visible = true;
            //////        label157.Visible = true;
            //////        label165.Visible = true;
            //////        label147.Visible = false;
            //////    }
            //////    else
            //////    {
            //////        label157.Visible = false;
            //////        label165.Visible = false;
            //////        label147.Visible = false;
            //////    }
            //////}
            //////else
            //////{
            //////    i = 0;
            //////    label157.Visible = false;
            //////    label165.Visible = false;
            //////    pictureBox33.Visible = false;
            //////}
            ////////////////////////////////////////////////// ВОСЬМАЯ ОСЬ
            //////s = Convert.ToString(Convert.ToDouble(label164.Text.ToString()) * 1000);
            //////i = 0;
            //////if (label164.Text != "")
            //////{
            //////    i = Convert.ToInt32(s);
            //////    if (i > 0)
            //////    {
            //////        label146.Visible = true;
            //////        double loc1 = 0;
            //////        loc1 = location - 40 - (20 * ((l[1] + l[2] + l[3] + l[4] + l[5] + l[6] + l[7]) * 100 + 40) / 100);
            //////        int loc = Convert.ToInt32(Math.Round(loc1));
            //////        pictureBox38.Location = new Point(loc, 110);
            //////        double locLOs = location - 40 - (20 * ((l[1] + l[2] + l[3] + l[4] + l[5] + l[6] + l[7] / 2) * 100 + 40)) / 100;
            //////        int locL = Convert.ToInt32(Math.Round(locLOs));
            //////        label156.Location = new Point(locL, 90);
            //////        label164.Location = new Point(loc, 138);

            //////        if ((i > 0) && (i < 9000))
            //////        {
            //////            if ((label146.Text != "") && (Convert.ToInt32(label146.Text) > 1))
            //////            { pictureBox38.Image = AVGK.Properties.Resources._33777Ч2; }
            //////            else if (label146.Text != "")
            //////            { pictureBox38.Image = AVGK.Properties.Resources._33777Ч1; }
            //////        }
            //////        else if ((i > 0) && (i > 9000))
            //////        {
            //////            if ((label146.Text != "") && (Convert.ToInt32(label146.Text) > 1))
            //////            { pictureBox38.Image = AVGK.Properties.Resources._33777К2; }
            //////            else if (label146.Text != "")
            //////            { pictureBox38.Image = AVGK.Properties.Resources._33777К1; }
            //////        }
            //////        pictureBox38.BringToFront();
            //////        pictureBox38.Visible = true;
            //////        label156.Visible = true;
            //////        label164.Visible = true;
            //////        label146.Visible = false;
            //////    }
            //////    else
            //////    {
            //////        label156.Visible = false;
            //////        label164.Visible = false;
            //////        label146.Visible = false;
            //////    }
            //////}
            //////else
            //////{
            //////    i = 0;
            //////    label156.Visible = false;
            //////    label164.Visible = false;
            //////    pictureBox33.Visible = false;
            //////}
            ////////////////////////////////////////////////// ДЕВЯТАЯ ОСЬ
            //////s = Convert.ToString(Convert.ToDouble(label163.Text.ToString()) * 1000);
            //////i = 0;
            //////if (label163.Text != "")
            //////{
            //////    i = Convert.ToInt32(s);
            //////    if (i > 0)
            //////    {
            //////        label145.Visible = true;
            //////        double loc1 = 0;
            //////        loc1 = location - 40 - (20 * ((l[1] + l[2] + l[3] + l[4] + l[5] + l[6] + l[7] + l[8]) * 100 + 40) / 100);
            //////        int loc = Convert.ToInt32(Math.Round(loc1));
            //////        pictureBox39.Location = new Point(loc, 110);
            //////        double locLOs = location - 40 - (20 * ((l[1] + l[2] + l[3] + l[4] + l[5] + l[6] + l[7] + l[8] / 2) * 100 + 40)) / 100;
            //////        int locL = Convert.ToInt32(Math.Round(locLOs));
            //////        label155.Location = new Point(locL, 90);
            //////        label163.Location = new Point(loc, 138);

            //////        if ((i > 0) && (i < 9000))
            //////        {
            //////            if ((label145.Text != "") && (Convert.ToInt32(label145.Text) > 1))
            //////            { pictureBox39.Image = AVGK.Properties.Resources._33777Ч2; }
            //////            else if (label145.Text != "")
            //////            { pictureBox39.Image = AVGK.Properties.Resources._33777Ч1; }
            //////        }
            //////        else if ((i > 0) && (i > 9000))
            //////        {
            //////            if ((label145.Text != "") && (Convert.ToInt32(label145.Text) > 1))
            //////            { pictureBox39.Image = AVGK.Properties.Resources._33777К2; }
            //////            else if (label145.Text != "")
            //////            { pictureBox39.Image = AVGK.Properties.Resources._33777К1; }
            //////        }
            //////        pictureBox39.BringToFront();
            //////        pictureBox39.Visible = true;
            //////        label155.Visible = true;
            //////        label163.Visible = true;
            //////        label145.Visible = false;
            //////    }
            //////    else
            //////    {
            //////        label155.Visible = false;
            //////        label163.Visible = false;
            //////        label145.Visible = false;
            //////    }
            //////}
            //////else
            //////{
            //////    i = 0;
            //////    label155.Visible = false;
            //////    label163.Visible = false;
            //////    pictureBox33.Visible = false;
            //////}
            #endregion              ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



            Puti[19] = System.Windows.Forms.SystemInformation.ComputerName.ToString();
            ///////////////////////////////////////////////////////////////////////////////

            MySqlCommand command2 = new MySqlCommand();
            ConnectStr conStr2 = new ConnectStr();
            conStr2.ConStr(1);
            Zapros zapros2 = new Zapros();
            string connectionString2;//, commandString;
            connectionString2 = conStr2.StP;//"Data source=localhost;UserId=root;Password=1q2w3e$R;database=camloc;";
            MySqlConnection connection2 = new MySqlConnection(connectionString2);
            zapros2.NastrPuti(0, Puti[19]);
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
                        Puti[0] = reader2["IDPut"].ToString();
                        Puti[1] = reader2["Rab_mesto"].ToString();
                        Puti[2] = reader2["Photo"].ToString();
                        Puti[3] = reader2["XML_Ang"].ToString();
                        Puti[4] = reader2["Akt_Arch"].ToString();
                        Puti[5] = reader2["CompName"].ToString();
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
            ////////////////////////////////////////////////////////////////////////////////


            MySqlCommand commandLB11 = new MySqlCommand();
            ConnectStr conStrLB11 = new ConnectStr();
            conStrLB11.ConStr(1);
            Zapros zaprosLB11 = new Zapros();
            string connectionStringLB11;//, commandString;
            connectionStringLB11 = conStrLB11.StP;//"Data source=localhost;UserId=root;Password=1q2w3e$R;database=camloc;";
            MySqlConnection connectionLB11 = new MySqlConnection(connectionStringLB11);
            zaprosLB11.CB(IDpish);
            zLB = zaprosLB11.commandStringTest;
            commandLB11.CommandText = zLB;// commandString;
            commandLB11.Connection = connectionLB11;
            MySqlDataReader readerLB11;
            try
            {
                commandLB11.Connection.Open();
                readerLB11 = commandLB11.ExecuteReader();
                 while (readerLB11.Read())
                {
                    ColPicKR = Convert.ToInt32(readerLB11["CB"]);
                }
            
                                readerLB11.Close();
        }
                            catch (MySqlException ex)
                            {
                                Console.WriteLine("Error: \r\n{0}", ex.ToString());
                            }
                            finally
                            {
                                commandLB11.Connection.Close();
                            }


                    if (Puti[5] == "" || Puti[5] != Puti[19])
            {
                MessageBox.Show("Внимание! \n У Вас не настроены пути подключения к базе данных! \n Обратитесь к системному администратору", "ВНИМАНИЕ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                zLB = "SELECT " +
           "binarycontainer_n.*, " +
           "binarycontainer_n.ID_PR " +
           "FROM binarycontainer_n " +
           "WHERE binarycontainer_n.ID_PR = " + IDW + " AND platformid = " + PLN + ";";
            
                        MySqlCommand commandLB = new MySqlCommand();
                        ConnectStr conStrLB = new ConnectStr();
                        conStrLB.ConStr(1);
                        Zapros zaprosLB = new Zapros();
                        string connectionStringLB;//, commandString;
                        connectionStringLB = conStrLB.StP;//"Data source=localhost;UserId=root;Password=1q2w3e$R;database=camloc;";
                        MySqlConnection connectionLB = new MySqlConnection(connectionStringLB);
                          commandLB.CommandText = zLB;// commandString;
                            commandLB.Connection = connectionLB;
                            MySqlDataReader readerLB;
                            try
                            {
                                commandLB.Connection.Open();
                                readerLB = commandLB.ExecuteReader();
                   while (readerLB.Read())
                    {

                        if (readerLB["name"].ToString() != "Video")
                                    {
                                        if (readerLB["name"].ToString() == "Image")
                                        {
                                            if (Puti[5] == "WIN-D3J6PR1H9QK")
                                            { st9 = readerLB["dataavailable"].ToString(); }
                                            else { st9 = @"" + Puti[2] + "" + readerLB["dataavailable"].ToString().Substring(13, readerLB["dataavailable"].ToString().Length - 13); }
                                            Im = new Bitmap(@"" + st9); ImNN = st9;

                            }
                                        if (readerLB["name"].ToString() == "ImgPlate")
                                        {
                                            if (Puti[5] == "WIN-D3J6PR1H9QK")
                                            {st9 = readerLB["dataavailable"].ToString(); }
                                            else { st9 = @"" + Puti[2] + "" + readerLB["dataavailable"].ToString().Substring(13, readerLB["dataavailable"].ToString().Length - 13); }
                                            pictureBox29.Image = new Bitmap(@"" + st9);
                                            ImPl = new Bitmap(@"" + st9); ImPlN = st9;
                            }
                                        if (readerLB["name"].ToString() == "ImageAlt")
                                        {
                                            if (Puti[5] == "WIN-D3J6PR1H9QK")
                                            { st9 = readerLB["dataavailable"].ToString(); }
                                            else { st9 = @"" + Puti[2] + "" + readerLB["dataavailable"].ToString().Substring(13, readerLB["dataavailable"].ToString().Length - 13); }
                                            ImAlt = new Bitmap(@"" + st9); ImAltN = st9;
                            }
                                        if (readerLB["name"].ToString() == "ImgObj")
                                         {
                                            if (Puti[5] == "WIN-D3J6PR1H9QK")
                                            { st9 = readerLB["dataavailable"].ToString(); }
                                            else { st9 = @"" + Puti[2] + "" + readerLB["dataavailable"].ToString().Substring(13, readerLB["dataavailable"].ToString().Length - 13); }
                                            ImObj = new Bitmap(@"" + st9); ImObjN = st9;
                            }

                            if (readerLB["name"].ToString() == "ReaPlate")
                            {
                                if (Puti[5] == "WIN-D3J6PR1H9QK")
                                { st9 = readerLB["dataavailable"].ToString(); }
                                else { st9 = @"" + Puti[2] + "" + readerLB["dataavailable"].ToString().Substring(13, readerLB["dataavailable"].ToString().Length - 13); }
                                if (pictureBox29.Image == null)
                                {
                                    pictureBox29.Image = new Bitmap(@"" + st9);
                                    label98.Text = "Внимание! Распознавание ГРЗ проведено по заднему ГРЗ. Фотофиксация переднего ГРЗ отсутствует...";
                                    label98.Visible = true;
                                }
                            }
                                if (Puti[5] == "WIN-D3J6PR1H9QK")
                            { st9 = readerLB["dataavailable"].ToString(); }
                            else { st9 = @"" + Puti[2] + "" + readerLB["dataavailable"].ToString().Substring(13, readerLB["dataavailable"].ToString().Length - 13); }
                            IIm = IIm + 1;
                            ImN[IIm] = new Bitmap(@"" + st9);
                            PicCount = PicCount + 1;
                                    }
                                    else
                                    {
                            if (Puti[5] == "WIN-D3J6PR1H9QK")
                            { st9 = readerLB["dataavailable"].ToString(); }
                            else { st9 = @"X:\" + readerLB["dataavailable"].ToString().Substring(13, readerLB["dataavailable"].ToString().Length - 13); }//st9 = @"" + Puti[2] + "" + readerLB["dataavailable"].ToString().Substring(13, readerLB["dataavailable"].ToString().Length - 13); }
                            label42.Visible = false; 
                            WMPl1.URL = @"" + st9.Remove(st9.LastIndexOf("_")) + ".avi";//@"" + st9;//@"C:\Video\Lame.avi";
                            PicCount = PicCount + 1;
                                    }
                                }
                    pictureBox40.Image = ImN[1];
                    if (pictureBox29.Image == null)
                    {
                        label98.Text = "Фотофиксация ГРЗ отсутствует...";
                        label98.Visible = true;
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

            #region От старой программы - позже к этому вернемся
            #region ///// Заполнение переменных о выбранном проезде для определения класса и расчета ПДК :)
           AC = new int[KolOs];
            if (KolOs != 0)
            {
                AI = new decimal[(KolOs)];// - 1)];
            }
            //AI = new decimal[(KolOs - 1)];
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
                if (ic <= 9)
                {
                    if (l[ic] > 0)
                    {
                        D[ic] = (l[ic] + 0.03);
                        if(D[ic]<2.5 && D[ic-1] > 0 && D[ic] - D[ic-1] < 0.8 && D[ic] > 2.36)
                        { D[ic] = D[ic] + (2.5 - D[ic]); }
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
                                    {
                                        TypO[ic] = 1;
                                    }
                                    else if (D[ic - 1] > 0 && D[ic - 1] < 2.5)
                                    {
                                        if (D[ic - 2] > 0 && D[ic - 2] < 2.5)
                                        {
                                            TypO[ic] = 3;
                                            TypO[ic - 1] = 3;
                                            TypO[ic - 2] = 3;
                                        }
                                        else
                                        {
                                            TypO[ic] = 2; TypO[ic - 1] = 2;
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
                                //if (D[ic - 1] >= 2.50)
                                //{
                                //    if (D[ic] == 0)
                                //    { TypO[ic] = 1; TypO[ic - 1] = 1; break; }
                                //    else
                                //    { TypO[ic] = 2; }
                                //}
                                //else if (D[ic - 1] > 0 && D[ic - 1] < 2.50)
                                //{
                                if (D[ic - 1] >= 2.50)
                                {
                                    if (D[ic] == 0)
                                    {
                                        if (D[ic - 2] > 0 && D[ic - 2] < 2.50)
                                        {
                                            TypO[ic] = 1; break;
                                        }
                                        else
                                        { TypO[ic] = 1; TypO[ic - 1] = 1; break; }
                                    }
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
                                            else { TypO[ic] = 4; TypO[ic - 1] = 4; TypO[ic - 2] = 4; TypO[ic - 3] = 4; }
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
            for (i = 1; i < KolOs + 1; i++)
            {
                AC[i - 1] = Convert.ToInt32(DoubO[i] * 2);
            }
            for (ic = KolOs + 1; ic <= 9; ic++)
            {
                D[ic] = 0;
                DoubO[ic] = 0;
                TypO[ic] = 0;
            }
           
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
                }
            }
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
                        names3[ic].BaseDistance = Convert.ToString(Math.Round(BetOs[3, ic],3));
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
                        if (Math.Round((BetOs[3, ic] + 0.03), 2) >= 2.5)
                        {
                            GrO = GrO + 1;
                            dataGridView1[3, ic].Value = Math.Round(BetOs[3, ic], 3);
                            dataGridView1[1, ic].Value = GrO;
                            dataGridView1[4, ic].Value = Math.Round((BetOs[3, ic] + 0.03), 3);
                            dataGridView1[5, ic].Value = (Math.Round(BetOs[5, ic] / 1000, 3));
                            dataGridView1[6, ic].Value = (Math.Round(BetOs[6, ic] / 1000, 3));
                            dataGridView1[7, ic].Value = (Math.Round(BetOs[4, ic] / 1000, 3));
                            dataGridView1[8, ic].Value = (Math.Round((BetOs[4, ic] - BetOs[4, ic] / 100 * 10) / 1000, 3));

                        }
                        else if (Math.Round((BetOs[3, ic] + 0.03), 2) >= 2.5)
                        {
                            KGr = KGr + 1;
                            dataGridView1[3, ic].Value = Math.Round(BetOs[3, ic], 3);
                            dataGridView1[1, ic - 1].Value = GrO;
                            dataGridView1[1, ic].Value = GrO;
                            dataGridView1[4, ic].Value = Math.Round((BetOs[3, ic] + 0.03), 3);
                            dataGridView1[5, ic].Value = (Math.Round(BetOs[5, ic] / 1000, 3));
                            dataGridView1[6, ic].Value = (Math.Round(BetOs[6, ic] / 1000, 3));
                            dataGridView1[7, ic].Value = (Math.Round(BetOs[4, ic] / 1000, 2));
                            dataGridView1[8, ic].Value = (Math.Round((BetOs[4, ic] - BetOs[4, ic] / 100 * 10) / 1000, 3));
                        }
                        else
                        {
                            if (Math.Round((BetOs[3, ic] + 0.03), 2) < 2.5 && Math.Round((BetOs[3, ic-1] + 0.03), 2) > 0 && Math.Round((BetOs[3, ic] + 0.03), 2) - Math.Round((BetOs[3, ic-1] + 0.03), 2) < 0.8 && Math.Round((BetOs[3, ic] + 0.03), 2) > 2.36)
                            {
                                GrO = GrO + 1;
                                dataGridView1[3, ic].Value = Math.Round(BetOs[3, ic], 3);
                                dataGridView1[1, ic].Value = GrO;
                                dataGridView1[4, ic].Value = Math.Round((BetOs[3, ic] + 0.03), 3);
                            dataGridView1[5, ic].Value = (Math.Round(BetOs[5, ic] / 1000, 3));
                            dataGridView1[6, ic].Value = (Math.Round(BetOs[6, ic] / 1000, 3));
                            dataGridView1[7, ic].Value = (Math.Round(BetOs[4, ic] / 1000, 3));
                            dataGridView1[8, ic].Value = (Math.Round((BetOs[4, ic] - BetOs[4, ic] / 100 * 10) / 1000, 3));
                        }
                            else
                            {
                                KGr = KGr + 1;
                                dataGridView1[3, ic].Value = Math.Round((BetOs[3, ic]), 3);
                                dataGridView1[1, ic - 1].Value = GrO;
                                dataGridView1[1, ic].Value = GrO;
                                dataGridView1[4, ic].Value = Math.Round((BetOs[3, ic] + 0.03), 3);
                                dataGridView1[5, ic].Value = (Math.Round(BetOs[5, ic] / 1000, 3));
                                dataGridView1[6, ic].Value = (Math.Round(BetOs[6, ic] / 1000, 3));
                                dataGridView1[7, ic].Value = (Math.Round(BetOs[4, ic] / 1000, 3));
                                dataGridView1[8, ic].Value = (Math.Round((BetOs[4, ic] - BetOs[4, ic] / 100 * 10) / 1000, 3));
                            }
                           }
                    }
                    else
                    {
                        GrO = GrO + 1;
                        dataGridView1[1, ic].Value = GrO;
                        dataGridView1[3, ic].Value = "-";
                        dataGridView1[4, ic].Value = "-";
                        dataGridView1[5, ic].Value = (Math.Round(BetOs[5, ic] / 1000, 3));
                        dataGridView1[6, ic].Value = (Math.Round(BetOs[6, ic] / 1000, 3));
                        dataGridView1[7, ic].Value = (Math.Round(BetOs[4, ic] / 1000, 3));
                        dataGridView1[8, ic].Value = (Math.Round((BetOs[4, ic] - BetOs[4, ic] / 100 * 10) / 1000, 3));
                       }
                    if (Convert.ToDouble(dataGridView1[11, ic].Value) < 0)
                    { dataGridView1[11, ic].Value = 0; }
                }
            }
            #endregion  ////////////////////////////////////////////////////////////////////////////////////

            #region/////////////////////////////////////////            заполнение таблицы групп осей

            if (GrO > 0)
            {
                dataGridView2.RowCount = GrO;
                KN[1, 0] = Convert.ToInt32(TypO[1]);
                KN[0, 0] = 1;
                /////////////////////////////////////////////       Заполняем первую строку ///////////////////////////////////////////////////
                if (KN[1, 0] == 1)
                {
                    dataGridView2[0, 0].Value = 1;
                    dataGridView2[1, 0].Value = TypO[1];
                    Sk = Convert.ToInt32(Math.Truncate(BetOs[8, 0])) + "/" + (Convert.ToInt32(Math.Truncate(BetOs[8, 0]))) * 2;
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
                    if (D1_2 % 2 == 0)
                    {
                        Sk = D1_2 / TypO[1] + "/" + (D1_2 * 2) / TypO[1];
                    }
                    else
                    {
                        D1_2 = D1_2 - 1;
                        Sk = D1_2 / TypO[1] + "/" + (D1_2 * 2) / TypO[1];
                    }
                    dataGridView2[2, 0].Value = Sk;
                    dataGridView2[3, 0].Value = Math.Round(D5_6 / (TypO[1] - 1),3);// BetOs[3, 0];
                    dataGridView2[4, 0].Value = Math.Round((D5_6 / (TypO[1] - 1) + 0.03),3) ;
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
                    int b = 0;
                    foreach (double c in TypO)
                    {          
                        if (Convert.ToInt32(c) == 4)
                        { b = b + 1; }
                    }
                    if (Convert.ToInt32(TypO[Fx]) == 4)
                    {
                        KN[1, ic] = b;
                    }
                    else
                    { 
                        KN[1, ic] = Convert.ToInt32(TypO[Fx]);//Количество
                    }
                    KN[0, ic] = Fx; //Позиция                            
                }
                //////////////////////////////////////////////////////////////////////

                for (ic = 1; ic < GrO; ic++)
                {
                    if (KN[1, ic] == 1)
                    {
                        dataGridView2[0, ic].Value = ic + 1;
                        dataGridView2[1, ic].Value = KN[1, ic]; //TypO[KN[0, ic]];
                        Sk = Convert.ToInt32(BetOs[8, ic]) + "/" + Convert.ToInt32(BetOs[8, ic] * 2);
                        dataGridView2[2, ic].Value = Sk;
                        dataGridView2[3, ic].Value = Math.Round(BetOs[3, KN[0, ic] - 1],3);
                        dataGridView2[4, ic].Value = Math.Round((BetOs[3, KN[0, ic] - 1] + 0.03),3) ;
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
                        dataGridView2[1, ic].Value = KN[1, ic]; //TypO[KN[0, ic]];
                        Sk = (Math.Truncate(Math.Floor(Convert.ToInt32(D1_2) / TypO[KN[0, ic]]))) + "/" + Math.Truncate(Math.Floor((Convert.ToInt32(D1_2) / TypO[KN[0, ic]])) * 2);
                        dataGridView2[2, ic].Value = Sk;

                      if (KN[1, ic] > 2)
                        {
                            dataGridView2[3, ic].Value = Math.Round(D5_6 / (KN[1, ic] - 1), 3);//TypO[KN[0, ic]] - 1),3);// BetOs[3, 0];
                            dataGridView2[4, ic].Value = Math.Round((D5_6 / (KN[1, ic] - 1) + 0.03), 3);//TypO[KN[0, ic]] - 1) + 0.03),3);
                        }
                        else
                        {
                            dataGridView2[3, ic].Value = Math.Round(D5_6,3);// BetOs[3, 0];
                            dataGridView2[4, ic].Value = Math.Round((D5_6 + 0.03),3);
                        }
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
            DSIstIzm = new DataSet();
            DSIstIzm1 = new DataSet();
            ConnectStr conStrIzm = new ConnectStr();
            Zapros zaprosIzm = new Zapros();
            conStrIzm.ConStr(1);
            zaprosIzm.ZaprIstIzm(IDW);
            connectionIzm = new MySqlConnection(conStrIzm.StP);
            MySqlDataAdapterizm = new MySqlDataAdapter(zaprosIzm.commandStringTest, connectionIzm);
            MySqlDataAdapterizm.Fill(DSIstIzm);
            dataGridView3.DataSource = DSIstIzm.Tables[0];
            dataGridView3.Columns[0].Visible = false;//
            dataGridView3.Columns[3].Visible = false;
            dataGridView3.Columns[5].Visible = false;
            dataGridView3.Columns[7].Visible = false;
            dataGridView3.Columns[1].Visible = false;
            dataGridView3.Columns[2].Visible = false;
            dataGridView3.Columns[6].Visible = false;
            dataGridView3.Columns[8].Visible = false;
            dataGridView3.Columns[10].Visible = false;
           connectionIzm.Close();
             int RC = dataGridView3.Rows.Count;
            if (RC == 0)
            {
                if (label1.Text == "Ошибка измерений")
                {
                    label11.Visible = true;
                    label122.Text = "Ошибка измерений на комплексе. \n Изменений статуса не было";
                }
                else
                {
                    label11.Visible = true;
                    label122.Text = "Изменений статуса не было";
                }
            }
            else {
                label11.Visible = false;
                label122.Text = dataGridView3[4, RC-1].Value.ToString(); ;
            }

            for (int icr = 0; icr < RC - 1; icr++) //цикл             
            {
                if (dataGridView3[3, icr].Value.ToString() == "16")//days > 9000)
                {
                    label122.Text = dataGridView3[4, icr].Value.ToString();
                    if (label122.Text == "AUTO")
                    {
                        label122.Text = "Автоматическая система";
                    }
                }
            }
           
            for (int icr = 0; icr < RC - 1; icr++) //цикл             
            {
                if (dataGridView3[3, icr].Value.ToString() == "1") // 16  тут замени на нужное!!!
                {
                    label20.Visible = false;
                    label21.Visible = false;
                    label22.Visible = false;
                    label23.Visible = false;
                    label24.Visible = false;
                    label25.Visible = false;
                    label26.Visible = false;
                    label27.Visible = false;
                    label28.Visible = false;
                    label29.Visible = false;
                    label84.Visible = false;
                    label85.Visible = false;
                }
            }
            if (label84.Text!="")
            {
                ConnectStr conStrIzm1 = new ConnectStr();
                Zapros zaprosIzm1 = new Zapros();
                conStrIzm1.ConStr(1);
                zaprosIzm1.StatSR(maskedTextBox1.Text.ToString());
                connectionIzm1 = new MySqlConnection(conStrIzm1.StP);
                MySqlDataAdapterizm1 = new MySqlDataAdapter(zaprosIzm1.commandStringTest, connectionIzm1);
                MySqlDataAdapterizm1.Fill(DSIstIzm1);
                dataGridView4.DataSource = DSIstIzm1.Tables[0];
                connectionIzm.Close();
            }
        }
       
        #endregion /////////////////////////////////// Длина межосев  //////////////////////////////////////////


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
                    pictureBox40.Image = ImObj;
                }
                if (iPic == 5)
                {
                    iPic = iPic - 1;
                    pictureBox40.Image = null;
                    pictureBox40.Image = ImREA;
                }
                if (iPic == 6)
                {
                    iPic = iPic - 1;
                    pictureBox40.Image = null;
                    pictureBox40.Image = ImPlREA;
                }
                if (iPic == 7)
                {
                    iPic = iPic - 1;
                    pictureBox40.Image = null;
                    pictureBox40.Image = ImAltREA;
                }
                if (iPic == 8)
                {
                    iPic = iPic - 1;
                    pictureBox40.Image = null;
                    pictureBox40.Image = ImObjREA;
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
                    pictureBox40.Image = ImObj;
                }
                if (iPic == 6)
                {
                    iPic = iPic + 1;
                    pictureBox40.Image = null;
                    pictureBox40.Image = ImREA;
                }
                if (iPic == 5)
                {
                    iPic = iPic + 1;
                    pictureBox40.Image = null;
                    pictureBox40.Image = ImPlREA;
                }
                if (iPic == 4)
                {
                    iPic = iPic + 1;
                    pictureBox40.Image = null;
                    pictureBox40.Image = ImAltREA;
                }
                if (iPic == 3)
                {
                    iPic = iPic + 1;
                    pictureBox40.Image = null;
                    pictureBox40.Image = ImObjREA;
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
        #endregion/////////////////////////////////////////////
        
        private void pictureBox40_Click(object sender, EventArgs e)
        {
            if (this.pictureBox40.Image != null)
            {
                if (Form2.SelfRef.iz == 1)
                {
                    FormPic newfrm = new FormPic(this.pictureBox40.Image);
                    newfrm.Show();
                }
            }
        }
        

        #endregion/////////////////////////////////////////////  

        #region/////////////////////////////////////////////   загрузка фото в LEFT часть  
        public void ZPHOTOLEFT()
        {
            if (KnPriv == 0)
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
        
        private void label62_Click(object sender, EventArgs e)
        {
            this.Close();
        }       
        private void button4_Click(object sender, EventArgs e)
        {
            #region ////////////////////////////////////// Запрос XML для АНГЕЛОВ    ////////////////////////////////
            if (maskedTextBox1.Text != "" && (XDate[31] == "True" || XDate[30] == "True" || XDate[2] == "True" || XDate[4] == "True" || XDate[3] == "True") && Im != null && TypNar > 0)//&& ImPl,ImAlt )
            {
                try
                {
                    XNamespace rpvk1 = "urn:smtp-violation";
                    XDocument doc = new XDocument(
                    new XElement("CaseData",
                    new XAttribute(XNamespace.Xmlns + "xsi", "http://www.w3.org/2001/XMLSchema-instance"),
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
            new XElement("StateNumber", maskedTextBox1.Text.ToString()),
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
                    if (Puti[5] == "WIN-D3J6PR1H9QK")
                    { doc.Save(@"F:\\archiv\\AKT\\" + GDAng.ToString() + ".xml"); }//@"F:\archiv\AKT\" + NRUB + "_" + alphaBlendTextBox25.Text + "_" + DateTime.Now.ToString("ddMMyyyy") + ".xml"); }
                    else { doc.Save(@"" + Puti[3] + GDAng.ToString() + ".xml"); }//NRUB + "_" + alphaBlendTextBox25.Text + "_" + DateTime.Now.ToString("ddMMyyyy") + ".xml"); }
                        PDF();
                        if (Puti[5] == "WIN-D3J6PR1H9QK")
                        {
                            string aaa = @"F:\\archiv\\AKT\\" + DateTime.Now.ToString("dd_MM_yyyy");
                            string bbb = @"F:\\archivACT\\act\\" + DateTime.Now.ToString("dd_MM_yyyy");
                            CopyFolderYesterdayFiles(@"F:\\archiv\\AKT\\", aaa, bbb, GDAng.ToString(), IDW.ToString(), PLN.ToString(), CDD.ToString(), PT5);
                        }
                        //aaa = @"F:\\archiv\\AKT\\" + DateTime.Now.ToString("dd_MM_yyyy"); }
                        else
                        {
                            string aaa = @"" + Puti[3] + DateTime.Now.ToString("dd_MM_yyyy");
                            string bbb = @"" + Puti[4] + DateTime.Now.ToString("dd_MM_yyyy");
                            CopyFolderYesterdayFiles(@"" + Puti[3], aaa, bbb, GDAng.ToString(), IDW.ToString(), PLN.ToString(), CDD.ToString(), PT5);
                            //aaa = @"" + Puti[3] + DateTime.Now.ToString("dd_MM_yyyy");
                        }
                        //if (Puti[5] == "WIN-D3J6PR1H9QK")
                        //{ CopyFolderYesterdayFiles(@"F:\\archiv\\AKT\\", aaa); }
                        //else { CopyFolderYesterdayFiles(@""+Puti[3], aaa); }

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
                        MessageBox.Show("XML файл успешно сохранен.", "Выполнено.");
                    }
                catch
                {
                    MessageBox.Show("Невозможно сохранить XML файл.", "Ошибка.");
                }
            }
            else { MessageBox.Show("Невозможно выполнить отправку файлов (не все данные корректны, либо не хватает данных).", "Ошибка."); }
            #endregion ////////////////////////////////////////////////////////////////     ////////////////////////////////
        }

        static void CopyFolderYesterdayFiles(string sourceFolder, string destFolder, string destFolderM, string GAng, string IW, string PL, string DPR, string PT5)
        {
            ////////////////////////////////////////////////////////////////////////////////////////  О Б Я З А Т Е Л Ь Н О !!!  ПОМЕНЯТЬ ПУТЬ НА Ф
            DateTime YesterdayDate = DateTime.Today.Date;

            //////if (PT5 == "WIN-D3J6PR1H9QK")
            //////{
            DirectoryInfo dirInfo = new DirectoryInfo(@"F:\\archiv\\AKT\\");
            //////}
            //////else
            //////{
            //////DirectoryInfo dirInfo = new DirectoryInfo(@"Y:\\");
            //////}
            if (!Directory.Exists(destFolder))
            {
                Directory.CreateDirectory(destFolder);
            }
            //FileInfo[] files = dirInfo.GetFiles("" + GAng.ToString() + ".xml");//.AddDays(-1).ToString("yyyyMMdd") + "_*.xml");//sourceFolder);

            //DirectoryInfo directory = new DirectoryInfo(@"F:\\archiv\\AKT\\" + YesterdayDate.ToString("ddMMyyyy"));//file => file.LastWriteTime.Date == YesterdayDate );

            //foreach (FileInfo file in files)
            //    File.Delete(Path.Combine(destFolder, file.Name));

            //foreach (FileInfo file in files)
            //    File.Copy(file.FullName, Path.Combine(destFolder, file.Name));

            //string[] folders = Directory.GetDirectories(sourceFolder);

            //foreach (FileInfo file in files)
            //    File.Delete(file.FullName);

            if (!Directory.Exists(destFolderM))
            {
                Directory.CreateDirectory(destFolderM);
            }

            FileInfo[] filesM = dirInfo.GetFiles("" + GAng.ToString() + ".pdf");
            DirectoryInfo directoryM = new DirectoryInfo(@"X:\\act\\" + YesterdayDate.ToString("dd_MM_yyyy"));//file => file.LastWriteTime.Date == YesterdayDate );
            //DirectoryInfo directoryM = new DirectoryInfo(@"F:\\archivACT\\act\\" + YesterdayDate.ToString("dd_MM_yyyy"));//file => file.LastWriteTime.Date == YesterdayDate );
            //foreach (FileInfo file in filesM)
            //    File.Delete(Path.Combine(destFolderM, file.Name));
            foreach (FileInfo file in filesM)
                File.Copy(file.FullName, Path.Combine(destFolderM, file.Name));

            string[] foldersM = Directory.GetDirectories(sourceFolder);

            foreach (FileInfo file in filesM)
                File.Delete(file.FullName);

            ////////////////FileInfo[] filesP = dirInfo.GetFiles("" + GAng.ToString() + ".pdf");//*_" + DateTime.Today.Date.ToString("ddMMyyyy") + ".pdf");//.AddDays(-1).ToString("yyyyMMdd") + "_*.xml");//sourceFolder);

            ////////////////DirectoryInfo directoryP = new DirectoryInfo(@"F:\\archiv\\AKT\\" + YesterdayDate.ToString("ddMMyyyy"));//file => file.LastWriteTime.Date == YesterdayDate );

            ////////////////foreach (FileInfo file in filesP)
            ////////////////    File.Delete(Path.Combine(destFolder, file.Name));

            ////////////////foreach (FileInfo file in filesP)
            ////////////////    File.Copy(file.FullName, Path.Combine(destFolder, file.Name));

            ////////////////string[] foldersP = Directory.GetDirectories(sourceFolder);

            ////////////////foreach (FileInfo file in filesP)
            ////////////////    File.Delete(file.FullName);
            ////////public void CopyFolderYesterdayFiles(string sourceFolder, string destFolder)
            ////////{
            ////////    DateTime YesterdayDate = DateTime.Today.Date;
            ////////DirectoryInfo dirInfo;
            ////////    if (Puti[5] == "WIN-D3J6PR1H9QK")
            ////////    { dirInfo = new DirectoryInfo(@"F:\\archiv\\AKT\\"); }
            ////////    else { dirInfo = new DirectoryInfo(@"" + Puti[3]); }

            ////////    if (!Directory.Exists(destFolder))
            ////////    {
            ////////        Directory.CreateDirectory(destFolder);
            ////////    }
            ////////    FileInfo[] files = dirInfo.GetFiles("*_" + DateTime.Today.Date.ToString("ddMMyyyy") + ".xml");//.AddDays(-1).ToString("yyyyMMdd") + "_*.xml");//sourceFolder);
            ////////    DirectoryInfo directory;
            ////////    if (Puti[5] == "WIN-D3J6PR1H9QK")
            ////////    { directory = new DirectoryInfo(@"F:\\archiv\\AKT\\" + YesterdayDate.ToString("ddMMyyyy")); }
            ////////    else { directory = new DirectoryInfo(@"" + Puti[3] + YesterdayDate.ToString("ddMMyyyy")); }
            ////////    foreach (FileInfo file in files)
            ////////        File.Copy(file.FullName, Path.Combine(destFolder, file.Name));

            ////////    string[] folders = Directory.GetDirectories(sourceFolder);

            ////////    foreach (FileInfo file in files)
            ////////        File.Delete(file.FullName);

            ////////    FileInfo[] filesP = dirInfo.GetFiles("*_" + DateTime.Today.Date.ToString("ddMMyyyy") + ".pdf");//.AddDays(-1).ToString("yyyyMMdd") + "_*.xml");//sourceFolder);
            ////////    DirectoryInfo directoryP;
            ////////    if (Puti[5] == "WIN-D3J6PR1H9QK")
            ////////    { directoryP = new DirectoryInfo(@"F:\\archiv\\AKT\\" + YesterdayDate.ToString("ddMMyyyy")); }
            ////////    else { directoryP = new DirectoryInfo(@"" + Puti[3] + YesterdayDate.ToString("ddMMyyyy")); }
            ////////    foreach (FileInfo file in filesP)
            ////////        File.Copy(file.FullName, Path.Combine(destFolder, file.Name));
            ////////    string[] foldersP = Directory.GetDirectories(sourceFolder);
            ////////    foreach (FileInfo file in filesP)
            ////////        File.Delete(file.FullName);
            ////////    FileInfo[] filesI = dirInfo.GetFiles("*_" + DateTime.Today.Date.ToString("ddMMyyyy") + "_*.Jpeg");//.AddDays(-1).ToString("yyyyMMdd") + "_*.xml");//sourceFolder);
            ////////    DirectoryInfo directoryI;
            ////////    if (Puti[5] == "WIN-D3J6PR1H9QK")
            ////////    { directoryI = new DirectoryInfo(@"F:\\archiv\\AKT\\" + YesterdayDate.ToString("ddMMyyyy")); }
            ////////    else { directoryI = new DirectoryInfo(@"" + Puti[3] + YesterdayDate.ToString("ddMMyyyy")); }
            ////////    foreach (FileInfo file in filesI)
            ////////        File.Copy(file.FullName, Path.Combine(destFolder, file.Name));
            ////////    string[] foldersI = Directory.GetDirectories(sourceFolder);
            ////////    foreach (FileInfo file in filesI)
            ////////        File.Delete(file.FullName);
        }        
        private void button5_Click(object sender, EventArgs e)//// Создаем новый PDF документ
        {
            ////////if (checkBox1.Checked == true)
            ////////{
            ////////    PT5 = Puti[5];
            ////////    //////////////////////////////////////////
            ////////    //   формируем ГУИД для ангелов если его нет
            ////////    if (AngStat == 0)
            ////////    {
            ////////        AngStat = 1;
            ////////        INAng = Guid.NewGuid();
            ////////        GDAng = Convert.ToString(INAng);//.Replace("-", "");
            ////////        DateTime YesterdayDateA = DateTime.Today.Date;
            ////////        NamPD = @"F:\\archivACT\\act\\" + YesterdayDateA.ToString("dd_MM_yyyy") + @"\\" + GDAng.ToString() + ".pdf";

            ////////        MySqlCommand command3 = new MySqlCommand();
            ////////        ConnectStr conStr3 = new ConnectStr();
            ////////        Zapros zapros3 = new Zapros();
            ////////        conStr3.ConStr(1);
            ////////        cstr = conStr3.StP;
            ////////        zapros3.ZUIDAng(IDTS1, GDAng, NamPD);
            ////////        MySqlConnection connection3 = new MySqlConnection(cstr);
            ////////        MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
            ////////        string z3 = zapros3.commandStringTest;
            ////////        cmd.CommandText = z3;
            ////////        cmd.Connection = connection3;
            ////////        connection3.Open();
            ////////        cmd.ExecuteNonQuery();
            ////////        connection3.Close();

            ////////    }

            ////////    if (PDFN.ToString() != @"F:\archivACT\ac")
            ////////    {
            ////////        string PPDF = "";
            ////////        if (Puti[5] == "WIN-D3J6PR1H9QK")
            ////////        { /*PPDF=(@"F:\\archivACT\\act\\" + NRUB + "_" + alphaBlendTextBox25.Text + "_" + DateTime.Now.ToString("ddMMyyyy") + ".pdf");*/
            ////////            string folderPath = @"F:\\archivACT\\act\\";
            ////////            DirectoryInfo dir = new DirectoryInfo(folderPath);
            ////////            FileInfo[] files = dir.GetFiles(NRUB + "_" + alphaBlendTextBox25.Text + "_*", SearchOption.TopDirectoryOnly);
            ////////            if (files.Length > 0)
            ////////            {
            ////////                foreach (var item in files)
            ////////                {
            ////////                    PPDF = (@"" + item.FullName);
            ////////                    FormZAGR newfrm = new FormZAGR();
            ////////                    newfrm.Show();
            ////////                    Process.Start(@"" + PPDF);
            ////////                    System.Threading.Thread.Sleep(4000);
            ////////                    newfrm.Close();
            ////////                }
            ////////            }
            ////////            else
            ////////            {
            ////////                PPDF = (@"F:\\archivACT\\act\\" + NRUB + "_" + alphaBlendTextBox25.Text + "_" + DateTime.Now.ToString("ddMMyyyy") + ".pdf");
            ////////                PDF();
            ////////                string aaa = @"F:\\archiv\\AKT\\" + DateTime.Now.ToString("dd_MM_yyyy");
            ////////                string bbb = @"F:\\archivACT\\act\\" + DateTime.Now.ToString("dd_MM_yyyy");
            ////////                CopyFolderYesterdayFiles(@"F:\\archiv\\AKT\\", aaa, bbb, GDAng.ToString(), IDW.ToString(), PLN.ToString(), CDD.ToString(), PT5);
            ////////                Process.Start(@"" + PPDF);
            ////////            }
            ////////        }
            ////////        else
            ////////        { /*PPDF=(@"" + Puti[4] + NRUB + "_" + alphaBlendTextBox25.Text + "_" + DateTime.Now.ToString("ddMMyyyy") + ".pdf");*/
            ////////            string folderPath = @"" + Puti[4];
            ////////            DirectoryInfo dir = new DirectoryInfo(folderPath);
            ////////            FileInfo[] files = dir.GetFiles(NRUB + "_" + alphaBlendTextBox25.Text + "_*", SearchOption.TopDirectoryOnly);
            ////////            if (files.Length > 0)
            ////////            {
            ////////                foreach (var item in files)
            ////////                {
            ////////                    PPDF = (@"" + item.FullName);
            ////////                    FormZAGR newfrm = new FormZAGR();
            ////////                    newfrm.Show();
            ////////                    Process.Start(@"" + PPDF);
            ////////                    System.Threading.Thread.Sleep(4000);
            ////////                    newfrm.Close();
            ////////                }
            ////////            }
            ////////            else
            ////////            {
            ////////                PDF();
            ////////                string aaa = @"Y:\\" + DateTime.Now.ToString("dd_MM_yyyy");
            ////////                string bbb = @"X:\\act\\" + DateTime.Now.ToString("dd_MM_yyyy");
            ////////                CopyFolderYesterdayFiles(@"X:\\", aaa, bbb, GDAng.ToString(), IDW.ToString(), PLN.ToString(), CDD.ToString(), PT5);

            ////////                PPDF = (@"" + Puti[4] + DateTime.Now.ToString("dd_MM_yyyy") + @"\\" + GDAng.ToString() + ".pdf");
            ////////                Process.Start(@"" + PPDF);
            ////////                //PPDF = (@"" + Puti[4] + NRUB + "_" + alphaBlendTextBox25.Text + "_" + DateTime.Now.ToString("ddMMyyyy") + ".pdf");
            ////////                //PDF();
            ////////                //string aaa = @"F:\\archiv\\AKT\\" + DateTime.Now.ToString("dd_MM_yyyy");
            ////////                //string bbb = @"F:\\archivACT\\act\\" + DateTime.Now.ToString("dd_MM_yyyy");
            ////////                //CopyFolderYesterdayFiles(@"F:\\archiv\\AKT\\", aaa, bbb, GDAng.ToString(), IDW.ToString(), PLN.ToString(), CDD.ToString(), PT5);
            ////////                //Process.Start(@"" + PPDF);
            ////////            }

            ////////        }
            ////////    }
            ////////    else
            ////////    {
            ////////        string PPDF = "";
            ////////        if (Puti[5] == "WIN-D3J6PR1H9QK")
            ////////        { /*PPDF=(@"F:\\archivACT\\act\\" + NRUB + "_" + alphaBlendTextBox25.Text + "_" + DateTime.Now.ToString("ddMMyyyy") + ".pdf");*/
            ////////            string folderPath = @"F:\\archivACT\\act\\" + alphaBlendTextBox26.Text.Replace(".", "_") + @"\\";
            ////////            DirectoryInfo dir = new DirectoryInfo(folderPath);
            ////////            FileInfo[] files = dir.GetFiles(UidANG + "*", SearchOption.TopDirectoryOnly);
            ////////            if (files.Length > 0)
            ////////            {
            ////////                foreach (var item in files)
            ////////                {
            ////////                    PPDF = (@"" + item.FullName);
            ////////                    FormZAGR newfrm = new FormZAGR();
            ////////                    newfrm.Show();
            ////////                    Process.Start(@"" + PPDF);
            ////////                    System.Threading.Thread.Sleep(4000);
            ////////                    newfrm.Close();
            ////////                }
            ////////            }
            ////////            else
            ////////            {
            ////////                PPDF = (@"F:\\archivACT\\act\\" + NRUB + "_" + alphaBlendTextBox25.Text + "_" + DateTime.Now.ToString("ddMMyyyy") + ".pdf");
            ////////                PDF();
            ////////                string aaa = @"F:\\archiv\\AKT\\" + DateTime.Now.ToString("dd_MM_yyyy");
            ////////                string bbb = @"F:\\archivACT\\act\\" + DateTime.Now.ToString("dd_MM_yyyy");
            ////////                CopyFolderYesterdayFiles(@"F:\\archiv\\AKT\\", aaa, bbb, GDAng.ToString(), IDW.ToString(), PLN.ToString(), CDD.ToString(), PT5);
            ////////                Process.Start(@"" + PPDF);
            ////////            }
            ////////        }
            ////////        else
            ////////        { /*PPDF=(@"" + Puti[4] + NRUB + "_" + alphaBlendTextBox25.Text + "_" + DateTime.Now.ToString("ddMMyyyy") + ".pdf");*/
            ////////            string folderPath = @"X:\act\" + alphaBlendTextBox26.Text.Replace(".", "_") + @"\\";
            ////////            DirectoryInfo dir = new DirectoryInfo(folderPath);
            ////////            FileInfo[] files = dir.GetFiles(UidANG + "*", SearchOption.TopDirectoryOnly);
            ////////            //09_10_2018\";// + Puti[4];
            ////////            //                    DirectoryInfo dir = new DirectoryInfo(folderPath);
            ////////            //                    FileInfo[] files = dir.GetFiles("ec2f0d15-9f27-437f-9b45-835b5bf8f1f6.pdf", SearchOption.TopDirectoryOnly);//NRUB + "_" + alphaBlendTextBox25.Text + "_*", SearchOption.TopDirectoryOnly);
            ////////            if (files.Length > 0)
            ////////            {
            ////////                foreach (var item in files)
            ////////                {
            ////////                    PPDF = (@"" + item.FullName);
            ////////                    FormZAGR newfrm = new FormZAGR();
            ////////                    newfrm.Show();
            ////////                    Process.Start(@"" + PPDF);
            ////////                    System.Threading.Thread.Sleep(4000);
            ////////                    newfrm.Close();
            ////////                }
            ////////            }
            ////////            else
            ////////            {
            ////////                //PPDF = (@"" + Puti[4] + UidANG + ".pdf");
            ////////                PDF();
            ////////                string aaa = @"Y:\\" + DateTime.Now.ToString("dd_MM_yyyy");
            ////////                string bbb = @"X:\\act\\" + DateTime.Now.ToString("dd_MM_yyyy");
            ////////                CopyFolderYesterdayFiles(@"X:\\", aaa, bbb, GDAng.ToString(), IDW.ToString(), PLN.ToString(), CDD.ToString(), PT5);

            ////////                PPDF = (@"" + Puti[4] + DateTime.Now.ToString("dd_MM_yyyy") + "\\" + GDAng.ToString() + ".pdf");
            ////////                Process.Start(@"" + PPDF);
            ////////            }

            ////////        }

            ////////    }
            ////////}
            ////////else
            ////////{
                PT5 = Puti[5];
                //////////////////////////////////////////
                //   формируем ГУИД для ангелов если его нет
                if (AngStat == 0)
                {
                    AngStat = 1;
                    INAng = Guid.NewGuid();
                    GDAng = Convert.ToString(INAng);//.Replace("-", "");
                    DateTime YesterdayDateA = DateTime.Today.Date;
                    NamPD = @"F:\\archivACT\\act\\" + YesterdayDateA.ToString("dd_MM_yyyy") + @"\\" + GDAng.ToString() + ".pdf";

                    MySqlCommand command3 = new MySqlCommand();
                    ConnectStr conStr3 = new ConnectStr();
                    Zapros zapros3 = new Zapros();
                    conStr3.ConStr(1);
                    cstr = conStr3.StP;
                    zapros3.ZUIDAng(IDTS1, GDAng, NamPD);
                    MySqlConnection connection3 = new MySqlConnection(cstr);
                    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
                    string z3 = zapros3.commandStringTest;
                    cmd.CommandText = z3;
                    cmd.Connection = connection3;
                    connection3.Open();
                    cmd.ExecuteNonQuery();
                    connection3.Close();

                }

                if (PDFN.ToString() != @"F:\archivACT\ac")
                {
                    string PPDF = "";
                    if (Puti[5] == "WIN-D3J6PR1H9QK")
                    { /*PPDF=(@"F:\\archivACT\\act\\" + NRUB + "_" + alphaBlendTextBox25.Text + "_" + DateTime.Now.ToString("ddMMyyyy") + ".pdf");*/
                        string folderPath = @"F:\\archivACT\\act\\";
                        DirectoryInfo dir = new DirectoryInfo(folderPath);
                    PPDF = (@"" + folderPath + DateTime.Now.ToString("dd_MM_yyyy") + @"\\" + GDAng.ToString() + ".pdf");
                    //Process.Start(@"" + PPDF);

                    //FileInfo[] files = dir.GetFiles(NRUB + "_" + alphaBlendTextBox25.Text + "_*", SearchOption.TopDirectoryOnly);
                    //    if (files.Length > 0)
                    //    {
                    //        foreach (var item in files)
                    //        {
                    //            PPDF = (@"" + item.FullName);
                    //            FormZAGR newfrm = new FormZAGR();
                    //            newfrm.Show();
                    //            Process.Start(@"" + PPDF);
                    //            System.Threading.Thread.Sleep(4000);
                    //            newfrm.Close();
                    //        }
                    //    }
                    //    else
                    //    {
                        PPDF = (@"" + folderPath + DateTime.Now.ToString("dd_MM_yyyy") + @"\\" + GDAng.ToString() + ".pdf");
                        //Process.Start(@"" + PPDF);
                        //PPDF = (@"F:\\archivACT\\act\\" + NRUB + "_" + alphaBlendTextBox25.Text + "_" + DateTime.Now.ToString("ddMMyyyy") + ".pdf");
                            PDF();
                            //string aaa = @"F:\\archiv\\AKT\\" + DateTime.Now.ToString("dd_MM_yyyy");
                            //string bbb = @"F:\\archivACT\\act\\" + DateTime.Now.ToString("dd_MM_yyyy");
                            //CopyFolderYesterdayFiles(@"F:\\archiv\\AKT\\", aaa, bbb, GDAng.ToString(), IDW.ToString(), PLN.ToString(), CDD.ToString(), PT5);
                            Process.Start(@"" + PPDF);
                        //}
                    }
                    else
                    { /*PPDF=(@"" + Puti[4] + NRUB + "_" + alphaBlendTextBox25.Text + "_" + DateTime.Now.ToString("ddMMyyyy") + ".pdf");*/
                        //string folderPath = @"" + Puti[4] + PDFName;
                        //DirectoryInfo dir = new DirectoryInfo(folderPath);
                        //FileInfo[] files = dir.GetFiles(NRUB + "_" + alphaBlendTextBox25.Text + "_*", SearchOption.TopDirectoryOnly);
                        //if (files.Length > 0)
                        //{
                        //    foreach (var item in files)
                        //    {
                        //        PPDF = (@"" + item.FullName);
                        //        FormZAGR newfrm = new FormZAGR();
                        //        newfrm.Show();
                        //        Process.Start(@"" + PPDF);
                        //        System.Threading.Thread.Sleep(4000);
                        //        newfrm.Close();
                        //    }
                        //}
                        //else
                        //{
                            PDF();
                            //string aaa = @"Y:\\" + DateTime.Now.ToString("dd_MM_yyyy");
                            //string bbb = @"X:\\act\\" + DateTime.Now.ToString("dd_MM_yyyy");
                            //CopyFolderYesterdayFiles(@"X:\\", aaa, bbb, GDAng.ToString(), IDW.ToString(), PLN.ToString(), CDD.ToString(), PT5);

                            PPDF = (@"" + Puti[4] + DateTime.Now.ToString("dd_MM_yyyy") + @"\\" + GDAng.ToString() + ".pdf");
                            Process.Start(@"" + PPDF);
                            //PPDF = (@"" + Puti[4] + NRUB + "_" + alphaBlendTextBox25.Text + "_" + DateTime.Now.ToString("ddMMyyyy") + ".pdf");
                            //PDF();
                            //string aaa = @"F:\\archiv\\AKT\\" + DateTime.Now.ToString("dd_MM_yyyy");
                            //string bbb = @"F:\\archivACT\\act\\" + DateTime.Now.ToString("dd_MM_yyyy");
                            //CopyFolderYesterdayFiles(@"F:\\archiv\\AKT\\", aaa, bbb, GDAng.ToString(), IDW.ToString(), PLN.ToString(), CDD.ToString(), PT5);
                            //Process.Start(@"" + PPDF);
                        //}

                    }
                }
                else
                {
                    string PPDF = "";
                    if (Puti[5] == "WIN-D3J6PR1H9QK")
                    { /*PPDF=(@"F:\\archivACT\\act\\" + NRUB + "_" + alphaBlendTextBox25.Text + "_" + DateTime.Now.ToString("ddMMyyyy") + ".pdf");*/
                        string folderPath = @"F:\\archivACT\\act\\" + alphaBlendTextBox26.Text.Replace(".", "_") + @"\\";
                        DirectoryInfo dir = new DirectoryInfo(folderPath);
                        FileInfo[] files = dir.GetFiles(UidANG + "*", SearchOption.TopDirectoryOnly);
                        if (files.Length > 0)
                        {
                            foreach (var item in files)
                            {
                                PPDF = (@"" + item.FullName);
                                FormZAGR newfrm = new FormZAGR();
                                newfrm.Show();
                                Process.Start(@"" + PPDF);
                                System.Threading.Thread.Sleep(4000);
                                newfrm.Close();
                            }
                        }
                        else
                        {
                            PPDF = (@"F:\\archivACT\\act\\" + NRUB + "_" + alphaBlendTextBox25.Text + "_" + UidANG +  ".pdf");
                            PDF();
                            //string aaa = @"F:\\archiv\\AKT\\" + DateTime.Now.ToString("dd_MM_yyyy");
                            //string bbb = @"F:\\archivACT\\act\\" + DateTime.Now.ToString("dd_MM_yyyy");
                            //CopyFolderYesterdayFiles(@"F:\\archiv\\AKT\\", aaa, bbb, GDAng.ToString(), IDW.ToString(), PLN.ToString(), CDD.ToString(), PT5);
                            Process.Start(@"" + PPDF);
                        }
                    }
                    else
                    { /*PPDF=(@"" + Puti[4] + NRUB + "_" + alphaBlendTextBox25.Text + "_" + DateTime.Now.ToString("ddMMyyyy") + ".pdf");*/
                        string folderPath = @"X:\act\" + alphaBlendTextBox26.Text.Replace(".", "_") + @"\\";
                        DirectoryInfo dir = new DirectoryInfo(folderPath);
                        FileInfo[] files = dir.GetFiles(UidANG + "*", SearchOption.TopDirectoryOnly);
                        //09_10_2018\";// + Puti[4];
                        //                    DirectoryInfo dir = new DirectoryInfo(folderPath);
                        //                    FileInfo[] files = dir.GetFiles("ec2f0d15-9f27-437f-9b45-835b5bf8f1f6.pdf", SearchOption.TopDirectoryOnly);//NRUB + "_" + alphaBlendTextBox25.Text + "_*", SearchOption.TopDirectoryOnly);
                        if (files.Length > 0)
                        {
                            foreach (var item in files)
                            {
                                PPDF = (@"" + item.FullName);
                                FormZAGR newfrm = new FormZAGR();
                                newfrm.Show();
                                Process.Start(@"" + PPDF);
                                System.Threading.Thread.Sleep(4000);
                                newfrm.Close();
                            }
                        }
                        else
                        {
                            //PPDF = (@"" + Puti[4] + UidANG + ".pdf");
                            PDF();
                            //string aaa = @"Y:\\" + DateTime.Now.ToString("dd_MM_yyyy");
                            //string bbb = @"X:\\act\\" + DateTime.Now.ToString("dd_MM_yyyy");
                            //CopyFolderYesterdayFiles(@"X:\\", aaa, bbb, GDAng.ToString(), IDW.ToString(), PLN.ToString(), CDD.ToString(), PT5);

                            PPDF = (@"" + Puti[4] + alphaBlendTextBox26.Text.Replace(".", "_") + @"\\" + GDAng.ToString() + ".pdf");
                            Process.Start(@"" + PPDF);
                        }

                    }

                }




                //////PDF();
                //////string aaa = @"Y:\\" + DateTime.Now.ToString("dd_MM_yyyy");
                //////string bbb = @"X:\\act\\" + DateTime.Now.ToString("dd_MM_yyyy");
                //////CopyFolderYesterdayFiles(@"X:\\", aaa, bbb, GDAng.ToString(), IDW.ToString(), PLN.ToString(), CDD.ToString(), PT5);

                //PPDF = (@"" + Puti[4] + DateTime.Now.ToString("dd_MM_yyyy") + @"\\" + GDAng.ToString() + ".pdf");
                //Process.Start(@"" + PPDF);
            //////}
        }
        public void PDF()
        {
            
            A1[259] = NRUB + "_" + alphaBlendTextBox25.Text;
            A1[0] = NRUB + "-" + alphaBlendTextBox25.Text;
            A1[250] = DateTime.Now.ToString("dd.MM.yyyyг.");
            A1[1] = Convert.ToDateTime(alphaBlendTextBox26.Text).ToString("dd.MM.yyyyг.");//alphaBlendTextBox26.Text;//
            A1[2] = alphaBlendTextBox33.Text;//DateTime.Now.ToString(" HH:mm:ss");
            A1[3] = alphaBlendTextBox25.Text;
            A1[4] = alphaBlendTextBox53.Text; A1[5] = alphaBlendTextBox54.Text; /*"Комплекс измерительный автоматического весового и габаритного контроля";*/ A1[6] = alphaBlendTextBox55.Text; A1[7] = alphaBlendTextBox56.Text; /*"001/02/2018 ";*/ A1[8] = alphaBlendTextBox58.Text;
            A1[9] = alphaBlendTextBox35.Text;/*"51 км. + 106 м.";*/ A1[10] = alphaBlendTextBox31.Text; A1[11] = alphaBlendTextBox63.Text;/*" Betamont s.r.o. "*/; A1[12] = alphaBlendTextBox57.Text;/*"123456"*/; A1[13] = alphaBlendTextBox60.Text;
            A1[14] = alphaBlendTextBox59.Text; A1[15] = alphaBlendTextBox62.Text;/*"Тets - 123"*/; A1[16] = alphaBlendTextBox61.Text; A1[17] = alphaBlendTextBox64.Text; A1[18] = alphaBlendTextBox32.Text;
            A1[19] = alphaBlendTextBox29.Text;/*"г. Севастополь, а/д Симферополь-Бахчисарай-Севастополь 51 км. + 106 м.";*/ A1[20] = alphaBlendTextBox65.Text; A1[21] = alphaBlendTextBox30.Text; A1[22] = alphaBlendTextBox66.Text + " тонн/ось"; A1[23] = alphaBlendTextBox67.Text;
            A1[24] = alphaBlendTextBox68.Text;
            if (maskedTextBox1.Text != "") { A1[25] = maskedTextBox1.Text; } else { A1[25] = "-"; }
            A1[26] = FFFT;// alphaBlendTextBox12.Text;
            A1[27] = alphaBlendTextBox11.Text; A1[28] = alphaBlendTextBox13.Text;
            A1[29] = GrO.ToString() + "(" + tipoS.ToString() + ")"; /*A1[29] = FF;*/ A1[30] = alphaBlendTextBox69.Text; A1[31] = alphaBlendTextBox70.Text; A1[32] = alphaBlendTextBox71.Text; A1[33] = alphaBlendTextBox72.Text;
            A1[34] = alphaBlendTextBox74.Text; A1[35] = alphaBlendTextBox73.Text; A1[36] = alphaBlendTextBox75.Text; A1[37] = alphaBlendTextBox78.Text;/*alphaBlendTextBox27.Text;*/ A1[38] = alphaBlendTextBox76.Text;
            A1[39] = alphaBlendTextBox79.Text; 
            if (TypNarTXT.ToString() != "")
            { A1[41] = TypNarTXT.ToString();/*alphaBlendTextBox28.Text;*/ A1[42] = MAXPREVPROTC.ToString();/*alphaBlendTextBox24.Text;*/A1[43] = MAXPREV.ToString(); }/*alphaBlendTextBox27.Text;*/
            else { A1[41] = "-"; A1[42] = "-"; A1[43] = "-"; }
            A1[44] = "- 0.60 м"; A1[45] = "- 0.10 м"; A1[46] = "- 0.06 м"; A1[47] = alphaBlendTextBox42.Text;
            if (alphaBlendTextBox45.Text.ToString() != "-") { A1[48] = alphaBlendTextBox45.Text.ToString(); A1[51] = alphaBlendTextBox43.Text.ToString(); } else { A1[48] = "-"; A1[51] = "-"; }
            if (alphaBlendTextBox48.Text != "-") { A1[49] = alphaBlendTextBox48.Text; A1[52] = alphaBlendTextBox46.Text; } else { A1[49] = "-"; A1[52] = "-"; }

           /* A1[48] = alphaBlendTextBox45.Text;*/ /*A1[49] = alphaBlendTextBox48.Text;*/ A1[50] = alphaBlendTextBox37.Text; /*A1[51] = alphaBlendTextBox43.Text;*/ /*A1[52] = alphaBlendTextBox46.Text;*/
            A1[53] = alphaBlendTextBox41.Text; A1[54] = alphaBlendTextBox44.Text; A1[55] = alphaBlendTextBox47.Text;
            if (XDate[12].ToString() != "False")
            { A1[56] = alphaBlendTextBox21.Text; ; A1[57] = alphaBlendTextBox81.Text; ; A1[58] = alphaBlendTextBox82.Text; A1[69] = alphaBlendTextBox20.Text; A1[40] = alphaBlendTextBox77.Text; }
            else
            {  A1[56] = "-"; A1[57] = "-"; A1[58] = "-";   A1[69] = "-"; A1[40] = "-"; }
            A1[59] = alphaBlendTextBox39.Text; A1[60] = alphaBlendTextBox49.Text; A1[61] = alphaBlendTextBox51.Text; A1[62] = alphaBlendTextBox40.Text;
            A1[63] = alphaBlendTextBox50.Text; A1[64] = alphaBlendTextBox52.Text; A1[65] = "- 5%"; A1[66] = alphaBlendTextBox22.Text; A1[67] = alphaBlendTextBox36.Text;
            A1[68] = alphaBlendTextBox23.Text;
            if (alphaBlendTextBox24.Text!="")
            { A1[70] = alphaBlendTextBox24.Text; A1[71] = alphaBlendTextBox27.Text; }
            else { A1[70] = "-"; A1[71]="-"; }
           
                A1[72] = dataGridView1[0, 0].Value.ToString(); A1[73] = dataGridView1[2, 0].Value.ToString(); A1[74] = dataGridView1[1, 0].Value.ToString(); A1[75] = dataGridView1[3, 0].Value.ToString(); A1[76] = dataGridView1[4, 0].Value.ToString();
            A1[77] = dataGridView1[7, 0].Value.ToString(); A1[78] = dataGridView1[8, 0].Value.ToString(); A1[79] = dataGridView1[9, 0].Value.ToString(); 
            A1[81] = dataGridView1[11, 0].Value.ToString(); A1[82] = dataGridView1[12, 0].Value.ToString();
            if (Convert.ToInt32(alphaBlendTextBox13.Text) > 1)
            {
                A1[83] = dataGridView1[0, 1].Value.ToString(); A1[84] = dataGridView1[2, 1].Value.ToString(); A1[85] = dataGridView1[1, 1].Value.ToString(); A1[86] = dataGridView1[3, 1].Value.ToString(); A1[87] = dataGridView1[4, 1].Value.ToString();
                A1[88] = dataGridView1[7, 1].Value.ToString(); A1[89] = dataGridView1[8, 1].Value.ToString(); A1[90] =dataGridView1[9, 1].Value.ToString(); // "|       -      |      -      |           24,88          |"; /* 
                A1[92] = dataGridView1[11, 1].Value.ToString(); A1[93] = dataGridView1[12, 1].Value.ToString();
            }
            if (Convert.ToInt32(alphaBlendTextBox13.Text) > 2)
            {
                A1[94] = dataGridView1[0, 2].Value.ToString(); A1[95] = dataGridView1[2, 2].Value.ToString(); A1[96] = dataGridView1[1, 2].Value.ToString(); A1[97] = dataGridView1[3, 2].Value.ToString(); A1[98] = dataGridView1[4, 2].Value.ToString();
                A1[99] = dataGridView1[7, 2].Value.ToString(); A1[100] = dataGridView1[8, 2].Value.ToString(); A1[101] = dataGridView1[9, 2].Value.ToString(); 
                A1[103] = dataGridView1[11, 2].Value.ToString(); A1[104] = dataGridView1[12, 2].Value.ToString();
            }
            if (Convert.ToInt32(alphaBlendTextBox13.Text) > 3)
            {
                A1[105] = dataGridView1[0, 3].Value.ToString(); A1[106] = dataGridView1[2, 3].Value.ToString(); A1[107] = dataGridView1[1, 3].Value.ToString(); A1[108] = dataGridView1[3, 3].Value.ToString(); A1[109] = dataGridView1[4, 3].Value.ToString();
                A1[110] = dataGridView1[7, 3].Value.ToString(); A1[111] = dataGridView1[8, 3].Value.ToString(); A1[112] = dataGridView1[9, 3].Value.ToString();  
                A1[114] = dataGridView1[11, 3].Value.ToString();
                A1[115] = dataGridView1[12, 3].Value.ToString();
            }
            if (Convert.ToInt32(alphaBlendTextBox13.Text) > 4)
            {
                A1[116] = dataGridView1[0, 4].Value.ToString(); A1[117] = dataGridView1[2, 4].Value.ToString(); A1[118] = dataGridView1[1, 4].Value.ToString(); A1[119] = dataGridView1[3, 4].Value.ToString(); A1[120] = dataGridView1[4, 4].Value.ToString();
                A1[121] = dataGridView1[7, 4].Value.ToString(); A1[122] = dataGridView1[8, 4].Value.ToString(); A1[123] = dataGridView1[9, 4].Value.ToString();  
                A1[125] = dataGridView1[11, 4].Value.ToString();
                A1[126] = dataGridView1[12, 4].Value.ToString();
            }
            if (Convert.ToInt32(alphaBlendTextBox13.Text) > 5)
            {
                A1[127] = dataGridView1[0, 5].Value.ToString(); A1[128] = dataGridView1[2, 5].Value.ToString(); A1[129] = dataGridView1[1, 5].Value.ToString(); A1[130] = dataGridView1[3, 5].Value.ToString(); A1[131] = dataGridView1[4, 5].Value.ToString();
                A1[132] = dataGridView1[7, 5].Value.ToString(); A1[133] = dataGridView1[8, 5].Value.ToString(); A1[134] = dataGridView1[9, 5].Value.ToString();  
                A1[136] = dataGridView1[11, 5].Value.ToString();
                A1[137] = dataGridView1[12, 5].Value.ToString();
            }
            if (Convert.ToInt32(alphaBlendTextBox13.Text) > 6)
            {
                A1[138] = dataGridView1[0, 6].Value.ToString(); A1[139] = dataGridView1[2, 6].Value.ToString(); A1[140] = dataGridView1[1, 6].Value.ToString(); A1[141] = dataGridView1[3, 6].Value.ToString(); A1[142] = dataGridView1[4, 6].Value.ToString();
                A1[143] = dataGridView1[7, 6].Value.ToString(); A1[144] = dataGridView1[8, 6].Value.ToString(); A1[145] = dataGridView1[9, 6].Value.ToString();  
                A1[147] = dataGridView1[11, 6].Value.ToString();
                A1[148] = dataGridView1[12, 6].Value.ToString();
            }
            if (Convert.ToInt32(alphaBlendTextBox13.Text) > 7)
            {
                A1[149] = dataGridView1[0, 7].Value.ToString(); A1[150] = dataGridView1[2, 7].Value.ToString(); A1[151] = dataGridView1[1, 7].Value.ToString(); A1[152] = dataGridView1[3, 7].Value.ToString(); A1[153] = dataGridView1[4, 7].Value.ToString();
                A1[154] = dataGridView1[7, 7].Value.ToString(); A1[155] = dataGridView1[8, 7].Value.ToString(); A1[156] = dataGridView1[9, 7].Value.ToString(); 
                A1[158] = dataGridView1[11, 7].Value.ToString();
                A1[159] = dataGridView1[12, 7].Value.ToString();
            }
            if (Convert.ToInt32(alphaBlendTextBox13.Text) > 8)
            {
                A1[160] = dataGridView1[0, 8].Value.ToString(); A1[161] = dataGridView1[2, 8].Value.ToString(); A1[162] = dataGridView1[1, 8].Value.ToString(); A1[163] = dataGridView1[3, 8].Value.ToString(); A1[164] = dataGridView1[4, 8].Value.ToString();
                A1[165] = dataGridView1[7, 8].Value.ToString(); A1[166] = dataGridView1[8, 8].Value.ToString(); A1[167] = dataGridView1[9, 8].Value.ToString();  
                A1[169] = dataGridView1[11, 8].Value.ToString();
                A1[170] = dataGridView1[12, 8].Value.ToString();
            }

            A1[171] = dataGridView2[0, 0].Value.ToString(); A1[172] = dataGridView2[2, 0].Value.ToString(); A1[173] = dataGridView2[1, 0].Value.ToString(); /*A1[174] = dataGridView2[3, 0].Value.ToString();*/ A1[175] = dataGridView2[4, 0].Value.ToString();
            A1[176] = dataGridView2[7, 0].Value.ToString(); A1[177] = dataGridView2[8, 0].Value.ToString(); A1[178] = dataGridView2[9, 0].Value.ToString();  
            A1[180] = dataGridView2[11, 0].Value.ToString();
            A1[181] = dataGridView2[12, 0].Value.ToString();
            if (Convert.ToInt32(dataGridView2.RowCount) > 1)
            {
                A1[182] = dataGridView2[0, 1].Value.ToString(); A1[183] = dataGridView2[2, 1].Value.ToString(); A1[184] = dataGridView2[1, 1].Value.ToString(); /*A1[185] = dataGridView2[3, 1].Value.ToString();*/ if (dataGridView2[1, 1].Value.ToString()=="1") { A1[186] = "-"; } else { A1[186] = dataGridView2[4, 1].Value.ToString(); }
                A1[187] = dataGridView2[7, 1].Value.ToString(); A1[188] = dataGridView2[8, 1].Value.ToString(); A1[189] = dataGridView2[9, 1].Value.ToString();  
                A1[191] = dataGridView2[11, 1].Value.ToString();
                A1[192] = dataGridView2[12, 1].Value.ToString();
            }
            if (Convert.ToInt32(dataGridView2.RowCount) > 2)
            {
                A1[193] = dataGridView2[0, 2].Value.ToString(); A1[194] = dataGridView2[2, 2].Value.ToString(); A1[195] = dataGridView2[1, 2].Value.ToString(); /*A1[196] = dataGridView2[3, 2].Value.ToString();*/ if (dataGridView2[1, 2].Value.ToString() == "1") { A1[197] = "-"; } else { A1[197] = dataGridView2[4, 2].Value.ToString(); }
                A1[198] = dataGridView2[7, 2].Value.ToString(); A1[199] = dataGridView2[8, 2].Value.ToString(); A1[200] = dataGridView2[9, 2].Value.ToString(); 
                A1[202] = dataGridView2[11, 2].Value.ToString();
                A1[203] = dataGridView2[12, 2].Value.ToString();
            }
            if (Convert.ToInt32(dataGridView2.RowCount) > 3)
            {
                A1[204] = dataGridView2[0, 3].Value.ToString(); A1[205] = dataGridView2[2, 3].Value.ToString(); A1[206] = dataGridView2[1, 3].Value.ToString(); /*A1[207] = dataGridView2[3, 3].Value.ToString();*/ if (dataGridView2[1, 3].Value.ToString() == "1") { A1[208] = "-"; } else { A1[208] = dataGridView2[4, 3].Value.ToString(); }
                A1[209] = dataGridView2[7, 3].Value.ToString(); A1[210] = dataGridView2[8, 3].Value.ToString(); A1[211] = dataGridView2[9, 3].Value.ToString(); 
                A1[213] = dataGridView2[11, 3].Value.ToString();
                A1[214] = dataGridView2[12, 3].Value.ToString();
            }
            if (Convert.ToInt32(dataGridView2.RowCount) > 4)
            {
                A1[215] = dataGridView2[0, 4].Value.ToString(); A1[216] = dataGridView2[2, 4].Value.ToString(); A1[217] = dataGridView2[1, 4].Value.ToString(); /*A1[218] = dataGridView2[3, 4].Value.ToString();*/ if (dataGridView2[1, 4].Value.ToString() == "1") { A1[219] = "-"; } else { A1[219] = dataGridView2[4, 4].Value.ToString(); }
                A1[220] = dataGridView2[7, 4].Value.ToString(); A1[221] = dataGridView2[8, 4].Value.ToString(); A1[222] = dataGridView2[9, 4].Value.ToString(); 
                A1[224] = dataGridView2[11, 4].Value.ToString();
                A1[225] = dataGridView2[12, 4].Value.ToString();
            }
            if (Convert.ToInt32(dataGridView2.RowCount) > 5)
            {
                A1[226] = dataGridView2[0, 5].Value.ToString(); A1[227] = dataGridView2[2, 5].Value.ToString(); A1[228] = dataGridView2[1, 5].Value.ToString(); /*A1[229] = dataGridView2[3, 5].Value.ToString();*/ if (dataGridView2[1, 5].Value.ToString() == "1") { A1[230] = "-"; } else { A1[230] = dataGridView2[4, 5].Value.ToString(); }
                A1[231] = dataGridView2[7, 5].Value.ToString(); A1[232] = dataGridView2[8, 5].Value.ToString(); A1[233] = dataGridView2[9, 5].Value.ToString();  
                A1[235] = dataGridView2[11, 5].Value.ToString();
                A1[236] = dataGridView2[12, 5].Value.ToString();
            } 
            ////// Таблицы заполнить СПЕЦ.РАЗР
            if (XDate[12].ToString() != "False")
            {
                A1[80] = dataGridView1[10, 0].Value.ToString();
                A1[91] = dataGridView1[10,1].Value.ToString();
                if (A1[94] != "" && A1[94] != null) { A1[102] = dataGridView1[10, 2].Value.ToString(); }
                if (A1[105] != "" && A1[105] != null) { A1[113] = dataGridView1[10, 3].Value.ToString(); }
                if (A1[116] != "" && A1[116] != null) { A1[124] = dataGridView1[10, 4].Value.ToString(); }
                if (A1[127] != "" && A1[127] != null) { A1[135] = dataGridView1[10, 5].Value.ToString(); }
                if (A1[138] != "" && A1[138] != null) { A1[146] = dataGridView1[10, 6].Value.ToString(); }
                if (A1[149] != "" && A1[149] != null) { A1[157] = dataGridView1[10, 7].Value.ToString(); }
                if (A1[160] != "" && A1[160] != null) { A1[168] = dataGridView1[10, 8].Value.ToString(); }

                if (A1[171] != "" && A1[171] != null) { A1[179] = dataGridView2[10, 0].Value.ToString(); }
                if (A1[182] != "" && A1[182] != null) { A1[190] = dataGridView2[10, 1].Value.ToString(); }
                if (A1[193] != "" && A1[193] != null) { A1[201] = dataGridView2[10, 2].Value.ToString(); }
                if (A1[204] != "" && A1[204] != null) { A1[212] = dataGridView2[10, 3].Value.ToString(); }
                if (A1[215] != "" && A1[215] != null) { A1[223] = dataGridView2[10, 4].Value.ToString(); }
                if (A1[226] != "" && A1[226] != null) { A1[234] = dataGridView2[10, 5].Value.ToString(); }
            }
            else
            {
                A1[80] = "-";
                A1[91] = "-";
                if (A1[94] != "" && A1[94] != null) { A1[102] = "-"; }
                if (A1[105] != "" && A1[105]!=null) { A1[113] = "-"; }
                if (A1[116] != "" && A1[116] != null) { A1[124] = "-"; }
                if (A1[127] != "" && A1[127] != null) { A1[135] = "-"; }
                if (A1[138] != "" && A1[138] != null) { A1[146] = "-"; }
                if (A1[149] != "" && A1[149] != null) { A1[157] = "-"; }
                if (A1[160] != "" && A1[160] != null) { A1[168] = "-"; }

                if (A1[171] != "" && A1[171] != null) { A1[179] = "-"; }
                if (A1[182] != "" && A1[182] != null) { A1[190] = "-"; }
                if (A1[193] != "" && A1[193] != null) { A1[201] = "-"; }
                if (A1[204] != "" && A1[204] != null) { A1[212] = "-"; }
                if (A1[215] != "" && A1[215] != null) { A1[223] = "-"; }
                if (A1[226] != "" && A1[226] != null) { A1[234] = "-"; }
            }
            //////
            A1[218] = alphaBlendTextBox109.Text; A1[229] = alphaBlendTextBox108.Text;
            A1[237] = "-"; A1[238] = "-"; A1[239] = "-"; A1[240] = "-";
            A1[241] = "-"; A1[242] = "-"; A1[243] = "-"; A1[244] = "-"; A1[245] = "Настоящий акт № " + NRUB + "-" + alphaBlendTextBox25.Text + "составлен в автоматическом режиме"  ;
            A1[246] = "Настоящий акт отправлен в ЦАФАП ОГИБДД ГУ МВД  России по г. Севастополь"; A1[247] = "-"; A1[248] = "-"; A1[249] = "-";
            /*SPEED*/A1[251] = SPEED_ALL[0]; A1[252] = SPEED_ALL[1]; A1[253] = SPEED_ALL[2]; A1[254] = SPEED_ALL[3]; A1[255] = SPEED_ALL[4]; A1[256] = SPEED_ALL[5]; A1[257] = SPEED_ALL[6];

            if (checkBox1.Checked == true)
            {
                 AKT_PDF AKT = new AKT_PDF();

                if (ImObj != null)
                {
                    if (ImPl == null)
                    { AKT.FormPDF(Im, ImPlREA, ImObj, A1, NRUB, GDAng.ToString(), KNR); }
                    else { AKT.FormPDF(Im, ImPl, ImObj, A1, NRUB, GDAng.ToString(), KNR); }
                }
                else
                {
                    if (ImPl == null)
                    { AKT.FormPDF(Im, ImPlREA, ImAlt, A1, NRUB, GDAng.ToString(), KNR); }
                    else { AKT.FormPDF(Im, ImPl, ImAlt, A1, NRUB, GDAng.ToString(), KNR); }
                }
            }
            else
            {                
                    AKT_PDF_New AKT = new AKT_PDF_New();
                INAng = Guid.NewGuid();
                GDAng = Convert.ToString(INAng);//.Replace("-", "");
                if (ImObj != null)
                {
                    if (ImPl == null)
                    { AKT.FormPDFN(Im, ImPlREA, ImObj, A1, NRUB, GDAng.ToString(), KNR); }
                    else { AKT.FormPDFN(Im, ImPl, ImObj, A1, NRUB, GDAng.ToString(), KNR); }
                }
                else
                {
                    if (ImPl == null)
                    { AKT.FormPDFN(Im, ImPlREA, ImAlt, A1, NRUB, GDAng.ToString(), KNR); }
                    else { AKT.FormPDFN(Im, ImPl, ImAlt, A1, NRUB, GDAng.ToString(), KNR); }
                }
            }
            //DateTime YesterdayDateA = DateTime.Today.Date;

            //NamPD = @"F:\\archivACT\\act\\" + YesterdayDateA.ToString("dd_MM_yyyy") + @"\\" + GDAng.ToString() + ".pdf";//@"F:\\archiv\\AKT\\" + GDAng.ToString() + ".pdf"; //A1[259] + "_" + DateTime.Now.ToString("ddMMyyyy") + ".pdf";

        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("В разработке (Формирует печатное постановление о нарушении в формате Word)");
        }
        #region //////////////////////////////////////////////////////////////// Запрос изменена ли запись    ////////////////////////////////
        public void ZIzm(int IDTS) ////////////////////////////////////////////////////// Запрос изменена ли запись   //////////////////////////
        {
            MySqlCommand commandNSR = new MySqlCommand();
            ConnectStr conStrNSR = new ConnectStr();
            conStrNSR.ConStr(1);
            Zapros zaprosNSR = new Zapros();
            string connectionStringNSR;
            connectionStringNSR = conStrNSR.StP;//"Data source=localhost;UserId=root;Password=1q2w3e$R;database=camloc;";
            MySqlConnection connectionNSR = new MySqlConnection(connectionStringNSR);
            zaprosNSR.PrNalSR(IDTS);
            string zNSR = zaprosNSR.commandStringTest;
            commandNSR.CommandText = zNSR;// commandString;
            commandNSR.Connection = connectionNSR;
            MySqlDataReader readerNSR;
            int NSR = 0;
            try
            {
                commandNSR.Connection.Open();
                readerNSR = commandNSR.ExecuteReader();
                while (readerNSR.Read())
                {
                    NSR = 1;
                }
                readerNSR.Close();
            }
            catch (MySqlException ex)
            {
                NSR = 0;
                //Console.WriteLine("Error: \r\n{0}", ex.ToString());
            }
            finally
            {
                commandNSR.Connection.Close();
            }
            
            MySqlCommand command2 = new MySqlCommand();
            ConnectStr conStr2 = new ConnectStr();
            conStr2.ConStr(1);
            Zapros zapros2 = new Zapros();
            string connectionString2;//, commandString;
            connectionString2 = conStr2.StP;//"Data source=localhost;UserId=root;Password=1q2w3e$R;database=camloc;";
            MySqlConnection connection2 = new MySqlConnection(connectionString2);
            zapros2.ZaprAllCamNaprLO(IDTS, NSR);
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
                    if (reader2["Plate"].ToString() == "")
                    { maskedTextBox1.Text = reader2["PlateRear"].ToString();
                        nom = reader2["PlateRear"].ToString();
                    }
                    else
                    {
                        maskedTextBox1.Text = reader2["Plate"].ToString();
                        nom = reader2["Plate"].ToString();
                    }
                 
                    if (Convert.ToDouble(reader2["ChangeType"].ToString()) == 1)
                    {                       
                        KnPriv = 1;
                        /// в переменные загоняем изменения для отвязки
                        IDTSKon = 0;                        
                        OGRZ = "";
                        OKL = "";
                        NLP = reader2["OldGRZ"].ToString();
                        OlDat = "";
                        chang = 0;
                        /////////////////////////////////
                      
                        label21.Text = reader2["DateChang"].ToString();
                        label22.Text = reader2["NameUs"].ToString();
                        label24.Text = reader2["OldGRZ"].ToString();
                        label26.Text = reader2["OldIDPR"].ToString();
                        label28.Text = reader2["DateChang"].ToString();
                        if (reader2["Plate"].ToString() == "")
                        { label84.Text = reader2["PlateRear"].ToString(); }
                        else
                        {
                            label84.Text = reader2["Plate"].ToString();
                        }
                        alphaBlendTextBox53.Text = reader2["nameapvk"].ToString();//Наименование комплекса
                        alphaBlendTextBox63.Text = reader2["Vladel"].ToString();//Владелец комплекса
                        alphaBlendTextBox54.Text = reader2["TipSI"].ToString();//Тип СИ комплекса
                        alphaBlendTextBox55.Text = reader2["Model"].ToString();//Марка и модель комплекса
                        alphaBlendTextBox56.Text = reader2["sernum"].ToString();//Заводской № комплекса
                        if (Convert.ToInt64(reader2["kodapvk"].ToString()) == 2952855555)
                        {
                            alphaBlendTextBox58.Text = "2920002";
                        }
                        else if (Convert.ToInt64(reader2["kodapvk"].ToString()) == 2952855553)
                        {
                            alphaBlendTextBox58.Text = "2920001";
                        }
                        else
                        { alphaBlendTextBox58.Text = reader2["kodapvk"].ToString(); }
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
                        alphaBlendTextBox16.Text = alphaBlendTextBox80.Text;
                        alphaBlendTextBox68.Text = reader2["ogranich"].ToString();//особ. условия. дороги                                                                                  
                        label20.Visible = true;
                        label21.Visible = true; label22.Visible = true; label23.Visible = true; label24.Visible = true; label25.Visible = true;
                        label26.Visible = true; label27.Visible = true; label28.Visible = true; label29.Visible = true;
                    }
                    else
                    {
                        ////////////////////////////////////////////////////////////////////
                        IDSV = 0;
                       
                        label20.Visible = false;
                        label21.Visible = false; label22.Visible = false; label23.Visible = false; label24.Visible = false; label25.Visible = false;
                        label26.Visible = false; label27.Visible = false; label28.Visible = false; label29.Visible = false;                      
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
             ZOsPDK();
            //RisOsei();
#region //////////////////////////////////////////////////////////////// заполняем ПДК по тележкам и превышения (левая)    ////////////////////////////////
            KNR[1, 0] = Convert.ToInt32(TypO[1]);
            KNR[0, 0] = 1;
            ///////////////////////////////////////////       Заполняем первую строку ///////////////////////////////////////////////////
            if (KNR[1, 0] == 1)
            {
                dataGridView2[9, 0].Value = PDKO[1];// / Convert.ToInt32(TypO[ic + 1]);
                if (names3[1].massSR == "0")
                {
                    dataGridView2[10, 0].Value = "-";
                    if (Math.Round(Convert.ToDouble(dataGridView2[8, 0].Value) / (Convert.ToDouble(dataGridView2[9, 0].Value)) * 100 - 100, 2) > 0)
                    {
                        dataGridView2[11, 0].Value = Math.Round(Convert.ToDouble(dataGridView2[8, 0].Value) / (Convert.ToDouble(dataGridView2[9, 0].Value)) * 100 - 100, 0);
                        dataGridView2[12, 0].Value = Math.Round(Convert.ToDouble(dataGridView2[8, 0].Value) - Convert.ToDouble(dataGridView2[9, 0].Value), 2);
                        if (Math.Round(Convert.ToDouble(dataGridView2[8, 0].Value) / (Convert.ToDouble(dataGridView2[9, 0].Value)) * 100 - 100, 0) >= 3)
                        {
                            XDate[31] = "True";
                            PrevNar[10] = Math.Round(Convert.ToDouble(dataGridView2[11, 0].Value), 0);
                            PrevNar[37] = 1;
                        }
                        else { XDate[31] = "False"; }

                        dataGridView2.Rows[0].DefaultCellStyle.BackColor = Color.LightPink;//.Red;
                    }
                    else
                    {
                        dataGridView2[11, 0].Value = "-";
                        dataGridView2[12, 0].Value = "-";
                    }
                }
                else
                {
                    dataGridView2[10, 0].Value = names3[1].massSR;
                    if (Math.Round(Convert.ToDouble(dataGridView2[8, 0].Value) / (Convert.ToDouble(names3[1].massSR)) * 100 - 100, 2) > 0)
                    {
                        dataGridView2[11, 0].Value = Math.Round(Convert.ToDouble(dataGridView2[8, 0].Value) / (Convert.ToDouble(names3[1].massSR)) * 100 - 100, 0);
                        dataGridView2[12, 0].Value = Math.Round(Convert.ToDouble(dataGridView2[8, 0].Value) - Convert.ToDouble(names3[1].massSR), 2);
                        if (Math.Round(Convert.ToDouble(dataGridView2[8, 0].Value) / (Convert.ToDouble(names3[1].massSR)) * 100 - 100, 0) >= 3)
                        {
                            XDate[31] = "True";
                            PrevNar[10] = Math.Round(Convert.ToDouble(dataGridView2[11, 0].Value), 0);
                            PrevNar[37] = 1;
                        }
                        else { XDate[31] = "False"; }

                        dataGridView2.Rows[0].DefaultCellStyle.BackColor = Color.LightPink;//.Red;
                    }
                    else
                    {
                        dataGridView2[11, 0].Value = "-";
                        dataGridView2[12, 0].Value = "-";
                    }
                }
            }
            else if (KNR[1, 0] > 1 && KNR[1, 0] < 4)
            {
                D1_2 = 0;
                D1S_2S = 0;
                for (icC = 1; icC <= TypO[1]; icC++)
                {
                    D1_2 = D1_2 + PDKTel[icC];
                    D1S_2S = D1S_2S + Convert.ToDouble(names3[icC].massSR);
                }
                dataGridView2[9, 0].Value = D1_2 / TypO[1];//icC;// / Convert.ToInt32(TypO[ic + 1]);
                if (names3[1].massSR == "0")
                {
                    dataGridView2[10, 0].Value = "-";
                    if (Math.Round(Convert.ToDouble(dataGridView2[8, 0].Value) / (Convert.ToDouble(dataGridView2[9, 0].Value)) * 100 - 100, 2) > 0)
                    {
                        dataGridView2[11, 0].Value = Math.Round(Convert.ToDouble(dataGridView2[8, 0].Value) / (Convert.ToDouble(dataGridView2[9, 0].Value)) * 100 - 100, 0);
                        dataGridView2[12, 0].Value = Math.Round(Convert.ToDouble(dataGridView2[8, 0].Value) - Convert.ToDouble(dataGridView2[9, 0].Value), 2);
                        if (Math.Round(Convert.ToDouble(dataGridView2[8, 0].Value) / (Convert.ToDouble(dataGridView2[9, 0].Value)) * 100 - 100, 0) >= 3)
                        {
                            XDate[31] = "True";
                            PrevNar[10] = Math.Round(Convert.ToDouble(dataGridView2[11, 0].Value), 0);
                            PrevNar[37] = 1;
                            for (icC = 1; icC <= TypO[1]; icC++)
                            {
                                PDKOsTel[icC] = 1;
                            }
                        }
                        else { XDate[31] = "False"; }
                        dataGridView2.Rows[0].DefaultCellStyle.BackColor = Color.LightPink;//.Red;
                    }
                    else
                    {
                        dataGridView2[11, 0].Value = "-";
                        dataGridView2[12, 0].Value = "-";
                    }
                }
                else
                {
                    dataGridView2[10, 0].Value = D1S_2S;// / TypO[1];
                    if (Math.Round(Convert.ToDouble(dataGridView2[8, 0].Value) / (Convert.ToDouble(dataGridView2[10, 0].Value)) * 100 - 100, 2) > 0)
                    {
                        dataGridView2[11, 0].Value = Math.Round(Convert.ToDouble(dataGridView2[8, 0].Value) / (Convert.ToDouble(dataGridView2[10, 0].Value)) * 100 - 100, 0);
                        dataGridView2[12, 0].Value = Math.Round(Convert.ToDouble(dataGridView2[8, 0].Value) - Convert.ToDouble(dataGridView2[10, 0].Value), 2);
                        if (Math.Round(Convert.ToDouble(dataGridView2[8, 0].Value) / (Convert.ToDouble(dataGridView2[10, 0].Value)) * 100 - 100, 0) >= 3)
                        {
                            XDate[31] = "True";
                            PrevNar[10] = Math.Round(Convert.ToDouble(dataGridView2[11, 0].Value), 0);
                            PrevNar[37] = 1;
                            for (icC = 1; icC <= TypO[1]; icC++)
                            {
                                PDKOsTel[icC] = 1;
                            }
                        }
                        else { XDate[31] = "False"; }
                        dataGridView2.Rows[0].DefaultCellStyle.BackColor = Color.LightPink;//.Red;
                    }
                    else
                    {
                        dataGridView2[11, 0].Value = "-";
                        dataGridView2[12, 0].Value = "-";
                    }
                }
            }
            else if (KNR[1, 0] > 3)
            {
                dataGridView2[2, 0].Value = "-";
                dataGridView2[9, 0].Value = "-";
                dataGridView2[10, 0].Value = "-";
                dataGridView2[11, 0].Value = "-";
                dataGridView2[12, 0].Value = "-";              
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
                    if (names3[ic].massSR == "0")
                    {
                        dataGridView2[10, ic].Value = "-";
                       
                        if (Math.Round(Convert.ToDouble(dataGridView2[8, ic].Value) / (Convert.ToDouble(dataGridView2[9, ic].Value)) * 100 - 100, 2) > 0)
                        {
                            dataGridView2[11, ic].Value = Math.Round(Convert.ToDouble(dataGridView2[8, ic].Value) / (Convert.ToDouble(dataGridView2[9, ic].Value)) * 100 - 100, 0);
                            dataGridView2[12, ic].Value = Math.Round(Convert.ToDouble(dataGridView2[8, ic].Value) - Convert.ToDouble(dataGridView2[9, ic].Value), 2);
                            if (/*Math.Floor(*/Math.Round(Convert.ToDouble(dataGridView2[8, ic].Value) / (Convert.ToDouble(dataGridView2[9, ic].Value)) * 100 - 100, 0)/*)*/ >= 3)
                            {
                                XDate[31] = "True";
                                PrevNar[ic + 10] = Convert.ToDouble(dataGridView2[11, ic].Value);
                                PrevNar[37] = 1;
                            }
                            else { XDate[31] = "False"; }
                            dataGridView2.Rows[ic].DefaultCellStyle.BackColor = Color.LightPink;//.Red;
                        }
                        else
                        {
                            dataGridView2[11, ic].Value = "-";
                            dataGridView2[12, ic].Value = "-";
                        }
                    }
                    else
                    {
                        dataGridView2[10, ic].Value = names3[ic].massSR;
                        if (Math.Round(Convert.ToDouble(dataGridView2[8, ic].Value) / (Convert.ToDouble(dataGridView2[10, ic].Value)) * 100 - 100, 2) > 0)
                        {
                            dataGridView2[11, ic].Value = Math.Round(Convert.ToDouble(dataGridView2[8, ic].Value) / (Convert.ToDouble(dataGridView2[10, ic].Value)) * 100 - 100, 0);
                            dataGridView2[12, ic].Value = Math.Round(Convert.ToDouble(dataGridView2[8, ic].Value) - Convert.ToDouble(dataGridView2[10, ic].Value), 2);
                            if (/*Math.Floor(*/Math.Round(Convert.ToDouble(dataGridView2[8, ic].Value) / (Convert.ToDouble(dataGridView2[10, ic].Value)) * 100 - 100, 0)/*)*/ >= 3)
                            {
                                XDate[31] = "True";
                                PrevNar[ic + 10] = Convert.ToDouble(dataGridView2[11, ic].Value);
                                PrevNar[37] = 1;
                            }
                            else { XDate[31] = "False"; }
                            dataGridView2.Rows[ic].DefaultCellStyle.BackColor = Color.LightPink;//.Red;
                        }
                        else
                        {
                            dataGridView2[11, ic].Value = "-";
                            dataGridView2[12, ic].Value = "-";
                        }
                    }
                }
                else if (KNR[1, ic] > 1 && KNR[1, ic] <4)
                {
                    D1_2 = 0;
                    D1S_2S = 0;

                    for (icC = KNR[0, ic]; icC < (KNR[0, ic] - 1 + KNR[1, ic]); icC++)
                    {
                        D1S_2S = D1S_2S + Convert.ToDouble(names3[icC].massSR);
                        if (icC < 8)
                        {
                            D1_2 = PDKTel[icC + 1];
                        }
                    }
                    dataGridView2[9, ic].Value = D1_2;// / Convert.ToInt32(TypO[ic + 1]);
                    if (names3[ic].massSR == "0")
                    {
                        dataGridView2[10, ic].Value = "-";

                        if (Math.Round(Convert.ToDouble(dataGridView2[8, ic].Value) / (Convert.ToDouble(dataGridView2[9, ic].Value)) * 100 - 100, 2) > 0)
                        {
                            dataGridView2[11, ic].Value = Math.Round(Convert.ToDouble(dataGridView2[8, ic].Value) / (Convert.ToDouble(dataGridView2[9, ic].Value)) * 100 - 100, 0);
                            dataGridView2[12, ic].Value = Math.Round(Convert.ToDouble(dataGridView2[8, ic].Value) - Convert.ToDouble(dataGridView2[9, ic].Value), 2);
                            if (Math.Round(Convert.ToDouble(dataGridView2[8, ic].Value) / (Convert.ToDouble(dataGridView2[9, ic].Value)) * 100 - 100, 0) >= 3)
                            {
                                XDate[31] = "True";
                                PrevNar[ic + 10] = Convert.ToDouble(dataGridView2[11, ic].Value);
                                PrevNar[37] = 1;
                                for (icC = KNR[0, ic]; icC <= (KNR[0, ic] - 1 + KNR[1, ic]); icC++)
                                {
                                    if (icC < 8)
                                    {
                                        PDKOsTel[icC] = 2;
                                    }
                                }
                            }
                            else { XDate[31] = "False"; }
                            dataGridView2.Rows[ic].DefaultCellStyle.BackColor = Color.LightPink;//.Red;
                        }
                        else
                        {
                            dataGridView2[11, ic].Value = "-";
                            dataGridView2[12, ic].Value = "-";
                        }
                    }
                    else
                    {
                        dataGridView2[10, ic].Value = Convert.ToString(Convert.ToDouble(names3[ic].massSR) * KNR[1, ic]);
                        if (Math.Round(Convert.ToDouble(dataGridView2[8, ic].Value) / (Convert.ToDouble(dataGridView2[10, ic].Value)) * 100 - 100, 2) > 0)
                        {
                            dataGridView2[11, ic].Value = Math.Round(Convert.ToDouble(dataGridView2[8, ic].Value) / (Convert.ToDouble(dataGridView2[10, ic].Value)) * 100 - 100, 0);
                            dataGridView2[12, ic].Value = Math.Round(Convert.ToDouble(dataGridView2[8, ic].Value) - Convert.ToDouble(dataGridView2[10, ic].Value), 2);
                            if (Math.Round(Convert.ToDouble(dataGridView2[8, ic].Value) / (Convert.ToDouble(dataGridView2[10, ic].Value)) * 100 - 100, 0) >= 3)
                            {
                                XDate[31] = "True";
                                PrevNar[ic + 10] = Convert.ToDouble(dataGridView2[11, ic].Value);
                                PrevNar[37] = 1;
                                for (icC = KNR[0, ic]; icC <= (KNR[0, ic] - 1 + KNR[1, ic]); icC++)
                                {
                                    if (icC < 8)
                                    {
                                        PDKOsTel[icC] = 2;
                                    }
                                }
                            }
                            else { XDate[31] = "False"; }
                            dataGridView2.Rows[ic].DefaultCellStyle.BackColor = Color.LightPink;//.Red;
                        }
                        else
                        {
                            dataGridView2[11, ic].Value = "-";
                            dataGridView2[12, ic].Value = "-";
                        }
                    }
                }

                else if (KNR[1, ic]> 3)
                {                   
                    dataGridView2[2, ic].Value = "-";

                    dataGridView2[9, ic].Value = "-";
                        dataGridView2[10, ic].Value = "-";
                        dataGridView2[11, ic].Value = "-";
                        dataGridView2[12, ic].Value = "-";                     
                }
                ////////////////////////////////////////////////////////////////////////
            }
            #endregion ///////////////////////////////////////////

            #region //////////////////////////////////////////////////////////////// заполняем ПДК по осям и превышения (левая)    ////////////////////////////////
             for (ic = 0; ic < (KolOs); ic++) //Convert.ToInt32(alphaBlendTextBox13.Text)); ic++)
            {

                if (ic < 9)
                {
                    if (PDKOsTel[ic + 1] == 0 && Convert.ToInt32(TypO[ic + 1]) < 4)
                    {
                        dataGridView1[9, ic].Value = PDKO[ic + 1];
                        if (names3[ic].massSR == "0")
                        {
                            dataGridView1[10, ic].Value = "-"; 
                            if (Math.Round((Convert.ToDouble(dataGridView1[8, ic].Value) / (PDKO[ic + 1]) * 100 - 100), 2) > 0)
                            {
                                dataGridView1[11, ic].Value = Math.Round(Convert.ToDouble(dataGridView1[8, ic].Value) / (PDKO[ic + 1]) * 100 - 100, 0);
                                dataGridView1[12, ic].Value = Math.Round(Convert.ToDouble(dataGridView1[8, ic].Value) - PDKO[ic + 1], 2);
                                if (Math.Round(Convert.ToDouble(dataGridView1[8, ic].Value) / (PDKO[ic + 1]) * 100 - 100, 0) > 2)
                                {
                                    XDate[31] = "True";
                                    PrevNar[ic] = Convert.ToDouble(dataGridView1[11, ic].Value);
                                    PrevNar[37] = 1;
                                }
                                else { XDate[31] = "False"; }
                                dataGridView1.Rows[ic].DefaultCellStyle.BackColor = Color.LightPink;//.Red;
                            }
                            else
                            {
                                dataGridView1[11, ic].Value = "-";
                                dataGridView1[12, ic].Value = "-";
                            }
                        }
                    else
                    {
                        dataGridView1[10, ic].Value = names3[ic].massSR;
                            if (Math.Round((Convert.ToDouble(dataGridView1[8, ic].Value) / Convert.ToDouble(names3[ic].massSR) * 100 - 100), 2) > 0)
                            {
                                dataGridView1[11, ic].Value = Math.Round(Convert.ToDouble(dataGridView1[8, ic].Value) / Convert.ToDouble(names3[ic].massSR) * 100 - 100, 0);
                                dataGridView1[12, ic].Value = Math.Round(Convert.ToDouble(dataGridView1[8, ic].Value) - Convert.ToDouble(names3[ic].massSR), 2);
                                if (Math.Round(Convert.ToDouble(dataGridView1[8, ic].Value) / Convert.ToDouble(names3[ic].massSR) * 100 - 100, 0) > 2 )
                                {
                                    XDate[31] = "True";
                                    PrevNar[ic] = Convert.ToDouble(dataGridView1[11, ic].Value);
                                    PrevNar[37] = 1;
                                }
                                else { XDate[31] = "False"; }
                                dataGridView1.Rows[ic].DefaultCellStyle.BackColor = Color.LightPink;//.Red;
                            }
                            else
                            {
                                dataGridView1[11, ic].Value = "-";
                                dataGridView1[12, ic].Value = "-";
                            }
                    }
                }
                    else if (Convert.ToInt32(TypO[ic + 1])<4)
                    {
                        dataGridView1[9, ic].Value = PDKTel[ic + 1] / Convert.ToInt32(TypO[ic + 1]);
                        if (names3[ic].massSR == "0")
                        {
                            dataGridView1[10, ic].Value = "-";
                        if (Math.Round(Convert.ToDouble(dataGridView1[8, ic].Value) / (Convert.ToDouble(dataGridView1[9, ic].Value)) * 100 - 100, 2) > 0)
                        {
                            dataGridView1[11, ic].Value = Math.Round(Convert.ToDouble(dataGridView1[8, ic].Value) / (Convert.ToDouble(dataGridView1[9, ic].Value)) * 100 - 100, 0);
                            dataGridView1[12, ic].Value = Math.Round(Convert.ToDouble(dataGridView1[8, ic].Value) - Convert.ToDouble(dataGridView1[9, ic].Value), 2);
                            if (Math.Round(Convert.ToDouble(dataGridView1[8, ic].Value) / (Convert.ToDouble(dataGridView1[9, ic].Value)) * 100 - 100, 0) > 2)
                            {  XDate[31] = "True";   PrevNar[ic] = Convert.ToDouble(dataGridView1[11, ic].Value);   PrevNar[37] = 1;   }
                            else { XDate[31] = "False"; }
                            dataGridView1.Rows[ic].DefaultCellStyle.BackColor = Color.LightPink;//.Red;
                        }
                        else
                        { dataGridView1[11, ic].Value = "-";   dataGridView1[12, ic].Value = "-";  }
                        }
                        else
                        {
                            dataGridView1[10, ic].Value = names3[ic].massSR;
                            if (Math.Round(Convert.ToDouble(dataGridView1[8, ic].Value) / (Convert.ToDouble(names3[ic].massSR)) * 100 - 100, 2) > 0)
                            {
                                dataGridView1[11, ic].Value = Math.Round(Convert.ToDouble(dataGridView1[8, ic].Value) / (Convert.ToDouble(names3[ic].massSR)) * 100 - 100, 0);
                                dataGridView1[12, ic].Value = Math.Round(Convert.ToDouble(dataGridView1[8, ic].Value) - Convert.ToDouble(names3[ic].massSR), 2);
                                if (Math.Round(Convert.ToDouble(dataGridView1[8, ic].Value) / (Convert.ToDouble(names3[ic].massSR)) * 100 - 100, 0) > 2)
                                {   XDate[31] = "True";  PrevNar[ic] = Convert.ToDouble(dataGridView1[11, ic].Value);  PrevNar[37] = 1;   }
                                else { XDate[31] = "False"; }
                                dataGridView1.Rows[ic].DefaultCellStyle.BackColor = Color.LightPink;//.Red;
                            }
                            else
                            {   dataGridView1[11, ic].Value = "-";   dataGridView1[12, ic].Value = "-";      }
                        }
                    }

                    else if (Convert.ToInt32(TypO[ic + 1]) > 3)
                    {
                        dataGridView1[9, ic].Value = PDKO[ic + 1] ;
                        if (names3[ic].massSR == "0")
                        {  dataGridView1[10, ic].Value = "-";
                        if (Math.Round(Convert.ToDouble(dataGridView1[8, ic].Value) / (Convert.ToDouble(dataGridView1[9, ic].Value)) * 100 - 100, 2) > 0)
                        {
                            dataGridView1[11, ic].Value = Math.Round(Convert.ToDouble(dataGridView1[8, ic].Value) / (Convert.ToDouble(dataGridView1[9, ic].Value)) * 100 - 100, 0);
                            dataGridView1[12, ic].Value = Math.Round(Convert.ToDouble(dataGridView1[8, ic].Value) - Convert.ToDouble(dataGridView1[9, ic].Value), 2);
                            if (Math.Round(Convert.ToDouble(dataGridView1[8, ic].Value) / (Convert.ToDouble(dataGridView1[9, ic].Value)) * 100 - 100, 0) > 2)
                            {  XDate[31] = "True";    PrevNar[ic] = Convert.ToDouble(dataGridView1[11, ic].Value);    PrevNar[37] = 1;   }
                            else { XDate[31] = "False"; }
                            dataGridView1.Rows[ic].DefaultCellStyle.BackColor = Color.LightPink;//.Red;
                        }
                        else
                        { dataGridView1[11, ic].Value = "-";   dataGridView1[12, ic].Value = "-"; }
                    }
                    else
                    {
                        dataGridView1[10, ic].Value = names3[ic].massSR;
                            if (Math.Round(Convert.ToDouble(dataGridView1[8, ic].Value) / (Convert.ToDouble(names3[ic].massSR)) * 100 - 100, 2) > 0)
                            {
                                dataGridView1[11, ic].Value = Math.Round(Convert.ToDouble(dataGridView1[8, ic].Value) / (Convert.ToDouble(names3[ic].massSR)) * 100 - 100, 0);
                                dataGridView1[12, ic].Value = Math.Round(Convert.ToDouble(dataGridView1[8, ic].Value) - Convert.ToDouble(names3[ic].massSR), 2);
                                if (Math.Round(Convert.ToDouble(dataGridView1[8, ic].Value) / (Convert.ToDouble(names3[ic].massSR)) * 100 - 100, 0) > 2)
                                { XDate[31] = "True"; PrevNar[ic] = Convert.ToDouble(dataGridView1[11, ic].Value); PrevNar[37] = 1; }
                                else { XDate[31] = "False"; }
                                dataGridView1.Rows[ic].DefaultCellStyle.BackColor = Color.LightPink;//.Red;
                            }
                            else
                            { dataGridView1[11, ic].Value = "-"; dataGridView1[12, ic].Value = "-"; }
                    }
                }

                }

                if (names3[ic].massSR == "0")
                {
                    names3[ic].massPrev = Convert.ToString(Math.Round(Convert.ToDouble(dataGridView1[8, ic].Value) - Convert.ToDouble(dataGridView1[9, ic].Value), 2));
                    names3[ic].PDKmass = Convert.ToString(dataGridView1[9, ic].Value);
                    if (Convert.ToDouble(names3[ic].massPrev) > 3)
                    {
                        names3[ic].massSign = "true";
                        if (dataGridView1[11, ic].Value.ToString() == "-")
                        { PrevNar[ic] = 0; }
                        else
                        {
                            PrevNar[ic] = Convert.ToDouble(dataGridView1[11, ic].Value);
                            PrevNar[37] = 1;
                        }
                    }
                    else
                    {
                        names3[ic].massSign = "false";
                        names3[ic].massPrev = "0";
                    }
                }
                else
                {
                    names3[ic].massPrevSR = Convert.ToString(Math.Round(Convert.ToDouble(dataGridView1[8, ic].Value) - Convert.ToDouble(names3[ic].massSR), 2));
                    names3[ic].PDKmass = Convert.ToString(dataGridView1[9, ic].Value);
                    if (Convert.ToDouble(names3[ic].massPrevSR) > 2)
                    {
                        names3[ic].massSign = "true";
                        if (dataGridView1[11, ic].Value.ToString() == "-")
                        { PrevNar[ic] = 0; }
                        else
                        {
                            PrevNar[ic] = Convert.ToDouble(dataGridView1[11, ic].Value);
                            PrevNar[37] = 1;
                        }
                    }
                    else
                    {
                        names3[ic].massSign = "false";
                        names3[ic].massPrevSR = "0";
                    }
                }

            }
            #endregion //////////////////////////
            RisOsei();

            #region /////////////////////////////////////////// ///////////////////////////////////////////////////// ТИП НАРУШЕНИЯ
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
                dataGridView1.Rows[iNar].DefaultCellStyle.BackColor = Color.Red;
                PrevNar[30] = 1;
                if (PrevNar[29] == 1)
                {
                    PrevNar[32] = 1;
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
                {
                    PrevNar[32] = 2;
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
                PrevNar[31] = iNar - 9;
                TypNar = 2;
                TypNarTXT = "Превышение нагрузки на группу осей";
                MAXPREV = Convert.ToDouble(dataGridView2[12, iNar - 10].Value); ;
                MAXPREVPROTC = Convert.ToDouble(dataGridView2[11, iNar - 10].Value);
                PrevNar[30] = 2;
                dataGridView2.Rows[iNar - 10].DefaultCellStyle.BackColor = Color.Red;
                if (PrevNar[29] == 1)
                {
                    PrevNar[32] = 1;
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
                {
                    PrevNar[32] = 2;
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
                {
                    PrevNar[32] = 1;
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
                {
                    PrevNar[32] = 2;
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
                PrevNar[30] = 4;
                if (PrevNar[29] == 1)
                {
                    PrevNar[32] = 1;
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
                {
                    PrevNar[32] = 2;
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

            if (PrevNar[30]>0 && PrevNar[30]<4)
            {
                if (PrevNar[33] < 1000)
                {
                    if (PrevNar[33] < 100)
                    {
                        if (PrevNar[33] < 10)
                        {
                            PNarSTEPEN = "000" + PrevNar[33].ToString();
                        }
                        else { PNarSTEPEN = "00" + PrevNar[33].ToString(); }
                    }
                    else { PNarSTEPEN = "0" + PrevNar[33].ToString(); }
                }
                else { PNarSTEPEN = PrevNar[33].ToString(); }
            }
            else if (PrevNar[30] > 3 && PrevNar[30] < 7) {
                if (PrevNar[39] < 1000)
                {
                    if (PrevNar[39] < 100)
                    {
                        if (PrevNar[39] < 10)
                        {
                            PNarSTEPEN = "000" + PrevNar[39].ToString();
                        }
                        else { PNarSTEPEN = "00" + PrevNar[39].ToString(); }
                    }
                    else { PNarSTEPEN = "0" + PrevNar[39].ToString(); }
                }
                else { PNarSTEPEN = PrevNar[39].ToString(); }
            }
            else { PNarSTEPEN = "0000"; }



            if (KolOs < 10)
            {
                if (PrevNar[34] < 10) { CodNar = PrevNar[25].ToString() + "0" + PrevNar[26].ToString() + PrevNar[27].ToString() + PrevNar[28].ToString() + PrevNar[29].ToString() + PrevNar[30].ToString() + "0" + PrevNar[31].ToString() + PrevNar[32].ToString() + PNarSTEPEN.ToString() + "0" + PrevNar[34].ToString() + "00"; }

                else { CodNar = PrevNar[25].ToString() + "0" + PrevNar[26].ToString() + PrevNar[27].ToString() + PrevNar[28].ToString() + PrevNar[29].ToString() + PrevNar[30].ToString() + "0" + PrevNar[31].ToString() + PrevNar[32].ToString() + PNarSTEPEN.ToString() + PrevNar[34].ToString() + "00"; }
            }
            else
            {
                if (PrevNar[34] < 10) { CodNar = PrevNar[25].ToString() + //срок поверки 1
                        PrevNar[26].ToString() + //количество осей 2
                        PrevNar[27].ToString() + //вид атс 1
                        PrevNar[28].ToString() + //тип атс 1
                        PrevNar[29].ToString() + //спец.разр 1
                        PrevNar[30].ToString() + //вид нарушения 1
                        PrevNar[31].ToString() + //детализация нарушения (№оси)2
                        PrevNar[32].ToString() + //превышение чего ПДК или СР 1
                       PNarSTEPEN.ToString() + "0" + //степень превышения 3
                        PrevNar[34].ToString() + "00"; } //часть статьи 2

                else { CodNar = PrevNar[25].ToString() + PrevNar[26].ToString() + PrevNar[27].ToString() + PrevNar[28].ToString() + PrevNar[29].ToString() + PrevNar[30].ToString() + PrevNar[31].ToString() + PrevNar[32].ToString() + PNarSTEPEN.ToString() + PrevNar[34].ToString() + "00"; }
            }
            CodNar = CodNar;


            int i1 = 0;
            int i2 = 0;
            int cnt = 0;
            tipoS = "";
          
            for (i1 = 0; i1 < 9; i1++)
            {
                if (KN[1, i1] > 0)
                {
                    tipoS = tipoS + KN[1, i1].ToString() + "+";
                }
            }
            if (tipoS != "")
            {
                tipoS = tipoS.Remove(tipoS.Length - 1, 1);
            }
            
            alphaBlendTextBox12.Text = FFF + ", схема: " + tipoS;
            alphaBlendTextBox17.Text = alphaBlendTextBox12.Text;
        }
        #endregion ///////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////

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
                    alphaBlendTextBox11.Text = reader2["Kategory"].ToString();
                    alphaBlendTextBox84.Text = reader2["SubCategory"].ToString();
                    alphaBlendTextBox19.Text = alphaBlendTextBox11.Text;
                    IDKLLeft = Convert.ToInt32(reader2["idklassts"].ToString());
                    FFF = reader2["naimklassts"].ToString();
                    if (FFF.Length > 11)
                    {
                        if (FFF.Substring(0, 9).ToString() == ("Автопоезд") || FFF.Substring(FFF.Length - 11, 11).ToString() == (" с прицепом"))
                        { FFFT = "Автопоезд"; PrevNar[27] = 2; }
                        else { FFFT = "Одиночное"; PrevNar[27] = 1; }
                    }
                    else
                    { FFFT = "Одиночное"; PrevNar[27] = 1; }
                    if (PrevNar[27]==1|| PrevNar[27] == 0)//reader2["tipschema"].ToString().Length == 1)
                    { TTS = 1; }
                    else if (PrevNar[27] == 2)//reader2["tipschema"].ToString().Length > 1)
                    { TTS = 2; }
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
                if (PrevNar[27] == 0)
                {
                    if (alphaBlendTextBox11.Text.ToString() != "6" && alphaBlendTextBox11.Text.ToString() != "9" && alphaBlendTextBox11.Text.ToString() != "8" && alphaBlendTextBox11.Text.ToString() != "7"  )
                        { FFFT = "Одиночное"; PrevNar[27] = 1; TTS = 1; FFF = "Одиночное ТС"; }
                    else
                    { FFFT = "Автопоезд"; PrevNar[27] = 2; TTS = 2; FFF = "Автопоезд"; }
                }
            }
        }
        #endregion/////////////////////////////////////////////        

        #region/////////////////////////////////////////////   Общ.масса запрос ПДК 
        public void ZObPDK()
        {
            int KO1;
            MySqlCommand command2 = new MySqlCommand();
            ConnectStr conStr2 = new ConnectStr();
            conStr2.ConStr(1);
            Zapros zapros2 = new Zapros();
            string connectionString2;//, commandString;
            connectionString2 = conStr2.StP;//"Data source=localhost;UserId=root;Password=1q2w3e$R;database=camloc;";
            MySqlConnection connection2 = new MySqlConnection(connectionString2);
            if (TTS == 1 && KolOs > 5)
            { KO1 = 5; }
            else if (TTS == 2 && KolOs > 6)
            { KO1 = 6; }
            else { KO1 = KolOs; }
            zapros2.PDObshMass(KO1, TTS);
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
                    alphaBlendTextBox22.Text = Convert.ToString(Math.Round(ObshMass / 1000, 3));
                    alphaBlendTextBox36.Text = Convert.ToString(Math.Round(ObshMass / 1000 - (ObshMass / 1000 / 100 * 5),3));
                    alphaBlendTextBox23.Text = Convert.ToString(Math.Round(Convert.ToDouble(reader2["pdmassts"].ToString()), 3));
                    if (XDate[12] == "False")
                    {
                        if (Convert.ToDouble(alphaBlendTextBox36.Text) <= Convert.ToDouble(alphaBlendTextBox23.Text))
                        {
                            alphaBlendTextBox28.Text = "Не выявлено";
                            alphaBlendTextBox27.Visible = false;
                            alphaBlendTextBox24.Visible = false;
                        }
                        else if (Convert.ToDouble(alphaBlendTextBox36.Text) > Convert.ToDouble(alphaBlendTextBox23.Text))
                        {
                            alphaBlendTextBox28.Text = "Превышение по общей массе";
                            alphaBlendTextBox27.Visible = true;
                            alphaBlendTextBox24.Visible = true;
                            alphaBlendTextBox27.Text = Convert.ToString(Math.Round(Convert.ToDouble(alphaBlendTextBox36.Text) - Convert.ToDouble(alphaBlendTextBox23.Text), 3));//"11.34 тонн";
                            alphaBlendTextBox24.Text = Convert.ToString(Math.Round(Convert.ToDouble(alphaBlendTextBox36.Text) / (Convert.ToDouble(alphaBlendTextBox23.Text) / 100) - 100, 0));
                            if (Convert.ToDouble(alphaBlendTextBox24.Text) >= 3)
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
                        else if (XDate[12] == "False")
                        { XDate[28] = "0"; }
                    }
                    else
                    {
                        ///////////////
                        label99.Visible = true;
                        alphaBlendTextBox20.Visible = true;
                        alphaBlendTextBox20.Text = XDate[26].ToString();
                        if (Convert.ToDouble(alphaBlendTextBox36.Text) <= Convert.ToDouble(alphaBlendTextBox20.Text))
                        {                            
                            alphaBlendTextBox28.Text = "Не выявлено";
                            alphaBlendTextBox27.Visible = false;
                            alphaBlendTextBox24.Visible = false;
                        }
                        else if (Convert.ToDouble(alphaBlendTextBox36.Text) > Convert.ToDouble(alphaBlendTextBox20.Text))
                        {
                            alphaBlendTextBox28.Text = "Превышение по общей массе";
                            alphaBlendTextBox27.Visible = true;
                            alphaBlendTextBox24.Visible = true;
                            alphaBlendTextBox27.Text = Convert.ToString(Math.Round(Convert.ToDouble(alphaBlendTextBox36.Text) - Convert.ToDouble(alphaBlendTextBox20.Text), 3));//"11.34 тонн";
                            alphaBlendTextBox24.Text = Convert.ToString(Math.Round(Convert.ToDouble(alphaBlendTextBox36.Text) / (Convert.ToDouble(alphaBlendTextBox20.Text) / 100) - 100, 0));
                            if (Convert.ToDouble(alphaBlendTextBox24.Text) >= 3)
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
                        if ((Convert.ToDouble(alphaBlendTextBox36.Text)) - (Convert.ToDouble(alphaBlendTextBox20.Text)) <= 0)
                        {
                            XDate[27] = "0";
                        }
                        else
                        {
                            XDate[27] = Convert.ToString((Convert.ToDouble(alphaBlendTextBox36.Text)) - (Convert.ToDouble(alphaBlendTextBox20.Text)));
                        }
                        XDate[28] = Convert.ToString(Convert.ToDouble(XDate[25]) - Convert.ToDouble(XDate[26]));
                        if (Convert.ToDouble(XDate[28]) <= 0)
                        {
                            XDate[28] = "0";
                        }
                        else if (XDate[12] == "False")
                        { XDate[28] = "0"; }
                        /////////////////////////
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
        }
        #endregion///////////////////////////////////////////// 
        #region/////////////////////////////////////////////   Габариты запрос ПДК 
        public void ZGabarPDK()
        {
            alphaBlendTextBox42.Text = Convert.ToString(Math.Round(DLINATS / 100, 2));
            alphaBlendTextBox37.Text = Convert.ToString((Math.Round(DLINATS / 100, 2)) - 0.6);//длина
            if (PrevNar[27] == 1) { alphaBlendTextBox41.Text = Convert.ToString(12.00); }
            else if (PrevNar[27] == 2) { alphaBlendTextBox41.Text = Convert.ToString(20.00); }
            alphaBlendTextBox45.Text = Convert.ToString(Math.Round(SHIRTS / 100, 2));
            if ((Math.Round(SHIRTS / 100, 2) - 0.1) > 0)
            {
                alphaBlendTextBox43.Text = Convert.ToString((Math.Round(SHIRTS / 100, 2)) - 0.1);//ширина
            }
            else { alphaBlendTextBox43.Text = "0"; }
            alphaBlendTextBox44.Text = Convert.ToString(2.60);

            alphaBlendTextBox48.Text = Convert.ToString(Math.Round(VISTS / 100, 2));
            if ((Math.Round(VISTS / 100, 2) - 0.06) > 0)
            {
                alphaBlendTextBox46.Text = Convert.ToString((Math.Round(VISTS / 100, 2)) - 0.06);//высота
            }
            else { alphaBlendTextBox46.Text = "0"; }
            alphaBlendTextBox47.Text = Convert.ToString(4.00);
            alphaBlendTextBox38.Text = "Не выявлено";
            ///////////////////// Длина превыш
            if (Convert.ToDouble(alphaBlendTextBox37.Text.ToString()) - Convert.ToDouble(alphaBlendTextBox41.Text.ToString()) > 0)
            {
                XDate[9] = Convert.ToString(Convert.ToDouble(alphaBlendTextBox37.Text.ToString()) - Convert.ToDouble(alphaBlendTextBox41.Text.ToString()));
               PrevNar[38] = 1;
                PrevNar[39] = Math.Round(Convert.ToDouble(XDate[9]) * 100 , 0);
                PrevDlPr = Convert.ToDouble(Math.Round(100-(Convert.ToDouble(alphaBlendTextBox41.Text.ToString()) / Convert.ToDouble(alphaBlendTextBox37.Text.ToString())* 100), 0));
                PrevNar[18] = PrevDlPr;
                alphaBlendTextBox38.Text = "Превышение длины на " + Math.Round(Convert.ToDouble(XDate[9]), 2) + " м." ;
            }
            if (Convert.ToDouble(alphaBlendTextBox37.Text.ToString()) - Convert.ToDouble(alphaBlendTextBox41.Text.ToString()) <= 0)
            {
                XDate[9] = "0";
            }
            ////////////////// Ширина превыш
            if (Convert.ToDouble(alphaBlendTextBox43.Text.ToString()) - Convert.ToDouble(alphaBlendTextBox44.Text.ToString()) > 0)
            {
                XDate[10] = Convert.ToString(Convert.ToDouble(alphaBlendTextBox43.Text.ToString()) - Convert.ToDouble(alphaBlendTextBox44.Text.ToString()));
                PrevNar[38] = 1;
                PrevNar[39] = Math.Round(Convert.ToDouble(XDate[10]) * 100, 0);
                PrevDlPr = Convert.ToDouble(Math.Round(100 - (Convert.ToDouble(alphaBlendTextBox44.Text.ToString()) / Convert.ToDouble(alphaBlendTextBox43.Text.ToString()) * 100), 0));
                PrevNar[19] = PrevDlPr;
                alphaBlendTextBox38.Text = "Превышение ширины на " + Math.Round(Convert.ToDouble(XDate[10]), 2) + " м.";
            }
            if (Convert.ToDouble(alphaBlendTextBox43.Text.ToString()) - Convert.ToDouble(alphaBlendTextBox44.Text.ToString()) <= 0)
            {
                XDate[10] = "0";
            }
            ///////////////// Высота превыш
            if (Convert.ToDouble(alphaBlendTextBox46.Text.ToString()) - Convert.ToDouble(alphaBlendTextBox47.Text.ToString()) > 0)
            {
                XDate[11] = Convert.ToString(Convert.ToDouble(alphaBlendTextBox46.Text.ToString()) - Convert.ToDouble(alphaBlendTextBox47.Text.ToString()));
                PrevNar[38] = 1;
                PrevNar[39] = Math.Round(Convert.ToDouble(XDate[11]) * 100, 0);
                PrevDlPr = Convert.ToDouble(Math.Round(100 - (Convert.ToDouble(alphaBlendTextBox47.Text.ToString()) / Convert.ToDouble(alphaBlendTextBox46.Text.ToString()) * 100), 0));
                PrevNar[20] = PrevDlPr;
                alphaBlendTextBox38.Text = "Превышение высоты на " + Math.Round(Convert.ToDouble(XDate[11]), 2) + " м.";
            }
            if (Convert.ToDouble(alphaBlendTextBox46.Text.ToString()) - Convert.ToDouble(alphaBlendTextBox47.Text.ToString()) <= 0)
            {
                XDate[11] = "0";
            }
            ////////////////////////// И по СР
            ///////////////////// Длина превыш
            if (XDate[12].ToString() != "False")
            {
                label100.Visible = true; label101.Visible = true; label102.Visible = true;
                alphaBlendTextBox21.Visible = true; alphaBlendTextBox81.Visible = true; alphaBlendTextBox82.Visible = true;
                alphaBlendTextBox21.Text = XDate[19].ToString(); alphaBlendTextBox81.Text= XDate[20].ToString(); alphaBlendTextBox82.Text= XDate[21];

                if (Convert.ToDouble(alphaBlendTextBox37.Text.ToString()) - Convert.ToDouble(XDate[19].ToString()) > 0)
                {
                    XDate[22] = Convert.ToString(Convert.ToDouble(alphaBlendTextBox37.Text.ToString()) - Convert.ToDouble(XDate[19].ToString()));
                    PrevNar[38] = 1;
                    PrevNar[39] = Math.Round(Convert.ToDouble(XDate[22]) * 100, 0);
                    PrevDlPr = Convert.ToDouble(Math.Floor(Math.Round(Convert.ToDouble(alphaBlendTextBox37.Text.ToString()) / Convert.ToDouble(alphaBlendTextBox41.Text.ToString()) / 100 - 100, 2)));
                    alphaBlendTextBox38.Text = "Превышение длины на " + Math.Round(Convert.ToDouble(XDate[22]), 2) + " м.";
                }
                if (Convert.ToDouble(alphaBlendTextBox37.Text.ToString()) - Convert.ToDouble(XDate[19].ToString()) <= 0)
                {
                    XDate[22] = "0";
                }
                ////////////////// Ширина превыш
                if (Convert.ToDouble(alphaBlendTextBox43.Text.ToString()) - Convert.ToDouble(XDate[20].ToString()) > 0)
                {
                    XDate[23] = Convert.ToString(Convert.ToDouble(alphaBlendTextBox43.Text.ToString()) - Convert.ToDouble(XDate[20].ToString()));
                }
                if (Convert.ToDouble(alphaBlendTextBox43.Text.ToString()) - Convert.ToDouble(XDate[20].ToString()) <= 0)
                {
                    XDate[23] = "0";
                }
                ///////////////// Высота превыш
                if (Convert.ToDouble(alphaBlendTextBox48.Text.ToString()) - Convert.ToDouble(XDate[21].ToString()) > 0)
                {
                    XDate[24] = Convert.ToString(Convert.ToDouble(alphaBlendTextBox48.Text.ToString()) - Convert.ToDouble(XDate[21].ToString()));
                }
                if (Convert.ToDouble(alphaBlendTextBox48.Text.ToString()) - Convert.ToDouble(XDate[21].ToString()) <= 0)
                {
                    XDate[24] = "0";
                }
            }
            else
            {
                XDate[22] = "0";
                XDate[23] = "0";
                XDate[24] = "0";
            }         
        }
        #endregion///////////////////////////////////////////// 
        #region/////////////////////////////////////////////   Осевая масса запрос ПДК 
        public void ZOsPDK()
        {   int ig = 0;
            int io = 0;
            int ipr = 0;
           double[] SRdist = new double[10];
            double[] massGR = new double[10];
            double[] SRdistO = new double[10];

            //////for (ic = 1; ic < KolOs + 1; ic++)
            //////{
            //////    if (Convert.ToInt32(TypO[ic]) > 1 && D[ic - 1] <= D[ic] && D[ic - 2] > D[ic - 1])
            //////    {
            //////        NagrTel = 0; // - общая масса группы 
            //////        for (int iTel = ic - 1; iTel < ic - 1 + TypO[ic]; iTel++)
            //////        { massGR[ic] = massGR[ic] + (BetOs[13, iTel - 1]/*- BetOs[13, iTel]/100*10*/); }
            //////    }

            //////}

            //////while (ig < KolGr+1)
            //////{
            //////    if (D[ig] == 0)
            //////    { SRdist[ig] = 0; }
            //////    else
            //////    {
            //////        while ((D[io + 1] > 0 && D[io + 1] < 2.50) || io == 0)
            //////        {
            //////            if (io != 0)
            //////            {
            //////                SRdist[ig] = (SRdist[ig] + D[io]);
            //////                //massGR[ig] = massGR[ig] + BetOs[13, io];
            //////            }
            //////            io++;
            //////        }
            //////    }
            //////    SRdist[ig] = SRdist[ig] / (io - ipr);
            //////    ipr = io;
            //////    ig++;
            //////}
            //////ig = 0;
            //////io = 0;
            //////while (ig < KolGr + 1)
            //////{
            //////    while ((D[io + 1] > 0 && D[io + 1] < 2.50) || io == 0)
            //////    {
            //////        if (io != 0)
            //////        {
            //////            SRdistO[io] = SRdist[ig];
            //////        }
            //////        io++;
            //////    }
            //////    ig++;
            //////}

            //if (Convert.ToInt32(TypO[ic]) > 1 && D[ic - 1] > D[ic] && D[ic - 1] > D[ic - 2] && D[ic] != 0)
            //{
            //    SrednRTel = 0; // среднее расстояние
            //    for (int iRTel = ic; iRTel < ic - 1 + TypO[ic]; iRTel++)
            //    {

            //        SrednRTel = SrednRTel + D[iRTel]; /*}*/
            //    }

            //проходим по осям и делаем выборку по группам
            for (ic = 1; ic < KolOs + 1; ic++)
            {
                if (ic <= 9)
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
                        if (Convert.ToInt32(TypO[ic]) > 1 && D[ic - 1] == 0)// если сдвоенная/строенная но первая т.е. перед ней нет ни одной оси
                        {
                            zapros2.PDOsNagr(Convert.ToInt32(DoubO[ic]), Convert.ToInt32(TypO[ic]), ADNagr, (D[ic] * 100));

                        }
                        else if (Convert.ToInt32(TypO[ic]) > 1 && D[ic - 1] <= D[ic] && D[ic-1]>=2.5)// если сдвоенная/строенная предидущее расстояние меньше настоящего (напр: 1+2... а это 3)
                        {
                            
                                if (Convert.ToInt32(DoubO[ic]) > Convert.ToInt32(DoubO[ic - 1]))// если текущая скатность больше предидущей в гр.
                                {
                                    zapros2.PDOsNagr(Convert.ToInt32(DoubO[ic - 1]), Convert.ToInt32(TypO[ic]), ADNagr, (SrednRTel / (TypO[ic] - 1) * 100)); //(D[ic - 1] * 100));
                                }
                                else { zapros2.PDOsNagr(Convert.ToInt32(DoubO[ic]), Convert.ToInt32(TypO[ic]), ADNagr, (SrednRTel / (TypO[ic] - 1) * 100)); } //(D[ic - 1] * 100)); }
                            //////}
                            //////else { zapros2.PDOsNagr(Convert.ToInt32(DoubO[ic]), Convert.ToInt32(TypO[ic]), ADNagr, (D[ic - 1] * 100)); }

                        }
                        else if (Convert.ToInt32(TypO[ic]) > 1 && D[ic - 1] <= D[ic] )// если сдвоенная/строенная предидущее расстояние меньше настоящего (напр: 1+2... а это 3)
                        {

                            if (Convert.ToInt32(DoubO[ic]) > Convert.ToInt32(DoubO[ic - 1]))// если текущая скатность больше предидущей в гр.
                            {
                                zapros2.PDOsNagr(Convert.ToInt32(DoubO[ic - 1]), Convert.ToInt32(TypO[ic]), ADNagr, (D[ic - 1] * 100)); } //(SrednRTel / (TypO[ic] - 1) * 100)); //(D[ic - 1] * 100)); }
                            else { zapros2.PDOsNagr(Convert.ToInt32(DoubO[ic]), Convert.ToInt32(TypO[ic]), ADNagr, (D[ic - 1] * 100)); } // (SrednRTel / (TypO[ic] - 1) * 100)); } //(D[ic - 1] * 100)); }
                            //////}
                            //////else { zapros2.PDOsNagr(Convert.ToInt32(DoubO[ic]), Convert.ToInt32(TypO[ic]), ADNagr, (D[ic - 1] * 100)); }

                        }
                        else if (Convert.ToInt32(TypO[ic]) > 1 && D[ic - 1] > D[ic] && D[ic] != 0)// если сдвоенная/строенная предидущее расстояние больше настоящего (напр: 1+2... а это 2)
                        {

                            if (D[ic] < 2.5)
                            {
                                if (Convert.ToInt32(TypO[ic]) > 1 && D[ic - 1] > D[ic] && D[ic - 1] > D[ic - 2] && D[ic] != 0 && D[ic - 1]>=2.5)
                                {
                                    SrednRTel = 0;
                                    for (int iRTel = ic; iRTel < ic - 1 + TypO[ic]; iRTel++)
                                    {
                                        //if (TypO[ic] == 2)
                                        //{ SrednRTel = SrednRTel + D[ic] + D[ic]; }
                                        //else
                                        /*{*/
                                        SrednRTel = SrednRTel + D[iRTel]; /*}*/
                                    }
                                }
                                if (Convert.ToInt32(DoubO[ic]) > Convert.ToInt32(DoubO[ic + 1]))
                                {
                                    zapros2.PDOsNagr(Convert.ToInt32(DoubO[ic + 1]), Convert.ToInt32(TypO[ic]), ADNagr, (SrednRTel / (TypO[ic] - 1) * 100)); //(D[ic] * 100));
                                }
                                else { zapros2.PDOsNagr(Convert.ToInt32(DoubO[ic]), Convert.ToInt32(TypO[ic]), ADNagr, (SrednRTel / (TypO[ic] - 1) * 100)); } //(D[ic] * 100)); }
                            }
                        }

                        else if (Convert.ToInt32(TypO[ic]) == 1)
                        {
                            if (D[ic] == 2.5)
                            {
                                D[ic] = 2.51;
                                zapros2.PDOsNagr(Convert.ToInt32(DoubO[ic]), Convert.ToInt32(TypO[ic]), ADNagr, (D[ic] * 100));
                                D[ic] = 2.5;
                            }
                            else
                            { zapros2.PDOsNagr(Convert.ToInt32(DoubO[ic]), Convert.ToInt32(TypO[ic]), ADNagr, (D[ic] * 100)); }

                        }
                    }
                    else
                    {
                        if (D[ic - 1] < 2.5)
                        {
                            if (Convert.ToInt32(DoubO[ic]) > Convert.ToInt32(DoubO[ic - 1]))
                            {
                                zapros2.PDOsNagr(Convert.ToInt32(DoubO[ic - 1]), Convert.ToInt32(TypO[ic]), ADNagr, (D[ic - 1] * 100));
                            }
                            else { zapros2.PDOsNagr(Convert.ToInt32(DoubO[ic]), Convert.ToInt32(TypO[ic]), ADNagr, (D[ic - 1] * 100)); }
                        }
                        else
                        {
                            zapros2.PDOsNagr(Convert.ToInt32(DoubO[ic]), Convert.ToInt32(TypO[ic]), ADNagr, (D[ic - 1] * 100));
                        }
                    }

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
                            //PDKO[ic] = Convert.ToDouble(reader2["pdo"].ToString());
                            PDKTel[ic] = Convert.ToDouble(reader2["pdt"].ToString());
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

            for (ic = 1; ic < KolOs + 1; ic++) //// ПДК по осям
            {
                if (ic <= 9)
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
                        if (Convert.ToInt32(TypO[ic]) > 1 && D[ic - 1] == 0)// если сдвоенная/строенная но первая т.е. перед ней нет ни одной оси
                        {
                            zapros2.PDOsNagr(Convert.ToInt32(DoubO[ic]), Convert.ToInt32(TypO[ic]), ADNagr, (D[ic] * 100));

                        }
                        else if (Convert.ToInt32(TypO[ic]) > 1 && D[ic - 1] <= D[ic])// если сдвоенная/строенная предидущее расстояние меньше настоящего (напр: 1+2... а это 3)
                        {
                            //////if (Convert.ToInt32(TypO[ic]) > 1 && D[ic - 1] <= D[ic] && D[ic - 2] > D[ic-1])
                            //////{ NagrTel = 0;
                            //////    for (int iTel = ic-1; iTel < ic - 1 +TypO[ic]; iTel++)
                            //////    { NagrTel = NagrTel + (BetOs[13, iTel-1]/*- BetOs[13, iTel]/100*10*/); }
                            //////}
                            if (NagrTel/1000 - PDKTel[ic-1] > 0)//если суммарная масса по группе выше ПДК группы
                            {
                                //PDKO[ic] = PDKO[ic-1];
                                //PDKTel[ic] = PDKTel[ic-1];
                                if (Convert.ToInt32(DoubO[ic]) > Convert.ToInt32(DoubO[ic - 1]))// если текущая скатность больше предидущей в гр.
                                {
                                    zapros2.PDOsNagr(Convert.ToInt32(DoubO[ic - 1]), Convert.ToInt32(TypO[ic]), ADNagr, (SrednRTel / (TypO[ic] - 1) * 100)); //(D[ic - 1] * 100));
                                }
                                else { zapros2.PDOsNagr(Convert.ToInt32(DoubO[ic]), Convert.ToInt32(TypO[ic]), ADNagr, (SrednRTel / (TypO[ic] - 1) * 100)); } //(D[ic - 1] * 100)); }
                                }
                            else {
                                //if (Convert.ToInt32(DoubO[ic]) > Convert.ToInt32(DoubO[ic - 1]))// если текущая скатность больше предидущей в гр.
                                //{
                                //    zapros2.PDOsNagr(Convert.ToInt32(DoubO[ic - 1]), Convert.ToInt32(TypO[ic]), ADNagr, (D[ic - 1] * 100)); //(D[ic - 1] * 100));
                                //}
                                /*else { */zapros2.PDOsNagr(Convert.ToInt32(DoubO[ic]), Convert.ToInt32(TypO[ic]), ADNagr, (D[ic - 1] * 100));/* }*/
                                //zapros2.PDOsNagr(Convert.ToInt32(DoubO[ic]), Convert.ToInt32(TypO[ic]), ADNagr, (D[ic - 1] * 100)); 
                            }

                        }
                        else if (Convert.ToInt32(TypO[ic]) > 1 && D[ic - 1] > D[ic] && D[ic] != 0)// если сдвоенная/строенная предидущее расстояние больше настоящего (напр: 1+2... а это 2)
                        {

                            if (D[ic] < 2.5)
                            {
                                if (Convert.ToInt32(TypO[ic]) > 1 && D[ic - 1] > D[ic] && D[ic - 1] >= 2.5 && D[ic] != 0)
                                {
                                    SrednRTel = 0;
                                    for (int iRTel = ic; iRTel < ic - 1 + TypO[ic]; iRTel++)
                                    {
                                        //if (TypO[ic] == 2)
                                        //{ SrednRTel = SrednRTel + D[ic] + D[ic]; }
                                        //else
                                        /*{*/
                                        SrednRTel = SrednRTel + D[iRTel]; /*}*/
                                    }
                                    NagrTel = 0;
                                    for (int iTel = ic; iTel < ic - 1 + TypO[ic]; iTel++)
                                    { NagrTel = NagrTel + (BetOs[13, iTel - 1]/*- BetOs[13, iTel]/100*10*/); }
                                }
                                if (NagrTel / 1000 - PDKTel[ic - 1] > 0)//если суммарная масса по группе выше ПДК группы
                                {
                                    if (Convert.ToInt32(DoubO[ic]) > Convert.ToInt32(DoubO[ic + 1]))
                                    {
                                        zapros2.PDOsNagr(Convert.ToInt32(DoubO[ic + 1]), Convert.ToInt32(TypO[ic]), ADNagr, (SrednRTel / (TypO[ic] - 1) * 100)); //(D[ic] * 100));
                                    }
                                    else { zapros2.PDOsNagr(Convert.ToInt32(DoubO[ic]), Convert.ToInt32(TypO[ic]), ADNagr, (SrednRTel / (TypO[ic] - 1) * 100)); } //(D[ic] * 100)); }
                                }
                                else { zapros2.PDOsNagr(Convert.ToInt32(DoubO[ic]), Convert.ToInt32(TypO[ic]), ADNagr, (SrednRTel / (TypO[ic] - 1) * 100)); }
                            }
                        }
          
                        else if (Convert.ToInt32(TypO[ic]) == 1)
                        {
                            if (D[ic] == 2.5)
                            {
                                D[ic] = 2.51;
                                zapros2.PDOsNagr(Convert.ToInt32(DoubO[ic]), Convert.ToInt32(TypO[ic]), ADNagr, (D[ic] * 100));
                                D[ic] = 2.5;
                            }
                            else
                            { zapros2.PDOsNagr(Convert.ToInt32(DoubO[ic]), Convert.ToInt32(TypO[ic]), ADNagr, (D[ic] * 100)); }

                        }
                    }
                    else {
                        if (D[ic - 1] < 2.5)
                        {
                            if (Convert.ToInt32(DoubO[ic]) > Convert.ToInt32(DoubO[ic - 1]))
                            {
                                zapros2.PDOsNagr(Convert.ToInt32(DoubO[ic - 1]), Convert.ToInt32(TypO[ic]), ADNagr, (D[ic - 1] * 100));
                            }
                            else { zapros2.PDOsNagr(Convert.ToInt32(DoubO[ic]), Convert.ToInt32(TypO[ic]), ADNagr, (D[ic - 1] * 100)); }
                        }
                        else
                        {
                            zapros2.PDOsNagr(Convert.ToInt32(DoubO[ic]), Convert.ToInt32(TypO[ic]), ADNagr, (D[ic - 1] * 100));
                        }
                        }

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
                            //PDKTel[ic] = Convert.ToDouble(reader2["pdt"].ToString());
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
      

        private void button9_Click(object sender, EventArgs e)
        {
            int IDT = Convert.ToInt32(alphaBlendTextBox25.Text);
            WCPSoapClientForm.Form1 FRMALEX = new WCPSoapClientForm.Form1();
            FRMALEX.ACc = AC; FRMALEX.AIc = AI; FRMALEX.ALc = AL; FRMALEX.DTc = DT; FRMALEX.CPCc = CPC;
            FRMALEX.Dc = Dc; FRMALEX.TWc = TW; FRMALEX.GRZc = GRZ; FRMALEX.Hc = H; FRMALEX.Lc = L; FRMALEX.Wc = W;
            FRMALEX.IdPr = Convert.ToInt32(alphaBlendTextBox25.Text);
            FRMALEX.ShowDialog(); //Show();
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
            FormKartMonit_LoadPMonit(IDT, NamU, RazrG);
        }        
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

        private void label62_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            if (iPic > 0 && iPic <= PicCount+1)
            {
                iPic = iPic - 1;
                if (iPic == 0)
                { iPic = PicCount; }
                    pictureBox40.Image = null;
                    pictureBox40.Image = ImN[iPic];
            }
            else
            {
                iPic = PicCount+1;
            }
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            if (iPic > 0 && iPic <= PicCount)
            {
                iPic = iPic + 1;
                if (iPic== PicCount+1)
                { iPic = 1; }
                if (iPic == 10)
                {
                    pictureBox40.Image = null;
                    pictureBox40.Image = ImN[iPic];
                }
                if (iPic == 9)
                {
                    pictureBox40.Image = null;
                    pictureBox40.Image = ImN[iPic];
                }
                if (iPic == 8)
                {                    
                    pictureBox40.Image = null;
                    pictureBox40.Image = ImN[iPic];
                }
                if (iPic == 7)
                {
                    pictureBox40.Image = null;
                    pictureBox40.Image = ImN[iPic];
                }
                if (iPic == 6)
                {
                    pictureBox40.Image = null;
                    pictureBox40.Image = ImN[iPic];
                }
                if (iPic == 5)
                {
                    pictureBox40.Image = null;
                    pictureBox40.Image = ImN[iPic];
                }
                if (iPic == 4)
                {
                    pictureBox40.Image = null;
                    pictureBox40.Image = ImN[iPic];
                }
                if (iPic == 3)
                {
                    pictureBox40.Image = null;
                    pictureBox40.Image = ImN[iPic];
                }
                if (iPic == 2)
                {
                    pictureBox40.Image = null;
                    pictureBox40.Image = ImN[iPic];
                }
                if (iPic == 1)
                {
                    pictureBox40.Image = null;
                    pictureBox40.Image = ImN[iPic];
                }
            }
            else
            {
                iPic = 0;
            }
        }

        private void dataGridView4_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView4.Rows.Count > 0)
            {
                int currentRow = dataGridView4.CurrentRow.Index; // номер строки, по которой кликнули
                alphaBlendTextBox8.Text = dataGridView4[1, currentRow].Value.ToString(); 
                ZagrdataGridView4(Convert.ToInt64(dataGridView4[7, currentRow].Value.ToString()), dataGridView4[1, currentRow].Value.ToString());
            }
        }

        public void ZagrdataGridView4(Int64 IDp, string NSpR)
        {
            alphaBlendTextBox14.Text = "-";
            alphaBlendTextBox10.Text = "-";
            alphaBlendTextBox9.Text = "-";
            alphaBlendTextBox7.Text = "-";
            alphaBlendTextBox6.Text = "-";
            alphaBlendTextBox5.Text = "-";
            alphaBlendTextBox4.Text = "-";
            alphaBlendTextBox3.Text = "-";
            alphaBlendTextBox2.Text = "-";
            alphaBlendTextBox15.Text = "-";

            MySqlCommand commandR = new MySqlCommand();
            ConnectStr conStrR = new ConnectStr();
            conStrR.ConStr(1);
            Zapros zaprosR = new Zapros();
            string connectionStringR;//, commandString;
            connectionStringR = conStrR.StP;//"Data source=localhost;UserId=root;Password=1q2w3e$R;database=camloc;";
            MySqlConnection connectionR = new MySqlConnection(connectionStringR);
            zaprosR.StatSRKonkr(IDp, NSpR);
            zR = zaprosR.commandStringTest;
            commandR.CommandText = zR;// commandString;
            commandR.Connection = connectionR;
            MySqlDataReader readerR;
            try
            {
                string AllOsM="";
                string AllOsl = "";
                string AllOsSk = "";
                string ObshM = "";
                string ObshL = "";
                string ObshH = "";
                string ObshW = "";
                int COS=0;
                commandR.Connection.Open();
                readerR = commandR.ExecuteReader();

                while (readerR.Read())
                {
                    COS = COS+1 ;
                    alphaBlendTextBox14.Text = readerR["KemVid"].ToString();

                    if (readerR["VidPerevoz"].ToString() == "Local")
                    { alphaBlendTextBox10.Text = "региональная"; }
                    if (readerR["VidPerevoz"].ToString() == "Interregional")
                    { alphaBlendTextBox10.Text = "межрегиональная"; }
                    if (readerR["VidPerevoz"].ToString() == "International")
                    { alphaBlendTextBox10.Text = "международная"; }

                    //alphaBlendTextBox10.Text = readerR["VidPerevoz"].ToString();
                    alphaBlendTextBox9.Text = readerR["GRZSR"].ToString();
                    alphaBlendTextBox7.Text = readerR["DateVidSR"].ToString();
                    alphaBlendTextBox6.Text = readerR["SrokDeistvSR"].ToString();
                    alphaBlendTextBox5.Text = readerR["RazrMarshr"].ToString();
                    alphaBlendTextBox4.Text = readerR["OsjbUslDvSR"].ToString();
                    alphaBlendTextBox3.Text = readerR["KolRazrPr"].ToString();
                    alphaBlendTextBox2.Text = readerR["IspolzPR"].ToString();
                    AllOsM = AllOsM +readerR["MasAxSR"].ToString() + "; " ; 
                    AllOsl= AllOsl + readerR["IntervalAxSR"].ToString() + "; ";
                    AllOsSk = AllOsSk + readerR["SkatAxSR"].ToString() + "; ";
                    ObshM = "Общая масса ТС (т.): " + readerR["RazrMassa"].ToString() + "; ";
                    ObshL = "Общая длина ТС (м.): " + readerR["LengthSR"].ToString() + "; " ;
                    ObshH = "Общая ширина ТС: " + readerR["HeightSR"].ToString() + "; ";
                    ObshW = "Общая высота ТС: " + readerR["WidthSR"].ToString() + "; ";
                    alphaBlendTextBox15.Text = ObshM + ObshL + " Количество осей: " + COS + " в т.ч. разрешенные массы (т.):" + AllOsM + "разрешенные интервалы (м.):" + AllOsl + "разрешенные скатности:" + AllOsSk;

                }
                readerR.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: \r\n{0}", ex.ToString());
            }
            finally
            {
                commandR.Connection.Close();
            }
        }

        private void tabControl4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl4.SelectedIndex == 3)
            {
                if (dataGridView4.Rows.Count == 0)
                { groupBox1.Visible = false; }
                else { groupBox1.Visible = true; }               
            }
        }

        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl2.SelectedIndex==5)
            { WMPl1.Update(); /*if (WMPl1.URL!=null) { label42.Visible = true; } */}
        }
        #endregion /////////////////////////////////////////

        private void maskedTextBox1_Click(object sender, EventArgs e)
        {
            if(RazrG == "1")
            { label106.Visible = true;  }
            else
            { label106.Visible = false; }

        }

        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (RazrG == "1")
            { button1.Visible = true; }
            else
            { button1.Visible = false; }
        }

        private void button1_Click(object sender, EventArgs e)//// Сохранение ГРЗ
        {
            string IDTS = alphaBlendTextBox25.Text.ToString();
            OGRZ = maskedTextBox1.Text.ToString();
            chang = 1;

           
            MySqlCommand command = new MySqlCommand();
            ConnectStr conStr = new ConnectStr();
            Zapros zapros = new Zapros();
            conStr.ConStr(1);
            cstr = conStr.StP;
            zapros.ZGRZUpSTAT(Convert.ToString(IDW), DPR, IDTS, OGRZ, NamU, chang, NLP, PLN);
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
            {
                Console.WriteLine("Error: \r\n{0}", ex.ToString());
            }
            finally
            { command.Connection.Close(); }

            //    MySqlCommand command = new MySqlCommand();
            //ConnectStr conStr = new ConnectStr();
            //Zapros zapros = new Zapros();
            conStr.ConStr(1);
            cstr = conStr.StP;
            zapros.ZGRZUp(IDTS, OGRZ, NamU, chang);
            //MySqlConnection connection = new MySqlConnection(cstr);
            /*string*/ z = zapros.commandStringTest;
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

        public void RisOsei()
        {
            #region //////////////////////////////////////////////         рисунок осей             /////////////////////////////////
            pictureBox30.Visible = false;//скобка
            pictureBox41.Visible = false;//стрелка
            string s = label154.Text;
            double i;
            if (label154.Text != "")
                i = Convert.ToDouble(s.ToString());//.Substring(0, 4));
            else i = 0;
            if (i > 0)
            {
                double loc2 = 0;
                string TO;
                TO = "Общая длина ТС - " + Convert.ToDouble(s) + " м. " + "\n" + "Общий вес: " + Math.Round(Convert.ToDouble(ObshMass) / 1000, 3) + " т. ";
                loc2 = 20 * i + 100;
                int loc3 = Convert.ToInt32(loc2);
                pictureBox30.Width = loc3 - 60;
                int newloc = 57 + loc3 / 2;
                pictureBox30.Location = new Point(350, 150);
                double loc = Convert.ToDouble(label154.Text) * 100;
                location = 57 + Convert.ToInt32(20 * loc / 100);
                pictureBox41.Location = new Point(Convert.ToInt32(loc2) + 300, 120);
                pictureBox41.Visible = true;
                label142.Text = TO;
                label142.Location = new Point((loc3 / 2 + 240), 175); //location / 2 + 90), 285);
                label142.BackColor = Color.Transparent;
                pictureBox30.Visible = true;
                label142.Visible = true;
            }

            //////////////////////////////////////////// ПЕРВАЯ ОСЬ
            s = Convert.ToString(Convert.ToDouble(label171.Text.ToString()) * 1000);
            i = 0;
            if (label154.Text != "")
            { i = (Convert.ToInt32(s) - Convert.ToInt32(s) / 100 * 10); }//Convert.ToInt32(znachenie); 
            else i = 0;
            if (i > 0)
            {
                double loc = Convert.ToDouble(label154.Text) * 100;
                location = 370 + Convert.ToInt32(20 * loc / 100);
                pictureBox31.Location = new Point(location, 110);
                pictureBox31.Image = AVGK.Properties.Resources._33777Ч1;
                label171.Location = new Point(location, 138);
                if ((i > 0) && (i < Convert.ToDouble(dataGridView1[9, 0].Value) * 1000))
                {
                    if ((label153.Text != "") && (Convert.ToInt32(label153.Text) > 1))
                    { pictureBox31.Image = AVGK.Properties.Resources._33777Ч2; }
                    else if ((label153.Text != ""))
                    { pictureBox31.Image = AVGK.Properties.Resources._33777Ч1; }
                }
                else if ((i > 0) && (i > Convert.ToDouble(dataGridView1[9, 0].Value) * 1000))
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
                i = (Convert.ToInt32(s) - Convert.ToInt32(s) / 100 * 10);
                if (i > 0)
                {
                    double loc1 = 0;
                    loc1 = location - 20 - 20 * (l[1] * 100 + 40) / 100;// + 45;
                    int loc = Convert.ToInt32(Math.Round(loc1));
                    pictureBox32.Location = new Point(loc, 110);//50 + loc, 223);
                    double locLOs = location - 5 - (20 * (l[1] / 2 * 100 + 40)) / 100;// + 45;
                    int locL = Convert.ToInt32(Math.Round(locLOs));
                    label162.Location = new Point(locL, 90);
                    label170.Location = new Point(loc, 138);

                    if ((i > 0) && (i < Convert.ToDouble(dataGridView1[9, 1].Value) * 1000))
                    {
                        if ((label152.Text != "") && (Convert.ToInt32(label152.Text) > 1))
                        { pictureBox32.Image = AVGK.Properties.Resources._33777Ч2; }
                        else if ((label152.Text != ""))
                        { pictureBox32.Image = AVGK.Properties.Resources._33777Ч1; }
                    }
                    else if ((i > 0) && (i > Convert.ToDouble(dataGridView1[9, 1].Value) * 1000))
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
                i = (Convert.ToInt32(s) - Convert.ToInt32(s) / 100 * 10);
                if (i > 0)
                {
                    label151.Visible = true;
                    double loc1 = 0;
                    loc1 = location - 40 - (20 * ((l[2] + l[1]) * 100 + 40) / 100);
                    int loc = Convert.ToInt32(Math.Round(loc1));
                    pictureBox33.Location = new Point(loc, 110);
                    double locLOs = location - 30 - (20 * ((l[1] + l[2] / 2) * 100 + 40)) / 100;
                    int locL = Convert.ToInt32(Math.Round(locLOs));
                    label161.Location = new Point(locL, 90);
                    label169.Location = new Point(loc, 138);

                    if ((i > 0) && (i < Convert.ToDouble(dataGridView1[9, 2].Value) * 1000))
                    {
                        if ((label151.Text != "") && (Convert.ToInt32(label151.Text) > 1))
                        { pictureBox33.Image = AVGK.Properties.Resources._33777Ч2; }
                        else if (label151.Text != "")
                        { pictureBox33.Image = AVGK.Properties.Resources._33777Ч1; }
                    }
                    else if ((i > 0) && (i > Convert.ToDouble(dataGridView1[9, 2].Value) * 1000))
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
                i = (Convert.ToInt32(s) - Convert.ToInt32(s) / 100 * 10);
                if (i > 0)
                {
                    label150.Visible = true;
                    double loc1 = 0;
                    loc1 = location - 40 - (20 * ((l[3] + l[2] + l[1]) * 100 + 40) / 100);
                    int loc = Convert.ToInt32(Math.Round(loc1));
                    pictureBox34.Location = new Point(loc, 110);
                    double locLOs = location - 40 - (20 * ((l[1] + l[2] + l[3] / 2) * 100 + 40)) / 100;
                    int locL = Convert.ToInt32(Math.Round(locLOs));
                    label160.Location = new Point(locL, 90);
                    label168.Location = new Point(loc, 138);

                    if ((i > 0) && (i < Convert.ToDouble(dataGridView1[9, 3].Value) * 1000))
                    {
                        if ((label150.Text != "") && (Convert.ToInt32(label150.Text) > 1))
                        { pictureBox34.Image = AVGK.Properties.Resources._33777Ч2; }
                        else if (label150.Text != "")
                        { pictureBox34.Image = AVGK.Properties.Resources._33777Ч1; }
                    }
                    else if ((i > 0) && (i > Convert.ToDouble(dataGridView1[9, 3].Value) * 1000))
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
                i = (Convert.ToInt32(s) - Convert.ToInt32(s) / 100 * 10);
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

                    if ((i > 0) && (i < Convert.ToDouble(dataGridView1[9, 4].Value) * 1000))
                    {
                        if ((label149.Text != "") && (Convert.ToInt32(label149.Text) > 1))
                        { pictureBox35.Image = AVGK.Properties.Resources._33777Ч2; }
                        else if (label149.Text != "")
                        { pictureBox35.Image = AVGK.Properties.Resources._33777Ч1; }
                    }
                    else if ((i > 0) && (i > Convert.ToDouble(dataGridView1[9, 4].Value) * 1000))
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
                i = (Convert.ToInt32(s) - Convert.ToInt32(s) / 100 * 10);
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

                    if ((i > 0) && (i < Convert.ToDouble(dataGridView1[9, 5].Value) * 1000))
                    {
                        if ((label148.Text != "") && (Convert.ToInt32(label148.Text) > 1))
                        { pictureBox36.Image = AVGK.Properties.Resources._33777Ч2; }
                        else if (label148.Text != "")
                        { pictureBox36.Image = AVGK.Properties.Resources._33777Ч1; }
                    }
                    else if ((i > 0) && (i > Convert.ToDouble(dataGridView1[9, 5].Value) * 1000))
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
                i = (Convert.ToInt32(s) - Convert.ToInt32(s) / 100 * 10);
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

                    if ((i > 0) && (i < Convert.ToDouble(dataGridView1[9, 6].Value) * 1000))
                    {
                        if ((label147.Text != "") && (Convert.ToInt32(label147.Text) > 1))
                        { pictureBox37.Image = AVGK.Properties.Resources._33777Ч2; }
                        else if (label147.Text != "")
                        { pictureBox37.Image = AVGK.Properties.Resources._33777Ч1; }
                    }
                    else if ((i > 0) && (i > Convert.ToDouble(dataGridView1[9, 6].Value) * 1000))
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
                i = (Convert.ToInt32(s) - Convert.ToInt32(s) / 100 * 10);
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

                    if ((i > 0) && (i < Convert.ToDouble(dataGridView1[9, 7].Value) * 1000))
                    {
                        if ((label146.Text != "") && (Convert.ToInt32(label146.Text) > 1))
                        { pictureBox38.Image = AVGK.Properties.Resources._33777Ч2; }
                        else if (label146.Text != "")
                        { pictureBox38.Image = AVGK.Properties.Resources._33777Ч1; }
                    }
                    else if ((i > 0) && (i > Convert.ToDouble(dataGridView1[9, 7].Value) * 1000))
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
                i = (Convert.ToInt32(s) - Convert.ToInt32(s) / 100 * 10);
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

                    if ((i > 0) && (i < Convert.ToDouble(dataGridView1[9, 8].Value) * 1000))
                    {
                        if ((label145.Text != "") && (Convert.ToInt32(label145.Text) > 1))
                        { pictureBox39.Image = AVGK.Properties.Resources._33777Ч2; }
                        else if (label145.Text != "")
                        { pictureBox39.Image = AVGK.Properties.Resources._33777Ч1; }
                    }
                    else if ((i > 0) && (i > Convert.ToDouble(dataGridView1[9, 8].Value) * 1000))
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

        }
    }
    
}
