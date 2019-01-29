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
    public partial class FormPDKO : Form
    {
        public int IDKL = 0;
        public int NF; public int NT;
        public double RF; public double RT;
        public int[] IDPDK = new int[6];
        public string[,] PDKZN = new string[6, 16];
        public string[] NameTyp = { "одиночная","сдвоенная","строенная","4 и более","Сближенные оси"};
        public FormPDKO()
        {
            InitializeComponent();
            button1.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        internal void FormPDKO_LoadRN(int IDTS)
        {
            button1.Visible = false;
            button2.Visible = true;

            string z = "SELECT " +
                "raposnagrts.iddon, " +
                "raposnagrts.duble_os, " +
                "raposnagrts.tupeos, " +
                "raposnagrts.nametupeos, " +
                "raposnagrts.rasstjsey_min, " +
                "raposnagrts.rasstjsey_max, " +
                "raposnagrts.pdo, " +
                "raposnagrts.pdt, " +
                "raposnagrts.nagrad, " +
                "raposnagrts.NosFor, " +
                "raposnagrts.NosTo, " +
                "raposnagrts.NcircleFor, " +
                "raposnagrts.NcircleTo, " +
                "raposnagrts.TypeOsTo " +
                "FROM raposnagrts " +
                "WHERE raposnagrts.iddon = " + IDTS;

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
                    //alphaBlendTextBox6.Text = readerT["NcircleFor"].ToString();
                    //alphaBlendTextBox5.Text = readerT["NcircleTo"].ToString();
                    RF = Convert.ToInt32(readerT["rasstjsey_min"].ToString());
                    RT = Convert.ToInt32(readerT["rasstjsey_max"].ToString());
                    //alphaBlendTextBox26.Text = readerT["Distanc2_3Min"].ToString();
                    //alphaBlendTextBox1.Text = readerT["Distanc2_3Max"].ToString();
                    //alphaBlendTextBox2.Text = readerT["Distanc3_4Min"].ToString();
                    //alphaBlendTextBox11.Text = readerT["Distanc3_4Max"].ToString();
                    //alphaBlendTextBox10.Text = readerT["Distanc4_5Min"].ToString();
                    //alphaBlendTextBox9.Text = readerT["Distanc4_5Max"].ToString();
                    //alphaBlendTextBox14.Text = readerT["Distanc5_6Min"].ToString();
                    //alphaBlendTextBox13.Text = readerT["Distanc5_6Max"].ToString();
                    //alphaBlendTextBox12.Text = readerT["Distanc6_7Min"].ToString();
                    //alphaBlendTextBox20.Text = readerT["Distanc6_7Max"].ToString();
                    //alphaBlendTextBox19.Text = readerT["Distanc7_8Min"].ToString();
                    //alphaBlendTextBox18.Text = readerT["Distanc7_8Max"].ToString();
                    //alphaBlendTextBox17.Text = readerT["MaxOsNagrm161"].ToString();
                    //alphaBlendTextBox16.Text = readerT["MaxOsNagrm162"].ToString();
                    //alphaBlendTextBox15.Text = readerT["MaxOsNagrm111"].ToString();  
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

            string z1 = "SELECT " +
                "raposnagrts.iddon, " +
                "raposnagrts.duble_os, " +
                "raposnagrts.tupeos, " +
                "raposnagrts.nametupeos, " +
                "raposnagrts.rasstjsey_min, " +
                "raposnagrts.rasstjsey_max, " +
                "raposnagrts.pdo, " +
                "raposnagrts.pdt, " +
                "raposnagrts.nagrad, " +
                "raposnagrts.NosFor, " +
                "raposnagrts.NosTo, " +
                "raposnagrts.NcircleFor, " +
                "raposnagrts.NcircleTo, " +
                "raposnagrts.TypeOsTo, " +
                "pdodoub , " +
                "pdtdoub " +
                "FROM raposnagrts " +
                "WHERE raposnagrts.NosFor = " + NF +
                " AND NosTo = " + NT +
                " AND rasstjsey_min = " + RF +
                " AND rasstjsey_max = " + RT;

            MySqlCommand command1 = new MySqlCommand();
            ConnectStr conStr1 = new ConnectStr();
            conStr1.ConStr(1);
            Zapros zapros1 = new Zapros();
            string connectionString1;
            connectionString1 = conStr1.StP;
            MySqlConnection connection1 = new MySqlConnection(connectionString1);
            command1.CommandText = z1;// commandString;
            command1.Connection = connection1;
            MySqlDataReader reader1;
            try
            {
                command1.Connection.Open();
                reader1 = command1.ExecuteReader();
                while (reader1.Read())
                {
                    if (reader1["nagrad"].ToString() == "6")
                    {
                        //if (reader1["duble_os"].ToString() == "1")
                        //{
                            alphaBlendTextBox3.Text = reader1["NosFor"].ToString();
                            alphaBlendTextBox4.Text = reader1["NosTo"].ToString();
                            alphaBlendTextBox6.Text = reader1["NcircleFor"].ToString();
                            alphaBlendTextBox5.Text = reader1["NcircleTo"].ToString();
                            alphaBlendTextBox8.Text = reader1["rasstjsey_min"].ToString();
                            alphaBlendTextBox7.Text = reader1["rasstjsey_max"].ToString();
                            alphaBlendTextBox26.Text = reader1["nagrad"].ToString();
                            alphaBlendTextBox11.Text = reader1["pdo"].ToString();
                            alphaBlendTextBox20.Text = reader1["pdt"].ToString();
                            alphaBlendTextBox23.Text = reader1["iddon"].ToString();
                            alphaBlendTextBox28.Text = reader1["nametupeos"].ToString();
                            
                        //}
                        //else
                        //{
                            alphaBlendTextBox14.Text = reader1["pdodoub"].ToString();
                            alphaBlendTextBox17.Text = reader1["pdtdoub"].ToString();
                            alphaBlendTextBox27.Text = reader1["iddon"].ToString();
                        //}
                    }
                    else if (reader1["nagrad"].ToString() == "10")
                    {
                        //if (reader1["duble_os"].ToString() == "1")
                        //{                            
                            alphaBlendTextBox1.Text = reader1["nagrad"].ToString();
                            alphaBlendTextBox10.Text = reader1["pdo"].ToString();
                            alphaBlendTextBox19.Text = reader1["pdt"].ToString();
                            alphaBlendTextBox22.Text = reader1["iddon"].ToString();                           
                        //}
                        //else
                        //{
                            alphaBlendTextBox13.Text = reader1["pdodoub"].ToString();
                            alphaBlendTextBox16.Text = reader1["pdtdoub"].ToString();
                            alphaBlendTextBox25.Text = reader1["iddon"].ToString();
                        //}
                    }
                    else if (reader1["nagrad"].ToString() == "11.5")
                    {
                        //if (reader1["duble_os"].ToString() == "1")
                        //{
                            alphaBlendTextBox2.Text = reader1["nagrad"].ToString();
                            alphaBlendTextBox9.Text = reader1["pdo"].ToString();
                            alphaBlendTextBox18.Text = reader1["pdt"].ToString();
                            alphaBlendTextBox21.Text = reader1["iddon"].ToString();                            
                        //}
                        //else
                        //{
                            alphaBlendTextBox12.Text = reader1["pdodoub"].ToString();
                            alphaBlendTextBox15.Text = reader1["pdtdoub"].ToString();
                            alphaBlendTextBox24.Text = reader1["iddon"].ToString();
                        //}
                    }

                }
                IDKL = IDTS;
                reader1.Close();

            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: \r\n{0}", ex.ToString());
            }
            finally
            {
                command1.Connection.Close();
            }

        }

        internal void FormPDKO_LoadRNV(int IDTS)
        {
            button1.Visible = false;
            button2.Visible = false;

            string z = "SELECT " +
                "raposnagrts.iddon, " +
                "raposnagrts.duble_os, " +
                "raposnagrts.tupeos, " +
                "raposnagrts.nametupeos, " +
                "raposnagrts.rasstjsey_min, " +
                "raposnagrts.rasstjsey_max, " +
                "raposnagrts.pdo, " +
                "raposnagrts.pdt, " +
                "raposnagrts.nagrad, " +
                "raposnagrts.NosFor, " +
                "raposnagrts.NosTo, " +
                "raposnagrts.NcircleFor, " +
                "raposnagrts.NcircleTo, " +
                "raposnagrts.TypeOsTo " +
                "FROM raposnagrts " +
                "WHERE raposnagrts.iddon = " + IDTS;

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
                    //alphaBlendTextBox6.Text = readerT["NcircleFor"].ToString();
                    //alphaBlendTextBox5.Text = readerT["NcircleTo"].ToString();
                    RF = Convert.ToInt32(readerT["rasstjsey_min"].ToString());
                    RT = Convert.ToInt32(readerT["rasstjsey_max"].ToString());
                    //alphaBlendTextBox26.Text = readerT["Distanc2_3Min"].ToString();
                    //alphaBlendTextBox1.Text = readerT["Distanc2_3Max"].ToString();
                    //alphaBlendTextBox2.Text = readerT["Distanc3_4Min"].ToString();
                    //alphaBlendTextBox11.Text = readerT["Distanc3_4Max"].ToString();
                    //alphaBlendTextBox10.Text = readerT["Distanc4_5Min"].ToString();
                    //alphaBlendTextBox9.Text = readerT["Distanc4_5Max"].ToString();
                    //alphaBlendTextBox14.Text = readerT["Distanc5_6Min"].ToString();
                    //alphaBlendTextBox13.Text = readerT["Distanc5_6Max"].ToString();
                    //alphaBlendTextBox12.Text = readerT["Distanc6_7Min"].ToString();
                    //alphaBlendTextBox20.Text = readerT["Distanc6_7Max"].ToString();
                    //alphaBlendTextBox19.Text = readerT["Distanc7_8Min"].ToString();
                    //alphaBlendTextBox18.Text = readerT["Distanc7_8Max"].ToString();
                    //alphaBlendTextBox17.Text = readerT["MaxOsNagrm161"].ToString();
                    //alphaBlendTextBox16.Text = readerT["MaxOsNagrm162"].ToString();
                    //alphaBlendTextBox15.Text = readerT["MaxOsNagrm111"].ToString();  
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

            string z1 = "SELECT " +
                "raposnagrts.iddon, " +
                "raposnagrts.duble_os, " +
                "raposnagrts.tupeos, " +
                "raposnagrts.nametupeos, " +
                "raposnagrts.rasstjsey_min, " +
                "raposnagrts.rasstjsey_max, " +
                "raposnagrts.pdo, " +
                "raposnagrts.pdt, " +
                "raposnagrts.nagrad, " +
                "raposnagrts.NosFor, " +
                "raposnagrts.NosTo, " +
                "raposnagrts.NcircleFor, " +
                "raposnagrts.NcircleTo, " +
                "raposnagrts.TypeOsTo, " +
                "pdodoub , " +
                "pdtdoub " +
                "FROM raposnagrts " +
                "WHERE raposnagrts.NosFor = " + NF +
                " AND NosTo = " + NT +
                " AND rasstjsey_min = " + RF +
                " AND rasstjsey_max = " + RT;

            MySqlCommand command1 = new MySqlCommand();
            ConnectStr conStr1 = new ConnectStr();
            conStr1.ConStr(1);
            Zapros zapros1 = new Zapros();
            string connectionString1;
            connectionString1 = conStr1.StP;
            MySqlConnection connection1 = new MySqlConnection(connectionString1);
            command1.CommandText = z1;// commandString;
            command1.Connection = connection1;
            MySqlDataReader reader1;
            try
            {
                command1.Connection.Open();
                reader1 = command1.ExecuteReader();
                while (reader1.Read())
                {
                    if (reader1["nagrad"].ToString() == "6")
                    {
                        //if (reader1["duble_os"].ToString() == "1")
                        //{
                        alphaBlendTextBox3.Text = reader1["NosFor"].ToString();
                        alphaBlendTextBox4.Text = reader1["NosTo"].ToString();
                        alphaBlendTextBox6.Text = reader1["NcircleFor"].ToString();
                        alphaBlendTextBox5.Text = reader1["NcircleTo"].ToString();
                        alphaBlendTextBox8.Text = reader1["rasstjsey_min"].ToString();
                        alphaBlendTextBox7.Text = reader1["rasstjsey_max"].ToString();
                        alphaBlendTextBox26.Text = reader1["nagrad"].ToString();
                        alphaBlendTextBox11.Text = reader1["pdo"].ToString();
                        alphaBlendTextBox20.Text = reader1["pdt"].ToString();
                        alphaBlendTextBox23.Text = reader1["iddon"].ToString();
                        alphaBlendTextBox28.Text = reader1["nametupeos"].ToString();

                        //}
                        //else
                        //{
                        alphaBlendTextBox14.Text = reader1["pdodoub"].ToString();
                        alphaBlendTextBox17.Text = reader1["pdtdoub"].ToString();
                        alphaBlendTextBox27.Text = reader1["iddon"].ToString();
                        //}
                    }
                    else if (reader1["nagrad"].ToString() == "10")
                    {
                        //if (reader1["duble_os"].ToString() == "1")
                        //{                            
                        alphaBlendTextBox1.Text = reader1["nagrad"].ToString();
                        alphaBlendTextBox10.Text = reader1["pdo"].ToString();
                        alphaBlendTextBox19.Text = reader1["pdt"].ToString();
                        alphaBlendTextBox22.Text = reader1["iddon"].ToString();
                        //}
                        //else
                        //{
                        alphaBlendTextBox13.Text = reader1["pdodoub"].ToString();
                        alphaBlendTextBox16.Text = reader1["pdtdoub"].ToString();
                        alphaBlendTextBox25.Text = reader1["iddon"].ToString();
                        //}
                    }
                    else if (reader1["nagrad"].ToString() == "11.5")
                    {
                        //if (reader1["duble_os"].ToString() == "1")
                        //{
                        alphaBlendTextBox2.Text = reader1["nagrad"].ToString();
                        alphaBlendTextBox9.Text = reader1["pdo"].ToString();
                        alphaBlendTextBox18.Text = reader1["pdt"].ToString();
                        alphaBlendTextBox21.Text = reader1["iddon"].ToString();
                        //}
                        //else
                        //{
                        alphaBlendTextBox12.Text = reader1["pdodoub"].ToString();
                        alphaBlendTextBox15.Text = reader1["pdtdoub"].ToString();
                        alphaBlendTextBox24.Text = reader1["iddon"].ToString();
                        //}
                    }

                }
                IDKL = IDTS;
                reader1.Close();

            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: \r\n{0}", ex.ToString());
            }
            finally
            {
                command1.Connection.Close();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            IDPDK[0] = Convert.ToInt32(alphaBlendTextBox23.Text.ToString());
            IDPDK[1] = Convert.ToInt32(alphaBlendTextBox22.Text.ToString());
            IDPDK[2] = Convert.ToInt32(alphaBlendTextBox21.Text.ToString());
            IDPDK[3] = Convert.ToInt32(alphaBlendTextBox27.Text.ToString());
            IDPDK[4] = Convert.ToInt32(alphaBlendTextBox25.Text.ToString());
            IDPDK[5] = Convert.ToInt32(alphaBlendTextBox24.Text.ToString());

            PDKZN[0, 14] = Convert.ToString(alphaBlendTextBox28.Text.ToString());
            PDKZN[0, 0]= Convert.ToString(Convert.ToInt32(alphaBlendTextBox6.Text.ToString())/2);
            PDKZN[1, 0] = Convert.ToString(Convert.ToInt32(alphaBlendTextBox6.Text.ToString()) / 2);
            PDKZN[2, 0] = Convert.ToString(Convert.ToInt32(alphaBlendTextBox6.Text.ToString()) / 2);
            if (alphaBlendTextBox3.Text.ToString() == alphaBlendTextBox4.Text.ToString())
            {
                PDKZN[0, 1] = alphaBlendTextBox3.Text.ToString();
                //PDKZN[0, 2] = NameTyp[Convert.ToInt32(alphaBlendTextBox3.Text) - 1];
                PDKZN[1, 1] = alphaBlendTextBox3.Text.ToString();
                //PDKZN[1, 2] = NameTyp[Convert.ToInt32(alphaBlendTextBox3.Text) - 1];
                PDKZN[2, 1] = alphaBlendTextBox3.Text.ToString();
            }
            //PDKZN[2, 2] = NameTyp[Convert.ToInt32(alphaBlendTextBox3.Text) - 1]; }
            else if (Convert.ToInt32(alphaBlendTextBox3.Text.ToString()) < Convert.ToInt32(alphaBlendTextBox4.Text.ToString()) && Convert.ToInt32(alphaBlendTextBox3.Text.ToString()) == 4)
            { PDKZN[0, 1] = alphaBlendTextBox3.Text.ToString(); /*PDKZN[0, 2] = NameTyp[3];*/ PDKZN[1, 1] = alphaBlendTextBox3.Text.ToString(); /*PDKZN[1, 2] = NameTyp[3];*/ PDKZN[2, 1] = alphaBlendTextBox3.Text.ToString(); /*PDKZN[2, 2] = NameTyp[3];*/ }
            else
            { PDKZN[0, 1] = Convert.ToString(Convert.ToInt32(alphaBlendTextBox3.Text.ToString()) - 2); /*PDKZN[0, 2] = NameTyp[4];*/ PDKZN[1, 1] = Convert.ToString(Convert.ToInt32(alphaBlendTextBox3.Text.ToString()) - 2); /*PDKZN[1, 2] = NameTyp[4];*/ PDKZN[2, 1] = Convert.ToString(Convert.ToInt32(alphaBlendTextBox3.Text.ToString()) - 2); /*PDKZN[2, 2] = NameTyp[4];*/ }
            PDKZN[0, 3] = alphaBlendTextBox8.Text.ToString(); PDKZN[1, 3] = alphaBlendTextBox8.Text.ToString(); PDKZN[2, 3] = alphaBlendTextBox8.Text.ToString();
            PDKZN[0, 4] = alphaBlendTextBox7.Text.ToString(); PDKZN[1, 4] = alphaBlendTextBox7.Text.ToString(); PDKZN[2, 4] = alphaBlendTextBox7.Text.ToString();

                PDKZN[0, 5] = alphaBlendTextBox11.Text.ToString();
                PDKZN[0, 6] = alphaBlendTextBox20.Text.ToString();
                PDKZN[0, 7] = alphaBlendTextBox14.Text.ToString();
                PDKZN[0, 8] = alphaBlendTextBox17.Text.ToString();
                PDKZN[0, 9] = alphaBlendTextBox26.Text.ToString();
                PDKZN[0, 10] = alphaBlendTextBox3.Text.ToString();
                PDKZN[0, 11] = alphaBlendTextBox4.Text.ToString();
                PDKZN[0, 12] = alphaBlendTextBox6.Text.ToString();
                PDKZN[0, 13] = alphaBlendTextBox5.Text.ToString();

            PDKZN[1, 5] = alphaBlendTextBox10.Text.ToString();
            PDKZN[1, 6] = alphaBlendTextBox19.Text.ToString();
            PDKZN[1, 7] = alphaBlendTextBox13.Text.ToString();
            PDKZN[1, 8] = alphaBlendTextBox16.Text.ToString();
            PDKZN[1, 9] = alphaBlendTextBox1.Text.ToString();
            PDKZN[1, 10] = alphaBlendTextBox3.Text.ToString();
            PDKZN[1, 11] = alphaBlendTextBox4.Text.ToString();
            PDKZN[1, 12] = alphaBlendTextBox6.Text.ToString();
            PDKZN[1, 13] = alphaBlendTextBox5.Text.ToString();

            PDKZN[2, 5] = alphaBlendTextBox9.Text.ToString();
            PDKZN[2, 6] = alphaBlendTextBox18.Text.ToString();
            PDKZN[2, 7] = alphaBlendTextBox12.Text.ToString();
            PDKZN[2, 8] = alphaBlendTextBox15.Text.ToString();
            PDKZN[2, 9] = alphaBlendTextBox2.Text.ToString();
            PDKZN[2, 10] = alphaBlendTextBox3.Text.ToString();
            PDKZN[2, 11] = alphaBlendTextBox4.Text.ToString();
            PDKZN[2, 12] = alphaBlendTextBox6.Text.ToString();
            PDKZN[2, 13] = alphaBlendTextBox5.Text.ToString();

            for (int i=0; i<3; i++)
            {
                string z = "UPDATE raposnagrts " +
                "SET duble_os = " + Convert.ToInt32(PDKZN[i,0]) + ", " +
                "tupeos = " + Convert.ToInt32(PDKZN[i,1]) + ", " +
                "nametupeos = '" + PDKZN[0, 14].ToString() + "', " +
                "rasstjsey_min = " + Convert.ToDouble(PDKZN[i, 3]) + ", " +
                "rasstjsey_max = " + Convert.ToDouble(PDKZN[i, 4]) + ", " +
                "pdo = " + Convert.ToDouble(PDKZN[i, 5]) + ", " +
                "pdt = " + Convert.ToDouble(PDKZN[i, 6]) + ", " +
                "pdodoub = " + Convert.ToDouble(PDKZN[i, 7]) + ", " +
                "pdtdoub = " + Convert.ToDouble(PDKZN[i, 8]) + ", " +
                "nagrad = " + Convert.ToDouble(PDKZN[i, 9]) + ", " +
                "NosFor = " + Convert.ToInt32(PDKZN[i, 10]) + ", " +
                "NosTo = " + Convert.ToInt32(PDKZN[i, 11]) + ", " +
                "NcircleFor = " + Convert.ToInt32(PDKZN[i, 12]) + ", " +
                "NcircleTo = " + Convert.ToInt32(PDKZN[i, 13]) + " " +
                "WHERE iddon = " + IDPDK[i] + ";";
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
               
            }
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //IDPDK[0] = Convert.ToInt32(alphaBlendTextBox23.Text.ToString());
            //IDPDK[1] = Convert.ToInt32(alphaBlendTextBox22.Text.ToString());
            //IDPDK[2] = Convert.ToInt32(alphaBlendTextBox21.Text.ToString());
            //IDPDK[3] = Convert.ToInt32(alphaBlendTextBox27.Text.ToString());
            //IDPDK[4] = Convert.ToInt32(alphaBlendTextBox25.Text.ToString());
            //IDPDK[5] = Convert.ToInt32(alphaBlendTextBox24.Text.ToString());
            PDKZN[0, 14]= Convert.ToString(alphaBlendTextBox28.Text.ToString());
            PDKZN[0, 0] = Convert.ToString(Convert.ToInt32(alphaBlendTextBox6.Text.ToString()) / 2);
            PDKZN[1, 0] = Convert.ToString(Convert.ToInt32(alphaBlendTextBox6.Text.ToString()) / 2);
            PDKZN[2, 0] = Convert.ToString(Convert.ToInt32(alphaBlendTextBox6.Text.ToString()) / 2);
            if (alphaBlendTextBox3.Text.ToString() == alphaBlendTextBox4.Text.ToString())
            {
                PDKZN[0, 1] = alphaBlendTextBox3.Text.ToString();
                //PDKZN[0, 2] = NameTyp[Convert.ToInt32(alphaBlendTextBox3.Text) - 1];
                PDKZN[1, 1] = alphaBlendTextBox3.Text.ToString();
                //PDKZN[1, 2] = NameTyp[Convert.ToInt32(alphaBlendTextBox3.Text) - 1];
                PDKZN[2, 1] = alphaBlendTextBox3.Text.ToString();
                //PDKZN[2, 2] = NameTyp[Convert.ToInt32(alphaBlendTextBox3.Text) - 1];
            }
            else if (Convert.ToInt32(alphaBlendTextBox3.Text.ToString()) < Convert.ToInt32(alphaBlendTextBox4.Text.ToString()) && Convert.ToInt32(alphaBlendTextBox3.Text.ToString()) == 4)
            { PDKZN[0, 1] = alphaBlendTextBox3.Text.ToString(); /*PDKZN[0, 2] = NameTyp[3];*/ PDKZN[1, 1] = alphaBlendTextBox3.Text.ToString(); /*PDKZN[1, 2] = NameTyp[3];*/ PDKZN[2, 1] = alphaBlendTextBox3.Text.ToString(); /*PDKZN[2, 2] = NameTyp[3];*/ }
            else if (Convert.ToInt32(alphaBlendTextBox3.Text.ToString()) < Convert.ToInt32(alphaBlendTextBox4.Text.ToString()))
            { PDKZN[0, 1] = alphaBlendTextBox3.Text.ToString(); /*PDKZN[0, 2] = NameTyp[3];*/ PDKZN[1, 1] = alphaBlendTextBox3.Text.ToString(); /*PDKZN[1, 2] = NameTyp[3];*/ PDKZN[2, 1] = alphaBlendTextBox3.Text.ToString(); /*PDKZN[2, 2] = NameTyp[3];*/ }
            else
            { PDKZN[0, 1] = Convert.ToString(Convert.ToInt32(alphaBlendTextBox3.Text.ToString()) - 2); /*PDKZN[0, 2] = NameTyp[4];*/ PDKZN[1, 1] = Convert.ToString(Convert.ToInt32(alphaBlendTextBox3.Text.ToString()) - 2); /*PDKZN[1, 2] = NameTyp[4];*/ PDKZN[2, 1] = Convert.ToString(Convert.ToInt32(alphaBlendTextBox3.Text.ToString()) - 2); /*PDKZN[2, 2] = NameTyp[4];*/ }
            PDKZN[0, 3] = alphaBlendTextBox8.Text.ToString(); PDKZN[1, 3] = alphaBlendTextBox8.Text.ToString(); PDKZN[2, 3] = alphaBlendTextBox8.Text.ToString();
            PDKZN[0, 4] = alphaBlendTextBox7.Text.ToString(); PDKZN[1, 4] = alphaBlendTextBox7.Text.ToString(); PDKZN[2, 4] = alphaBlendTextBox7.Text.ToString();

            PDKZN[0, 5] = alphaBlendTextBox11.Text.ToString();
            PDKZN[0, 6] = alphaBlendTextBox20.Text.ToString();
            PDKZN[0, 7] = alphaBlendTextBox14.Text.ToString();
            PDKZN[0, 8] = alphaBlendTextBox17.Text.ToString();
            PDKZN[0, 9] = alphaBlendTextBox26.Text.ToString();
            PDKZN[0, 10] = alphaBlendTextBox3.Text.ToString();
            PDKZN[0, 11] = alphaBlendTextBox4.Text.ToString();
            PDKZN[0, 12] = alphaBlendTextBox6.Text.ToString();
            PDKZN[0, 13] = alphaBlendTextBox5.Text.ToString();

            PDKZN[1, 5] = alphaBlendTextBox10.Text.ToString();
            PDKZN[1, 6] = alphaBlendTextBox19.Text.ToString();
            PDKZN[1, 7] = alphaBlendTextBox13.Text.ToString();
            PDKZN[1, 8] = alphaBlendTextBox16.Text.ToString();
            PDKZN[1, 9] = alphaBlendTextBox1.Text.ToString();
            PDKZN[1, 10] = alphaBlendTextBox3.Text.ToString();
            PDKZN[1, 11] = alphaBlendTextBox4.Text.ToString();
            PDKZN[1, 12] = alphaBlendTextBox6.Text.ToString();
            PDKZN[1, 13] = alphaBlendTextBox5.Text.ToString();

            PDKZN[2, 5] = alphaBlendTextBox9.Text.ToString();
            PDKZN[2, 6] = alphaBlendTextBox18.Text.ToString();
            PDKZN[2, 7] = alphaBlendTextBox12.Text.ToString();
            PDKZN[2, 8] = alphaBlendTextBox15.Text.ToString();
            PDKZN[2, 9] = alphaBlendTextBox2.Text.ToString();
            PDKZN[2, 10] = alphaBlendTextBox3.Text.ToString();
            PDKZN[2, 11] = alphaBlendTextBox4.Text.ToString();
            PDKZN[2, 12] = alphaBlendTextBox6.Text.ToString();
            PDKZN[2, 13] = alphaBlendTextBox5.Text.ToString();
            for (int i = 0; i < 3; i++)
            {
                string z = "INSERT INTO raposnagrts (" +
                "duble_os, " +
                "tupeos, " +
                "nametupeos, " +
                "rasstjsey_min, " +
                "rasstjsey_max, " +
                "pdo, " +
                "pdt, " +
                "nagrad, " +
                "NosFor, " +
                "NosTo, " +
                "NcircleFor, " +
                "NcircleTo, " +
                //"TypeOsTo, " +
                "pdodoub, " +
                "pdtdoub) " +
                "VALUES ( " +
                "" + Convert.ToInt32(PDKZN[i, 0]) + ", " +
                "" + Convert.ToInt32(PDKZN[i, 1]) + ", " +
                "'" + PDKZN[0, 14].ToString() + "', " +
                "" + Convert.ToDouble(PDKZN[i, 3]) + ", " +
                "" + Convert.ToDouble(PDKZN[i, 4]) + ", " +
                "" + Convert.ToDouble(PDKZN[i, 5]) + ", " +
                "" + Convert.ToDouble(PDKZN[i, 6]) + ", " +
                "" + Convert.ToDouble(PDKZN[i, 9]) + ", " +
                "" + Convert.ToDouble(PDKZN[i, 10]) + ", " +
                "" + Convert.ToDouble(PDKZN[i, 11]) + ", " +
                "" + Convert.ToInt32(PDKZN[i, 12]) + ", " +
                "" + Convert.ToInt32(PDKZN[i, 13]) + ", " +
                //"" + Convert.ToInt32(PDKZN[i, __]) + ", " +
                "" + Convert.ToInt32(PDKZN[i, 7]) + ", " +
                "" + Convert.ToInt32(PDKZN[i, 8]) + "); ";
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
            }
            Close();
        }
    }
}
