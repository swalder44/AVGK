using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace AVGK
{
    static class Program
    {
        public static ApplicationContext Context { get; set; }
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Context = new ApplicationContext(new Form1());
            Application.Run(Context);
            //Application.Run(new Form1());
        }

        ////////       //static void Main(string[] args)
        ////////       //{
        ////////           // строка подключения к БД
        ////////           string connStr = "server=192.168.1.140;user=customer;database=unicam_sensors;password=Ud5dg69s*Q;";
        ////////           // создаём объект для подключения к БД
        ////////           MySqlConnection conn = new MySqlConnection(connStr);
        ////////           // устанавливаем соединение с БД
        ////////           conn.Open();
        ////////           // запрос
        ////////           string sql = "SELECT " +
        ////////   "wims_detections.id," +
        ////////  " wims_detections.wim," +
        ////////  " wims_detections.datetime," +
        ////////  " wims_detections.lp," +
        ////////  " wims_detections.total_weight," +
        ////////  " wims_detections.velocity," +
        ////////  " wims_detections.trailer_presence," +
        ////////  " wims_detections.axle_1_leftside_load + wims_detections.axle_1_rightside_load AS expr1," +
        ////////  " wims_detections.axles_1_2_base / 100 AS expr20," +
        ////////  " LEFT(wims_detections.dual_tire, 1) AS expr2," +
        ////////  " wims_detections.axle_2_leftside_load + wims_detections.axle_2_rightside_load AS expr3," +
        ////////  " wims_detections.axles_2_3_base / 100 AS expr21," +
        ////////  " MID(wims_detections.dual_tire, 2, 1) AS expr4," +
        ////////  " wims_detections.axle_3_leftside_load + wims_detections.axle_3_rightside_load AS expr5," +
        ////////  " wims_detections.axle_4_leftside_load + wims_detections.axle_4_rightside_load AS expr6," +
        ////////  " wims_detections.axle_5_leftside_load + wims_detections.axle_5_rightside_load AS expr7," +
        ////////  " wims_detections.axle_6_leftside_load + wims_detections.axle_6_rightside_load AS expr8," +
        ////////  " wims_detections.axle_7_leftside_load + wims_detections.axle_7_rightside_load AS expr9," +
        ////////  " wims_detections.axle_8_leftside_load + wims_detections.axle_8_rightside_load AS expr10," +
        ////////  " wims_detections.axle_9_leftside_load + wims_detections.axle_9_rightside_load AS expr11," +
        ////////  " wims_detections.axles_3_4_base / 100 AS expr22," +
        ////////  " wims_detections.axles_4_5_base / 100 AS expr23," +
        ////////  " wims_detections.axles_5_6_base / 100 AS expr24," +
        ////////  " wims_detections.axles_6_7_base / 100 AS expr25," +
        ////////  " wims_detections.axles_7_8_base / 100 AS expr26," +
        ////////  " wims_detections.axles_8_9_base / 100 AS expr27," +
        ////////  " MID(wims_detections.dual_tire, 3, 1) AS expr12," +
        ////////  " MID(wims_detections.dual_tire, 4, 1) AS expr13," +
        ////////  " MID(wims_detections.dual_tire, 5, 1) AS expr14," +
        ////////  " MID(wims_detections.dual_tire, 6, 1) AS expr15," +
        ////////  " MID(wims_detections.dual_tire, 7, 1) AS expr16," +
        ////////  " MID(wims_detections.dual_tire, 8, 1) AS expr17," +
        ////////  " MID(wims_detections.dual_tire, 9, 1) AS expr18," +
        ////////  " wims_detections.length / 10 AS expr28," +
        ////////  " wims_detections.vehicle_class," +
        ////////  " wims_detections.vehicle_class AS expr19," +
        ////////  " wims_detections.s_length," +
        ////////  " wims_detections.s_height," +
        ////////  " wims_detections.s_width," +
        ////////  " wims_detections.validity," +
        ////////  " wims_detections.validity_flags," +
        ////////  " wims_detections.temp_internal," +
        ////////  " wims_detections.temp_asphalt," +
        ////////  " wims_detections.error_flags," +
        ////////  " wims_detections.axles_count," +
        ////////  " wims_detections.acceleration," +
        ////////  " wims_detections.overweighting," +
        ////////  " wims_detections.car_layout," +
        ////////  " wims_detections.dual_tire," +
        ////////  " wims_detections.overweight_desc," +
        ////////  " wims_detections.opposite_direction," +
        ////////  " wims_detections.wim_detector_id," +
        ////////  " wims_detections.detection_id," +
        ////////  " wims_detections.detection_image_id," +
        ////////  " wims_detections.detection_image_id_back" +
        ////////" FROM unicam_sensors.wims_detections" +
        ////////" WHERE unicam_sensors.wims_detections.id > 1386465";
        ////////           // объект для выполнения SQL-запроса
        ////////           MySqlCommand command = new MySqlCommand(sql, conn);
        ////////           // объект для чтения ответа сервера
        ////////           MySqlDataReader reader = command.ExecuteReader();
        ////////           // читаем результат
        ////////           while (reader.Read())
        ////////           {
        ////////               // элементы массива [] - это значения столбцов из запроса SELECT
        ////////               Console.WriteLine(reader[0].ToString() + " " + reader[1].ToString());
        ////////           }
        ////////           reader.Close(); // закрываем reader
        ////////           // закрываем соединение с БД
        ////////           conn.Close();
        ////////       }
        static class Data
        {
            public static string ValuePhoto { get; set; }
        }
    }
    }
