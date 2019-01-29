using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;

namespace AVGK
{
    public class UsUpd
    {
        public string commandStringTest;
        //private MySqlConnection connectionU;
        //private MySqlDataAdapter mySqlDataAdapterU;
        public string cstrU;
        public string zU;
        public DataSet DSU = new DataSet();

        public void butAdd(string[] Us)///////////// Кнопка сохранить (добавить) //////////////////////
        {
            ConnectStr conStrU = new ConnectStr();
            Zapros zaprosU = new Zapros();
            //int IDU = 0;
            conStrU.ConStr(1);
            //zaprosU.KartUser(0);
            cstrU = conStrU.StP;
            MySql.Data.MySqlClient.MySqlConnection sqlConnectionT = new MySql.Data.MySqlClient.MySqlConnection(cstrU);
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
            cmd.CommandText = "INSERT INTO raptuser (user," +
                 " passuser," +
                 " d2," +
                 " d3," +
                 " r1," +
                 " r2," +
                 " r3," +
                 " r4," +
                 " r5," +
                 " r6," +
                 " r7," +
                 " r8," +
                 " r9," +
                 " r10," +
                  " r11," +
                   " r12," +
                   "r13, " +
                 " famu," +
                 " nameu," +
                 " otchu," +
                 " doljnostu," +
                 " telu," +
                 " E_mail) " +
                 "VALUES(" +
                 "'" + Us[1] + "'," +
                 "'" + Us[2] + "'," +
                " DEFAULT," +
                 " DEFAULT," +
                  "'" + Convert.ToInt32(Us[9]) + "'," +
                 "'" + Convert.ToInt32(Us[10]) + "'," +
                  "'" + Convert.ToInt32(Us[11]) + "'," +
                  "'" + Convert.ToInt32(Us[12]) + "'," +
                  "'" + Convert.ToInt32(Us[13]) + "'," +
                  "'" + Convert.ToInt32(Us[14]) + "'," +
                  "'" + Convert.ToInt32(Us[15]) + "'," +
                 "'" + Convert.ToInt32(Us[16]) + "'," +
                 "'" + Convert.ToInt32(Us[17]) + "'," +
                 "'" + Convert.ToInt32(Us[18]) + "'," +
                  "'" + Convert.ToInt32(Us[19]) + "'," +
                   "'" + Convert.ToInt32(Us[20]) + "'," +
                   "'" + Convert.ToInt32(Us[21]) + "', " +
                 "'" + Us[3] + "'," +
                 "'" + Us[4] + "'," +
                 "'" + Us[5] + "'," +
                 "'" + Us[6] + "'," +
                 "'" + Us[7] + "'," +
                 "'" + Us[8] + "')";            
            cmd.Connection = sqlConnectionT;

            sqlConnectionT.Open();
            cmd.ExecuteNonQuery();
            sqlConnectionT.Close();
            //Close();
        }
        #region         
        //////internal void FormKlass_LoadP(int IDTS)
        //////{
        //////    button1.Visible = false;
        //////    button2.Visible = true;
        //////    MySql.Data.MySqlClient.MySqlConnection sqlConnectionT = new MySql.Data.MySqlClient.MySqlConnection("Data source = localhost; UserId = root; Password = 1q2w3e$R; database = test; ");
        //////    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
        //////    cmd.CommandText = "SELECT " +
        //////        "raptklassts.Klass," +
        //////        " raptklassts.naimklassts," +
        //////        " raptklassts.tipschema," +
        //////        " raptklassts.ColOsey," +
        //////        " raptklassts.Distanc1_2Min," +
        //////        " raptklassts.Distanc1_2Max," +
        //////        " raptklassts.Distanc2_3Min," +
        //////        " raptklassts.Distanc2_3Max," +
        //////        " raptklassts.Distanc3_4Min," +
        //////        " raptklassts.Distanc3_4Max," +
        //////        " raptklassts.Distanc4_5Min," +
        //////        " raptklassts.Distanc4_5Max," +
        //////        " raptklassts.Distanc5_6Min," +
        //////        " raptklassts.Distanc5_6Max," +
        //////        " raptklassts.Distanc6_7Min," +
        //////        " raptklassts.Distanc6_7Max," +
        //////        " raptklassts.Distanc7_8Min," +
        //////        " raptklassts.Distanc7_8Max," +
        //////        " raptklassts.MaxOsNagrm161," +
        //////        " raptklassts.MaxOsNagrm162," +
        //////        " raptklassts.MaxOsNagrm111," +
        //////        " raptklassts.MaxOsNagrm112," +
        //////        " raptklassts.MaxOsNagrm121," +
        //////        " raptklassts.MaxOsNagrm122," +
        //////        " raptklassts.MaxOsNagrm261," +
        //////        " raptklassts.MaxOsNagrm262," +
        //////        " raptklassts.MaxOsNagrm211," +
        //////        " raptklassts.MaxOsNagrm212," +
        //////        " raptklassts.MaxOsNagrm221," +
        //////        " raptklassts.MaxOsNagrm222," +
        //////        " raptklassts.MaxOsNagrm361," +
        //////        " raptklassts.MaxOsNagrm362," +
        //////        " raptklassts.MaxOsNagrm311," +
        //////        " raptklassts.MaxOsNagrm312," +
        //////        " raptklassts.MaxOsNagrm321," +
        //////        " raptklassts.MaxOsNagrm322," +
        //////        " raptklassts.MaxOsNagrm461," +
        //////        " raptklassts.MaxOsNagrm462," +
        //////        " raptklassts.MaxOsNagrm411," +
        //////        " raptklassts.MaxOsNagrm412," +
        //////        " raptklassts.MaxOsNagrm421," +
        //////        " raptklassts.MaxOsNagrm422," +
        //////        " raptklassts.MaxOsNagrm561," +
        //////        " raptklassts.MaxOsNagrm562," +
        //////        " raptklassts.MaxOsNagrm511," +
        //////        " raptklassts.MaxOsNagrm512," +
        //////        " raptklassts.MaxOsNagrm521," +
        //////        " raptklassts.MaxOsNagrm522," +
        //////        " raptklassts.MaxOsNagrm661," +
        //////        " raptklassts.MaxOsNagrm662," +
        //////        " raptklassts.MaxOsNagrm611," +
        //////        " raptklassts.MaxOsNagrm612," +
        //////        " raptklassts.MaxOsNagrm621," +
        //////        " raptklassts.MaxOsNagrm622," +
        //////        " raptklassts.MaxOsNagrm761," +
        //////        " raptklassts.MaxOsNagrm762," +
        //////        " raptklassts.MaxOsNagrm711," +
        //////        " raptklassts.MaxOsNagrm712," +
        //////        " raptklassts.MaxOsNagrm721," +
        //////        " raptklassts.MaxOsNagrm722," +
        //////         "raptklassts.MaxOsNagrm861," +
        //////         "raptklassts.MaxOsNagrm862," +
        //////         "raptklassts.MaxOsNagrm811," +
        //////         "raptklassts.MaxOsNagrm812," +
        //////         "raptklassts.MaxOsNagrm821," +
        //////         "raptklassts.MaxOsNagrm822," +
        //////        " raptklassts.Kategory," +
        //////        " raptklassts.PolnMassb," +
        //////        " raptklassts.SubCategory," +
        //////        " raptklassts.PolnMassm," +
        //////        " raptklassts.prim " +
        //////        "FROM raptklassts " +
        //////        "WHERE raptklassts.idklassts = " + IDTS;
        //////    cmd.Connection = sqlConnectionT;
        //////    MySqlDataReader readerT;
        //////    try
        //////    {
        //////        sqlConnectionT.Open();
        //////        readerT = cmd.ExecuteReader();
        //////        while (readerT.Read())
        //////        {
        //////            alphaBlendTextBox26.Text = readerT["Klass"].ToString();
        //////            alphaBlendTextBox1.Text = readerT["naimklassts"].ToString();
        //////            alphaBlendTextBox2.Text = readerT["tipschema"].ToString();
        //////            alphaBlendTextBox3.Text = readerT["ColOsey"].ToString();
        //////            alphaBlendTextBox4.Text = readerT["Distanc1_2Min"].ToString();
        //////            alphaBlendTextBox5.Text = readerT["Distanc1_2Max"].ToString();
        //////            alphaBlendTextBox6.Text = readerT["Distanc2_3Min"].ToString();
        //////            alphaBlendTextBox7.Text = readerT["Distanc2_3Max"].ToString();
        //////            alphaBlendTextBox8.Text = readerT["Distanc3_4Min"].ToString();
        //////            alphaBlendTextBox9.Text = readerT["Distanc3_4Max"].ToString();
        //////            alphaBlendTextBox10.Text = readerT["Distanc4_5Min"].ToString();
        //////            alphaBlendTextBox11.Text = readerT["Distanc4_5Max"].ToString();
        //////            alphaBlendTextBox12.Text = readerT["Distanc5_6Min"].ToString();
        //////            alphaBlendTextBox13.Text = readerT["Distanc5_6Max"].ToString();
        //////            alphaBlendTextBox14.Text = readerT["Distanc6_7Min"].ToString();
        //////            alphaBlendTextBox15.Text = readerT["Distanc6_7Max"].ToString();
        //////            alphaBlendTextBox16.Text = readerT["Distanc7_8Min"].ToString();
        //////            alphaBlendTextBox17.Text = readerT["Distanc7_8Max"].ToString();
        //////            alphaBlendTextBox32.Text = readerT["MaxOsNagrm161"].ToString();
        //////            alphaBlendTextBox39.Text = readerT["MaxOsNagrm162"].ToString();
        //////            alphaBlendTextBox46.Text = readerT["MaxOsNagrm111"].ToString();
        //////            alphaBlendTextBox53.Text = readerT["MaxOsNagrm112"].ToString();
        //////            alphaBlendTextBox60.Text = readerT["MaxOsNagrm121"].ToString();
        //////            alphaBlendTextBox67.Text = readerT["MaxOsNagrm122"].ToString();
        //////            alphaBlendTextBox31.Text = readerT["MaxOsNagrm261"].ToString();
        //////            alphaBlendTextBox38.Text = readerT["MaxOsNagrm262"].ToString();
        //////            alphaBlendTextBox45.Text = readerT["MaxOsNagrm211"].ToString();
        //////            alphaBlendTextBox52.Text = readerT["MaxOsNagrm212"].ToString();
        //////            alphaBlendTextBox59.Text = readerT["MaxOsNagrm221"].ToString();
        //////            alphaBlendTextBox66.Text = readerT["MaxOsNagrm222"].ToString();
        //////            alphaBlendTextBox30.Text = readerT["MaxOsNagrm361"].ToString();
        //////            alphaBlendTextBox37.Text = readerT["MaxOsNagrm362"].ToString();
        //////            alphaBlendTextBox44.Text = readerT["MaxOsNagrm311"].ToString();
        //////            alphaBlendTextBox51.Text = readerT["MaxOsNagrm312"].ToString();
        //////            alphaBlendTextBox58.Text = readerT["MaxOsNagrm321"].ToString();
        //////            alphaBlendTextBox65.Text = readerT["MaxOsNagrm322"].ToString();
        //////            alphaBlendTextBox29.Text = readerT["MaxOsNagrm461"].ToString();
        //////            alphaBlendTextBox36.Text = readerT["MaxOsNagrm462"].ToString();
        //////            alphaBlendTextBox43.Text = readerT["MaxOsNagrm411"].ToString();
        //////            alphaBlendTextBox50.Text = readerT["MaxOsNagrm412"].ToString();
        //////            alphaBlendTextBox57.Text = readerT["MaxOsNagrm421"].ToString();
        //////            alphaBlendTextBox64.Text = readerT["MaxOsNagrm422"].ToString();
        //////            alphaBlendTextBox28.Text = readerT["MaxOsNagrm561"].ToString();
        //////            alphaBlendTextBox35.Text = readerT["MaxOsNagrm562"].ToString();
        //////            alphaBlendTextBox42.Text = readerT["MaxOsNagrm511"].ToString();
        //////            alphaBlendTextBox49.Text = readerT["MaxOsNagrm512"].ToString();
        //////            alphaBlendTextBox56.Text = readerT["MaxOsNagrm521"].ToString();
        //////            alphaBlendTextBox63.Text = readerT["MaxOsNagrm522"].ToString();
        //////            alphaBlendTextBox27.Text = readerT["MaxOsNagrm661"].ToString();
        //////            alphaBlendTextBox34.Text = readerT["MaxOsNagrm662"].ToString();
        //////            alphaBlendTextBox41.Text = readerT["MaxOsNagrm611"].ToString();
        //////            alphaBlendTextBox48.Text = readerT["MaxOsNagrm612"].ToString();
        //////            alphaBlendTextBox55.Text = readerT["MaxOsNagrm621"].ToString();
        //////            alphaBlendTextBox62.Text = readerT["MaxOsNagrm622"].ToString();
        //////            alphaBlendTextBox25.Text = readerT["MaxOsNagrm761"].ToString();
        //////            alphaBlendTextBox33.Text = readerT["MaxOsNagrm762"].ToString();
        //////            alphaBlendTextBox40.Text = readerT["MaxOsNagrm711"].ToString();
        //////            alphaBlendTextBox47.Text = readerT["MaxOsNagrm712"].ToString();
        //////            alphaBlendTextBox54.Text = readerT["MaxOsNagrm721"].ToString();
        //////            alphaBlendTextBox61.Text = readerT["MaxOsNagrm722"].ToString();
        //////            alphaBlendTextBox73.Text = readerT["MaxOsNagrm861"].ToString();
        //////            alphaBlendTextBox72.Text = readerT["MaxOsNagrm862"].ToString();
        //////            alphaBlendTextBox71.Text = readerT["MaxOsNagrm811"].ToString();
        //////            alphaBlendTextBox70.Text = readerT["MaxOsNagrm812"].ToString();
        //////            alphaBlendTextBox69.Text = readerT["MaxOsNagrm821"].ToString();
        //////            alphaBlendTextBox68.Text = readerT["MaxOsNagrm822"].ToString();
        //////            alphaBlendTextBox22.Text = readerT["Kategory"].ToString();
        //////            alphaBlendTextBox21.Text = readerT["PolnMassb"].ToString();
        //////            alphaBlendTextBox23.Text = readerT["SubCategory"].ToString();
        //////            alphaBlendTextBox20.Text = readerT["PolnMassm"].ToString();
        //////            alphaBlendTextBox24.Text = readerT["prim"].ToString();

