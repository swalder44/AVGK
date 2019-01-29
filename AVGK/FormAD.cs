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
    public partial class FormAD : Form
    {
        public int IDRub = 0;
        public string KODNapr = "";
        public int k = 1;
        public int k1 = 1;
        public int idr;
        public FormAD()
        {
            InitializeComponent();
            button1.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)/////////////////////////  Закрытие формы
        {
            Close();
        }
        internal void FormAD_LoadRN(int IDRN)
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
            zapros.AD(IDRN);
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
                    alphaBlendTextBox26.Text = reader["IDAD"].ToString();
                    alphaBlendTextBox1.Text = reader["UchNomer"].ToString();
                    alphaBlendTextBox31.Text = reader["Name Dor"].ToString();
                    alphaBlendTextBox16.Text = reader["KatergryAD"].ToString();
                    comboBox1.Text = reader["ZnachenAD"].ToString();
                    alphaBlendTextBox15.Text = reader["ChisloPolos"].ToString();
                    alphaBlendTextBox2.Text = reader["ChisloNapravlen"].ToString();
                    alphaBlendTextBox3.Text = reader["ObshProtyajAD"].ToString();
                    alphaBlendTextBox4.Text = reader["widthAD"].ToString();
                    alphaBlendTextBox6.Text = reader["widthObochin"].ToString();
                    alphaBlendTextBox5.Text = reader["widthRazdPolos"].ToString();
                    alphaBlendTextBox22.Text = reader["VladeletsAD"].ToString();
                    alphaBlendTextBox21.Text = reader["AdrVladel"].ToString();
                    alphaBlendTextBox20.Text = reader["KontaktVladel"].ToString();
                    alphaBlendTextBox7.Text = reader["OtvLVladel"].ToString();
                    IDRub = IDRN;
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

        internal void FormAD_LoadRNV(int IDRN)
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
            zapros.AD(IDRN);
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
                    alphaBlendTextBox26.Text = reader["IDAD"].ToString();
                    alphaBlendTextBox1.Text = reader["UchNomer"].ToString();
                    alphaBlendTextBox31.Text = reader["Name Dor"].ToString();
                    alphaBlendTextBox16.Text = reader["KatergryAD"].ToString();
                    comboBox1.Text = reader["ZnachenAD"].ToString();
                    alphaBlendTextBox15.Text = reader["ChisloPolos"].ToString();
                    alphaBlendTextBox2.Text = reader["ChisloNapravlen"].ToString();
                    alphaBlendTextBox3.Text = reader["ObshProtyajAD"].ToString();
                    alphaBlendTextBox4.Text = reader["widthAD"].ToString();
                    alphaBlendTextBox6.Text = reader["widthObochin"].ToString();
                    alphaBlendTextBox5.Text = reader["widthRazdPolos"].ToString();
                    alphaBlendTextBox22.Text = reader["VladeletsAD"].ToString();
                    alphaBlendTextBox21.Text = reader["AdrVladel"].ToString();
                    alphaBlendTextBox20.Text = reader["KontaktVladel"].ToString();
                    alphaBlendTextBox7.Text = reader["OtvLVladel"].ToString();
                    IDRub = IDRN;
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
            //zapros.AD(IDRN);
            string z = "UPDATE rapdoroga " +
                "SET IDAD = " + Convert.ToInt32(alphaBlendTextBox26.Text) + ", " +
                "UchNomer = '" + alphaBlendTextBox1.Text + "', " +
                "`Name Dor` = '" + alphaBlendTextBox31.Text + "', " +
                "KatergryAD = " + Convert.ToInt32(alphaBlendTextBox16.Text) + ", " +
                "ZnachenAD = '" + comboBox1.Text + "', " +
                "ChisloPolos = " + Convert.ToInt32(alphaBlendTextBox15.Text) + ", " +
                "ChisloNapravlen = " + Convert.ToInt32(alphaBlendTextBox2.Text) + ", " +
                "ObshProtyajAD = '" + alphaBlendTextBox3.Text + "', " +
                "widthAD = " + Convert.ToDouble(alphaBlendTextBox4.Text) + ", " +
                "widthObochin = " + Convert.ToDouble(alphaBlendTextBox6.Text) + ", " +
                "widthRazdPolos = " + Convert.ToDouble(alphaBlendTextBox5.Text) + ", " +
                "VladeletsAD = '" + alphaBlendTextBox22.Text + "', " +
                "AdrVladel = '" + alphaBlendTextBox21.Text + "', " +
                "KontaktVladel = '" + alphaBlendTextBox20.Text + "', " +
                "OtvLVladel = '" + alphaBlendTextBox7.Text + "' " +
                " WHERE id = " + IDRub;
            command.CommandText = z;// commandString;
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
            string z = " INSERT INTO rapdoroga " +
                "(IDAD, " +
                "UchNomer, " +
                "`Name Dor`, " +
                "KatergryAD, " +
                "ZnachenAD, " +
                "ChisloPolos, " +
                "ChisloNapravlen, " +
                "ObshProtyajAD, " +
                "widthAD, " +
                "widthObochin, " +
                "widthRazdPolos, " +
                "VladeletsAD, " +
                "AdrVladel, " +
                "KontaktVladel, " +
                "OtvLVladel) " +                
                "VALUES(" + Convert.ToInt32(alphaBlendTextBox26.Text) + ", " +
                "'" + alphaBlendTextBox1.Text + "', " +
                "'" + alphaBlendTextBox31.Text + "', " +
                "" + Convert.ToInt32(alphaBlendTextBox16.Text) + ", " +
                "'" + comboBox1.Text + "', " +
                "" + Convert.ToInt32(alphaBlendTextBox15.Text) + ", " +
                "" + Convert.ToInt32(alphaBlendTextBox2.Text) + ", " +
                "'" + alphaBlendTextBox3.Text + "', " +
                "" + Convert.ToDouble(alphaBlendTextBox4.Text) + ", " +
                "" + Convert.ToDouble(alphaBlendTextBox6.Text) + ", " +
                "" + Convert.ToDouble(alphaBlendTextBox5.Text) + ", " +
                "'" + alphaBlendTextBox22.Text + "', " +
                "'" + alphaBlendTextBox21.Text + "', " +
                "'" + alphaBlendTextBox20.Text + "', " +
                "'" + alphaBlendTextBox7.Text + "' )" ;
            command.CommandText = z;// commandString;
            command.Connection = connection;

            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();
            Close();
            
        }
    }
}
