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
using MySql.Data;
using System.Threading;



namespace AVGK
{
    public partial class Form1 : Form
    {
        #region Fields
        private string[] str;
        private bool flag;
        private int _logins;
        private int _countLogFailed;
        private bool _ValidForm;
        public int Us;
        private DataSet ds = new DataSet();
        private DataTable dt = new DataTable();
        public string cstrUs;
        public MySqlConnection connectionUs = new MySqlConnection();
        public string zUs;
        public string N1, N2; 

        #endregion

        public Form1()
        {
            InitializeComponent();
           
            /////////////////////////////////////////////////////////////////////////////////////////////////////////
            _countLogFailed = 0;
            _logins = 3;
            tbName.Validating += new CancelEventHandler(ValidateTextBox);
            tbPassword.Validating += new CancelEventHandler(ValidateTextBox);
            tbName.Text = "razrab";// "admin";
            tbPassword.Text = "*";// "admin";
        }
             
            #region Validating

            private void ValidateTextBox(object sender, CancelEventArgs e)
            {
                bool NameValid = true, PasswordValid = true;

            if (String.IsNullOrEmpty(((TextBox)sender).Text))
            {
                switch (Convert.ToByte(((TextBox)sender).Tag))
                {
                    case 0:
                        errorProvider1.SetError(tbName, "Необходимо указать логин");
                        NameValid = false;
                        break;
                    case 1:
                        errorProvider1.SetError(tbPassword, "Не могли бы Вы ввести пароль");
                        PasswordValid = false;
                        break;
                }
            }
            else
            {
                switch (Convert.ToByte(((TextBox)sender).Tag))
                {
                    case 0:
                        errorProvider1.SetError(tbName, "");
                        break;
                    case 1:
                        errorProvider1.SetError(tbPassword, "");
                        break;
                }
            }
            _ValidForm = NameValid && PasswordValid;
            }
            #endregion

        private void btnLogin_Click(object sender, EventArgs e)
        {

            str = new string[5];
            N1 = tbName.Text;
            N2 = tbPassword.Text;
            tbName.Validating += new CancelEventHandler(ValidateTextBox);
            tbPassword.Validating += new CancelEventHandler(ValidateTextBox);
            try
            {
                MySqlCommand commandLB = new MySqlCommand();
                ConnectStr conStrLB = new ConnectStr();
                conStrLB.ConStr(1);
                Zapros zaprosLB = new Zapros();
                string connectionStringLB;
                connectionStringLB = conStrLB.StP;;
                MySqlConnection connectionLB = new MySqlConnection(connectionStringLB);
                zaprosLB.ZaprUs(N1, N2);
                zUs = zaprosLB.commandStringTest;
                commandLB.CommandText = zUs;
                commandLB.Connection = connectionLB;
                MySqlDataReader readerLB;
                flag = false;
                try
                {
                    commandLB.Connection.Open();
                    readerLB = commandLB.ExecuteReader();
                    if (readerLB.Read())
                    {
                        flag = true;                    
                            Us = Convert.ToInt32(readerLB["iduser"].ToString());
                    }
                    readerLB.Close();
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Error: \r\n{0}", ex.ToString());
                }
                finally
                {
                    commandLB.Connection.Close();
                }                                                             
                if (flag == true)
                {
                    this.Cursor = Cursors.WaitCursor;
                    #region ОТКРЫТИЕ ОСНОВНОЙ ФОРМЫ
            
                    Program.Context.MainForm = new Form2(Us);
 
                    this.Close();
                 
                    //покажет вторую форму и оставит приложение живым до ее закрытия
                    Program.Context.MainForm.Show();
                    #endregion                  
                }
                else
                {
                    _countLogFailed++;
                    if (_countLogFailed > _logins - 1)
                    {
                        //You can do to close login form or do waiting user for instance 1 minute
                        MessageBox.Show("Вы ввели неправильные логин/пароль 3 раза. \n Новая попытка ввода возможна лишь через 1 минуту");
                        Thread.Sleep(60000);
                        _logins = 3;
                        _countLogFailed = 0;
                        tbPassword.Text = "";
                        tbName.Text = "";
                        MessageBox.Show("Попробуйте еще раз...");
                        return;                      
                    }
                    MessageBox.Show("Введен ошибочный логин или пароль. \n Пожалуйста попробуйте еще раз. \n Осталось попыток входа: "
                      + (_logins - _countLogFailed).ToString(), "Не удалось войти", MessageBoxButtons.OK);
                }                 
            }
            catch (Exception ex)
            {
                // Вывод сообщения об ошибке
                MessageBox.Show(ex.Message);
            }
            finally
            {
              
            }
        }              

        private void tbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            // Проверям нажата ли именно клавиша Enter            
            if (e.KeyCode == Keys.Enter)
            {
                // Вызываем обработчик события нажатия кнопки
                btnLogin_Click(this, EventArgs.Empty);              
            }
        }

        private void tbName_KeyDown(object sender, KeyEventArgs e)
        {
            // Проверям нажата ли именно клавиша Enter            
            if (e.KeyCode == Keys.Enter)
            {
                // Вызываем обработчик события нажатия кнопки
                btnLogin_Click(this, EventArgs.Empty);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
