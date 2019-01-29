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
    public partial class SpetsRazrVKL : Form
    {
        public string rasp; public string AD; public string napr; public string nPol;
        public Boolean[] flagsSR;// = new Boolean[29];
        public string[] NaprSR;
        public SpetsRazrVKL()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormFiltrM_Shown(object sender, EventArgs e)
        {
            comboBox4.Text = NaprSR[0];// rasp;
            comboBox1.Text = NaprSR[1];//AD;
            comboBox2.Text = NaprSR[2];//NaprSR;
            comboBox3.Text = NaprSR[3];//nPol;
            if (flagsSR[0] == true)
            { dateTimePicker1.Value = Convert.ToDateTime(NaprSR[4]); }
            else
            { dateTimePicker1.Value = DateTime.Now; }
            if (flagsSR[1] == true)
            { dateTimePicker2.Value = Convert.ToDateTime(NaprSR[5]); }
            else
            { dateTimePicker2.Value = DateTime.Now; }
            //if (NaprSR[4] != "" && NaprSR[4] != null)
            //{
            //    dateTimePicker1.Value = Convert.ToDateTime(NaprSR[4]);
            //    dateTimePicker2.Value = Convert.ToDateTime(NaprSR[5]);
            //}
            //else
            //{
            //    dateTimePicker1.Value = DateTime.Now;
            //    dateTimePicker2.Value = DateTime.Now;
            //}
            textBox1.Text = NaprSR[6];
            textBox2.Text = NaprSR[7];
            textBox4.Text = NaprSR[8];
            textBox3.Text = NaprSR[9];
            textBox6.Text = NaprSR[10];
            textBox5.Text = NaprSR[11];
            textBox7.Text = NaprSR[12];
            if (flagsSR[3] == true)
            { dateTimePicker4.Value = Convert.ToDateTime(NaprSR[14]); }
            else
            { dateTimePicker4.Value = DateTime.Now; }
            if (flagsSR[4] == true)
            { dateTimePicker3.Value = Convert.ToDateTime(NaprSR[13]); }
            else
            { dateTimePicker3.Value = DateTime.Now; }
            //if (NaprSR[13] != "" && NaprSR[13] != null)
            //{
            //    dateTimePicker4.Value = Convert.ToDateTime(NaprSR[13]);
            //    dateTimePicker3.Value = Convert.ToDateTime(NaprSR[14]);
            //}
            //else
            //{
            //    dateTimePicker4.Value = DateTime.Now;
            //    dateTimePicker3.Value = DateTime.Now;
            //}
            checkBox1.Checked = flagsSR[0];
            checkBox2.Checked = flagsSR[1];
            checkBox3.Checked = flagsSR[3];
            checkBox4.Checked = flagsSR[4];
            checkBox8.Checked = flagsSR[5];
            checkBox7.Checked = flagsSR[6];
            checkBox6.Checked = flagsSR[7];
            checkBox5.Checked = flagsSR[8];
            checkBox12.Checked = flagsSR[9];
            checkBox11.Checked = flagsSR[10];
            checkBox10.Checked = flagsSR[11];
            checkBox9.Checked = flagsSR[12];
            checkBox20.Checked = flagsSR[13];
            checkBox19.Checked = flagsSR[14];
            checkBox18.Checked = flagsSR[15];
            checkBox17.Checked = flagsSR[16];
            checkBox16.Checked = flagsSR[17];
            //checkBox21.Checked = flagsSR[18];
            //checkBox15.Checked = flagsSR[19];
            //checkBox14.Checked = flagsSR[20];
            //checkBox13.Checked = flagsSR[21];
            //checkBox25.Checked = flagsSR[22];
            //checkBox24.Checked = flagsSR[23];
            //checkBox23.Checked = flagsSR[24];
            //checkBox22.Checked = flagsSR[25];
            //checkBox26.Checked = flagsSR[26];
            //checkBox28.Checked = flagsSR[27];
            //checkBox27.Checked = flagsSR[28];
        }

        private void button1_Click(object sender, EventArgs e)
        {

            NaprSR[0] = comboBox4.Text;//rasp ;
            NaprSR[1] = comboBox1.Text;//AD;
            NaprSR[2] = comboBox2.Text;//NaprSR;
            NaprSR[3] = comboBox3.Text;//nPol;

            
            //flagsSR[1] = checkBox2.Checked;
            //flagsSR[3] = checkBox3.Checked;
            //flagsSR[4] = checkBox4.Checked;
            flagsSR[5] = checkBox8.Checked;
            flagsSR[6] = checkBox7.Checked;
            flagsSR[7] = checkBox6.Checked;
            flagsSR[8] = checkBox5.Checked;
            flagsSR[9] = checkBox12.Checked;
            flagsSR[10] = checkBox11.Checked;
            flagsSR[11] = checkBox10.Checked;
            flagsSR[12] = checkBox9.Checked;
            flagsSR[13] = checkBox20.Checked;
            flagsSR[14] = checkBox19.Checked;
            flagsSR[15] = checkBox18.Checked;
            flagsSR[16] = checkBox17.Checked;
            flagsSR[17] = checkBox16.Checked;
            if (checkBox1.Checked==true)
            {
            flagsSR[0] = checkBox1.Checked;
            NaprSR[4] = dateTimePicker1.Value.ToString();
            }
            else { flagsSR[0] = false; NaprSR[4] = ""; }
            if (checkBox2.Checked == true)
            {
                flagsSR[1] = checkBox2.Checked;
                NaprSR[5] = dateTimePicker2.Value.ToString();
            }
            else { flagsSR[1] = false; NaprSR[5] = ""; }
            //NaprSR[5] = dateTimePicker2.Value.ToString();
            NaprSR[6] = textBox1.Text ;
            NaprSR[7] = textBox2.Text ;
            NaprSR[8] = textBox4.Text  ;
            NaprSR[9] = textBox3.Text;
            NaprSR[10] = textBox6.Text;
            NaprSR[11] = textBox5.Text;
            NaprSR[12] = textBox7.Text;
            if (checkBox3.Checked == true)
            {
                flagsSR[3] = checkBox3.Checked;
                NaprSR[14] = dateTimePicker4.Value.ToString();
            }
            else { flagsSR[3] = false; NaprSR[14] = ""; }
            if (checkBox4.Checked == true)
            {
                flagsSR[4] = checkBox4.Checked;
                NaprSR[13] = dateTimePicker3.Value.ToString();
            }
            else { flagsSR[4] = false; NaprSR[13] = ""; }
            //NaprSR[13] = dateTimePicker4.Value.ToString();
            //NaprSR[14] = dateTimePicker3.Value.ToString();

            //flagsSR[18] = checkBox21.Checked;
            //flagsSR[19] = checkBox15.Checked;
            //flagsSR[20] = checkBox14.Checked;
            //flagsSR[21] = checkBox13.Checked;
            //flagsSR[22] = checkBox25.Checked;
            //flagsSR[23] = checkBox24.Checked;
            //flagsSR[24] = checkBox23.Checked;
            //flagsSR[25] = checkBox22.Checked;
            //flagsSR[26] = checkBox26.Checked;
            //flagsSR[27] = checkBox28.Checked;
            //flagsSR[28] = checkBox27.Checked;

            //Form2 a = new Form2();
            //a.flagsSR = flagsSR; a.rasp = rasp; a.AD = AD; a.napr = napr; a.nPol = nPol;
            //a.Show();

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

        //private void checkBox28_CheckedChanged(object sender, EventArgs e)
        //{
        //    //if (checkBox28.Checked == true)
        //    //{ checkBox27.Checked = false; }
        //}

        //private void checkBox27_CheckedChanged(object sender, EventArgs e)
        //{
        //    //if (checkBox27.Checked == true)
        //    //{ checkBox28.Checked = false; }
        //}

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

        private void dateTimePicker1_MouseDown(object sender, MouseEventArgs e)
        {
            checkBox1.Checked = true;
        }

        private void dateTimePicker2_MouseDown(object sender, MouseEventArgs e)
        {
            checkBox2.Checked = true;
        }

        private void dateTimePicker4_MouseDown(object sender, MouseEventArgs e)
        {
            checkBox3.Checked = true;
        }

        private void dateTimePicker3_MouseDown(object sender, MouseEventArgs e)
        {
            checkBox4.Checked = true;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            textBox3.Text = textBox4.Text.ToString();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            textBox5.Text = textBox6.Text.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox2.Text = textBox1.Text.ToString();
        }

        //private void checkBox30_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (checkBox30.Checked == true)
        //    {
        //        checkBox1.Checked = true; checkBox2.Checked = true; checkBox3.Checked = true; checkBox4.Checked = true;
        //    }
        //    else
        //    {
        //        checkBox1.Checked = false; checkBox2.Checked = false; checkBox3.Checked = false; checkBox4.Checked = false;
        //    }
        //}

        //private void checkBox31_CheckedChanged(object sender, EventArgs e)
        //{
        //    //if (checkBox31.Checked == true)
        //    //{
        //    //    checkBox13.Checked = true; checkBox14.Checked = true; checkBox15.Checked = true; checkBox21.Checked = true;
        //    //}
        //    //else
        //    //{
        //    //    checkBox13.Checked = false; checkBox14.Checked = false; checkBox15.Checked = false; checkBox21.Checked = false;
        //    //}
        //}
    }
}
