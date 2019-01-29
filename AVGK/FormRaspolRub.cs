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

namespace AVGK
{
    public partial class FormRaspolRub : Form
    {
        public string cstrRub;
        public string zL;
        public string zN;
        public int IDRub = 0;
        public string KODNapr = "";
        //public string [] KODN_r = nev;
        public int k = 1;
        public int k1 = 1;
        public int idr;
        public FormRaspolRub()
        {
            InitializeComponent();
            button1.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)/////////////////////////  Закрытие формы
        {
            Close();
        }

        internal void FormRaspolRub_LoadRN(int IDRN)
        {
            button1.Visible = false;
            button2.Visible = true;
            MySqlCommand commandL = new MySqlCommand();
            ConnectStr conStrL = new ConnectStr();
            conStrL.ConStr(1);
            //Zapros zaprosL = new Zapros();
            string connectionStringL;//, commandString;
            connectionStringL = conStrL.StP;//"Data source=localhost;UserId=root;Password=1q2w3e$R;database=camloc;";
            MySqlConnection connectionL = new MySqlConnection(connectionStringL);

            //zaprosL.ZaprAllCamNaprLO(IDRN);
            zL = "SELECT " +
                "rapraspolojenrubeja.* " +
                "FROM rapraspolojenrubeja " +
                "WHERE idrub = " + IDRN;
            commandL.CommandText = zL;// commandString;
            commandL.Connection = connectionL;
            MySqlDataReader readerT;
            try
            {
                commandL.Connection.Open();
                readerT = commandL.ExecuteReader();
                while (readerT.Read())
                {

                    //    //ConnectStr conStrAD = new ConnectStr();
                    //    //conStrAD.ConStr(1);
                    //    //cstrRub = conStrAD.StP;
                    //    ////connectionRub = new MySqlConnection(cstrRub);
                    //    //MySql.Data.MySqlClient.MySqlConnection sqlConnectionT = new MySqlConnection(cstrRub);//new MySql.Data.MySqlClient.MySqlConnection("Data source = localhost; UserId = root; Password = 1q2w3e$R; database = test; ");
                    //    //MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
                    //    //cmd.CommandText = "SELECT " +
                    //    //    "rapraspolojenrubeja.* " +
                    //    //    "FROM rapraspolojenrubeja " +
                    //    //    "WHERE idrub = " + IDRN;
                    //    //cmd.Connection = sqlConnectionT;
                    //    MySqlDataReader readerT;
                    //try
                    //{
                    //    sqlConnectionT.Open();
                    //    readerT = cmd.ExecuteReader();
                    //    while (readerT.Read())
                    //    {                  
                    alphaBlendTextBox26.Text = readerT["nameapvk"].ToString();
                    alphaBlendTextBox1.Text = readerT["kodapvk"].ToString();
                    alphaBlendTextBox2.Text = readerT["sernum"].ToString();
                    alphaBlendTextBox3.Text = readerT["dislocationapvk"].ToString();
                    alphaBlendTextBox4.Text = readerT["shir"].ToString();
                    alphaBlendTextBox5.Text = readerT["dolg"].ToString();
                    alphaBlendTextBox6.Text = readerT["namead"].ToString();
                    alphaBlendTextBox7.Text = readerT["ad_znachen"].ToString();
                    alphaBlendTextBox8.Text = readerT["partad"].ToString();
                    alphaBlendTextBox9.Text = readerT["maxosnagr"].ToString();
                    alphaBlendTextBox10.Text = readerT["ogranich"].ToString();
                    alphaBlendTextBox11.Text = readerT["primechanie"].ToString();
                    alphaBlendTextBox14.Text = readerT["Speed"].ToString();
                    alphaBlendTextBox15.Text = readerT["Vladel"].ToString();
                    comboBox1.Text = readerT["TipSI"].ToString();
                    alphaBlendTextBox16.Text = readerT["Model"].ToString();
                    alphaBlendTextBox19.Text = readerT["NomSvidTipaSI"].ToString();
                    alphaBlendTextBox18.Text = readerT["DateVidSTSI"].ToString();
                    alphaBlendTextBox17.Text = readerT["RegNomSTSI"].ToString();
                    alphaBlendTextBox22.Text = readerT["NomSPSI"].ToString();
                    alphaBlendTextBox21.Text = readerT["DateVidSPSI"].ToString();
                    alphaBlendTextBox20.Text = readerT["SrokSPSI"].ToString();
                    alphaBlendTextBox23.Text = readerT["NormPravAktAD"].ToString();
                    KODNapr = readerT["kodapvk"].ToString();
                    alphaBlendTextBox31.Text = readerT["IDWim"].ToString();
                }
                IDRub = IDRN;
                readerT.Close();
            
                //cmdr.CommandText = "SELECT " +
                zN = "SELECT " +
                        "raptnapr.* " +
                        "FROM raptnapr " +
                        "WHERE raptnapr.IDKOMPL = '" + IDRN.ToString() + "'";
                commandL.CommandText = zN;// commandString;
                commandL.Connection = connectionL;
                MySqlDataReader readerr;
                if (connectionL.State == System.Data.ConnectionState.Closed)
                { connectionL.Open(); }
                //commandL.Connection.Open();
                readerr = commandL.ExecuteReader();
                int NN = 0;
                while (readerr.Read())
               
                {
                    NN = NN + 1;
                    if (NN>1)
                    {
                        alphaBlendTextBox30.Text = readerr["namenapr"].ToString();
                        //alphaBlendTextBox29.Text = readerr["KodNapr"].ToString();
                        alphaBlendTextBox28.Text = readerr["npolos"].ToString();
                    }
                    else {
                        alphaBlendTextBox27.Text = readerr["namenapr"].ToString();
                        //alphaBlendTextBox25.Text = readerr["KodNapr"].ToString();
                        alphaBlendTextBox24.Text = readerr["npolos"].ToString();
                    }
                    

                }

                readerr.Close();
            }

            catch (MySqlException ex)
            {
                Console.WriteLine("Error: \r\n{0}", ex.ToString());
            }
            finally
            {
                commandL.Connection.Close();
            }
            //catch (MySqlException ex)
            //{
            //    Console.WriteLine("Error: \r\n{0}", ex.ToString());
            //}
            //finally
            //{
            //    cmdr.Connection.Close();
            //}
        }
        internal void FormRaspolRub_LoadRNV(int IDRN)
        {
            button1.Visible = false;
            button2.Visible = false;
            MySqlCommand commandL = new MySqlCommand();
            ConnectStr conStrL = new ConnectStr();
            conStrL.ConStr(1);
            //Zapros zaprosL = new Zapros();
            string connectionStringL;//, commandString;
            connectionStringL = conStrL.StP;//"Data source=localhost;UserId=root;Password=1q2w3e$R;database=camloc;";
            MySqlConnection connectionL = new MySqlConnection(connectionStringL);

            //zaprosL.ZaprAllCamNaprLO(IDRN);
            zL = "SELECT " +
                "rapraspolojenrubeja.* " +
                "FROM rapraspolojenrubeja " +
                "WHERE idrub = " + IDRN;
            commandL.CommandText = zL;// commandString;
            commandL.Connection = connectionL;
            MySqlDataReader readerT;
            try
            {
                commandL.Connection.Open();
                readerT = commandL.ExecuteReader();
                while (readerT.Read())
                {                
                    alphaBlendTextBox26.Text = readerT["nameapvk"].ToString();
                    alphaBlendTextBox1.Text = readerT["kodapvk"].ToString();
                    alphaBlendTextBox2.Text = readerT["sernum"].ToString();
                    alphaBlendTextBox3.Text = readerT["dislocationapvk"].ToString();
                    alphaBlendTextBox4.Text = readerT["shir"].ToString();
                    alphaBlendTextBox5.Text = readerT["dolg"].ToString();
                    alphaBlendTextBox6.Text = readerT["namead"].ToString();
                    alphaBlendTextBox7.Text = readerT["ad_znachen"].ToString();
                    alphaBlendTextBox8.Text = readerT["partad"].ToString();
                    alphaBlendTextBox9.Text = readerT["maxosnagr"].ToString();
                    alphaBlendTextBox10.Text = readerT["ogranich"].ToString();
                    alphaBlendTextBox11.Text = readerT["primechanie"].ToString();
                    alphaBlendTextBox14.Text = readerT["Speed"].ToString();
                    alphaBlendTextBox15.Text = readerT["Vladel"].ToString();
                    comboBox1.Text = readerT["TipSI"].ToString();
                    alphaBlendTextBox16.Text = readerT["Model"].ToString();
                    alphaBlendTextBox19.Text = readerT["NomSvidTipaSI"].ToString();
                    alphaBlendTextBox18.Text = readerT["DateVidSTSI"].ToString();
                    alphaBlendTextBox17.Text = readerT["RegNomSTSI"].ToString();
                    alphaBlendTextBox22.Text = readerT["NomSPSI"].ToString();
                    alphaBlendTextBox21.Text = readerT["DateVidSPSI"].ToString();
                    alphaBlendTextBox20.Text = readerT["SrokSPSI"].ToString();
                    alphaBlendTextBox23.Text = readerT["NormPravAktAD"].ToString();
                    KODNapr = readerT["kodapvk"].ToString();
                    alphaBlendTextBox31.Text = readerT["IDWim"].ToString();
                }
                IDRub = IDRN;
                readerT.Close();

                zN = "SELECT " +
                        "raptnapr.* " +
                        "FROM raptnapr " +
                        "WHERE raptnapr.IDKOMPL = '" + IDRN.ToString() + "'";
                commandL.CommandText = zN;// commandString;
                commandL.Connection = connectionL;
                MySqlDataReader readerr;
                if (connectionL.State == System.Data.ConnectionState.Closed)
                { connectionL.Open(); }
                readerr = commandL.ExecuteReader();
                int NN = 0;
                while (readerr.Read())

                {
                    NN = NN + 1;
                    if (NN > 1)
                    {
                        alphaBlendTextBox30.Text = readerr["namenapr"].ToString();
                        alphaBlendTextBox28.Text = readerr["npolos"].ToString();
                    }
                    else
                    {
                        alphaBlendTextBox27.Text = readerr["namenapr"].ToString();
                        alphaBlendTextBox24.Text = readerr["npolos"].ToString();
                    }
                }
                readerr.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: \r\n{0}", ex.ToString());
            }
            finally
            {
                commandL.Connection.Close();
            }           
        }
        private void button2_Click(object sender, EventArgs e)////////////////////////////   Сохранение изменений в рубеже и направлении
        {
            if (alphaBlendTextBox14.Text=="")
            {
                alphaBlendTextBox14.Text = "0";
            }
            MySqlCommand command = new MySqlCommand();
            ConnectStr conStr = new ConnectStr();
            conStr.ConStr(1);
            //Zapros zapros = new Zapros();
            string connectionString;
            connectionString = conStr.StP;
            MySqlConnection connection = new MySqlConnection(connectionString);
            string z = "UPDATE rapraspolojenrubeja" +
                    " SET nameapvk ='" + alphaBlendTextBox26.Text.ToString() + "', " +
                    "kodapvk = '" + alphaBlendTextBox1.Text.ToString() + "', " +
                    "sernum = '" + alphaBlendTextBox2.Text.ToString() + "', " +
                    "dislocationapvk = '" + alphaBlendTextBox3.Text.ToString() + "', " +
                    "shir = " + Convert.ToDecimal(alphaBlendTextBox4.Text.Replace(",", ".").ToString()) + ", " +
                    "dolg = " + Convert.ToDecimal(alphaBlendTextBox5.Text.Replace(",", ".").ToString()) + ", " +
                    "ad_znachen = '" + alphaBlendTextBox7.Text.ToString() + "', " +
                    "maxosnagr = " + Convert.ToDouble(alphaBlendTextBox9.Text.ToString()) + ", " +
                    "namead = '" + alphaBlendTextBox6.Text.ToString() + "', " +
                    "partad = '" + alphaBlendTextBox8.Text.ToString() + "', " +
                    "ogranich = '" + alphaBlendTextBox10.Text.ToString() + "', " +
                    "Speed = " + Convert.ToDouble(alphaBlendTextBox14.Text.ToString()) + ", " +
                    "primechanie = '" + alphaBlendTextBox11.Text.ToString() + "', " +
                    "IDWim = '" + alphaBlendTextBox31.Text.ToString() + "', " +
                    //"IDDir = '" + alphaBlendTextBox26.Text.ToString() + "', " +
                    //"Vladel = '" + alphaBlendTextBox26.Text.ToString() + "', " +
                    "TipSI = '" + comboBox1.Text.ToString() + "', " +
                    "Model = '" + alphaBlendTextBox16.Text.ToString() + "', " +
                    "NomSvidTipaSI = '" + alphaBlendTextBox19.Text.ToString() + "', " +
                    "DateVidSTSI = '" + alphaBlendTextBox18.Text.ToString() + "', " +
                    "RegNomSTSI = '" + alphaBlendTextBox17.Text.ToString() + "', " +
                    "NomSPSI = '" + alphaBlendTextBox22.Text.ToString() + "', " +
                    "DateVidSPSI = '" + alphaBlendTextBox21.Text.ToString() + "', " +
                    "SrokSPSI = '" + alphaBlendTextBox20.Text.ToString() + "', " +
                    "NormPravAktAD = '" + alphaBlendTextBox23.Text.ToString() + "' " +
                    //"CheckPointCode = '" + alphaBlendTextBox26.Text.ToString() + "' " +
                    "WHERE idrub = " + IDRub;
           
            command.CommandText = z;
            command.Connection = connection;

            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();
            //Close(); 

            for (int i = 1; i < 3; i++)
            {
                if (i == 1)
                {
                    KODNapr = "1";// alphaBlendTextBox25.Text;
                    //MySqlCommand command = new MySqlCommand();
                    //ConnectStr conStr = new ConnectStr();
                    conStr.ConStr(1);
                    //Zapros zapros = new Zapros();
                    //string connectionString;
                    connectionString = conStr.StP;
                    //MySqlConnection connection = new MySqlConnection(connectionString);
                    z = "UPDATE raptnapr " +
                       "SET namenapr = '" + alphaBlendTextBox27.Text.ToString() + "', " +
                       "npolos = " + Convert.ToInt32(alphaBlendTextBox24.Text.ToString()) + " , " +
                        "PlatfID = '" + alphaBlendTextBox31.Text.ToString() + "' , " +
                       "KodNapr = '1'" + //alphaBlendTextBox25.Text.ToString() + "'" +
                       " WHERE KodNapr = '" + KODNapr + "' AND raptnapr.IDKOMPL = '" + IDRub.ToString() + "'";
                    command.CommandText = z;
                    command.Connection = connection;

                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }
                else
                {
                    KODNapr = "1";// alphaBlendTextBox25.Text;
                    //MySqlCommand command = new MySqlCommand();
                    //ConnectStr conStr = new ConnectStr();
                    conStr.ConStr(1);
                    //Zapros zapros = new Zapros();
                    //string connectionString;
                    connectionString = conStr.StP;
                    //MySqlConnection connection = new MySqlConnection(connectionString);
                    z = "UPDATE raptnapr " +
                       "SET namenapr = '" + alphaBlendTextBox30.Text.ToString() + "', " +
                       "npolos = " + Convert.ToInt32(alphaBlendTextBox28.Text.ToString()) + " , " +
                       "PlatfID = '" + alphaBlendTextBox31.Text.ToString() + "' , " +
                       "KodNapr = '1'" +
                       " WHERE KodNapr = '" + KODNapr + "' AND raptnapr.IDKOMPL = '" + IDRub.ToString() + "'";
                    command.CommandText = z;
                    command.Connection = connection;

                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }
            }
            Close();
        }

