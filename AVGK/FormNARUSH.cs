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
    public partial class FormNARUSH : Form
    {
        public int IDNAR;
        public int NCh;
        public string zR;
        public string[,] TabNar = new string[7,10];
        private string cstr;
        private string z;
        private MySqlDataAdapter mySqlDataAdapter;

        public FormNARUSH()
        {
            InitializeComponent();
            button1.Visible = true;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void button1_Click(object sender, EventArgs e)/////////////Кнопка Сохранить (для нового проезда)
        {
            if (checkBox1.Checked == true)
            {
               TabNar[1, 0] = textBox1.Text.ToString();
               TabNar[1, 1] = comboBox1.Text.ToString();
               TabNar[1, 2] = textBox14.Text.ToString();
               TabNar[1, 3] = textBox20.Text.ToString();
               TabNar[1, 4] = textBox26.Text.ToString();
               TabNar[1, 5] = textBox32.Text.ToString();
               TabNar[1, 6] = textBox33.Text.ToString();
               TabNar[1, 7] = textBox34.Text.ToString();
               TabNar[1, 8] = textBox35.Text.ToString();
               TabNar[1, 9] = textBox3.Text.ToString();

                TabNar[2, 0] = textBox1.Text.ToString();
                TabNar[2, 1] = comboBox1.Text.ToString();
                TabNar[2, 2] = textBox13.Text.ToString();
                TabNar[2, 3] = textBox19.Text.ToString();
                TabNar[2, 4] = textBox25.Text.ToString();
                TabNar[2, 5] = textBox31.Text.ToString();
                TabNar[2, 6] = textBox33.Text.ToString();
                TabNar[2, 7] = textBox34.Text.ToString();
                TabNar[2, 8] = textBox35.Text.ToString();
                TabNar[2, 9] = textBox4.Text.ToString();

                TabNar[3, 0] = textBox1.Text.ToString();
                TabNar[3, 1] = comboBox1.Text.ToString();
                TabNar[3, 2] = textBox12.Text.ToString();
                TabNar[3, 3] = textBox18.Text.ToString();
                TabNar[3, 4] = textBox24.Text.ToString();
                TabNar[3, 5] = textBox30.Text.ToString();
                TabNar[3, 6] = textBox33.Text.ToString();
                TabNar[3, 7] = textBox34.Text.ToString();
                TabNar[3, 8] = textBox35.Text.ToString();
                TabNar[3, 9] = textBox5.Text.ToString();

                TabNar[4, 0] = textBox1.Text.ToString();
                TabNar[4, 1] = comboBox1.Text.ToString();
                TabNar[4, 2] = textBox11.Text.ToString();
                TabNar[4, 3] = textBox17.Text.ToString();
                TabNar[4, 4] = textBox23.Text.ToString();
                TabNar[4, 5] = textBox29.Text.ToString();
                TabNar[4, 6] = textBox33.Text.ToString();
                TabNar[4, 7] = textBox34.Text.ToString();
                TabNar[4, 8] = textBox35.Text.ToString();
                TabNar[4, 9] = textBox6.Text.ToString();

                TabNar[5, 0] = textBox1.Text.ToString();
                TabNar[5, 1] = comboBox1.Text.ToString();
                TabNar[5, 2] = textBox10.Text.ToString();
                TabNar[5, 3] = textBox16.Text.ToString();
                TabNar[5, 4] = textBox22.Text.ToString();
                TabNar[5, 5] = textBox28.Text.ToString();
                TabNar[5, 6] = textBox33.Text.ToString();
                TabNar[5, 7] = textBox34.Text.ToString();
                TabNar[5, 8] = textBox35.Text.ToString();
                TabNar[5, 9] = textBox7.Text.ToString();

                TabNar[6, 0] = textBox1.Text.ToString();
                TabNar[6, 1] = comboBox1.Text.ToString();
                TabNar[6, 2] = textBox9.Text.ToString();
                TabNar[6, 3] = textBox15.Text.ToString();
                TabNar[6, 4] = textBox21.Text.ToString();
                TabNar[6, 5] = textBox27.Text.ToString();
                TabNar[6, 6] = textBox33.Text.ToString();
                TabNar[6, 7] = textBox34.Text.ToString();
                TabNar[6, 8] = textBox35.Text.ToString();
                TabNar[6, 9] = textBox8.Text.ToString();

                for (int i=1; i<7; i++)
                {
                    string stat = TabNar[i, 6] + " ч." + TabNar[i, 9];
                         string z = "INSERT INTO raptsprnar (" +
                "tipnar, " +
                "tipnarN, " +
                "ChastSt, " +
                "NoSRFor, " +
                "NoSRTo, " +
                "MitSRFor, " +
                "MitSRTo, " +
                "STATIA, " +
                "vidnar, " +
                "prmechannar ) " +
                "VALUES ( " +
                "" + Convert.ToInt32(TabNar[i, 0]) + ", " +
                 "'" + TabNar[i, 1] + "', " +
                  "" + Convert.ToInt32(TabNar[i, 9]) + ", " +
                   "" + Convert.ToInt32(TabNar[i, 2]) + ", " +
                    "" + Convert.ToInt32(TabNar[i, 3]) + ", " +
                     "" + Convert.ToInt32(TabNar[i, 4]) + ", " +
                      "" + Convert.ToInt32(TabNar[i, 5]) + ", " +
                       "'" + stat.ToString() + "', " +
                        "'" + TabNar[i, 7] + "', " +
                         "'" + TabNar[i, 8] + "'); ";
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                checkBox6.Checked = false;
                checkBox7.Checked = false;

                checkBox2.Enabled = false;
                checkBox3.Enabled = false;
                checkBox4.Enabled = false;
                checkBox5.Enabled = false;
                checkBox6.Enabled = false;
                checkBox7.Enabled = false;
            }
            else
            {
                checkBox2.Enabled = true;
                checkBox3.Enabled = true;
                checkBox4.Enabled = true;
                checkBox5.Enabled = true;
                checkBox6.Enabled = true;
                checkBox7.Enabled = true;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            { checkBox1.Checked = false;/* checkBox1.Enabled = false;*/ }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            { checkBox1.Checked = false;/* checkBox1.Enabled = false;*/ }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            { checkBox1.Checked = false;/* checkBox1.Enabled = false;*/ }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true)
            { checkBox1.Checked = false;/* checkBox1.Enabled = false; */}
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked == true)
            { checkBox1.Checked = false; /*checkBox1.Enabled = false;*/ }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked == true)
            { checkBox1.Checked = false; /*checkBox1.Enabled = false; */}
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "5")
            {
                textBox40.Enabled = false; textBox39.Enabled = false;
                textBox3.Enabled = true; textBox4.Enabled = true; textBox5.Enabled = true; textBox6.Enabled = true; textBox7.Enabled = true; textBox8.Enabled = true;
                textBox9.Enabled = true; textBox10.Enabled = true; textBox11.Enabled = true; textBox12.Enabled = true; textBox13.Enabled = true; textBox14.Enabled = true;
                textBox15.Enabled = true; textBox16.Enabled = true; textBox17.Enabled = true; textBox18.Enabled = true; textBox19.Enabled = true; textBox20.Enabled = true;
                textBox21.Enabled = true; textBox22.Enabled = true; textBox23.Enabled = true; textBox24.Enabled = true; textBox25.Enabled = true; textBox26.Enabled = true;
                textBox27.Enabled = true; textBox28.Enabled = true; textBox29.Enabled = true; textBox30.Enabled = true; textBox31.Enabled = true; textBox32.Enabled = true;
                checkBox1.Enabled = true;
            }
            else
            {
                textBox40.Enabled = true; textBox39.Enabled = true;
                textBox3.Enabled = false; textBox4.Enabled = false; textBox5.Enabled = false; textBox6.Enabled = false; textBox7.Enabled = false; textBox8.Enabled = false;
                textBox9.Enabled = false; textBox10.Enabled = false; textBox11.Enabled = false; textBox12.Enabled = false; textBox13.Enabled = false; textBox14.Enabled = false;
                textBox15.Enabled = false; textBox16.Enabled = false; textBox17.Enabled = false; textBox18.Enabled = false; textBox19.Enabled = false; textBox20.Enabled = false;
                textBox21.Enabled = false; textBox22.Enabled = false; textBox23.Enabled = false; textBox24.Enabled = false; textBox25.Enabled = false; textBox26.Enabled = false;
                textBox27.Enabled = false; textBox28.Enabled = false; textBox29.Enabled = false; textBox30.Enabled = false; textBox31.Enabled = false; textBox32.Enabled = false;
                checkBox1.Checked = false; checkBox1.Enabled = false;
            }
        }

        internal void FormNARUSH_Load(int IDTS)
        
        {
            int i = 0;
            button1.Visible = false;
            button2.Visible = true;
            MySqlCommand commandR = new MySqlCommand();
            ConnectStr conStrR = new ConnectStr();
            conStrR.ConStr(1);
            Zapros zaprosR = new Zapros();
            string connectionStringR;//, commandString;
            connectionStringR = conStrR.StP;//"Data source=localhost;UserId=root;Password=1q2w3e$R;database=camloc;";
            MySqlConnection connectionR = new MySqlConnection(connectionStringR);
            zaprosR.Narush(IDTS);
            zR = zaprosR.commandStringTest;
            commandR.CommandText = zR;// commandString;
            commandR.Connection = connectionR;

            MySqlDataReader readerR;
            try
            {
                commandR.Connection.Open();
                readerR = commandR.ExecuteReader();
                while (readerR.Read())
                {
                    textBox1.Text = Convert.ToString(readerR["tipnar"]);
                    //textBox2.Text = Convert.ToString(readerR["tipnarN"]);
                    comboBox1.Text = Convert.ToString(readerR["tipnarN"]);
                    if (Convert.ToInt32(readerR["ChastSt"])>0 && Convert.ToInt32(readerR["ChastSt"]) < 7 )
                    {
                        switch (Convert.ToInt32(readerR["ChastSt"]))
                        {
                            case 1:
                                TabNar[1,0]= Convert.ToString(readerR["tipnar"]);
                                TabNar[1, 1] = Convert.ToString(readerR["tipnarN"]);
                                TabNar[1, 2] = Convert.ToString(readerR["NoSRFor"]);
                                TabNar[1, 3] = Convert.ToString(readerR["NoSRTo"]);
                                TabNar[1, 4] = Convert.ToString(readerR["MitSRFor"]);
                                TabNar[1, 5] = Convert.ToString(readerR["MitSRTo"]);
                                TabNar[1, 6] = Convert.ToString(readerR["STATIA"]);
                                TabNar[1, 7] = Convert.ToString(readerR["vidnar"]);
                                TabNar[1, 8] = Convert.ToString(readerR["prmechannar"]);

                                textBox14.Text = Convert.ToString(readerR["NoSRFor"]);
                                textBox20.Text = Convert.ToString(readerR["NoSRTo"]);
                                textBox26.Text = Convert.ToString(readerR["MitSRFor"]);
                                textBox32.Text = Convert.ToString(readerR["MitSRTo"]);


                                break;
                            case 2:
                                TabNar[2, 0] = Convert.ToString(readerR["tipnar"]);
                                TabNar[2, 1] = Convert.ToString(readerR["tipnarN"]);
                                TabNar[2, 2] = Convert.ToString(readerR["NoSRFor"]);
                                TabNar[2, 3] = Convert.ToString(readerR["NoSRTo"]);
                                TabNar[2, 4] = Convert.ToString(readerR["MitSRFor"]);
                                TabNar[2, 5] = Convert.ToString(readerR["MitSRTo"]);
                                TabNar[2, 6] = Convert.ToString(readerR["STATIA"]);
                                TabNar[2, 7] = Convert.ToString(readerR["vidnar"]);
                                TabNar[2, 8] = Convert.ToString(readerR["prmechannar"]);

                                textBox13.Text = Convert.ToString(readerR["NoSRFor"]);
                                textBox19.Text = Convert.ToString(readerR["NoSRTo"]);
                                textBox25.Text = Convert.ToString(readerR["MitSRFor"]);
                                textBox31.Text = Convert.ToString(readerR["MitSRTo"]);

                                break;
                            case 3:
                                TabNar[3, 0] = Convert.ToString(readerR["tipnar"]);
                                TabNar[3, 1] = Convert.ToString(readerR["tipnarN"]);
                                TabNar[3, 2] = Convert.ToString(readerR["NoSRFor"]);
                                TabNar[3, 3] = Convert.ToString(readerR["NoSRTo"]);
                                TabNar[3, 4] = Convert.ToString(readerR["MitSRFor"]);
                                TabNar[3, 5] = Convert.ToString(readerR["MitSRTo"]);
                                TabNar[3, 6] = Convert.ToString(readerR["STATIA"]);
                                TabNar[3, 7] = Convert.ToString(readerR["vidnar"]);
                                TabNar[3, 8] = Convert.ToString(readerR["prmechannar"]);

                                textBox12.Text = Convert.ToString(readerR["NoSRFor"]);
                                textBox18.Text = Convert.ToString(readerR["NoSRTo"]);
                                textBox24.Text = Convert.ToString(readerR["MitSRFor"]);
                                textBox30.Text = Convert.ToString(readerR["MitSRTo"]);
                                break;
                            case 4:
                                TabNar[4, 0] = Convert.ToString(readerR["tipnar"]);
                                TabNar[4, 1] = Convert.ToString(readerR["tipnarN"]);
                                TabNar[4, 2] = Convert.ToString(readerR["NoSRFor"]);
                                TabNar[4, 3] = Convert.ToString(readerR["NoSRTo"]);
                                TabNar[4, 4] = Convert.ToString(readerR["MitSRFor"]);
                                TabNar[4, 5] = Convert.ToString(readerR["MitSRTo"]);
                                TabNar[4, 6] = Convert.ToString(readerR["STATIA"]);
                                TabNar[4, 7] = Convert.ToString(readerR["vidnar"]);
                                TabNar[4, 8] = Convert.ToString(readerR["prmechannar"]);

                                textBox11.Text = Convert.ToString(readerR["NoSRFor"]);
                                textBox17.Text = Convert.ToString(readerR["NoSRTo"]);
                                textBox23.Text = Convert.ToString(readerR["MitSRFor"]);
                                textBox29.Text = Convert.ToString(readerR["MitSRTo"]);
                                break;
                            case 5:
                                TabNar[5, 0] = Convert.ToString(readerR["tipnar"]);
                                TabNar[5, 1] = Convert.ToString(readerR["tipnarN"]);
                                TabNar[5, 2] = Convert.ToString(readerR["NoSRFor"]);
                                TabNar[5, 3] = Convert.ToString(readerR["NoSRTo"]);
                                TabNar[5, 4] = Convert.ToString(readerR["MitSRFor"]);
                                TabNar[5, 5] = Convert.ToString(readerR["MitSRTo"]);
                                TabNar[5, 6] = Convert.ToString(readerR["STATIA"]);
                                TabNar[5, 7] = Convert.ToString(readerR["vidnar"]);
                                TabNar[5, 8] = Convert.ToString(readerR["prmechannar"]);

                                textBox10.Text = Convert.ToString(readerR["NoSRFor"]);
                                textBox16.Text = Convert.ToString(readerR["NoSRTo"]);
                                textBox22.Text = Convert.ToString(readerR["MitSRFor"]);
                                textBox28.Text = Convert.ToString(readerR["MitSRTo"]);
                                break;
                            case 6:
                                TabNar[6, 0] = Convert.ToString(readerR["tipnar"]);
                                TabNar[6, 1] = Convert.ToString(readerR["tipnarN"]);
                                TabNar[6, 2] = Convert.ToString(readerR["NoSRFor"]);
                                TabNar[6, 3] = Convert.ToString(readerR["NoSRTo"]);
                                TabNar[6, 4] = Convert.ToString(readerR["MitSRFor"]);
                                TabNar[6, 5] = Convert.ToString(readerR["MitSRTo"]);
                                TabNar[6, 6] = Convert.ToString(readerR["STATIA"]);
                                TabNar[6, 7] = Convert.ToString(readerR["vidnar"]);
                                TabNar[6, 8] = Convert.ToString(readerR["prmechannar"]);

                                textBox9.Text = Convert.ToString(readerR["NoSRFor"]);
                                textBox15.Text = Convert.ToString(readerR["NoSRTo"]);
                                textBox21.Text = Convert.ToString(readerR["MitSRFor"]);
                                textBox27.Text = Convert.ToString(readerR["MitSRTo"]);
                                break;
                        }
                    }
                }
                readerR.Close();
                checkBox2.Enabled = false;
                checkBox3.Enabled = false;
                checkBox4.Enabled = false;
                checkBox5.Enabled = false;
                checkBox6.Enabled = false;
                checkBox7.Enabled = false;
                checkBox1.Checked = true;
                IDNAR = IDTS;
                //checkBox1.Enabled = false;
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

        internal void FormNARUSH_LoadV(int IDTS)

        {
            int i = 0;
            button1.Visible = false;
            button2.Visible = false;
            MySqlCommand commandR = new MySqlCommand();
            ConnectStr conStrR = new ConnectStr();
            conStrR.ConStr(1);
            Zapros zaprosR = new Zapros();
            string connectionStringR;//, commandString;
            connectionStringR = conStrR.StP;//"Data source=localhost;UserId=root;Password=1q2w3e$R;database=camloc;";
            MySqlConnection connectionR = new MySqlConnection(connectionStringR);
            zaprosR.Narush(IDTS);
            zR = zaprosR.commandStringTest;
            commandR.CommandText = zR;// commandString;
            commandR.Connection = connectionR;

            MySqlDataReader readerR;
            try
            {
                commandR.Connection.Open();
                readerR = commandR.ExecuteReader();
                while (readerR.Read())
                {
                    textBox1.Text = Convert.ToString(readerR["tipnar"]);
                    //textBox2.Text = Convert.ToString(readerR["tipnarN"]);
                    comboBox1.Text = Convert.ToString(readerR["tipnarN"]);
                    if (Convert.ToInt32(readerR["ChastSt"]) > 0 && Convert.ToInt32(readerR["ChastSt"]) < 7)
                    {
                        switch (Convert.ToInt32(readerR["ChastSt"]))
                        {
                            case 1:
                                TabNar[1, 0] = Convert.ToString(readerR["tipnar"]);
                                TabNar[1, 1] = Convert.ToString(readerR["tipnarN"]);
                                TabNar[1, 2] = Convert.ToString(readerR["NoSRFor"]);
                                TabNar[1, 3] = Convert.ToString(readerR["NoSRTo"]);
                                TabNar[1, 4] = Convert.ToString(readerR["MitSRFor"]);
                                TabNar[1, 5] = Convert.ToString(readerR["MitSRTo"]);
                                TabNar[1, 6] = Convert.ToString(readerR["STATIA"]);
                                TabNar[1, 7] = Convert.ToString(readerR["vidnar"]);
                                TabNar[1, 8] = Convert.ToString(readerR["prmechannar"]);

                                textBox14.Text = Convert.ToString(readerR["NoSRFor"]);
                                textBox20.Text = Convert.ToString(readerR["NoSRTo"]);
                                textBox26.Text = Convert.ToString(readerR["MitSRFor"]);
                                textBox32.Text = Convert.ToString(readerR["MitSRTo"]);


                                break;
                            case 2:
                                TabNar[2, 0] = Convert.ToString(readerR["tipnar"]);
                                TabNar[2, 1] = Convert.ToString(readerR["tipnarN"]);
                                TabNar[2, 2] = Convert.ToString(readerR["NoSRFor"]);
                                TabNar[2, 3] = Convert.ToString(readerR["NoSRTo"]);
                                TabNar[2, 4] = Convert.ToString(readerR["MitSRFor"]);
                                TabNar[2, 5] = Convert.ToString(readerR["MitSRTo"]);
                                TabNar[2, 6] = Convert.ToString(readerR["STATIA"]);
                                TabNar[2, 7] = Convert.ToString(readerR["vidnar"]);
                                TabNar[2, 8] = Convert.ToString(readerR["prmechannar"]);

                                textBox13.Text = Convert.ToString(readerR["NoSRFor"]);
                                textBox19.Text = Convert.ToString(readerR["NoSRTo"]);
                                textBox25.Text = Convert.ToString(readerR["MitSRFor"]);
                                textBox31.Text = Convert.ToString(readerR["MitSRTo"]);

                                break;
                            case 3:
                                TabNar[3, 0] = Convert.ToString(readerR["tipnar"]);
                                TabNar[3, 1] = Convert.ToString(readerR["tipnarN"]);
                                TabNar[3, 2] = Convert.ToString(readerR["NoSRFor"]);
                                TabNar[3, 3] = Convert.ToString(readerR["NoSRTo"]);
                                TabNar[3, 4] = Convert.ToString(readerR["MitSRFor"]);
                                TabNar[3, 5] = Convert.ToString(readerR["MitSRTo"]);
                                TabNar[3, 6] = Convert.ToString(readerR["STATIA"]);
                                TabNar[3, 7] = Convert.ToString(readerR["vidnar"]);
                                TabNar[3, 8] = Convert.ToString(readerR["prmechannar"]);

                                textBox12.Text = Convert.ToString(readerR["NoSRFor"]);
                                textBox18.Text = Convert.ToString(readerR["NoSRTo"]);
                                textBox24.Text = Convert.ToString(readerR["MitSRFor"]);
                                textBox30.Text = Convert.ToString(readerR["MitSRTo"]);
                                break;
                            case 4:
                                TabNar[4, 0] = Convert.ToString(readerR["tipnar"]);
                                TabNar[4, 1] = Convert.ToString(readerR["tipnarN"]);
                                TabNar[4, 2] = Convert.ToString(readerR["NoSRFor"]);
                                TabNar[4, 3] = Convert.ToString(readerR["NoSRTo"]);
                                TabNar[4, 4] = Convert.ToString(readerR["MitSRFor"]);
                                TabNar[4, 5] = Convert.ToString(readerR["MitSRTo"]);
                                TabNar[4, 6] = Convert.ToString(readerR["STATIA"]);
                                TabNar[4, 7] = Convert.ToString(readerR["vidnar"]);
                                TabNar[4, 8] = Convert.ToString(readerR["prmechannar"]);

                                textBox11.Text = Convert.ToString(readerR["NoSRFor"]);
                                textBox17.Text = Convert.ToString(readerR["NoSRTo"]);
                                textBox23.Text = Convert.ToString(readerR["MitSRFor"]);
                                textBox29.Text = Convert.ToString(readerR["MitSRTo"]);
                                break;
                            case 5:
                                TabNar[5, 0] = Convert.ToString(readerR["tipnar"]);
                                TabNar[5, 1] = Convert.ToString(readerR["tipnarN"]);
                                TabNar[5, 2] = Convert.ToString(readerR["NoSRFor"]);
                                TabNar[5, 3] = Convert.ToString(readerR["NoSRTo"]);
                                TabNar[5, 4] = Convert.ToString(readerR["MitSRFor"]);
                                TabNar[5, 5] = Convert.ToString(readerR["MitSRTo"]);
                                TabNar[5, 6] = Convert.ToString(readerR["STATIA"]);
                                TabNar[5, 7] = Convert.ToString(readerR["vidnar"]);
                                TabNar[5, 8] = Convert.ToString(readerR["prmechannar"]);

                                textBox10.Text = Convert.ToString(readerR["NoSRFor"]);
                                textBox16.Text = Convert.ToString(readerR["NoSRTo"]);
                                textBox22.Text = Convert.ToString(readerR["MitSRFor"]);
                                textBox28.Text = Convert.ToString(readerR["MitSRTo"]);
                                break;
                            case 6:
                                TabNar[6, 0] = Convert.ToString(readerR["tipnar"]);
                                TabNar[6, 1] = Convert.ToString(readerR["tipnarN"]);
                                TabNar[6, 2] = Convert.ToString(readerR["NoSRFor"]);
                                TabNar[6, 3] = Convert.ToString(readerR["NoSRTo"]);
                                TabNar[6, 4] = Convert.ToString(readerR["MitSRFor"]);
                                TabNar[6, 5] = Convert.ToString(readerR["MitSRTo"]);
                                TabNar[6, 6] = Convert.ToString(readerR["STATIA"]);
                                TabNar[6, 7] = Convert.ToString(readerR["vidnar"]);
                                TabNar[6, 8] = Convert.ToString(readerR["prmechannar"]);

                                textBox9.Text = Convert.ToString(readerR["NoSRFor"]);
                                textBox15.Text = Convert.ToString(readerR["NoSRTo"]);
                                textBox21.Text = Convert.ToString(readerR["MitSRFor"]);
                                textBox27.Text = Convert.ToString(readerR["MitSRTo"]);
                                break;
                        }
                    }
                }
                readerR.Close();
                checkBox2.Enabled = false;
                checkBox3.Enabled = false;
                checkBox4.Enabled = false;
                checkBox5.Enabled = false;
                checkBox6.Enabled = false;
                checkBox7.Enabled = false;
                checkBox1.Checked = true;
                IDNAR = IDTS;
                //checkBox1.Enabled = false;
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

        public void ZapomnVidNar()
        {
            NCh = 0;
            if (textBox14.Focused == true || textBox20.Focused == true || textBox26.Focused == true || textBox32.Focused == true || textBox3.Focused == true)
            { NCh = 1;}
            else if (textBox13.Focused == true || textBox19.Focused == true || textBox25.Focused == true || textBox31.Focused == true || textBox4.Focused == true)
            { NCh = 2; }
            else if(textBox12.Focused == true || textBox18.Focused == true || textBox24.Focused == true || textBox30.Focused == true || textBox5.Focused == true)
            { NCh = 3; }
            else if(textBox14.Focused == true || textBox17.Focused == true || textBox3.Focused == true || textBox29.Focused == true || textBox6.Focused == true)
            { NCh = 4; }
            else if(textBox10.Focused == true || textBox16.Focused == true || textBox22.Focused == true || textBox28.Focused == true || textBox7.Focused == true)
            { NCh = 5; }
            else if(textBox9.Focused == true || textBox15.Focused == true || textBox21.Focused == true || textBox27.Focused == true || textBox8.Focused == true)
            { NCh = 6; }
            //if (textBox14.Focused == true || textBox20.Focused == true || textBox26.Focused == true || textBox32.Focused == true || textBox3.Focused == true)
            //{ NCh = 1; }
        }

        private void FormNARUSH_MouseClick(object sender, MouseEventArgs e)
        {
            //ZapomnVidNar();
            //if (NCh>0)
            //{
            //    textBox1.Text = TabNar[NCh, 0];
            //    textBox2.Text = TabNar[NCh, 1];
            //    textBox33.Text = TabNar[NCh, 6];
            //    textBox34.Text = TabNar[NCh, 7];
            //    textBox35.Text = TabNar[NCh, 8];                    
            //}
        }

        private void textBox14_MouseClick(object sender, MouseEventArgs e)
        {
            //ZapomnVidNar();
            //if (NCh > 0)
            //{
            //    textBox1.Text = TabNar[NCh, 0];
            //    textBox2.Text = TabNar[NCh, 1];
            //    textBox33.Text = TabNar[NCh, 6];
            //    textBox34.Text = TabNar[NCh, 7];
            //    textBox35.Text = TabNar[NCh, 8];
            //}
        }

        private void comboBox1_MouseClick(object sender, MouseEventArgs e)
        {

            ConnectStr conStrComCOMBO = new ConnectStr();
            Zapros zaprosCom = new Zapros();
            conStrComCOMBO.ConStr(1);
            zaprosCom.COMBOKOMPL();
            cstr = conStrComCOMBO.StP;
            z = "SELECT " +
                "raptsprnar.tipnar AS TN, tipnarN " +
                "FROM raptsprnar " +
                "GROUP BY raptsprnar.tipnar";
            MySqlConnection connectionCOMBO = new MySqlConnection(cstr);
            mySqlDataAdapter = new MySqlDataAdapter(z, connectionCOMBO);
            DataSet DSCOMBO = new DataSet();
            mySqlDataAdapter.Fill(DSCOMBO);
            comboBox1.DataSource = DSCOMBO.Tables[0];
            comboBox1.DisplayMember = "tipnarN";
            comboBox1.ValueMember = "TN";
            connectionCOMBO.Close();
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
           
            textBox1.Text = comboBox1.SelectedValue.ToString();           
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex > -1)
            {
                textBox1.Text = comboBox1.SelectedValue.ToString();
            }
            else { textBox1.Text = ""; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = true;
            
                TabNar[1, 0] = textBox1.Text.ToString();
                TabNar[1, 1] = comboBox1.Text.ToString();
                TabNar[1, 2] = textBox14.Text.ToString();
                TabNar[1, 3] = textBox20.Text.ToString();
                TabNar[1, 4] = textBox26.Text.ToString();
                TabNar[1, 5] = textBox32.Text.ToString();
                TabNar[1, 6] = textBox33.Text.ToString();
                TabNar[1, 7] = textBox34.Text.ToString();
                TabNar[1, 8] = textBox35.Text.ToString();
                TabNar[1, 9] = textBox3.Text.ToString();

                TabNar[2, 0] = textBox1.Text.ToString();
                TabNar[2, 1] = comboBox1.Text.ToString();
                TabNar[2, 2] = textBox13.Text.ToString();
                TabNar[2, 3] = textBox19.Text.ToString();
                TabNar[2, 4] = textBox25.Text.ToString();
                TabNar[2, 5] = textBox31.Text.ToString();
                TabNar[2, 6] = textBox33.Text.ToString();
                TabNar[2, 7] = textBox34.Text.ToString();
                TabNar[2, 8] = textBox35.Text.ToString();
                TabNar[2, 9] = textBox4.Text.ToString();

                TabNar[3, 0] = textBox1.Text.ToString();
                TabNar[3, 1] = comboBox1.Text.ToString();
                TabNar[3, 2] = textBox12.Text.ToString();
                TabNar[3, 3] = textBox18.Text.ToString();
                TabNar[3, 4] = textBox24.Text.ToString();
                TabNar[3, 5] = textBox30.Text.ToString();
                TabNar[3, 6] = textBox33.Text.ToString();
                TabNar[3, 7] = textBox34.Text.ToString();
                TabNar[3, 8] = textBox35.Text.ToString();
                TabNar[3, 9] = textBox5.Text.ToString();

                TabNar[4, 0] = textBox1.Text.ToString();
                TabNar[4, 1] = comboBox1.Text.ToString();
                TabNar[4, 2] = textBox11.Text.ToString();
                TabNar[4, 3] = textBox17.Text.ToString();
                TabNar[4, 4] = textBox23.Text.ToString();
                TabNar[4, 5] = textBox29.Text.ToString();
                TabNar[4, 6] = textBox33.Text.ToString();
                TabNar[4, 7] = textBox34.Text.ToString();
                TabNar[4, 8] = textBox35.Text.ToString();
                TabNar[4, 9] = textBox6.Text.ToString();

                TabNar[5, 0] = textBox1.Text.ToString();
                TabNar[5, 1] = comboBox1.Text.ToString();
                TabNar[5, 2] = textBox10.Text.ToString();
                TabNar[5, 3] = textBox16.Text.ToString();
                TabNar[5, 4] = textBox22.Text.ToString();
                TabNar[5, 5] = textBox28.Text.ToString();
                TabNar[5, 6] = textBox33.Text.ToString();
                TabNar[5, 7] = textBox34.Text.ToString();
                TabNar[5, 8] = textBox35.Text.ToString();
                TabNar[5, 9] = textBox7.Text.ToString();

                TabNar[6, 0] = textBox1.Text.ToString();
                TabNar[6, 1] = comboBox1.Text.ToString();
                TabNar[6, 2] = textBox9.Text.ToString();
                TabNar[6, 3] = textBox15.Text.ToString();
                TabNar[6, 4] = textBox21.Text.ToString();
                TabNar[6, 5] = textBox27.Text.ToString();
                TabNar[6, 6] = textBox33.Text.ToString();
                TabNar[6, 7] = textBox34.Text.ToString();
                TabNar[6, 8] = textBox35.Text.ToString();
                TabNar[6, 9] = textBox8.Text.ToString();

                for (int i = 1; i < 7; i++)
                {
                    string stat = TabNar[i, 6] + " ч." + TabNar[i, 9];
                    string z = "UPDATE raptsprnar SET " +
           "tipnar = " + Convert.ToInt32(TabNar[i, 0]) + ", " +
           "tipnarN = '" + TabNar[i, 1] + "', " +
           "ChastSt = " + Convert.ToInt32(TabNar[i, 9]) + ", " +
           "NoSRFor = " + Convert.ToInt32(TabNar[i, 2]) + ", " +
           "NoSRTo = " + Convert.ToInt32(TabNar[i, 3]) + ", " +
           "MitSRFor = " + Convert.ToInt32(TabNar[i, 4]) + ", " +
           "MitSRTo = " + Convert.ToInt32(TabNar[i, 5]) + ", " +
           "STATIA = '" + stat + "', " +
           "vidnar = '" + TabNar[i, 7] + "', " +
           "prmechannar = '" + TabNar[i, 8] + "'" +
           "WHERE tipnar = " + IDNAR + " and ChastSt = " + Convert.ToInt32(TabNar[i, 9]) + ";";
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
