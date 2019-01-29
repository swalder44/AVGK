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
    public partial class FormMDisl : Form
    {
        public int IDRub;
        public FormMDisl()
        {
            InitializeComponent();
            button1.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        internal void FormMDisl_LoadRN(int IDMD)
        {
            button1.Visible = false;
            button2.Visible = true;
            MySqlCommand command = new MySqlCommand();
            ConnectStr conStr = new ConnectStr();
            conStr.ConStr(1);
            Zapros zapros = new Zapros();
            string connectionString;
            connectionString = conStr.StP;
            MySqlConnection connection = new MySqlConnection(connectionString);
            zapros.ZaprMDisl(IDMD);
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
                    //alphaBlendTextBox48.Text = reader["IDSYS"].ToString();
                    alphaBlendTextBox48.Text = reader["IDSYS"].ToString();
                    alphaBlendTextBox31.Text = reader["UchNomer"].ToString();
                    alphaBlendTextBox32.Text = reader["IDAD"].ToString();
                    alphaBlendTextBox26.Text = reader["NameAD"].ToString();
                    alphaBlendTextBox1.Text = reader["ZnachenAD"].ToString();
                    alphaBlendTextBox8.Text = reader["KMPiketMD"].ToString();
                    alphaBlendTextBox4.Text = reader["GLONASShir"].ToString();
                    alphaBlendTextBox5.Text = reader["GLONASDolg"].ToString();
                    alphaBlendTextBox33.Text = reader["GPSShir"].ToString();
                    alphaBlendTextBox34.Text = reader["GPSDolg"].ToString();
                    alphaBlendTextBox37.Text = reader["GMap"].ToString();
                    alphaBlendTextBox35.Text = reader["YMap"].ToString();
                    alphaBlendTextBox10.Text = reader["PrivyazkaNP"].ToString();
                    alphaBlendTextBox13.Text = reader["NaznachenMD"].ToString();
                    alphaBlendTextBox22.Text = reader["ObshChisloPolos"].ToString();
                    alphaBlendTextBox36.Text = reader["ChisloNapravl"].ToString();
                    alphaBlendTextBox39.Text = reader["ShirinaPD"].ToString();
                    alphaBlendTextBox38.Text = reader["ShirinaOboch"].ToString();
                    alphaBlendTextBox41.Text = reader["ShirinaRazdPol"].ToString();
                    alphaBlendTextBox40.Text = reader["ShirinaSpeedPol"].ToString();
                    alphaBlendTextBox43.Text = reader["ShirinaSpetsPlosh"].ToString();
                    alphaBlendTextBox42.Text = reader["DlinaSpetsPlosh"].ToString();
                    alphaBlendTextBox46.Text = reader["NomAktAccredpolos"].ToString();
                    alphaBlendTextBox47.Text = reader["DataAccredPolos"].ToString();
                    alphaBlendTextBox44.Text = reader["NomAccredSpetsPlosh"].ToString();
                    alphaBlendTextBox45.Text = reader["DataAccredSpPlosh"].ToString();
                    alphaBlendTextBox50.Text = reader["IDNaprR"].ToString();
                    alphaBlendTextBox51.Text = reader["IDNaprL"].ToString();
                    alphaBlendTextBox19.Text = reader["CantryMD"].ToString();
                    alphaBlendTextBox18.Text = reader["OKATOCantryMD"].ToString();
                    alphaBlendTextBox6.Text = reader["SubjektMD"].ToString();
                    alphaBlendTextBox7.Text = reader["OKATOSubjektMD"].ToString();
                    alphaBlendTextBox9.Text = reader["MRajonMD"].ToString();
                    alphaBlendTextBox12.Text = reader["OKATOMRajonMD"].ToString();
                    alphaBlendTextBox14.Text = reader["ObjektMZMD"].ToString();
                    alphaBlendTextBox16.Text = reader["OKATOObjektMZMD"].ToString();
                    alphaBlendTextBox17.Text = reader["NPMD"].ToString();
                    alphaBlendTextBox20.Text = reader["OKATONPMD"].ToString();
                    alphaBlendTextBox27.Text = reader["OrgobslADName"].ToString();
                    alphaBlendTextBox25.Text = reader["OrgobslADAdr"].ToString();
                    alphaBlendTextBox24.Text = reader["OrgobslADKontakt"].ToString();
                    alphaBlendTextBox21.Text = reader["OrgobslADOL"].ToString();
                    alphaBlendTextBox15.Text = reader["OrgobslESName"].ToString();
                    alphaBlendTextBox11.Text = reader["OrgobslESAdr"].ToString();
                    alphaBlendTextBox3.Text = reader["OrgobslESKontakt"].ToString();
                    alphaBlendTextBox2.Text = reader["OrgobslESOL"].ToString();
                    alphaBlendTextBox30.Text = reader["OrgobslSvyazName"].ToString();
                    alphaBlendTextBox29.Text = reader["OrgobslSvyazAdr"].ToString();
                    alphaBlendTextBox28.Text = reader["OrgobslSvyazKontakt"].ToString();
                    alphaBlendTextBox23.Text = reader["OrgobslSvyazOL"].ToString();                    

                    IDRub = IDMD;
                    reader.Close();
                }
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

        internal void FormMDisl_LoadRNV(int IDMD)
        {
            button1.Visible = false;
            button2.Visible = false;
            MySqlCommand command = new MySqlCommand();
            ConnectStr conStr = new ConnectStr();
            conStr.ConStr(1);
            Zapros zapros = new Zapros();
            string connectionString;
            connectionString = conStr.StP;
            MySqlConnection connection = new MySqlConnection(connectionString);
            zapros.ZaprMDisl(IDMD);
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
                    //alphaBlendTextBox48.Text = reader["IDSYS"].ToString();
                    alphaBlendTextBox48.Text = reader["IDSYS"].ToString();
                    alphaBlendTextBox31.Text = reader["UchNomer"].ToString();
                    alphaBlendTextBox32.Text = reader["IDAD"].ToString();
                    alphaBlendTextBox26.Text = reader["NameAD"].ToString();
                    alphaBlendTextBox1.Text = reader["ZnachenAD"].ToString();
                    alphaBlendTextBox8.Text = reader["KMPiketMD"].ToString();
                    alphaBlendTextBox4.Text = reader["GLONASShir"].ToString();
                    alphaBlendTextBox5.Text = reader["GLONASDolg"].ToString();
                    alphaBlendTextBox33.Text = reader["GPSShir"].ToString();
                    alphaBlendTextBox34.Text = reader["GPSDolg"].ToString();
                    alphaBlendTextBox37.Text = reader["GMap"].ToString();
                    alphaBlendTextBox35.Text = reader["YMap"].ToString();
                    alphaBlendTextBox10.Text = reader["PrivyazkaNP"].ToString();
                    alphaBlendTextBox13.Text = reader["NaznachenMD"].ToString();
                    alphaBlendTextBox22.Text = reader["ObshChisloPolos"].ToString();
                    alphaBlendTextBox36.Text = reader["ChisloNapravl"].ToString();
                    alphaBlendTextBox39.Text = reader["ShirinaPD"].ToString();
                    alphaBlendTextBox38.Text = reader["ShirinaOboch"].ToString();
                    alphaBlendTextBox41.Text = reader["ShirinaRazdPol"].ToString();
                    alphaBlendTextBox40.Text = reader["ShirinaSpeedPol"].ToString();
                    alphaBlendTextBox43.Text = reader["ShirinaSpetsPlosh"].ToString();
                    alphaBlendTextBox42.Text = reader["DlinaSpetsPlosh"].ToString();
                    alphaBlendTextBox46.Text = reader["NomAktAccredpolos"].ToString();
                    alphaBlendTextBox47.Text = reader["DataAccredPolos"].ToString();
                    alphaBlendTextBox44.Text = reader["NomAccredSpetsPlosh"].ToString();
                    alphaBlendTextBox45.Text = reader["DataAccredSpPlosh"].ToString();
                    alphaBlendTextBox50.Text = reader["IDNaprR"].ToString();
                    alphaBlendTextBox51.Text = reader["IDNaprL"].ToString();
                    alphaBlendTextBox19.Text = reader["CantryMD"].ToString();
                    alphaBlendTextBox18.Text = reader["OKATOCantryMD"].ToString();
                    alphaBlendTextBox6.Text = reader["SubjektMD"].ToString();
                    alphaBlendTextBox7.Text = reader["OKATOSubjektMD"].ToString();
                    alphaBlendTextBox9.Text = reader["MRajonMD"].ToString();
                    alphaBlendTextBox12.Text = reader["OKATOMRajonMD"].ToString();
                    alphaBlendTextBox14.Text = reader["ObjektMZMD"].ToString();
                    alphaBlendTextBox16.Text = reader["OKATOObjektMZMD"].ToString();
                    alphaBlendTextBox17.Text = reader["NPMD"].ToString();
                    alphaBlendTextBox20.Text = reader["OKATONPMD"].ToString();
                    alphaBlendTextBox27.Text = reader["OrgobslADName"].ToString();
                    alphaBlendTextBox25.Text = reader["OrgobslADAdr"].ToString();
                    alphaBlendTextBox24.Text = reader["OrgobslADKontakt"].ToString();
                    alphaBlendTextBox21.Text = reader["OrgobslADOL"].ToString();
                    alphaBlendTextBox15.Text = reader["OrgobslESName"].ToString();
                    alphaBlendTextBox11.Text = reader["OrgobslESAdr"].ToString();
                    alphaBlendTextBox3.Text = reader["OrgobslESKontakt"].ToString();
                    alphaBlendTextBox2.Text = reader["OrgobslESOL"].ToString();
                    alphaBlendTextBox30.Text = reader["OrgobslSvyazName"].ToString();
                    alphaBlendTextBox29.Text = reader["OrgobslSvyazAdr"].ToString();
                    alphaBlendTextBox28.Text = reader["OrgobslSvyazKontakt"].ToString();
                    alphaBlendTextBox23.Text = reader["OrgobslSvyazOL"].ToString();

                    IDRub = IDMD;
                    reader.Close();
                }
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

        private void button2_Click(object sender, EventArgs e)////////////////////////////   Сохранение изменений в AD
        {
            MySqlCommand command = new MySqlCommand();
            ConnectStr conStr = new ConnectStr();
            conStr.ConStr(1);
            //Zapros zapros = new Zapros();
            string connectionString;
            connectionString = conStr.StP;
            MySqlConnection connection = new MySqlConnection(connectionString);           
            string z = "UPDATE rapmestodislokatsii " +
                "SET IDSYS = '" + alphaBlendTextBox48.Text.ToString() + "', " +
                "UchNomer = '" + alphaBlendTextBox31.Text.ToString() + "', " +
                "IDAD = '" + alphaBlendTextBox32.Text.ToString() + "', " +
                "NameAD = '" + alphaBlendTextBox26.Text.ToString() + "', " +
                "ZnachenAD = '" + alphaBlendTextBox1.Text.ToString() + "', " +
                "KMPiketMD = '" + alphaBlendTextBox8.Text.ToString() + "', " +
                "GPSDolg = '" + alphaBlendTextBox4.Text.ToString() + "', " +
                "GPSShir = '" + alphaBlendTextBox5.Text.ToString() + "', " +
                "GLONASDolg = '" + alphaBlendTextBox33.Text.ToString() + "', " +
                "GLONASShir = '" + alphaBlendTextBox34.Text.ToString() + "', " +
                "GMap = '" + alphaBlendTextBox37.Text.ToString() + "', " +
                "YMap = '" + alphaBlendTextBox35.Text.ToString() + "', " +
                "PrivyazkaNP = '" + alphaBlendTextBox10.Text.ToString() + "', " +
                "NaznachenMD = '" + alphaBlendTextBox13.Text.ToString() + "', " +
                "ObshChisloPolos = " + Convert.ToInt32(alphaBlendTextBox22.Text.ToString()) + ", " +
                "ChisloNapravl = '" + alphaBlendTextBox36.Text.ToString() + "', " +
                "ShirinaPD = '" + alphaBlendTextBox39.Text.ToString() + "', " +
                "ShirinaOboch = '" + alphaBlendTextBox38.Text.ToString() + "', " +
                "ShirinaRazdPol = '" + alphaBlendTextBox41.Text.ToString() + "', " +
                "ShirinaSpeedPol = '" + alphaBlendTextBox40.Text.ToString() + "', " +
                "ShirinaSpetsPlosh = '" + alphaBlendTextBox43.Text.ToString() + "', " +
                "DlinaSpetsPlosh = '" + alphaBlendTextBox42.Text.ToString() + "', " +
                "NomAktAccredpolos = '" + alphaBlendTextBox46.Text.ToString() + "', " +
                "DataAccredPolos = '" + alphaBlendTextBox47.Text.ToString() + "', " +
                "NomAccredSpetsPlosh = '" + alphaBlendTextBox44.Text.ToString() + "', " +
                "DataAccredSpPlosh = '" + alphaBlendTextBox45.Text.ToString() + "', " +
                "IDNaprR = " + Convert.ToInt32(alphaBlendTextBox50.Text.ToString()) + ", " +
                "IDNaprL = " + Convert.ToInt32(alphaBlendTextBox51.Text.ToString()) + ", " +
                "CantryMD = '" + alphaBlendTextBox19.Text.ToString() + "', " +
                "OKATOCantryMD = '" + alphaBlendTextBox18.Text.ToString() + "', " +
                "SubjektMD = '" + alphaBlendTextBox6.Text.ToString() + "', " +
                "OKATOSubjektMD = '" + alphaBlendTextBox7.Text.ToString() + "', " +
                "MRajonMD = '" + alphaBlendTextBox9.Text.ToString() + "', " +
                "OKATOMRajonMD = '" + alphaBlendTextBox12.Text.ToString() + "', " +
                "ObjektMZMD = '" + alphaBlendTextBox14.Text.ToString() + "', " +
                "OKATOObjektMZMD = '" + alphaBlendTextBox16.Text.ToString() + "', " +
                "NPMD = '" + alphaBlendTextBox17.Text.ToString() + "', " +
                "OKATONPMD = '" + alphaBlendTextBox20.Text.ToString() + "', " +
                "OrgobslADName = '" + alphaBlendTextBox27.Text.ToString() + "', " +
                "OrgobslADAdr = '" + alphaBlendTextBox25.Text.ToString() + "', " +
                "OrgobslADKontakt = '" + alphaBlendTextBox24.Text.ToString() + "', " +
                "OrgobslADOL = '" + alphaBlendTextBox21.Text.ToString() + "', " +
                "OrgobslESName = '" + alphaBlendTextBox15.Text.ToString() + "', " +
                "OrgobslESAdr = '" + alphaBlendTextBox11.Text.ToString() + "', " +
                "OrgobslESKontakt = '" + alphaBlendTextBox3.Text.ToString() + "', " +
                "OrgobslESOL = '" + alphaBlendTextBox2.Text.ToString() + "', " +
                "OrgobslSvyazName = '" + alphaBlendTextBox30.Text.ToString() + "', " +
                "OrgobslSvyazAdr = '" + alphaBlendTextBox29.Text.ToString() + "', " +
                "OrgobslSvyazKontakt = '" + alphaBlendTextBox28.Text.ToString() + "', " +
                "OrgobslSvyazOL = '" + alphaBlendTextBox23.Text.ToString() + "' " +
                "WHERE ID = " + IDRub;
            command.CommandText = z;
            command.Connection = connection;

            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();
            Close();
        }

        private void button1_Click(object sender, EventArgs e)////////////////////////////   Добавление AD
        {
            MySqlCommand command = new MySqlCommand();
            ConnectStr conStr = new ConnectStr();
            conStr.ConStr(1);
            //Zapros zapros = new Zapros();
            string connectionString;
            connectionString = conStr.StP;
            MySqlConnection connection = new MySqlConnection(connectionString);
            //zapros.AD(IDRN);
            string z = " INSERT INTO rapmestodislokatsii ( " +
                "IDSYS,  " +
                "UchNomer,  " +
                "IDAD,  " +
                "NameAD,  " +
                "ZnachenAD,  " +
                "KMPiketMD,  " +
                "GPSDolg,  " +
                "GPSShir,  " +
                "GLONASDolg,  " +
                "GLONASShir,  " +
                "GMap,  " +
                "YMap,  " +
                "PrivyazkaNP,  " +
                "NaznachenMD,  " +
                "ObshChisloPolos,  " +
                "ChisloNapravl,  " +
                "ShirinaPD,  " +
                "ShirinaOboch,  " +
                "ShirinaRazdPol,  " +
                "ShirinaSpeedPol,  " +
                "ShirinaSpetsPlosh,  " +
                "DlinaSpetsPlosh,  " +
                "NomAktAccredpolos, " +
                "DataAccredPolos, " +
                "NomAccredSpetsPlosh, " +
                "DataAccredSpPlosh, " +
                "IDNaprR, IDNaprL, " +
                "CantryMD, " +
                "OKATOCantryMD, " +
                "SubjektMD, " +
                "OKATOSubjektMD, " +
                "MRajonMD, " +
                "OKATOMRajonMD, " +
                "ObjektMZMD, " +
                "OKATOObjektMZMD, " +
                "NPMD, OKATONPMD, " +
                "OrgobslADName, " +
                "OrgobslADAdr, " +
                "OrgobslADKontakt, " +
                "OrgobslADOL, " +
                "OrgobslESName, " +
                "OrgobslESAdr, " +
                "OrgobslESKontakt, " +
                "OrgobslESOL, " +
                "OrgobslSvyazName, " +
                "OrgobslSvyazAdr, " +
                "OrgobslSvyazKontakt, " +
                "OrgobslSvyazOL) " +
                "VALUES( '" + alphaBlendTextBox48.Text.ToString() + "', " +
                "'" + alphaBlendTextBox31.Text.ToString() + "', " +
                "'" + alphaBlendTextBox32.Text.ToString() + "', " +
                "'" + alphaBlendTextBox26.Text.ToString() + "', " +
                "'" + alphaBlendTextBox1.Text.ToString() + "', " +
                "'" + alphaBlendTextBox8.Text.ToString() + "', " +
                "'" + alphaBlendTextBox4.Text.ToString() + "', " +
                "'" + alphaBlendTextBox5.Text.ToString() + "', " +
                "'" + alphaBlendTextBox33.Text.ToString() + "', " +
                "'" + alphaBlendTextBox34.Text.ToString() + "', " +
                "'" + alphaBlendTextBox37.Text.ToString() + "', " +
                "'" + alphaBlendTextBox35.Text.ToString() + "', " +
                "'" + alphaBlendTextBox10.Text.ToString() + "', " +
                "'" + alphaBlendTextBox13.Text.ToString() + "', " +
                "" + Convert.ToInt32(alphaBlendTextBox22.Text.ToString()) + ", " +
                "'" + alphaBlendTextBox36.Text.ToString() + "', " +
                "'" + alphaBlendTextBox39.Text.ToString() + "', " +
                "'" + alphaBlendTextBox38.Text.ToString() + "', " +
                "'" + alphaBlendTextBox41.Text.ToString() + "', " +
                "'" + alphaBlendTextBox40.Text.ToString() + "', " +
                "'" + alphaBlendTextBox43.Text.ToString() + "', " +
                "'" + alphaBlendTextBox42.Text.ToString() + "', " +
                "'" + alphaBlendTextBox46.Text.ToString() + "', " +
                "'" + alphaBlendTextBox47.Text.ToString() + "', " +
                "'" + alphaBlendTextBox44.Text.ToString() + "', " +
                "'" + alphaBlendTextBox45.Text.ToString() + "', " +
                "" + Convert.ToInt32(alphaBlendTextBox50.Text.ToString()) + ", " +
                "" + Convert.ToInt32(alphaBlendTextBox51.Text.ToString()) + ", " +
                "'" + alphaBlendTextBox19.Text.ToString() + "', " +
                "'" + alphaBlendTextBox18.Text.ToString() + "', " +
                "'" + alphaBlendTextBox6.Text.ToString() + "', " +
                "'" + alphaBlendTextBox7.Text.ToString() + "', " +
                "'" + alphaBlendTextBox9.Text.ToString() + "', " +
                "'" + alphaBlendTextBox12.Text.ToString() + "', " +
                "'" + alphaBlendTextBox14.Text.ToString() + "', " +
                "'" + alphaBlendTextBox16.Text.ToString() + "', " +
                "'" + alphaBlendTextBox17.Text.ToString() + "', " +
                "'" + alphaBlendTextBox20.Text.ToString() + "', " +
                "'" + alphaBlendTextBox27.Text.ToString() + "', " +
                "'" + alphaBlendTextBox25.Text.ToString() + "', " +
                "'" + alphaBlendTextBox24.Text.ToString() + "', " +
                "'" + alphaBlendTextBox21.Text.ToString() + "', " +
                "'" + alphaBlendTextBox15.Text.ToString() + "', " +
                "'" + alphaBlendTextBox11.Text.ToString() + "', " +
                "'" + alphaBlendTextBox3.Text.ToString() + "', " +
                "'" + alphaBlendTextBox2.Text.ToString() + "', " +
                "'" + alphaBlendTextBox30.Text.ToString() + "', " +
                "'" + alphaBlendTextBox29.Text.ToString() + "', " +
                "'" + alphaBlendTextBox28.Text.ToString() + "', " +
                "'" + alphaBlendTextBox23.Text.ToString() + "');";
            command.CommandText = z;// commandString;
            command.Connection = connection;

            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();
            Close();

        }


    }
}
