using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Threading;


namespace AVGK
{
    public partial class Form2 : Form
    {
        public int NF; int NT; int RF; int RT; int Osh; int OshKK;
        public string rasp; public string AD; public string napr; public string nPol ;
        public string rasp1 = ""; public string AD1 = ""; public string napr1 = ""; public string nPol1 = "";
        public int ColKl; 
        public Boolean[] flags; public Boolean[] flagsSR;//= new Boolean[29]
        public string[] Napr; public string[] NaprSR;
        public Boolean[] flags1 = new Boolean[55]; public Boolean[] flags2 = new Boolean[55]; public Boolean[] flags3 = new Boolean[55]; public Boolean[] flags4 = new Boolean[55];
        public string[] Napr1 = new string [4]; public string[] Napr2 = new string[4]; public string[] Napr3 = new string[4]; public string[] Napr4 = new string[15];
        public int FlStup; public decimal IDStup;
        public int CoZKR; public int CoZKL; public int CoZKROF;
        public int RC; public int RCR; public int RCL; public int RCRO;
        public Int64 NPicMon; public Int64 NPicKR; public Int64 NPicKL; public Int64 NPicKRO;
        public int ColPicMon; public int ColPicKR; public int ColPicKL; public int ColPicKRO;
        public int nM = 0; public int nKR = 0; public int nKl = 0; public int nKRO = 0;
        public int IDPDKO = 0;  public TabPage PreviousTab;  public TabPage CurrentTab; public Int64 IDpish; public Int64 IDW; public string PLN;
        public int ss; public int IDUB = 1; public Bitmap iimgg; int IDLF = 0; int IDRF = 0; Stream ms = null; Stream nz = null;
        Stream onz = null;  private DataSet ds = new DataSet(); private DataTable dt = new DataTable();
        public static double widh; public static int location; public static int locOpisOs;
        public double[] l = new double[9]; public string TSh;  public string TSh11; public string TipoS; public string TipoS11;
        private string[] strus = new string[20];
        public string ChValid = "";
        public string PF = "";
        public string SP = "";
        public string MOb = "";
        public string fGRZ = "";
        public int IndFiltrLeft = 0;
        public int currentRowLeft;
        public int kol; public int kolR; public int kolRR;  public int kol2;
        public int rowIndex = 0; public int rowIndexM = 0;  public int rowIndexR = 0; public int rowIndex2 = 0; int rowNumR; int IDNAPR;
        public string NUs;
        public int V = 0;
        public int R1;
        public DataView dv;
        public int FM = 0;
        public DataSet DS = new DataSet(); public DataSet DSL = new DataSet(); public DataSet DSR = new DataSet();
        public DataSet DSAD = new DataSet(); public DataSet DSPDKO = new DataSet(); public DataSet DSPDK = new DataSet(); public DataSet DSMD = new DataSet(); public DataSet DSU = new DataSet();
        public DataSet DSKL = new DataSet(); public DataSet DSRUB = new DataSet(); public DataSet DSNAPR = new DataSet(); public DataSet DSNAR = new DataSet();
        public DataSet DSLO = new DataSet(); public DataSet DSSR = new DataSet(); public DataSet DSROF = new DataSet(); public DataSet DSPUT = new DataSet();
        public string NarOb; public string NarObMS; public double NarObM; public double NarObMPr; public string NarOs;
        public double NarOsM; public double NarGRM; public double NarOsMPr;
        public int KGr = 1;

        public int j;
        public int Fx;
        public string Sk;
        public int[,] KN = new int[2, 9];
        public int[,] KNR = new int[2, 9];
        public string[,] AxelDateKR = new string[4, 10];
        public double[,] PDK = new double[7, 10];
        public double[,] PDKGR = new double[7, 10];
        public double[] D = new double[10]; ///Группа из скольки колес
        public double[] DoubO = new double[10];///Двойные скаты на какой оси
        public double[] TypO = new double[10];///Тип оси
        public double[] PDKO = new double[10];///PDK оси
        public double[] PDKTel = new double[10];///пдк тележки
        public string[] A1 = new string[250];///Для акта
        public double[] D111 = new double[10];
        public double D1_2 = 0; public double D2_3 = 0; public double D3_4 = 0; public double D4_5 = 0;
        public double D5_6 = 0; public double D6_7 = 0; public double D7_8 = 0; public double ObshMass = 0;
        public int KolOs = 0; public int KolOsL = 0; public int KolOsR = 0;
        public int TTS = 0;
        public double ADNagr = 0;
        public double RasstOs = 0;
        public double DLINATS = 0;
        public int DO = 0;
        public int TypeO = 0;
        public string FFF;  public string FF;
        public int COs;
        public int COsL;
        public int COsR; public int COsROF;
        public string D1; public string D2; public string D1SR; public string D2SR; public string GRZSR; public int ColRSR;
        public string D1L; public string D2L;
        public string D1R; public string D2R;
        public int Cl;
        public string WM;
        public string cstr; public string cstrL; public string cstrR; public string cstrAD; public string cstrMD; public string cstrOF; public string cstrKL1;
        public string cstrU; public string cstrKL; public string cstrRUB; public string cstrNAPR; public string cstrNar; public string cstrPUT; public string cstrSR;
        public string z; public string zL; public string zR; public string zM; public string zAD; public string zPDKO; public string zPDK; public string zLB;
        public string zMD; public string zU; public string zKL; public string zRUB; public string zNAPR; public string zSR; public string zNar; public string zROF; public string zPUT;
        public int ic;
        public int icO;
        public int icC;
        public int GrO;
        public string Pl; int RCS;
        public int SRIDPR;
        public MySqlConnection connection;public MySqlConnection connectionL;public MySqlConnection connectionR;public MySqlConnection connectionAD;
        public MySqlDataAdapter mySqlDataAdapter;public MySqlDataAdapter mySqlDataAdapterL;public MySqlDataAdapter mySqlDataAdapterR;public MySqlDataAdapter mySqlDataAdapterAD;
        public MySqlDataAdapter mySqlDataAdapterPDKO;
        public MySqlDataAdapter mySqlDataAdapterPDK;
        public MySqlConnection connectionMD;
        public MySqlDataAdapter mySqlDataAdapterMD;
        public MySqlConnection connectionU;
        public MySqlDataAdapter mySqlDataAdapterU;
        public MySqlConnection connectionKL;
        public MySqlDataAdapter mySqlDataAdapterKL;
        public MySqlConnection connectionRUB;
        public MySqlDataAdapter mySqlDataAdapterRUB;
        public MySqlConnection connectionNAPR, connectionSR;
        public MySqlDataAdapter mySqlDataAdapterNAPR, mySqlDataAdapterSR;
        public MySqlConnection connectionNar;
        public MySqlDataAdapter mySqlDataAdapterNar;
        public MySqlConnection connectionROF;
        public MySqlDataAdapter mySqlDataAdapterROF;
        public MySqlConnection connectionPUT;
        public MySqlDataAdapter mySqlDataAdapterPUT;
        public string[] Us = new string[25];///User
        public string[] Puti  =  { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
        public string st7;
        public struct pictures
        {
            public byte pic1, pic2, pic3, pic4;
        }
        public pictures n1;
        public int iz = 1;
        private int us;
        private DataTable WD = new DataTable();

        public struct SprKl
        {
            public int KlEuro, KlRus, KolOsKL, NosKl;
            public double  MejOsRasstKlmin1, MejOsRasstKlmax1, MejOsRasstKlmin2, MejOsRasstKlmax2, MejOsRasstKlmin3, MejOsRasstKlmax3, OsNagrDor;
            public double MejOsRasstKlmin4, MejOsRasstKlmax4, MejOsRasstKlmin5, MejOsRasstKlmax5, MejOsRasstKlmin6, MejOsRasstKlmax6;
            public double MejOsRasstKlmin7, MejOsRasstKlmax7, MejOsRasstKlmin8, MejOsRasstKlmax8,PolnMKlmin,PolnMKlmax;
            public string NameKL,TypeSchKl;
        }
        public SprKl[] SKL=new SprKl[51];
        #region                        Инициализация формы    /////////////////////////////////////////////////////////////////
        public Form2()
        {
            InitializeComponent();
            


            SelfRef = this;
        }
        #endregion////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public Form2(int us)
        {
            this.us = us;
            InitializeComponent(); SelfRef = this;
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            #region                      Получаем данные о юзере в переменные       /////////////////////////////////////////
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            {
                string zUs;
                MySqlCommand commandUS = new MySqlCommand();
                ConnectStr conStrUS = new ConnectStr();
                conStrUS.ConStr(1);
                Zapros zaprosUS = new Zapros();
                string connectionStringUS;
                connectionStringUS = conStrUS.StP; ;
                MySqlConnection connectionUS = new MySqlConnection(connectionStringUS);
                zaprosUS.KartUser(us);
                zUs = zaprosUS.commandStringTest;
                commandUS.CommandText = zUs;
                commandUS.Connection = connectionUS;
                MySqlDataReader readerUS;
                try
                {
                    commandUS.Connection.Open();
                    readerUS = commandUS.ExecuteReader();
                    while (readerUS.Read())
                    {
                        strus[1] = readerUS["r1"].ToString();
                        strus[2] = readerUS["r2"].ToString();
                        strus[3] = readerUS["r3"].ToString();//справочники
                        strus[4] = readerUS["r4"].ToString();
                        strus[5] = readerUS["r5"].ToString();
                        strus[6] = readerUS["r6"].ToString();
                        strus[7] = readerUS["r7"].ToString();
                        strus[8] = readerUS["r8"].ToString();
                        strus[9] = readerUS["r9"].ToString();
                        strus[10] = readerUS["r10"].ToString();
                        strus[11] = readerUS["r11"].ToString();// VSPR
                        strus[12] = readerUS["r12"].ToString();// RSPR
                        strus[13] = readerUS["r13"].ToString();// Контроль ГРЗ
                        strus[15] = readerUS["user"].ToString();
                    }
                    readerUS.Close();
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Error: \r\n{0}", ex.ToString());
                }
                finally
                {
                    commandUS.Connection.Close();
                }
                tabControl2.TabPages.Remove(tabPage17);
                NUs = strus[15];
                label61.Text = "Добро пожаловать: " + strus[15].ToString();

                if (((strus[1]) != "") && (Convert.ToInt32(strus[1]) > 0))
                {
                    tabControl1.TabPages.Remove(tabPage1);
                    tabControl1.TabPages.Add(tabPage1);////  Вкладка Мониторинг
                    tabControl2.TabPages.Remove(tabPage17);
                    timer2.Enabled = true;
                }
                else
                {
                    tabControl1.TabPages.Remove(tabPage1);
                    tabControl2.TabPages.Remove(tabPage17);
                }
                if (((strus[6]) != "") && (Convert.ToInt32(strus[6]) > 0))
                {
                    tabControl1.TabPages.Remove(tabPage9);
                    tabControl1.TabPages.Add(tabPage9); //// Вкладка Контроль
                    tabControl2.TabPages.Remove(tabPage17);
                    timer1.Enabled = true;
                    timer3.Enabled = true;
                }
                else
                {
                    tabControl1.TabPages.Remove(tabPage9);
                }
                if (((strus[2]) != "") && (Convert.ToInt32(strus[2]) > 0))
                {
                    tabControl1.TabPages.Remove(tabPage2);
                    tabControl1.TabPages.Add(tabPage2);//// Вкладка СР
                }
                else
                {
                    tabControl1.TabPages.Remove(tabPage2);
                }
                if (((strus[4]) != "") && (Convert.ToInt32(strus[4]) > 0))
                {
                    tabControl1.TabPages.Remove(tabPage4);
                    tabControl1.TabPages.Add(tabPage4);
                   
                }
                else
                {
                    tabControl1.TabPages.Remove(tabPage4);
                }
                if (((strus[3]) != "") && (Convert.ToInt32(strus[3]) > 0))
                {
                    tabControl1.TabPages.Remove(tabPage3);
                    tabControl1.TabPages.Add(tabPage3);
                    if (((strus[11]) != "") && (Convert.ToInt32(strus[11]) > 0) && (Convert.ToInt32(strus[12]) == 0))
                    { button19.Enabled = false; button18.Enabled = false; button16.Enabled = false; 
                    button19.Enabled = false; button18.Enabled = false; button16.Enabled = false;
                        button19.Enabled = false; button18.Enabled = false; button16.Enabled = false;
                        button22.Enabled = false; button21.Enabled = false; button20.Enabled = false;
                        button14.Enabled = false; button13.Enabled = false; button12.Enabled = false;
                        button7.Enabled = false; button2.Enabled = false; button10.Enabled = false;
                        button6.Enabled = false; button5.Enabled = false; button4.Enabled = false;
                        button27.Enabled = false; button26.Enabled = false; button9.Enabled = false;
                        button30.Enabled = false; button29.Enabled = false; button28.Enabled = false;
                    }
                }
                else
                {
                    tabControl1.TabPages.Remove(tabPage3);
                }
                if (((strus[8]) != "") && (Convert.ToInt32(strus[8]) > 0))
                {
                    tabControl1.TabPages.Remove(tabPage5);
                    tabControl1.TabPages.Add(tabPage5);
                }
                else
                {
                    tabControl1.TabPages.Remove(tabPage5);
                }                
                if (((strus[1]) != "") && (Convert.ToInt32(strus[1]) > 0) && ((strus[6]) != "") && (Convert.ToInt32(strus[6]) > 0))
                {
                    if (tabControl1.SelectedIndex == 1)
                    {
                        timer1.Enabled = true;
                        timer2.Enabled = false;
                        timer3.Enabled = true;
                    }
                    else if (tabControl1.SelectedIndex == 0)
                    {
                        timer1.Enabled = false;
                        timer2.Enabled = true;
                        timer3.Enabled = false;
                    }
                }
                else if (((strus[1]) != "") && (Convert.ToInt32(strus[1]) > 0))
                {
                    timer1.Enabled = false;
                    timer2.Enabled = true;
                    timer3.Enabled = false;
                }
            }
        }
        private BindingSource bindingSorce = new BindingSource();

        public static Form2 SelfRef
        {
            get;
            set;
        }
        public object button1 { get; private set; }

        public void izobr()
        {
            if (iz == 0)
                return;
            else return;
        }

        #endregion////////////////////////////////////////////////////////////////////////////////////////////////////////////
        #region                                                 Загрузка формы и подмена главной формы  //////////////////////////

        private void Form2_Load(object sender, EventArgs e)
        {
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
            StrKL();
            ////////////////////////////////////// ЗАГРУЗКА АД ///////////////////////////////////////////////////////            
            ConnectStr conStrAD = new ConnectStr();
            Zapros zaprosAD = new Zapros();
            conStrAD.ConStr(1);
            cstrAD = conStrAD.StP;
            connectionAD = new MySqlConnection(cstrAD);
            if (((strus[3]) != "") && (Convert.ToInt32(strus[3]) > 0))
            {
                zaprosAD.AD(0);
                zAD = zaprosAD.commandStringTest;
                mySqlDataAdapterAD = new MySqlDataAdapter(zAD, connectionAD);
                mySqlDataAdapterAD.Fill(DSAD);
                dataGridView13.DataSource = DSAD.Tables[0];
                dataGridView13.Refresh();

                ZagrPDKO(0);
                ZagrPDKObMass(0);
                ZagrNarush();
                ZagrNastrPuti();               
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////               
            }
            connectionAD.Close();//connectionAD.Close();
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            ////////////////////////////////////// ЗАГРУЗКА СПЕЦ.РАЗР. ///////////////////////////////////////////////////////            
            if (((strus[2]) != "") && (Convert.ToInt32(strus[2]) > 0))
            {
                ZagrSPRAZR(0, "", "", 100, "");               
            }
            connectionSR.Close();
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            if (((strus[1]) != "") && (Convert.ToInt32(strus[1]) > 0))
            {
                dateTimePicker10.Value = DateTime.Now;
                dateTimePicker9.Value = dateTimePicker10.Value.AddHours(-1);//.AddMinutes(-15);//.AddSeconds(-10);//dateTimePicker8.Value.AddHours(-12);
                dateTimePicker5.Value = DateTime.Now;//Convert.ToDateTime("2018.04.13 11:50:00");
                dateTimePicker6.Value = DateTime.Now.AddHours(-1);
            }

            ////////////////////////////////////// ЗАГРУЗКА К(ЛЕВАЯ) ///////////////////////////////////////////////////////            
            if (((strus[6]) != "") && (Convert.ToInt32(strus[6]) > 0))
            {
                dateTimePicker8.Value = DateTime.Now;//Convert.ToDateTime("2018.03.29 11:50:00");
                dateTimePicker7.Value = DateTime.Now.AddHours(-1);///DateTime.Now;//dateTimePicker8.Value.AddSeconds(-10);// dateTimePicker8.Value.AddHours(-24); //Convert.ToDateTime("2018.01.01 00:00:00"); //dateTimePicker8.Value.AddHours(-24);
                dateTimePicker2.Value = DateTime.Now;//Convert.ToDateTime("2018.03.29 11:50:00");
                dateTimePicker1.Value = DateTime.Now.AddHours(-1);//Convert.ToDateTime("2018.01.01 00:00:00");
                dateTimePicker12.Value = DateTime.Now;//DateTime.Now;//Convert.ToDateTime("2018.03.29 11:50:00");
                dateTimePicker11.Value = DateTime.Now;//dateTimePicker12.Value.AddSeconds(-10);//Convert.ToDateTime("2018.01.01 00:00:00");
                dateTimePicker3.Value = DateTime.Now;//Convert.ToDateTime("2018.03.29 11:50:00");//DateTime.Now;
                dateTimePicker4.Value = DateTime.Now.AddHours(-1);//Convert.ToDateTime("2018.01.01 00:00:00");
            }
            //////////////////////////////////////////////////////////////
            if (((strus[2]) != "") && (Convert.ToInt32(strus[2]) > 0))
            { 
                dateTimePicker15.Value = DateTime.Now.AddHours(-1);
                dateTimePicker16.Value = DateTime.Now;
                dateTimePicker14.Value=DateTime.Now.AddHours(-1);
                dateTimePicker13.Value = DateTime.Now;
            }
        }
        #region ////////////////////////////////////// ЗАГРУЗКА Table USER /////////////////////////////////////////////////////// 
        public void TabUs()
        {
            ConnectStr conStrU = new ConnectStr();
            conStrU.ConStr(1);
            cstrU = conStrU.StP;
            connectionU = new MySqlConnection(cstrU);
            Zapros zaprosU = new Zapros();   //int IDU = 0;
            zaprosU.KartUser(0);
            zU = zaprosU.commandStringTest;
            mySqlDataAdapterU = new MySqlDataAdapter(zU, connectionU);
            
            mySqlDataAdapterU.Fill(DSU);
            dataGridView7.DataSource = DSU.Tables[0];
            dataGridView7.Columns[0].Visible = false;
            int ssU = 0;
            for (ssU = 3; ssU < 15; ssU++)
            { dataGridView7.Columns[ssU].Visible = false; }
            dataGridView7.Columns[21].Visible = false;
            dataGridView7.Columns[22].Visible = false;
            dataGridView7.Columns[23].Visible = false;
            dataGridView7.Refresh();
            connectionU.Close();
        }
        #endregion ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void label62_Click(object sender, EventArgs e)///////////// Кнопка "Выход" (из учетки)
        {
            Program.Context.MainForm = new Form1();
            this.Close();
            // покажет первую форму и оставит приложение живым до ее закрытия
            Program.Context.MainForm.Show();
        }
        #endregion////////////////////////////////////////////////////////////////////////////////////////////////////////////
        #region                                     Фильтр и его обработка    ////////////////////////    ДЛЯ ЛЕВОЙ ЧАСТИ    ////////////////////////
         private void StopSearch()  // Делаем фильтр и все ссылк к нему (до строки /////////////////      ДЛЯ ЛЕВОЙ ЧАСТИ      ///////)
        {
            if (Napr2[1] == null) { Napr2[0] = ""; Napr2[1] = ""; Napr2[2] = ""; Napr2[3] = ""; }
            if (checkBox11.Checked == true)
            {
                dateTimePicker7.Value = DateTime.Now;
                dateTimePicker8.Value = dateTimePicker10.Value.AddDays(-1);//.AddHours(-1);
            }
            else
            {
                dateTimePicker7.Value = dateTimePicker1.Value;//Convert.ToDateTime("28.04.2018 00:00:00");//
                dateTimePicker8.Value = dateTimePicker2.Value;//Convert.ToDateTime("28.04.2018 13:00:00");
            }

            dateTimePicker7.Value = dateTimePicker1.Value;
            dateTimePicker8.Value = dateTimePicker2.Value;
            string TXTFLEFT = "";
            TXTFLEFT = " WHERE  Created >= '" + dateTimePicker7.Value.ToString("yyyyMMddHHmmss") + "' and Created <= '" + dateTimePicker8.Value.ToString("yyyyMMddHHmmss") + "'";
            if (textBoxGRZ.Text != "")
            {
                TXTFLEFT = TXTFLEFT + " and Plate LIKE '%" + textBoxGRZ.Text + "%'";
            }           
            /////////////////////////////////////// по классу
            if (flags2 == null) { flags2 = new Boolean[55]; }
            if (flags2[5] == false && flags2[6] == false && flags2[7] == false && flags2[8] == false && flags2[9] == false && flags2[10] == false && flags2[11] == false && flags2[12] == false && flags2[13] == false && flags2[14] == false && flags2[15] == false && flags2[16] == false && flags2[17] == false)
            { }
            else
            {
                if (flags2[5] == true)
                { TXTFLEFT = TXTFLEFT + " AND (IF(CHAR_LENGTH(allandnapr.Class2)>3 ,SUBSTR(allandnapr.Class2, 1, 2), IF(CHAR_LENGTH(allandnapr.Class2)<=1 ,0,SUBSTR(allandnapr.Class2, 1, 1))) = 1"; }
                else if (flags2[5] == false)
                { TXTFLEFT = TXTFLEFT + " AND (IF(CHAR_LENGTH(allandnapr.Class2)>3 ,SUBSTR(allandnapr.Class2, 1, 2), IF(CHAR_LENGTH(allandnapr.Class2)<=1 ,0,SUBSTR(allandnapr.Class2, 1, 1))) = 17"; }

                for (int ifk = 6; ifk < 17; ifk++)
                {
                    if (flags2[ifk] == true)
                    { TXTFLEFT = TXTFLEFT + " OR IF(CHAR_LENGTH(allandnapr.Class2)>3 ,SUBSTR(allandnapr.Class2, 1, 2), IF(CHAR_LENGTH(allandnapr.Class2)<=1 ,0,SUBSTR(allandnapr.Class2, 1, 1))) = " + (ifk - 4); }
                    else if (flags2[ifk] == false)
                    { /*TXTFLEFT = TXTFLEFT + " OR Cl12 = 0";*/ }
                }
                if (flags2[17] == true)
                { TXTFLEFT = TXTFLEFT + " OR IF(CHAR_LENGTH(allandnapr.Class2)>3 ,SUBSTR(allandnapr.Class2, 1, 2), IF(CHAR_LENGTH(allandnapr.Class2)<=1 ,0,SUBSTR(allandnapr.Class2, 1, 1))) = 12)"; }
                else if (flags2[17] == false)
                { TXTFLEFT = TXTFLEFT + ")"; }
            }
            if (flags2[0] == true)
            { TXTFLEFT = TXTFLEFT + " AND (IsOverweightGross = 1"; }

            if (flags2[1] == true)
            {
                if (flags2[0] == true)
                { TXTFLEFT = TXTFLEFT + " OR IsOverweightPartial = 1"; }
                else
                { TXTFLEFT = TXTFLEFT + " AND (IsOverweightPartial = 1"; }
            }

            if (flags2[3] == true)
            {
                if (flags2[0] == true)
                { TXTFLEFT = TXTFLEFT + " OR IsOverweightGroup = 1"; }
                else
                {
                    if (flags2[1] == true)
                    { TXTFLEFT = TXTFLEFT + " OR IsOverweightGroup = 1"; }
                    else
                    { TXTFLEFT = TXTFLEFT + " AND (IsOverweightGroup = 1"; }
                }
            }
            if (flags2[4] == true)
            {
                if (flags2[0] == true)
                { TXTFLEFT = TXTFLEFT + " OR IsExceededLength = 1)"; }
                else
                {
                    if (flags2[1] == true)
                    { TXTFLEFT = TXTFLEFT + " OR IsExceededLength = 1)"; }
                    else
                    {
                        if (flags2[3] == true)
                        { TXTFLEFT = TXTFLEFT + " OR IsExceededLength = 1)"; }
                        else
                        { TXTFLEFT = TXTFLEFT + " AND IsExceededLength = 1"; }
                    }
                }
            }
            else
            {
                if (flags2[0] == true)
                { TXTFLEFT = TXTFLEFT + ")"; }
                else
                {
                    if (flags2[1] == true)
                    { TXTFLEFT = TXTFLEFT + ")"; }
                    else
                    {
                        if (flags2[3] == true)
                        { TXTFLEFT = TXTFLEFT + ")"; }

                    }
                }
            }

            if (flags2[18] == true)
            { TXTFLEFT = TXTFLEFT + " AND (( Plate = '' and PlateRear = '' AND OldGRZ = '')"; }
            if (flags2[19] == true)
            {
                if (flags2[18] == true)
                { TXTFLEFT = TXTFLEFT + " or CredenceExceeded > 0"; }
                else
                { TXTFLEFT = TXTFLEFT + " AND ( CredenceExceeded > 0"; }
            }
            if (flags2[20] == true)
            {
                if (flags2[19] == true || flags2[18] == true)
                { TXTFLEFT = TXTFLEFT + " or AxleCount < 1"; }
                else { TXTFLEFT = TXTFLEFT + " AND ( AxleCount < 1"; }
            }
            if (flags2[21] == true)
            {
                if (flags2[19] == true || flags2[18] == true || flags2[20] == true)
                { TXTFLEFT = TXTFLEFT + " or ClassScheme3 < 3"; }
                else { TXTFLEFT = TXTFLEFT + " AND ( ClassScheme3 < 3"; }
            }
            if (flags2[19] == true || flags2[18] == true || flags2[20] == true || flags2[21] == true)
            { TXTFLEFT = TXTFLEFT + ")"; }

            if (Napr2[0].ToString() == "Все" || Napr2[0].ToString() == "")
            {/* TXTFLEFT = TXTFLEFT + " AND (PlatformId = 2952855555 OR PlatformId = 2952855553)"; */}
            else if (Napr2[0].ToString() == "РК-1")
            { TXTFLEFT = TXTFLEFT + " AND PlatformId = 2952855553"; }
            else if (Napr2[0].ToString() == "РК-2")
            { TXTFLEFT = TXTFLEFT + " AND PlatformId = 2952855555"; }


            if (Napr2[1].ToString() == "Все" || Napr2[1].ToString() == "")
            {/* TXTFLEFT = TXTFLEFT + " AND (namead =  '67-ОП-РЗ-67Р-01' OR namead = '67-ОП-РЗ-67К-14')"; */}
            else if (Napr2[1].ToString() == "67-ОП-РЗ-67Р-01")
            { TXTFLEFT = TXTFLEFT + " AND namead = '67-ОП-РЗ-67Р-01'"; }
            else if (Napr2[1].ToString() == "67-ОП-РЗ-67К-14")
            { TXTFLEFT = TXTFLEFT + " AND namead = '67-ОП-РЗ-67К-14'"; }

            if (Napr2[2].ToString() == "Все" || Napr2[2].ToString() == "")
            {/* TXTFLEFT = TXTFLEFT + " AND (namenapr =  'из Севастополя' OR namenapr = 'в Севастополь')"; */}
            else if (Napr2[2].ToString() == "из Севастополя")
            { TXTFLEFT = TXTFLEFT + " AND namenapr = 'из Севастополя'"; }
            else if (Napr2[2].ToString() == "в Севастополь")
            { TXTFLEFT = TXTFLEFT + " AND namenapr = 'в Севастополь'"; }

            if (Napr2[3].ToString() == "Все" || Napr2[3].ToString() == "")
            {/* TXTFLEFT = TXTFLEFT + " AND (Lane =  1 OR Lane = 2)"; */}
            else if (Napr2[3].ToString() == "1")
            { TXTFLEFT = TXTFLEFT + " AND Lane =  1"; }
            else if (Napr2[3].ToString() == "2")
            { TXTFLEFT = TXTFLEFT + " AND Lane =  2"; }

            if (flags2[27] == true)
            { TXTFLEFT = TXTFLEFT + " AND NameUs = 'AUTO'"; }
            if (flags2[28] == true)
            { TXTFLEFT = TXTFLEFT + " AND NameUs  NOT LIKE 'AUTO'"; }

            if (flags2[29] == false && flags2[30] == false && flags2[31] == false && flags2[32] == false && flags2[33] == false && flags2[34] == false && flags2[35] == false && flags2[36] == false)
            { }
            else
            {
                if (flags2[29] == true)
                { TXTFLEFT = TXTFLEFT + " AND (allandnapr.AxleCount <= 2"; }
                else if (flags2[29] == false)
                { TXTFLEFT = TXTFLEFT + " AND (allandnapr.AxleCount = 28"; }

                for (int ifk = 30; ifk < 36; ifk++)
                {
                    if (flags2[ifk] == true)
                    { TXTFLEFT = TXTFLEFT + " OR allandnapr.AxleCount = " + (ifk - 27); }
                    else if (flags2[ifk] == false)
                    {/* TXTFLEFT = TXTFLEFT + " OR Cl12 = 0"; */}
                }
                if (flags2[36] == true)
                { TXTFLEFT = TXTFLEFT + " OR allandnapr.AxleCount >= 9 )"; }
                else if (flags2[36] == false)
                { TXTFLEFT = TXTFLEFT + ")"; }
            }

            if (flags2[37] == false && flags2[38] == false && flags2[39] == false && flags2[40] == false && flags2[41] == false && flags2[42] == false && flags2[43] == false && flags2[44] == false)
            { }
            else
            {
                if (flags2[37] == true)
                { TXTFLEFT = TXTFLEFT + " AND (allandnapr.Weight <= 3.5"; }
                else if (flags2[37] == false)
                { TXTFLEFT = TXTFLEFT + " AND (allandnapr.Weight = 280"; }

                if (flags2[38] == true)
                { TXTFLEFT = TXTFLEFT + " OR (allandnapr.Weight > 3.5 and allandnapr.Weight <= 5 )"; }
                else if (flags2[38] == false)
                {/* TXTFLEFT = TXTFLEFT + " OR Cl12 = 0"; */}
                if (flags2[39] == true)
                { TXTFLEFT = TXTFLEFT + " OR (allandnapr.Weight > 5 and allandnapr.Weight <= 10 )"; }
                else if (flags2[39] == false)
                {/* TXTFLEFT = TXTFLEFT + " OR Cl12 = 0"; */}
                if (flags2[40] == true)
                { TXTFLEFT = TXTFLEFT + " OR (allandnapr.Weight > 10 and allandnapr.Weight <= 20 )"; }
                else if (flags2[40] == false)
                {/* TXTFLEFT = TXTFLEFT + " OR Cl12 = 0"; */}
                if (flags2[41] == true)
                { TXTFLEFT = TXTFLEFT + " OR (allandnapr.Weight > 20 and allandnapr.Weight <= 30 )"; }
                else if (flags2[41] == false)
                {/* TXTFLEFT = TXTFLEFT + " OR Cl12 = 0"; */}
                if (flags2[42] == true)
                { TXTFLEFT = TXTFLEFT + " OR (allandnapr.Weight > 30 and allandnapr.Weight <= 50 )"; }
                else if (flags2[42] == false)
                {/* TXTFLEFT = TXTFLEFT + " OR Cl12 = 0"; */}
                if (flags2[43] == true)
                { TXTFLEFT = TXTFLEFT + " OR (allandnapr.Weight > 50 and allandnapr.Weight <= 70 )"; }
                else if (flags2[43] == false)
                {/* TXTFLEFT = TXTFLEFT + " OR Cl12 = 0"; */}

                if (flags2[44] == true)
                { TXTFLEFT = TXTFLEFT + " OR allandnapr.Weight > 70 )"; }
                else if (flags2[44] == false)
                { TXTFLEFT = TXTFLEFT + ")"; }

            }

            if (flags2[45] == false && flags2[46] == false && flags2[47] == false && flags2[48] == false)
            { }
            else
            {
                if (flags2[45] == true)
                { TXTFLEFT = TXTFLEFT + " AND (allandnapr.Length <= 5"; }
                else if (flags2[45] == false)
                { TXTFLEFT = TXTFLEFT + " AND (allandnapr.Length = 280"; }

                if (flags2[46] == true)
                { TXTFLEFT = TXTFLEFT + " OR (allandnapr.Length > 5 and allandnapr.Length <= 12 )"; }
                else if (flags2[46] == false)
                {/* TXTFLEFT = TXTFLEFT + " OR Cl12 = 0"; */}
                if (flags2[47] == true)
                { TXTFLEFT = TXTFLEFT + " OR (allandnapr.Length > 12 and allandnapr.Length <= 20 )"; }
                else if (flags2[47] == false)
                {/* TXTFLEFT = TXTFLEFT + " OR Cl12 = 0"; */}

                if (flags2[48] == true)
                { TXTFLEFT = TXTFLEFT + " OR allandnapr.Length > 20 )"; }
                else if (flags2[44] == false)
                { TXTFLEFT = TXTFLEFT + ")"; }
            }

            if (flags2[49] == false && flags2[50] == false && flags2[51] == false && flags2[52] == false && flags2[53] == false)
            { }
            else
            {
                if (flags2[49] == true)
                { TXTFLEFT = TXTFLEFT + " AND (allandnapr.Speed < 50"; }
                else if (flags2[49] == false)
                { TXTFLEFT = TXTFLEFT + " AND (allandnapr.Speed = 280"; }

                if (flags2[50] == true)
                { TXTFLEFT = TXTFLEFT + " OR (allandnapr.Speed >= 50 and allandnapr.Speed <= 60 )"; }
                else if (flags2[50] == false)
                {/* TXTFLEFT = TXTFLEFT + " OR Cl12 = 0"; */}
                if (flags2[51] == true)
                { TXTFLEFT = TXTFLEFT + " OR (allandnapr.Speed > 60 and allandnapr.Speed <= 70 )"; }
                else if (flags2[51] == false)
                {/* TXTFLEFT = TXTFLEFT + " OR Cl12 = 0"; */}
                if (flags2[52] == true)
                { TXTFLEFT = TXTFLEFT + " OR (allandnapr.Speed > 70 and allandnapr.Speed <= 90 )"; }
                else if (flags2[52] == false)
                {/* TXTFLEFT = TXTFLEFT + " OR Cl12 = 0"; */}

                if (flags2[53] == true)
                { TXTFLEFT = TXTFLEFT + " OR allandnapr.Speed > 90 )"; }
                else if (flags2[53] == false)
                { TXTFLEFT = TXTFLEFT + ")"; }
            }

            TXTFLEFT = TXTFLEFT + " ORDER BY Created DESC LIMIT " + textBox12.Text + ";";

            flags2 = flags;
            if (DSL != null)
                DSL.Clear();
            ZKontrolL(TXTFLEFT);
           
            if (toolStripLabel14.Text != "")
            {
                kol = Convert.ToInt32(toolStripLabel14.Text);
            }
            if (dataGridView8.RowCount > 0)
            {
                rowIndex = dataGridView8.SelectedCells[0].RowIndex;
                if (kol > rowIndex)
                { kol = 0; }
                int Sum = 0;
                for (int i = 0; i < dataGridView8.Rows.Count; i++)
                {
                    Sum = Sum + 1;
                }
                if (Sum - kol < Sum)
                { kol = Sum - kol; }
                dataGridView8.CurrentCell = dataGridView8[0, rowIndex + kol];
                currentRowLeft = rowIndex + kol;
                toolStripLabel14.Text = "" + (Convert.ToInt32(Sum)).ToString();
                Otrisovka1();
            }
            else
            {
                if (DSL != null)
                    DSL.Clear();
                ZKontrolL("");
                dv = new DataView(DSL.Tables[0], "(Created >= '" + dateTimePicker7.Value + "' and Created <= '" + dateTimePicker8.Value + "') ", "", DataViewRowState.CurrentRows);
                dataGridView8.DataSource = dv;
                label83.Text = "ЗАПИСИ УДОВЛЕТВОРЯЮЩИЕ ЗАПРОСУ НЕ НАЙДЕНЫ";
                Otrisovka1();
            }
        }
       
        private void toolStripTextBox2_TextChanged(object sender, EventArgs e)//Фильтр по ГРЗ
        {
            StopSearch();
        }

        #endregion  ///////////////////////////////////////////////////////////////////////////////////////////

        #region    /////////////////////////////////////////////////////////////////////////// Л Е В А Я  Ч А С Т Ь  ///////////////

        #region          Общая скобка по весу и длине + направление движения   /////////////////////////////////////// tttttttttttttttttttttttttttttttttttttttt
        private void label28_TextChanged(System.Object sender, System.EventArgs e)//Общая скобка по весу и длине + направление движения
        {
            pictureBox31.Visible = false;
            pictureBox32.Visible = false;
            pictureBox33.Visible = false;
            pictureBox34.Visible = false;
            pictureBox35.Visible = false;
            pictureBox36.Visible = false;
            pictureBox37.Visible = false;
            pictureBox38.Visible = false;
            pictureBox39.Visible = false;
            pictureBox30.Visible = false;//скобка
            pictureBox41.Visible = false;//стрелка
            label154.Visible = false;//надпись общ.длина
            label144.Visible = false;//надпись общ.масса
            label170.Visible = false;
            label171.Visible = false;
            string s = label154.Text;
            double i;
            if (label154.Text != "")
                i = Convert.ToDouble(s);//Convert.ToInt32(znachenie); 
            else i = 0;
            if (i > 0)
            {
                double loc2 = 0;
                string TO;
                TO = "Общая длина ТС - " + Convert.ToDouble(s) + " м. " + "\n" + "Общий вес: " + Convert.ToDouble(label144.Text) + " т. ";
                loc2 = 24 * i + 130;
                int loc3 = Convert.ToInt32(loc2);
                pictureBox30.Width = loc3 - 110;
                int newloc = 307 + loc3 / 2;
                pictureBox30.Location = new Point(30 + 240, 258);
                double loc = Convert.ToDouble(label154.Text) * 100;
                location = 180 + Convert.ToInt32(24 * loc / 100);
                pictureBox41.Location = new Point(Convert.ToInt32(loc2) + 170, 225);
                pictureBox41.Visible = true;
                label142.Text = TO;
                label142.Location = new Point((location / 2 + 135), 285);
                label142.BackColor = Color.Transparent;
                pictureBox30.Visible = true;
                label142.Visible = true;
                pictureBox41.Visible = true;
            }
        }
        #endregion
        #region     Рисунки колесных пар   ///////////////////////////////////////
        private void Label171_TextChanged(System.Object sender, System.EventArgs e)// Рисунок первой колесной пары + данные по ней
        {
            string s = Convert.ToString(Convert.ToDouble(label171.Text) * 1000);
            label153.Visible = true;
            int i;
            if (label162.Text != "")
            { i = Convert.ToInt32(s); }//Convert.ToInt32(znachenie); 
            else i = 0;
            if (i > 0)
            {
                double loc = Convert.ToDouble(label154.Text) * 100;
                location = 265 + Convert.ToInt32(24 * loc / 100);
                pictureBox31.Location = new Point(location, 223);
                pictureBox31.Image = AVGK.Properties.Resources._33777Ч1;
                label171.Location = new Point(location, 246);
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
                label162.Visible = true;
                label171.Visible = true;
                label153.Visible = false;
            }
            else
            {
                label162.Visible = false;
                label171.Visible = false;
                label153.Visible = false;
            }
        }

        private void label170_TextChanged(System.Object sender, System.EventArgs e)// Рисунок второй колесной пары + данные по ней
        {
            string s = Convert.ToString(Convert.ToDouble(label170.Text) * 1000);
            int i;
            if (label170.Text != "")
            {
                label152.Visible = true;
                i = Convert.ToInt32(s);//Convert.ToInt32(znachenie);
                if (i > 0)
                {
                    double loc1 = 0;
                    loc1 = location - (24 * ((Convert.ToDouble(label162.Text)) * 100) / 100);
                    int loc = Convert.ToInt32(Math.Round(loc1));
                    pictureBox32.Location = new Point(4 + loc, 223);
                    double locLOs = location - (24 * ((Convert.ToDouble(label162.Text) / 2)) * 100) / 100;// + 32;
                    int locL = Convert.ToInt32(Math.Round(locLOs));
                    label162.Location = new Point(4 + locL, 200);
                    label170.Location = new Point(4 + loc, 246);
                    if ((i > 0) && (i < 9000))
                    {
                        if ((label152.Text != "") && (Convert.ToInt32(label152.Text) > 0))
                        { pictureBox32.Image = AVGK.Properties.Resources._33777Ч2; }
                        else if ((label152.Text != ""))
                        { pictureBox32.Image = AVGK.Properties.Resources._33777Ч1; }
                    }
                    else if ((i > 0) && (i > 9000))
                    {
                        if ((label152.Text != "") && (Convert.ToInt32(label152.Text) > 0))
                        { pictureBox32.Image = AVGK.Properties.Resources._33777К2; }
                        else if ((label152.Text != ""))
                        { pictureBox32.Image = AVGK.Properties.Resources._33777К1; }
                    }
                    pictureBox34.BringToFront();
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
        }
        private void label169_TextChanged(System.Object sender, System.EventArgs e)// Рисунок третьей колесной пары + данные по ней
        {
            string s = Convert.ToString(Convert.ToDouble(label169.Text) * 1000);
            int i;
            if (label169.Text != "")
            {
                i = Convert.ToInt32(s);
                if (i > 0)
                {
                    label151.Visible = true;
                    double loc1 = 0;
                    loc1 = location - (24 * ((Convert.ToDouble(label162.Text) + Convert.ToDouble(label161.Text)) * 100) / 100);
                    int loc = Convert.ToInt32(Math.Round(loc1));
                    pictureBox33.Location = new Point(4 + loc, 223);
                    double locLOs = location - (24 * ((Convert.ToDouble(label162.Text) + Convert.ToDouble(label161.Text) / 2)) * 100) / 100;// + 32;
                    int locL = Convert.ToInt32(Math.Round(locLOs));
                    label161.Location = new Point(4 + locL, 200);
                    label169.Location = new Point(4 + loc, 246);

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
        }
        private void label168_TextChanged(System.Object sender, System.EventArgs e)// Рисунок четвертой колесной пары + данные по ней
        {
            string s = Convert.ToString(Convert.ToDouble(label168.Text) * 1000);
            int i;
            if (label168.Text != "")
            {
                label150.Visible = true;
                i = Convert.ToInt32(s);//Convert.ToInt32(znachenie);
                if (i > 0)
                {
                    double loc1 = 0;
                    loc1 = location - (24 * ((Convert.ToDouble(label162.Text) + Convert.ToDouble(label161.Text) + Convert.ToDouble(label160.Text)) * 100) / 100);
                    int loc = Convert.ToInt32(Math.Round(loc1));
                    pictureBox34.Location = new Point(4 + loc, 223);
                    double locLOs = location - (24 * ((Convert.ToDouble(label162.Text) + Convert.ToDouble(label161.Text) + Convert.ToDouble(label160.Text) / 2)) * 100) / 100;// + 32;
                    int locL = Convert.ToInt32(Math.Round(locLOs));
                    label160.Location = new Point(4 + locL, 200);
                    label168.Location = new Point(4 + loc, 246);
                    if ((i > 0) && (i < 9000))
                    {
                        if ((label150.Text != "") && (Convert.ToInt32(label150.Text) > 0))
                        { pictureBox34.Image = AVGK.Properties.Resources._33777Ч2; }
                        else if ((label150.Text != ""))
                        { pictureBox34.Image = AVGK.Properties.Resources._33777Ч1; }
                    }
                    else if ((i > 0) && (i > 9000))
                    {
                        if ((label150.Text != "") && (Convert.ToInt32(label150.Text) > 0))
                        { pictureBox34.Image = AVGK.Properties.Resources._33777К2; }
                        else if ((label150.Text != ""))
                        { pictureBox34.Image = AVGK.Properties.Resources._33777К1; }
                    }
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
                pictureBox34.Visible = false;
            }
        }
        private void label167_TextChanged(System.Object sender, System.EventArgs e)// Рисунок пятой колесной пары + данные по ней
        {
            label149.Visible = true;
            string s = Convert.ToString(Convert.ToDouble(label167.Text) * 1000);
            int i;
            if (label167.Text != "")
            {
                i = Convert.ToInt32(s);
                if (i > 0)
                {
                    double loc1 = 0;
                    loc1 = location - (24 * ((Convert.ToDouble(label162.Text) + Convert.ToDouble(label161.Text) + Convert.ToDouble(label160.Text) + Convert.ToDouble(label159.Text)) * 100) / 100);
                    int loc = Convert.ToInt32(Math.Round(loc1));
                    pictureBox35.Location = new Point(4 + loc, 223);
                    double locLOs = location - (24 * ((Convert.ToDouble(label162.Text) + Convert.ToDouble(label161.Text) + Convert.ToDouble(label160.Text) + Convert.ToDouble(label159.Text) / 2)) * 100) / 100;// + 32;
                    int locL = Convert.ToInt32(Math.Round(locLOs));
                    label159.Location = new Point(4 + locL, 200);
                    label167.Location = new Point(4 + loc, 246);
                    if ((i > 0) && (i < 9000))
                    {
                        if ((label149.Text != "") && (Convert.ToInt32(label149.Text) > 0))
                        { pictureBox35.Image = AVGK.Properties.Resources._33777Ч2; }
                        else if ((label149.Text != ""))
                        { pictureBox35.Image = AVGK.Properties.Resources._33777Ч1; }
                    }
                    else if ((i > 0) && (i > 9000))
                    {
                        if ((label149.Text != "") && (Convert.ToInt32(label149.Text) > 0))
                        { pictureBox35.Image = AVGK.Properties.Resources._33777К2; }
                        else if ((label149.Text != ""))
                        { pictureBox35.Image = AVGK.Properties.Resources._33777К1; }
                    }
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
                pictureBox35.Visible = false;
            }
        }
        private void label166_TextChanged(System.Object sender, System.EventArgs e)// Рисунок шестой колесной пары + данные по ней
        {
            label148.Visible = true;
            string s = Convert.ToString(Convert.ToDouble(label166.Text) * 1000);
            int i;
            if (label166.Text != "")
            {
                i = Convert.ToInt32(s);
                if (i > 0)
                {
                    double loc1 = 0;
                    loc1 = location - (24 * ((Convert.ToDouble(label162.Text) + Convert.ToDouble(label161.Text) + Convert.ToDouble(label160.Text) + Convert.ToDouble(label159.Text) + Convert.ToDouble(label158.Text)) * 100) / 100);
                    int loc = Convert.ToInt32(Math.Round(loc1));
                    pictureBox36.Location = new Point(4 + loc, 223);
                    double locLOs = location - (24 * ((Convert.ToDouble(label162.Text) + Convert.ToDouble(label161.Text) + Convert.ToDouble(label160.Text) + Convert.ToDouble(label159.Text) + Convert.ToDouble(label158.Text) / 2)) * 100) / 100;// + 32;
                    int locL = Convert.ToInt32(Math.Round(locLOs));
                    label158.Location = new Point(4 + locL, 200);
                    label166.Location = new Point(4 + loc, 246);
                    if ((i > 0) && (i < 9000))
                    {
                        if ((label148.Text != "") && (Convert.ToInt32(label148.Text) > 0))
                        { pictureBox36.Image = AVGK.Properties.Resources._33777Ч2; }
                        else if ((label148.Text != ""))
                        { pictureBox36.Image = AVGK.Properties.Resources._33777Ч1; }
                    }
                    else if ((i > 0) && (i > 9000))
                    {
                        if ((label148.Text != "") && (Convert.ToInt32(label148.Text) > 0))
                        { pictureBox36.Image = AVGK.Properties.Resources._33777К2; }
                        else if ((label148.Text != ""))
                        { pictureBox36.Image = AVGK.Properties.Resources._33777К1; }
                    }
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
                pictureBox36.Visible = false;
            }
        }
        private void Label16_TextChanged(System.Object sender, System.EventArgs e)// Рисунок седьмой колесной пары + данные по ней
        {
            label147.Visible = true;
            string s = Convert.ToString(Convert.ToDouble(label165.Text) * 1000);
            int i;
            if (label165.Text != "")
            {
                i = Convert.ToInt32(s);
                if (i > 0)
                {
                    double loc1 = 0;
                    loc1 = location - (24 * ((Convert.ToDouble(label162.Text) + Convert.ToDouble(label161.Text) + Convert.ToDouble(label160.Text) + Convert.ToDouble(label159.Text) + Convert.ToDouble(label158.Text) + Convert.ToDouble(label157.Text)) * 100) / 100);
                    int loc = Convert.ToInt32(Math.Round(loc1));
                    pictureBox37.Location = new Point(4 + loc, 223);
                    double locLOs = location - (24 * ((Convert.ToDouble(label162.Text) + Convert.ToDouble(label161.Text) + Convert.ToDouble(label160.Text) + Convert.ToDouble(label159.Text) + Convert.ToDouble(label158.Text) + Convert.ToDouble(label157.Text) / 2)) * 100) / 100;// + 32;
                    int locL = Convert.ToInt32(Math.Round(locLOs));
                    label157.Location = new Point(4 + locL, 200);
                    label165.Location = new Point(4 + loc, 246);
                    if ((i > 0) && (i < 9000))
                    {
                        if ((label147.Text != "") && (Convert.ToInt32(label147.Text) > 0))

                        { pictureBox37.Image = AVGK.Properties.Resources._33777Ч2; }
                        else if ((label147.Text != ""))
                        { pictureBox37.Image = AVGK.Properties.Resources._33777Ч1; }
                    }
                    else if ((i > 0) && (i > 9000))
                    {
                        if ((label147.Text != "") && (Convert.ToInt32(label147.Text) > 0))
                        { pictureBox37.Image = AVGK.Properties.Resources._33777К2; }
                        else if ((label147.Text != ""))
                        { pictureBox37.Image = AVGK.Properties.Resources._33777К1; }
                    }
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
                pictureBox37.Visible = false;
            }
        }
        private void Label17_TextChanged(System.Object sender, System.EventArgs e)// Рисунок восьмой колесной пары + данные по ней
        {
            label146.Visible = true;
            string s = Convert.ToString(Convert.ToDouble(label164.Text) * 1000);
            int i;
            if (label164.Text != "")
            {
                i = Convert.ToInt32(s);
                if (i > 0)
                {
                    double loc1 = 0;
                    loc1 = location - (24 * ((Convert.ToDouble(label162.Text) + Convert.ToDouble(label161.Text) + Convert.ToDouble(label160.Text) + Convert.ToDouble(label159.Text) + Convert.ToDouble(label158.Text) + Convert.ToDouble(label157.Text) + Convert.ToDouble(label156.Text)) * 100) / 100);
                    int loc = Convert.ToInt32(Math.Round(loc1));
                    pictureBox38.Location = new Point(4 + loc, 223);
                    widh = loc1 - 193;
                    double locLOs = location - (24 * ((Convert.ToDouble(label162.Text) + Convert.ToDouble(label161.Text) + Convert.ToDouble(label160.Text) + Convert.ToDouble(label159.Text) + Convert.ToDouble(label158.Text) + Convert.ToDouble(label157.Text) + Convert.ToDouble(label156.Text) / 2)) * 100) / 100;// + 32;
                    int locL = Convert.ToInt32(Math.Round(locLOs));
                    label156.Location = new Point(4 + locL, 200);
                    label164.Location = new Point(4 + loc, 246);
                    if ((i > 0) && (i < 9000))
                    {
                        if ((label146.Text != "") && (Convert.ToInt32(label146.Text) > 0))
                        { pictureBox38.Image = AVGK.Properties.Resources._33777Ч2; }
                        else if ((label146.Text != ""))
                        { pictureBox38.Image = AVGK.Properties.Resources._33777Ч1; }
                    }
                    else if ((i > 0) && (i > 9000))
                    {
                        if ((label146.Text != "") && (Convert.ToInt32(label146.Text) > 0))
                        { pictureBox38.Image = AVGK.Properties.Resources._33777К2; }
                        else if ((label146.Text != ""))
                        { pictureBox38.Image = AVGK.Properties.Resources._33777К1; }
                    }
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
                pictureBox38.Visible = false;
            }
        }
        private void Label18_TextChanged(System.Object sender, System.EventArgs e)// Рисунок девятой колесной пары + данные по ней
        {
            label145.Visible = true;
            string s = Convert.ToString(Convert.ToDouble(label163.Text) * 1000);
            int i;
            if (label163.Text != "")
            {
                i = Convert.ToInt32(s);
                if (i > 0)
                {
                    double loc1 = 0;
                    loc1 = location - (24 * ((Convert.ToDouble(label162.Text) + Convert.ToDouble(label161.Text) + Convert.ToDouble(label160.Text) + Convert.ToDouble(label159.Text) + Convert.ToDouble(label158.Text) + Convert.ToDouble(label157.Text) + Convert.ToDouble(label156.Text) + Convert.ToDouble(label155.Text)) * 100) / 100);
                    int loc = Convert.ToInt32(Math.Round(loc1));
                    pictureBox39.Location = new Point(4 + loc, 223);
                    widh = loc1 - 193;
                    double locLOs = location - (24 * ((Convert.ToDouble(label162.Text) + Convert.ToDouble(label161.Text) + Convert.ToDouble(label160.Text) + Convert.ToDouble(label159.Text) + Convert.ToDouble(label158.Text) + Convert.ToDouble(label157.Text) + Convert.ToDouble(label156.Text) + Convert.ToDouble(label155.Text) / 2)) * 100) / 100;// + 32;
                    int locL = Convert.ToInt32(Math.Round(locLOs));
                    label155.Location = new Point(4 + locL, 200);
                    label163.Location = new Point(4 + loc, 246);
                    if ((i > 0) && (i < 9000))
                    {
                        if ((label145.Text != "") && (Convert.ToInt32(label145.Text) > 0))
                        { pictureBox39.Image = AVGK.Properties.Resources._33777Ч2; }
                        else if ((label145.Text != ""))
                        { pictureBox39.Image = AVGK.Properties.Resources._33777Ч1; }
                    }
                    else if ((i > 0) && (i > 9000))
                    {
                        if ((label145.Text != "") && (Convert.ToInt32(label145.Text) > 0))
                        { pictureBox39.Image = AVGK.Properties.Resources._33777К2; }
                        else if ((label145.Text != ""))
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
                pictureBox39.Visible = false;
            }
        }
        #endregion       
        #endregion /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                
        private void dataGridView8_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
                 int currentRow = dataGridView8.CurrentRow.Index; // номер строки, по которой кликнули
                alphaBlendTextBox25.Text = dataGridView8[0, currentRow].Value.ToString(); //ID
                alphaBlendTextBox33.Text = dataGridView8[2, currentRow].Value.ToString();
                alphaBlendTextBox26.Text = dataGridView8[1, currentRow].Value.ToString().Substring(0, 10);
                int aaa = Convert.ToInt32(dataGridView8[0, currentRow].Value);
                int aaa2 = Convert.ToInt32(dataGridView8[14, currentRow].Value);//DSL.Tables[0].Rows[currentRow].Field<int>("AxleCount");
            label83.Text = "";
            Osh = 0;
            if (Convert.ToDouble(dataGridView8[4, currentRow].Value) == 0 || Convert.ToDouble(dataGridView8[6, currentRow].Value) == 0 || Convert.ToDouble(dataGridView8[7, currentRow].Value) == 0)
            {
                label83.Text = "Критическая ошибка средств измерения (открытие карточки проезда невозможно)";
            }

            TSh = "";
                ZagrdataGridView8(aaa);
            string Oshib = Convert.ToString(Osh, 2);
            if (Oshib != "0" && Oshib.Length > 9)
            {
                label83.Text = label83.Text.ToString() + "Ошибка на измерительном комплексе: ";
                if (Oshib.Substring(Oshib.Length - 1) != "0")
                { label83.Text = label83.Text.ToString() + " -не все данные были получены от датчиков;"; }
                if (Convert.ToInt64(Oshib.Substring(Oshib.Length - 2)) > 9)
                { label83.Text = label83.Text.ToString() + " -неравномерное движение ТС;"; }
                if (Convert.ToInt64(Oshib.Substring(Oshib.Length - 3)) > 99)
                { label83.Text = label83.Text.ToString() + " -размеры ТС выходит за допустимые пределы измерения;"; }
                if (Convert.ToInt64(Oshib.Substring(Oshib.Length - 4)) > 999)
                { label83.Text = label83.Text.ToString() + " -нагрузка на ось выходит за пределы измерения;"; }
                if (Convert.ToInt64(Oshib.Substring(Oshib.Length - 5)) > 9999)
                { label83.Text = label83.Text.ToString() + " -ошибка определения количества осей;"; }
                if (Convert.ToInt64(Oshib.Substring(Oshib.Length - 6)) > 99999)
                { label83.Text = label83.Text.ToString() + " -ошибка измерения межосевого расстояния;"; }
                if (Convert.ToInt64(Oshib.Substring(Oshib.Length - 7)) > 999999)
                { label83.Text = label83.Text.ToString() + " -ошибка измерения длины ТС;"; }
                if (Convert.ToInt64(Oshib.Substring(Oshib.Length - 8)) > 9999999)
                { label83.Text = label83.Text.ToString() + " -скорость ТС выходит за допустимые пределы измерения;"; }
            }
            else if (Oshib != "0" && Oshib.Length < 9)
            {
                label83.Text = label83.Text.ToString() + "Ошибка на измерительном комплексе ";
            }
            if (dataGridView8[8, currentRow].Value.ToString() == "")
            {
                label83.Text = label83.Text.ToString() + " Не распознан ГРЗ ТС";
            }
            int i1 = 0;
                int i2 = 0;
                int cnt = 0;
                TipoS = "";
                for (i1 = 0; i1 < 9; i1++)
                {

                    if (i1 > 0)
                    {
                        if (KN[0, i1] != KN[0, i1 - 1])
                        {
                            KN[1, i1 - 1] = cnt;
                            cnt = 0;
                        }
                    }
                    cnt = cnt + 1;
                }
                for (i1 = 0; i1 < 9; i1++)
                {
                    if (KN[1, i1] > 0)
                    {
                        TipoS = TipoS + KN[1, i1].ToString() + "+";
                    }
                }
                if (TipoS != null)
                {
                    if (TipoS != "")
                    {
                        TipoS = TipoS.Remove(TipoS.Length - 1, 1);
                    }
                    alphaBlendTextBox36.Text = TipoS;
            }
        }
        #region /////////////////////////////////////////////// Запрос класса ТС (ЛЕВАЯ)
        public void ZKLL()
        {
            if (KolOsL == 0 || ObshMass == 0)
            {
                alphaBlendTextBox31.Text = "Ошибка измерений, определение невозможно";
            }
            else if (KolOsL > 8)
            {
                alphaBlendTextBox31.Text = "12 (Прочие нестандартные АТС (Сельхоз, строительная и прочая техника))";
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
                zapros2.KlassTS(D111, D1_2, D2_3, D3_4, D4_5, D5_6, D6_7, D7_8, KolOsL, ObshMass);
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

                        FFF = reader2["naimklassts"].ToString();
                        FF = reader2["tipschema"].ToString();
                        alphaBlendTextBox31.Text = FFF + ", схема**: " + FF;
                        if (reader2["tipschema"].ToString().Length == 1)
                        { TTS = 1; }
                        else if (reader2["tipschema"].ToString().Length > 1)
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
                }
            }
        }
        #endregion ///////////////////////////////////////////////
        #region/////////////////////////////////////////////   загрузка всех параметров проезда для K(ЛЕВЫЙ) //////////////////  
        public void ZagrdataGridView8(int IDp)//, int CO)
        {
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            MySqlCommand commandL = new MySqlCommand();
            ConnectStr conStrL = new ConnectStr();
            conStrL.ConStr(1);           
            string connectionStringL;
            connectionStringL = conStrL.StP;
            MySqlConnection connectionL = new MySqlConnection(connectionStringL);
            Zapros zaprosL = new Zapros();
            zaprosL.ZaprLevKontrOsi(IDp); 
            zL = zaprosL.commandStringTest;
            commandL.CommandText = zL;
            commandL.Connection = connectionL;
            MySqlDataReader readerL;

            int NumberIter = 0;
            label162.Text = "0"; label161.Text = "0"; label160.Text = "0"; label159.Text = "0";
            label158.Text = "0"; label157.Text = "0"; label156.Text = "0"; label155.Text = "0";

            label153.Text = "0"; label152.Text = "0"; label151.Text = "0"; label150.Text = "0";
            label149.Text = "0"; label148.Text = "0"; label147.Text = "0"; label146.Text = "0";
            label145.Text = "0";

            label171.Text = "0"; label170.Text = "0"; label169.Text = "0"; label168.Text = "0";
            label167.Text = "0"; label166.Text = "0"; label165.Text = "0"; label164.Text = "0";
            label163.Text = "0";
            KN = new int[2, 9];
            int i1 = 0;
            commandL.Connection.Open();
            try
            {                
                readerL = commandL.ExecuteReader();
                double pos = 0;
                while (readerL.Read())
                {
                    Osh = Convert.ToInt32(readerL["CredenceExceeded"].ToString());

                    label144.Text = Convert.ToString(Convert.ToDouble(readerL["Weight"]) / 1000);
                    label154.Text = Convert.ToString(Convert.ToDouble(readerL["Length"]) / 100);
                    if (readerL["CheckSumIsch"].ToString() != readerL["CheckSum"].ToString())
                    { pictureBox16.Visible=true /*label233.Visible = true*/; }
                    else { pictureBox16.Visible = false /*label233.Visible = false*/; }

                    if (NumberIter == 0)
                    {
                        string i = Convert.ToString(Convert.ToInt32(readerL["wheelCount"]) / 2);
                        label153.Text = i;//Convert.ToString(Convert.ToInt32(readerL["wheelCount"]) / 2);
                        string ii = Convert.ToString(Convert.ToDouble(readerL["weightAxel"]) / 1000);
                        label171.Text = ii;//Convert.ToString(Convert.ToDouble(readerL["weightAxel"]) / 1000);
                    }
                    if (NumberIter == 1)
                    {
                        label152.Text = Convert.ToString(Convert.ToInt32(readerL["wheelCount"]) / 2);
                        label162.Text = Convert.ToString((Convert.ToDouble(readerL["position"]) / 100) - pos);
                        pos = Convert.ToDouble(readerL["position"]) / 100;
                        label170.Text = Convert.ToString(Convert.ToDouble(readerL["weightAxel"]) / 1000);
                    }
                    if (NumberIter == 2)
                    {
                        label151.Text = Convert.ToString(Convert.ToInt32(readerL["wheelCount"]) / 2);
                        label161.Text = Convert.ToString((Convert.ToDouble(readerL["position"]) / 100) - pos);
                        pos = Convert.ToDouble(readerL["position"]) / 100;
                        label169.Text = Convert.ToString(Convert.ToDouble(readerL["weightAxel"]) / 1000);
                    }
                    if (NumberIter == 3)
                    {
                        label150.Text = Convert.ToString(Convert.ToInt32(readerL["wheelCount"]) / 2);
                        label160.Text = Convert.ToString((Convert.ToDouble(readerL["position"]) / 100) - pos);
                        pos = Convert.ToDouble(readerL["position"]) / 100;
                        label168.Text = Convert.ToString(Convert.ToDouble(readerL["weightAxel"]) / 1000);
                    }
                    if (NumberIter == 4)
                    {
                        label149.Text = Convert.ToString(Convert.ToInt32(readerL["wheelCount"]) / 2);
                        label159.Text = Convert.ToString((Convert.ToDouble(readerL["position"]) / 100) - pos);
                        pos = Convert.ToDouble(readerL["position"]) / 100;
                        label167.Text = Convert.ToString(Convert.ToDouble(readerL["weightAxel"]) / 1000);
                    }
                    if (NumberIter == 5)
                    {
                        label148.Text = Convert.ToString(Convert.ToInt32(readerL["wheelCount"]) / 2);
                        label158.Text = Convert.ToString((Convert.ToDouble(readerL["position"]) / 100) - pos);
                        pos = Convert.ToDouble(readerL["position"]) / 100;
                        label166.Text = Convert.ToString(Convert.ToDouble(readerL["weightAxel"]) / 1000);
                    }
                    if (NumberIter == 6)
                    {
                        label147.Text = Convert.ToString(Convert.ToInt32(readerL["wheelCount"]) / 2);
                        label157.Text = Convert.ToString((Convert.ToDouble(readerL["position"]) / 100) - pos);
                        pos = Convert.ToDouble(readerL["position"]) / 100;
                        label165.Text = Convert.ToString(Convert.ToDouble(readerL["weightAxel"]) / 1000);
                    }
                    if (NumberIter == 7)
                    {
                        label146.Text = Convert.ToString(Convert.ToInt32(readerL["wheelCount"]) / 2);
                        label156.Text = Convert.ToString((Convert.ToDouble(readerL["position"]) / 100) - pos);
                        pos = Convert.ToDouble(readerL["position"]) / 100;
                        label164.Text = Convert.ToString(Convert.ToDouble(readerL["weightAxel"]) / 1000);
                    }
                    if (NumberIter == 8)
                    {
                        label145.Text = Convert.ToString(Convert.ToInt32(readerL["wheelCount"]) / 2);
                        label155.Text = Convert.ToString((Convert.ToDouble(readerL["position"]) / 100) - pos);
                        pos = Convert.ToDouble(readerL["position"]) / 100;
                        label163.Text = Convert.ToString(Convert.ToDouble(readerL["weightAxel"]) / 1000);
                    }


                    KN[0, i1] = Convert.ToInt32(readerL["group"]);
                    i1 = i1 + 1;
                    TSh = TSh + Convert.ToString(readerL["group"]);
                    NumberIter = NumberIter + 1;
                    //#region ///// Заполнение переменных о выбранном проезде для определения класса и расчета ПДК :)
                    KolOsL = Convert.ToInt32(readerL["AxleCount"]);
                    Cl = Convert.ToInt32(readerL["Class2"].ToString());

                    if (readerL["IDKlassN"].ToString() != "0")
                    { alphaBlendTextBox31.Text = readerL["IDKlassN"].ToString(); Cl = Convert.ToInt32(readerL["IDKlassN"].ToString()); }
                    else
                    {
                        if (readerL["Class2"].ToString().Length > 3)
                        { alphaBlendTextBox31.Text = readerL["Class2"].ToString().Substring(0, 2); }
                        else if (readerL["Class2"].ToString().Length <= 1)
                        { alphaBlendTextBox31.Text = "0"; }
                        else { alphaBlendTextBox31.Text = readerL["Class2"].ToString().Substring(0, 1); }
                    }
                    ObshMass = Convert.ToDouble(readerL["Weight"].ToString());
                    ADNagr = Convert.ToDouble(readerL["maxosnagr"].ToString());
                    alphaBlendTextBox29.Text = readerL["namead"].ToString();
                    alphaBlendTextBox30.Text = readerL["namenapr"].ToString();
                    alphaBlendTextBox32.Text = readerL["dislocationapvk"].ToString();
                    alphaBlendTextBox35.Text = readerL["nameapvk"].ToString();
                    label73.Text = readerL["dislocationapvk"].ToString();//readerL["nameapvk"].ToString() + ", " +
                    alphaBlendTextBox34.Text = readerL["Lane"].ToString();
                   
                    string Pl = readerL["Plate"].ToString();
                    label141.Text = "";
                    label140.Text = "";
                    label139.Text = "";
                    label138.Text = "";
                    label135.Text = "";
                    label133.Text = "";
                    label127.Text = "";
                    label137.Text = "";
                    label131.Text = "";
                    int n = Pl.Length;
                    if (n >= 1) { label141.Text = Pl.Substring(0, 1); }
                    if (n >= 2) { label140.Text = Pl.Substring(1, 1); }
                    if (n >= 3) { label139.Text = Pl.Substring(2, 1); }
                    if (n >= 4) { label138.Text = Pl.Substring(3, 1); }
                    if (n >= 5) { label135.Text = Pl.Substring(4, 1); }
                    if (n >= 6) { label133.Text = Pl.Substring(5, 1); }
                    if (n >= 7) { label127.Text = Pl.Substring(6, 1); }
                    if (n >= 8) { label137.Text = Pl.Substring(7, 1); }
                    if (n == 9) { label131.Text = Pl.Substring(8, 1); }

                    IDW = Convert.ToInt64(readerL["ID_wim"].ToString());
                    PLN = readerL["PlatformId"].ToString();
                    IDpish = Convert.ToInt64(readerL["ID_wim"]);
                    if (readerL["Class3"].ToString() != null)
                    {
                        NPicKL = Convert.ToInt64(readerL["Class3"]);
                    }
                    else { NPicKL = 0; ColPicKL = 0; }
                }
                readerL.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: \r\n{0}", ex.ToString());
            }
          
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
                    ColPicKL = Convert.ToInt32(readerLB11["CB"]);
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

            pictureBox40.Image = null;
                        pictureBox29.Image = null;
            if (ColPicKL < 16)
            {
            for (int i = 0; i < ColPicKL; i++)
                {
                    if (i != 0)
                    { NPicKL = NPicKL - 1; }
                   Zapros zaprosLB = new Zapros();
                    if (alphaBlendTextBox26.Text.ToString() != null || alphaBlendTextBox26.Text.ToString() != "000000" || alphaBlendTextBox26.Text.ToString() != "")
                    {
                       if ((Convert.ToDateTime(dataGridView8[9, (dataGridView8.CurrentRow.Index)].Value.ToString()) < Convert.ToDateTime("08.06.2018 13:25:49") && PLN == "2952855555") || (Convert.ToDateTime(dataGridView8[9, (dataGridView8.CurrentRow.Index)].Value.ToString()) < Convert.ToDateTime("24.05.2018 16:50:25") && PLN == "2952855553"))
                        {
                            zaprosLB.ZaprBitmapPHOTO(NPicKL, PLN, IDW);
                            zLB = zaprosLB.commandStringTest;
                            commandL.CommandText = zLB;
                            commandL.Connection = connectionL;
                            MySqlDataReader readerLB;
                            try
                            {
                                readerLB = commandL.ExecuteReader();
                                while (readerLB.Read())
                                {
                                    if (readerLB["name"].ToString() != "Video")
                                    {
                                        if (readerLB["name"].ToString() == "Image")
                                    {
                                        string st5;
                                        if (Puti[5] == "WIN-D3J6PR1H9QK")
                                        { st5 = readerLB["dataavailable"].ToString(); }
                                        else { st5 = @"" + Puti[2] + "" + readerLB["dataavailable"].ToString().Substring(13, readerLB["dataavailable"].ToString().Length - 13); };

                                        pictureBox40.Image = new Bitmap(@"" + st5);
                                    }
                                    if (readerLB["name"].ToString() == "ImgPlate")
                                    {
                                        string st6;
                                        if (Puti[5] == "WIN-D3J6PR1H9QK")
                                        { st6 = readerLB["dataavailable"].ToString(); }
                                        else { st6 = @"" + Puti[2] + "" + readerLB["dataavailable"].ToString().Substring(13, readerLB["dataavailable"].ToString().Length - 13); };

                                        pictureBox29.Image = new Bitmap(@"" + st6);
                                    }
                                        if (readerLB["name"].ToString() == "ReaPlate")
                                        {
                                            if (Puti[5] == "WIN-D3J6PR1H9QK")
                                            { st7 = readerLB["dataavailable"].ToString(); }
                                            else { st7 = @"" + Puti[2] + "" + readerLB["dataavailable"].ToString().Substring(13, readerLB["dataavailable"].ToString().Length - 13); }
                                            if (pictureBox29.Image == null)
                                            {
                                                pictureBox29.Image = new Bitmap(@"" + st7);
                                            }
                                        }
                                    }
                                    else
                                    {
                                    }                                
                            }

                                readerLB.Close();
                            }
                            catch (MySqlException ex)
                            {
                                Console.WriteLine("Error: \r\n{0}", ex.ToString());
                            }
                        }
                        else
                        {
                            zaprosLB.ZaprBitmapPHOTONew(NPicKL, PLN, IDW);
                            zLB = zaprosLB.commandStringTest;
                            commandL.CommandText = zLB;
                            commandL.Connection = connectionL;
                            MySqlDataReader readerLB;
                            try
                            {

                                readerLB = commandL.ExecuteReader();
                                while (readerLB.Read())
                                {
                                    if (readerLB["name"].ToString() != "Video")
                                    {
                                        if (readerLB["name"].ToString() == "Image")
                                {
                                        string st5;
                                        if (Puti[5] == "WIN-D3J6PR1H9QK")
                                        { st5 = readerLB["dataavailable"].ToString(); }
                                        else { st5 = @"" + Puti[2] + "" + readerLB["dataavailable"].ToString().Substring(13, readerLB["dataavailable"].ToString().Length - 13); };
                                        pictureBox40.Image = new Bitmap(@""+st5);
                                }
                                if (readerLB["name"].ToString() == "ImgPlate")
                                {
                                        string st6;
                                        if (Puti[5] == "WIN-D3J6PR1H9QK")
                                        { st6 = readerLB["dataavailable"].ToString(); }
                                        else { st6 = @"" + Puti[2] + "" + readerLB["dataavailable"].ToString().Substring(13, readerLB["dataavailable"].ToString().Length - 13); };
                                        pictureBox29.Image = new Bitmap(@"" + st6);
                                }
                                        if (readerLB["name"].ToString() == "ReaPlate")
                                        {
                                            if (Puti[5] == "WIN-D3J6PR1H9QK")
                                            { st7 = readerLB["dataavailable"].ToString(); }
                                            else { st7 = @"" + Puti[2] + "" + readerLB["dataavailable"].ToString().Substring(13, readerLB["dataavailable"].ToString().Length - 13); }
                                            if (pictureBox29.Image == null)
                                            {
                                                pictureBox29.Image = new Bitmap(@"" + st7);
                                            }
                                        } 
                                    }
                                    else
                                    {
                                    }
                                }

                                readerLB.Close();
                            }
                            catch (MySqlException ex)
                            {
                                Console.WriteLine("Error: \r\n{0}", ex.ToString());
                            }

                        }
                    }
                }
                
            }
            commandL.Connection.Close();
        }

        #endregion///////////////////////////////////////////// 

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        #region По нажатию на картинку - открытие формы детальной инфо (ПРАВАЯ) ///////////////////////////////////
        private void pictureBox23_Click(object sender, EventArgs e)// По нажатию на картинку - открытие формы Увеличенно (Левая часть)
        {
            if (pictureBox40.Image != null)
            {
                if (SelfRef.iz == 1)
                {
                    FormPic newfrm = new FormPic(pictureBox40.Image);
                    newfrm.Show();
                }
            }
        }
        #endregion

        public void Otrisovka1()//раскраска ячеек
        {
            // |||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
            foreach (DataGridViewRow row in dataGridView8.Rows) //цикл
            {
                this.Cursor = Cursors.WaitCursor;
                if ((Convert.ToBoolean(row.Cells[10].Value.ToString()) == true)|| (Convert.ToBoolean(row.Cells[11].Value.ToString()) == true) || (Convert.ToBoolean(row.Cells[12].Value.ToString()) == true))//days > 9000)
                {
                    row.Cells[0].Style.BackColor = System.Drawing.Color.LightPink;
                    row.Cells[1].Style.BackColor = System.Drawing.Color.LightPink;
                    row.Cells[2].Style.BackColor = System.Drawing.Color.LightPink;
                    row.Cells[3].Style.BackColor = System.Drawing.Color.LightPink;
                    row.Cells[20].Style.BackColor = System.Drawing.Color.LightPink;
                    row.Cells[5].Style.BackColor = System.Drawing.Color.LightPink;
                    row.Cells[6].Style.BackColor = System.Drawing.Color.LightPink;
                    row.Cells[7].Style.BackColor = System.Drawing.Color.LightPink;
                    row.Cells[8].Style.BackColor = System.Drawing.Color.LightPink;
                    row.Cells[4].Style.BackColor = System.Drawing.Color.LightPink;

                }
                if (Convert.ToDouble(row.Cells[4].Value) == 0 || Convert.ToDouble(row.Cells[6].Value) == 0 || Convert.ToDouble(row.Cells[7].Value) == 0 || row.Cells[19].Value.ToString() != "0")
                {
                    row.Cells[0].Style.BackColor = System.Drawing.Color.LightYellow;
                    row.Cells[1].Style.BackColor = System.Drawing.Color.LightYellow;
                    row.Cells[2].Style.BackColor = System.Drawing.Color.LightYellow;
                    row.Cells[3].Style.BackColor = System.Drawing.Color.LightYellow;
                    row.Cells[4].Style.BackColor = System.Drawing.Color.LightYellow;
                    row.Cells[20].Style.BackColor = System.Drawing.Color.LightYellow;
                    row.Cells[6].Style.BackColor = System.Drawing.Color.LightYellow;
                    row.Cells[7].Style.BackColor = System.Drawing.Color.LightYellow;
                    row.Cells[8].Style.BackColor = System.Drawing.Color.LightYellow;
                    row.Cells[5].Style.BackColor = System.Drawing.Color.LightYellow;
                }
                
                else
                {
                }
                this.Cursor = Cursors.Default;
            }


        }
        #region .......................          Подпись сколько валидных проездов в таблице (Левая и МОНИТОРИНГ)
        private void toolStriplabel171_TextChanged(object sender, EventArgs e)
        {
            int Sum = 0;
            for (int i = 0; i < dataGridView8.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dataGridView8.Rows[i].Cells[10].Value) == true || Convert.ToBoolean(dataGridView8.Rows[i].Cells[11].Value) == true || Convert.ToBoolean(dataGridView8.Rows[i].Cells[12].Value) == true || Convert.ToBoolean(dataGridView8.Rows[i].Cells[14].Value) == true) //Convert.ToInt32(dataGridView8.Rows[i].Cells[53].Value) == -1)
                {
                    Sum = Sum + 1;
                }
            }
            toolStripLabel16.Text = "" + (Convert.ToInt32(Sum)).ToString();
        }

        private void toolStripLabel18_TextChanged(object sender, EventArgs e)
        {
            int SumR = 0;
            for (int ivr = 0; ivr < dataGridView11.Rows.Count; ivr++)
            {
                if (Convert.ToInt32(dataGridView11.Rows[ivr].Cells[10].Value) != 0)//Convert.ToBoolean(dataGridView11.Rows[ivr].Cells[58].Value) == true || Convert.ToBoolean(dataGridView11.Rows[ivr].Cells[59].Value) == true || Convert.ToBoolean(dataGridView11.Rows[ivr].Cells[65].Value) == true || Convert.ToString(dataGridView11.Rows[ivr].Cells[39].Value) == "")
                {
                    SumR = SumR + 1;
                }
            }
            toolStripLabel20.Text = "" + (Convert.ToInt32(SumR)).ToString();
        }

        //////////////////////////////////////////////////////////////       Подпись сколько валидных проездов в таблице МОНИТОРИНГ
        private void toolStripLabel2_TextChanged(object sender, EventArgs e)
        {
            int Sum = 0;
            for (int i = 0; i < dataGridView9.Rows.Count; i++)
            {
                if (
                    (Convert.ToBoolean(dataGridView9.Rows[i].Cells[15].Value) == true || Convert.ToBoolean(dataGridView9.Rows[i].Cells[14].Value) == true || Convert.ToBoolean(dataGridView9.Rows[i].Cells[13].Value) == true 
                    || Convert.ToBoolean(dataGridView9.Rows[i].Cells[10].Value) == true || Convert.ToBoolean(dataGridView9.Rows[i].Cells[11].Value) == true || Convert.ToBoolean(dataGridView9.Rows[i].Cells[12].Value) == true /*|| Convert.ToBoolean(dataGridView9.Rows[i].Cells[14].Value) == true*/
                    && (Convert.ToDouble(dataGridView9.Rows[i].Cells[4].Value) == 0 || Convert.ToDouble(dataGridView9.Rows[i].Cells[6].Value) == 0 || Convert.ToDouble(dataGridView9.Rows[i].Cells[7].Value) == 0 || dataGridView9.Rows[i].Cells[19].Value.ToString() != "0")
                    )/* && Convert.ToInt32(dataGridView9.Rows[i].Cells[19].Value)==0 */)
                {
                    Sum = Sum + 1;
                }
            }
            toolStripLabel4.Text = "" + (Convert.ToInt32(Sum)).ToString();
        }
        #endregion
        #region //////////////////////   TIMER    ///////////////////////////////   запоминаем позицию выделенной строки (ЛЕВАЯ) и после обновления переходим на нее
        private void timer1_Tick(object sender, EventArgs e)
        {
            nKl = nKl + 6;
            dateTimePicker8.Value = DateTime.Now;
            dateTimePicker7.Value = dateTimePicker8.Value.AddHours(-1);//.AddSeconds(-nKl);//dateTimePicker8.Value.AddHours(-12);
            dateTimePicker2.Value = DateTime.Now;//dateTimePicker8.Value;//Convert.ToDateTime("2018.04.13 11:50:00");
            if (dataGridView8.Rows.Count != 0)
            { RCL = dataGridView8.CurrentCell.RowIndex;
            }
            if (DSL != null)
                DSL.Clear();
            //StopSearch();
            ZKontrolL("");
            if (dataGridView8.Rows.Count != 0)
            {
                if (toolStripLabel14.Text != "")
                {
                    kol = Convert.ToInt32(toolStripLabel14.Text);
                }
                dataGridView8.CurrentCell = dataGridView8[0, RCL];
                rowIndexM = dataGridView9.CurrentCell.RowIndex;
                //rowIndex = dataGridView8.SelectedCells[0].RowIndex;
                if (kol > rowIndex)
                { kol = 0; }
                int Sum = 0;
                for (int i = 0; i < dataGridView8.Rows.Count; i++)
                {
                    Sum = Sum + 1;// (int)dataGridView8.Rows[i].Cells[0].Value;
                }
                if (Sum - kol < Sum)
                { kol = Sum - kol; }
                currentRowLeft = rowIndex + kol;
                dataGridView8.CurrentCell = dataGridView8[0, rowIndex + kol];
                toolStripLabel14.Text = "" + (Convert.ToInt32(Sum)).ToString();

                int SumKR = 0;
                for (int i = 0; i < dataGridView8.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(dataGridView8.Rows[i].Cells[10].Value) == true || Convert.ToBoolean(dataGridView8.Rows[i].Cells[11].Value) == true || Convert.ToBoolean(dataGridView8.Rows[i].Cells[12].Value) == true || Convert.ToBoolean(dataGridView8.Rows[i].Cells[14].Value) == true) //Convert.ToInt32(dataGridView8.Rows[i].Cells[53].Value) == -1)
                    {
                        SumKR = SumKR + 1;
                    }
                }
                toolStripLabel16.Text = "" + (Convert.ToInt32(SumKR)).ToString();
                Otrisovka1();
            }
        }
        #endregion
        private void checkBox9_CheckedChanged(object sender, EventArgs e) //  Флажок онлайн для контроля левого
        {
            if (checkBox9.Checked)
            { timer1.Enabled = true; }
            else
            { timer1.Enabled = false; }
        }
        private void dataGridView8_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)/////////////   щелчек по левой таблице
        {
            int rowNum;
            rowNum = dataGridView8.CurrentRow.Index;
            string znachenie = Convert.ToString(dataGridView8[14, rowNum].Value);
        }

        #region    //////////////////////////      Рисунки колесных пар  СПРАВА  ///////////////////////////////////////
        #region          Общая скобка по весу и длине + направление движения   ///////////////////////////////////////
        private void label196_TextChanged(object sender, EventArgs e)// Изменения в правой части (передвижение по таблице)//Общая скобка по весу и длине + направление движения
        {
            label213.Visible = false; label212.Visible = false; label211.Visible = false; label210.Visible = false;
            label209.Visible = false; label208.Visible = false; label207.Visible = false; label206.Visible = false;
            label205.Visible = false;
            label204.Visible = false; label203.Visible = false; label202.Visible = false; label201.Visible = false;
            label200.Visible = false; label199.Visible = false; label198.Visible = false; label197.Visible = false;
            label196.Visible = false;
            label186.Visible = false;
            label195.Visible = false; label194.Visible = false; label193.Visible = false; label192.Visible = false;
            label191.Visible = false; label190.Visible = false; label189.Visible = false; label188.Visible = false;
            label187.Visible = false;

            pictureBox52.Visible = false;
            pictureBox44.Visible = false;
            pictureBox45.Visible = false;
            pictureBox46.Visible = false;
            pictureBox47.Visible = false;
            pictureBox48.Visible = false;
            pictureBox49.Visible = false;
            pictureBox50.Visible = false;
            pictureBox51.Visible = false;
            #region  //////////////////////////////////    Общая скобка и стрелка направления  ///////////////////////////////////////
            pictureBox54.Visible = false;//скобка
            pictureBox42.Visible = false;//стрелка
            label196.Visible = false;//надпись общ.длина
            string s = label196.Text;
            double i;
            if (label196.Text != "")
                i = Convert.ToDouble(s.ToString());
            else i = 0;
            if (i > 0)
            {
                label186.Visible = true;
                double loc2 = 0;
                string TO;
                TO = "Общая длина ТС - " + Convert.ToDouble(s) + " м. " + "\n" + "Общий вес: " + Convert.ToDouble(label186.Text) + " т. ";
                loc2 = 15 * i + 150;
                int loc3 = Convert.ToInt32(loc2);
                pictureBox54.Width = loc3 - 10;
                int newloc = 57 + loc3 / 2;
                pictureBox54.Location = new Point(220, 258);
                double loc = Convert.ToDouble(label196.Text) * 100;
                location = 57 + Convert.ToInt32(35 * loc / 100);
                pictureBox42.Location = new Point(Convert.ToInt32(loc2) + 195, 223);
                pictureBox42.Visible = true;
                label214.Text = TO;
                label214.Location = new Point((loc3 / 2 + 137), 285); //location / 2 + 90), 285);
                label214.BackColor = Color.Transparent;
                pictureBox54.Visible = true;
                label214.Visible = true;
                pictureBox42.Visible = true;
                label186.Visible = false;
                label196.Visible = false;//надпись общ.длина
            }
        }
        #endregion     ///////////////////////////////////////
        #region  ////////////////////////////////////////////  ПЕРВАЯ ОСЬ      /////////////////////////////////////// 
        private void Label213_TextChanged(System.Object sender, System.EventArgs e)// Рисунок первой колесной пары + данные по ней
        {
            string s = Convert.ToString(Convert.ToDouble(label213.Text) * 1000);// reader["o1m"].ToString();
            label195.Visible = true;
            int i;
            if (label204.Text != "")
            { i = Convert.ToInt32(s); }//Convert.ToInt32(znachenie); 
            else i = 0;
            if (i > 0)
            {
                double loc = Convert.ToDouble(label196.Text) * 100;
                location = 315 + Convert.ToInt32(15 * loc / 100);
                pictureBox44.Location = new Point(location, 220);
                pictureBox44.Image = AVGK.Properties.Resources._33777Ч1;
                label213.Location = new Point(location, 245);
                if ((i > 0) && (i < 9000))
                {
                    if ((label195.Text != "") && (Convert.ToInt32(label195.Text) > 1))
                    { pictureBox44.Image = AVGK.Properties.Resources._33777Ч2; }
                    else if ((label195.Text != ""))
                    { pictureBox44.Image = AVGK.Properties.Resources._33777Ч1; }
                }
                else if ((i > 0) && (i > 9000))
                {
                    if ((label195.Text != "") && (Convert.ToInt32(label195.Text) > 1))
                    { pictureBox44.Image = AVGK.Properties.Resources._33777К2; }
                    else if ((label195.Text != ""))
                    { pictureBox44.Image = AVGK.Properties.Resources._33777К1; }
                }
                pictureBox44.BringToFront();
                pictureBox44.Visible = true;
                label213.Visible = true;
                label195.Visible = false;
            }
            else
            {
                label196.Visible = false;
                label213.Visible = false;
                label195.Visible = false;
            }
        }
        #endregion ///////////////////////////////////////
        #region   ////////////////////////////////////////////  ВТОРАЯ ОСЬ       ///////////////////////////////////////               
        private void Label212_TextChanged(System.Object sender, System.EventArgs e)// Рисунок первой колесной пары + данные по ней
        {
            string s = Convert.ToString(Convert.ToDouble(label212.Text) * 1000);// reader["o2m"].ToString();
            label194.Visible = true;
            int i = 0;
            if (!(label212.Text == "" || Convert.ToDouble(label212.Text) == 0))
            {
                i = Convert.ToInt32(s);
                if (i > 0)
                {
                    double loc1 = 0;
                    loc1 = location - 20 - 21 * (Convert.ToDouble(label204.Text) * 100 + 40) / 100;// + 45;
                    int loc = Convert.ToInt32(Math.Round(loc1));
                    pictureBox45.Location = new Point(loc, 220);//50 + loc, 223);
                    double locLOs = location - 20 - (21 * (Convert.ToDouble(label204.Text) / 2 * 100)) / 100;// + 45;
                    int locL = Convert.ToInt32(Math.Round(locLOs));
                    label204.Location = new Point(locL, 195);
                    label212.Location = new Point(loc, 245);

                    if ((i > 0) && (i < 9000))
                    {
                        if ((label194.Text != "") && (Convert.ToInt32(label194.Text) > 1))
                        { pictureBox45.Image = AVGK.Properties.Resources._33777Ч2; }
                        else if ((label194.Text != ""))
                        { pictureBox45.Image = AVGK.Properties.Resources._33777Ч1; }
                    }
                    else if ((i > 0) && (i > 9000))
                    {
                        if ((label194.Text != "") && (Convert.ToInt32(label194.Text) > 1))
                        { pictureBox45.Image = AVGK.Properties.Resources._33777К2; }
                        else if ((label194.Text != ""))
                        { pictureBox45.Image = AVGK.Properties.Resources._33777К1; }
                    }
                    pictureBox45.BringToFront();
                    pictureBox45.Visible = true;
                    label204.Visible = true;
                    label212.Visible = true;
                    label194.Visible = false;
                }
                else
                {
                    label204.Visible = false;
                    label212.Visible = false;
                    label194.Visible = false;
                }
            }
            else
            {
                i = 0;
                label204.Visible = false;
                label212.Visible = false;
                label194.Visible = false;
                pictureBox45.Visible = false;
            }

        }
        #endregion  ///////////////////////////////////////
        #region  ////////////////////////////////////////////  ТРЕТЬЯ ОСЬ       /////////////////////////////////////// 
        private void Label211_TextChanged(System.Object sender, System.EventArgs e)// Рисунок первой колесной пары + данные по ней
        {
            string s = Convert.ToString(Convert.ToDouble(label211.Text) * 1000);
            int i = 0;
            if (!(label211.Text == "" || Convert.ToDouble(label211.Text) == 0))
            {
                i = Convert.ToInt32(s);
                if (i > 0)
                {
                    label193.Visible = true;
                    double loc1 = 0;
                    loc1 = location - 20 - (21 * ((Convert.ToDouble(label203.Text) + Convert.ToDouble(label204.Text)) * 100 + 40) / 100);
                    int loc = Convert.ToInt32(Math.Round(loc1));
                    pictureBox46.Location = new Point(loc, 220);
                    double locLOs = location - 20 - (21 * ((Convert.ToDouble(label203.Text) + Convert.ToDouble(label204.Text) / 2) * 100 + 40)) / 100;
                    int locL = Convert.ToInt32(Math.Round(locLOs));
                    label203.Location = new Point(locL, 195);
                    label211.Location = new Point(loc, 245);

                    if ((i > 0) && (i < 9000))
                    {
                        if ((label193.Text != "") && (Convert.ToInt32(label193.Text) > 1))
                        { pictureBox46.Image = AVGK.Properties.Resources._33777Ч2; }
                        else if (label193.Text != "")
                        { pictureBox46.Image = AVGK.Properties.Resources._33777Ч1; }
                    }
                    else if ((i > 0) && (i > 9000))
                    {
                        if ((label193.Text != "") && (Convert.ToInt32(label193.Text) > 1))
                        { pictureBox46.Image = AVGK.Properties.Resources._33777К2; }
                        else if (label193.Text != "")
                        { pictureBox46.Image = AVGK.Properties.Resources._33777К1; }
                    }
                    pictureBox46.BringToFront();
                    pictureBox46.Visible = true;
                    label203.Visible = true;
                    label211.Visible = true;
                    label193.Visible = false;
                }
                else
                {
                    label203.Visible = false;
                    label211.Visible = false;
                    label193.Visible = false;
                }
            }
            else
            {
                i = 0;
                label203.Visible = false;
                label211.Visible = false;
                label193.Visible = false;
                pictureBox46.Visible = false;
            }

        }
        #endregion  ///////////////////////////////////////
        #region //////////////////////////////////////////////  ЧЕТВЕРТАЯ ОСЬ       ///////////////////////////////////////
        private void Label210_TextChanged(System.Object sender, System.EventArgs e)// Рисунок первой колесной пары + данные по ней
        {
            string s = Convert.ToString(Convert.ToDouble(label210.Text) * 1000);
            int i = 0;
            if (!(label210.Text == "" || Convert.ToDouble(label210.Text) == 0))
            {
                i = Convert.ToInt32(s);
                if (i > 0)
                {
                    label192.Visible = true;
                    double loc1 = 0;
                    loc1 = location - 20 - (21 * ((Convert.ToDouble(label204.Text) + Convert.ToDouble(label203.Text) + Convert.ToDouble(label202.Text)) * 100 + 40) / 100);
                    int loc = Convert.ToInt32(Math.Round(loc1));
                    pictureBox47.Location = new Point(loc, 220);
                    double locLOs = location - 20 - (21 * ((Convert.ToDouble(label204.Text) + Convert.ToDouble(label203.Text) + Convert.ToDouble(label202.Text) / 2) * 100 + 40)) / 100;
                    int locL = Convert.ToInt32(Math.Round(locLOs));
                    label202.Location = new Point(locL, 195);
                    label210.Location = new Point(loc, 245);

                    if ((i > 0) && (i < 9000))
                    {
                        if ((label192.Text != "") && (Convert.ToInt32(label192.Text) > 1))
                        { pictureBox47.Image = AVGK.Properties.Resources._33777Ч2; }
                        else if (label192.Text != "")
                        { pictureBox47.Image = AVGK.Properties.Resources._33777Ч1; }
                    }
                    else if ((i > 0) && (i > 9000))
                    {
                        if ((label192.Text != "") && (Convert.ToInt32(label192.Text) > 1))
                        { pictureBox47.Image = AVGK.Properties.Resources._33777К2; }
                        else if (label192.Text != "")
                        { pictureBox47.Image = AVGK.Properties.Resources._33777К1; }
                    }
                    pictureBox47.BringToFront();
                    pictureBox47.Visible = true;
                    label202.Visible = true;
                    label210.Visible = true;
                    label192.Visible = false;
                }
                else
                {
                    label202.Visible = false;
                    label210.Visible = false;
                    label192.Visible = false;
                }
            }
            else
            {
                i = 0;
                label202.Visible = false;
                label210.Visible = false;
                label192.Visible = false;
                pictureBox47.Visible = false;
            }
        }
        #endregion ///////////////////////////////////////
        #region  ////////////////////////////////////////////  ПЯТАЯ ОСЬ       ///////////////////////////////////////
        private void Label209_TextChanged(System.Object sender, System.EventArgs e)// Рисунок первой колесной пары + данные по ней
        {
            string s = Convert.ToString(Convert.ToDouble(label209.Text) * 1000);
            int i = 0;
            if (!(label209.Text == "" || Convert.ToDouble(label209.Text) == 0))
            {
                i = Convert.ToInt32(s);
                if (i > 0)
                {
                    label191.Visible = true;
                    double loc1 = 0;
                    loc1 = location - 20 - (21 * ((Convert.ToDouble(label204.Text) + Convert.ToDouble(label203.Text) + Convert.ToDouble(label202.Text) + Convert.ToDouble(label201.Text)) * 100 + 40) / 100);
                    int loc = Convert.ToInt32(Math.Round(loc1));
                    pictureBox48.Location = new Point(loc, 220);
                    double locLOs = location - 20 - (21 * ((Convert.ToDouble(label204.Text) + Convert.ToDouble(label203.Text) + Convert.ToDouble(label202.Text) + Convert.ToDouble(label201.Text) / 2) * 100 + 40)) / 100;
                    int locL = Convert.ToInt32(Math.Round(locLOs));
                    label201.Location = new Point(locL, 195);
                    label209.Location = new Point(loc, 245);

                    if ((i > 0) && (i < 9000))
                    {
                        if ((label191.Text != "") && (Convert.ToInt32(label191.Text) > 1))
                        { pictureBox48.Image = AVGK.Properties.Resources._33777Ч2; }
                        else if (label191.Text != "")
                        { pictureBox48.Image = AVGK.Properties.Resources._33777Ч1; }
                    }
                    else if ((i > 0) && (i > 9000))
                    {
                        if ((label191.Text != "") && (Convert.ToInt32(label191.Text) > 1))
                        { pictureBox48.Image = AVGK.Properties.Resources._33777К2; }
                        else if (label191.Text != "")
                        { pictureBox48.Image = AVGK.Properties.Resources._33777К1; }
                    }
                    pictureBox48.BringToFront();
                    pictureBox48.Visible = true;
                    label201.Visible = true;
                    label209.Visible = true;
                    label191.Visible = false;
                }
                else
                {
                    label201.Visible = false;
                    label209.Visible = false;
                    label191.Visible = false;
                }
            }
            else
            {
                i = 0;
                label201.Visible = false;
                label209.Visible = false;
                label191.Visible = false;
                pictureBox48.Visible = false;
            }
        }
        #endregion ///////////////////////////////////////
        #region     ////////////////////////////////////////////   ШЕСТАЯ ОСЬ       ///////////////////////////////////////
        private void Label208_TextChanged(System.Object sender, System.EventArgs e)// Рисунок первой колесной пары + данные по ней
        {
            string s = Convert.ToString(Convert.ToDouble(label208.Text) * 1000);
            int i = 0;
            if (!(label208.Text == "" || Convert.ToDouble(label208.Text) == 0))
            {
                i = Convert.ToInt32(s);
                if (i > 0)
                {
                    label190.Visible = true;
                    double loc1 = 0;
                    loc1 = location - 20 - (21 * ((Convert.ToDouble(label204.Text) + Convert.ToDouble(label203.Text) + Convert.ToDouble(label202.Text) + Convert.ToDouble(label201.Text) + Convert.ToDouble(label200.Text)) * 100 + 40) / 100);
                    int loc = Convert.ToInt32(Math.Round(loc1));
                    pictureBox49.Location = new Point(loc, 220);
                    double locLOs = location - 20 - (21 * ((Convert.ToDouble(label204.Text) + Convert.ToDouble(label203.Text) + Convert.ToDouble(label202.Text) + Convert.ToDouble(label201.Text) + Convert.ToDouble(label200.Text) / 2) * 100 + 40)) / 100;
                    int locL = Convert.ToInt32(Math.Round(locLOs));
                    label200.Location = new Point(locL, 195);
                    label208.Location = new Point(loc, 245);

                    if ((i > 0) && (i < 9000))
                    {
                        if ((label190.Text != "") && (Convert.ToInt32(label190.Text) > 1))
                        { pictureBox49.Image = AVGK.Properties.Resources._33777Ч2; }
                        else if (label190.Text != "")
                        { pictureBox49.Image = AVGK.Properties.Resources._33777Ч1; }
                    }
                    else if ((i > 0) && (i > 9000))
                    {
                        if ((label190.Text != "") && (Convert.ToInt32(label190.Text) > 1))
                        { pictureBox49.Image = AVGK.Properties.Resources._33777К2; }
                        else if (label190.Text != "")
                        { pictureBox49.Image = AVGK.Properties.Resources._33777К1; }
                    }
                    pictureBox49.BringToFront();
                    pictureBox49.Visible = true;
                    label200.Visible = true;
                    label208.Visible = true;
                    label190.Visible = false;
                }
                else
                {
                    label200.Visible = false;
                    label208.Visible = false;
                    label190.Visible = false;
                }
            }
            else
            {
                i = 0;
                label200.Visible = false;
                label208.Visible = false;
                label190.Visible = false;
                pictureBox49.Visible = false;
            }
        }
        #endregion ///////////////////////////////////////
        #region          ////////////////////////////////////////////  СЕДЬМАЯ ОСЬ    //////////////////////////////////////          
        private void Label207_TextChanged(System.Object sender, System.EventArgs e)// Рисунок первой колесной пары + данные по ней
        {
            string s = Convert.ToString(Convert.ToDouble(label207.Text) * 1000);
            int i = 0;
            if (!(label207.Text == "" || Convert.ToDouble(label207.Text) == 0))
            {
                i = Convert.ToInt32(s);
                if (i > 0)
                {
                    label189.Visible = true;
                    double loc1 = 0;
                    loc1 = location - 20 - (21 * ((Convert.ToDouble(label204.Text) + Convert.ToDouble(label203.Text) + Convert.ToDouble(label202.Text) + Convert.ToDouble(label201.Text) + Convert.ToDouble(label200.Text) + Convert.ToDouble(label199.Text)) * 100 + 40) / 100);
                    int loc = Convert.ToInt32(Math.Round(loc1));
                    pictureBox50.Location = new Point(loc, 220);
                    double locLOs = location - 20 - (21 * ((Convert.ToDouble(label204.Text) + Convert.ToDouble(label203.Text) + Convert.ToDouble(label202.Text) + Convert.ToDouble(label201.Text) + Convert.ToDouble(label200.Text) + Convert.ToDouble(label199.Text) / 2) * 100 + 40)) / 100;
                    int locL = Convert.ToInt32(Math.Round(locLOs));
                    label199.Location = new Point(locL, 195);
                    label207.Location = new Point(loc, 245);

                    if ((i > 0) && (i < 9000))
                    {
                        if ((label189.Text != "") && (Convert.ToInt32(label189.Text) > 1))
                        { pictureBox50.Image = AVGK.Properties.Resources._33777Ч2; }
                        else if (label189.Text != "")
                        { pictureBox50.Image = AVGK.Properties.Resources._33777Ч1; }
                    }
                    else if ((i > 0) && (i > 9000))
                    {
                        if ((label189.Text != "") && (Convert.ToInt32(label189.Text) > 1))
                        { pictureBox50.Image = AVGK.Properties.Resources._33777К2; }
                        else if (label189.Text != "")
                        { pictureBox50.Image = AVGK.Properties.Resources._33777К1; }
                    }
                    pictureBox50.BringToFront();
                    pictureBox50.Visible = true;
                    label199.Visible = true;
                    label207.Visible = true;
                    label189.Visible = false;
                }
                else
                {
                    label199.Visible = false;
                    label207.Visible = false;
                    label189.Visible = false;
                }
            }
            else
            {
                i = 0;
                label199.Visible = false;
                label207.Visible = false;
                label189.Visible = false;
                pictureBox50.Visible = false;
            }
        }
        #endregion   ///////////////////////////////////////
        #region      ////////////////////////////////////////////  ВОСЬМАЯ ОСЬ     ///////////////////////////////////////              
        private void Label206_TextChanged(System.Object sender, System.EventArgs e)// Рисунок первой колесной пары + данные по ней
        {
            string s = Convert.ToString(Convert.ToDouble(label206.Text) * 1000);
            int i = 0;
            if (!(label206.Text == "" || Convert.ToDouble(label206.Text) == 0))
            {
                i = Convert.ToInt32(s);
                if (i > 0)
                {
                    label188.Visible = true;
                    double loc1 = 0;
                    loc1 = location - 20 - (21 * ((Convert.ToDouble(label204.Text) + Convert.ToDouble(label203.Text) + Convert.ToDouble(label202.Text) + Convert.ToDouble(label201.Text) + Convert.ToDouble(label200.Text) + Convert.ToDouble(label199.Text) + Convert.ToDouble(label198.Text)) * 100 + 40) / 100);
                    int loc = Convert.ToInt32(Math.Round(loc1));
                    pictureBox51.Location = new Point(loc, 220);
                    double locLOs = location - 20 - (21 * ((Convert.ToDouble(label204.Text) + Convert.ToDouble(label203.Text) + Convert.ToDouble(label202.Text) + Convert.ToDouble(label201.Text) + Convert.ToDouble(label200.Text) + Convert.ToDouble(label199.Text) + Convert.ToDouble(label198.Text) / 2) * 100 + 40)) / 100;
                    int locL = Convert.ToInt32(Math.Round(locLOs));
                    label198.Location = new Point(locL, 195);
                    label206.Location = new Point(loc, 245);

                    if ((i > 0) && (i < 9000))
                    {
                        if ((label188.Text != "") && (Convert.ToInt32(label188.Text) > 1))
                        { pictureBox51.Image = AVGK.Properties.Resources._33777Ч2; }
                        else if (label188.Text != "")
                        { pictureBox51.Image = AVGK.Properties.Resources._33777Ч1; }
                    }
                    else if ((i > 0) && (i > 9000))
                    {
                        if ((label188.Text != "") && (Convert.ToInt32(label188.Text) > 1))
                        { pictureBox51.Image = AVGK.Properties.Resources._33777К2; }
                        else if (label188.Text != "")
                        { pictureBox51.Image = AVGK.Properties.Resources._33777К1; }
                    }
                    pictureBox51.BringToFront();
                    pictureBox51.Visible = true;
                    label198.Visible = true;
                    label206.Visible = true;
                    label188.Visible = false;
                }
                else
                {
                    label198.Visible = false;
                    label206.Visible = false;
                    label188.Visible = false;
                }
            }
            else
            {
                i = 0;
                label198.Visible = false;
                label206.Visible = false;
                label188.Visible = false;
                pictureBox51.Visible = false;
            }
        }
        #endregion  ///////////////////////////////////////
        #region     ////////////////////////////////////////////////////  ДЕВЯТАЯ ОСЬ ///////////////////////////////
        private void Label205_TextChanged(System.Object sender, System.EventArgs e)// Рисунок первой колесной пары + данные по ней
        {
            string s = Convert.ToString(Convert.ToDouble(label205.Text) * 1000);
            int i = 0;
            if (!(label205.Text == "" || Convert.ToDouble(label205.Text) == 0))
            {
                i = Convert.ToInt32(s);
                if (i > 0)
                {
                    label187.Visible = true;
                    double loc1 = 0;
                    loc1 = location - 40 - (15 * ((Convert.ToDouble(label204.Text) + Convert.ToDouble(label203.Text) + Convert.ToDouble(label202.Text) + Convert.ToDouble(label201.Text) + Convert.ToDouble(label200.Text) + Convert.ToDouble(label199.Text) + Convert.ToDouble(label198.Text) + Convert.ToDouble(label197.Text)) * 100 + 40) / 100);
                    int loc = Convert.ToInt32(Math.Round(loc1));
                    pictureBox52.Location = new Point(loc, 220);
                    double locLOs = location - 40 - (15 * ((Convert.ToDouble(label204.Text) + Convert.ToDouble(label203.Text) + Convert.ToDouble(label202.Text) + Convert.ToDouble(label201.Text) + Convert.ToDouble(label200.Text) + Convert.ToDouble(label199.Text) + Convert.ToDouble(label198.Text) + Convert.ToDouble(label197.Text) / 2) * 100 + 40)) / 100;
                    int locL = Convert.ToInt32(Math.Round(locLOs));
                    label197.Location = new Point(locL, 195);
                    label205.Location = new Point(loc, 245);

                    if ((i > 0) && (i < 9000))
                    {
                        if ((label187.Text != "") && (Convert.ToInt32(label187.Text) > 1))
                        { pictureBox52.Image = AVGK.Properties.Resources._33777Ч2; }
                        else if (label187.Text != "")
                        { pictureBox52.Image = AVGK.Properties.Resources._33777Ч1; }
                    }
                    else if ((i > 0) && (i > 9000))
                    {
                        if ((label187.Text != "") && (Convert.ToInt32(label187.Text) > 1))
                        { pictureBox52.Image = AVGK.Properties.Resources._33777К2; }
                        else if (label187.Text != "")
                        { pictureBox52.Image = AVGK.Properties.Resources._33777К1; }
                    }
                    pictureBox52.BringToFront();
                    pictureBox52.Visible = true;
                    label197.Visible = true;
                    label205.Visible = true;
                    label187.Visible = false;
                }
                else
                {
                    label197.Visible = false;
                    label205.Visible = false;
                    label187.Visible = false;
                }
            }
            else
            {
                i = 0;
                label197.Visible = false;
                label205.Visible = false;
                label187.Visible = false;
                pictureBox52.Visible = false;
            }
        }
        #endregion
        #endregion
        #endregion

        private void pictureBox43_Click(object sender, EventArgs e)//////////////   Открытие детальной информации по клику на фото (ПРАВАЯ)
        {
            if (((strus[7]) != "") && (Convert.ToInt32(strus[7]) > 0))
            {
                if (dataGridView11.Rows.Count != 0)
                {
                    RCR = dataGridView11.CurrentCell.RowIndex;
                }
                this.Cursor = Cursors.WaitCursor;
                FormKartMonit OrdersForm = new FormKartMonit();
                OrdersForm.FormKartMonit_LoadPMonit(Convert.ToInt32(alphaBlendTextBox10.Text), NUs, strus[13]);
                OrdersForm.ShowDialog();
               if (DSR != null)
                    DSR.Clear();
                ZKontrolR("");
                if (dataGridView11.Rows.Count != 0)
                {
                    if (tabControl3.SelectedIndex == 0)
                    {
                        if (toolStripLabel18.Text != "")
                        {
                            kolR = Convert.ToInt32(toolStripLabel18.Text);
                        }
                        dataGridView11.CurrentCell = dataGridView11[0, RCR];
                        rowIndexR = dataGridView11.SelectedCells[0].RowIndex;
                        if (kolR > rowIndexR)
                        {
                            kolR = 0;
                        }
                        int SumR = 0;
                        for (int i = 0; i < dataGridView11.Rows.Count; i++)
                        {
                            SumR = SumR + 1;// (int)dataGridView8.Rows[i].Cells[0].Value;
                        }
                        if (SumR - kolR < SumR)
                        {
                            kolR = SumR - kolR;
                        }
                        currentRowLeft = rowIndexR + kolR;
                        dataGridView11.CurrentCell = dataGridView11[0, rowIndexR + kolR];
                        toolStripLabel18.Text = "" + (Convert.ToInt32(SumR)).ToString();
                    }
                    ////////////////////////////////////////////////////////////////////// И Оформленные
                    if (tabControl3.SelectedIndex == 1)
                    {
                        if (toolStripLabel18.Text != "")
                        {
                            kolR = Convert.ToInt32(toolStripLabel18.Text);
                        }
                        rowIndexR = dataGridView10.SelectedCells[0].RowIndex;
                        if (kolR > rowIndexR)
                        {
                            kolR = 0;
                        }
                        int SumRO = 0;
                        for (int i = 0; i < dataGridView10.Rows.Count; i++)
                        {
                            SumRO = SumRO + 1;// (int)dataGridView8.Rows[i].Cells[0].Value;
                        }
                        if (SumRO - kolR < SumRO)
                        {
                            kolR = SumRO - kolR;
                        }
                        currentRowLeft = rowIndexR + kolR;
                        dataGridView10.CurrentCell = dataGridView10[0, rowIndexR + kolR];
                        toolStripLabel18.Text = "" + (Convert.ToInt32(SumRO)).ToString();
                    }
                    ////////////////////////////////////////////////////////////////////////////////////
                    Otrisovka3();
                }
            }
            else
            {
                MessageBox.Show(" Извините, у Вас нет доступа к карточке проезда.  \n по вопросам доступа обратитесь к администратору", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        } 
        
        #region     Редактирование классов ТС  ///////////////////////////////////////    
        private void dataGridView4_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView4.Rows.Count != 0)
            {
                R1 = 0;
                R1 = dataGridView4.CurrentCell.RowIndex;
            }
            int IDKl = Convert.ToInt32(dataGridView4[0, dataGridView4.CurrentRow.Index].Value.ToString());
            
            FormKlass OrdersForm = new FormKlass();
            OrdersForm.FormKlass_LoadPV(IDKl);
            OrdersForm.ShowDialog();
            DSKL = new DataSet();
            ZagrKlass(0);
           dataGridView4.CurrentCell = dataGridView4[1, R1];
        }
        private void button7_Click(object sender, EventArgs e)///////////////////////////////  Кнопка добавления нового класса ТС
        {
            if (dataGridView4.Rows.Count != 0)
            {
                R1 = 0;
                R1 = dataGridView4.Rows.Count;
            }
            FormKlass OrdersFormKl = new FormKlass();
            OrdersFormKl.ShowDialog();
            DSKL = new DataSet();
            ZagrKlass(0);
            if (R1 > 0)
            { dataGridView4.CurrentCell = dataGridView4[1, R1 - 1]; }
            else if (R1 == 0)
            { dataGridView4.CurrentCell = dataGridView4[1, R1]; }            
        }
        private void button2_Click_1(object sender, EventArgs e)///////////////////////////////  Кнопка редактирования класса ТС
        {
            if (dataGridView4.Rows.Count != 0)
            {
                R1 = 0;
                R1 = dataGridView4.CurrentCell.RowIndex;
            }
            int IDKl = Convert.ToInt32(dataGridView4[0, dataGridView4.CurrentRow.Index].Value.ToString());
            rowIndex = dataGridView4.SelectedCells[0].RowIndex;
            kol = dataGridView4.Rows.Count;
            if (kol > rowIndex)
            { kol = 0; }
            int Sum = 0;
            for (int i = 0; i < dataGridView4.Rows.Count; i++)
            {
                Sum = Sum + 1;
            }
            if (Sum - kol < Sum)
            { kol = Sum - kol; }
            currentRowLeft = rowIndex + kol;
            DataView dvKL;
            dvKL = new DataView(DSKL.Tables[0], "", "", DataViewRowState.CurrentRows);
            dataGridView4.DataSource = dvKL;

            FormKlass OrdersForm = new FormKlass();
            OrdersForm.FormKlass_LoadP(IDKl);
            OrdersForm.ShowDialog();

            DSKL = new DataSet();
            ZagrKlass(0);
           dataGridView4.CurrentCell = dataGridView4[1, rowIndex + kol];
            dataGridView4.CurrentCell = dataGridView4[1, R1];
        }

        private void button10_Click(object sender, EventArgs e)////////////////// Кнопка удаления класса ТС
        {
            if (dataGridView4.Rows.Count != 0)
            {
                R1 = 0;
                R1 = dataGridView4.CurrentCell.RowIndex;
            }
            int IDKl = Convert.ToInt32(dataGridView4[0, dataGridView4.CurrentRow.Index].Value.ToString());
            DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить выбранный Вами класс? \n (Строка будет удалена окончательно без возможности восстановления)", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
            }
            if (result == DialogResult.Yes)
            {
                ConnectStr conStrKl = new ConnectStr();
                Zapros zaprosKl = new Zapros();
                conStrKl.ConStr(1);
                cstrKL = conStrKl.StP;
                MySql.Data.MySqlClient.MySqlConnection sqlConnectionT = new MySql.Data.MySqlClient.MySqlConnection(cstrKL);
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
                cmd.CommandText = "DELETE " +
                        " FROM raptklassts " +
                        "WHERE idklassts = " + IDKl;
                cmd.Connection = sqlConnectionT;
                sqlConnectionT.Open();
                cmd.ExecuteNonQuery();
                sqlConnectionT.Close();
                DSKL = new DataSet();
                ZagrKlass(0);
                if (R1 > 0)
                { dataGridView4.CurrentCell = dataGridView4[1, R1 - 1]; }
                else if (R1 == 0)
                { dataGridView4.CurrentCell = dataGridView4[1, R1]; }
            }
        }
        #endregion
        #region     Редактирование расположения рубежа  ///////////////////////////////////////
        private void button14_Click(object sender, EventArgs e)/////////////////////////// Кнопка добавления расположения рубежа на а/д
        {
            if (raspolojenRubejaDataGridView.Rows.Count != 0)
            {
                R1 = 0;
                R1 = raspolojenRubejaDataGridView.Rows.Count;
            }
            FormRaspolRub OrdersFormRRub = new FormRaspolRub();
            OrdersFormRRub.ShowDialog();
            DSRUB = new DataSet();
            ZagrRUB(0);
            DSNAPR = new DataSet();
            ZagrNAPR(0);
            if (R1 > 0)
            { raspolojenRubejaDataGridView.CurrentCell = raspolojenRubejaDataGridView[1, R1 - 1]; }
            else if (R1 == 0)
            { raspolojenRubejaDataGridView.CurrentCell = raspolojenRubejaDataGridView[1, R1]; }
        }

        private void button13_Click(object sender, EventArgs e)///////////////////   Редактирование рубежа и направления движения
        {
            if (raspolojenRubejaDataGridView.Rows.Count != 0)
            {
                R1 = 0;
                R1 = raspolojenRubejaDataGridView.CurrentCell.RowIndex;
            }
            int IDRub = Convert.ToInt32(raspolojenRubejaDataGridView[0, raspolojenRubejaDataGridView.CurrentRow.Index].Value.ToString());
            FormRaspolRub OrdersFormRRub = new FormRaspolRub();
            OrdersFormRRub.FormRaspolRub_LoadRN(IDRub);
            OrdersFormRRub.ShowDialog();
            DSRUB = new DataSet();
            ZagrRUB(0);
            raspolojenRubejaDataGridView.CurrentCell = raspolojenRubejaDataGridView[1, R1];
            if (DSNAPR != null)
            {
                rowNumR = raspolojenRubejaDataGridView.CurrentRow.Index;
                IDNAPR = Convert.ToInt32(raspolojenRubejaDataGridView[0, rowNumR].Value);
                DSNAPR = new DataSet();
                ZagrNAPR(IDNAPR);
            }
            raspolojenRubejaDataGridView.CurrentCell = raspolojenRubejaDataGridView[1, R1];
        }

        private void button12_Click(object sender, EventArgs e)///////////////////   Кнопка удаления рубежа и направления движения
        {
            if (raspolojenRubejaDataGridView.Rows.Count != 0)
            {
                R1 = 0;
                R1 = raspolojenRubejaDataGridView.CurrentCell.RowIndex;
            }
            int rowNumR;
            rowNumR = raspolojenRubejaDataGridView.CurrentRow.Index;
            int IDNAPR = Convert.ToInt32(raspolojenRubejaDataGridView[0, rowNumR].Value);
            DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить выбранный Вами комплекс? \n (Строки будут удалены окончательно без возможности восстановления)", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
            }
            if (result == DialogResult.Yes)
            {
                ConnectStr conStrKl = new ConnectStr();
                Zapros zaprosKl = new Zapros();
                conStrKl.ConStr(1);
                cstrKL = conStrKl.StP;
                MySql.Data.MySqlClient.MySqlConnection sqlConnectionT = new MySql.Data.MySqlClient.MySqlConnection(cstrKL);
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
                cmd.CommandText = "DELETE " +
                        " FROM rapraspolojenrubeja " +
                        "WHERE idrub = " + IDNAPR;
                cmd.Connection = sqlConnectionT;
                sqlConnectionT.Open();
                cmd.ExecuteNonQuery();
                sqlConnectionT.Close();

                ConnectStr conStrKl1 = new ConnectStr();
                Zapros zaprosKl1 = new Zapros();
                conStrKl1.ConStr(1);
                cstrKL1 = conStrKl1.StP;
                MySql.Data.MySqlClient.MySqlConnection sqlConnection1 = new MySql.Data.MySqlClient.MySqlConnection(cstrKL1);
                MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand();
                cmd1.CommandText = "DELETE " +
                        " FROM raptnapr " +
                        "WHERE IDKOMPL = " + IDNAPR;
                cmd1.Connection = sqlConnection1;
                sqlConnection1.Open();
                cmd1.ExecuteNonQuery();
                sqlConnection1.Close();

                if (DSRUB != null)
                    DSRUB = new DataSet();
                ZagrRUB(0);

                if (R1 > 0)
                { raspolojenRubejaDataGridView.CurrentCell = raspolojenRubejaDataGridView[1, R1 - 1]; }
                else if (R1 == 0)
                { raspolojenRubejaDataGridView.CurrentCell = raspolojenRubejaDataGridView[1, R1]; }

                if (DSNAPR != null)
                {
                    rowNumR = raspolojenRubejaDataGridView.CurrentRow.Index;
                    /*int*/ IDNAPR = Convert.ToInt32(raspolojenRubejaDataGridView[0, rowNumR].Value);
                    DSNAPR = new DataSet();               
                ZagrNAPR(IDNAPR);
                }                
            }
        }
  private void raspolojenRubejaDataGridView_DoubleClick(object sender, EventArgs e) //// двойной клик на таблице рубежа
        {
            if (raspolojenRubejaDataGridView.Rows.Count != 0)
            {
                R1 = 0;
                R1 = raspolojenRubejaDataGridView.CurrentCell.RowIndex;
            }
            int IDRub = Convert.ToInt32(raspolojenRubejaDataGridView[0, raspolojenRubejaDataGridView.CurrentRow.Index].Value.ToString());
            FormRaspolRub OrdersFormRRub = new FormRaspolRub();
            OrdersFormRRub.FormRaspolRub_LoadRNV(IDRub);
            OrdersFormRRub.ShowDialog();
            DSRUB = new DataSet();
            ZagrRUB(0);
            raspolojenRubejaDataGridView.CurrentCell = raspolojenRubejaDataGridView[1, R1];
            int rowNumR;
            rowNumR = raspolojenRubejaDataGridView.CurrentRow.Index;
            int IDNAPR = Convert.ToInt32(raspolojenRubejaDataGridView[0, rowNumR].Value);
            DSNAPR = new DataSet();
            ZagrNAPR(IDNAPR);
            raspolojenRubejaDataGridView.CurrentCell = raspolojenRubejaDataGridView[1, R1];
        }

        #endregion  ///////////////////////////////////////////////////////////////////////////////////////////
       
        private void fillByFiltrF2ToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
        private void fillByFiltrF2ToolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
       
        private void button15_Click(object sender, EventArgs e)/////////////    Кнопка фильтра правого
        {
            timer3.Enabled = false;
            StopSearchR();
        }

        private void button11_Click(object sender, EventArgs e)/////////////    Кнопка фильтра левого
        {
            if (dataGridView8.RowCount > 0)
            {
                dataGridView8.CurrentCell = dataGridView8[1, 0];
            }
            checkBox9.Checked = false;
            timer1.Enabled = false;
            StopSearch();
        }

        private void dateTimePicker2_MouseDown(object sender, MouseEventArgs e)
        {
            checkBox9.Checked = false;
        }

        #region    /////////////////////////////////////////////////////////////////////////// М О Н И Т О Р И Н Г  ///////////////


        #region          Общая скобка по весу и длине + направление движения   ///////////////////////////////////////
        private void label47_TextChanged(System.Object sender, System.EventArgs e)//Общая скобка по весу и длине + направление движения
        {
            pictureBox11.Visible = false;
            pictureBox10.Visible = false;
            pictureBox9.Visible = false;
            pictureBox8.Visible = false;
            pictureBox7.Visible = false;
            pictureBox6.Visible = false;
            pictureBox5.Visible = false;
            pictureBox4.Visible = false;
            pictureBox3.Visible = false;
            pictureBox13.Visible = false;//скобка
            pictureBox1.Visible = false;//стрелка
            label47.Visible = false;//надпись общ.длина
            label37.Visible = false;//надпись общ.масса
            string s = label47.Text;
            double i;
            if (label47.Text != "")
                i = Convert.ToDouble(s);//Convert.ToInt32(znachenie); 
            else i = 0;
            if (i > 0)
            {
                double loc2 = 0;
                string TO1;
                TO1 = "Общая длина ТС - " + Convert.ToDouble(s) + " м. " + "\n" + "Общий вес: " + Convert.ToDouble(label37.Text) + " т. ";
                loc2 = 24 * i + 130;
                int loc3 = Convert.ToInt32(loc2);
                pictureBox13.Width = loc3 - 90;
                int newloc = 307 + loc3 / 2;
                pictureBox13.Location = new Point(10 + 240, 258);
                double loc = Convert.ToDouble(label47.Text) * 100;
                location = 180 + Convert.ToInt32(24 * loc / 100);
                pictureBox1.Location = new Point(Convert.ToInt32(loc2) + 170, 225);
                pictureBox1.Visible = true;
                label70.Text = TO1;
                label70.Location = new Point((location / 2 + 135), 285);
                label70.BackColor = Color.Transparent;
                pictureBox13.Visible = true;
                label70.Visible = true;
                pictureBox1.Visible = true;
            }
        }
        #endregion
        #region     Рисунки колесных пар   ///////////////////////////////////////
        private void Label69_TextChanged(System.Object sender, System.EventArgs e)// Рисунок первой колесной пары + данные по ней
        {
            string s = Convert.ToString(Convert.ToDouble(label69.Text) * 1000);
            label46.Visible = true;
            label55.Visible = true;
            int i;
            if (label55.Text != "")
            { i = Convert.ToInt32(s); }//Convert.ToInt32(znachenie); 
            else i = 0;
            if (i > 0)
            {
                double loc = Convert.ToDouble(label47.Text) * 100;
                location = 265 + Convert.ToInt32(24 * loc / 100);
                pictureBox3.Location = new Point(location, 223);
                pictureBox3.Image = AVGK.Properties.Resources._33777Ч1;
                label69.Location = new Point(location, 246);
                pictureBox3.BringToFront();
                pictureBox3.Visible = true;
                label55.Visible = true;
                label69.Visible = true;
                label46.Visible = false;
            }
            else
            {
                label55.Visible = false;
                label69.Visible = false;
                label46.Visible = false;
            }
        }

        private void label68_TextChanged(System.Object sender, System.EventArgs e)// Рисунок второй колесной пары + данные по ней
        {
            string s = Convert.ToString(Convert.ToDouble(label68.Text) * 1000);
            int i;
            if (label68.Text != "")
            {
                label45.Visible = true;
                i = Convert.ToInt32(s);//Convert.ToInt32(znachenie);
                if (i > 0)
                {
                    double loc1 = 0;
                    loc1 = location - (26 * (Convert.ToDouble(label55.Text) * 100) / 100);
                    int loc = Convert.ToInt32(Math.Round(loc1));
                    pictureBox4.Location = new Point(loc, 223);
                    double locLOs = location - (26 * ((Convert.ToDouble(label55.Text) / 2)) * 100) / 100;// + 32;
                    int locL = Convert.ToInt32(Math.Round(locLOs));
                    label55.Location = new Point(locL, 200);
                    label68.Location = new Point(loc, 246);
                    pictureBox6.BringToFront();
                    pictureBox4.Visible = true;
                    label55.Visible = true;
                    label68.Visible = true;
                    label45.Visible = false;
                }
                else
                {
                    label55.Visible = false;
                    label68.Visible = false;
                    label45.Visible = false;
                }
            }
            else
            {
                i = 0;
                label55.Visible = false;
                label68.Visible = false;
                pictureBox4.Visible = false;
            }
        }
        private void label66_TextChanged(System.Object sender, System.EventArgs e)// Рисунок третьей колесной пары + данные по ней
        {
            string s = Convert.ToString(Convert.ToDouble(label66.Text) * 1000);
            int i;
            if (label66.Text != "")
            {
                i = Convert.ToInt32(s);
                if (i > 0)
                {
                    label44.Visible = true;
                    double loc1 = 0;
                    loc1 = location - (26 * ((Convert.ToDouble(label55.Text) + Convert.ToDouble(label54.Text)) * 100) / 100);
                    int loc = Convert.ToInt32(Math.Round(loc1));
                    pictureBox5.Location = new Point(loc, 223);
                    double locLOs = location - (26 * ((Convert.ToDouble(label55.Text) + Convert.ToDouble(label54.Text) / 2)) * 100) / 100;// + 32;
                    int locL = Convert.ToInt32(Math.Round(locLOs));
                    label54.Location = new Point(locL, 200);

                    label66.Location = new Point(loc, 246);
                    pictureBox5.BringToFront();
                    pictureBox5.Visible = true;
                    label54.Visible = true;
                    label66.Visible = true;
                    label44.Visible = false;
                }
                else
                {
                    label54.Visible = false;
                    label66.Visible = false;
                    label44.Visible = false;
                }
            }
            else
            {
                i = 0;
                label54.Visible = false;
                label66.Visible = false;
                pictureBox5.Visible = false;
            }
        }
        private void label65_TextChanged(System.Object sender, System.EventArgs e)// Рисунок четвертой колесной пары + данные по ней
        {
            string s = Convert.ToString(Convert.ToDouble(label65.Text) * 1000);
            int i;
            if (label65.Text != "")
            {
                label43.Visible = true;
                i = Convert.ToInt32(s);//Convert.ToInt32(znachenie);
                if (i > 0)
                {
                    double loc1 = 0;
                    loc1 = location - (26 * ((Convert.ToDouble(label55.Text) + Convert.ToDouble(label54.Text) + Convert.ToDouble(label53.Text)) * 100) / 100);
                    int loc = Convert.ToInt32(Math.Round(loc1));
                    pictureBox6.Location = new Point(loc, 223);
                    double locLOs = location - (26 * ((Convert.ToDouble(label55.Text) + Convert.ToDouble(label54.Text) + Convert.ToDouble(label53.Text) / 2)) * 100) / 100;// + 32;
                    int locL = Convert.ToInt32(Math.Round(locLOs));
                    label53.Location = new Point(locL, 200);
                    label65.Location = new Point(loc, 246);
                    pictureBox6.Visible = true;
                    label53.Visible = true;
                    label65.Visible = true;
                    label43.Visible = false;
                }
                else
                {
                    label53.Visible = false;
                    label65.Visible = false;
                    label43.Visible = false;
                }
            }
            else
            {
                i = 0;
                label53.Visible = false;
                label65.Visible = false;
                pictureBox6.Visible = false;
            }
        }
        private void label64_TextChanged(System.Object sender, System.EventArgs e)// Рисунок пятой колесной пары + данные по ней
        {
            label42.Visible = true;
            string s = Convert.ToString(Convert.ToDouble(label64.Text) * 1000);
            int i;
            if (label64.Text != "")
            {
                i = Convert.ToInt32(s);
                if (i > 0)
                {
                    double loc1 = 0;
                    loc1 = location - (26 * ((Convert.ToDouble(label55.Text) + Convert.ToDouble(label54.Text) + Convert.ToDouble(label53.Text) + Convert.ToDouble(label52.Text)) * 100) / 100);
                    int loc = Convert.ToInt32(Math.Round(loc1));
                    pictureBox7.Location = new Point(loc, 223);
                    double locLOs = location - (26 * ((Convert.ToDouble(label55.Text) + Convert.ToDouble(label54.Text) + Convert.ToDouble(label53.Text) + Convert.ToDouble(label52.Text) / 2)) * 100) / 100;// + 32;
                    int locL = Convert.ToInt32(Math.Round(locLOs));
                    label52.Location = new Point(locL, 200);
                    label64.Location = new Point(loc, 246);
                    pictureBox7.Visible = true;
                    label52.Visible = true;
                    label64.Visible = true;
                    label42.Visible = false;
                }
                else
                {
                    label52.Visible = false;
                    label64.Visible = false;
                    label42.Visible = false;
                }
            }
            else
            {
                i = 0;
                label52.Visible = false;
                label64.Visible = false;
                pictureBox7.Visible = false;
            }
        }
        private void label63_TextChanged(System.Object sender, System.EventArgs e)// Рисунок шестой колесной пары + данные по ней
        {
            label41.Visible = true;
            string s = Convert.ToString(Convert.ToDouble(label63.Text) * 1000);
            int i;
            if (label63.Text != "")
            {
                i = Convert.ToInt32(s);
                if (i > 0)
                {
                    double loc1 = 0;
                    loc1 = location - (26 * ((Convert.ToDouble(label55.Text) + Convert.ToDouble(label54.Text) + Convert.ToDouble(label53.Text) + Convert.ToDouble(label52.Text) + Convert.ToDouble(label51.Text)) * 100) / 100);
                    int loc = Convert.ToInt32(Math.Round(loc1));
                    pictureBox8.Location = new Point(loc, 223);
                    double locLOs = location - (26 * ((Convert.ToDouble(label55.Text) + Convert.ToDouble(label54.Text) + Convert.ToDouble(label53.Text) + Convert.ToDouble(label52.Text) + Convert.ToDouble(label51.Text) / 2)) * 100) / 100;// + 32;
                    int locL = Convert.ToInt32(Math.Round(locLOs));
                    label51.Location = new Point(locL, 200);
                    label63.Location = new Point(loc, 246);
                    pictureBox8.Visible = true;
                    label51.Visible = true;
                    label63.Visible = true;
                    label41.Visible = false;
                }
                else
                {
                    label51.Visible = false;
                    label63.Visible = false;
                    label41.Visible = false;
                }
            }
            else
            {
                i = 0;
                label51.Visible = false;
                label63.Visible = false;
                pictureBox8.Visible = false;
            }
        }
        private void Label58_TextChanged(System.Object sender, System.EventArgs e)// Рисунок седьмой колесной пары + данные по ней
        {
            label40.Visible = true;
            string s = Convert.ToString(Convert.ToDouble(label58.Text) * 1000);
            int i;
            if (label58.Text != "")
            {
                i = Convert.ToInt32(s);
                if (i > 0)
                {
                    double loc1 = 0;
                    loc1 = location - (26 * ((Convert.ToDouble(label55.Text) + Convert.ToDouble(label54.Text) + Convert.ToDouble(label53.Text) + Convert.ToDouble(label52.Text) + Convert.ToDouble(label51.Text) + Convert.ToDouble(label50.Text)) * 100) / 100);
                    int loc = Convert.ToInt32(Math.Round(loc1));
                    pictureBox9.Location = new Point(loc, 223);
                    double locLOs = location - (26 * ((Convert.ToDouble(label55.Text) + Convert.ToDouble(label54.Text) + Convert.ToDouble(label53.Text) + Convert.ToDouble(label52.Text) + Convert.ToDouble(label51.Text) + Convert.ToDouble(label50.Text) / 2)) * 100) / 100;// + 32;
                    int locL = Convert.ToInt32(Math.Round(locLOs));
                    label50.Location = new Point(locL, 200);
                    label58.Location = new Point(loc, 246);
                    pictureBox9.Visible = true;
                    label50.Visible = true;
                    label58.Visible = true;
                    label40.Visible = false;
                }
                else
                {
                    label50.Visible = false;
                    label58.Visible = false;
                    label40.Visible = false;
                }
            }
            else
            {
                i = 0;
                label50.Visible = false;
                label58.Visible = false;
                pictureBox9.Visible = false;
            }
        }
        private void Label57_TextChanged(System.Object sender, System.EventArgs e)// Рисунок восьмой колесной пары + данные по ней
        {
            label39.Visible = true;
            string s = Convert.ToString(Convert.ToDouble(label57.Text) * 1000);
            int i;
            if (label57.Text != "")
            {
                i = Convert.ToInt32(s);
                if (i > 0)
                {
                    double loc1 = 0;
                    loc1 = location - (26 * ((Convert.ToDouble(label55.Text) + Convert.ToDouble(label54.Text) + Convert.ToDouble(label53.Text) + Convert.ToDouble(label52.Text) + Convert.ToDouble(label51.Text) + Convert.ToDouble(label50.Text) + Convert.ToDouble(label49.Text)) * 100) / 100);
                    int loc = Convert.ToInt32(Math.Round(loc1));
                    pictureBox10.Location = new Point(loc, 223);
                    widh = loc1 - 193;
                    double locLOs = location - (26 * ((Convert.ToDouble(label55.Text) + Convert.ToDouble(label54.Text) + Convert.ToDouble(label53.Text) + Convert.ToDouble(label52.Text) + Convert.ToDouble(label51.Text) + Convert.ToDouble(label50.Text) + Convert.ToDouble(label49.Text) / 2)) * 100) / 100;// + 32;
                    int locL = Convert.ToInt32(Math.Round(locLOs));
                    label49.Location = new Point(locL, 200);
                    label57.Location = new Point(loc, 246);
                    pictureBox10.Visible = true;
                    label49.Visible = true;
                    label57.Visible = true;
                    label39.Visible = false;
                }
                else
                {
                    label49.Visible = false;
                    label57.Visible = false;
                    label39.Visible = false;
                }
            }
            else
            {
                i = 0;
                label49.Visible = false;
                label57.Visible = false;
                pictureBox10.Visible = false;
            }
        }
        private void Label56_TextChanged(System.Object sender, System.EventArgs e)// Рисунок девятой колесной пары + данные по ней
        {
            label38.Visible = true;
            string s = Convert.ToString(Convert.ToDouble(label56.Text) * 1000);
            int i;
            if (label56.Text != "")
            {
                i = Convert.ToInt32(s);
                if (i > 0)
                {
                    double loc1 = 0;
                    loc1 = location - (26 * ((Convert.ToDouble(label55.Text) + Convert.ToDouble(label54.Text) + Convert.ToDouble(label53.Text) + Convert.ToDouble(label52.Text) + Convert.ToDouble(label51.Text) + Convert.ToDouble(label50.Text) + Convert.ToDouble(label49.Text) + Convert.ToDouble(label48.Text)) * 100) / 100);
                    int loc = Convert.ToInt32(Math.Round(loc1));
                    pictureBox11.Location = new Point(loc, 223);
                    widh = loc1 - 193;
                    double locLOs = location - (26 * ((Convert.ToDouble(label55.Text) + Convert.ToDouble(label54.Text) + Convert.ToDouble(label53.Text) + Convert.ToDouble(label52.Text) + Convert.ToDouble(label51.Text) + Convert.ToDouble(label50.Text) + Convert.ToDouble(label49.Text) + Convert.ToDouble(label48.Text) / 2)) * 100) / 100;// + 32;
                    int locL = Convert.ToInt32(Math.Round(locLOs));
                    label48.Location = new Point(locL, 200);
                    label56.Location = new Point(loc, 246);
                    pictureBox11.BringToFront();
                    pictureBox11.Visible = true;
                    label48.Visible = true;
                    label56.Visible = true;
                    label38.Visible = false;
                }
                else
                {
                    label48.Visible = false;
                    label56.Visible = false;
                    label38.Visible = false;
                }
            }
            else
            {
                i = 0;
                label48.Visible = false;
                label56.Visible = false;
                pictureBox11.Visible = false;
            }
        }
        #endregion

        #endregion /////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void dataGridView9_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
           label126.Visible = false;
             label119.Visible = true;            
            int currentRow = dataGridView9.CurrentRow.Index; // номер строки, по которой кликнули
            alphaBlendTextBox11.Text = "0";
            alphaBlendTextBox11.Text = dataGridView9[0, currentRow].Value.ToString();
            alphaBlendTextBox16.Text = dataGridView9[2, currentRow].Value.ToString();
            alphaBlendTextBox19.Text = dataGridView9[1, currentRow].Value.ToString().Substring(0, 10);
            int aaa = Convert.ToInt32(dataGridView9[0, currentRow].Value);
            alphaBlendTextBox40.Text = "";
            Osh = 0;
            if (Convert.ToDouble(dataGridView9[4, currentRow].Value) == 0 || Convert.ToDouble(dataGridView9[6, currentRow].Value) == 0 || Convert.ToDouble(dataGridView9[7, currentRow].Value) == 0)
            {
                label126.Visible = true;
                label119.Visible = false;
            }
                TSh = "";
            ZagrdataGridView9(Convert.ToInt32(alphaBlendTextBox11.Text));
            //// перевод ошибок...........           
            string Oshib = Convert.ToString(Osh, 2);
            if (Oshib != "0" && Oshib.Length>9)
            {
                alphaBlendTextBox40.Text = alphaBlendTextBox40.Text.ToString() + "Ошибка на измерительном комплексе: ";
            if (Oshib.Substring(Oshib.Length - 1) != "0")
                    { alphaBlendTextBox40.Text = alphaBlendTextBox40.Text.ToString() + " -не все данные были получены от датчиков;";  }
            if (Convert.ToInt64(Oshib.Substring(Oshib.Length - 2)) > 9)
                    { alphaBlendTextBox40.Text = alphaBlendTextBox40.Text.ToString() + " -неравномерное движение ТС;"; }
            if (Convert.ToInt64(Oshib.Substring(Oshib.Length - 3)) > 99)
                    {  alphaBlendTextBox40.Text = alphaBlendTextBox40.Text.ToString() + " -размеры ТС выходит за допустимые пределы измерения;";  }
                if (Convert.ToInt64(Oshib.Substring(Oshib.Length - 4)) >999)
                { alphaBlendTextBox40.Text = alphaBlendTextBox40.Text.ToString() + " -нагрузка на ось выходит за пределы измерения;"; }
                if (Convert.ToInt64(Oshib.Substring(Oshib.Length - 5)) > 9999)
                { alphaBlendTextBox40.Text = alphaBlendTextBox40.Text.ToString() + " -ошибка определения количества осей;"; }
                if (Convert.ToInt64(Oshib.Substring(Oshib.Length - 6)) > 99999)
                { alphaBlendTextBox40.Text = alphaBlendTextBox40.Text.ToString() + " -ошибка измерения межосевого расстояния;"; }
                if (Convert.ToInt64(Oshib.Substring(Oshib.Length - 7)) > 999999)
                { alphaBlendTextBox40.Text = alphaBlendTextBox40.Text.ToString() + " -ошибка измерения длины ТС;"; }
                if (Convert.ToInt64(Oshib.Substring(Oshib.Length - 8)) > 9999999)
                { alphaBlendTextBox40.Text = alphaBlendTextBox40.Text.ToString() + " -скорость ТС выходит за допустимые пределы измерения;"; }
            }
            else if (Oshib != "0" && Oshib.Length < 9)
            {
                alphaBlendTextBox40.Text = alphaBlendTextBox40.Text.ToString() + "Ошибка на измерительном комплексе ";
            }
            if (dataGridView9[8, currentRow].Value.ToString()== "")
            {
                alphaBlendTextBox40.Text = alphaBlendTextBox40.Text.ToString() + " Не распознан ГРЗ ТС";
            } 
                    ////.........................
            if (Convert.ToInt32(dataGridView9[17, currentRow].Value.ToString())==0)
            {
                if (Convert.ToInt32(dataGridView9[19, currentRow].Value.ToString()) > 0)
                { alphaBlendTextBox41.Text = "Проверка не проводилась (ошибка измерений на комплексе)"; }
                else if (dataGridView9[8, currentRow].Value.ToString() == "" && (Convert.ToBoolean(dataGridView9[10, currentRow].Value.ToString()) == true || Convert.ToBoolean(dataGridView9[11, currentRow].Value.ToString()) == true || Convert.ToBoolean(dataGridView9[12, currentRow].Value.ToString()) == true || Convert.ToBoolean(dataGridView9[14, currentRow].Value.ToString()) == true))
                {
                    alphaBlendTextBox41.Text = "Проверка не проводилась (не распознан ГРЗ ТС)";
                }
                else
                { alphaBlendTextBox41.Text = "Проверка не проводилась"; }
            }
            else if (Convert.ToInt32(dataGridView9[17, currentRow].Value.ToString()) == 14 || Convert.ToInt32(dataGridView9[17, currentRow].Value.ToString()) == 17)
            {
                //alphaBlendTextBox41.Text = dataGridView9[17, currentRow].Value.ToString();
            }
            else if (Convert.ToInt32(dataGridView9[17, currentRow].Value.ToString()) == 4 )
            {
                if (Convert.ToInt32(dataGridView9[19, currentRow].Value.ToString().Substring(6,1))==1)
                { alphaBlendTextBox41.Text = "Выявлено нарушение (превышение нагрузки на ось)"; }
                else if (Convert.ToInt32(dataGridView9[19, currentRow].Value.ToString().Substring(6, 1)) == 2)
                { alphaBlendTextBox41.Text = "Выявлено нарушение (превышение нагрузки на группу осей)"; }
                else if (Convert.ToInt32(dataGridView9[19, currentRow].Value.ToString().Substring(6, 1)) == 3)
                { alphaBlendTextBox41.Text = "Выявлено нарушение (превышение общей массы)"; }
                else if (Convert.ToInt32(dataGridView9[19, currentRow].Value.ToString().Substring(6, 1)) == 4)
                { alphaBlendTextBox41.Text = "Выявлено нарушение (превышение длины)"; }                
            }
            else if (Convert.ToInt32(dataGridView9[17, currentRow].Value.ToString()) == 20)
            { alphaBlendTextBox41.Text = "Проверка не была завершена (отсутствие связи с СВСР)"; }
            else if (Convert.ToInt32(dataGridView9[17, currentRow].Value.ToString()) == 1)
            { alphaBlendTextBox41.Text = "Проверка не была завершена (ошибка данных)"; }
           int i1 = 0;
            int i2 = 0;
            int cnt = 0;
            TipoS = "";
            for (i1 = 0; i1 < 9; i1++)
            {
                if (i1 > 0)
                {
                    if (KN[0, i1] != KN[0, i1 - 1])
                    {
                        KN[1, i1 - 1] = cnt;
                        cnt = 0;
                    }
                }
                cnt = cnt + 1;
            }
            for (i1 = 0; i1 < 9; i1++)
            {
                if (KN[1, i1] > 0)
                {
                    TipoS = TipoS + KN[1, i1].ToString() + "+";
                }
            }
            if (TipoS != "")
            {
                TipoS = TipoS.Remove(TipoS.Length - 1, 1);
            }
            alphaBlendTextBox13.Text = TipoS;

        }
        #region /////////////////////////////////////////////// Запрос класса ТС
        public void ZKL()
        {
            if (KolOs == 0 || ObshMass == 0)
            {
                alphaBlendTextBox14.Text = "Ошибка измерений, определение невозможно";
                alphaBlendTextBox17.Text = "Не определен";
            }
            else if (KolOs > 8)
            {
                alphaBlendTextBox14.Text = "Прочие нестандартные АТС (Сельхоз, строительная и прочая техника)";
                alphaBlendTextBox17.Text = "12";
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
                        FFF = reader2["naimklassts"].ToString();
                        FF = reader2["tipschema"].ToString();
                        alphaBlendTextBox14.Text = FFF + ", схема**: " + FF;
                        alphaBlendTextBox17.Text = reader2["Kategory"].ToString();
                        if (reader2["tipschema"].ToString().Length == 1)
                        { TTS = 1; }
                        else if (reader2["tipschema"].ToString().Length > 1)
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
                }
                //ZPHOTOPR();
            }
        }
        #endregion ///////////////////////////////////////////////
        #region/////////////////////////////////////////////   загрузка всех параметров проезда для МОНИТОРИНГА //////////////////  
        public void ZagrdataGridView9(int IDp)
        {
            MySqlCommand commandNSR = new MySqlCommand();
            ConnectStr conStrNSR = new ConnectStr();
            conStrNSR.ConStr(1);
            Zapros zaprosNSR = new Zapros();
            string connectionStringNSR;
            connectionStringNSR = conStrNSR.StP;//"Data source=localhost;UserId=root;Password=1q2w3e$R;database=camloc;";
            MySqlConnection connectionNSR = new MySqlConnection(connectionStringNSR);
            zaprosNSR.PrNalSR(IDp);
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

            MySqlCommand commandL = new MySqlCommand();
            ConnectStr conStrL = new ConnectStr();
            conStrL.ConStr(1);
            Zapros zaprosL = new Zapros();
            string connectionStringL;//, commandString;
            connectionStringL = conStrL.StP;//"Data source=localhost;UserId=root;Password=1q2w3e$R;database=camloc;";
            MySqlConnection connectionL = new MySqlConnection(connectionStringL);
            zaprosL.ZaprAllCamNaprLO(IDp, NSR);
            zL = zaprosL.commandStringTest;
            commandL.CommandText = zL;// commandString;
            commandL.Connection = connectionL;
            MySqlDataReader readerL;
            int NumberIter = 0;
            label55.Text = "0"; label54.Text = "0"; label53.Text = "0"; label52.Text = "0";
            label51.Text = "0"; label50.Text = "0"; label49.Text = "0"; label48.Text = "0";

            label46.Text = "0"; label45.Text = "0"; label44.Text = "0"; label43.Text = "0";
            label42.Text = "0"; label41.Text = "0"; label40.Text = "0"; label39.Text = "0";
            label38.Text = "0";
            label37.Text = "0";
            label47.Text = "0";
            label69.Text = "0"; label68.Text = "0"; label66.Text = "0"; label65.Text = "0";
            label64.Text = "0"; label63.Text = "0"; label58.Text = "0"; label57.Text = "0";
            label56.Text = "0";

            KN = new int[2, 9];
            int i1 = 0;
            try
            {
                commandL.Connection.Open();
                readerL = commandL.ExecuteReader();
                double pos = 0;
                while (readerL.Read())
                {
                    Osh = Convert.ToInt32(readerL["CredenceExceeded"].ToString());

                    label37.Text = Convert.ToString(Convert.ToDouble(readerL["Weight"]) / 1000);
                    label47.Text = Convert.ToString(Convert.ToDouble(readerL["Length"]) / 100);
                    if (readerL["CheckSumIsch"].ToString() != readerL["CheckSum"].ToString())
                    {
                        string C1 = readerL["CheckSumIsch"].ToString();
                        string C2 = readerL["CheckSum"].ToString();
                        pictureBox15.Visible=true /*label232.Visible = true*/; }
                    else { pictureBox15.Visible = false /*label232.Visible = false*/; }
                    if (NumberIter == 0)
                    {
                        string i = Convert.ToString(Convert.ToInt32(readerL["wheelCount"]) / 2);
                        label46.Text = i;//Convert.ToString(Convert.ToInt32(readerL["wheelCount"]) / 2);
                        string ii = Convert.ToString(Convert.ToDouble(readerL["weightAxel"]) / 1000);
                        label69.Text = ii;//Convert.ToString(Convert.ToDouble(readerL["weightAxel"]) / 1000);
                    }
                    if (NumberIter == 1)
                    {
                        label45.Text = Convert.ToString(Convert.ToInt32(readerL["wheelCount"]) / 2);
                        label55.Text = Convert.ToString((Convert.ToDouble(readerL["position"]) / 100) - pos);
                        pos = Convert.ToDouble(readerL["position"]) / 100;
                        label68.Text = Convert.ToString(Convert.ToDouble(readerL["weightAxel"]) / 1000);
                    }
                    if (NumberIter == 2)
                    {
                        label44.Text = Convert.ToString(Convert.ToInt32(readerL["wheelCount"]) / 2);
                        label54.Text = Convert.ToString((Convert.ToDouble(readerL["position"]) / 100) - pos);
                        pos = Convert.ToDouble(readerL["position"]) / 100;
                        label66.Text = Convert.ToString(Convert.ToDouble(readerL["weightAxel"]) / 1000);
                    }
                    if (NumberIter == 3)
                    {
                        label43.Text = Convert.ToString(Convert.ToInt32(readerL["wheelCount"]) / 2);
                        label53.Text = Convert.ToString((Convert.ToDouble(readerL["position"]) / 100) - pos);
                        pos = Convert.ToDouble(readerL["position"]) / 100;
                        label65.Text = Convert.ToString(Convert.ToDouble(readerL["weightAxel"]) / 1000);
                    }
                    if (NumberIter == 4)
                    {
                        label42.Text = Convert.ToString(Convert.ToInt32(readerL["wheelCount"]) / 2);
                        label52.Text = Convert.ToString((Convert.ToDouble(readerL["position"]) / 100) - pos);
                        pos = Convert.ToDouble(readerL["position"]) / 100;
                        label64.Text = Convert.ToString(Convert.ToDouble(readerL["weightAxel"]) / 1000);
                    }
                    if (NumberIter == 5)
                    {
                        label41.Text = Convert.ToString(Convert.ToInt32(readerL["wheelCount"]) / 2);
                        label51.Text = Convert.ToString((Convert.ToDouble(readerL["position"]) / 100) - pos);
                        pos = Convert.ToDouble(readerL["position"]) / 100;
                        label63.Text = Convert.ToString(Convert.ToDouble(readerL["weightAxel"]) / 1000);
                    }
                    if (NumberIter == 6)
                    {
                        label40.Text = Convert.ToString(Convert.ToInt32(readerL["wheelCount"]) / 2);
                        label50.Text = Convert.ToString((Convert.ToDouble(readerL["position"]) / 100) - pos);
                        pos = Convert.ToDouble(readerL["position"]) / 100;
                        label58.Text = Convert.ToString(Convert.ToDouble(readerL["weightAxel"]) / 1000);
                    }
                    if (NumberIter == 7)
                    {
                        label39.Text = Convert.ToString(Convert.ToInt32(readerL["wheelCount"]) / 2);
                        label49.Text = Convert.ToString((Convert.ToDouble(readerL["position"]) / 100) - pos);
                        pos = Convert.ToDouble(readerL["position"]) / 100;
                        label57.Text = Convert.ToString(Convert.ToDouble(readerL["weightAxel"]) / 1000);
                    }
                    if (NumberIter == 8)
                    {
                        label38.Text = Convert.ToString(Convert.ToInt32(readerL["wheelCount"]) / 2);
                        label48.Text = Convert.ToString((Convert.ToDouble(readerL["position"]) / 100) - pos);
                        pos = Convert.ToDouble(readerL["position"]) / 100;
                        label56.Text = Convert.ToString(Convert.ToDouble(readerL["weightAxel"]) / 1000);
                    }

                    KN[0, i1] = Convert.ToInt32(readerL["group"]);
                    i1 = i1 + 1;
                    TSh = TSh + Convert.ToString(readerL["group"]);
                    NumberIter = NumberIter + 1;
                    KolOsL = Convert.ToInt32(readerL["AxleCount"]);
                    Cl = Convert.ToInt32(readerL["Class2"].ToString());

                    if (readerL["IDKlassN"].ToString() != "0")
                    { alphaBlendTextBox17.Text = readerL["IDKlassN"].ToString(); Cl = Convert.ToInt32(readerL["IDKlassN"].ToString()); }
                    else {
                        if (readerL["Class2"].ToString().Length > 3)
                        { alphaBlendTextBox17.Text = readerL["Class2"].ToString().Substring(0, 2); }
                        else if (readerL["Class2"].ToString().Length <= 1)
                        { alphaBlendTextBox17.Text = "Не определен"; }
                        else { alphaBlendTextBox17.Text = readerL["Class2"].ToString().Substring(0, 1); }
                    }
                        
                    ObshMass = Convert.ToDouble(readerL["Weight"].ToString());
                    ADNagr = Convert.ToDouble(readerL["maxosnagr"].ToString());
                    alphaBlendTextBox18.Text = readerL["namead"].ToString();
                    alphaBlendTextBox15.Text = readerL["namenapr"].ToString();
                    alphaBlendTextBox20.Text = readerL["Speed"].ToString();
                    alphaBlendTextBox14.Text = readerL["VehicleTypeName"].ToString();
                    label89.Text = readerL["dislocationapvk"].ToString();//readerL["nameapvk"].ToString() + ", " +
                    alphaBlendTextBox27.Text = readerL["SpeedRubej"].ToString();
                    alphaBlendTextBox21.Text = Convert.ToString(Math.Round(Convert.ToDouble(readerL["Length"].ToString())/100 , 2));
                    string Pl = "";
                    if (readerL["PlateConfidence"].ToString() == "0")
                    {Pl = readerL["PlateRear"].ToString(); }
                    else
                    {
                        Pl = readerL["Plate"].ToString();
                    }
                    
                    label85.Text = "";
                    label84.Text = "";
                    label82.Text = "";
                    label80.Text = "";
                    label76.Text = "";
                    label75.Text = "";
                    label72.Text = "";
                    label78.Text = "";
                    label74.Text = "";
                    int n = Pl.Length;
                    if (n >= 1) { label85.Text = Pl.Substring(0, 1); }
                    if (n >= 2) { label84.Text = Pl.Substring(1, 1); }
                    if (n >= 3) { label82.Text = Pl.Substring(2, 1); }
                    if (n >= 4) { label80.Text = Pl.Substring(3, 1); }
                    if (n >= 5) { label76.Text = Pl.Substring(4, 1); }
                    if (n >= 6) { label75.Text = Pl.Substring(5, 1); }
                    if (n >= 7) { label72.Text = Pl.Substring(6, 1); }
                    if (n >= 8) { label78.Text = Pl.Substring(7, 1); }
                    if (n == 9) { label74.Text = Pl.Substring(8, 1); }                   

                    IDW = Convert.ToInt64(readerL["ID_wim"].ToString());
                    PLN = readerL["PlatformId"].ToString();
                    IDpish = Convert.ToInt64(readerL["ID_wim"]);
                    if (readerL["Class3"] != null && readerL["Class3"].ToString() != "")
                    { NPicMon = Convert.ToInt64(readerL["Class3"]); }    
                    }
                readerL.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: \r\n{0}", ex.ToString());
            }
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
                    ColPicMon = Convert.ToInt32(readerLB11["CB"]);
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
                pictureBox2.Image = null;
                pictureBox12.Image = null;

                zLB = "SELECT " +
              "binarycontainer_n.*, " +
              "binarycontainer_n.ID_PR " +
              "FROM binarycontainer_n " +
              "WHERE binarycontainer_n.ID_PR = " + IDW + " AND platformid = " + PLN + ";";

                if (connectionL.State == System.Data.ConnectionState.Closed)
                { connectionL.Open(); }
                commandL.CommandText = zLB;// commandString;
                commandL.Connection = connectionL;

                MySqlDataReader readerLB;
                try
                {                    
                    readerLB = commandL.ExecuteReader();
                    while (readerLB.Read())
                    {
                        if (readerLB["name"].ToString() != "Video")
                        {
                            if (readerLB["name"].ToString() == "Image")
                            {
                                if (Puti[5] == "WIN-D3J6PR1H9QK")
                                { st7 = readerLB["dataavailable"].ToString(); }
                                else { st7 = @"" + Puti[2] + "" + readerLB["dataavailable"].ToString().Substring(13, readerLB["dataavailable"].ToString().Length - 13); }
                                pictureBox2.Image = new Bitmap(@"" + st7);
                            }
                            if (readerLB["name"].ToString() == "ImgPlate")
                            {
                                string st8;
                                if (Puti[5] == "WIN-D3J6PR1H9QK")
                                { st8 = readerLB["dataavailable"].ToString(); }
                                else { st8 = @"" + Puti[2] + "" + readerLB["dataavailable"].ToString().Substring(13, readerLB["dataavailable"].ToString().Length - 13); };
                                pictureBox12.Image = new Bitmap(@"" + st8);
                            }
                            if (readerLB["name"].ToString() == "ReaPlate")
                            {
                                if (Puti[5] == "WIN-D3J6PR1H9QK")
                                { st7 = readerLB["dataavailable"].ToString(); }
                                else { st7 = @"" + Puti[2] + "" + readerLB["dataavailable"].ToString().Substring(13, readerLB["dataavailable"].ToString().Length - 13); }
                                if (pictureBox12.Image == null)
                                {
                                    pictureBox12.Image = new Bitmap(@"" + st7);
                                }
                            }
                        }
                        else
                        {
                        }
                    }
                    
                    readerLB.Close();
                }
                catch (MySqlException ex)
                                {
                                    Console.WriteLine("Error: \r\n{0}", ex.ToString());
                                }
                            }commandL.Connection.Close();
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
                    double Mo = 0;
                    Mo = (Math.Round(ObshMass / 1000, 2)) - (Math.Round(ObshMass / 1000, 2) / 100 * 5);
                    alphaBlendTextBox24.Text = Convert.ToString(Math.Round(Convert.ToDouble(reader2["pdmassts"].ToString()), 2));
                    if (Math.Round(Mo, 2) <= Convert.ToDouble(alphaBlendTextBox24.Text))
                    {
                        NarObMS = "";
                        alphaBlendTextBox28.Text = "Не превышено";
                        alphaBlendTextBox23.Text = "Не превышено";
                    }
                    else if (Convert.ToDouble(alphaBlendTextBox24.Text) < Math.Round(Mo, 2))
                    {
                        NarObMS = "Превышение общей массы ТС на " + NarObM + "т.(" + NarObMPr + "%). ";
                        NarObM = Math.Round(Mo, 2) - Convert.ToDouble(alphaBlendTextBox24.Text);
                        NarObMPr = Math.Round((Math.Round(Mo, 2) / (Convert.ToDouble(alphaBlendTextBox24.Text) / 100)), 2) - 100;
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
        
        #region/////////////////////////////////////////////   Осевая масса запрос ПДК 
        public void ZOsPDK()
        {
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
                        if (Convert.ToInt32(TypO[ic]) > 1 && D[ic - 1] == 0)
                        {
                            zapros2.PDOsNagr(Convert.ToInt32(DoubO[ic]), Convert.ToInt32(TypO[ic]), ADNagr, D[ic]);
                        }
                        else if (Convert.ToInt32(TypO[ic]) > 1 && D[ic - 1] <= D[ic])
                        {
                            zapros2.PDOsNagr(Convert.ToInt32(DoubO[ic]), Convert.ToInt32(TypO[ic]), ADNagr, D[ic - 1]);
                        }
                        else if (Convert.ToInt32(TypO[ic]) > 1 && D[ic - 1] > D[ic])
                        {
                            zapros2.PDOsNagr(Convert.ToInt32(DoubO[ic]), Convert.ToInt32(TypO[ic]), ADNagr, D[ic]);
                        }
                        else if (Convert.ToInt32(TypO[ic]) == 1)
                        {
                            if (D[ic] < 250)
                            {
                                D[ic] = 250;
                            }
                            zapros2.PDOsNagr(Convert.ToInt32(DoubO[ic]), Convert.ToInt32(TypO[ic]), ADNagr, D[ic]);
                        }
                    }
                    else { zapros2.PDOsNagr(Convert.ToInt32(DoubO[ic]), Convert.ToInt32(TypO[ic]), ADNagr, D[ic - 1]); }

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
        #region /////////////////////////////////////////////////Увеличение рисунка в мониторинге
        private void pictureBox2_Click(object sender, EventArgs e) ///////////// Увеличение рисунка в мониторинге
        {
            if (pictureBox2.Image != null )
            {
                if (SelfRef.iz == 1)
                {
                    FormPic newfrm = new FormPic(pictureBox2.Image);
                    newfrm.Show();
                }
            }
        }
        #endregion ///////////////////////////////////////////////
        #region /////////////////////////////////////////////////            Кнопка фильтра а затем сам фильтр    ////////////////////////////
        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView9.RowCount > 0)
            {
                dataGridView9.CurrentCell = dataGridView9[1, 0];
            }
               checkBox11.Checked = false;
                timer2.Enabled = false;
                StopSearchM();               
        }
        private void StopSearchM()  // Делаем фильтр и все ссылк к нему (до строки ////////////////////////////////////////////  M O N I T O R   /////////////////////////////////////////////////////////////////////)
        {
            if (Napr1[1] == null) { Napr1[0] = ""; Napr1[1] = ""; Napr1[2] = ""; Napr1[3] = ""; }
            if (checkBox11.Checked==true)
            {
                dateTimePicker10.Value = DateTime.Now;
                dateTimePicker9.Value = dateTimePicker10.Value.AddDays(-1);//.AddHours(-1);
            }
            else
            {
            dateTimePicker9.Value = dateTimePicker6.Value;//Convert.ToDateTime("28.04.2018 00:00:00");//
            dateTimePicker10.Value = dateTimePicker5.Value;//Convert.ToDateTime("28.04.2018 13:00:00");
            }
            
            string TXTFLEFT = "";
            TXTFLEFT = " WHERE  Created >= '" + dateTimePicker9.Value.ToString("yyyyMMddHHmmss") + "' and Created <= '" + dateTimePicker10.Value.ToString("yyyyMMddHHmmss") + "'";
            if (textBox7.Text != "")
            {
                TXTFLEFT = TXTFLEFT + " and Plate LIKE '%" + textBox7.Text + "%'";
            }
            /////////////////////////////////////// по классу
            if (flags1==null) { flags1 = new Boolean[55]; }
            if (flags1[5] == false && flags1[6] == false && flags1[7] == false && flags1[8] == false && flags1[9] == false && flags1[10] == false && flags1[11] == false && flags1[12] == false && flags1[13] == false && flags1[14] == false && flags1[15] == false && flags1[16] == false && flags1[17] == false)
            { }
            else
            {
                if (flags1[5] == true)
                { TXTFLEFT = TXTFLEFT + " AND (IF(CHAR_LENGTH(allandnapr.Class2)>3 ,SUBSTR(allandnapr.Class2, 1, 2), IF(CHAR_LENGTH(allandnapr.Class2)<=1 ,0,SUBSTR(allandnapr.Class2, 1, 1))) = 1"; }
                else if (flags1[5] == false)
                { TXTFLEFT = TXTFLEFT + " AND (IF(CHAR_LENGTH(allandnapr.Class2)>3 ,SUBSTR(allandnapr.Class2, 1, 2), IF(CHAR_LENGTH(allandnapr.Class2)<=1 ,0,SUBSTR(allandnapr.Class2, 1, 1))) = 17"; }

                for (int ifk = 6; ifk < 17; ifk++)
                {
                    if (flags1[ifk] == true)
                    { TXTFLEFT = TXTFLEFT + " OR IF(CHAR_LENGTH(allandnapr.Class2)>3 ,SUBSTR(allandnapr.Class2, 1, 2), IF(CHAR_LENGTH(allandnapr.Class2)<=1 ,0,SUBSTR(allandnapr.Class2, 1, 1))) = " + (ifk - 4); }
                    else if (flags1[ifk] == false)
                    {/* TXTFLEFT = TXTFLEFT + " OR Cl12 = 0"; */}
                }
                if (flags1[17] == true)
                { TXTFLEFT = TXTFLEFT + " OR IF(CHAR_LENGTH(allandnapr.Class2)>3 ,SUBSTR(allandnapr.Class2, 1, 2), IF(CHAR_LENGTH(allandnapr.Class2)<=1 ,0,SUBSTR(allandnapr.Class2, 1, 1))) = 12)"; }
                else if (flags1[17] == false)
                { TXTFLEFT = TXTFLEFT + ")"; }
            }

            if (flags1[0] == true)
            { TXTFLEFT = TXTFLEFT + " AND (IsOverweightGross = 1"; }
          
            if (flags1[1] == true)
            {
                if (flags1[0] == true)
                { TXTFLEFT = TXTFLEFT + " OR IsOverweightPartial = 1"; }
                else
                { TXTFLEFT = TXTFLEFT + " AND (IsOverweightPartial = 1"; }
             }
            
            if (flags1[3] == true)
            {
                if (flags1[0] == true)
                { TXTFLEFT = TXTFLEFT + " OR IsOverweightPartial = 1"; }
                else
                {
                    if (flags1[1] == true)
                    { TXTFLEFT = TXTFLEFT + " OR IsOverweightPartial = 1"; }
                    else
                    { TXTFLEFT = TXTFLEFT + " AND (IsOverweightPartial = 1"; }
                }
            }
           
            if (flags1[4] == true)
            {
                if (flags1[0] == true)
                { TXTFLEFT = TXTFLEFT + " OR IsExceededLength = 1)"; }
                else
                {
                    if (flags1[1] == true)
                    { TXTFLEFT = TXTFLEFT + " OR IsExceededLength = 1)"; }
                    else
                    {
                        if (flags1[3] == true)
                        { TXTFLEFT = TXTFLEFT + " OR IsExceededLength = 1)"; }
                        else
                        { TXTFLEFT = TXTFLEFT + " AND IsExceededLength = 1"; }
                    }
                }
            }
            else
            {
                if (flags1[0] == true)
                { TXTFLEFT = TXTFLEFT + ")"; }
                else
                {
                    if (flags1[1] == true)
                    { TXTFLEFT = TXTFLEFT + ")"; }
                    else
                    {
                        if (flags1[3] == true)
                        { TXTFLEFT = TXTFLEFT + ")"; }
                       
                    }
                }
            }
            

            if (flags1[18] == true)
            { TXTFLEFT = TXTFLEFT + " AND (( Plate = '' and PlateRear = '' AND OldGRZ = '')"; }
            if (flags1[19] == true)
            {if (flags1[18] == true)
                { TXTFLEFT = TXTFLEFT + " or CredenceExceeded > 0"; }
                else
                { TXTFLEFT = TXTFLEFT + " AND ( CredenceExceeded > 0"; } }
            if (flags1[20] == true)
            { if (flags1[19] == true || flags1[18] == true)
                { TXTFLEFT = TXTFLEFT + " or AxleCount < 1"; }
            else { TXTFLEFT = TXTFLEFT + " AND ( AxleCount < 1"; }
            }
            if (flags1[21] == true)
            { if (flags1[19] == true || flags1[18] == true || flags1[20] == true)
                { TXTFLEFT = TXTFLEFT + " or ClassScheme3 < 3"; }
                else { TXTFLEFT = TXTFLEFT + " AND ( ClassScheme3 < 3"; }
            }
            if (flags1[19] == true || flags1[18] == true || flags1[20] == true || flags1[21] == true)
            { TXTFLEFT = TXTFLEFT + ")"; }
           
            if (Napr1[0].ToString() == "Все" || Napr1[0].ToString() == "")
            {/* TXTFLEFT = TXTFLEFT + " AND (PlatformId = 2952855555 OR PlatformId = 2952855553)"; */}
            else if (Napr1[0].ToString() == "РК-1")
            { TXTFLEFT = TXTFLEFT + " AND PlatformId = 2952855553"; }
            else if (Napr1[0].ToString() == "РК-2")
            { TXTFLEFT = TXTFLEFT + " AND PlatformId = 2952855555"; }
            
            if (Napr1[1].ToString() == "Все" || Napr1[1].ToString() == "")
            {/* TXTFLEFT = TXTFLEFT + " AND (namead =  '67-ОП-РЗ-67Р-01' OR namead = '67-ОП-РЗ-67К-14')"; */}
            else if (Napr1[1].ToString() == "67-ОП-РЗ-67Р-01")
            { TXTFLEFT = TXTFLEFT + " AND namead = '67-ОП-РЗ-67Р-01'"; }
            else if (Napr1[1].ToString() == "67-ОП-РЗ-67К-14")
            { TXTFLEFT = TXTFLEFT + " AND namead = '67-ОП-РЗ-67К-14'"; }

            if (Napr1[2].ToString() == "Все" || Napr1[2].ToString() == "")
            {/* TXTFLEFT = TXTFLEFT + " AND (namenapr =  'из Севастополя' OR namenapr = 'в Севастополь')"; */}
            else if (Napr1[2].ToString() == "из Севастополя")
            { TXTFLEFT = TXTFLEFT + " AND namenapr = 'из Севастополя'"; }
            else if (Napr1[2].ToString() == "в Севастополь")
            { TXTFLEFT = TXTFLEFT + " AND namenapr = 'в Севастополь'"; }

            if (Napr1[3].ToString() == "Все" || Napr1[3].ToString() == "")
            {/* TXTFLEFT = TXTFLEFT + " AND (Lane =  1 OR Lane = 2)"; */}
            else if (Napr1[3].ToString() == "1")
            { TXTFLEFT = TXTFLEFT + " AND Lane =  1"; }
            else if (Napr1[3].ToString() == "2")
            { TXTFLEFT = TXTFLEFT + " AND Lane =  2"; }


            if (flags1[27] == true)
            { TXTFLEFT = TXTFLEFT + " AND NameUs = 'AUTO'"; }
            if (flags1[28] == true)
            { TXTFLEFT = TXTFLEFT + " AND NameUs  NOT LIKE 'AUTO'"; }


            if (flags1[29] == false && flags1[30] == false && flags1[31] == false && flags1[32] == false && flags1[33] == false && flags1[34] == false && flags1[35] == false && flags1[36] == false)
            { }
            else
            {
                if (flags1[29] == true)
                { TXTFLEFT = TXTFLEFT + " AND (allandnapr.AxleCount <= 2"; }
                else if (flags1[29] == false)
                { TXTFLEFT = TXTFLEFT + " AND (allandnapr.AxleCount = 28"; }

                for (int ifk = 30; ifk < 36; ifk++)
                {
                    if (flags1[ifk] == true)
                    {  TXTFLEFT = TXTFLEFT + " OR allandnapr.AxleCount = " + (ifk - 27); }
                    else if (flags1[ifk] == false)
                    {/* TXTFLEFT = TXTFLEFT + " OR Cl12 = 0"; */}
                }
                if (flags1[36] == true)
                { TXTFLEFT = TXTFLEFT + " OR allandnapr.AxleCount >= 9 )"; }
                else if (flags1[36] == false)
                { TXTFLEFT = TXTFLEFT + ")"; }
            }

            if (flags1[37] == false && flags1[38] == false && flags1[39] == false && flags1[40] == false && flags1[41] == false && flags1[42] == false && flags1[43] == false && flags1[44] == false)
            { }
            else
            {
                if (flags1[37] == true)
                { TXTFLEFT = TXTFLEFT + " AND (allandnapr.Weight <= 3.5"; }
                else if (flags1[37] == false)
                { TXTFLEFT = TXTFLEFT + " AND (allandnapr.Weight = 280"; }
                               
                    if (flags1[38] == true)
                    {  TXTFLEFT = TXTFLEFT + " OR (allandnapr.Weight > 3.5 and allandnapr.Weight <= 5 )"; }
                    else if (flags1[38] == false)
                    {/* TXTFLEFT = TXTFLEFT + " OR Cl12 = 0"; */}
                if (flags1[39] == true)
                { TXTFLEFT = TXTFLEFT + " OR (allandnapr.Weight > 5 and allandnapr.Weight <= 10 )"; }
                else if (flags1[39] == false)
                {/* TXTFLEFT = TXTFLEFT + " OR Cl12 = 0"; */}
                if (flags1[40] == true)
                { TXTFLEFT = TXTFLEFT + " OR (allandnapr.Weight > 10 and allandnapr.Weight <= 20 )"; }
                else if (flags1[40] == false)
                {/* TXTFLEFT = TXTFLEFT + " OR Cl12 = 0"; */}
                if (flags1[41] == true)
                { TXTFLEFT = TXTFLEFT + " OR (allandnapr.Weight > 20 and allandnapr.Weight <= 30 )"; }
                else if (flags1[41] == false)
                {/* TXTFLEFT = TXTFLEFT + " OR Cl12 = 0"; */}
                if (flags1[42] == true)
                { TXTFLEFT = TXTFLEFT + " OR (allandnapr.Weight > 30 and allandnapr.Weight <= 50 )"; }
                else if (flags1[42] == false)
                {/* TXTFLEFT = TXTFLEFT + " OR Cl12 = 0"; */}
                if (flags1[43] == true)
                { TXTFLEFT = TXTFLEFT + " OR (allandnapr.Weight > 50 and allandnapr.Weight <= 70 )"; }
                else if (flags1[43] == false)
                {/* TXTFLEFT = TXTFLEFT + " OR Cl12 = 0"; */}

                if (flags1[44] == true)
                { TXTFLEFT = TXTFLEFT + " OR allandnapr.Weight > 70 )"; }
                else if (flags1[44] == false)
                { TXTFLEFT = TXTFLEFT + ")"; }
                
            }

            if (flags1[45] == false && flags1[46] == false && flags1[47] == false && flags1[48] == false)
            { }
            else
            {
                if (flags1[45] == true)
                { TXTFLEFT = TXTFLEFT + " AND (allandnapr.Length <= 5"; }
                else if (flags1[45] == false)
                { TXTFLEFT = TXTFLEFT + " AND (allandnapr.Length = 280"; }

                if (flags1[46] == true)
                { TXTFLEFT = TXTFLEFT + " OR (allandnapr.Length > 5 and allandnapr.Length <= 12 )"; }
                else if (flags1[46] == false)
                {/* TXTFLEFT = TXTFLEFT + " OR Cl12 = 0"; */}
                if (flags1[47] == true)
                { TXTFLEFT = TXTFLEFT + " OR (allandnapr.Length > 12 and allandnapr.Length <= 20 )"; }
                else if (flags1[47] == false)
                {/* TXTFLEFT = TXTFLEFT + " OR Cl12 = 0"; */}
               
                if (flags1[48] == true)
                { TXTFLEFT = TXTFLEFT + " OR allandnapr.Length > 20 )"; }
                else if (flags1[44] == false)
                { TXTFLEFT = TXTFLEFT + ")"; }
            }

            if (flags1[49] == false && flags1[50] == false && flags1[51] == false && flags1[52] == false && flags1[53] == false)
            { }
            else
            {
                if (flags1[49] == true)
                { TXTFLEFT = TXTFLEFT + " AND (allandnapr.Speed < 50"; }
                else if (flags1[49] == false)
                { TXTFLEFT = TXTFLEFT + " AND (allandnapr.Speed = 280"; }

                if (flags1[50] == true)
                { TXTFLEFT = TXTFLEFT + " OR (allandnapr.Speed >= 50 and allandnapr.Speed <= 60 )"; }
                else if (flags1[50] == false)
                {/* TXTFLEFT = TXTFLEFT + " OR Cl12 = 0"; */}
                if (flags1[51] == true)
                { TXTFLEFT = TXTFLEFT + " OR (allandnapr.Speed > 60 and allandnapr.Speed <= 70 )"; }
                else if (flags1[51] == false)
                {/* TXTFLEFT = TXTFLEFT + " OR Cl12 = 0"; */}
                if (flags1[52] == true)
                { TXTFLEFT = TXTFLEFT + " OR (allandnapr.Speed > 70 and allandnapr.Speed <= 90 )"; }
                else if (flags1[52] == false)
                {/* TXTFLEFT = TXTFLEFT + " OR Cl12 = 0"; */}

                if (flags1[53] == true)
                { TXTFLEFT = TXTFLEFT + " OR allandnapr.Speed > 90 )"; }
                else if (flags1[53] == false)
                { TXTFLEFT = TXTFLEFT + ")"; }
            }
            //AND allandnapr.AxleCount = 3 AND Length > 5 AND Weight > 20 AND Speed > 85

            TXTFLEFT = TXTFLEFT + " ORDER BY Created DESC LIMIT "+ textBox11.Text + ";";
           
            ////////////////////////////////////////
           
            string NAVGK = comboBox8.Text;

            if (NAVGK != "")
            {
                TXTFLEFT = TXTFLEFT + " and PlatformId = " + Convert.ToInt64(comboBox8.SelectedValue.ToString()) + "";
               // textBox11.Text = "10000";
            }
            flags1 = flags;
            if (DS != null)
                DS.Clear();
            ZMonitor(TXTFLEFT);
            label86.Visible = false;
             if (toolStripLabel2.Text != "")
            {
                kol = Convert.ToInt32(toolStripLabel2.Text);
            }
            if (dataGridView9.RowCount > 1)
            {
                rowIndex = dataGridView9.SelectedCells[1].RowIndex;
                if (kol > rowIndex)
                { kol = 0; }
                int Sum = 0;
                for (int i = 0; i < dataGridView9.Rows.Count; i++)
                {
                    Sum = Sum + 1;
                }
                if (Sum - kol < Sum)
                { kol = Sum - kol; }
                dataGridView9.CurrentCell = dataGridView9[1, rowIndex + kol];
                currentRowLeft = rowIndex + kol;
                toolStripLabel2.Text = "" + (Convert.ToInt32(Sum)).ToString();
                Otrisovka();
            }
            else
            {
                if (DS != null)
                    DS.Clear();
                ZMonitor("");
                label86.Text = "ЗАПИСИ УДОВЛЕТВОРЯЮЩИЕ ЗАПРОСУ НЕ НАЙДЕНЫ";
                label86.Visible=true;
                Otrisovka();
            }
        }
        #endregion /////////////////////////////////////////////////


        private void timer2_Tick(object sender, EventArgs e)
        {
            nM = nM + 6;
            dateTimePicker10.Value = DateTime.Now;
            dateTimePicker9.Value = dateTimePicker10.Value.AddHours(-1);//.AddSeconds(-nM);//dateTimePicker8.Value.AddHours(-12);
            if (dataGridView9.Rows.Count != 0)
            { RC = dataGridView9.CurrentCell.RowIndex; }
            if (DS != null)
                DS.Clear();
            StopSearchM();
            //ZMonitor("");
            if (dataGridView9.Rows.Count != 0)
            {
                if (toolStripLabel2.Text != "")
                {
                    kol = Convert.ToInt32(toolStripLabel2.Text);
                }

                dataGridView9.CurrentCell = dataGridView9[0, RC];
                rowIndexM = dataGridView9.CurrentCell.RowIndex;
                if (kol > rowIndexM)
                { kol = 0; }
                dateTimePicker10.Value = DateTime.Now;//dateTimePicker10.Value.AddMinutes(+10);
                int SumM = 0;
                for (int i = 0; i < dataGridView9.Rows.Count; i++)
                {
                    SumM = SumM + 1;// (int)dataGridView8.Rows[i].Cells[0].Value;
                }
                if (SumM - kol < SumM)
                { kol = SumM - kol; }

                currentRowLeft = rowIndexM + kol;
                dataGridView9.CurrentCell = dataGridView9[0, rowIndexM + kol];
                toolStripLabel2.Text = "" + (Convert.ToInt32(SumM)).ToString();
                int SumMN = 0;
                for (int i = 0; i < dataGridView9.Rows.Count; i++)
                {
                    if ((Convert.ToBoolean(dataGridView9.Rows[i].Cells[15].Value) == true ||
                        Convert.ToBoolean(dataGridView9.Rows[i].Cells[14].Value) == true || Convert.ToBoolean(dataGridView9.Rows[i].Cells[13].Value) == true || 
                        Convert.ToBoolean(dataGridView9.Rows[i].Cells[10].Value) == true || Convert.ToBoolean(dataGridView9.Rows[i].Cells[11].Value) == true || Convert.ToBoolean(dataGridView9.Rows[i].Cells[12].Value) == true /*|| Convert.ToBoolean(dataGridView9.Rows[i].Cells[14].Value) == true*/
                        && (Convert.ToDouble(dataGridView9.Rows[i].Cells[4].Value) == 0 || Convert.ToDouble(dataGridView9.Rows[i].Cells[6].Value) == 0 || Convert.ToDouble(dataGridView9.Rows[i].Cells[7].Value) == 0 || dataGridView9.Rows[i].Cells[19].Value.ToString() != "0")
                        )/* && Convert.ToInt32(dataGridView9.Rows[i].Cells[19].Value)==0 */)
                    {
                        SumMN = SumMN + 1;
                    }
                }
                toolStripLabel4.Text = "" + (Convert.ToInt32(SumMN)).ToString();
                Otrisovka();
            }
        }

        private void tabControl1_Click(object sender, EventArgs e)
        { if (((strus[1]) != "") && (Convert.ToInt32(strus[1]) > 0) && ((strus[6]) != "") && (Convert.ToInt32(strus[6]) > 0))
            {
                if (tabControl1.SelectedIndex == 1)
                {
                    timer1.Enabled = true;
                    timer2.Enabled = false;
                    timer3.Enabled = true;
                }
                else if (tabControl1.SelectedIndex == 0)
                {
                    timer1.Enabled = false;
                    timer2.Enabled = true;
                    timer3.Enabled = false;
                }
            }
            else if (((strus[1]) != "") && (Convert.ToInt32(strus[1]) > 0))
            {
                timer1.Enabled = false;
                timer2.Enabled = true;
                timer3.Enabled = false;

            }

            else if (((strus[6]) != "") && (Convert.ToInt32(strus[6]) > 0))
            {
                timer1.Enabled = true;
                timer2.Enabled = false;
                timer3.Enabled = true;
            }

            if (tabControl1.SelectedIndex == 3)
            {
                DSAD = new DataSet();
                DSMD = new DataSet();
                DSKL = new DataSet();
                DSRUB = new DataSet();
                DSNAPR = new DataSet();
                ////////////////////////////////////// ЗАГРУЗКА АД ///////////////////////////////////////////////////////            
                ConnectStr conStrAD = new ConnectStr();
                Zapros zaprosAD = new Zapros();
                conStrAD.ConStr(1);
                zaprosAD.AD(0);
                cstrAD = conStrAD.StP;
                zAD = zaprosAD.commandStringTest;
                connectionAD = new MySqlConnection(cstrAD);
                mySqlDataAdapterAD = new MySqlDataAdapter(zAD, connectionAD);
                mySqlDataAdapterAD.Fill(DSAD);
                dataGridView13.DataSource = DSAD.Tables[0];
                connectionAD.Close();
                dataGridView13.Refresh();
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            }
            ////////////////////////////////////// ЗАГРУЗКА Участка ///////////////////////////////////////////////////////  
            DSMD = new DataSet();
            ZagrUchast(0);
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////// ЗАГРУЗКА КлассаТС ///////////////////////////////////////////////////////  
            DSKL = new DataSet();
            ZagrKlass(0);
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////// ЗАГРУЗКА РУБЕЖЕЙ ///////////////////////////////////////////////////////  
            DSRUB = new DataSet();
            ZagrRUB(0);
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////// ЗАГРУЗКА НАПРАВЛЕНИЙ ///////////////////////////////////////////////////////  
            DSNAPR = new DataSet();
            ZagrNAPR(0);
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        }
        #region /////////////////////////////////////////////////   Комбобокс Название комплекса в КОНТРОЛЕ
        private void comboBox2_MouseClick(object sender, MouseEventArgs e)
        {
            //ConnectStr conStrComCOMBO = new ConnectStr();
            //Zapros zaprosCom = new Zapros();
            //conStrComCOMBO.ConStr(1);
            //zaprosCom.COMBOKOMPL();
            //cstr = conStrComCOMBO.StP;
            //z = zaprosCom.commandStringTest;
            //MySqlConnection connectionCOMBO = new MySqlConnection(cstr);
            //mySqlDataAdapter = new MySqlDataAdapter(z, connectionCOMBO);
            //DataSet DSCOMBO = new DataSet();
            //mySqlDataAdapter.Fill(DSCOMBO);
            //comboBox2.DataSource = DSCOMBO.Tables[0];
            //comboBox2.DisplayMember = "nameapvk";
            //comboBox2.ValueMember = "KAPVGK";
            //connectionCOMBO.Close();
        }
        #endregion /////////////////////////////////////////////////
       
        #region /////////////////////////////////////////////////   Комбобокс Название комплекса в МОНИТОРЕ
        private void comboBox8_MouseClick(object sender, MouseEventArgs e)
        {
            ConnectStr conStrComCOMBO = new ConnectStr();
            Zapros zaprosCom = new Zapros();
            conStrComCOMBO.ConStr(1);
            zaprosCom.COMBOKOMPL();
            cstr = conStrComCOMBO.StP;
            z = zaprosCom.commandStringTest;
            MySqlConnection connectionCOMBO = new MySqlConnection(cstr);
            mySqlDataAdapter = new MySqlDataAdapter(z, connectionCOMBO);
            DataSet DSCOMBO = new DataSet();
            mySqlDataAdapter.Fill(DSCOMBO);
            comboBox8.DataSource = DSCOMBO.Tables[0];
            comboBox8.DisplayMember = "nameapvk";
            comboBox8.ValueMember = "KAPVGK";
            connectionCOMBO.Close();
        }
        #endregion /////////////////////////////////////////////////   

        #region/////////////////////////////////////////////   загрузка всех параметров проезда для K(ПРАВЫЙ) //////////////////  
        public void ZagrdataGridView11(int IDp)
        {
            MySqlCommand commandR = new MySqlCommand();
            ConnectStr conStrR = new ConnectStr();
            conStrR.ConStr(1);
            Zapros zaprosR = new Zapros();
            string connectionStringR;//, commandString;
            connectionStringR = conStrR.StP;//"Data source=localhost;UserId=root;Password=1q2w3e$R;database=camloc;";
            MySqlConnection connectionR = new MySqlConnection(connectionStringR);
            zaprosR.ZaprPravKontrOsi(IDp);
            zR = zaprosR.commandStringTest;
            commandR.CommandText = zR;// commandString;
            commandR.Connection = connectionR;

            MySqlDataReader readerR;
            int NumberIter = 0;           

            AxelDateKR = new string[4,10] { { "0", "0", "0", "0", "0", "0", "0", "0", "0", "0" },
                { "0", "0", "0", "0", "0", "0", "0", "0", "0", "0" },
                { "0", "0", "0", "0", "0", "0", "0", "0", "0", "0" },
                { "0", "0", "0", "0", "0", "0", "0", "0", "0", "0" } };
            label213.Text = "0"; label212.Text = "0"; label211.Text = "0"; label210.Text = "0";
            label209.Text = "0"; label208.Text = "0"; label207.Text = "0"; label206.Text = "0";
            label205.Text = "0";

            label204.Text = "0"; label203.Text = "0"; label202.Text = "0"; label201.Text = "0";
            label200.Text = "0"; label199.Text = "0"; label198.Text = "0"; label197.Text = "0";

            label195.Text = "0"; label194.Text = "0"; label193.Text = "0"; label192.Text = "0";
            label191.Text = "0"; label190.Text = "0"; label189.Text = "0"; label188.Text = "0";
            label187.Text = "0";

            KN = new int[2, 9];
            int i1 = 0;
            try
            {
                commandR.Connection.Open();
                readerR = commandR.ExecuteReader();
                double pos = 0;
                while (readerR.Read())
                {
                    OshKK = Convert.ToInt32(readerR["CredenceExceeded"].ToString());
                    if (NumberIter==0)
                    {
                        AxelDateKR[0, 0] = Convert.ToString(Convert.ToInt32(readerR["wheelCount"]) / 2);
                        AxelDateKR[1, 0] = "0";
                        AxelDateKR[2, 0] = "0";
                        AxelDateKR[3, 0] = Convert.ToString(Convert.ToDouble(readerR["weightAxel"]) / 1000);
                        NumberIter = NumberIter + 1;
                        AxelDateKR[2, 9] = Convert.ToString(Convert.ToDouble(readerR["Weight"]) / 1000); ;
                        AxelDateKR[3, 9] = Convert.ToString(Convert.ToDouble(readerR["Length"]) / 100);
                        KN[0, i1] = Convert.ToInt32(readerR["group"]);
                        i1 = i1 + 1;
                        TSh11 = TSh11 + Convert.ToString(readerR["group"]);
                        KolOsL = Convert.ToInt32(readerR["AxleCount"]);
                        Cl = Convert.ToInt32(readerR["Class2"].ToString());

                        if (readerR["IDKlassN"].ToString() != "0")
                        { alphaBlendTextBox4.Text = readerR["IDKlassN"].ToString(); Cl = Convert.ToInt32(readerR["IDKlassN"].ToString()); }
                        else
                        {
                            if (readerR["Class2"].ToString().Length > 3)
                            { alphaBlendTextBox4.Text = readerR["Class2"].ToString().Substring(0, 2); }
                            else if (readerR["Class2"].ToString().Length <= 1)
                            { alphaBlendTextBox4.Text = "0"; }
                            else { alphaBlendTextBox4.Text = readerR["Class2"].ToString().Substring(0, 1); }
                        }
                        ObshMass = Convert.ToDouble(readerR["Weight"].ToString());
                        ADNagr = Convert.ToDouble(readerR["maxosnagr"].ToString());
                        alphaBlendTextBox8.Text = readerR["namead"].ToString();
                        alphaBlendTextBox7.Text = readerR["namenapr"].ToString();
                        alphaBlendTextBox5.Text = readerR["dislocationapvk"].ToString();
                        alphaBlendTextBox3.Text = readerR["nameapvk"].ToString();
                        alphaBlendTextBox2.Text = readerR["Lane"].ToString();
                        string Pl = readerR["Plate"].ToString();
                        label224.Text = "";
                        label223.Text = "";
                        label222.Text = "";
                        label221.Text = "";
                        label219.Text = "";
                        label218.Text = "";
                        label216.Text = "";
                        label220.Text = "";
                        label217.Text = "";
                        int n = Pl.Length;
                        if (n >= 1) { label224.Text = Pl.Substring(0, 1); }
                        if (n >= 2) { label223.Text = Pl.Substring(1, 1); }
                        if (n >= 3) { label222.Text = Pl.Substring(2, 1); }
                        if (n >= 4) { label221.Text = Pl.Substring(3, 1); }
                        if (n >= 5) { label219.Text = Pl.Substring(4, 1); }
                        if (n >= 6) { label218.Text = Pl.Substring(5, 1); }
                        if (n >= 7) { label216.Text = Pl.Substring(6, 1); }
                        if (n >= 8) { label220.Text = Pl.Substring(7, 1); }
                        if (n == 9) { label217.Text = Pl.Substring(8, 1); }

                        IDW = Convert.ToInt64(readerR["ID_wim"].ToString());
                        PLN = readerR["PlatformId"].ToString();
                        IDpish = Convert.ToInt64(readerR["ID_wim"]);
                        NPicKR = Convert.ToInt64(readerR["Class3"]);
                    }
                    else
                    {
                        AxelDateKR[0, NumberIter] = Convert.ToString(Convert.ToInt32(readerR["wheelCount"]) / 2);
                        AxelDateKR[1, NumberIter] = Convert.ToString((Convert.ToDouble(readerR["position"]) / 100) - Convert.ToDouble(AxelDateKR[2, NumberIter-1]));
                        AxelDateKR[2, NumberIter] = Convert.ToString(Convert.ToDouble(readerR["position"]) / 100);
                        AxelDateKR[3, NumberIter] = Convert.ToString(Convert.ToDouble(readerR["weightAxel"]) / 1000);
                        NumberIter = NumberIter + 1;
                    }
                   
                }
                readerR.Close();
        }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: \r\n{0}", ex.ToString());
            }
            
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
            if (ColPicKR < 16)
            {
                pictureBox43.Image = null;
                pictureBox53.Image = null;
                for (int i = 0; i < ColPicKR; i++)
                {
                    if (i != 0)
                    { NPicKR = NPicKR - 1; }

                    Zapros zaprosLB = new Zapros();
                    if (alphaBlendTextBox9.Text.ToString() != null || alphaBlendTextBox9.Text.ToString() != "000000" || alphaBlendTextBox9.Text.ToString() != "")
                    {                       
                        if ((Convert.ToDateTime(dataGridView11[9, (dataGridView11.CurrentRow.Index)].Value.ToString()) < Convert.ToDateTime("08.06.2018 13:25:49") && PLN == "2952855555") || (Convert.ToDateTime(dataGridView11[9, (dataGridView11.CurrentRow.Index)].Value.ToString()) < Convert.ToDateTime("24.05.2018 16:50:25") && PLN == "2952855553"))
                        {
                            zaprosLB.ZaprBitmapPHOTO(NPicKR, PLN, IDW);
                            zLB = zaprosLB.commandStringTest;
                            commandR.CommandText = zLB;// commandString;
                            commandR.Connection = connectionR;

                            MySqlDataReader readerLB;
                            try
                            {
                                readerLB = commandR.ExecuteReader();

                                while (readerLB.Read())
                                {
                                    if (readerLB["name"].ToString() != "Video")
                                    {
                                        if (readerLB["name"].ToString() == "Image")
                                    {
                                        string st = readerLB["dataavailable"].ToString();
                                        Bitmap img = new Bitmap(@"" + st);
                                        pictureBox43.Image = img;//new Bitmap(@"" + st);
                                    }
                                    if (readerLB["name"].ToString() == "ImgPlate")
                                    {
                                       string st1 = readerLB["dataavailable"].ToString();
                                        pictureBox53.Image = new Bitmap(@"" + st1);
                                    }                                       
                                }
                                    else
                                    {
                                    }
                                }
                                readerLB.Close();
                            }
                            catch (MySqlException ex)
                            {
                                Console.WriteLine("Error: \r\n{0}", ex.ToString());
                            }
                        }
                        else 
                        {
                            zaprosLB.ZaprBitmapPHOTONew(NPicKR, PLN, IDW);
                            zLB = zaprosLB.commandStringTest;
                            commandR.CommandText = zLB;// commandString;
                            commandR.Connection = connectionR;
                            MySqlDataReader readerLB;
                            try
                            {
                                readerLB = commandR.ExecuteReader();
                                while (readerLB.Read())
                                {
                                    if (readerLB["name"].ToString() != "Video")
                                    {
                                        if (readerLB["name"].ToString() == "Image")
                                    {
                                        string st;
                                        if (Puti[5] == "WIN-D3J6PR1H9QK")
                                        { st = readerLB["dataavailable"].ToString(); }
                                        else { st = @"" + Puti[2] + "" + readerLB["dataavailable"].ToString().Substring(13, readerLB["dataavailable"].ToString().Length - 13); };
                                        Bitmap img = new Bitmap(@"" + st);
                                        pictureBox43.Image = img;//new Bitmap(@"" + st);
                                    }
                                    if (readerLB["name"].ToString() == "ImgPlate")
                                    {
                                       string st1;
                                        if (Puti[5] == "WIN-D3J6PR1H9QK")
                                        { st1 = readerLB["dataavailable"].ToString(); }
                                        else { st1 = @"" + Puti[2] + "" + readerLB["dataavailable"].ToString().Substring(13, readerLB["dataavailable"].ToString().Length - 13); };

                                        pictureBox53.Image = new Bitmap(@"" + st1);
                                    }
                                        if (readerLB["name"].ToString() == "ReaPlate")
                                        {
                                            if (Puti[5] == "WIN-D3J6PR1H9QK")
                                            { st7 = readerLB["dataavailable"].ToString(); }
                                            else { st7 = @"" + Puti[2] + "" + readerLB["dataavailable"].ToString().Substring(13, readerLB["dataavailable"].ToString().Length - 13); }
                                            if (pictureBox53.Image == null)
                                            {
                                                pictureBox53.Image = new Bitmap(@"" + st7);
                                            }
                                        }
                                    }
                                 else
                                {
                                }
                            }
                                readerLB.Close();
                            }
                            catch (MySqlException ex)
                            {
                                Console.WriteLine("Error: \r\n{0}", ex.ToString());
                            }                        
                        }
                    }
                }
            }
            commandR.Connection.Close();
        }
        public void ZagrdataGridView10(int IDp)
        {
            MySqlCommand commandR = new MySqlCommand();
            ConnectStr conStrR = new ConnectStr();
            conStrR.ConStr(1);
            Zapros zaprosR = new Zapros();
            string connectionStringR;//, commandString;
            connectionStringR = conStrR.StP;//"Data source=localhost;UserId=root;Password=1q2w3e$R;database=camloc;";
            MySqlConnection connectionR = new MySqlConnection(connectionStringR);
            zaprosR.ZaprPravKontrOsi(IDp);
            zR = zaprosR.commandStringTest;
            commandR.CommandText = zR;// commandString;
            commandR.Connection = connectionR;

            MySqlDataReader readerR;
            int NumberIter = 0;

            label213.Text = "0"; label212.Text = "0"; label211.Text = "0"; label210.Text = "0";
            label209.Text = "0"; label208.Text = "0"; label207.Text = "0"; label206.Text = "0";
            label205.Text = "0";

            label204.Text = "0"; label203.Text = "0"; label202.Text = "0"; label201.Text = "0";
            label200.Text = "0"; label199.Text = "0"; label198.Text = "0"; label197.Text = "0";

            label195.Text = "0"; label194.Text = "0"; label193.Text = "0"; label192.Text = "0";
            label191.Text = "0"; label190.Text = "0"; label189.Text = "0"; label188.Text = "0";
            label187.Text = "0";

            KN = new int[2, 9];
            int i1 = 0;
            try
            {
                commandR.Connection.Open();
                readerR = commandR.ExecuteReader();
                double pos = 0;
                while (readerR.Read())
                {
                    label186.Text = Convert.ToString(Convert.ToDouble(readerR["Weight"]) / 1000);
                    label196.Text = Convert.ToString(Convert.ToDouble(readerR["Length"]) / 100);
                    if (NumberIter == 0)
                    {
                        string i = Convert.ToString(Convert.ToInt32(readerR["wheelCount"]) / 2);
                        label195.Text = i;//Convert.ToString(Convert.ToInt32(readerL["wheelCount"]) / 2);
                        string ii = Convert.ToString(Convert.ToDouble(readerR["weightAxel"]) / 1000);
                        label213.Text = ii;//Convert.ToString(Convert.ToDouble(readerL["weightAxel"]) / 1000);
                    }
                    if (NumberIter == 1)
                    {
                        label194.Text = Convert.ToString(Convert.ToInt32(readerR["wheelCount"]) / 2);
                        label204.Text = Convert.ToString((Convert.ToDouble(readerR["position"]) / 100) - pos);
                        pos = Convert.ToDouble(readerR["position"]) / 100;
                        label212.Text = Convert.ToString(Convert.ToDouble(readerR["weightAxel"]) / 1000);
                    }
                    if (NumberIter == 2)
                    {
                        label193.Text = Convert.ToString(Convert.ToInt32(readerR["wheelCount"]) / 2);
                        label203.Text = Convert.ToString((Convert.ToDouble(readerR["position"]) / 100) - pos);
                        pos = Convert.ToDouble(readerR["position"]) / 100;
                        label211.Text = Convert.ToString(Convert.ToDouble(readerR["weightAxel"]) / 1000);
                    }
                    if (NumberIter == 3)
                    {
                        label192.Text = Convert.ToString(Convert.ToInt32(readerR["wheelCount"]) / 2);
                        label202.Text = Convert.ToString((Convert.ToDouble(readerR["position"]) / 100) - pos);
                        pos = Convert.ToDouble(readerR["position"]) / 100;
                        label210.Text = Convert.ToString(Convert.ToDouble(readerR["weightAxel"]) / 1000);
                    }
                    if (NumberIter == 4)
                    {
                        label191.Text = Convert.ToString(Convert.ToInt32(readerR["wheelCount"]) / 2);
                        label201.Text = Convert.ToString((Convert.ToDouble(readerR["position"]) / 100) - pos);
                        pos = Convert.ToDouble(readerR["position"]) / 100;
                        label209.Text = Convert.ToString(Convert.ToDouble(readerR["weightAxel"]) / 1000);
                    }
                    if (NumberIter == 5)
                    {
                        label190.Text = Convert.ToString(Convert.ToInt32(readerR["wheelCount"]) / 2);
                        label200.Text = Convert.ToString((Convert.ToDouble(readerR["position"]) / 100) - pos);
                        pos = Convert.ToDouble(readerR["position"]) / 100;
                        label208.Text = Convert.ToString(Convert.ToDouble(readerR["weightAxel"]) / 1000);
                    }
                    if (NumberIter == 6)
                    {
                        label189.Text = Convert.ToString(Convert.ToInt32(readerR["wheelCount"]) / 2);
                        label199.Text = Convert.ToString((Convert.ToDouble(readerR["position"]) / 100) - pos);
                        pos = Convert.ToDouble(readerR["position"]) / 100;
                        label207.Text = Convert.ToString(Convert.ToDouble(readerR["weightAxel"]) / 1000);
                    }
                    if (NumberIter == 7)
                    {
                        label188.Text = Convert.ToString(Convert.ToInt32(readerR["wheelCount"]) / 2);
                        label198.Text = Convert.ToString((Convert.ToDouble(readerR["position"]) / 100) - pos);
                        pos = Convert.ToDouble(readerR["position"]) / 100;
                        label206.Text = Convert.ToString(Convert.ToDouble(readerR["weightAxel"]) / 1000);
                    }
                    if (NumberIter == 8)
                    {
                        label187.Text = Convert.ToString(Convert.ToInt32(readerR["wheelCount"]) / 2);
                        label197.Text = Convert.ToString((Convert.ToDouble(readerR["position"]) / 100) - pos);
                        pos = Convert.ToDouble(readerR["position"]) / 100;
                        label205.Text = Convert.ToString(Convert.ToDouble(readerR["weightAxel"]) / 1000);
                    }
                    KN[0, i1] = Convert.ToInt32(readerR["group"]);
                    i1 = i1 + 1;
                    TSh11 = TSh11 + Convert.ToString(readerR["group"]);
                    NumberIter = NumberIter + 1;
                    KolOsL = Convert.ToInt32(readerR["AxleCount"]);
                    Cl = Convert.ToInt32(readerR["Class"].ToString());
                    alphaBlendTextBox4.Text = readerR["Class"].ToString();// + ", " + readerL["VehicleTypeName"].ToString();
                    ObshMass = Convert.ToDouble(readerR["Weight"].ToString());
                    ADNagr = Convert.ToDouble(readerR["maxosnagr"].ToString());
                    alphaBlendTextBox8.Text = readerR["namead"].ToString();
                    alphaBlendTextBox7.Text = readerR["namenapr"].ToString();
                    alphaBlendTextBox5.Text = readerR["dislocationapvk"].ToString();
                    alphaBlendTextBox3.Text = readerR["nameapvk"].ToString();
                    alphaBlendTextBox2.Text = readerR["Lane"].ToString();
                    string Pl = "";
                     Pl = readerR["Plate"].ToString();
                    label224.Text = "";
                    label223.Text = "";
                    label222.Text = "";
                    label221.Text = "";
                    label219.Text = "";
                    label218.Text = "";
                    label216.Text = "";
                    label220.Text = "";
                    label217.Text = "";
                    int n = Pl.Length;
                    if (n >= 1) { label224.Text = Pl.Substring(0, 1); }
                    if (n >= 2) { label223.Text = Pl.Substring(1, 1); }
                    if (n >= 3) { label222.Text = Pl.Substring(2, 1); }
                    if (n >= 4) { label221.Text = Pl.Substring(3, 1); }
                    if (n >= 5) { label219.Text = Pl.Substring(4, 1); }
                    if (n >= 6) { label218.Text = Pl.Substring(5, 1); }
                    if (n >= 7) { label216.Text = Pl.Substring(6, 1); }
                    if (n >= 8) { label220.Text = Pl.Substring(7, 1); }
                    if (n == 9) { label217.Text = Pl.Substring(8, 1); }

                    IDW = Convert.ToInt64(readerR["ID_wim"].ToString());
                    PLN = readerR["PlatformId"].ToString();
                    IDpish = Convert.ToInt64(readerR["ID_wim"]);
                    NPicKR = Convert.ToInt64(readerR["Class3"]);
                }
                readerR.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: \r\n{0}", ex.ToString());
            }
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
            if (ColPicKR < 16)
            {
            pictureBox53.Image = null;
            pictureBox43.Image = null;
                for (int i = 0; i < ColPicKR; i++)
                {
                    if (i != 0)
                    { NPicKR = NPicKR - 1; }
                    if (connectionR.State == System.Data.ConnectionState.Closed)
                    { connectionR.Open(); }
                    Zapros zaprosLB = new Zapros();
                    if (alphaBlendTextBox9.Text.ToString() != null || alphaBlendTextBox9.Text.ToString() != "000000" || alphaBlendTextBox9.Text.ToString() != "")
                    {
                        if (Convert.ToDateTime(dataGridView10[9, (dataGridView10.CurrentRow.Index)].Value.ToString()) < Convert.ToDateTime("29.04.2018 11:44:57"))
                        {
                            zaprosLB.ZaprBitmap(NPicKR, PLN, IDW);
                            zLB = zaprosLB.commandStringTest;
                            commandR.CommandText = zLB;// commandString;
                            commandR.Connection = connectionR;
                            MySqlDataReader readerLB;
                            try
                            {
                                readerLB = commandR.ExecuteReader();
                            while (readerLB.Read())
                            {
                                    if (readerLB["name"].ToString() != "Video")
                                    {
                                        if (readerLB["name"].ToString() == "Image")
                                {                                    
                                    pictureBox43.Image = null;
                                    pictureBox43.Image = StrToImg(readerLB["dataavailable"].ToString());
                                }
                                if (readerLB["name"].ToString() == "ImgPlate")
                                {
                                    pictureBox53.Image = null;
                                    pictureBox53.Image = StrToImg(readerLB["dataavailable"].ToString());
                                }
                            }
                                    else
                                    {
                                    }
                                }
                                readerLB.Close();
                            }
                            catch (MySqlException ex)
                            {
                                Console.WriteLine("Error: \r\n{0}", ex.ToString());
                            }
                        }
                        else if ((Convert.ToDateTime(dataGridView10[9, (dataGridView10.CurrentRow.Index)].Value.ToString()) < Convert.ToDateTime("08.06.2018 13:25:49") && PLN == "2952855555") || (Convert.ToDateTime(dataGridView10[9, (dataGridView10.CurrentRow.Index)].Value.ToString()) < Convert.ToDateTime("24.05.2018 16:50:25") && PLN == "2952855553"))
                        {
                            zaprosLB.ZaprBitmapPHOTO(NPicKR, PLN, IDW);
                            zLB = zaprosLB.commandStringTest;
                            commandR.CommandText = zLB;// commandString;
                            commandR.Connection = connectionR;
                            MySqlDataReader readerLB;
                            try
                            {
                            readerLB = commandR.ExecuteReader();
                            while (readerLB.Read())
                            {
                                    if (readerLB["name"].ToString() != "Video")
                                    {
                                        if (readerLB["name"].ToString() == "Image")
                                {
                                    pictureBox43.Image = null;
                                        string st3;
                                        if (Puti[5] == "WIN-D3J6PR1H9QK")
                                        { st3 = readerLB["dataavailable"].ToString(); }
                                        else { st3 = @"" + Puti[2] + "" + readerLB["dataavailable"].ToString().Substring(13, readerLB["dataavailable"].ToString().Length - 13); };
                                       pictureBox43.Image = new Bitmap (@""+st3);
                                }
                                if (readerLB["name"].ToString() == "ImgPlate")
                                {
                                    pictureBox53.Image = null;
                                        string st4;
                                        if (Puti[5] == "WIN-D3J6PR1H9QK")
                                        { st4 = readerLB["dataavailable"].ToString(); }
                                        else { st4 = @"" + Puti[2] + "" + readerLB["dataavailable"].ToString().Substring(13, readerLB["dataavailable"].ToString().Length - 13); };
                                       pictureBox53.Image = new Bitmap(@""+st4);
                                }
                                        if (readerLB["name"].ToString() == "ReaPlate")
                                        {
                                            if (Puti[5] == "WIN-D3J6PR1H9QK")
                                            { st7 = readerLB["dataavailable"].ToString(); }
                                            else { st7 = @"" + Puti[2] + "" + readerLB["dataavailable"].ToString().Substring(13, readerLB["dataavailable"].ToString().Length - 13); }
                                            if (pictureBox53.Image == null)
                                            {
                                                pictureBox53.Image = new Bitmap(@"" + st7);
                                            }
                                        }
                                    }
                                    else
                                    {
                                    }
                                }
                                readerLB.Close();
                            }
                            catch (MySqlException ex)
                            {
                                Console.WriteLine("Error: \r\n{0}", ex.ToString());
                            }
                        }
                         else
                        {
                            zaprosLB.ZaprBitmapPHOTONew(NPicKR, PLN, IDW);
                            zLB = zaprosLB.commandStringTest;
                            commandR.CommandText = zLB;// commandString;
                            commandR.Connection = connectionR;
                            MySqlDataReader readerLB;
                            try
                            {
                                readerLB = commandR.ExecuteReader();
                                while (readerLB.Read())
                                {
                                    if (readerLB["name"].ToString() != "Video")
                                    {
                                        if (readerLB["name"].ToString() == "Image")
                                    {
                                        pictureBox43.Image = null;
                                        string st3;
                                        if (Puti[5] == "WIN-D3J6PR1H9QK")
                                        { st3 = readerLB["dataavailable"].ToString(); }
                                        else { st3 = @"" + Puti[2] + "" + readerLB["dataavailable"].ToString().Substring(13, readerLB["dataavailable"].ToString().Length - 13); };
                                        pictureBox43.Image = new Bitmap(@"" + st3);
                                    }
                                    if (readerLB["name"].ToString() == "ImgPlate")
                                    {
                                        pictureBox53.Image = null;
                                        string st4;
                                        if (Puti[5] == "WIN-D3J6PR1H9QK")
                                        { st4 = readerLB["dataavailable"].ToString(); }
                                        else { st4 = @"" + Puti[2] + "" + readerLB["dataavailable"].ToString().Substring(13, readerLB["dataavailable"].ToString().Length - 13); };
                                        pictureBox53.Image = new Bitmap(@"" + st4);
                                    }
                                        if (readerLB["name"].ToString() == "ReaPlate")
                                        {
                                            if (Puti[5] == "WIN-D3J6PR1H9QK")
                                            { st7 = readerLB["dataavailable"].ToString(); }
                                            else { st7 = @"" + Puti[2] + "" + readerLB["dataavailable"].ToString().Substring(13, readerLB["dataavailable"].ToString().Length - 13); }
                                            if (pictureBox53.Image == null)
                                            {
                                                pictureBox53.Image = new Bitmap(@"" + st7);
                                            }
                                        }
                                    }
                                    else
                                    {
                                    }
                                }
                                readerLB.Close();
                            }
                            catch (MySqlException ex)
                            {
                                Console.WriteLine("Error: \r\n{0}", ex.ToString());
                            }
                        }
                    }
                }
               commandR.Connection.Close();
            }
        }
        #endregion///////////////////////////////////////////// 

        #region/////////////////////////////////////////////   Общ.масса запрос ПДК R
        public void ZObPDKR()
        {
            MySqlCommand command2 = new MySqlCommand();
            ConnectStr conStr2 = new ConnectStr();
            conStr2.ConStr(1);
            Zapros zapros2 = new Zapros();
            string connectionString2;//, commandString;
            connectionString2 = conStr2.StP;//"Data source=localhost;UserId=root;Password=1q2w3e$R;database=camloc;";
            MySqlConnection connection2 = new MySqlConnection(connectionString2);
            zapros2.PDObshMass(KolOsR, TTS);
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
                    double Mo = 0;
                    Mo = (Math.Round(ObshMass / 1000, 2)) - (Math.Round(ObshMass / 1000, 2) / 100 * 5);
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
        
        #region/////////////////////////////////////////////   Осевая масса запрос ПДК R
        public void ZOsPDKR()
        {
            for (ic = 1; ic < KolOsR + 1; ic++)
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
                        if (Convert.ToInt32(TypO[ic]) > 1 && D[ic - 1] == 0)
                        {
                            zapros2.PDOsNagr(Convert.ToInt32(DoubO[ic]), Convert.ToInt32(TypO[ic]), ADNagr, D[ic]);
                        }
                        else if (Convert.ToInt32(TypO[ic]) > 1 && D[ic - 1] <= D[ic])
                        {
                            zapros2.PDOsNagr(Convert.ToInt32(DoubO[ic]), Convert.ToInt32(TypO[ic]), ADNagr, D[ic - 1]);
                        }
                        else if (Convert.ToInt32(TypO[ic]) > 1 && D[ic - 1] > D[ic])
                        {
                            zapros2.PDOsNagr(Convert.ToInt32(DoubO[ic]), Convert.ToInt32(TypO[ic]), ADNagr, D[ic]);
                        }
                        else if (Convert.ToInt32(TypO[ic]) == 1)
                        {
                            if (D[ic] < 250)
                            {
                                D[ic] = 250;
                            }
                            zapros2.PDOsNagr(Convert.ToInt32(DoubO[ic]), Convert.ToInt32(TypO[ic]), ADNagr, D[ic]);
                        }
                    }
                    else { zapros2.PDOsNagr(Convert.ToInt32(DoubO[ic]), Convert.ToInt32(TypO[ic]), ADNagr, D[ic - 1]); }

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
        
        #region////////////////////////////////////////////////// Запоминаем и переходим на № строки а затем пишем сколько записей в дата гриде (ПРАВЫЙ)
        private void timer3_Tick(object sender, EventArgs e) //ПРАВЫЙ
        {
            nKR = nKR + 6;
            dateTimePicker12.Value = DateTime.Now;
            dateTimePicker11.Value = dateTimePicker12.Value.AddSeconds(-nKR);//dateTimePicker8.Value.AddHours(-12);
            dateTimePicker3.Value = dateTimePicker12.Value;
            if (tabControl3.SelectedIndex == 0)
                {
                if (dataGridView11.Rows.Count != 0)
            { RCR = dataGridView11.CurrentCell.RowIndex;
            }
            if (DSR != null)
                DSR.Clear();
                //StopSearchR();
               ZKontrolR("");
                if (dataGridView11.Rows.Count != 0)
                {
                    if (toolStripLabel18.Text != "")
                    {
                        kolR = Convert.ToInt32(toolStripLabel18.Text);
                    }
                    dataGridView11.CurrentCell = dataGridView11[0, RCR];
                    rowIndexR = dataGridView11.SelectedCells[0].RowIndex;
                    if (kolR > rowIndexR)
                    { kolR = 0; }
                    int SumR = 0;
                    for (int i = 0; i < dataGridView11.Rows.Count; i++)
                    {
                        SumR = SumR + 1;// (int)dataGridView8.Rows[i].Cells[0].Value;
                    }
                    if (SumR - kolR < SumR)
                    { kolR = SumR - kolR; }
                    currentRowLeft = rowIndexR + kolR;
                    dataGridView11.CurrentCell = dataGridView11[0, rowIndexR + kolR];
                    toolStripLabel18.Text = "" + (Convert.ToInt32(SumR)).ToString();
                } 
             }
            ////////////////////////////////////////////////////////////////////// И Оформленные
            if (tabControl3.SelectedIndex == 1)
            {
                if (dataGridView10.Rows.Count != 0)
                {
                    RCR = dataGridView10.CurrentCell.RowIndex;
                }
                if (DSR != null)
                    DSR.Clear();
                StopSearchR();
                //ZKontrolR("");
                if (dataGridView10.Rows.Count != 0)
                {
                    if (toolStripLabel18.Text != "")
                    {
                        kolR = Convert.ToInt32(toolStripLabel18.Text);
                    }
                    rowIndexR = dataGridView10.SelectedCells[0].RowIndex;
                    if (kolR > rowIndexR)
                    { kolR = 0; }
                    int SumRO = 0;
                    for (int i = 0; i < dataGridView10.Rows.Count; i++)
                    {
                        SumRO = SumRO + 1;// (int)dataGridView8.Rows[i].Cells[0].Value;
                    }
                    if (SumRO - kolR < SumRO)
                    { kolR = SumRO - kolR; }
                    currentRowLeft = rowIndexR + kolR;
                    dataGridView10.CurrentCell = dataGridView10[0, rowIndexR + kolR];
                    toolStripLabel18.Text = "" + (Convert.ToInt32(SumRO)).ToString();
                }
            }
                ////////////////////////////////////////////////////////////////////////////////////
                Otrisovka3();
        }
        #endregion/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        #region// Делаем фильтр и все ссылк к нему (Правая часть) ////////////////////////)
        private void StopSearchR()
        {
            if (Napr3[1] == null) {Napr3[0] = ""; Napr3[1] = ""; Napr3[2] = ""; Napr3[3] = ""; }
            if (timer3.Enabled == true)
            {
                dateTimePicker11.Value = DateTime.Now;
                dateTimePicker12.Value = dateTimePicker10.Value.AddDays(-1);//.AddHours(-1);
            }
            else
            {
                dateTimePicker11.Value = dateTimePicker4.Value;//Convert.ToDateTime("28.04.2018 00:00:00");//
                dateTimePicker12.Value = dateTimePicker3.Value;//Convert.ToDateTime("28.04.2018 13:00:00");
            }

            //dateTimePicker11.Value = dateTimePicker4.Value;
            //dateTimePicker12.Value = dateTimePicker3.Value;
            string TXTFLEFT = "";
            TXTFLEFT = " WHERE  Created >= '" + dateTimePicker11.Value.ToString("yyyyMMddHHmmss") + "' and Created <= '" + dateTimePicker12.Value.ToString("yyyyMMddHHmmss") + "'";
            if (textBox6.Text != "")
            {
                TXTFLEFT = TXTFLEFT + " and Plate LIKE '%" + textBox6.Text + "%'";
            }
            /////////////////////////////////////// по классу
            if (flags3 == null) { flags3 = new Boolean[55]; }
            if (flags3[5] == false && flags3[6] == false && flags3[7] == false && flags3[8] == false && flags3[9] == false && flags3[10] == false && flags3[11] == false && flags3[12] == false && flags3[13] == false && flags3[14] == false && flags3[15] == false && flags3[16] == false && flags3[17] == false)
            { }
            else
            {
                if (flags3[5] == true)
                { TXTFLEFT = TXTFLEFT + " AND (IF(CHAR_LENGTH(allandnapr.Class2)>3 ,SUBSTR(allandnapr.Class2, 1, 2), IF(CHAR_LENGTH(allandnapr.Class2)<=1 ,0,SUBSTR(allandnapr.Class2, 1, 1))) = 1"; }
                else if (flags3[5] == false)
                { TXTFLEFT = TXTFLEFT + " AND (IF(CHAR_LENGTH(allandnapr.Class2)>3 ,SUBSTR(allandnapr.Class2, 1, 2), IF(CHAR_LENGTH(allandnapr.Class2)<=1 ,0,SUBSTR(allandnapr.Class2, 1, 1))) = 17"; }

                for (int ifk = 6; ifk < 17; ifk++)
                {
                    if (flags3[ifk] == true)
                    { TXTFLEFT = TXTFLEFT + " OR IF(CHAR_LENGTH(allandnapr.Class2)>3 ,SUBSTR(allandnapr.Class2, 1, 2), IF(CHAR_LENGTH(allandnapr.Class2)<=1 ,0,SUBSTR(allandnapr.Class2, 1, 1))) = " + (ifk - 4); }
                    else if (flags3[ifk] == false)
                    {/* TXTFLEFT = TXTFLEFT + " OR Cl12 = 0"; */}
                }
                if (flags3[17] == true)
                { TXTFLEFT = TXTFLEFT + " OR IF(CHAR_LENGTH(allandnapr.Class2)>3 ,SUBSTR(allandnapr.Class2, 1, 2), IF(CHAR_LENGTH(allandnapr.Class2)<=1 ,0,SUBSTR(allandnapr.Class2, 1, 1))) = 12)"; }
                else if (flags3[17] == false)
                { TXTFLEFT = TXTFLEFT + ")"; }
            }
           
                flags3[0] = true; flags3[1] = true; flags3[3] = true; flags3[4] = true;
           
            if (flags3[0] == true)
            { TXTFLEFT = TXTFLEFT + " AND (IsOverweightGross = 1"; }

            if (flags3[1] == true)
            {
                if (flags3[0] == true)
                { TXTFLEFT = TXTFLEFT + " OR IsOverweightPartial = 1"; }
                else
                { TXTFLEFT = TXTFLEFT + " AND (IsOverweightPartial = 1"; }
            }

            if (flags3[3] == true)
            {
                if (flags3[0] == true)
                { TXTFLEFT = TXTFLEFT + " OR IsOverweightGroup = 1"; }
                else
                {
                    if (flags3[1] == true)
                    { TXTFLEFT = TXTFLEFT + " OR IsOverweightGroup = 1"; }
                    else
                    { TXTFLEFT = TXTFLEFT + " AND (IsOverweightGroup = 1"; }
                }
            }

            if (flags3[4] == true)
            {
                if (flags3[0] == true)
                { TXTFLEFT = TXTFLEFT + " OR IsExceededLength = 1)"; }
                else
                {
                    if (flags3[1] == true)
                    { TXTFLEFT = TXTFLEFT + " OR IsExceededLength = 1)"; }
                    else
                    {
                        if (flags3[3] == true)
                        { TXTFLEFT = TXTFLEFT + " OR IsExceededLength = 1)"; }
                        else
                        { TXTFLEFT = TXTFLEFT + " AND IsExceededLength = 1"; }
                    }
                }
            }
            else
            {
                if (flags3[0] == true)
                { TXTFLEFT = TXTFLEFT + ")"; }
                else
                {
                    if (flags3[1] == true)
                    { TXTFLEFT = TXTFLEFT + ")"; }
                    else
                    {
                        if (flags3[3] == true)
                        { TXTFLEFT = TXTFLEFT + ")"; }
                    }
                }
            }

            if (tabControl3.SelectedIndex == 0)
            {
                TXTFLEFT = TXTFLEFT + " AND ( ChangeType <> 4)  AND Credence > 0 ";
            }
            if (tabControl3.SelectedIndex == 1)
            {
                TXTFLEFT = TXTFLEFT + " AND ( ChangeType = 4) AND Credence > 0 ";
            }

            if (flags3[18] == true)
            { TXTFLEFT = TXTFLEFT + " AND (( Plate LIKE '' or Plate is null )"; }
            if (flags3[19] == true)
            {
                if (flags3[18] == true)
                { TXTFLEFT = TXTFLEFT + " or CredenceExceeded > 0"; }
                else
                { TXTFLEFT = TXTFLEFT + " AND ( CredenceExceeded > 0"; }
            }
            if (flags3[20] == true)
            {
                if (flags3[19] == true || flags3[18] == true)
                { TXTFLEFT = TXTFLEFT + " or AxleCount < 1"; }
                else { TXTFLEFT = TXTFLEFT + " AND ( AxleCount < 1"; }
            }
            if (flags3[21] == true)
            {
                if (flags3[19] == true || flags3[18] == true || flags3[20] == true)
                { TXTFLEFT = TXTFLEFT + " or ClassScheme3 < 3"; }
                else { TXTFLEFT = TXTFLEFT + " AND ( ClassScheme3 < 3"; }
            }
            if (flags3[19] == true || flags3[18] == true || flags3[20] == true || flags3[21] == true)
            { TXTFLEFT = TXTFLEFT + ")"; }

            if (Napr3[0].ToString() == "Все" || Napr3[0].ToString() == "")
            {/* TXTFLEFT = TXTFLEFT + " AND (PlatformId = 2952855555 OR PlatformId = 2952855553)";*/ }
            else if (Napr3[0].ToString() == "РК-1")
            { TXTFLEFT = TXTFLEFT + " AND PlatformId = 2952855553"; }
            else if (Napr3[0].ToString() == "РК-2")
            { TXTFLEFT = TXTFLEFT + " AND PlatformId = 2952855555"; }

            if (Napr3[1].ToString() == "Все" || Napr3[1].ToString() == "")
            { /*TXTFLEFT = TXTFLEFT + " AND (namead =  '67-ОП-РЗ-67Р-01' OR namead = '67-ОП-РЗ-67К-14')"*/; }
            else if (Napr3[1].ToString() == "67-ОП-РЗ-67Р-01")
            { TXTFLEFT = TXTFLEFT + " AND namead = '67-ОП-РЗ-67Р-01'"; }
            else if (Napr3[1].ToString() == "67-ОП-РЗ-67К-14")
            { TXTFLEFT = TXTFLEFT + " AND namead = '67-ОП-РЗ-67К-14'"; }

            if (Napr3[2].ToString() == "Все" || Napr3[2].ToString() == "")
            { /*TXTFLEFT = TXTFLEFT + " AND (namenapr =  'из Севастополя' OR namenapr = 'в Севастополь')";*/ }
            else if (Napr3[2].ToString() == "из Севастополя")
            { TXTFLEFT = TXTFLEFT + " AND namenapr = 'из Севастополя'"; }
            else if (Napr3[2].ToString() == "в Севастополь")
            { TXTFLEFT = TXTFLEFT + " AND namenapr = 'в Севастополь'"; }

            if (Napr3[3].ToString() == "Все" || Napr3[3].ToString() == "")
            {/* TXTFLEFT = TXTFLEFT + " AND (Lane =  1 OR Lane = 2)"; */}
            else if (Napr3[3].ToString() == "1")
            { TXTFLEFT = TXTFLEFT + " AND Lane =  1"; }
            else if (Napr3[3].ToString() == "2")
            { TXTFLEFT = TXTFLEFT + " AND Lane =  2"; }

            if (flags3[27] == true)
            { TXTFLEFT = TXTFLEFT + " AND NameUs = 'AUTO'"; }
            if (flags3[28] == true)
            { TXTFLEFT = TXTFLEFT + " AND NameUs  NOT LIKE 'AUTO'"; }

            if (flags3[29] == false && flags3[30] == false && flags3[31] == false && flags3[32] == false && flags3[33] == false && flags3[34] == false && flags3[35] == false && flags3[36] == false)
            { }
            else
            {
                if (flags3[29] == true)
                { TXTFLEFT = TXTFLEFT + " AND (allandnapr.AxleCount <= 2"; }
                else if (flags3[29] == false)
                { TXTFLEFT = TXTFLEFT + " AND (allandnapr.AxleCount = 28"; }

                for (int ifk = 30; ifk < 36; ifk++)
                {
                    if (flags3[ifk] == true)
                    { TXTFLEFT = TXTFLEFT + " OR allandnapr.AxleCount = " + (ifk - 27); }
                    else if (flags3[ifk] == false)
                    {/* TXTFLEFT = TXTFLEFT + " OR Cl12 = 0"; */}
                }
                if (flags3[36] == true)
                { TXTFLEFT = TXTFLEFT + " OR allandnapr.AxleCount >= 9 )"; }
                else if (flags3[36] == false)
                { TXTFLEFT = TXTFLEFT + ")"; }
            }

            if (flags3[37] == false && flags3[38] == false && flags3[39] == false && flags3[40] == false && flags3[41] == false && flags3[42] == false && flags3[43] == false && flags3[44] == false)
            { }
            else
            {
                if (flags3[37] == true)
                { TXTFLEFT = TXTFLEFT + " AND (allandnapr.Weight <= 3.5"; }
                else if (flags3[37] == false)
                { TXTFLEFT = TXTFLEFT + " AND (allandnapr.Weight = 280"; }

                if (flags3[38] == true)
                { TXTFLEFT = TXTFLEFT + " OR (allandnapr.Weight > 3.5 and allandnapr.Weight <= 5 )"; }
                else if (flags3[38] == false)
                {/* TXTFLEFT = TXTFLEFT + " OR Cl12 = 0"; */}
                if (flags3[39] == true)
                { TXTFLEFT = TXTFLEFT + " OR (allandnapr.Weight > 5 and allandnapr.Weight <= 10 )"; }
                else if (flags3[39] == false)
                {/* TXTFLEFT = TXTFLEFT + " OR Cl12 = 0"; */}
                if (flags3[40] == true)
                { TXTFLEFT = TXTFLEFT + " OR (allandnapr.Weight > 10 and allandnapr.Weight <= 20 )"; }
                else if (flags3[40] == false)
                {/* TXTFLEFT = TXTFLEFT + " OR Cl12 = 0"; */}
                if (flags3[41] == true)
                { TXTFLEFT = TXTFLEFT + " OR (allandnapr.Weight > 20 and allandnapr.Weight <= 30 )"; }
                else if (flags3[41] == false)
                {/* TXTFLEFT = TXTFLEFT + " OR Cl12 = 0"; */}
                if (flags3[42] == true)
                { TXTFLEFT = TXTFLEFT + " OR (allandnapr.Weight > 30 and allandnapr.Weight <= 50 )"; }
                else if (flags3[42] == false)
                {/* TXTFLEFT = TXTFLEFT + " OR Cl12 = 0"; */}
                if (flags3[43] == true)
                { TXTFLEFT = TXTFLEFT + " OR (allandnapr.Weight > 50 and allandnapr.Weight <= 70 )"; }
                else if (flags3[43] == false)
                {/* TXTFLEFT = TXTFLEFT + " OR Cl12 = 0"; */}

                if (flags3[44] == true)
                { TXTFLEFT = TXTFLEFT + " OR allandnapr.Weight > 70 )"; }
                else if (flags3[44] == false)
                { TXTFLEFT = TXTFLEFT + ")"; }

            }

            if (flags3[45] == false && flags3[46] == false && flags3[47] == false && flags3[48] == false)
            { }
            else
            {
                if (flags3[45] == true)
                { TXTFLEFT = TXTFLEFT + " AND (allandnapr.Length <= 5"; }
                else if (flags3[45] == false)
                { TXTFLEFT = TXTFLEFT + " AND (allandnapr.Length = 280"; }

                if (flags3[46] == true)
                { TXTFLEFT = TXTFLEFT + " OR (allandnapr.Length > 5 and allandnapr.Length <= 12 )"; }
                else if (flags3[46] == false)
                {/* TXTFLEFT = TXTFLEFT + " OR Cl12 = 0"; */}
                if (flags3[47] == true)
                { TXTFLEFT = TXTFLEFT + " OR (allandnapr.Length > 12 and allandnapr.Length <= 20 )"; }
                else if (flags3[47] == false)
                {/* TXTFLEFT = TXTFLEFT + " OR Cl12 = 0"; */}

                if (flags3[48] == true)
                { TXTFLEFT = TXTFLEFT + " OR allandnapr.Length > 20 )"; }
                else if (flags3[44] == false)
                { TXTFLEFT = TXTFLEFT + ")"; }
            }

            if (flags3[49] == false && flags3[50] == false && flags3[51] == false && flags3[52] == false && flags3[53] == false)
            { }
            else
            {
                if (flags3[49] == true)
                { TXTFLEFT = TXTFLEFT + " AND (allandnapr.Speed < 50"; }
                else if (flags3[49] == false)
                { TXTFLEFT = TXTFLEFT + " AND (allandnapr.Speed = 280"; }

                if (flags3[50] == true)
                { TXTFLEFT = TXTFLEFT + " OR (allandnapr.Speed >= 50 and allandnapr.Speed <= 60 )"; }
                else if (flags3[50] == false)
                {/* TXTFLEFT = TXTFLEFT + " OR Cl12 = 0"; */}
                if (flags3[51] == true)
                { TXTFLEFT = TXTFLEFT + " OR (allandnapr.Speed > 60 and allandnapr.Speed <= 70 )"; }
                else if (flags3[51] == false)
                {/* TXTFLEFT = TXTFLEFT + " OR Cl12 = 0"; */}
                if (flags3[52] == true)
                { TXTFLEFT = TXTFLEFT + " OR (allandnapr.Speed > 70 and allandnapr.Speed <= 90 )"; }
                else if (flags3[52] == false)
                {/* TXTFLEFT = TXTFLEFT + " OR Cl12 = 0"; */}

                if (flags3[53] == true)
                { TXTFLEFT = TXTFLEFT + " OR allandnapr.Speed > 90 )"; }
                else if (flags3[53] == false)
                { TXTFLEFT = TXTFLEFT + ")"; }
            }
            //AND allandnapr.AxleCount = 3 AND Length > 5 AND Weight > 20 AND Speed > 85

            TXTFLEFT = TXTFLEFT + " ORDER BY Created DESC LIMIT " + textBox13.Text + ";";

            flags3 = flags;
            if (textBox6.Text != "")
            {
                if (tabControl3.SelectedIndex == 0)
                {
                    if (DSR != null)
                        DSR.Clear();
                    ZKontrolR(TXTFLEFT);
                }
                if (tabControl3.SelectedIndex == 1)
                {
                    if (DSROF != null)
                        DSROF.Clear();
                    ZKontrolROF(TXTFLEFT);
                }
            }
            else
            {
                if (tabControl3.SelectedIndex == 0)
                {
                    if (DSR != null)
                    DSR.Clear();
                ZKontrolR(TXTFLEFT);
                }
                if (tabControl3.SelectedIndex == 1)
                {
                    if (DSROF != null)
                        DSROF.Clear();
                    ZKontrolROF(TXTFLEFT);
                    toolStripLabel22.Text = dataGridView10.RowCount.ToString();
                }
            }

            if (toolStripLabel18.Text != "")
            {
                kolR = Convert.ToInt32(toolStripLabel18.Text);
            }
            if (tabControl3.SelectedIndex == 0)
            {
                if (dataGridView11.RowCount > 0)
                {
                    rowIndexR = dataGridView11.SelectedCells[0].RowIndex;
                    if (kolR > rowIndexR)
                    { kolR = 0; }
                    int SumR = 0;
                    for (int i = 0; i < dataGridView11.Rows.Count; i++)
                    {
                        SumR = SumR + 1;
                    }
                    if (SumR - kolR < SumR)
                    { kolR = SumR - kolR; }
                    dataGridView11.CurrentCell = dataGridView11[0, rowIndexR + kolR];
                    currentRowLeft = rowIndexR + kolR;
                    toolStripLabel18.Text = "" + (Convert.ToInt32(SumR)).ToString();
                    Otrisovka3();
                }
                else
                {
                    if (DSR != null)
                        DSR.Clear();
                    ZKontrolR("");
                }
            }
                if (tabControl3.SelectedIndex == 1)
                {
                if (dataGridView10.RowCount > 0)
                {
                    rowIndexR = dataGridView10.SelectedCells[0].RowIndex;
                    if (kolR > rowIndexR)
                    { kolR = 0; }
                    int SumR = 0;
                    for (int i = 0; i < dataGridView10.Rows.Count; i++)
                    {
                        SumR = SumR + 1;
                    }
                    if (SumR - kolR < SumR)
                    { kolR = SumR - kolR; }
                    dataGridView10.CurrentCell = dataGridView10[1, rowIndexR + kolR];
                    currentRowLeft = rowIndexR + kolR;
                    toolStripLabel18.Text = "" + (Convert.ToInt32(SumR)).ToString();
                }
                else
                {
                    if (DSROF != null)
                        DSROF.Clear();
                    ZKontrolROF("");
                }
                }
                label124.Text = "ЗАПИСИ УДОВЛЕТВОРЯЮЩИЕ ЗАПРОСУ НЕ НАЙДЕНЫ";
            }
        #endregion ////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void Otrisovka3()//раскраска ячеек
        {
            if (tabControl3.SelectedIndex == 0)
            { //||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
                foreach (DataGridViewRow row in dataGridView11.Rows) //цикл             
                {
                    if (Convert.ToBoolean(row.Cells[10].Value.ToString()) == true)//days > 9000)
                    {
                        row.Cells[0].Style.BackColor = System.Drawing.Color.LightPink;
                        row.Cells[1].Style.BackColor = System.Drawing.Color.LightPink;
                        row.Cells[2].Style.BackColor = System.Drawing.Color.LightPink;
                        row.Cells[3].Style.BackColor = System.Drawing.Color.LightPink;
                        row.Cells[20].Style.BackColor = System.Drawing.Color.LightPink;
                        row.Cells[5].Style.BackColor = System.Drawing.Color.LightPink;
                        row.Cells[6].Style.BackColor = System.Drawing.Color.LightPink;
                        row.Cells[7].Style.BackColor = System.Drawing.Color.LightPink;
                        row.Cells[8].Style.BackColor = System.Drawing.Color.LightPink;
                        row.Cells[4].Style.BackColor = System.Drawing.Color.LightPink;
                    }
                    if (Convert.ToBoolean(row.Cells[11].Value.ToString()) == true)//days > 9000)
                    {
                        row.Cells[0].Style.BackColor = System.Drawing.Color.LightPink;
                        row.Cells[1].Style.BackColor = System.Drawing.Color.LightPink;
                        row.Cells[2].Style.BackColor = System.Drawing.Color.LightPink;
                        row.Cells[3].Style.BackColor = System.Drawing.Color.LightPink;
                        row.Cells[20].Style.BackColor = System.Drawing.Color.LightPink;
                        row.Cells[5].Style.BackColor = System.Drawing.Color.LightPink;
                        row.Cells[6].Style.BackColor = System.Drawing.Color.LightPink;
                        row.Cells[7].Style.BackColor = System.Drawing.Color.LightPink;
                        row.Cells[8].Style.BackColor = System.Drawing.Color.LightPink;
                        row.Cells[4].Style.BackColor = System.Drawing.Color.LightPink;
                    }
                    if (Convert.ToBoolean(row.Cells[12].Value.ToString()) == true)//days > 9000)
                    {
                        row.Cells[0].Style.BackColor = System.Drawing.Color.LightPink;
                        row.Cells[1].Style.BackColor = System.Drawing.Color.LightPink;
                        row.Cells[2].Style.BackColor = System.Drawing.Color.LightPink;
                        row.Cells[3].Style.BackColor = System.Drawing.Color.LightPink;
                        row.Cells[20].Style.BackColor = System.Drawing.Color.LightPink;
                        row.Cells[5].Style.BackColor = System.Drawing.Color.LightPink;
                        row.Cells[6].Style.BackColor = System.Drawing.Color.LightPink;
                        row.Cells[7].Style.BackColor = System.Drawing.Color.LightPink;
                        row.Cells[8].Style.BackColor = System.Drawing.Color.LightPink;
                        row.Cells[4].Style.BackColor = System.Drawing.Color.LightPink;
                    }
                    if (Convert.ToBoolean(row.Cells[13].Value.ToString()) == true)//days > 9000)
                    {
                        row.Cells[0].Style.BackColor = System.Drawing.Color.LightPink;
                        row.Cells[1].Style.BackColor = System.Drawing.Color.LightPink;
                        row.Cells[2].Style.BackColor = System.Drawing.Color.LightPink;
                        row.Cells[3].Style.BackColor = System.Drawing.Color.LightPink;
                        row.Cells[20].Style.BackColor = System.Drawing.Color.LightPink;
                        row.Cells[5].Style.BackColor = System.Drawing.Color.LightPink;
                        row.Cells[6].Style.BackColor = System.Drawing.Color.LightPink;
                        row.Cells[7].Style.BackColor = System.Drawing.Color.LightPink;
                        row.Cells[8].Style.BackColor = System.Drawing.Color.LightPink;
                        row.Cells[4].Style.BackColor = System.Drawing.Color.LightPink;
                    }
                    else
                    {
                    }
                    // |||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
                }
            }

        }

        private void dataGridView11_CellEnter(object sender, DataGridViewCellEventArgs e)
        {            
                int currentRowROF = dataGridView10.CurrentRow.Index; // номер строки, по которой кликнули
            alphaBlendTextBox10.Text = dataGridView10[0, currentRowROF].Value.ToString(); //ID
            alphaBlendTextBox6.Text = dataGridView10[2, currentRowROF].Value.ToString();
            alphaBlendTextBox9.Text = dataGridView10[1, currentRowROF].Value.ToString().Substring(0, 10);
            TSh11 = "";
            ZagrdataGridView10(Convert.ToInt32(alphaBlendTextBox10.Text));
            int i1 = 0;
            int i2 = 0;
            int cnt = 0;
            TipoS11 = "";
            for (i1 = 0; i1 < 9; i1++)
            {
                if (i1 > 0)
                {
                    if (KN[0, i1] != KN[0, i1 - 1])
                    {
                        KN[1, i1 - 1] = cnt;
                        cnt = 0;
                    }
                }
                cnt = cnt + 1;
            }
            for (i1 = 0; i1 < 9; i1++)
            {
                if (KN[1, i1] > 0)
                {
                    TipoS11 = TipoS11 + KN[1, i1].ToString() + "+";
                }
            }
            if (TipoS11 != "")
            {
                TipoS11 = TipoS11.Remove(TipoS11.Length - 1, 1);
            }
            alphaBlendTextBox38.Text = TipoS;
        }
        #region /////////////////////////////////////////////////////////// ЗЗГРУЗКА ПРАВАЯ
        public void ZagrPrav()
        {
            Zapros zaprosR = new Zapros();
            COsR = KolOsR;
            D1R = dateTimePicker11.Value.ToString("yyyy.MM.dd HH:mm:ss");
            D2R = dateTimePicker12.Value.ToString("yyyy.MM.dd HH:mm:ss");
            zaprosR.ZaprAllCamNaprL(0, D1R, D2R, 100);
            zR = zaprosR.commandStringTest;
            mySqlDataAdapterR = new MySqlDataAdapter(zR, connectionAD); //R);
            mySqlDataAdapterR.Fill(DSR);
            dataGridView11.DataSource = DSR.Tables[0];
            ss = 0;
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
            ////////////////////////////////////////////////////////////////////// И вкладку ОФОРМЛЕННЫЕ
            dataGridView10.DataSource = DSR.Tables[0];
            ss = 0;
            for (ss = 1; ss < 12; ss++)
            { dataGridView10.Columns[ss].Visible = false; }
            ss = 0;
            for (ss = 14; ss < 20; ss++)
            { dataGridView10.Columns[ss].Visible = false; }
            dataGridView10.Columns[21].Visible = false;
            ss = 0;
            for (ss = 23; ss < 28; ss++)
            { dataGridView10.Columns[ss].Visible = false; }
            ss = 0;
            for (ss = 29; ss < 35; ss++)
            { dataGridView10.Columns[ss].Visible = false; }
            for (ss = 36; ss < 38; ss++)
            { dataGridView10.Columns[ss].Visible = false; }
            ss = 0;
            for (ss = 39; ss < 90; ss++)
            { dataGridView10.Columns[ss].Visible = false; }
            dataGridView10.Refresh();
            ss = 0;
            for (ss = 92; ss < 201; ss++)
            { dataGridView10.Columns[ss].Visible = false; }
            dataGridView10.Refresh();
            /////////////////////////////////////////////////////////////////////////////////////////////
            ////connection.Close();
            DataView dvR;
            dvR = new DataView(DSR.Tables[0], "Created >= '" + dateTimePicker11.Value + "' and Created <= '" + dateTimePicker12.Value + "' AND (IsOverweightGross>0 OR IsOverweightPartial>0 OR IsExceededLength>0 OR IsOverspeed>0 OR Plate='') ", "", DataViewRowState.CurrentRows);
            dataGridView11.DataSource = dvR;

            DataView dvRO;
            dvRO = new DataView(DSR.Tables[0], "Created >= '" + dateTimePicker11.Value + "' and Created <= '" + dateTimePicker12.Value + "' and `Change` = 4 AND (IsOverweightGross>0 OR IsOverweightPartial>0 OR IsExceededLength>0 OR IsOverspeed>0 OR Plate='')", "", DataViewRowState.CurrentRows);
            dataGridView10.DataSource = dvRO;
           
            timer3.Enabled = true;
        }
        #endregion ////////////////////////////////////////////////////////////////////////////////

        private void Form2_Shown(object sender, EventArgs e)
        {
            if (((strus[1]) != "") && (Convert.ToInt32(strus[1]) > 0))
            {
                ZMonitor("");
            }
            else if (((strus[6]) != "") && (Convert.ToInt32(strus[6]) > 0))
            {
                ZKontrolL("");
                ZKontrolR("");
            }
              
                if (((strus[4]) != "") && (Convert.ToInt32(strus[4]) > 0))
            {
                TabUs();
            }
        }
        #region /////////////////////////////////////////////////////////////////// регистрация пользователя
        private void dataGridView7_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

            int currentRow = dataGridView7.CurrentRow.Index; // номер строки, по которой кликнули
            textBoxID.Text = dataGridView7[0, currentRow].Value.ToString(); //ID
            textBoxLog.Text = dataGridView7[1, currentRow].Value.ToString(); //ID
            textBoxPass.Text = dataGridView7[2, currentRow].Value.ToString();
            textBox1.Text = dataGridView7[15, currentRow].Value.ToString();
            textBox2.Text = dataGridView7[16, currentRow].Value.ToString();
            textBox3.Text = dataGridView7[17, currentRow].Value.ToString();
            textBox4.Text = dataGridView7[18, currentRow].Value.ToString();
            textBox5.Text = dataGridView7[19, currentRow].Value.ToString();
            textBox8.Text = dataGridView7[20, currentRow].Value.ToString();
            if (dataGridView7[5, currentRow].Value.ToString() == "0")
            { checkBox2.Checked = false; }
            else
            { checkBox2.Checked = true; }
            if (dataGridView7[6, currentRow].Value.ToString() == "0")
            { checkBox3.Checked = false; }
            else
            { checkBox3.Checked = true; }
            if (dataGridView7[7, currentRow].Value.ToString() == "0")
            { checkBox4.Checked = false; }
            else
            { checkBox4.Checked = true; }
            if (dataGridView7[8, currentRow].Value.ToString() == "0")
            { checkBox8.Checked = false; }
            else
            { checkBox8.Checked = true; }
            if (dataGridView7[9, currentRow].Value.ToString() == "0")
            { checkBox7.Checked = false; }
            else
            { checkBox7.Checked = true; }
            if (dataGridView7[10, currentRow].Value.ToString() == "0")
            { checkBox5.Checked = false; }
            else
            { checkBox5.Checked = true; }
            if (dataGridView7[11, currentRow].Value.ToString() == "0")
            { checkBox12.Checked = false; }
            else
            { checkBox12.Checked = true; }
            if (dataGridView7[12, currentRow].Value.ToString() == "0")
            { checkBox13.Checked = false; }
            else
            { checkBox13.Checked = true; }
            if (dataGridView7[21, currentRow].Value.ToString() == "0")
            { checkBox1.Checked = false; }
            else
            { checkBox1.Checked = true; }
            if (dataGridView7[22, currentRow].Value.ToString() == "0")
            { checkBox6.Checked = false; }
            else
            { checkBox6.Checked = true; }
            if (dataGridView7[23, currentRow].Value.ToString() == "0")
            { checkBox14.Checked = false; }
            else
            { checkBox14.Checked = true; }
        }
        private void button25_Click(object sender, EventArgs e)
        {
            Us = new string[25];
            if (IDUB == 0)
            {
                Button btn = sender as Button;
                btn.Text = "Добавить нового пользователя";
                IDUB = 1;
                Us[1] = textBoxLog.Text.ToString(); //ID
                Us[2] = textBoxPass.Text.ToString();
                Us[3] = textBox1.Text.ToString();
                Us[4] = textBox2.Text.ToString();
                Us[5] = textBox3.Text.ToString();
                Us[6] = textBox4.Text.ToString();
                Us[7] = textBox5.Text.ToString();
                Us[8] = textBox8.Text.ToString();
                if (checkBox2.Checked == true) { Us[9] = "1"; }
                else { Us[9] = "0"; }
                if (checkBox3.Checked == true) { Us[10] = "1"; }
                else { Us[10] = "0"; }
                if (checkBox4.Checked == true) { Us[11] = "1"; }
                else { Us[11] = "0"; }
                if (checkBox8.Checked == true) { Us[12] = "1"; }
                else { Us[12] = "0"; }
                if (checkBox7.Checked == true) { Us[13] = "1"; }
                else { Us[13] = "0"; }
                if (checkBox5.Checked == true) { Us[14] = "1"; }
                else { Us[14] = "0"; }
                if (checkBox12.Checked == true) { Us[15] = "1"; }
                else { Us[15] = "0"; }
                if (checkBox13.Checked == true) { Us[16] = "1"; }
                else { Us[16] = "0"; }
                if (checkBox1.Checked == true) { Us[19] = "1"; }
                else { Us[19] = "0"; }
                if (checkBox6.Checked == true) { Us[20] = "1"; }
                else { Us[20] = "0"; }
                Us[17] = "0";
                Us[18] = "0";
                if (checkBox14.Checked == true) { Us[21] = "1"; }
                else { Us[21] = "0"; }
                if (dataGridView7.Rows.Count != 0)
                {
                    R1 = 0;
                    R1 = dataGridView7.Rows.Count;
                }
                UsUpd AddU = new UsUpd();
                AddU.butAdd(Us);
                DSU = new DataSet();
                TabUs();
                if (R1 > 0)
                { dataGridView7.CurrentCell = dataGridView7[1, R1 - 1]; }
                else if (R1 == 0)
                { dataGridView7.CurrentCell = dataGridView7[1, R1]; }
            }
            else if (IDUB == 1)
            {
                Button btn = sender as Button;
                btn.Text = "Сохранить пользователя";
                IDUB = 0;
                textBoxID.Text = ""; //ID
                textBoxLog.Text = ""; //ID
                textBoxPass.Text = "";
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox8.Text = "";
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                checkBox7.Checked = false;
                checkBox8.Checked = false;
                checkBox12.Checked = false;
                checkBox13.Checked = false;
                checkBox1.Checked = false;
                checkBox6.Checked = false;
                checkBox14.Checked = false;
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            Us = new string[25];
            Us[0] = textBoxID.Text.ToString(); //ID
            Us[1] = textBoxLog.Text.ToString(); //ID
            Us[2] = textBoxPass.Text.ToString();
            Us[3] = textBox1.Text.ToString();
            Us[4] = textBox2.Text.ToString();
            Us[5] = textBox3.Text.ToString();
            Us[6] = textBox4.Text.ToString();
            Us[7] = textBox5.Text.ToString();
            Us[8] = textBox8.Text.ToString();
            if (checkBox2.Checked == true) { Us[9] = "1"; }
            else { Us[9] = "0"; }
            if (checkBox3.Checked == true) { Us[10] = "1"; }
            else { Us[10] = "0"; }
            if (checkBox4.Checked == true) { Us[11] = "1"; }
            else { Us[11] = "0"; }
            if (checkBox8.Checked == true) { Us[12] = "1"; }
            else { Us[12] = "0"; }
            if (checkBox7.Checked == true) { Us[13] = "1"; }
            else { Us[13] = "0"; }
            if (checkBox5.Checked == true) { Us[14] = "1"; }
            else { Us[14] = "0"; }
            if (checkBox12.Checked == true) { Us[15] = "1"; }
            else { Us[15] = "0"; }
            if (checkBox13.Checked == true) { Us[16] = "1"; }
            else { Us[16] = "0"; }
            if (checkBox1.Checked == true) { Us[19] = "1"; }
            else { Us[19] = "0"; }
            if (checkBox6.Checked == true) { Us[20] = "1"; }
            else { Us[20] = "0"; }
            Us[17] = "0";
            Us[18] = "0";
            if (checkBox14.Checked == true) { Us[21] = "1"; }
            else { Us[21] = "0"; }
            if (dataGridView7.Rows.Count != 0)
            {
                R1 = 0;
                R1 = dataGridView7.CurrentCell.RowIndex; ;
            }
            UsUpd AddU = new UsUpd();
            AddU.butUP(Us);
            DSU = new DataSet();
            TabUs();
            dataGridView7.CurrentCell = dataGridView7[1, R1];
        }

        private void button23_Click(object sender, EventArgs e)
        {
            {
                R1 = 0;
                R1 = dataGridView7.CurrentCell.RowIndex;
            }
            int IDUs = Convert.ToInt32(textBoxID.Text.ToString());
            DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить выбранного Вами пользователя? \n (Пользователь будет удален окончательно без возможности восстановления)", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            { }
            if (result == DialogResult.Yes)
            {
                ConnectStr conStrU = new ConnectStr();
                Zapros zaprosU = new Zapros();
                conStrU.ConStr(1);
                cstrU = conStrU.StP;
                MySql.Data.MySqlClient.MySqlConnection sqlConnectionT = new MySql.Data.MySqlClient.MySqlConnection(cstrU);
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
                cmd.CommandText = "DELETE " +
                        " FROM raptuser " +
                        "WHERE iduser = " + IDUs;
                cmd.Connection = sqlConnectionT;
                sqlConnectionT.Open();
                cmd.ExecuteNonQuery();
                sqlConnectionT.Close();
                DSU = new DataSet();
                TabUs();
                if (R1 > 0)
                { dataGridView7.CurrentCell = dataGridView7[1, R1 - 1]; }
                else if (R1 == 0)
                { dataGridView7.CurrentCell = dataGridView7[1, R1]; }
            }
        }
       private void checkBox4_Click(object sender, EventArgs e)
        {
            if(checkBox4.Checked==true)
            { checkBox1.Checked = true; }
            else { checkBox1.Checked = false; checkBox6.Checked = false; }
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = true;
if (checkBox1.Checked==true || checkBox6.Checked==true)
            { checkBox4.Checked = true; }
else { checkBox4.Checked = false;  }
        }
        private void checkBox6_Click(object sender, EventArgs e)
        {            
            if (checkBox1.Checked == true || checkBox6.Checked == true)
            { checkBox4.Checked = true; }
            else { checkBox4.Checked = false; }
        }
      private void checkBox12_Click(object sender, EventArgs e) //////////////Карточка проезда
        {
            //if (checkBox12.Checked == true)
            //{ checkBox14.Visible = true; }
            //else { checkBox14.Checked = false; checkBox14.Visible = false; }
        }
        #endregion ///////////////////////////////////////////////////////////////////////////
                
        #region /////////////////////////////////////// ЗАГРУЗКА КлассаТС ///////////////////////////////////////////////////////  
        public void ZagrKlass(int IDKL)
        {
            ConnectStr conStrKL = new ConnectStr();
            Zapros zaprosKL = new Zapros();
            conStrKL.ConStr(1);
            if (IDKL != 0)
            { zaprosKL.SPRAVOCHNKlass(IDKL); }
            else
            { zaprosKL.SPRAVOCHNKlass(0); }
            cstrKL = conStrKL.StP;
            zKL = zaprosKL.commandStringTest;
            connectionKL = new MySqlConnection(cstrKL);
            mySqlDataAdapterKL = new MySqlDataAdapter(zKL, connectionKL);
            mySqlDataAdapterKL.Fill(DSKL);
            dataGridView4.DataSource = DSKL.Tables[0];
            dataGridView4.Columns[0].Visible = false;
            int ssKL = 0;
            for (ssKL = 5; ssKL < 67; ssKL++)
            { dataGridView4.Columns[ssKL].Visible = false; }
            dataGridView4.Columns[68].Visible = false;
            dataGridView4.Columns[70].Visible = false;
            connectionKL.Close();
        }
        #endregion //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        #region /////////////////////////////////////// ЗАГРУЗКА Участка ///////////////////////////////////////////////////////            
        public void ZagrUchast(int IDKL)
        {
            ConnectStr conStrMD = new ConnectStr();
            Zapros zaprosMD = new Zapros();
            conStrMD.ConStr(1);
            if (IDKL != 0)
            { zaprosMD.MDAD(IDKL); }
            else
            { zaprosMD.MDAD(0); }
            cstrMD = conStrMD.StP;
            zMD = zaprosMD.commandStringTest;
            connectionMD = new MySqlConnection(cstrMD);
            mySqlDataAdapterMD = new MySqlDataAdapter(zMD, connectionMD);
            mySqlDataAdapterMD.Fill(DSMD);
            dataGridView12.DataSource = DSMD.Tables[0];

            ss = 0;
            for (ss = 0; ss < 2; ss++)
            { dataGridView12.Columns[ss].Visible = false; }
            dataGridView12.Columns[3].Visible = false;
            ss = 0;
            for (ss = 9; ss < 15; ss++)
            { dataGridView12.Columns[ss].Visible = false; }
           for (ss = 16; ss < 51; ss++)
            { dataGridView12.Columns[ss].Visible = false; }

            dataGridView12.Refresh();
            connectionMD.Close();
        }
 
        #endregion ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        #region /////////////////////////////////////// ЗАГРУЗКА Рубежа ///////////////////////////////////////////////////////  
        public void ZagrRUB(int IDRUB)
        {
            ConnectStr conStrRUB = new ConnectStr();
            Zapros zaprosRUB = new Zapros();
            conStrRUB.ConStr(1);
            if (IDRUB != 0)
            { zaprosRUB.SPRAVOCHNRubej(IDRUB); }
            else
            { zaprosRUB.SPRAVOCHNRubej(0); }
            cstrRUB = conStrRUB.StP;
            zRUB = zaprosRUB.commandStringTest;
            connectionRUB = new MySqlConnection(cstrRUB);
            mySqlDataAdapterRUB = new MySqlDataAdapter(zRUB, connectionRUB);
            mySqlDataAdapterRUB.Fill(DSRUB);
            raspolojenRubejaDataGridView.DataSource = DSRUB.Tables[0];
            raspolojenRubejaDataGridView.Columns[0].Visible = false;
            raspolojenRubejaDataGridView.Columns[2].Visible = false;
            int ssRUB = 0;
            for (ssRUB = 4; ssRUB < 16; ssRUB++)
            { raspolojenRubejaDataGridView.Columns[ssRUB].Visible = false; }
            raspolojenRubejaDataGridView.Columns[26].Visible = false;
            connectionRUB.Close();
        }
        #endregion //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        #region /////////////////////////////////////// ЗАГРУЗКА Направления ///////////////////////////////////////////////////////  
        public void ZagrNAPR(int IDNAPR)
        {
            ConnectStr conStrNAPR = new ConnectStr();
            Zapros zaprosNAPR = new Zapros();
            conStrNAPR.ConStr(1);
            if (IDNAPR != 0)
            { zaprosNAPR.SPRAVOCHNNAPR(IDNAPR); }
            else
            { zaprosNAPR.SPRAVOCHNNAPR(0); }
            cstrNAPR = conStrNAPR.StP;
            zNAPR = zaprosNAPR.commandStringTest;
            connectionNAPR = new MySqlConnection(cstrNAPR);
            mySqlDataAdapterNAPR = new MySqlDataAdapter(zNAPR, connectionNAPR);
            mySqlDataAdapterNAPR.Fill(DSNAPR);
            dataGridView2.DataSource = DSNAPR.Tables[0];
            dataGridView2.Columns[0].Visible = false;
            dataGridView2.Columns[4].Visible = false;
            connectionNAPR.Close();
        }
        #endregion //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void raspolojenRubejaDataGridView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int rowNumR;
            rowNumR = raspolojenRubejaDataGridView.CurrentRow.Index;
            int IDNAPR = Convert.ToInt32(raspolojenRubejaDataGridView[0, rowNumR].Value);
            DSNAPR = new DataSet();
            ZagrNAPR(IDNAPR);
        }

        public void Otrisovka()//раскраска ячеек В МОНИТОРЕ
        {
            //||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
            foreach (DataGridViewRow row in dataGridView9.Rows) //цикл             
            {
                this.Cursor = Cursors.WaitCursor;
                if ((Convert.ToBoolean(row.Cells[10].Value.ToString()) == true)|| (Convert.ToBoolean(row.Cells[12].Value.ToString()) == true)
                    || (Convert.ToBoolean(row.Cells[11].Value.ToString()) == true) || (Convert.ToBoolean(row.Cells[13].Value.ToString()) == true)
                    || (Convert.ToBoolean(row.Cells[15].Value.ToString()) == true) || (Convert.ToBoolean(row.Cells[14].Value.ToString()) == true))//days > 9000)
                {
                    row.Cells[0].Style.BackColor = System.Drawing.Color.LightPink;
                    row.Cells[1].Style.BackColor = System.Drawing.Color.LightPink;
                    row.Cells[2].Style.BackColor = System.Drawing.Color.LightPink;
                    row.Cells[3].Style.BackColor = System.Drawing.Color.LightPink;
                    row.Cells[4].Style.BackColor = System.Drawing.Color.LightPink;
                    row.Cells[20].Style.BackColor = System.Drawing.Color.LightPink;
                    row.Cells[6].Style.BackColor = System.Drawing.Color.LightPink;
                    row.Cells[7].Style.BackColor = System.Drawing.Color.LightPink;
                    row.Cells[8].Style.BackColor = System.Drawing.Color.LightPink;
                }
                if (Convert.ToDouble(row.Cells[4].Value) == 0 || Convert.ToDouble(row.Cells[6].Value) == 0 || Convert.ToDouble(row.Cells[7].Value) == 0 || row.Cells[20].Value.ToString() != "0" )
                {
                    row.Cells[0].Style.BackColor = System.Drawing.Color.LightYellow;
                    row.Cells[1].Style.BackColor = System.Drawing.Color.LightYellow;
                    row.Cells[2].Style.BackColor = System.Drawing.Color.LightYellow;
                    row.Cells[3].Style.BackColor = System.Drawing.Color.LightYellow;
                    row.Cells[4].Style.BackColor = System.Drawing.Color.LightYellow;
                    row.Cells[20].Style.BackColor = System.Drawing.Color.LightYellow;
                    row.Cells[6].Style.BackColor = System.Drawing.Color.LightYellow;
                    row.Cells[7].Style.BackColor = System.Drawing.Color.LightYellow;
                    row.Cells[8].Style.BackColor = System.Drawing.Color.LightYellow;
                }               
                else
                {
                }                
            }
        }
        // |||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||

        public Image StrToImg(string StrImg)
        {
            byte[] arrayimg = Convert.FromBase64String(StrImg);
            Image imageStr = Image.FromStream(new MemoryStream(arrayimg));
            return imageStr;
        }
        #region     Редактирование АД  ///////////////////////////////////////
        private void button19_Click(object sender, EventArgs e) ///         добавление АД
        {
            if (dataGridView13.Rows.Count != 0)
            {
                R1 = 0;
                R1 = dataGridView13.Rows.Count;
            }
            FormAD OrdFormAD = new FormAD();
            OrdFormAD.ShowDialog();
            if (DSAD != null)
                DSAD.Clear();
            ZagrAD();
            if (R1 > 0)
            { dataGridView13.CurrentCell = dataGridView13[1, R1 - 1]; }
            else if (R1 == 0)
            { dataGridView13.CurrentCell = dataGridView13[1, R1]; }
        }

        private void button18_Click(object sender, EventArgs e)///////////////////   Редактирование автодороги
        {
            if (dataGridView13.Rows.Count != 0)
            {
                R1 = 0;
                R1 = dataGridView13.CurrentCell.RowIndex;
            }
            int IDKl = Convert.ToInt32(dataGridView13[0, dataGridView13.CurrentRow.Index].Value.ToString());
                        
            FormAD OrdFormAD = new FormAD();
            OrdFormAD.FormAD_LoadRN(IDKl);
            OrdFormAD.ShowDialog();
            if (DSAD != null)
                DSAD.Clear();
            ZagrAD();
            dataGridView13.CurrentCell = dataGridView13[1, R1];
        }
        private void button16_Click(object sender, EventArgs e)//           Кнопка удалить автодорогу
        {
            if (dataGridView13.Rows.Count != 0)
            {
                R1 = 0;
                R1 = dataGridView13.CurrentCell.RowIndex;
            }
            int IDKl = Convert.ToInt32(dataGridView13[0, dataGridView13.CurrentRow.Index].Value.ToString());
            DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить выбранную Вами автодорогу? \n (Автодорога будет удалена окончательно без возможности восстановления)", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
            }
            if (result == DialogResult.Yes)
            {
                ConnectStr conStrKl = new ConnectStr();
                Zapros zaprosKl = new Zapros();
                conStrKl.ConStr(1);
                cstrKL = conStrKl.StP;
                MySql.Data.MySqlClient.MySqlConnection sqlConnectionT = new MySql.Data.MySqlClient.MySqlConnection(cstrKL);
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
                cmd.CommandText = "DELETE " +
                        " FROM rapdoroga " +
                        "WHERE id = " + IDKl;
                cmd.Connection = sqlConnectionT;
                sqlConnectionT.Open();
                cmd.ExecuteNonQuery();
                sqlConnectionT.Close();
                if (DSAD != null)
                    DSAD.Clear();
                ZagrAD();
                if (R1 > 0)
                { dataGridView13.CurrentCell = dataGridView13[1, R1-1]; }
                else if (R1==0)
                { dataGridView13.CurrentCell = dataGridView13[1, R1]; }
            }
        }
        public void ZagrAD()
        {
    ConnectStr conStrAD = new ConnectStr();
    Zapros zaprosAD = new Zapros();
    conStrAD.ConStr(1);
    cstrAD = conStrAD.StP;
    connectionAD = new MySqlConnection(cstrAD);
            if (((strus[3]) != "") && (Convert.ToInt32(strus[3]) > 0))
            {
                zaprosAD.AD(0);
                zAD = zaprosAD.commandStringTest;
                mySqlDataAdapterAD = new MySqlDataAdapter(zAD, connectionAD);
                mySqlDataAdapterAD.Fill(DSAD);
                dataGridView13.DataSource = DSAD.Tables[0];
                dataGridView13.Refresh();
            }
        }       
        #endregion     Редактирование АД  ///////////////////////////////////////

        #region     Редактирование Рубежа  ///////////////////////////////////////
        private void button22_Click(object sender, EventArgs e)///////////////////   Кнопка добавления Места Дислокации
        {
            if (dataGridView12.Rows.Count != 0)
            {
                R1 = 0;
                R1 = dataGridView12.Rows.Count;
            }
            FormMDisl OrdersFormMDisl = new FormMDisl();
            OrdersFormMDisl.ShowDialog();
            DSMD = new DataSet();
            ZagrUchast(0);
            if (R1 > 0)
            { dataGridView12.CurrentCell = dataGridView12[2, R1 - 1]; }
            else if (R1 == 0)
            { dataGridView12.CurrentCell = dataGridView12[2, R1]; }
        }
        private void button21_Click(object sender, EventArgs e)//  Редактирование места дислокации
        {
            if (dataGridView12.Rows.Count != 0)
            {
                R1 = 0;
                R1 = dataGridView12.CurrentCell.RowIndex;
            }
            int IDKl = Convert.ToInt32(dataGridView12[0, dataGridView12.CurrentRow.Index].Value.ToString());

            FormMDisl OrdersFormMDisl = new FormMDisl();
            OrdersFormMDisl.FormMDisl_LoadRN(IDKl);
            OrdersFormMDisl.ShowDialog();
            if (DSMD != null)
                DSMD = new DataSet();
            ZagrUchast(0);
            dataGridView12.CurrentCell = dataGridView12[2, R1];
        }
        private void button20_Click(object sender, EventArgs e)//  Удаление Места Дислокации
        {
            if (dataGridView12.Rows.Count != 0)
            {
                R1 = 0;
                R1 = dataGridView12.CurrentCell.RowIndex;
            }
            int IDKl = Convert.ToInt32(dataGridView12[0, dataGridView12.CurrentRow.Index].Value.ToString());
            DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить выбранное Вами место дислокации? \n (Строка будет удалена окончательно без возможности восстановления)", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
            }
            if (result == DialogResult.Yes)
            {
                ConnectStr conStrKl = new ConnectStr();
                Zapros zaprosKl = new Zapros();
                conStrKl.ConStr(1);
                cstrKL = conStrKl.StP;
                MySql.Data.MySqlClient.MySqlConnection sqlConnectionT = new MySql.Data.MySqlClient.MySqlConnection(cstrKL);
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
                cmd.CommandText = "DELETE " +
                        " FROM rapmestodislokatsii " +
                        "WHERE ID = " + IDKl;
                cmd.Connection = sqlConnectionT;
                sqlConnectionT.Open();
                cmd.ExecuteNonQuery();
                sqlConnectionT.Close();
                if (DSMD != null)
                    DSMD = new DataSet();
                ZagrUchast(0);
                if (R1 > 0)
                { dataGridView12.CurrentCell = dataGridView12[2, R1 - 1]; }
                else if (R1 == 0)
                { dataGridView12.CurrentCell = dataGridView12[2, R1]; }
            }
        }
        private void dataGridView12_DoubleClick(object sender, EventArgs e)////  двойной клик по таблице
        {
            if (dataGridView12.Rows.Count != 0)
            {
                R1 = 0;
                R1 = dataGridView12.CurrentCell.RowIndex;
            }
            int IDKl = Convert.ToInt32(dataGridView12[0, dataGridView12.CurrentRow.Index].Value.ToString());

            FormMDisl OrdersFormMDisl = new FormMDisl();
            OrdersFormMDisl.FormMDisl_LoadRNV(IDKl);
            OrdersFormMDisl.ShowDialog();
            if (DSMD != null)
                DSMD = new DataSet();
            ZagrUchast(0);
            dataGridView12.CurrentCell = dataGridView12[2, R1];
        }
        #endregion  ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //функция преобразования изображения в строку
        ////    Private void tabControl1_Selected(Object ByVal,System.Windows.Forms.TabControlEventArgs e ) Handles tabControl1.Selected
        ////    CurrentTab = e.TabPage
        ////    Debug.WriteLine("Selected: " + e.TabPage.Name)
        ////End Sub
        #region /////////////////////////////////////// ЗАГРУЗКА PDKO ///////////////////////////////////////////////////////            
        public void ZagrPDKO(int IDKL)
        {
            Zapros zaprosPDKO = new Zapros();
            zaprosPDKO.SPRAVOCHNKPDKO(0);
            zPDKO = zaprosPDKO.commandStringTest;
            mySqlDataAdapterPDKO = new MySqlDataAdapter(zPDKO, connectionAD);
            mySqlDataAdapterPDKO.Fill(DSPDKO);
            dataGridView1.DataSource = DSPDKO.Tables[0];
            dataGridView1.Refresh();
        }
        #endregion ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        #region /////////////////////////////////////// ЗАГРУЗКА PDKObMass ///////////////////////////////////////////////////////            
        public void ZagrPDKObMass(int IDKL)
        {
            Zapros zaprosPDK = new Zapros();
            zaprosPDK.SPRAVOCHNPDK(0);
            zPDK = zaprosPDK.commandStringTest;
            mySqlDataAdapterPDK = new MySqlDataAdapter(zPDK, connectionAD);
            mySqlDataAdapterPDK.Fill(DSPDK);
            dataGridView14.DataSource = DSPDK.Tables[0];
            dataGridView14.Refresh();

        }
        #endregion ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        #region//////////////////////////////// запрос МОНИТОРИНГ   /////////////////////////////////////
        public void ZMonitor(string TxtZapr)
        {
            int CoZ = Convert.ToInt32(textBox11.Text);
            ConnectStr conStrM = new ConnectStr();
            conStrM.ConStr(1);
            cstr = conStrM.StP;
            connection = new MySqlConnection(cstr);
            Zapros zapros1 = new Zapros();
            COs = KolOs;
            D1 = dateTimePicker9.Value.ToString("yyyy.MM.dd HH:mm:ss");
            D2 = dateTimePicker10.Value.ToString("yyyy.MM.dd HH:mm:ss");
            zapros1.ZaprMonit(0, D1, D2, CoZ, TxtZapr);//zapros1.ZaprLevKontr(0, D1, D2, CoZ);//
            z = zapros1.commandStringTest;
            mySqlDataAdapter = new MySqlDataAdapter(z, connection);
            mySqlDataAdapter.Fill(DS);
            dataGridView9.DataSource = DS.Tables[0];
            dataGridView9.Columns[5].Visible = false;
            dataGridView9.Columns[9].Visible = false;
            dataGridView9.Columns[10].Visible = false;
            dataGridView9.Columns[11].Visible = false;
            dataGridView9.Columns[12].Visible = false;
            dataGridView9.Columns[13].Visible = false;
            dataGridView9.Columns[14].Visible = false;
            dataGridView9.Columns[15].Visible = false;
            dataGridView9.Columns[16].Visible = false;
            dataGridView9.Columns[17].Visible = false;
            dataGridView9.Columns[18].Visible = false;
            dataGridView9.Columns[19].Visible = false;
            dataGridView9.Columns[20].Visible = false;
            dataGridView9.Columns[21].Visible = false;

            if (dataGridView9.Rows.Count != 0)
            {
                alphaBlendTextBox11.Text = dataGridView9[0, 0].Value.ToString();
            }
            connection.Close();
        }
        #endregion ////////////////////////////////////////
        #region //////////////////////////// ЗАГРУЗКА ПРАВОГО И ЛЕВОГО КОНТРОЛЯ ////////////////////
        public void ZKontrolL(string TxtZaprL)
        {
            CoZKL = Convert.ToInt32(textBox12.Text);
            ConnectStr conStrL = new ConnectStr();
            conStrL.ConStr(1);
            cstr = conStrL.StP;
            connectionL = new MySqlConnection(cstr);
            Zapros zaprosL = new Zapros();
            COsL = KolOsL;
            D1L = dateTimePicker7.Value.ToString("yyyy.MM.dd HH:mm:ss");
            D2L = dateTimePicker8.Value.ToString("yyyy.MM.dd HH:mm:ss");
            zaprosL.ZaprLevKontr(0, D1L, D2L, CoZKL, TxtZaprL);
            zL = zaprosL.commandStringTest;
            mySqlDataAdapterL = new MySqlDataAdapter(zL, connectionL); //L);
            mySqlDataAdapterL.Fill(DSL);
            BindingSource bindingSource2 = new BindingSource();
            bindingSource2.DataSource = DSL.Tables[0];
            dataGridView8.DataSource = bindingSource2;//DSL.Tables[0];
            dataGridView8.Columns[5].Visible = false;
            dataGridView8.Columns[9].Visible = false;
            dataGridView8.Columns[10].Visible = false;
            dataGridView8.Columns[11].Visible = false;
            dataGridView8.Columns[12].Visible = false;
            dataGridView8.Columns[13].Visible = false;
            dataGridView8.Columns[14].Visible = false;
            dataGridView8.Columns[15].Visible = false;
            dataGridView8.Columns[16].Visible = false;
            dataGridView8.Columns[17].Visible = false;
            dataGridView8.Columns[18].Visible = false;
            dataGridView8.Columns[19].Visible = false;

            if (dataGridView8.Rows.Count != 0)
            {
              alphaBlendTextBox25.Text = dataGridView8[0, 0].Value.ToString();
            }
            connectionL.Close();
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            CoZKL = Convert.ToInt32(textBox12.Text);
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
       
            ///////////////////////////////////////////// ЗЗГРУЗКА ПРАВАЯ
        public void ZKontrolR(string TxtZaprR)
        {
            CoZKR = Convert.ToInt32(textBox13.Text);
            ConnectStr conStrR = new ConnectStr();
            conStrR.ConStr(1);
            cstr = conStrR.StP;
            connectionR = new MySqlConnection(cstr);
            Zapros zaprosR = new Zapros();
            COsR = KolOsR;
            D1R = dateTimePicker11.Value.ToString("yyyy.MM.dd HH:mm:ss");
            D2R = dateTimePicker12.Value.ToString("yyyy.MM.dd HH:mm:ss");
            zaprosR.ZaprPravKontr(0, D1R, D2R, CoZKR, TxtZaprR);
            zR = zaprosR.commandStringTest;
            mySqlDataAdapterR = new MySqlDataAdapter(zR, connectionR); //R);
            mySqlDataAdapterR.Fill(DSR);
            BindingSource bindingSourceR = new BindingSource();
            bindingSourceR.DataSource = DSR.Tables[0];
            dataGridView11.DataSource = bindingSourceR;// DSR.Tables[0];
            dataGridView11.Columns[5].Visible = false;
            dataGridView11.Columns[9].Visible = false;
            dataGridView11.Columns[10].Visible = false;
            dataGridView11.Columns[11].Visible = false;
            dataGridView11.Columns[12].Visible = false;
            dataGridView11.Columns[13].Visible = false;
            dataGridView11.Columns[14].Visible = false;
            dataGridView11.Columns[15].Visible = false;
            dataGridView11.Columns[16].Visible = false;
            dataGridView11.Columns[18].Visible = false;
            dataGridView11.Columns[19].Visible = false;
            dataGridView11.Columns[17].Visible = false;
            connectionR.Close();
        }
        public void ZKontrolROF(string TxtZaprRO)
        {
            CoZKROF = Convert.ToInt32(textBox13.Text);
            ConnectStr conStrROF = new ConnectStr();
            conStrROF.ConStr(1);
            cstrOF = conStrROF.StP;
            connectionROF = new MySqlConnection(cstrOF);
            Zapros zaprosROF = new Zapros();
            COsROF = KolOsR;
            D1R = dateTimePicker11.Value.ToString("yyyy.MM.dd HH:mm:ss");
            D2R = dateTimePicker12.Value.ToString("yyyy.MM.dd HH:mm:ss");
            zaprosROF.ZaprPravKontrOF(0, D1R, D2R, CoZKR, TxtZaprRO);
            zROF = zaprosROF.commandStringTest;
            mySqlDataAdapterROF = new MySqlDataAdapter(zROF, connectionROF); //R);
            mySqlDataAdapterROF.Fill(DSROF);
            BindingSource bindingSourceROF = new BindingSource();
            bindingSourceROF.DataSource = DSROF.Tables[0];
            dataGridView10.DataSource = bindingSourceROF;
            connectionROF.Close();
            }
       
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex!=0)
            { timer1.Enabled = false; timer2.Enabled = false; timer3.Enabled = false; }
            if (tabControl1.SelectedIndex==0)
            {
                if (((strus[1]) != "") && (Convert.ToInt32(strus[1]) > 0) && ((strus[6]) != "") && (Convert.ToInt32(strus[6]) > 0))
                {
                    if (tabControl1.SelectedIndex == 1)
                    {
                        timer1.Enabled = true;
                        timer2.Enabled = false;
                        timer3.Enabled = true;
                    }
                    else if (tabControl1.SelectedIndex == 0)
                    {
                        timer1.Enabled = false;
                        timer2.Enabled = true;
                        timer3.Enabled = false;
                    }
                }
                else if (((strus[1]) != "") && (Convert.ToInt32(strus[1]) > 0))
                {
                    timer1.Enabled = false;
                    timer2.Enabled = true;
                    timer3.Enabled = false;
                }

                else if (((strus[6]) != "") && (Convert.ToInt32(strus[6]) > 0))
                {
                    timer1.Enabled = true;
                    timer2.Enabled = false;
                    timer3.Enabled = true;
                }
            }
            else if (tabControl1.SelectedIndex != 3)
            {
                //timer1.Enabled = true;
                //timer2.Enabled = false;
                //timer3.Enabled = true;
            }

            if (tabControl1.SelectedTab.Name== "tabPage9")
            {

            }

            if (tabControl1.SelectedTab.Name == "tabPage2")
            {
                dateTimePicker15.Value = dateTimePicker14.Value;
                dateTimePicker16.Value = dateTimePicker13.Value;
                D1SR = dateTimePicker15.Value.ToString("yyyyMMddHHmmss");
                D2SR = dateTimePicker16.Value.ToString("yyyyMMddHHmmss");
                GRZSR = textBox15.Text.ToString();
                ColRSR = Convert.ToInt32(textBox14.Text);

                if (dataGridView15.RowCount > 0)
                {
                    dataGridView15.CurrentCell = dataGridView15[2, 0];
                }
                if (DSSR != null)
                    DSSR.Clear();
                ZagrSPRAZR(0, D1SR, D2SR, ColRSR, "");

                if (toolStripLabel6.Text != "")
                {
                    kol = Convert.ToInt32(toolStripLabel6.Text);
                }
                if (dataGridView15.RowCount > 1)
                {
                    rowIndex = dataGridView15.SelectedCells[2].RowIndex;
                    if (kol > rowIndex)
                    { kol = 0; }
                    int Sum = 0;
                    for (int i = 0; i < dataGridView15.Rows.Count; i++)
                    {
                        Sum = Sum + 1;
                    }
                    if (Sum - kol < Sum)
                    { kol = Sum - kol; }
                    dataGridView15.CurrentCell = dataGridView15[2, rowIndex + kol];
                    currentRowLeft = rowIndex + kol;
                    toolStripLabel6.Text = "" + (Convert.ToInt32(Sum)).ToString();
                }

            }
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            CoZKR = Convert.ToInt32(textBox13.Text);
        }
       
        private void timer4_Tick(object sender, EventArgs e)
        {
            if (IDLF == 0)
            {
                timer1.Enabled = true;
                timer4.Enabled = false;
            }
            else if (IDLF == 1)
            { timer4.Enabled = false; }
        }

        private void tabControl3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DSL != null)
                DSL.Clear();
            ZKontrolL("");
            Otrisovka1();

        }

        private void dataGridView9_DoubleClick(object sender, EventArgs e)
        {
           
            if (((strus[7]) != "") && (Convert.ToInt32(strus[7]) > 0))
            {
                int CH;
                if (checkBox11.Checked==true)
                {  CH = 1; timer2.Enabled = false; }
                else { CH = 0; }

                //timer1.Enabled = false;
                if (label126.Visible == false /*|| label126.Visible == true*/)
                {
                if (dataGridView9.Rows.Count != 0)
                {
                    RC = dataGridView9.CurrentCell.RowIndex;
                }
                    this.Cursor = Cursors.WaitCursor;
                    FormKartMonit OrdersForm = new FormKartMonit();
                    OrdersForm.FormKartMonit_LoadPMonit(Convert.ToInt32(alphaBlendTextBox11.Text), NUs, strus[13]);
                    OrdersForm.ShowDialog();
                }
                if (CH == 1)
                { timer2.Enabled = true; }
                
            }
        }       

        #endregion //////////////////////////////////////////////

        #region//////////////////////////////////// Загрузка справочн нарушений
        public void ZagrNarush()
        {
            ConnectStr conStrNar = new ConnectStr();
            Zapros zaprosNar = new Zapros();
            conStrNar.ConStr(1);
            cstrNar = conStrNar.StP;
            connectionNar = new MySqlConnection(cstrNar);
            zaprosNar.Narush(0);
                zNar = zaprosNar.commandStringTest;
                mySqlDataAdapterNar = new MySqlDataAdapter(zNar, connectionNar);
                mySqlDataAdapterNar.Fill(DSNAR);
                dataGridView16.DataSource = DSNAR.Tables[0];
            dataGridView16.Columns[0].Visible = false;
            dataGridView16.Columns[3].Visible = false;
            dataGridView16.Columns[10].Visible = false;
            dataGridView16.Refresh();
            }

        private void button30_Click(object sender, EventArgs e)//////////////////// добавление нарушения
        {
            if (dataGridView16.Rows.Count != 0)
            {
                R1 = 0;
                R1 = dataGridView16.Rows.Count;
            }
            FormNARUSH OFormNARUSH = new FormNARUSH();
            OFormNARUSH.ShowDialog();
            DSNAR = new DataSet();
            ZagrNarush();
            if (R1 > 0)
            { dataGridView16.CurrentCell = dataGridView16[1, R1 - 1]; }
            else if (R1 == 0)
            { dataGridView16.CurrentCell = dataGridView16[1, R1]; }
        }

        private void button28_Click(object sender, EventArgs e)////////////////////  Удалить нарушения
        {
            if (dataGridView16.Rows.Count != 0)
            {
                R1 = 0;
                R1 = dataGridView16.CurrentCell.RowIndex;
            }
            int IDNar = Convert.ToInt32(dataGridView16[0, dataGridView16.CurrentRow.Index].Value.ToString());
            DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить выбранноую Вами строку? \n (Строка будет удалена окончательно без возможности восстановления)", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            { }
            if (result == DialogResult.Yes)
            {
                ConnectStr conStrU = new ConnectStr();
                Zapros zaprosU = new Zapros();
                conStrU.ConStr(1);
                cstrU = conStrU.StP;
                MySql.Data.MySqlClient.MySqlConnection sqlConnectionT = new MySql.Data.MySqlClient.MySqlConnection(cstrU);
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
                cmd.CommandText = "DELETE " +
                        " FROM raptsprnar " +
                        "WHERE IDNar = " + IDNar;
                cmd.Connection = sqlConnectionT;
                sqlConnectionT.Open();
                cmd.ExecuteNonQuery();
                sqlConnectionT.Close();
                DSNAR = new DataSet();
                ZagrNarush();
                if (R1 > 0)
                { dataGridView16.CurrentCell = dataGridView16[1, R1 - 1]; }
                else if (R1 == 0)
                { dataGridView16.CurrentCell = dataGridView16[1, R1]; }
            }
        }
  private void button29_Click(object sender, EventArgs e)///Изменить запись в справочнике нарушений
        {
            if (dataGridView16.Rows.Count != 0)
            {
                R1 = 0;
                R1 = dataGridView16.CurrentCell.RowIndex;
            }
            int TNAR = Convert.ToInt32(dataGridView16[1, dataGridView16.CurrentRow.Index].Value.ToString());
            FormNARUSH OFormNARUSH = new FormNARUSH();
            OFormNARUSH.FormNARUSH_Load(TNAR);
            OFormNARUSH.ShowDialog();

            DSNAR = new DataSet();
            ZagrNarush();
            dataGridView16.CurrentCell = dataGridView16[1, R1];
        }

        private void dataGridView16_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView16.Rows.Count != 0)
            {
                R1 = 0;
                R1 = dataGridView16.CurrentCell.RowIndex;
            }
            int TNAR = Convert.ToInt32(dataGridView16[1, dataGridView16.CurrentRow.Index].Value.ToString());
            FormNARUSH OFormNARUSH = new FormNARUSH();
            OFormNARUSH.FormNARUSH_LoadV(TNAR);
            OFormNARUSH.ShowDialog();
            DSNAR = new DataSet();
            ZagrNarush();
            dataGridView16.CurrentCell = dataGridView16[1, R1];
        }

        #endregion ////////////////////////////////////////////////////////////////

        private void button32_Click(object sender, EventArgs e)                                  ///////// кнопка расширенного фильтра в МОНИТОРЕ
        {
            flags = new Boolean[55];
            Napr = new string[4];
            if (flags1 == null) { flags1 = new Boolean[55]; }
            if (Napr1 == null) { Napr1 = new string[4]; }
            flags = flags1;
           Napr = Napr1;
            FormFiltrM OrdersForm = new FormFiltrM();
            OrdersForm.flags = flags;
            OrdersForm.Napr = Napr;
            OrdersForm.ShowDialog();
            flags1 = flags;
            Napr1 = Napr;
            if (dataGridView9.RowCount > 0)
            {
                dataGridView9.CurrentCell = dataGridView9[1, 0];
            }
            //checkBox11.Checked = false;
            //timer2.Enabled = false;
            StopSearchM();
            //button1_Click(sender, e);
        }

        private void dataGridView8_DoubleClick(object sender, EventArgs e)
        {
            if (((strus[7]) != "") && (Convert.ToInt32(strus[7]) > 0))
            {
                int CHK;
                if (checkBox11.Checked == true)
                {
                    CHK = 1; timer1.Enabled = false; timer3.Enabled = false;
                }
                else { CHK = 0; }

                //timer1.Enabled = false;
                if (dataGridView8.Rows.Count != 0)
                {
                    RC = dataGridView8.CurrentCell.RowIndex;
                }
                this.Cursor = Cursors.WaitCursor;
                FormKartMonit OrdersForm = new FormKartMonit();
                OrdersForm.FormKartMonit_LoadPMonit(Convert.ToInt32(alphaBlendTextBox25.Text), NUs, strus[13]);
                OrdersForm.ShowDialog();
          
                if (CHK == 1)
                { timer1.Enabled = true; timer3.Enabled = true; }
            }
        }

        private void button31_Click(object sender, EventArgs e)
        {
            flags = new Boolean[55];
            Napr = new string[4];
            flags1 = new Boolean[55];
           string [] Napr1 = { "", "", "", ""};
            textBox7.Text = "";
            if (dataGridView9.RowCount > 0)
            {
                dataGridView9.CurrentCell = dataGridView9[1, 0];
            }
            checkBox11.Checked = true;
                timer2.Enabled = true;
                dateTimePicker10.Value = DateTime.Now;
                dateTimePicker9.Value = dateTimePicker10.Value.AddHours(-1);
                rowIndex = 0;
                kol = 0;
        }      

        #region ////////////////////////////////////////////////////  Настройка пути (отключен))
        private void button35_Click(object sender, EventArgs e)//Добавление настройки пути
        {
            FormNastrPuti OFormNastrPuti = new FormNastrPuti();
            OFormNastrPuti.ShowDialog();
            DSPUT = new DataSet();
            ZagrNastrPuti();            
        }

        private void button34_Click(object sender, EventArgs e)//Изменение настройки пути
        {
            int TNAR = Convert.ToInt32(dataGridView17[0, dataGridView17.CurrentRow.Index].Value.ToString());
           
            FormNastrPuti OFormNastrPuti = new FormNastrPuti();
            OFormNastrPuti.FormNastrPuti_Load(TNAR);
            OFormNastrPuti.ShowDialog();
            DSPUT = new DataSet();
            ZagrNastrPuti();          
        }

        private void button33_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(dataGridView17[0, dataGridView17.CurrentRow.Index].Value.ToString());
            DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить выбранноую Вами строку? \n (Строка будет удалена окончательно без возможности восстановления)", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            { }
            if (result == DialogResult.Yes)
            {
                ConnectStr conStrU = new ConnectStr();
                Zapros zaprosU = new Zapros();
                conStrU.ConStr(1);
                cstrU = conStrU.StP;
                MySql.Data.MySqlClient.MySqlConnection sqlConnectionT = new MySql.Data.MySqlClient.MySqlConnection(cstrU);
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
                cmd.CommandText = "DELETE " +
                        " FROM rap_nastr_puti " +
                        "WHERE rap_nastr_puti.IDPut = " + ID + ";";
                cmd.Connection = sqlConnectionT;
                sqlConnectionT.Open();
                cmd.ExecuteNonQuery();
                sqlConnectionT.Close();
                DSPUT = new DataSet();
                ZagrNastrPuti();
            }
        }
        #endregion //////////////////////////////////////////////////////////

        #region ///////////////////////////////////////////////////////////////////////// справочник предельно допустимых значений по осям
        private void button6_Click(object sender, EventArgs e)//       Добавление ПДКО
        {
            if (dataGridView1.Rows.Count != 0)
            {
                R1 = 0;
                R1 = dataGridView1.Rows.Count;
            }
            FormPDKO OrdersFormPDKO = new FormPDKO();
            OrdersFormPDKO.ShowDialog();
            DSPDKO = new DataSet();
            ZagrPDKO(0);
            if (R1 > 0)
            { dataGridView1.CurrentCell = dataGridView1[3, R1 - 1]; }
            else if (R1 == 0)
            { dataGridView1.CurrentCell = dataGridView1[3, R1]; }
        }
        private void button5_Click(object sender, EventArgs e)///     Редактирование ПДК ОСЕЙ
        {
            if (dataGridView1.Rows.Count != 0)
            {
                R1 = 0;
                R1 = dataGridView1.CurrentCell.RowIndex;
            }
            int IDKl = Convert.ToInt32(dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString());

            FormPDKO OrdersFormPDKO = new FormPDKO();
            OrdersFormPDKO.FormPDKO_LoadRN(IDKl);
            OrdersFormPDKO.ShowDialog();
            if (DSPDKO != null)
                DSPDKO = new DataSet();
            ZagrPDKO(0);
            dataGridView1.CurrentCell = dataGridView1[3, R1];
        }
         private void button4_Click(object sender, EventArgs e)///    Удаление ПДК ОСЕЙ
        { 
            if (dataGridView1.Rows.Count != 0)
            {
                R1 = 0;
                R1 = dataGridView1.CurrentCell.RowIndex;
            }
            int ID = Convert.ToInt32(dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString());
            DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить выбранноую Вами строку? \n (Строка будет удалена окончательно без возможности восстановления)", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            { }
            if (result == DialogResult.Yes)
            {
                string z = "SELECT " +
                "raposnagrts.iddon, " +
                "raposnagrts.rasstjsey_min, " +
                "raposnagrts.rasstjsey_max, " +
                "raposnagrts.NosFor, " +
                "raposnagrts.NosTo " +
                "FROM raposnagrts " +
                "WHERE raposnagrts.iddon = " + ID;

                MySqlCommand command = new MySqlCommand();
                ConnectStr conStr = new ConnectStr();
                conStr.ConStr(1);
                Zapros zapros = new Zapros();
                string connectionString;
                connectionString = conStr.StP;
                MySqlConnection connection = new MySqlConnection(connectionString);
                command.CommandText = z;// commandString;
                command.Connection = connection;
                MySqlDataReader readerT;
                try
                {
                    command.Connection.Open();
                    readerT = command.ExecuteReader();
                    while (readerT.Read())
                    {
                        NF = Convert.ToInt32(readerT["NosFor"].ToString());
                        NT = Convert.ToInt32(readerT["NosTo"].ToString());                        
                        RF = Convert.ToInt32(readerT["rasstjsey_min"].ToString());
                        RT = Convert.ToInt32(readerT["rasstjsey_max"].ToString());
                    }                   
                    readerT.Close();
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Error: \r\n{0}", ex.ToString());
                }
                finally
                {
                    command.Connection.Close();
                }                                

            ConnectStr conStrU = new ConnectStr();
                Zapros zaprosU = new Zapros();
                conStrU.ConStr(1);
                cstrU = conStrU.StP;
                MySql.Data.MySqlClient.MySqlConnection sqlConnectionT = new MySql.Data.MySqlClient.MySqlConnection(cstrU);
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
                cmd.CommandText = "DELETE " +
                        " FROM raposnagrts " +
                        "WHERE raposnagrts.NosFor = " + NF +
                    " AND NosTo = " + NT +
                    " AND rasstjsey_min = " + RF +
                    " AND rasstjsey_max = " + RT;
            cmd.Connection = sqlConnectionT;
                sqlConnectionT.Open();
                cmd.ExecuteNonQuery();
                sqlConnectionT.Close();
                if (DSPDKO != null)
                    DSPDKO = new DataSet();
                ZagrPDKO(0);
            }
            if (R1 >= 3 )
            { dataGridView1.CurrentCell = dataGridView1[3, R1 - 3]; }
            else if (R1 > 0 && R1 < 3)
            { dataGridView1.CurrentCell = dataGridView1[3, R1-1]; }
            else if (R1 == 0)
            { dataGridView1.CurrentCell = dataGridView1[3, R1]; }
        }
        private void dataGridView1_DoubleClick(object sender, EventArgs e)////       двойной клик по таблице ПДКО
        {
            if (dataGridView1.Rows.Count != 0)
            {
                R1 = 0;
                R1 = dataGridView1.CurrentCell.RowIndex;
            }
            int IDKl = Convert.ToInt32(dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString());

            FormPDKO OrdersFormPDKO = new FormPDKO();
            OrdersFormPDKO.FormPDKO_LoadRNV(IDKl);
            OrdersFormPDKO.ShowDialog();
            if (DSPDKO != null)
                DSPDKO = new DataSet();
            ZagrPDKO(0);
            dataGridView1.CurrentCell = dataGridView1[3, R1];
        }

        #endregion //////////////////////////////////////////////////////////

        private void checkBox11_CheckedChanged(object sender, EventArgs e) //   Флажок он-лайн в мониторинге
        {
            if (checkBox11.Checked)
            { timer2.Enabled = true; }
            else
            { timer2.Enabled = false; }
        }

        private void dataGridView9_Click(object sender, EventArgs e)
        {
            Otrisovka();
        }
        
        private void button36_MouseDown(object sender, MouseEventArgs e)
        {
            textBoxPass.UseSystemPasswordChar = false;
        }

        private void button36_MouseUp(object sender, MouseEventArgs e)
        {
            textBoxPass.UseSystemPasswordChar = true;
        }
        #region //////////////////////////////////////////////////////////////////////////// редактирование справочника ПДК общей массы
        private void button27_Click(object sender, EventArgs e)// Добавление ПДК ОБЩЕЙ МАССЫ
        {
            if (dataGridView14.Rows.Count != 0)
            {
                R1 = 0;
                R1 = dataGridView14.Rows.Count;
            }
            FormPDKObM OrdersFormPDKObM = new FormPDKObM();
            OrdersFormPDKObM.ShowDialog();
            DSPDK = new DataSet();
            ZagrPDKObMass(0);
            if (R1 > 0)
            { dataGridView14.CurrentCell = dataGridView14[1, R1 - 1]; }
            else if (R1 == 0)
            { dataGridView14.CurrentCell = dataGridView14[1, R1]; }
        }

        private void button26_Click(object sender, EventArgs e)// Редактирование ПДК ОБЩЕЙ МАССЫ
        {
            if (dataGridView14.Rows.Count != 0)
            {
                R1 = 0;
                R1 = dataGridView14.CurrentCell.RowIndex;
            }
            int IDPDK = Convert.ToInt32(dataGridView14[0, dataGridView14.CurrentRow.Index].Value.ToString());
            FormPDKObM OrdersFormPDKObM = new FormPDKObM();
            OrdersFormPDKObM.FormPDKObM_LoadRN(IDPDK);
            OrdersFormPDKObM.ShowDialog();
            if (DSPDK != null)
                DSPDK = new DataSet();
            ZagrPDKObMass(0);
            dataGridView14.CurrentCell = dataGridView14[1, R1];
        }

        private void button9_Click(object sender, EventArgs e)// Удаление ПДК ОБЩЕЙ МАССЫ
        {
            if (dataGridView14.Rows.Count != 0)
            {
                R1 = 0;
                R1 = dataGridView14.CurrentCell.RowIndex;
            }
            int ID = Convert.ToInt32(dataGridView14[0, dataGridView14.CurrentRow.Index].Value.ToString());
            DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить выбранноую Вами строку? \n (Строка будет удалена окончательно без возможности восстановления)", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            { }
            if (result == DialogResult.Yes)
            {
                ConnectStr conStrU = new ConnectStr();
                Zapros zaprosU = new Zapros();
                conStrU.ConStr(1);
                cstrU = conStrU.StP;
                MySql.Data.MySqlClient.MySqlConnection sqlConnectionT = new MySql.Data.MySqlClient.MySqlConnection(cstrU);
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
                cmd.CommandText = "DELETE " +
                        " FROM rapdopmassts " +
                        "WHERE rapdopmassts.iddmts = " + ID + ";";
                cmd.Connection = sqlConnectionT;
                sqlConnectionT.Open();
                cmd.ExecuteNonQuery();
                sqlConnectionT.Close();
                if (DSPDK != null)
                    DSPDK = new DataSet();
                ZagrPDKObMass(0);
                if (R1 > 0)
                { dataGridView14.CurrentCell = dataGridView14[1, R1 - 1]; }
                else if (R1 == 0)
                { dataGridView14.CurrentCell = dataGridView14[1, R1]; }
            }
        }
        private void dataGridView14_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView14.Rows.Count != 0)
            {
                R1 = 0;
                R1 = dataGridView14.CurrentCell.RowIndex;
            }
            int IDPDK = Convert.ToInt32(dataGridView14[0, dataGridView14.CurrentRow.Index].Value.ToString());
            FormPDKObM OrdersFormPDKObM = new FormPDKObM();
            OrdersFormPDKObM.FormPDKObM_LoadRNV(IDPDK);
            OrdersFormPDKObM.ShowDialog();
            if (DSPDK != null)
                DSPDK = new DataSet();
            ZagrPDKObMass(0);
            dataGridView14.CurrentCell = dataGridView14[1, R1];
        }
        #endregion /////////////////////////////////////////////////////////////////////////////////

        private void button38_Click(object sender, EventArgs e) // Расширенный фильтр по контролю ЛЕВЫЙ
        {
            flags = new Boolean[55];
            Napr = new string[4];
            if (flags2 == null) { flags2 = new Boolean[55]; }
            if (Napr2 == null) { Napr2 = new string[4]; }
            flags = flags2;
            Napr = Napr2;
            FormFiltrM OrdersForm = new FormFiltrM();
            OrdersForm.flags = flags;
            OrdersForm.Napr = Napr;
            OrdersForm.ShowDialog();
            flags2 = flags;
            Napr2 = Napr;
            if (dataGridView8.RowCount > 0)
            {
                dataGridView8.CurrentCell = dataGridView8[1, 0];
            }
            //StopSearch();
            button11_Click(sender, e);
        }

        private void button40_Click(object sender, EventArgs e) // Расширенный фильтр по контролю ПРАВЫЙ
        {
            flags = new Boolean[55];
            Napr = new string[4];
            if (flags3 == null) { flags3 = new Boolean[55]; }
            if (Napr3 == null) { Napr3 = new string[4]; }
            flags = flags3;
            Napr = Napr3;
            FormFiltrM OrdersForm = new FormFiltrM();
            OrdersForm.flags = flags;
            OrdersForm.Napr = Napr;
            OrdersForm.ShowDialog();
            flags3 = flags;
            Napr3 = Napr;
            if (dataGridView11.RowCount > 0)
            {
                dataGridView11.CurrentCell = dataGridView11[1, 0];
            }
           // StopSearchR();
            button15_Click(sender, e);
        }

        private void button37_Click(object sender, EventArgs e)//Сброс фильтра по контролю ЛЕВЫЙ
        {
            flags = new Boolean[55];
            Napr = new string[4];
            flags2 = new Boolean[55];
            string[] Napr2 = { "", "", "", "" };
            textBoxGRZ.Text = "";
            if (dataGridView8.RowCount > 0)
            {
                dataGridView8.CurrentCell = dataGridView8[1, 0];
            }
            checkBox9.Checked = true;
            timer1.Enabled = true;
            dateTimePicker8.Value = DateTime.Now;
            dateTimePicker7.Value = dateTimePicker8.Value.AddHours(-1);
            rowIndex = 0;
            kol = 0;
        }

        private void button39_Click(object sender, EventArgs e)
        {
            flags = new Boolean[55];
            Napr = new string[4];
            flags3 = new Boolean[55];
            string[] Napr3 = { "", "", "", "" };// new string[4];
            textBox6.Text = "";
            if (tabControl3.SelectedIndex == 0)
            {
                dataGridView11.CurrentCell = dataGridView11[1, 0];
            }
            if (tabControl3.SelectedIndex == 1)
            {
                dataGridView10.CurrentCell = dataGridView10[1, 0];
            }

            timer3.Enabled = true;

            dateTimePicker12.Value = DateTime.Now;
            dateTimePicker11.Value = dateTimePicker12.Value.AddHours(-1);
            rowIndex = 0;
            kol = 0;
        }

        private void dataGridView10_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int currentRow = dataGridView11.CurrentRow.Index; // номер строки, по которой кликнули
            alphaBlendTextBox10.Text = dataGridView11[0, currentRow].Value.ToString(); //ID
            alphaBlendTextBox6.Text = dataGridView11[2, currentRow].Value.ToString();
            alphaBlendTextBox9.Text = dataGridView11[1, currentRow].Value.ToString().Substring(0, 10);
             label125.Text = "";
            OshKK = 0;
            if (Convert.ToDouble(dataGridView11[4, currentRow].Value) == 0 || Convert.ToDouble(dataGridView11[6, currentRow].Value) == 0 || Convert.ToDouble(dataGridView11[7, currentRow].Value) == 0)
            {
                label125.Text = "Критическая ошибка средств измерения (открытие карточки проезда невозможно)";
            }
            TSh11 = "";
            ZagrdataGridView11(Convert.ToInt32(alphaBlendTextBox10.Text));

            //// перевод ошибок...........
            string Oshib = Convert.ToString(OshKK, 2);
            if (Oshib != "0" && Oshib.Length > 9)
            {
                label125.Text = label125.Text.ToString() + "Ошибка на измерительном комплексе: ";
                if (Oshib.Substring(Oshib.Length - 1) != "0")
                { label125.Text = label125.Text.ToString() + " -не все данные были получены от датчиков;"; }
                if (Convert.ToInt64(Oshib.Substring(Oshib.Length - 2)) > 9)
                { label125.Text = label125.Text.ToString() + " -неравномерное движение ТС;"; }
                if (Convert.ToInt64(Oshib.Substring(Oshib.Length - 3)) > 99)
                { label125.Text = label125.Text.ToString() + " -размеры ТС выходит за допустимые пределы измерения;"; }
                if (Convert.ToInt64(Oshib.Substring(Oshib.Length - 4)) > 999)
                { label125.Text = label125.Text.ToString() + " -нагрузка на ось выходит за пределы измерения;"; }
                if (Convert.ToInt64(Oshib.Substring(Oshib.Length - 5)) > 9999)
                { label125.Text = label125.Text.ToString() + " -ошибка определения количества осей;"; }
                if (Convert.ToInt64(Oshib.Substring(Oshib.Length - 6)) > 99999)
                { label125.Text = label125.Text.ToString() + " -ошибка измерения межосевого расстояния;"; }
                if (Convert.ToInt64(Oshib.Substring(Oshib.Length - 7)) > 999999)
                { label125.Text = label125.Text.ToString() + " -ошибка измерения длины ТС;"; }
                if (Convert.ToInt64(Oshib.Substring(Oshib.Length - 8)) > 9999999)
                { label125.Text = label125.Text.ToString() + " -скорость ТС выходит за допустимые пределы измерения;"; }
            }
            else if (Oshib != "0" && Oshib.Length < 9)
            {
                label125.Text = label125.Text.ToString() + "Ошибка на измерительном комплексе ";
            }
            if (dataGridView11[8, currentRow].Value.ToString() == "")
            {
                label125.Text = label125.Text.ToString() + " Не распознан ГРЗ ТС";
            }

            label186.Text = AxelDateKR[2, 9];
            label196.Text = AxelDateKR[3, 9];
            label195.Text = AxelDateKR[0, 0]; label213.Text = AxelDateKR[3, 0];
            label194.Text = AxelDateKR[0, 1]; label204.Text = AxelDateKR[1, 1]; label212.Text = AxelDateKR[3, 1];
            label193.Text = AxelDateKR[0, 2]; label203.Text = AxelDateKR[1, 2]; label211.Text = AxelDateKR[3, 2];
            label192.Text = AxelDateKR[0, 3]; label202.Text = AxelDateKR[1, 3]; label210.Text = AxelDateKR[3, 3];
            label191.Text = AxelDateKR[0, 4]; label201.Text = AxelDateKR[1, 4]; label209.Text = AxelDateKR[3, 4];
            label190.Text = AxelDateKR[0, 5]; label200.Text = AxelDateKR[1, 5]; label208.Text = AxelDateKR[3, 5];
            label189.Text = AxelDateKR[0, 6]; label199.Text = AxelDateKR[1, 6]; label207.Text = AxelDateKR[3, 6];
            label188.Text = AxelDateKR[0, 7]; label198.Text = AxelDateKR[1, 7]; label206.Text = AxelDateKR[3, 7];
            label187.Text = AxelDateKR[0, 8]; label197.Text = AxelDateKR[1, 8]; label205.Text = AxelDateKR[3, 8];

            int i1 = 0;
            int i2 = 0;
            int cnt = 0;
            TipoS11 = "";
            for (i1 = 0; i1 < 9; i1++)
            {
                if (i1 > 0)
                {
                    if (KN[0, i1] != KN[0, i1 - 1])
                    {
                        KN[1, i1 - 1] = cnt;
                        cnt = 0;
                    }
                }
                cnt = cnt + 1;
            }
            for (i1 = 0; i1 < 9; i1++)
            {
                if (KN[1, i1] > 0)
                {
                    TipoS11 = TipoS11 + KN[1, i1].ToString() + "+";
                }
            }
            if (TipoS11 != "")
            {
                TipoS11 = TipoS11.Remove(TipoS11.Length - 1, 1);
            }
            alphaBlendTextBox38.Text = TipoS;
        }
      
        #region ////////////////////////////////// Вкладка СПЕЦ РАЗРЕШЕНИЯ ////////////////////////////////////////////
        private void button42_Click(object sender, EventArgs e) //  Открытие расш фильтра во вкладке СПЕЦ РАЗР
        {
            flagsSR = new Boolean[55];
            NaprSR = new string[4];
            if (flags4 == null) { flags4 = new Boolean[55]; }
            if (Napr4 == null) { Napr4 = new string[15]; }
            flagsSR = flags4;
            NaprSR = Napr4;
            SpetsRazrVKL OrdersForm = new SpetsRazrVKL();
            OrdersForm.flagsSR = flagsSR;
            OrdersForm.NaprSR = NaprSR;
            OrdersForm.ShowDialog();
            flags4 = flagsSR;
            Napr4 = NaprSR;
            button43_Click(sender, e);
        }

        private void button43_Click(object sender, EventArgs e) ////  Кнопка ОК в фильтре С/Р
        {
            if (flags4 == null && Napr4 == null)
            {
                dateTimePicker15.Value = dateTimePicker14.Value;
                dateTimePicker16.Value = dateTimePicker13.Value;
                D1SR = dateTimePicker15.Value.ToString("yyyyMMddHHmmss");
                D2SR = dateTimePicker16.Value.ToString("yyyyMMddHHmmss");
                GRZSR = textBox15.Text.ToString();
                ColRSR = Convert.ToInt32(textBox14.Text);

                if (dataGridView15.RowCount > 0)
                {
                    dataGridView15.CurrentCell = dataGridView15[2, 0];
                }
                if (DSSR != null)
                    DSSR.Clear();
                ZagrSPRAZR(0, D1SR, D2SR, ColRSR, "");
            }
            else { StopSearchSR(); }

            if(toolStripLabel6.Text != "")
            {
                kol = Convert.ToInt32(toolStripLabel6.Text);
            }
            if (dataGridView15.RowCount > 1)
            {
                rowIndex = dataGridView15.SelectedCells[2].RowIndex;
                if (kol > rowIndex)
                { kol = 0; }
                int Sum = 0;
                for (int i = 0; i < dataGridView15.Rows.Count; i++)
                {
                    Sum = Sum + 1;
                }
                if (Sum - kol < Sum)
                { kol = Sum - kol; }
                dataGridView15.CurrentCell = dataGridView15[2, rowIndex + kol];
                currentRowLeft = rowIndex + kol;
                toolStripLabel6.Text = "" + (Convert.ToInt32(Sum)).ToString();
            }
        }

        private void toolStripLabel6_TextChanged(object sender, EventArgs e) //// Изменение текста в подписи таблицы по спец.разрешеням (количество записей)
        {
            int SumSR = 0;
            for (int i = 0; i < dataGridView15.Rows.Count; i++)
            {
                if (dataGridView15.Rows[i].Cells[10].Value.ToString() != "" )
                {
                    SumSR = SumSR + 1;
                }
            }
            toolStripLabel8.Text = "" + (Convert.ToInt32(SumSR)).ToString();
        }
        #endregion  //////////////////////////////////////////////////////////
        #region //////////////////////////////////фильтр СПЕЦ РАЗРЕШЕНИЯ ////////////////////////////////////////////
        private void StopSearchSR()  // Делаем фильтр и все ссылки к нему (до строки /////////  С П Е Ц   Р А З Р   //////////////////)
        {
            if (Napr4[1] == null) { Napr4[0] = ""; Napr4[1] = ""; Napr4[2] = ""; Napr4[3] = "";
                Napr4[4] = ""; Napr4[5] = ""; Napr4[6] = ""; Napr4[7] = "";
                Napr4[8] = ""; Napr4[9] = ""; Napr4[10] = ""; Napr4[11] = "";
                Napr4[12] = ""; Napr4[13] = ""; Napr4[14] = "";
            }
            dateTimePicker15.Value = dateTimePicker14.Value;//Convert.ToDateTime("28.04.2018 00:00:00");//
            dateTimePicker16.Value = dateTimePicker13.Value;//Convert.ToDateTime("28.04.2018 13:00:00");
            string TXTFLEFT = "";
            TXTFLEFT = " WHERE  raptssprrazr.dateregsr BETWEEN '" + dateTimePicker15.Value.ToString("yyyyMMddHHmmss") + "' and '" + dateTimePicker16.Value.ToString("yyyyMMddHHmmss") + "'";
            if (textBox15.Text != "")
            {
                TXTFLEFT = TXTFLEFT + " and Plate LIKE '%" + textBox15.Text + "%'";
            }
            /////////////////////////////////////// по классу
            if (flags4 == null) { flags4 = new Boolean[55]; }
            if (flags4[5] == false && flags4[6] == false && flags4[7] == false && flags4[8] == false && flags4[9] == false && flags4[10] == false && flags4[11] == false && flags4[12] == false && flags4[13] == false && flags4[14] == false && flags4[15] == false && flags4[16] == false && flags4[17] == false)
            { }
            else
            {
                if (flags4[5] == true)
                { TXTFLEFT = TXTFLEFT + " AND (IF(CHAR_LENGTH(allandnapr.Class2)>3 ,SUBSTR(allandnapr.Class2, 1, 2), IF(CHAR_LENGTH(allandnapr.Class2)<=1 ,0,SUBSTR(allandnapr.Class2, 1, 1))) = 1"; }
                else if (flags4[5] == false)
                { TXTFLEFT = TXTFLEFT + " AND (IF(CHAR_LENGTH(allandnapr.Class2)>3 ,SUBSTR(allandnapr.Class2, 1, 2), IF(CHAR_LENGTH(allandnapr.Class2)<=1 ,0,SUBSTR(allandnapr.Class2, 1, 1))) = 17"; }

                for (int ifk = 6; ifk < 17; ifk++)
                {
                    if (flags4[ifk] == true)
                    { TXTFLEFT = TXTFLEFT + " OR IF(CHAR_LENGTH(allandnapr.Class2)>3 ,SUBSTR(allandnapr.Class2, 1, 2), IF(CHAR_LENGTH(allandnapr.Class2)<=1 ,0,SUBSTR(allandnapr.Class2, 1, 1))) = " + (ifk - 4); }
                    else if (flags4[ifk] == false)
                    {/* TXTFLEFT = TXTFLEFT + " OR Cl12 = 0"; */}
                }
                if (flags4[17] == true)
                { TXTFLEFT = TXTFLEFT + " OR IF(CHAR_LENGTH(allandnapr.Class2)>3 ,SUBSTR(allandnapr.Class2, 1, 2), IF(CHAR_LENGTH(allandnapr.Class2)<=1 ,0,SUBSTR(allandnapr.Class2, 1, 1))) = 12)"; }
                else if (flags4[17] == false)
                { TXTFLEFT = TXTFLEFT + ")"; }
            }           

            if (Napr4[0].ToString() == "Все" || Napr4[0].ToString() == "")
            {/* TXTFLEFT = TXTFLEFT + " AND (PlatformId = 2952855555 OR PlatformId = 2952855553)"; */}
            else if (Napr4[0].ToString() == "РК-1")
            { TXTFLEFT = TXTFLEFT + " AND PlatformId = 2952855553"; }
            else if (Napr4[0].ToString() == "РК-2")
            { TXTFLEFT = TXTFLEFT + " AND PlatformId = 2952855555"; }


            if (Napr4[1].ToString() == "Все" || Napr4[1].ToString() == "")
            {/* TXTFLEFT = TXTFLEFT + " AND (namead =  '67-ОП-РЗ-67Р-01' OR namead = '67-ОП-РЗ-67К-14')"; */}
            else if (Napr4[1].ToString() == "67-ОП-РЗ-67Р-01")
            { TXTFLEFT = TXTFLEFT + " AND namead = '67-ОП-РЗ-67Р-01'"; }
            else if (Napr4[1].ToString() == "67-ОП-РЗ-67К-14")
            { TXTFLEFT = TXTFLEFT + " AND namead = '67-ОП-РЗ-67К-14'"; }

            if (Napr4[2].ToString() == "Все" || Napr4[2].ToString() == "")
            {/* TXTFLEFT = TXTFLEFT + " AND (namenapr =  'из Севастополя' OR namenapr = 'в Севастополь')"; */}
            else if (Napr4[2].ToString() == "из Севастополя")
            { TXTFLEFT = TXTFLEFT + " AND namenapr = 'из Севастополя'"; }
            else if (Napr4[2].ToString() == "в Севастополь")
            { TXTFLEFT = TXTFLEFT + " AND namenapr = 'в Севастополь'"; }

            if (Napr4[3].ToString() == "Все" || Napr4[3].ToString() == "")
            {/* TXTFLEFT = TXTFLEFT + " AND (Lane =  1 OR Lane = 2)"; */}
            else if (Napr4[3].ToString() == "1")
            { TXTFLEFT = TXTFLEFT + " AND Lane =  1"; }
            else if (Napr4[3].ToString() == "2")
            { TXTFLEFT = TXTFLEFT + " AND Lane =  2"; }

            if (flags4[0] == true)
            { TXTFLEFT = TXTFLEFT + " AND raptssprrazr.DateVidSR > '" + Convert.ToDateTime(Napr4[4].ToString()).ToString ("yyyyMMdd") + "' "; }
            if (flags4[1] == true)
            { TXTFLEFT = TXTFLEFT + " AND raptssprrazr.DateVidSR < '" + Convert.ToDateTime(Napr4[5].ToString()).ToString("yyyyMMdd") + "' "; }

            if (flags4[3] == true)
            { TXTFLEFT = TXTFLEFT + " AND raptssprrazr.DateZapr > '" + Convert.ToDateTime(Napr4[14].ToString()).ToString("yyyyMMddHHmmss") + "' "; }
            if (flags4[4] == true)
            { TXTFLEFT = TXTFLEFT + " AND raptssprrazr.DateZapr < '" + Convert.ToDateTime(Napr4[13].ToString()).ToString("yyyyMMddHHmmss") + "' "; }

            if (Napr4[12].ToString() != "" && Napr4[12].ToString() != null)
            {
                TXTFLEFT = TXTFLEFT + " AND raptssprrazr.GRZSR LIKE '%" + Napr4[12].ToString() + "%'";
            }

            if (Napr4[8].ToString() != "" && Napr4[8].ToString() != null)
            {
                if (Napr4[9].ToString() != "" && Napr4[9].ToString() != null)
                { TXTFLEFT = TXTFLEFT + " AND (raptssprrazr.KolRazrPr >= " + Convert.ToInt32(Napr4[8].ToString()) + " and raptssprrazr.KolRazrPr <= " + Convert.ToInt32(Napr4[9].ToString()) + ")"; }
                else
                { TXTFLEFT = TXTFLEFT + " AND raptssprrazr.KolRazrPr >= " + Convert.ToInt32(Napr4[8].ToString()); }
            }

            if (Napr4[10].ToString() != "" && Napr4[10].ToString() != null)
            {
                if (Napr4[11].ToString() != "" && Napr4[11].ToString() != null)
                { TXTFLEFT = TXTFLEFT + " AND (raptssprrazr.IspolzPR >= " + Convert.ToInt32(Napr4[10].ToString()) + " and raptssprrazr.IspolzPR <= " + Convert.ToInt32(Napr4[11].ToString()) + ")"; }
                else
                { TXTFLEFT = TXTFLEFT + " AND raptssprrazr.IspolzPR >= " + Convert.ToInt32(Napr4[10].ToString()); }
            }

            if (Napr4[6].ToString() != "" && Napr4[6].ToString() != null)
            {
                if (Napr4[7].ToString() != "" && Napr4[7].ToString() != null)
                { TXTFLEFT = TXTFLEFT + " AND (raptssprrazr.NomSR >= " + Convert.ToInt32(Napr4[6].ToString()) + " and raptssprrazr.NomSR <= " + Convert.ToInt32(Napr4[7].ToString()) + ")"; }
                else
                { TXTFLEFT = TXTFLEFT + " AND raptssprrazr.NomSR >= " + Convert.ToInt32(Napr4[6].ToString()); }
            }

            TXTFLEFT = TXTFLEFT + " ORDER BY Created DESC LIMIT " + textBox14.Text + ";";

            
            flags4 = flagsSR;
           
            if (DSSR != null)
                DSSR.Clear();
            ZagrSPRAZR(0, "", "", 0, TXTFLEFT);
            
            if (toolStripLabel6.Text != "")
            {
                kol = Convert.ToInt32(toolStripLabel6.Text);
            }
            if (dataGridView15.RowCount > 1)
            {
                rowIndex = dataGridView15.SelectedCells[2].RowIndex;
                if (kol > rowIndex)
                { kol = 0; }
                int Sum = 0;
                for (int i = 0; i < dataGridView15.Rows.Count; i++)
                {
                    Sum = Sum + 1;
                }
                if (Sum - kol < Sum)
                { kol = Sum - kol; }
                dataGridView15.CurrentCell = dataGridView15[2, rowIndex + kol];
                currentRowLeft = rowIndex + kol;
                toolStripLabel6.Text = "" + (Convert.ToInt32(Sum)).ToString();
                //////Otrisovka();
            }
            else
            {            
            }
        }
        #endregion///////////////////////////////////////////

        #region //////////////////////////////////////////////////   Двойной щелчек по строке вкладки СпецРазрешения ///////////////
        private void dataGridView15_DoubleClick(object sender, EventArgs e)
        {
            if (((strus[7]) != "") && (Convert.ToInt32(strus[7]) > 0))
            {
                    if (dataGridView15.Rows.Count != 0)
                    {
                        RCS = dataGridView15.CurrentCell.RowIndex;
                        SRIDPR= Convert.ToInt32(dataGridView15[2, RCS].Value.ToString());
                    }
                    this.Cursor = Cursors.WaitCursor;
                    FormKartMonit OrdersForm = new FormKartMonit();
                    OrdersForm.FormKartMonit_LoadPMonit(Convert.ToInt32(SRIDPR), NUs, strus[13]);
                    OrdersForm.ShowDialog();
            }
        }
        #endregion///////////////////////////////////////////

        #region ///////////////////////////////    Двойной щелчек по табл Автодорог
        private void dataGridView13_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView13.Rows.Count != 0)
            {
                R1 = 0;
                R1 = dataGridView13.CurrentCell.RowIndex;
            }
            int IDKl = Convert.ToInt32(dataGridView13[0, dataGridView13.CurrentRow.Index].Value.ToString());

            FormAD OrdFormAD = new FormAD();
            OrdFormAD.FormAD_LoadRNV(IDKl);
            OrdFormAD.ShowDialog();
            if (DSAD != null)
                DSAD.Clear();
            ZagrAD();
            dataGridView13.CurrentCell = dataGridView13[1, R1];
        }
        #endregion///////////////////////////////////////////

        #region//////////////////////////////////// Загрузка справочн PUTI
        public void ZagrNastrPuti()
        {
            ConnectStr conStrPUT = new ConnectStr();
            Zapros zaprosPUT = new Zapros();
            conStrPUT.ConStr(1);
            cstrPUT = conStrPUT.StP;
            connectionPUT = new MySqlConnection(cstrPUT);
            zaprosPUT.NastrPuti(0,"");
            zPUT = zaprosPUT.commandStringTest;
            mySqlDataAdapterPUT = new MySqlDataAdapter(zPUT, connectionPUT);
            mySqlDataAdapterPUT.Fill(DSPUT);
            dataGridView17.DataSource = DSPUT.Tables[0];
        }

        

        #endregion //////////////////////////////////////////////

        #region//////////////////////////////////// Загрузка спец.разрешений
        public void ZagrSPRAZR(int IDPR, string D1, string D2, int ColROW, string TXTFiltr)
        {
            ConnectStr conStrSR = new ConnectStr();
            Zapros zaprosSR = new Zapros();
            conStrSR.ConStr(1);
            cstrSR = conStrSR.StP;
            connectionSR = new MySqlConnection(cstrSR);
            if (D1!="" && D2!="")
            { zaprosSR.SPETSRAZRESHEN(0, D1, D2, ColROW, ""); }
            else { zaprosSR.SPETSRAZRESHEN(0, "", "", 100, TXTFiltr);}
            zSR = zaprosSR.commandStringTest;
            mySqlDataAdapterSR = new MySqlDataAdapter(zSR, connectionSR);
            mySqlDataAdapterSR.Fill(DSSR);
            dataGridView15.DataSource = DSSR.Tables[0];
            ss = 0;
            for (ss = 0; ss < 2; ss++)
            { dataGridView15.Columns[ss].Visible = false; }
            dataGridView15.Columns[3].Visible = false;
            ss = 0;
            for (ss = 4; ss < 7; ss++)
            { dataGridView15.Columns[ss].Visible = false; }
            dataGridView15.Columns[8].Visible = false;
            dataGridView15.Columns[9].Visible = false;
            dataGridView15.Columns[10].Visible = false;
            ss = 0;
            for (ss = 15; ss < 17; ss++)
            { dataGridView15.Columns[ss].Visible = false; }
            ss = 0;
            for (ss = 18; ss < 51; ss++)
            { dataGridView15.Columns[ss].Visible = false; }

            dataGridView15.Columns[52].Visible = false;

            ss = 0;
            for (ss = 56; ss < 65; ss++)
            { dataGridView15.Columns[ss].Visible = false; }

            dataGridView15.Refresh();
        }
        #endregion //////////////////////////////////////////////

        #region /////////////////////////////////   Загрузка структуры для КЛАССА
        public void StrKL()
        {
            MySqlCommand command2 = new MySqlCommand();
            ConnectStr conStr2 = new ConnectStr();
            conStr2.ConStr(1);
            Zapros zapros2 = new Zapros();
            string connectionString2;//, commandString;
            connectionString2 = conStr2.StP;//"Data source=localhost;UserId=root;Password=1q2w3e$R;database=camloc;";
            MySqlConnection connection2 = new MySqlConnection(connectionString2);
            string z2 = "SELECT *"
                        + "  FROM raptklassts";//zapros2.commandStringTest;
            command2.CommandText = z2;
            command2.Connection = connection2;
            MySqlDataReader reader2;
            try
            {
                int k = 0;
                command2.Connection.Open();
                reader2 = command2.ExecuteReader();
                while (reader2.Read())
                {
                    SKL[k].KlEuro = Convert.ToInt32(reader2["Klass"].ToString());
                    SKL[k].KlRus = Convert.ToInt32(reader2["Kategory"].ToString());
                    SKL[k].KolOsKL = Convert.ToInt32(reader2["ColOsey"].ToString());
                    SKL[k].MejOsRasstKlmin1 = Convert.ToDouble(reader2["Distanc1_2Min"].ToString());
                    SKL[k].MejOsRasstKlmax1 = Convert.ToDouble(reader2["Distanc1_2Max"].ToString());
                    SKL[k].MejOsRasstKlmin2 = Convert.ToDouble(reader2["Distanc2_3Min"].ToString());
                    SKL[k].MejOsRasstKlmax2 = Convert.ToDouble(reader2["Distanc2_3Max"].ToString());
                    SKL[k].MejOsRasstKlmin3 = Convert.ToDouble(reader2["Distanc3_4Min"].ToString());
                    SKL[k].MejOsRasstKlmax3 = Convert.ToDouble(reader2["Distanc3_4Max"].ToString());
                    SKL[k].MejOsRasstKlmin4 = Convert.ToDouble(reader2["Distanc4_5Min"].ToString());
                    SKL[k].MejOsRasstKlmax4 = Convert.ToDouble(reader2["Distanc4_5Max"].ToString());
                    SKL[k].MejOsRasstKlmin5 = Convert.ToDouble(reader2["Distanc5_6Min"].ToString());
                    SKL[k].MejOsRasstKlmax5 = Convert.ToDouble(reader2["Distanc5_6Max"].ToString());
                    SKL[k].MejOsRasstKlmin6 = Convert.ToDouble(reader2["Distanc6_7Min"].ToString());
                    SKL[k].MejOsRasstKlmax6 = Convert.ToDouble(reader2["Distanc6_7Max"].ToString());
                    SKL[k].MejOsRasstKlmin7 = Convert.ToDouble(reader2["Distanc7_8Min"].ToString());
                    SKL[k].MejOsRasstKlmax7 = Convert.ToDouble(reader2["Distanc7_8Max"].ToString());
                    SKL[k].PolnMKlmin = Convert.ToDouble(reader2["PolnMassm"].ToString());
                    SKL[k].PolnMKlmax = Convert.ToDouble(reader2["PolnMassb"].ToString());
                    SKL[k].NameKL = reader2["naimklassts"].ToString();
                    SKL[k].TypeSchKl = reader2["tipschema"].ToString();
                    k = k + 1;
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
        #endregion /////////////////////////////////////////////////////
    }
} 
