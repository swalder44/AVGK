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
    public partial class FormPDKObM : Form
    {
        public int IDPDKOb;
        public int TO;
        public FormPDKObM()
        {
            InitializeComponent();
            button1.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        internal void FormPDKObM_LoadRN(int IDTS)
        {
            button1.Visible = false;
            button2.Visible = true;

            string z = "SELECT " +
                "rapdopmassts.iddmts, " +
                "rapdopmassts.typets, " +
                "rapdopmassts.kolos, " +
                "rapdopmassts.pdmassts " +
                "FROM rapdopmassts " +
                "WHERE rapdopmassts.iddmts = " + IDTS;
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
                    if(readerT["typets"].ToString()=="1")
                    { comboBox1.Text = "Одиночное ТС";     }
                    else { comboBox1.Text = "Автопоезд"; }
                    alphaBlendTextBox6.Text = readerT["kolos"].ToString();
                    alphaBlendTextBox4.Text = readerT["pdmassts"].ToString();                    
                }
                IDPDKOb = IDTS;
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

        internal void FormPDKObM_LoadRNV(int IDTS)
        {
            button1.Visible = false;
            button2.Visible = false;

            string z = "SELECT " +
                "rapdopmassts.iddmts, " +
                "rapdopmassts.typets, " +
                "rapdopmassts.kolos, " +
                "rapdopmassts.pdmassts " +
                "FROM rapdopmassts " +
                "WHERE rapdopmassts.iddmts = " + IDTS;
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
                    if (readerT["typets"].ToString() == "1")
                    { comboBox1.Text = "Одиночное ТС"; }
                    else { comboBox1.Text = "Автопоезд"; }
                    alphaBlendTextBox6.Text = readerT["kolos"].ToString();
                    alphaBlendTextBox4.Text = readerT["pdmassts"].ToString();
                }
                IDPDKOb = IDTS;
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

        private void button1_Click(object sender, EventArgs e)
        {
            int TO;
            if (comboBox1.Text == "Одиночное ТС")
            { TO = 1; }
            else { TO = 2 ; }

            string z = "INSERT INTO rapdopmassts (" +
                "typets, " +
                "kolos, " +
                "pdmassts) " +
                "VALUES ( " +
                "" + TO + ", " +
                "" + Convert.ToInt32(alphaBlendTextBox6.Text.ToString()) + ", " +
                "" + Convert.ToInt32(alphaBlendTextBox4.Text.ToString()) + "); ";
            MySqlCommand command = new MySqlCommand();
            ConnectStr conStr = new ConnectStr();
            conStr.ConStr(1);
            string connectionString;
            connectionString = conStr.StP;
            MySqlConnection connection = new MySqlConnection(connectionString);
            command.CommandText = z;
            command.Connection = connection;
            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();
        
        Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int TO;
            if (comboBox1.Text == "Одиночное ТС")
            { TO = 1; }
            else { TO = 2; }

            string z = "UPDATE rapdopmassts " +
                "SET typets = " + TO + ", " +
                "kolos = " + Convert.ToInt32(alphaBlendTextBox6.Text.ToString()) + ", " +
                "pdmassts = " + Convert.ToInt32(alphaBlendTextBox4.Text.ToString()) + " " +
                "WHERE iddmts = " + IDPDKOb + ";";
            MySqlCommand command = new MySqlCommand();
            ConnectStr conStr = new ConnectStr();
            conStr.ConStr(1);
            string connectionString;
            connectionString = conStr.StP;
            MySqlConnection connection = new MySqlConnection(connectionString);
            command.CommandText = z;
            command.Connection = connection;
            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();

        
        Close();
    }
    }
}