        //////        }
        //////        IDKL = IDTS;
        //////        readerT.Close();
        //////    }
        //////    catch (MySqlException ex)
        //////    {
        //////        Console.WriteLine("Error: \r\n{0}", ex.ToString());
        //////    }
        //////    finally
        //////    {
        //////        cmd.Connection.Close();
        //////    }
        //////}
        #endregion
        public void butUP(string[] Us)///////////// Кнопка ОБНОВИТЬ //////////////////////
        {
            ConnectStr conStrU = new ConnectStr();
            Zapros zaprosU = new Zapros();
            //int IDU = 0;
            conStrU.ConStr(1);
            //zaprosU.KartUser(0);
            cstrU = conStrU.StP;
            MySql.Data.MySqlClient.MySqlConnection sqlConnectionT = new MySql.Data.MySqlClient.MySqlConnection(cstrU);
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
            cmd.CommandText = "UPDATE raptuser " +
                "SET user = '" + Us[1] + "', " +
                "passuser = '" + Us[2] + "' , " +
                " r1 = " + Convert.ToInt32(Us[9]) + " , " +
                 " r2 = " + Convert.ToInt32(Us[10]) + " , " +
                  " r3 = " + Convert.ToInt32(Us[11]) + " , " +
                   " r4 = " + Convert.ToInt32(Us[12]) + " , " +
                    " r5 = " + Convert.ToInt32(Us[13]) + " , " +
                     " r6 = " + Convert.ToInt32(Us[14]) + " , " +
                      " r7 = " + Convert.ToInt32(Us[15]) + " , " +
                      " r8 = " + Convert.ToInt32(Us[16]) + " , " +
                      " r9 = " + Convert.ToInt32(Us[17]) + " , " +
                      " r10 = " + Convert.ToInt32(Us[18]) + " , " +
                       " r11 = " + Convert.ToInt32(Us[19]) + " , " +
                        " r12 = " + Convert.ToInt32(Us[20]) + " , " +
                        " r13 = " + Convert.ToInt32(Us[21]) + " , " +
                       " famu = '" + Us[3] + "' , " +
                        " nameu = '" + Us[4] + "' , " +
                        " otchu = '" + Us[5] + "' , " +
                        " doljnostu = '" + Us[6] + "' , " +
                        " telu = '" + Us[7] + "' , " +
                        " E_mail = '" + Us[8] +
                "' WHERE iduser = " + Convert.ToInt32(Us[0]);
           

            cmd.Connection = sqlConnectionT;

            sqlConnectionT.Open();
            cmd.ExecuteNonQuery();
            sqlConnectionT.Close();
            //Close();
        }
    }
}
