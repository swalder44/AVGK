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
    public partial class FormStrPodkl : Form
    {
        public string TypeP = "";
        public string StrP = "";
        public string MySqlP = "";
        public string PostgreP = "";
        public string XMLP = "";

        public FormStrPodkl()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)///////////////   Кнопка закрытия формы
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e) //////////////   Кнопка сохранения добавления
        {if (alphaBlendTextBox2.Text != "")
            {
                MySql.Data.MySqlClient.MySqlConnection sqlConnectionT = new MySql.Data.MySqlClient.MySqlConnection("Data source = localhost; UserId = root; Password = 1q2w3e$R; database = test; ");
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
                cmd.CommandText = "INSERT raptpodkl (NamePodkl," +
                     "TypePodkl," +
                     "AdrServ," +
                     "NameUs," +
                     "PassPodkl," +
                     "PortPodkl," +
                     "NameBD," +
                     "strpodkl," +
                     "primpodkl " +
                     ") VALUES ('" + alphaBlendTextBox4.Text + "', " +
                     "'" + TypeP + "' , '" +
                     "" + alphaBlendTextBox5.Text + "' , '" +
                     "" + alphaBlendTextBox6.Text + "', '" +
                     "" + alphaBlendTextBox7.Text + "', " +
                     "" + Convert.ToInt32(alphaBlendTextBox8.Text) + ", '" +
                     "" + alphaBlendTextBox9.Text + "', '" +
                     "" + alphaBlendTextBox2.Text + "', '" +
                     "" + alphaBlendTextBox1.Text +
                     "')";
                cmd.Connection = sqlConnectionT;

                sqlConnectionT.Open();
                cmd.ExecuteNonQuery();
                sqlConnectionT.Close();
                Close();
            }
        else {
                MessageBox.Show("Операция не может быть завершена. \n Укажите тип подключения заново.. ", "ВНИМАНИЕ!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void alphaBlendTextBox5_TextChanged(object sender, EventArgs e)
        {
            MySqlP = "new MySql.Data.MySqlClient.MySqlConnection(\"server=" + alphaBlendTextBox5.Text + "; user="+ alphaBlendTextBox6.Text + ";password=" + alphaBlendTextBox7.Text + ";database=" + alphaBlendTextBox9.Text + ";port=" + alphaBlendTextBox8.Text + "; \")";
            PostgreP = "new NpgsqlConnection(\"Server=" + alphaBlendTextBox5.Text + ";Port=" + alphaBlendTextBox8.Text + ";Database=" + alphaBlendTextBox9.Text + ";User Id=" + alphaBlendTextBox6.Text + ";Password=" + alphaBlendTextBox7.Text + ";\")";
        }
        private void alphaBlendTextBox6_TextChanged(object sender, EventArgs e)
        {
            MySqlP = "new MySql.Data.MySqlClient.MySqlConnection(\"server=" + alphaBlendTextBox5.Text + "; user=" + alphaBlendTextBox6.Text + ";password=" + alphaBlendTextBox7.Text + ";database=" + alphaBlendTextBox9.Text + ";port=" + alphaBlendTextBox8.Text + "; \")";
            PostgreP = "new NpgsqlConnection(\"Server=" + alphaBlendTextBox5.Text + ";Port=" + alphaBlendTextBox8.Text + ";Database=" + alphaBlendTextBox9.Text + ";User Id=" + alphaBlendTextBox6.Text + ";Password=" + alphaBlendTextBox7.Text + ";\")";
        }
        private void alphaBlendTextBox7_TextChanged(object sender, EventArgs e)
        {
            MySqlP = "new MySql.Data.MySqlClient.MySqlConnection(\"server=" + alphaBlendTextBox5.Text + "; user=" + alphaBlendTextBox6.Text + ";password=" + alphaBlendTextBox7.Text + ";database=" + alphaBlendTextBox9.Text + ";port=" + alphaBlendTextBox8.Text + "; \")";
            PostgreP = "new NpgsqlConnection(\"Server=" + alphaBlendTextBox5.Text + ";Port=" + alphaBlendTextBox8.Text + ";Database=" + alphaBlendTextBox9.Text + ";User Id=" + alphaBlendTextBox6.Text + ";Password=" + alphaBlendTextBox7.Text + ";\")";
        }
        private void alphaBlendTextBox8_TextChanged(object sender, EventArgs e)
        {
            MySqlP = "new MySql.Data.MySqlClient.MySqlConnection(\"server=" + alphaBlendTextBox5.Text + "; user=" + alphaBlendTextBox6.Text + ";password=" + alphaBlendTextBox7.Text + ";database=" + alphaBlendTextBox9.Text + ";port=" + alphaBlendTextBox8.Text + "; \")";
            PostgreP = "new NpgsqlConnection(\"Server=" + alphaBlendTextBox5.Text + ";Port=" + alphaBlendTextBox8.Text + ";Database=" + alphaBlendTextBox9.Text + ";User Id=" + alphaBlendTextBox6.Text + ";Password=" + alphaBlendTextBox7.Text + ";\")";
        }
        private void alphaBlendTextBox9_TextChanged(object sender, EventArgs e)
        {
            MySqlP = "new MySql.Data.MySqlClient.MySqlConnection(\"server=" + alphaBlendTextBox5.Text + "; user=" + alphaBlendTextBox6.Text + ";password=" + alphaBlendTextBox7.Text + ";database=" + alphaBlendTextBox9.Text + ";port=" + alphaBlendTextBox8.Text + "; \")";
            PostgreP = "new NpgsqlConnection(\"Server=" + alphaBlendTextBox5.Text + ";Port=" + alphaBlendTextBox8.Text + ";Database=" + alphaBlendTextBox9.Text + ";User Id=" + alphaBlendTextBox6.Text + ";Password=" + alphaBlendTextBox7.Text + ";\")";
            //alphaBlendTextBox2.Refresh;
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            TypeP = "MySql";
            alphaBlendTextBox2.Text = MySqlP;
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            TypeP = "PostgreSql";
            alphaBlendTextBox2.Text = PostgreP;
        }

        private void radioButton3_Click(object sender, EventArgs e)
        {
            TypeP = "XML";
            alphaBlendTextBox2.Text = XMLP;
        }
    }
    }
//}
