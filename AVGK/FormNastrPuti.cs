using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AVGK
{
    public partial class FormNastrPuti : Form
    {
        public string[] Param = new string[15];
        public int IDRM = 0;

        public FormNastrPuti()
        {
            InitializeComponent();
            label2.Text = System.Windows.Forms.SystemInformation.ComputerName.ToString();
            button1.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        internal void FormNastrPuti_Load(int ID)
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
            zapros.NastrPuti(ID, "");
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
                    label2.Text = reader["CompName"].ToString();
                    textBox1.Text = reader["Rab_mesto"].ToString();
                    textBox2.Text = reader["Photo"].ToString()+ "\\";
                    textBox3.Text = reader["XML_Ang"].ToString() + "\\";                    
                    textBox4.Text = reader["Akt_Arch"].ToString() + "\\";
                    //alphaBlendTextBox2.Text = reader["ChisloNapravlen"].ToString();
                    //alphaBlendTextBox3.Text = reader["ObshProtyajAD"].ToString();
                    //alphaBlendTextBox4.Text = reader["widthAD"].ToString();
                    //alphaBlendTextBox6.Text = reader["widthObochin"].ToString();
                    //alphaBlendTextBox5.Text = reader["widthRazdPolos"].ToString();
                    //alphaBlendTextBox22.Text = reader["VladeletsAD"].ToString();
                    //alphaBlendTextBox21.Text = reader["AdrVladel"].ToString();
                    //alphaBlendTextBox20.Text = reader["KontaktVladel"].ToString();
                    //alphaBlendTextBox7.Text = reader["OtvLVladel"].ToString();
                    IDRM = ID;
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

        private void button1_Click(object sender, EventArgs e)///кнопка сохранить новое рабочее место

        {
            //Rab_mesto, Photo, XML_Ang, Akt_Arch, BD_log, BD_pass, BD_Name, BD_adr, Mail_in, Mail_in_pass, Mail_out, Mail_out_pass, Adr_SR, Adr_Avtodor, CompName
            Param[0] = textBox1.Text.ToString(); 
            Param[1] = textBox2.Text.ToString();
            Param[2] = textBox3.Text.ToString();
            Param[3] = textBox4.Text.ToString();
            Param[4] = "";//textBox4.Text.ToString();
            Param[5] = "";//textBox4.Text.ToString();
            Param[6] = "";//textBox4.Text.ToString();
            Param[7] = "";//textBox4.Text.ToString();
            Param[8] = "";//textBox4.Text.ToString();
            Param[9] = "";//textBox4.Text.ToString();
            Param[10] = "";//textBox4.Text.ToString();
            Param[11] = "";//textBox4.Text.ToString();
            Param[12] = "";//textBox4.Text.ToString();
            Param[13] = "";//textBox4.Text.ToString();
            Param[14] = label2.Text.ToString();

            MySqlCommand command = new MySqlCommand();
            ConnectStr conStr = new ConnectStr();
            conStr.ConStr(1);
            string connectionString;
            connectionString = conStr.StP;
            MySqlConnection connection = new MySqlConnection(connectionString);
            Zapros zapros = new Zapros();
            zapros.DobNastrPuti(Param);
            string z = zapros.commandStringTest; 
            command.CommandText = z;
            command.Connection = connection;
            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)////////////////////////////   Сохранение изменений в Рабочих местах
        {
            MySqlCommand command = new MySqlCommand();
            ConnectStr conStr = new ConnectStr();
            conStr.ConStr(1);
            //Zapros zapros = new Zapros();
            string connectionString;
            connectionString = conStr.StP;
            MySqlConnection connection = new MySqlConnection(connectionString);
            //zapros.AD(IDRN);
            string z = "UPDATE rap_nastr_puti " +
                "SET CompName = '" + label2.Text + "', " +
                "Rab_mesto = '" + textBox1.Text + "', " +
                "Photo = '" + textBox2.Text + "', " +
                "XML_Ang = '" + textBox3.Text + "', " +
                "Akt_Arch = '" + textBox4.Text + "' " +
                //"ChisloPolos = " + Convert.ToInt32(alphaBlendTextBox15.Text) + ", " +
                //"ChisloNapravlen = " + Convert.ToInt32(alphaBlendTextBox2.Text) + ", " +
                //"ObshProtyajAD = '" + alphaBlendTextBox3.Text + "', " +
                //"widthAD = " + Convert.ToDouble(alphaBlendTextBox4.Text) + ", " +
                //"widthObochin = " + Convert.ToDouble(alphaBlendTextBox6.Text) + ", " +
                //"widthRazdPolos = " + Convert.ToDouble(alphaBlendTextBox5.Text) + ", " +
                //"VladeletsAD = '" + alphaBlendTextBox22.Text + "', " +
                //"AdrVladel = '" + alphaBlendTextBox21.Text + "', " +
                //"KontaktVladel = '" + alphaBlendTextBox20.Text + "', " +
                //"OtvLVladel = '" + alphaBlendTextBox7.Text + "' " +
                " WHERE IDPut = " + IDRM;
            command.CommandText = z;// commandString;
            command.Connection = connection;

            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label2.Text = System.Windows.Forms.SystemInformation.ComputerName.ToString();
        }
    }
}
