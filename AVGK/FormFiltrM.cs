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
    public partial class FormFiltrM : Form
    {
        public string rasp ; public string AD; public string napr; public string nPol;
        public Boolean[] flags;// = new Boolean[29];
        public string[] Napr;
        public FormFiltrM()
        {
            InitializeComponent();           
        }
       
        private void button3_Click(object sender, EventArgs e)
        {
            //Napr[0] = comboBox4.Text;//rasp ;
            //Napr[1] = comboBox1.Text;//AD;
            //Napr[2] = comboBox2.Text;//napr;
            //Napr[3] = comboBox3.Text;//nPol;

            //flags[0] = checkBox1.Checked;
            //flags[1] = checkBox2.Checked;
            //flags[3] = checkBox3.Checked;
            //flags[4] = checkBox4.Checked;
            //flags[5] = checkBox8.Checked;
            //flags[6] = checkBox7.Checked;
            //flags[7] = checkBox6.Checked;
            //flags[8] = checkBox5.Checked;
            //flags[9] = checkBox12.Checked;
            //flags[10] = checkBox11.Checked;
            //flags[11] = checkBox10.Checked;
            //flags[12] = checkBox9.Checked;
            //flags[13] = checkBox20.Checked;
            //flags[14] = checkBox19.Checked;
            //flags[15] = checkBox18.Checked;
            //flags[16] = checkBox17.Checked;
            //flags[17] = checkBox16.Checked;
            //flags[18] = checkBox21.Checked;
            //flags[19] = checkBox15.Checked;
            //flags[20] = checkBox14.Checked;
            //flags[21] = checkBox13.Checked;
            //flags[22] = checkBox25.Checked;
            //flags[23] = checkBox24.Checked;
            //flags[24] = checkBox23.Checked;
            //flags[25] = checkBox22.Checked;
            //flags[26] = checkBox26.Checked;
            //flags[27] = checkBox28.Checked;
            //flags[28] = checkBox27.Checked;

            //flags[29] = checkBox45.Checked;
            //flags[30] = checkBox44.Checked;
            //flags[31] = checkBox43.Checked;
            //flags[32] = checkBox42.Checked;
            //flags[33] = checkBox41.Checked;
            //flags[34] = checkBox40.Checked;
            //flags[35] = checkBox39.Checked;
            //flags[36] = checkBox38.Checked;
            //flags[37] = checkBox49.Checked;
            //flags[38] = checkBox48.Checked;
            //flags[39] = checkBox47.Checked;
            //flags[40] = checkBox46.Checked;
            //flags[41] = checkBox37.Checked;
            //flags[42] = checkBox36.Checked;
            //flags[43] = checkBox35.Checked;
            //flags[44] = checkBox34.Checked;
            //flags[45] = checkBox67.Checked;
            //flags[46] = checkBox64.Checked;
            //flags[47] = checkBox61.Checked;
            //flags[48] = checkBox66.Checked;
            //flags[49] = checkBox58.Checked;
            //flags[50] = checkBox55.Checked;
            //flags[51] = checkBox52.Checked;
            //flags[52] = checkBox57.Checked;
            //flags[53] = checkBox54.Checked;

            this.Close();
        }

        private void FormFiltrM_Shown(object sender, EventArgs e)
        {
            comboBox4.Text = Napr[0];// rasp;
            comboBox1.Text = Napr[1];//AD;
            comboBox2.Text = Napr[2];//napr;
            comboBox3.Text = Napr[3];//nPol;
            checkBox1.Checked = flags[0];
            checkBox2.Checked = flags[1];
            checkBox3.Checked = flags[3];
            checkBox4.Checked = flags[4];
            checkBox8.Checked = flags[5];
            checkBox7.Checked = flags[6];
            checkBox6.Checked = flags[7];
            checkBox5.Checked = flags[8];
            checkBox12.Checked = flags[9];
            checkBox11.Checked = flags[10];
            checkBox10.Checked = flags[11];
            checkBox9.Checked = flags[12];
            checkBox20.Checked = flags[13];
            checkBox19.Checked = flags[14];
            checkBox18.Checked = flags[15];
            checkBox17.Checked = flags[16];
            checkBox16.Checked = flags[17];
            checkBox21.Checked = flags[18];
            checkBox15.Checked = flags[19];
            checkBox14.Checked = flags[20];
            checkBox13.Checked = flags[21];
            checkBox25.Checked = flags[22];
            checkBox24.Checked = flags[23];
            checkBox23.Checked = flags[24];
            checkBox22.Checked = flags[25];
            checkBox26.Checked = flags[26];
            checkBox28.Checked = flags[27];
            checkBox27.Checked = flags[28];

            checkBox45.Checked = flags[29];
            checkBox44.Checked = flags[30];
            checkBox43.Checked = flags[31];
            checkBox42.Checked = flags[32];
            checkBox41.Checked = flags[33];
            checkBox40.Checked = flags[34];
            checkBox39.Checked = flags[35];
            checkBox38.Checked = flags[36];
            checkBox49.Checked = flags[37];
            checkBox48.Checked = flags[38];
            checkBox47.Checked = flags[39];
            checkBox46.Checked = flags[40];
            checkBox37.Checked = flags[41];
            checkBox36.Checked = flags[42];
            checkBox35.Checked = flags[43];
            checkBox34.Checked = flags[44];
            checkBox67.Checked = flags[45];
            checkBox64.Checked = flags[46];
            checkBox61.Checked = flags[47];
            checkBox66.Checked = flags[48];
            checkBox58.Checked = flags[49];
            checkBox55.Checked = flags[50];
            checkBox52.Checked = flags[51];
            checkBox57.Checked = flags[52];
            checkBox54.Checked = flags[53];
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Napr[0] = comboBox4.Text;//rasp ;
            Napr[1] = comboBox1.Text;//AD;
            Napr[2] = comboBox2.Text;//napr;
            Napr[3] = comboBox3.Text;//nPol;

            flags[0] = checkBox1.Checked;
            flags[1] = checkBox2.Checked;
            flags[3] = checkBox3.Checked;
            flags[4] = checkBox4.Checked;
            flags[5] = checkBox8.Checked;
            flags[6] = checkBox7.Checked;
            flags[7] = checkBox6.Checked;
            flags[8] = checkBox5.Checked;
            flags[9] = checkBox12.Checked;
            flags[10] = checkBox11.Checked;
            flags[11] = checkBox10.Checked;
            flags[12] = checkBox9.Checked;
            flags[13] = checkBox20.Checked;
            flags[14] = checkBox19.Checked;
            flags[15] = checkBox18.Checked;
            flags[16] = checkBox17.Checked;
            flags[17] = checkBox16.Checked;
            flags[18] = checkBox21.Checked;
            flags[19] = checkBox15.Checked;
            flags[20] = checkBox14.Checked;
            flags[21] = checkBox13.Checked;
            flags[22] = checkBox25.Checked;
            flags[23] = checkBox24.Checked;
            flags[24] = checkBox23.Checked;
            flags[25] = checkBox22.Checked;
            flags[26] = checkBox26.Checked;
            flags[27] = checkBox28.Checked;
            flags[28] = checkBox27.Checked;

          flags[29] = checkBox45.Checked  ;
          flags[30] = checkBox44.Checked  ;
          flags[31] = checkBox43.Checked  ;
          flags[32] = checkBox42.Checked  ;
          flags[33] = checkBox41.Checked  ;
          flags[34] = checkBox40.Checked  ;
          flags[35] = checkBox39.Checked  ;
          flags[36] = checkBox38.Checked  ;
          flags[37] = checkBox49.Checked  ;
          flags[38] = checkBox48.Checked  ;
          flags[39] = checkBox47.Checked  ;
          flags[40] = checkBox46.Checked  ;
          flags[41] = checkBox37.Checked  ;
          flags[42] = checkBox36.Checked  ;
          flags[43] = checkBox35.Checked  ;
          flags[44] = checkBox34.Checked  ;
          flags[45] = checkBox67.Checked  ;
          flags[46] = checkBox64.Checked  ;
          flags[47] = checkBox61.Checked  ;
          flags[48] = checkBox66.Checked  ;
          flags[49] = checkBox58.Checked  ;
          flags[50] = checkBox55.Checked  ;
          flags[51] = checkBox52.Checked  ;
          flags[52] = checkBox57.Checked  ;
          flags[53] = checkBox54.Checked  ;

            this.Close();
        }

        private void comboBox4_TextChanged(object sender, EventArgs e)
        {
            if (comboBox4.Text == "Все")
            { comboBox1.Text = "Все"; }
            else if (comboBox4.Text == "РК-1")
            { comboBox1.Text = "67-ОП-РЗ-67Р-01"; }
            else if (comboBox4.Text == "РК-2")
            { comboBox1.Text = "67-ОП-РЗ-67К-14"; }
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Все")
            { comboBox4.Text = "Все"; }
            else if (comboBox1.Text == "67-ОП-РЗ-67Р-01")
            { comboBox4.Text = "РК-1"; }
            else if (comboBox1.Text == "67-ОП-РЗ-67К-14")
            { comboBox4.Text = "РК-2"; }
        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "Все")
            { comboBox3.Text = "Все"; }
            else if (comboBox2.Text == "из Севастополя")
            { comboBox3.Text = "2"; }
            else if (comboBox2.Text == "в Севастополь")
            { comboBox3.Text = "1"; }
          
        }

        private void comboBox3_TextChanged(object sender, EventArgs e)
        {
            if (comboBox3.Text == "Все")
            { comboBox2.Text = "Все"; }
            else if (comboBox3.Text == "2")
            { comboBox2.Text = "из Севастополя"; }
            else if (comboBox3.Text == "1")
            { comboBox2.Text = "в Севастополь"; }

        }

        private void checkBox28_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox28.Checked==true)
            { checkBox27.Checked = false; }
        }

        private void checkBox27_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox27.Checked == true)
            { checkBox28.Checked = false; }
        }

        private void checkBox29_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox29.Checked == true)
            {
                checkBox5.Checked = true; checkBox6.Checked = true; checkBox7.Checked = true; checkBox8.Checked = true; checkBox9.Checked = true;
                checkBox10.Checked = true; checkBox11.Checked = true; checkBox12.Checked = true; checkBox16.Checked = true; checkBox17.Checked = true;
                checkBox18.Checked = true; checkBox19.Checked = true; checkBox20.Checked = true;
            }
            else
            {
                checkBox5.Checked = false; checkBox6.Checked = false; checkBox7.Checked = false; checkBox8.Checked = false; checkBox9.Checked = false;
                checkBox10.Checked = false; checkBox11.Checked = false; checkBox12.Checked = false; checkBox16.Checked = false; checkBox17.Checked = false;
                checkBox18.Checked = false; checkBox19.Checked = false; checkBox20.Checked = false;
            }
        }

        private void checkBox30_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox30.Checked == true)
            {
                checkBox1.Checked = true; checkBox2.Checked = true; checkBox3.Checked = true; checkBox4.Checked = true;
            }
            else
            {
                checkBox1.Checked = false; checkBox2.Checked = false; checkBox3.Checked = false; checkBox4.Checked = false;
            }
        }

        private void checkBox31_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox31.Checked == true)
            {
                checkBox13.Checked = true; checkBox14.Checked = true; checkBox15.Checked = true; checkBox21.Checked = true;
            }
            else
            {
                checkBox13.Checked = false; checkBox14.Checked = false; checkBox15.Checked = false; checkBox21.Checked = false;
            }
        }

        private void checkBox32_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox32.Checked == true)
            {
                checkBox45.Checked = true; checkBox44.Checked = true; checkBox43.Checked = true; checkBox42.Checked = true;
                checkBox41.Checked = true; checkBox40.Checked = true; checkBox39.Checked = true; checkBox38.Checked = true;
            }
            else
            {
                checkBox45.Checked = false; checkBox44.Checked = false; checkBox43.Checked = false; checkBox42.Checked = false;
                checkBox41.Checked = false; checkBox40.Checked = false; checkBox39.Checked = false; checkBox38.Checked = false;
            }
        }

        private void checkBox33_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox33.Checked == true)
            {
                checkBox49.Checked = true; checkBox48.Checked = true; checkBox47.Checked = true; checkBox46.Checked = true;
                checkBox37.Checked = true; checkBox36.Checked = true; checkBox35.Checked = true; checkBox34.Checked = true;
            }
            else
            {
                checkBox49.Checked = false; checkBox48.Checked = false; checkBox47.Checked = false; checkBox46.Checked = false;
                checkBox37.Checked = false; checkBox36.Checked = false; checkBox35.Checked = false; checkBox34.Checked = false;
            }
        }

        private void checkBox59_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox59.Checked == true)
            {
                checkBox67.Checked = true; checkBox64.Checked = true; checkBox61.Checked = true; checkBox66.Checked = true;               
            }
            else
            {
                checkBox67.Checked = false; checkBox64.Checked = false; checkBox61.Checked = false; checkBox66.Checked = false;
            }
        }

        private void checkBox50_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox50.Checked == true)
            {
                checkBox58.Checked = true; checkBox55.Checked = true; checkBox52.Checked = true; checkBox57.Checked = true; checkBox54.Checked = true;
            }
            else
            {
                checkBox58.Checked = false; checkBox55.Checked = false; checkBox52.Checked = false; checkBox57.Checked = false; checkBox54.Checked = false;
            }
        }
    }
}
