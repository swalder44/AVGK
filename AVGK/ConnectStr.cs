using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AVGK
{
    public class ConnectStr
    {
        string server;
        string database ;
        string uid ;
        string password;
        //string connectionString; string connectionString1, commandString1;
        public string StP;
        public void ConStr(int Istr)
          {   if (Istr == 1)
            {
                server = "10.150.0.200";
                database = "test";
                uid = "vova";
                password = "1q2w3e4r%T";
                //server = "localhost";
                //database = "test";
                //uid = "root";
                //password = "1q2w3e$R";
                StP = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            }
          else {
                server = "192.168.1.140";
                database = "unicam_sensors";
                uid = "customer";
                password = "Ud5dg69s*Q";
                StP = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

                
               /*StP = "Фигу! /n Не будет вам подключения!!!"; */}
            //////connection = new MySqlConnection(ConnectStr.ConStr(comboBox4.Text));

            //////if (this.OpenConnection() == true)
            //////{
            //////    mySqlDataAdapter = new MySqlDataAdapter("SELECT * from `raptnapr`", connection);
            //////    DataSet DS = new DataSet();
            //////    mySqlDataAdapter.Fill(DS);
            //////    MessageBox.Show(StP);
        }
    }
}
