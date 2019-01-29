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
    public partial class FormKlass : Form
    {
        public DataSet DSKL = new DataSet();
        public int IDKL = 0;
        public FormKlass()
        {
            InitializeComponent();
            button1.Visible = true;
        }
        private void button1_Click(object sender, EventArgs e)///////////// Кнопка сохранить (добавить) //////////////////////
        {
            MySqlCommand command = new MySqlCommand();
            ConnectStr conStr = new ConnectStr();
            conStr.ConStr(1);
            //Zapros zapros = new Zapros();
            string connectionString;
            connectionString = conStr.StP;
            MySqlConnection connection = new MySqlConnection(connectionString);
            string z = "INSERT raptklassts (Klass, " +
                 "naimklassts, " +
                 "tipschema, " +
                 "ColOsey, " +
                 "Distanc1_2Min, " +
                 "Distanc1_2Max, " +
                 "Distanc2_3Min, " +
                 "Distanc2_3Max, " +
                 "Distanc3_4Min, " +
                 "Distanc3_4Max, " +
                 "Distanc4_5Min, " +
                 "Distanc4_5Max, " +
                 "Distanc5_6Min, " +
                 "Distanc5_6Max, " +
                 "Distanc6_7Min, " +
                 "Distanc6_7Max, " +
                 "Distanc7_8Min, " +
                 "Distanc7_8Max, " +
                 "MaxOsNagrm161, " +
                 "MaxOsNagrm162, " +
                 "MaxOsNagrm111, " +
                 "MaxOsNagrm112, " +
                 "MaxOsNagrm121, " +
                 "MaxOsNagrm122, " +
                 "MaxOsNagrm261, " +
                 "MaxOsNagrm262, " +
                 "MaxOsNagrm211, " +
                 "MaxOsNagrm212, " +
                 "MaxOsNagrm221, " +
                 "MaxOsNagrm222, " +
                 "MaxOsNagrm361, " +
                 "MaxOsNagrm362, " +
                 "MaxOsNagrm311, " +
                 "MaxOsNagrm312, " +
                 "MaxOsNagrm321, " +
                 "MaxOsNagrm322, " +
                 "MaxOsNagrm461, " +
                 "MaxOsNagrm462, " +
                 "MaxOsNagrm411, " +
                 "MaxOsNagrm412, " +
                 "MaxOsNagrm421, " +
                 "MaxOsNagrm422, " +
                 "MaxOsNagrm561, " +
                 "MaxOsNagrm562, " +
                 "MaxOsNagrm511, " +
                 "MaxOsNagrm512, " +
                 "MaxOsNagrm521, " +
                 "MaxOsNagrm522, " +
                 "MaxOsNagrm661, " +
                 "MaxOsNagrm662, " +
                 "MaxOsNagrm611, " +
                 "MaxOsNagrm612, " +
                 "MaxOsNagrm621, " +
                 "MaxOsNagrm622, " +
                 "MaxOsNagrm761, " +
                 "MaxOsNagrm762, " +
                 "MaxOsNagrm711, " +
                 "MaxOsNagrm712, " +
                 "MaxOsNagrm721, " +
                 "MaxOsNagrm722, " +
                 "MaxOsNagrm861, " +
                 "MaxOsNagrm862, " +
                 "MaxOsNagrm811, " +
                 "MaxOsNagrm812, " +
                 "MaxOsNagrm821, " +
                 "MaxOsNagrm822, " +                 
                 "Kategory, " +
                 "PolnMassb, " +
                 "SubCategory, " +
                 "PolnMassm, " +
                 "prim " +
                 ") VALUES (" + Convert.ToInt32(alphaBlendTextBox26.Text) + ", " +
                 "'" + alphaBlendTextBox1.Text + "', '" +
                 "" + alphaBlendTextBox2.Text + "', " +
                 "" + Convert.ToInt32(alphaBlendTextBox3.Text) + ", " +
                 "" + Convert.ToInt32(alphaBlendTextBox4.Text) + ", " +
                 "" + Convert.ToInt32(alphaBlendTextBox5.Text) + ", " +
                 "" + Convert.ToInt32(alphaBlendTextBox6.Text) + ", " +
                 "" + Convert.ToInt32(alphaBlendTextBox7.Text) + ", " +
                 "" + Convert.ToInt32(alphaBlendTextBox8.Text) + ", " +
                 "" + Convert.ToInt32(alphaBlendTextBox9.Text) + ", " +
                 "" + Convert.ToInt32(alphaBlendTextBox10.Text) + ", " +
                 "" + Convert.ToInt32(alphaBlendTextBox11.Text) + ", " +
                 "" + Convert.ToInt32(alphaBlendTextBox12.Text) + ", " +
                 "" + Convert.ToInt32(alphaBlendTextBox13.Text) + ", " +
                 "" + Convert.ToInt32(alphaBlendTextBox14.Text) + ", " +
                 "" + Convert.ToInt32(alphaBlendTextBox15.Text) + ", " +
                 "" + Convert.ToInt32(alphaBlendTextBox16.Text) + ", " +
                 "" + Convert.ToInt32(alphaBlendTextBox17.Text) + ", " +
                 "" + Convert.ToInt32(alphaBlendTextBox32.Text) + ", " +
                 "" + Convert.ToInt32(alphaBlendTextBox39.Text) + ", " +
                 "" + Convert.ToInt32(alphaBlendTextBox46.Text) + ", " +
                 "" + Convert.ToInt32(alphaBlendTextBox53.Text) + ", " +
                 "" + Convert.ToInt32(alphaBlendTextBox60.Text) + ", " +
                 "" + Convert.ToInt32(alphaBlendTextBox67.Text) + ", " +
                 "" + Convert.ToInt32(alphaBlendTextBox31.Text) + ", " +
                 "" + Convert.ToInt32(alphaBlendTextBox38.Text) + ", " +
                 "" + Convert.ToInt32(alphaBlendTextBox45.Text) + ", " +
                 "" + Convert.ToInt32(alphaBlendTextBox52.Text) + ", " +
                 "" + Convert.ToInt32(alphaBlendTextBox59.Text) + ", " +
                 "" + Convert.ToInt32(alphaBlendTextBox66.Text) + ", " +
                 "" + Convert.ToInt32(alphaBlendTextBox30.Text) + ", " +
                 "" + Convert.ToInt32(alphaBlendTextBox37.Text) + ", " +
                 "" + Convert.ToInt32(alphaBlendTextBox44.Text) + ", " +
                 "" + Convert.ToInt32(alphaBlendTextBox51.Text) + ", " +
                 "" + Convert.ToInt32(alphaBlendTextBox58.Text) + ", " +
                 "" + Convert.ToInt32(alphaBlendTextBox65.Text) + ", " +
                 "" + Convert.ToInt32(alphaBlendTextBox29.Text) + ", " +
                 "" + Convert.ToInt32(alphaBlendTextBox36.Text) + ", " +
                 "" + Convert.ToInt32(alphaBlendTextBox43.Text) + ", " +
                 "" + Convert.ToInt32(alphaBlendTextBox50.Text) + ", " +
                 "" + Convert.ToInt32(alphaBlendTextBox57.Text) + ", " +
                 "" + Convert.ToInt32(alphaBlendTextBox64.Text) + ", " +
                 "" + Convert.ToInt32(alphaBlendTextBox28.Text) + ", " +
                 "" + Convert.ToInt32(alphaBlendTextBox35.Text) + ", " +
                 "" + Convert.ToInt32(alphaBlendTextBox42.Text) + ", " +
                 "" + Convert.ToInt32(alphaBlendTextBox49.Text) + ", " +
                 "" + Convert.ToInt32(alphaBlendTextBox56.Text) + ", " +
                 "" + Convert.ToInt32(alphaBlendTextBox63.Text) + ", " +
                 "" + Convert.ToInt32(alphaBlendTextBox27.Text) + ", " +
                 "" + Convert.ToInt32(alphaBlendTextBox34.Text) + ", " +
                 "" + Convert.ToInt32(alphaBlendTextBox41.Text) + ", " +
                 "" + Convert.ToInt32(alphaBlendTextBox48.Text) + ", " +
                 "" + Convert.ToInt32(alphaBlendTextBox55.Text) + ", " +
                 "" + Convert.ToInt32(alphaBlendTextBox62.Text) + ", " +
                 "" + Convert.ToInt32(alphaBlendTextBox25.Text) + ", " +
                 "" + Convert.ToInt32(alphaBlendTextBox33.Text) + ", " +
                 "" + Convert.ToInt32(alphaBlendTextBox40.Text) + ", " +
                 "" + Convert.ToInt32(alphaBlendTextBox47.Text) + ", " +
                 "" + Convert.ToInt32(alphaBlendTextBox54.Text) + ", " +
                 "" + Convert.ToInt32(alphaBlendTextBox61.Text) + ", " +
                 "" + Convert.ToInt32(alphaBlendTextBox73.Text) + ", " +
                 "" + Convert.ToInt32(alphaBlendTextBox72.Text) + ", " +
                 "" + Convert.ToInt32(alphaBlendTextBox71.Text) + ", " +
                 "" + Convert.ToInt32(alphaBlendTextBox70.Text) + ", " +
                 "" + Convert.ToInt32(alphaBlendTextBox69.Text) + ", " +
                 "" + Convert.ToInt32(alphaBlendTextBox68.Text) + ", " +
                 "" + Convert.ToInt32(alphaBlendTextBox22.Text) + ", " +
                 "" + Convert.ToInt32(alphaBlendTextBox21.Text) + ", " +
                 "" + Convert.ToInt32(alphaBlendTextBox23.Text) + ", " +
                 "" + Convert.ToInt32(alphaBlendTextBox20.Text) + ", '" +
                 "" + alphaBlendTextBox24.Text +
                 "')";
            command.CommandText = z;
            command.Connection = connection;

            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();
            Close();
        }

        internal void FormKlass_LoadP(int IDTS)
        {
            button1.Visible = false;
            button2.Visible = true;
            
            string z = "SELECT " +
                "raptklassts.Klass," +
                " raptklassts.naimklassts," +
                " raptklassts.tipschema," +
                " raptklassts.ColOsey," +
                " raptklassts.Distanc1_2Min," +
                " raptklassts.Distanc1_2Max," +
                " raptklassts.Distanc2_3Min," +
                " raptklassts.Distanc2_3Max," +
                " raptklassts.Distanc3_4Min," +
                " raptklassts.Distanc3_4Max," +
                " raptklassts.Distanc4_5Min," +
                " raptklassts.Distanc4_5Max," +
                " raptklassts.Distanc5_6Min," +
                " raptklassts.Distanc5_6Max," +
                " raptklassts.Distanc6_7Min," +
                " raptklassts.Distanc6_7Max," +
                " raptklassts.Distanc7_8Min," +
                " raptklassts.Distanc7_8Max," +
                " raptklassts.MaxOsNagrm161," +
                " raptklassts.MaxOsNagrm162," +
                " raptklassts.MaxOsNagrm111," +
                " raptklassts.MaxOsNagrm112," +
                " raptklassts.MaxOsNagrm121," +
                " raptklassts.MaxOsNagrm122," +
                " raptklassts.MaxOsNagrm261," +
                " raptklassts.MaxOsNagrm262," +
                " raptklassts.MaxOsNagrm211," +
                " raptklassts.MaxOsNagrm212," +
                " raptklassts.MaxOsNagrm221," +
                " raptklassts.MaxOsNagrm222," +
                " raptklassts.MaxOsNagrm361," +
                " raptklassts.MaxOsNagrm362," +
                " raptklassts.MaxOsNagrm311," +
                " raptklassts.MaxOsNagrm312," +
                " raptklassts.MaxOsNagrm321," +
                " raptklassts.MaxOsNagrm322," +
                " raptklassts.MaxOsNagrm461," +
                " raptklassts.MaxOsNagrm462," +
                " raptklassts.MaxOsNagrm411," +
                " raptklassts.MaxOsNagrm412," +
                " raptklassts.MaxOsNagrm421," +
                " raptklassts.MaxOsNagrm422," +
                " raptklassts.MaxOsNagrm561," +
                " raptklassts.MaxOsNagrm562," +
                " raptklassts.MaxOsNagrm511," +
                " raptklassts.MaxOsNagrm512," +
                " raptklassts.MaxOsNagrm521," +
                " raptklassts.MaxOsNagrm522," +
                " raptklassts.MaxOsNagrm661," +
                " raptklassts.MaxOsNagrm662," +
                " raptklassts.MaxOsNagrm611," +
                " raptklassts.MaxOsNagrm612," +
                " raptklassts.MaxOsNagrm621," +
                " raptklassts.MaxOsNagrm622," +
                " raptklassts.MaxOsNagrm761," +
                " raptklassts.MaxOsNagrm762," +
                " raptklassts.MaxOsNagrm711," +
                " raptklassts.MaxOsNagrm712," +
                " raptklassts.MaxOsNagrm721," +
                " raptklassts.MaxOsNagrm722," +
                 "raptklassts.MaxOsNagrm861," +
                 "raptklassts.MaxOsNagrm862," +
                 "raptklassts.MaxOsNagrm811," +
                 "raptklassts.MaxOsNagrm812," +
                 "raptklassts.MaxOsNagrm821," +
                 "raptklassts.MaxOsNagrm822," +
                " raptklassts.Kategory," +
                " raptklassts.PolnMassb," +
                " raptklassts.SubCategory," +
                " raptklassts.PolnMassm," +
                " raptklassts.prim " +
                "FROM raptklassts " +
                "WHERE raptklassts.idklassts = " + IDTS;
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
                    alphaBlendTextBox26.Text = readerT["Klass"].ToString();
                    alphaBlendTextBox1.Text = readerT["naimklassts"].ToString();
                    alphaBlendTextBox2.Text = readerT["tipschema"].ToString();
                    alphaBlendTextBox3.Text = readerT["ColOsey"].ToString();
                    alphaBlendTextBox4.Text = readerT["Distanc1_2Min"].ToString();
                    alphaBlendTextBox5.Text = readerT["Distanc1_2Max"].ToString();
                    alphaBlendTextBox6.Text = readerT["Distanc2_3Min"].ToString();
                    alphaBlendTextBox7.Text = readerT["Distanc2_3Max"].ToString();
                    alphaBlendTextBox8.Text = readerT["Distanc3_4Min"].ToString();
                    alphaBlendTextBox9.Text = readerT["Distanc3_4Max"].ToString();
                    alphaBlendTextBox10.Text = readerT["Distanc4_5Min"].ToString();
                    alphaBlendTextBox11.Text = readerT["Distanc4_5Max"].ToString();
                    alphaBlendTextBox12.Text = readerT["Distanc5_6Min"].ToString();
                    alphaBlendTextBox13.Text = readerT["Distanc5_6Max"].ToString();
                    alphaBlendTextBox14.Text = readerT["Distanc6_7Min"].ToString();
                    alphaBlendTextBox15.Text = readerT["Distanc6_7Max"].ToString();
                    alphaBlendTextBox16.Text = readerT["Distanc7_8Min"].ToString();
                    alphaBlendTextBox17.Text = readerT["Distanc7_8Max"].ToString();
                    alphaBlendTextBox32.Text = readerT["MaxOsNagrm161"].ToString();
                    alphaBlendTextBox39.Text = readerT["MaxOsNagrm162"].ToString();
                    alphaBlendTextBox46.Text = readerT["MaxOsNagrm111"].ToString();
                    alphaBlendTextBox53.Text = readerT["MaxOsNagrm112"].ToString();
                    alphaBlendTextBox60.Text = readerT["MaxOsNagrm121"].ToString();
                    alphaBlendTextBox67.Text = readerT["MaxOsNagrm122"].ToString();
                    alphaBlendTextBox31.Text = readerT["MaxOsNagrm261"].ToString();
                    alphaBlendTextBox38.Text = readerT["MaxOsNagrm262"].ToString();
                    alphaBlendTextBox45.Text = readerT["MaxOsNagrm211"].ToString();
                    alphaBlendTextBox52.Text = readerT["MaxOsNagrm212"].ToString();
                    alphaBlendTextBox59.Text = readerT["MaxOsNagrm221"].ToString();
                    alphaBlendTextBox66.Text = readerT["MaxOsNagrm222"].ToString();
                    alphaBlendTextBox30.Text = readerT["MaxOsNagrm361"].ToString();
                    alphaBlendTextBox37.Text = readerT["MaxOsNagrm362"].ToString();
                    alphaBlendTextBox44.Text = readerT["MaxOsNagrm311"].ToString();
                    alphaBlendTextBox51.Text = readerT["MaxOsNagrm312"].ToString();
                    alphaBlendTextBox58.Text = readerT["MaxOsNagrm321"].ToString();
                    alphaBlendTextBox65.Text = readerT["MaxOsNagrm322"].ToString();
                    alphaBlendTextBox29.Text = readerT["MaxOsNagrm461"].ToString();
                    alphaBlendTextBox36.Text = readerT["MaxOsNagrm462"].ToString();
                    alphaBlendTextBox43.Text = readerT["MaxOsNagrm411"].ToString();
                    alphaBlendTextBox50.Text = readerT["MaxOsNagrm412"].ToString();
                    alphaBlendTextBox57.Text = readerT["MaxOsNagrm421"].ToString();
                    alphaBlendTextBox64.Text = readerT["MaxOsNagrm422"].ToString();
                    alphaBlendTextBox28.Text = readerT["MaxOsNagrm561"].ToString();
                    alphaBlendTextBox35.Text = readerT["MaxOsNagrm562"].ToString();
                    alphaBlendTextBox42.Text = readerT["MaxOsNagrm511"].ToString();
                    alphaBlendTextBox49.Text = readerT["MaxOsNagrm512"].ToString();
                    alphaBlendTextBox56.Text = readerT["MaxOsNagrm521"].ToString();
                    alphaBlendTextBox63.Text = readerT["MaxOsNagrm522"].ToString();
                    alphaBlendTextBox27.Text = readerT["MaxOsNagrm661"].ToString();
                    alphaBlendTextBox34.Text = readerT["MaxOsNagrm662"].ToString();
                    alphaBlendTextBox41.Text = readerT["MaxOsNagrm611"].ToString();
                    alphaBlendTextBox48.Text = readerT["MaxOsNagrm612"].ToString();
                    alphaBlendTextBox55.Text = readerT["MaxOsNagrm621"].ToString();
                    alphaBlendTextBox62.Text = readerT["MaxOsNagrm622"].ToString();
                    alphaBlendTextBox25.Text = readerT["MaxOsNagrm761"].ToString();
                    alphaBlendTextBox33.Text = readerT["MaxOsNagrm762"].ToString();
                    alphaBlendTextBox40.Text = readerT["MaxOsNagrm711"].ToString();
                    alphaBlendTextBox47.Text = readerT["MaxOsNagrm712"].ToString();
                    alphaBlendTextBox54.Text = readerT["MaxOsNagrm721"].ToString();
                    alphaBlendTextBox61.Text = readerT["MaxOsNagrm722"].ToString();
                    alphaBlendTextBox73.Text = readerT["MaxOsNagrm861"].ToString();
                    alphaBlendTextBox72.Text = readerT["MaxOsNagrm862"].ToString();
                    alphaBlendTextBox71.Text = readerT["MaxOsNagrm811"].ToString();
                    alphaBlendTextBox70.Text = readerT["MaxOsNagrm812"].ToString();
                    alphaBlendTextBox69.Text = readerT["MaxOsNagrm821"].ToString();
                    alphaBlendTextBox68.Text = readerT["MaxOsNagrm822"].ToString();
                    alphaBlendTextBox22.Text = readerT["Kategory"].ToString();
                    alphaBlendTextBox21.Text = readerT["PolnMassb"].ToString();
                    alphaBlendTextBox23.Text = readerT["SubCategory"].ToString();
                    alphaBlendTextBox20.Text = readerT["PolnMassm"].ToString();
                    alphaBlendTextBox24.Text = readerT["prim"].ToString();

                }
                IDKL = IDTS;
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
        }

        internal void FormKlass_LoadPV(int IDTS)
        {
            button1.Visible = false;
            button2.Visible =false;

            string z = "SELECT " +
                "raptklassts.Klass," +
                " raptklassts.naimklassts," +
                " raptklassts.tipschema," +
                " raptklassts.ColOsey," +
                " raptklassts.Distanc1_2Min," +
                " raptklassts.Distanc1_2Max," +
                " raptklassts.Distanc2_3Min," +
                " raptklassts.Distanc2_3Max," +
                " raptklassts.Distanc3_4Min," +
                " raptklassts.Distanc3_4Max," +
                " raptklassts.Distanc4_5Min," +
                " raptklassts.Distanc4_5Max," +
                " raptklassts.Distanc5_6Min," +
                " raptklassts.Distanc5_6Max," +
                " raptklassts.Distanc6_7Min," +
                " raptklassts.Distanc6_7Max," +
                " raptklassts.Distanc7_8Min," +
                " raptklassts.Distanc7_8Max," +
                " raptklassts.MaxOsNagrm161," +
                " raptklassts.MaxOsNagrm162," +
                " raptklassts.MaxOsNagrm111," +
                " raptklassts.MaxOsNagrm112," +
                " raptklassts.MaxOsNagrm121," +
                " raptklassts.MaxOsNagrm122," +
                " raptklassts.MaxOsNagrm261," +
                " raptklassts.MaxOsNagrm262," +
                " raptklassts.MaxOsNagrm211," +
                " raptklassts.MaxOsNagrm212," +
                " raptklassts.MaxOsNagrm221," +
                " raptklassts.MaxOsNagrm222," +
                " raptklassts.MaxOsNagrm361," +
                " raptklassts.MaxOsNagrm362," +
                " raptklassts.MaxOsNagrm311," +
                " raptklassts.MaxOsNagrm312," +
                " raptklassts.MaxOsNagrm321," +
                " raptklassts.MaxOsNagrm322," +
                " raptklassts.MaxOsNagrm461," +
                " raptklassts.MaxOsNagrm462," +
                " raptklassts.MaxOsNagrm411," +
                " raptklassts.MaxOsNagrm412," +
                " raptklassts.MaxOsNagrm421," +
                " raptklassts.MaxOsNagrm422," +
                " raptklassts.MaxOsNagrm561," +
                " raptklassts.MaxOsNagrm562," +
                " raptklassts.MaxOsNagrm511," +
                " raptklassts.MaxOsNagrm512," +
                " raptklassts.MaxOsNagrm521," +
                " raptklassts.MaxOsNagrm522," +
                " raptklassts.MaxOsNagrm661," +
                " raptklassts.MaxOsNagrm662," +
                " raptklassts.MaxOsNagrm611," +
                " raptklassts.MaxOsNagrm612," +
                " raptklassts.MaxOsNagrm621," +
                " raptklassts.MaxOsNagrm622," +
                " raptklassts.MaxOsNagrm761," +
                " raptklassts.MaxOsNagrm762," +
                " raptklassts.MaxOsNagrm711," +
                " raptklassts.MaxOsNagrm712," +
                " raptklassts.MaxOsNagrm721," +
                " raptklassts.MaxOsNagrm722," +
                 "raptklassts.MaxOsNagrm861," +
                 "raptklassts.MaxOsNagrm862," +
                 "raptklassts.MaxOsNagrm811," +
                 "raptklassts.MaxOsNagrm812," +
                 "raptklassts.MaxOsNagrm821," +
                 "raptklassts.MaxOsNagrm822," +
                " raptklassts.Kategory," +
                " raptklassts.PolnMassb," +
                " raptklassts.SubCategory," +
                " raptklassts.PolnMassm," +
                " raptklassts.prim " +
                "FROM raptklassts " +
                "WHERE raptklassts.idklassts = " + IDTS;
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
                    alphaBlendTextBox26.Text = readerT["Klass"].ToString();
                    alphaBlendTextBox1.Text = readerT["naimklassts"].ToString();
                    alphaBlendTextBox2.Text = readerT["tipschema"].ToString();
                    alphaBlendTextBox3.Text = readerT["ColOsey"].ToString();
                    alphaBlendTextBox4.Text = readerT["Distanc1_2Min"].ToString();
                    alphaBlendTextBox5.Text = readerT["Distanc1_2Max"].ToString();
                    alphaBlendTextBox6.Text = readerT["Distanc2_3Min"].ToString();
                    alphaBlendTextBox7.Text = readerT["Distanc2_3Max"].ToString();
                    alphaBlendTextBox8.Text = readerT["Distanc3_4Min"].ToString();
                    alphaBlendTextBox9.Text = readerT["Distanc3_4Max"].ToString();
                    alphaBlendTextBox10.Text = readerT["Distanc4_5Min"].ToString();
                    alphaBlendTextBox11.Text = readerT["Distanc4_5Max"].ToString();
                    alphaBlendTextBox12.Text = readerT["Distanc5_6Min"].ToString();
                    alphaBlendTextBox13.Text = readerT["Distanc5_6Max"].ToString();
                    alphaBlendTextBox14.Text = readerT["Distanc6_7Min"].ToString();
                    alphaBlendTextBox15.Text = readerT["Distanc6_7Max"].ToString();
                    alphaBlendTextBox16.Text = readerT["Distanc7_8Min"].ToString();
                    alphaBlendTextBox17.Text = readerT["Distanc7_8Max"].ToString();
                    alphaBlendTextBox32.Text = readerT["MaxOsNagrm161"].ToString();
                    alphaBlendTextBox39.Text = readerT["MaxOsNagrm162"].ToString();
                    alphaBlendTextBox46.Text = readerT["MaxOsNagrm111"].ToString();
                    alphaBlendTextBox53.Text = readerT["MaxOsNagrm112"].ToString();
                    alphaBlendTextBox60.Text = readerT["MaxOsNagrm121"].ToString();
                    alphaBlendTextBox67.Text = readerT["MaxOsNagrm122"].ToString();
                    alphaBlendTextBox31.Text = readerT["MaxOsNagrm261"].ToString();
                    alphaBlendTextBox38.Text = readerT["MaxOsNagrm262"].ToString();
                    alphaBlendTextBox45.Text = readerT["MaxOsNagrm211"].ToString();
                    alphaBlendTextBox52.Text = readerT["MaxOsNagrm212"].ToString();
                    alphaBlendTextBox59.Text = readerT["MaxOsNagrm221"].ToString();
                    alphaBlendTextBox66.Text = readerT["MaxOsNagrm222"].ToString();
                    alphaBlendTextBox30.Text = readerT["MaxOsNagrm361"].ToString();
                    alphaBlendTextBox37.Text = readerT["MaxOsNagrm362"].ToString();
                    alphaBlendTextBox44.Text = readerT["MaxOsNagrm311"].ToString();
                    alphaBlendTextBox51.Text = readerT["MaxOsNagrm312"].ToString();
                    alphaBlendTextBox58.Text = readerT["MaxOsNagrm321"].ToString();
                    alphaBlendTextBox65.Text = readerT["MaxOsNagrm322"].ToString();
                    alphaBlendTextBox29.Text = readerT["MaxOsNagrm461"].ToString();
                    alphaBlendTextBox36.Text = readerT["MaxOsNagrm462"].ToString();
                    alphaBlendTextBox43.Text = readerT["MaxOsNagrm411"].ToString();
                    alphaBlendTextBox50.Text = readerT["MaxOsNagrm412"].ToString();
                    alphaBlendTextBox57.Text = readerT["MaxOsNagrm421"].ToString();
                    alphaBlendTextBox64.Text = readerT["MaxOsNagrm422"].ToString();
                    alphaBlendTextBox28.Text = readerT["MaxOsNagrm561"].ToString();
                    alphaBlendTextBox35.Text = readerT["MaxOsNagrm562"].ToString();
                    alphaBlendTextBox42.Text = readerT["MaxOsNagrm511"].ToString();
                    alphaBlendTextBox49.Text = readerT["MaxOsNagrm512"].ToString();
                    alphaBlendTextBox56.Text = readerT["MaxOsNagrm521"].ToString();
                    alphaBlendTextBox63.Text = readerT["MaxOsNagrm522"].ToString();
                    alphaBlendTextBox27.Text = readerT["MaxOsNagrm661"].ToString();
                    alphaBlendTextBox34.Text = readerT["MaxOsNagrm662"].ToString();
                    alphaBlendTextBox41.Text = readerT["MaxOsNagrm611"].ToString();
                    alphaBlendTextBox48.Text = readerT["MaxOsNagrm612"].ToString();
                    alphaBlendTextBox55.Text = readerT["MaxOsNagrm621"].ToString();
                    alphaBlendTextBox62.Text = readerT["MaxOsNagrm622"].ToString();
                    alphaBlendTextBox25.Text = readerT["MaxOsNagrm761"].ToString();
                    alphaBlendTextBox33.Text = readerT["MaxOsNagrm762"].ToString();
                    alphaBlendTextBox40.Text = readerT["MaxOsNagrm711"].ToString();
                    alphaBlendTextBox47.Text = readerT["MaxOsNagrm712"].ToString();
                    alphaBlendTextBox54.Text = readerT["MaxOsNagrm721"].ToString();
                    alphaBlendTextBox61.Text = readerT["MaxOsNagrm722"].ToString();
                    alphaBlendTextBox73.Text = readerT["MaxOsNagrm861"].ToString();
                    alphaBlendTextBox72.Text = readerT["MaxOsNagrm862"].ToString();
                    alphaBlendTextBox71.Text = readerT["MaxOsNagrm811"].ToString();
                    alphaBlendTextBox70.Text = readerT["MaxOsNagrm812"].ToString();
                    alphaBlendTextBox69.Text = readerT["MaxOsNagrm821"].ToString();
                    alphaBlendTextBox68.Text = readerT["MaxOsNagrm822"].ToString();
                    alphaBlendTextBox22.Text = readerT["Kategory"].ToString();
                    alphaBlendTextBox21.Text = readerT["PolnMassb"].ToString();
                    alphaBlendTextBox23.Text = readerT["SubCategory"].ToString();
                    alphaBlendTextBox20.Text = readerT["PolnMassm"].ToString();
                    alphaBlendTextBox24.Text = readerT["prim"].ToString();

                }
                IDKL = IDTS;
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
        }

        private void button2_Click(object sender, EventArgs e)///////////////// Кнопка сохранить ОБНОВЛЕНИЕ  //////////////////////////
        {
            MySqlCommand command = new MySqlCommand();
            ConnectStr conStr = new ConnectStr();
            conStr.ConStr(1);
            //Zapros zapros = new Zapros();
            string connectionString;
            connectionString = conStr.StP;
            MySqlConnection connection = new MySqlConnection(connectionString);
            string z = "UPDATE raptklassts " +
                "SET Klass = " + Convert.ToInt32(alphaBlendTextBox26.Text) + ", " +
                "naimklassts = '" + alphaBlendTextBox1.Text + "' , " +
                " tipschema = '" + alphaBlendTextBox2.Text + "' , " +
                " ColOsey = " + Convert.ToInt32(alphaBlendTextBox3.Text) + ", " +
                " Distanc1_2Min = " + Convert.ToInt32(alphaBlendTextBox4.Text) + ", " +
                " Distanc1_2Max = " + Convert.ToInt32(alphaBlendTextBox5.Text) + ", " +
                " Distanc2_3Min = " + Convert.ToInt32(alphaBlendTextBox6.Text) + ", " +
                " Distanc2_3Max = " + Convert.ToInt32(alphaBlendTextBox7.Text) + ", " +
                " Distanc3_4Min = " + Convert.ToInt32(alphaBlendTextBox8.Text) + ", " +
                " Distanc3_4Max = " + Convert.ToInt32(alphaBlendTextBox9.Text) + ", " +
                " Distanc4_5Min = " + Convert.ToInt32(alphaBlendTextBox10.Text) + ", " +
                " Distanc4_5Max = " + Convert.ToInt32(alphaBlendTextBox11.Text) + ", " +
                " Distanc5_6Min = " + Convert.ToInt32(alphaBlendTextBox12.Text) + ", " +
                " Distanc5_6Max = " + Convert.ToInt32(alphaBlendTextBox13.Text) + ", " +
                " Distanc6_7Min = " + Convert.ToInt32(alphaBlendTextBox14.Text) + ", " +
                " Distanc6_7Max = " + Convert.ToInt32(alphaBlendTextBox15.Text) + ", " +
                " Distanc7_8Min = " + Convert.ToInt32(alphaBlendTextBox16.Text) + ", " +
                " Distanc7_8Max = " + Convert.ToInt32(alphaBlendTextBox17.Text) + ", " +
                " MaxOsNagrm161 = " + Convert.ToInt32(alphaBlendTextBox32.Text) + ", " +
                " MaxOsNagrm162 = " + Convert.ToInt32(alphaBlendTextBox39.Text) + ", " +
                " MaxOsNagrm111 = " + Convert.ToInt32(alphaBlendTextBox46.Text) + ", " +
                " MaxOsNagrm112 = " + Convert.ToInt32(alphaBlendTextBox53.Text) + ", " +
                " MaxOsNagrm121 = " + Convert.ToInt32(alphaBlendTextBox60.Text) + ", " +
                " MaxOsNagrm122 = " + Convert.ToInt32(alphaBlendTextBox67.Text) + ", " +
                " MaxOsNagrm261 = " + Convert.ToInt32(alphaBlendTextBox31.Text) + ", " +
                " MaxOsNagrm262 = " + Convert.ToInt32(alphaBlendTextBox38.Text) + ", " +
                " MaxOsNagrm211 = " + Convert.ToInt32(alphaBlendTextBox45.Text) + ", " +
                " MaxOsNagrm212 = " + Convert.ToInt32(alphaBlendTextBox52.Text) + ", " +
                " MaxOsNagrm221 = " + Convert.ToInt32(alphaBlendTextBox59.Text) + ", " +
                " MaxOsNagrm222 = " + Convert.ToInt32(alphaBlendTextBox66.Text) + ", " +
                " MaxOsNagrm361 = " + Convert.ToInt32(alphaBlendTextBox30.Text) + ", " +
                " MaxOsNagrm362 = " + Convert.ToInt32(alphaBlendTextBox37.Text) + ", " +
                " MaxOsNagrm311 = " + Convert.ToInt32(alphaBlendTextBox44.Text) + ", " +
                " MaxOsNagrm312 = " + Convert.ToInt32(alphaBlendTextBox51.Text) + ", " +
                " MaxOsNagrm321 = " + Convert.ToInt32(alphaBlendTextBox58.Text) + ", " +
                " MaxOsNagrm322 = " + Convert.ToInt32(alphaBlendTextBox65.Text) + ", " +
                " MaxOsNagrm461 = " + Convert.ToInt32(alphaBlendTextBox29.Text) + ", " +
                " MaxOsNagrm462 = " + Convert.ToInt32(alphaBlendTextBox36.Text) + ", " +
                " MaxOsNagrm411 = " + Convert.ToInt32(alphaBlendTextBox43.Text) + ", " +
                " MaxOsNagrm412 = " + Convert.ToInt32(alphaBlendTextBox50.Text) + ", " +
                " MaxOsNagrm421 = " + Convert.ToInt32(alphaBlendTextBox57.Text) + ", " +
                " MaxOsNagrm422 = " + Convert.ToInt32(alphaBlendTextBox64.Text) + ", " +
                " MaxOsNagrm561 = " + Convert.ToInt32(alphaBlendTextBox28.Text) + ", " +
                " MaxOsNagrm562 = " + Convert.ToInt32(alphaBlendTextBox35.Text) + ", " +
                " MaxOsNagrm511 = " + Convert.ToInt32(alphaBlendTextBox42.Text) + ", " +
                " MaxOsNagrm512 = " + Convert.ToInt32(alphaBlendTextBox49.Text) + ", " +
                " MaxOsNagrm521 = " + Convert.ToInt32(alphaBlendTextBox56.Text) + ", " +
                " MaxOsNagrm522 = " + Convert.ToInt32(alphaBlendTextBox63.Text) + ", " +
                " MaxOsNagrm661 = " + Convert.ToInt32(alphaBlendTextBox27.Text) + ", " +
                " MaxOsNagrm662 = " + Convert.ToInt32(alphaBlendTextBox34.Text) + ", " +
                " MaxOsNagrm611 = " + Convert.ToInt32(alphaBlendTextBox41.Text) + ", " +
                " MaxOsNagrm612 = " + Convert.ToInt32(alphaBlendTextBox48.Text) + ", " +
                " MaxOsNagrm621 = " + Convert.ToInt32(alphaBlendTextBox55.Text) + ", " +
                " MaxOsNagrm622 = " + Convert.ToInt32(alphaBlendTextBox62.Text) + ", " +
                " MaxOsNagrm761 = " + Convert.ToInt32(alphaBlendTextBox25.Text) + ", " +
                " MaxOsNagrm762 = " + Convert.ToInt32(alphaBlendTextBox33.Text) + ", " +
                " MaxOsNagrm711 = " + Convert.ToInt32(alphaBlendTextBox40.Text) + ", " +
                " MaxOsNagrm712 = " + Convert.ToInt32(alphaBlendTextBox47.Text) + ", " +
                " MaxOsNagrm721 = " + Convert.ToInt32(alphaBlendTextBox54.Text) + ", " +
                " MaxOsNagrm722 = " + Convert.ToInt32(alphaBlendTextBox61.Text) + ", " +
                 "MaxOsNagrm861= " + Convert.ToInt32(alphaBlendTextBox73.Text) + ", " +
                 "MaxOsNagrm862= " + Convert.ToInt32(alphaBlendTextBox72.Text) + ", " +
                 "MaxOsNagrm811= " + Convert.ToInt32(alphaBlendTextBox71.Text) + ", " +
                 "MaxOsNagrm812= " + Convert.ToInt32(alphaBlendTextBox70.Text) + ", " +
                 "MaxOsNagrm821= " + Convert.ToInt32(alphaBlendTextBox69.Text) + ", " +
                 "MaxOsNagrm822= " + Convert.ToInt32(alphaBlendTextBox68.Text) + ", " +
                " Kategory = " + Convert.ToInt32(alphaBlendTextBox22.Text) + ", " +
                " PolnMassb = " + Convert.ToInt32(alphaBlendTextBox21.Text) + ", " +
                " SubCategory = " + Convert.ToInt32(alphaBlendTextBox23.Text) + ", " +
                " PolnMassm = " + Convert.ToInt32(alphaBlendTextBox20.Text) + ", " +
                " prim = '" + alphaBlendTextBox24.Text +
                "' WHERE idklassts = " + IDKL;
            command.CommandText = z;
            command.Connection = connection;

            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();
            Close();
        }

        private void button3_Click(object sender, EventArgs e)///////////////  Кнопка закрытия формы
        {
            //button2.Visible = false;
            //button1.Visible = false;
            //DSKL = new DataSet();
            //Form2 frm = new Form2();
            //frm.ZagrKlass(0);
            Close();
        }
    }
}