        private void button1_Click(object sender, EventArgs e)////////////////////////////   Добавление рубежа и направления
        {

            MySqlCommand command = new MySqlCommand();
            ConnectStr conStr = new ConnectStr();
            conStr.ConStr(1);
            //Zapros zapros = new Zapros();
            string connectionString;
            connectionString = conStr.StP;
            MySqlConnection connection = new MySqlConnection(connectionString);
            string z = "INSERT INTO rapraspolojenrubeja" +
                    "(nameapvk, " +
                    "kodapvk, " +
                    "sernum, " +
                    "dislocationapvk, " +
                    "shir, " +
                    "dolg, " +
                    "ad_znachen, " +
                    "maxosnagr, " +
                    "namead, " +
                    "partad, " +
                    "ogranich, " +
                    "Speed, " +
                    "primechanie, " +
                    "TipSI, " +
                    "Model, " +
                    "NomSvidTipaSI, " +
                    "DateVidSTSI, " +
                    "RegNomSTSI, " +
                    "NomSPSI, " +
                    "DateVidSPSI, " +
                    "SrokSPSI, " +
                     "IDWim, " +
                    "NormPravAktAD) " +
                    " VALUES(" +
                    "'" + alphaBlendTextBox26.Text.ToString() + "', " +
                    "'" + alphaBlendTextBox1.Text.ToString() + "', " +
                    "'" + alphaBlendTextBox2.Text.ToString() + "', " +
                    "'" + alphaBlendTextBox3.Text.ToString() + "', " +
                    "" + Convert.ToDecimal(alphaBlendTextBox4.Text.Replace(",", ".").ToString()) + ", " +
                    "" + Convert.ToDecimal(alphaBlendTextBox5.Text.Replace(",", ".").ToString()) + ", " +
                    "'" + alphaBlendTextBox7.Text.ToString() + "', " +
                    "" + Convert.ToDouble(alphaBlendTextBox9.Text.ToString()) + ", " +
                    "'" + alphaBlendTextBox6.Text.ToString() + "', " +
                    "'" + alphaBlendTextBox8.Text.ToString() + "', " +
                    "'" + alphaBlendTextBox10.Text.ToString() + "', " +
                    "" + Convert.ToDouble(alphaBlendTextBox14.Text.ToString()) + ", " +
                    "'" + alphaBlendTextBox11.Text.ToString() + "', " +
                    "'" + comboBox1.Text.ToString() + "', " +
                    "'" + alphaBlendTextBox16.Text.ToString() + "', " +
                    "'" + alphaBlendTextBox19.Text.ToString() + "', " +
                    "'" + alphaBlendTextBox18.Text.ToString() + "', " +
                    "'" + alphaBlendTextBox17.Text.ToString() + "', " +
                    "'" + alphaBlendTextBox22.Text.ToString() + "', " +
                    "'" + alphaBlendTextBox21.Text.ToString() + "', " +
                    "'" + alphaBlendTextBox20.Text.ToString() + "', " +
                     "'" + alphaBlendTextBox31.Text.ToString() + "', " +
                    "'" + alphaBlendTextBox23.Text.ToString() + "' )";

            //"nameapvk, " +
            //        "kodapvk, " +
            //        "sernum, " +
            //        "dislocationapvk, " +
            //        "shir, " +
            //        "dolg, " +
            //        "namead, " +
            //        "ad_znachen, " +
            //        "partad, " +
            //        "maxosnagr, " +
            //        "ogranich, " +
            //        "primechanie, " +
            //         " Vladel, " +
            //        " TipSI, " +
            //        " Model, " +
            //        " NomSvidTipaSI, " +
            //        " DateVidSTSI, " +
            //        " RegNomSTSI, " +
            //        " NomSPSI, " +
            //        " DateVidSPSI, " +
            //        " SrokSPSI, " +
            //        " NormPravAktAD, " +
            //        " Speed, " + 
            //        "IDWim, " +
            //        "IDDir)" +
            //        " VALUES('" + alphaBlendTextBox26.Text.ToString() + "', " +
            //    "'" + alphaBlendTextBox1.Text.ToString() + "' , " +
            //    "'" + alphaBlendTextBox2.Text.ToString() + "' , " +
            //    "'" + alphaBlendTextBox3.Text.ToString() + "' , " +
            //    "'" + Convert.ToDecimal(alphaBlendTextBox4.Text.Replace(",", ".").ToString()) + "' , " +
            //    "'" + Convert.ToDecimal(alphaBlendTextBox5.Text.Replace(",", ".").ToString()) + "' , " +
            //    "'" + alphaBlendTextBox6.Text.ToString() + "' , " +
            //    "'" + alphaBlendTextBox7.Text.ToString() + "' , " +
            //    "'" + alphaBlendTextBox8.Text.ToString() + "' , " +
            //    "'" + Convert.ToDouble(alphaBlendTextBox9.Text.ToString()) + "' , " +
            //    "'" + alphaBlendTextBox10.Text.ToString() + "' , " +
            //    "'" + alphaBlendTextBox11.Text.ToString() + "' , " +
            //    "'" + alphaBlendTextBox15.Text.ToString() + "', " +
            //    "'" + comboBox1.Text.ToString() + "', " +
            //    "'" + alphaBlendTextBox16.Text.ToString() + "', " +
            //    "'" + alphaBlendTextBox19.Text.ToString() + "', " +
            //    "'" + alphaBlendTextBox18.Text.ToString() + "', " +
            //    "'" + alphaBlendTextBox17.Text.ToString() + "', " +
            //    "'" + alphaBlendTextBox22.Text.ToString() + "', " +
            //    "'" + alphaBlendTextBox21.Text.ToString() + "', " +
            //    "'" + alphaBlendTextBox20.Text.ToString() + "', " +
            //    "'" + alphaBlendTextBox23.Text.ToString() + "', " +
            //    "'" + Convert.ToInt32(alphaBlendTextBox14.Text.ToString()) + "', " +
            //    "'" + alphaBlendTextBox1.Text.ToString() + "' , " +
            //    "" + Convert.ToInt32(alphaBlendTextBox1.Text.Substring(alphaBlendTextBox1.Text.Length - 1, 1).ToString()) + " )";
            command.CommandText = z;
            command.Connection = connection;

            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();
            ////////////////////////////////////////////////////////// запрашиваем idr -последний добавленный рубеж
            MySqlCommand commandL = new MySqlCommand();
            ConnectStr conStrL = new ConnectStr();
            conStrL.ConStr(1);
            //Zapros zaprosL = new Zapros();
            string connectionStringL;//, commandString;
            connectionStringL = conStrL.StP;//"Data source=localhost;UserId=root;Password=1q2w3e$R;database=camloc;";
            MySqlConnection connectionL = new MySqlConnection(connectionStringL);

            //zaprosL.ZaprAllCamNaprLO(IDRN);
            zL = " SELECT " +
  "MAX(rapraspolojenrubeja.idrub) AS MR "+
"FROM rapraspolojenrubeja";
            commandL.CommandText = zL;// commandString;
            commandL.Connection = connectionL;
            MySqlDataReader readerT;
            try
            {
                commandL.Connection.Open();
                readerT = commandL.ExecuteReader();
                while (readerT.Read())
                {
                    idr = Convert.ToInt32(readerT["MR"].ToString());                    
                }               
                readerT.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: \r\n{0}", ex.ToString());
            }
            //finally
            //{
            //    cmd1.Connection.Close();
            //}


            ////////////////////////////////////////////////////////// создаем правое направление полосы
            for (int i = 1; i < 3; i++)
            {
                if (i == 1)
                {
                    KODNapr = "1";// alphaBlendTextBox25.Text;
                    //MySqlCommand command = new MySqlCommand();
                    //ConnectStr conStr = new ConnectStr();
                    conStr.ConStr(1);
                    //Zapros zapros = new Zapros();
                    //string connectionString;
                    connectionString = conStr.StP;
                    //MySqlConnection connection = new MySqlConnection(connectionString);
                    z = "INSERT INTO raptnapr (namenapr, " +
           "npolos, " +
           "KodNapr, " +
           "IDKOMPL, " +
           "PlatfID, " +
           "Napr) " +
           "VALUES " +
           "('" + alphaBlendTextBox27.Text.ToString() + "', " +
           "" + Convert.ToInt32(alphaBlendTextBox24.Text.ToString()) + ", " +
           "'1', " + //alphaBlendTextBox25.Text.ToString() + "', " +
           "" + idr + ", " +
           "'" + alphaBlendTextBox31.Text.ToString() + "' , " +
           "'правое')";
                    command.CommandText = z;
                    command.Connection = connection;

                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }
                else
                {
                    KODNapr = "1";// alphaBlendTextBox25.Text;
                    //MySqlCommand command = new MySqlCommand();
                    //ConnectStr conStr = new ConnectStr();
                    conStr.ConStr(1);
                    //Zapros zapros = new Zapros();
                    //string connectionString;
                    connectionString = conStr.StP;
                    //MySqlConnection connection = new MySqlConnection(connectionString);
                    z = "INSERT INTO raptnapr (namenapr, " +
           "npolos, " +
           "KodNapr, " +
           "IDKOMPL, " +
           "PlatfID, " +
           "Napr) " +
           "VALUES " +
           "('" + alphaBlendTextBox30.Text.ToString() + "', " +
           "" + Convert.ToInt32(alphaBlendTextBox28.Text.ToString()) + ", " +
           "'1', " + //alphaBlendTextBox29.Text.ToString() + "', " +
           "" + idr + ", " +
           "'" + alphaBlendTextBox31.Text.ToString() + "' , " +
           "'левое')";
                    command.CommandText = z;
                    command.Connection = connection;

                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }
            }

            Close();
        }
    }
}
