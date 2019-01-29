using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using PZone.Samples;
using System.Drawing;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

namespace AVGK
{
    class AKT_PDF_New
    {
            //Stream ii1 = null;
            public iTextSharp.text.Image imag;
            public iTextSharp.text.Image imag2;
            public iTextSharp.text.Image imag3;
            public string pf;
            public string[] Puti = { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
            string pdfFile;

        void delete_fields(int[,] KNRA, string[] args, int IDField, int CountFields)
        {
            int i;
            bool flag;
            int j;
            int k;
            string Name_field;
            string CheckField;

            j = 0;
            i = 0;
            Name_field = "";
            while(i < CountFields)
            {
                if (KNRA[0, j] == i)
                {
                    Name_field = "A" + IDField.ToString() + KNRA[0, j].ToString() + KNRA[1, j].ToString();
                    j++;
                }
               CheckField = "A" + IDField.ToString() + KNRA[0, j].ToString() + i.ToString();
             //  if (CheckField == Name_field)
                  //  form.SetField(CheckField, args[41 + i]);
              // else
                 //   form.RemoveField(CheckField);
               i++;
            }
        }
            public void FormPDFN(Bitmap i1, Bitmap i2, Bitmap i3, string[] args, string NRUB, string GAng, int[,] KNRA)//Bitmap i1, Bitmap i2, Bitmap i3, string[] args, string NRUB, string N1, string N2, string N3)//public void FormPDF(System.IO.Stream i1, System.IO.Stream i2, System.IO.Stream i3, string[] args)
        {

                Puti[19] = System.Windows.Forms.SystemInformation.ComputerName.ToString();
                MySqlCommand command2 = new MySqlCommand();
                ConnectStr conStr2 = new ConnectStr();
                conStr2.ConStr(1);
                Zapros zapros2 = new Zapros();
                string connectionString2;//, commandString;
                connectionString2 = conStr2.StP;//"Data source=localhost;UserId=root;Password=1q2w3e$R;database=camloc;";
                MySqlConnection connection2 = new MySqlConnection(connectionString2);
                zapros2.NastrPuti(0, Puti[19]);
                string z2 = zapros2.commandStringTest;
                command2.CommandText = z2;
                command2.Connection = connection2;
                MySqlDataReader reader2;
                try
                {
                    command2.Connection.Open();
                    reader2 = command2.ExecuteReader();
                    while (reader2.Read())
                    {
                        Puti[0] = reader2["IDPut"].ToString();
                        Puti[1] = reader2["Rab_mesto"].ToString();
                        Puti[2] = reader2["Photo"].ToString();
                        Puti[3] = reader2["XML_Ang"].ToString();
                        Puti[4] = reader2["Akt_Arch"].ToString();
                        Puti[5] = reader2["CompName"].ToString();
                    }

                    reader2.Close();
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Error: \r\n{0}", ex.ToString());
                }
                finally
                {
                    command2.Connection.Close();
                }


                String dir = Environment.CurrentDirectory;//получаем текущую рабочую папку приложения
                String dir1 = Application.StartupPath;//получаем папку из которой произошел запуск приложения
            var pdfTemplate = @"" + dir1 + "\\AKT.pdf";
            if (Puti[5] == "WIN-D3J6PR1H9QK")
            { pdfFile = @"F:\\archiv\\AKT\\" + GAng + ".pdf"; }//args[259] + "_" + DateTime.Now.ToString("ddMMyyyy") + ".pdf"; 
            else { pdfFile = @"" + Puti[3] + GAng + ".pdf"; };
            pf = GAng;//args[259] + "_" + DateTime.Now.ToString("ddMMyyyy");
            using (var templateReader = new PdfReader(pdfTemplate))

            {
                    if (i1 != null)
                    {
                    System.Drawing.Bitmap imgg = new System.Drawing.Bitmap(i1);
                    imag = iTextSharp.text.Image.GetInstance(imgg, System.Drawing.Imaging.ImageFormat.Jpeg);// @"C:\Users\cherednikov\Pictures\original22.jpg");
                    if (Puti[5] == "WIN-D3J6PR1H9QK")
                    { imgg.Save(@"F:\\archiv\\AKT\\" + args[259] + "_" + DateTime.Now.ToString("ddMMyyyy") + "_1.Jpg"); }
                    else
                    {
                        imgg.Save(@"" + Puti[3] + args[259] + "_" + DateTime.Now.ToString("ddMMyyyy") + "_1.Jpg");

                        //File.Copy(@"" + N1, @"" + Puti[3] + args[259] + "_" + DateTime.Now.ToString("ddMMyyyy") + "_1.png");
                    };

                }
                    if (i2 != null)
                    {
                    System.Drawing.Bitmap imgg2 = new System.Drawing.Bitmap(i2);
                    imag2 = iTextSharp.text.Image.GetInstance(imgg2, System.Drawing.Imaging.ImageFormat.Jpeg);
                    if (Puti[5] == "WIN-D3J6PR1H9QK")
                    { imgg2.Save(@"F:\\archiv\\AKT\\" + args[259] + "_" + DateTime.Now.ToString("ddMMyyyy") + "_2.Jpg"); }
                    else
                    {
                        imgg2.Save(@"" + Puti[3] + args[259] + "_" + DateTime.Now.ToString("ddMMyyyy") + "_2.Jpg");
                        //File.Copy(@"" + N2, @"" + Puti[3] + args[259] + "_" + DateTime.Now.ToString("ddMMyyyy") + "_2.png");
                    };
                }
                    if (i3 != null)
                    {
                    System.Drawing.Bitmap imgg3 = new System.Drawing.Bitmap(i3);
                    imag3 = iTextSharp.text.Image.GetInstance(imgg3, System.Drawing.Imaging.ImageFormat.Jpeg);
                    if (Puti[5] == "WIN-D3J6PR1H9QK")
                    { imgg3.Save(@"F:\\archiv\\AKT\\" + args[259] + "_" + DateTime.Now.ToString("ddMMyyyy") + "_3.Jpg"); }
                    else
                    {
                        imgg3.Save(@"" + Puti[3] + args[259] + "_" + DateTime.Now.ToString("ddMMyyyy") + "_3.Jpg");
                        //File.Copy(@"" + N3, @"" + Puti[3] + args[259] + "_" + DateTime.Now.ToString("ddMMyyyy") + "_3.png");
                    };
                }
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    ////////////var doc = new Document();
                    ////////////PdfWriter.GetInstance(doc, new FileStream(Application.StartupPath + @"\Document.pdf", FileMode.Create));
                    ////////////doc.Open();
                    ////////////iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(Application.StartupPath + @"/images.jpg");
                    ////////////jpg.Alignment = Element.ALIGN_CENTER;
                    ////////////doc.Add(jpg);
                    ////////////PdfPTable table = new PdfPTable(3);
                    ////////////PdfPCell cell = new PdfPCell(new Phrase("Simple table",
                    ////////////  new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 16,
                    ////////////  iTextSharp.text.Font.NORMAL, new BaseColor(Color.Orange))));
                    ////////////cell.BackgroundColor = new BaseColor(Color.Wheat);
                    ////////////cell.Padding = 5;
                    ////////////cell.Colspan = 3;
                    ////////////cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    ////////////table.AddCell(cell);
                    ////////////table.AddCell("Col 1 Row 1");
                    ////////////table.AddCell("Col 2 Row 1");
                    ////////////table.AddCell("Col 3 Row 1");
                    ////////////table.AddCell("Col 1 Row 2");
                    ////////////table.AddCell("Col 2 Row 2");
                    ////////////table.AddCell("Col 3 Row 2");
                    ////////////jpg = iTextSharp.text.Image.GetInstance(Application.StartupPath + @"/left.jpg");
                    ////////////cell = new PdfPCell(jpg);
                    ////////////cell.Padding = 5;
                    ////////////cell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                    ////////////table.AddCell(cell);
                    ////////////cell = new PdfPCell(new Phrase("Col 2 Row 3"));
                    ////////////cell.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                    ////////////cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    ////////////table.AddCell(cell);
                    ////////////jpg = iTextSharp.text.Image.GetInstance(Application.StartupPath + @"/right.jpg");
                    ////////////cell = new PdfPCell(jpg);
                    ////////////cell.Padding = 5;
                    ////////////cell.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                    ////////////table.AddCell(cell);
                    ////////////doc.Add(table);
                    ////////////doc.Close();



                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    using (var resultStamper = new PdfStamper(templateReader, new FileStream(pdfFile, FileMode.Create)))
                    {
                        var pdfcontentbyte = resultStamper.GetOverContent(1);
                        if (i1 != null)
                        {
                            imag.SetAbsolutePosition(55, 369);//695
                            imag.ScaleAbsoluteWidth(127);
                            imag.ScaleAbsoluteHeight(90);
                            imag.Alignment = Element.ALIGN_CENTER;
                            pdfcontentbyte.AddImage(imag);
                        }
                        if (i2 != null)
                        {
                            imag2.SetAbsolutePosition(230, 417); //745
                            imag2.ScaleAbsoluteWidth(137);
                            imag2.ScaleAbsoluteHeight(40);
                            imag2.Alignment = Element.ALIGN_CENTER;
                            pdfcontentbyte.AddImage(imag2);
                        }
                        if (i3 != null)
                        {
                            imag3.SetAbsolutePosition(404, 369); //696
                            imag3.ScaleAbsoluteWidth(146);
                            imag3.ScaleAbsoluteHeight(89);
                            imag3.Alignment = Element.ALIGN_CENTER;
                            pdfcontentbyte.AddImage(imag3);
                        }
                        PdfPTable table = new PdfPTable(14);

                        table.AddCell("Cell 1");
                        table.AddCell("Cell 2");
                        table.AddCell("Cell 3");
                        table.AddCell("Cell 4");
                        table.AddCell("Cell 5");
                        table.AddCell("Cell 6");
                        table.AddCell("Cell 7");
                        table.AddCell("Cell 8");

                        // Получаем ссылку на форму с полями.
                        var form = resultStamper.AcroFields;
                        // Получаем все шрифты формы.
                        //BaseFont baseFont = BaseFont.CreateFont(@"C:\Users\cherednikov\Desktop\WFPDF\WFPDF\calibri.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                        //iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL);
                        var font = templateReader.GetFormFonts();

                    // Установка значений полей формы.
                    // Установка значений полей формы.
                    form.SetFieldWithFont(templateReader, font, "A1", args[0]);
                    form.SetFieldWithFont(templateReader, font, "A3", args[1]); form.SetFieldWithFont(templateReader, font, "A4", args[2]);
                    form.SetFieldWithFont(templateReader, font, "A5", args[3]); form.SetFieldWithFont(templateReader, font, "A6", args[4]);
                    form.SetField("A2", args[250]); form.SetField("A9", args[5] + ", " + args[6]); form.SetField("A7", args[7]); form.SetField("A8", args[8]);
                    form.SetField("A10", args[9]);form.SetField("A11", args[21]); form.SetField("A12", args[10]); form.SetField("A13", "ДТ и РДТИ г. Севастополя");// args[11]);
                    form.SetField("A14", args[25]); form.SetField("A15", args[26]);form.SetField("A16", args[28]);form.SetField("A17", args[27]);form.SetField("A19", args[29]);
                    form.SetField("A20", args[41]); form.SetField("A21", args[42]); form.SetField("A22", args[43]); form.SetField("A18", "-");
                    /*ОБЩ_МАССА*/form.SetField("A23", args[65]); form.SetField("A24", args[66]);form.SetField("A25", args[67]); form.SetField("A26", args[68]); form.SetField("A27", args[69]);
                    form.SetField("A28", args[70]); 
                    /*ДЛИНА*/form.SetField("A29", args[44]);form.SetField("A30", args[47]);form.SetField("A31", args[50]); form.SetField("A32", args[53]);form.SetField("A33", args[56]); 
                    /*form.SetField("A55", args[59])*/;form.SetField("A34", args[62]);  
                    /*ШИРИНА*/form.SetField("A35", args[45]);form.SetField("A36", args[48]);form.SetField("A37", args[51]);form.SetField("A38", args[54]);form.SetField("A39", args[57]);
                    /*form.SetField("A56", args[60])*/;form.SetField("A40", args[63]);
                    /*ВЫСОТА*/form.SetField("A41", args[46]); form.SetField("A42", args[49]);form.SetField("A43", args[52]);form.SetField("A44", args[55]);form.SetField("A45", args[58]);
                    /*form.SetField("A57", args[61]);*/form.SetField("A46", args[64]);
                    /*СКАТНОСТЬ_КОЛ_КОЛЕС*/form.SetField("A47", args[73]); form.SetField("A48", args[84]);form.SetField("A49", args[95]); form.SetField("A50", args[106]);
                    form.SetField("A51", args[117]);form.SetField("A52", args[128]);form.SetField("A53", args[139]);form.SetField("A54", args[150]);form.SetField("A55", args[161]);
                    /*СКАТНОСТ_КОЛ_КОЛЕС_ПО_СПЕЦ_РАЗР*/
                    if (args[73] != null) { form.SetField("A56", "-"); }
                    if (args[84] != null) { form.SetField("A57", "-"); }
                    if (args[95] != null) { form.SetField("A58", "-"); }
                    if (args[106] != null) { form.SetField("A59", "-"); }
                    if (args[117] != null) { form.SetField("A60", "-"); }
                    if (args[128] != null) { form.SetField("A61", "-"); }
                    if (args[139] != null) { form.SetField("A62", "-"); }
                    if (args[150] != null) { form.SetField("A63", "-"); }
                    if (args[161] != null) { form.SetField("A64", "-"); }
                    //МЕЖОСЕВЫЕ 
                    if (args[86] != null)  { form.SetField("A65", "+ 0.03"); }
                    if (args[97] != null)  { form.SetField("A66", "+ 0.03"); }
                    if (args[108] != null)  { form.SetField("A67", "+ 0.03"); }
                    if (args[119] != null)  { form.SetField("A68", "+ 0.03");}
                    if (args[130] != null)  { form.SetField("A69", "+ 0.03"); }
                    if (args[141] != null)  { form.SetField("A70", "+ 0.03"); }
                    if (args[152] != null)  { form.SetField("A71", "+ 0.03"); }
                    if (args[163] != null)  { form.SetField("A72", "+ 0.03"); }

                    form.SetField("A73", args[86]);form.SetField("A74", args[97]);form.SetField("A75", args[108]);form.SetField("A76", args[119]);form.SetField("A77", args[130]);form.SetField("A78", args[141]);
form.SetField("A79", args[152]);form.SetField("A80", args[163]);
                    
                    form.SetField("A81", args[87]);form.SetField("A82", args[98]);form.SetField("A83", args[109]);form.SetField("A84", args[120]);form.SetField("A85", args[131]);
form.SetField("A86", args[142]);form.SetField("A87", args[153]); form.SetField("A88", args[164]);

                    /*Факт_нагрузка_на_оси */  form.SetField("A141", args[77]); form.SetField("A142", args[88]);
                    form.SetField("A143", args[99]); form.SetField("A144", args[110]); form.SetField("A145", args[121]);
                    form.SetField("A146", args[132]); form.SetField("A147", args[143]); form.SetField("A148", args[154]);
                    form.SetField("A149", args[165]);

                    /*Погрешность_нагрузки_на_оси */
                    form.SetField("A132", Convert.ToString(Convert.ToDouble(args[77]) * 0.1)); form.SetField("A133", Convert.ToString(Convert.ToDouble(args[88]) * 0.1));
                    form.SetField("A134", Convert.ToString(Convert.ToDouble(args[99]) * 0.1)); form.SetField("A135", Convert.ToString(Convert.ToDouble(args[110]) * 0.1)); form.SetField("A136", Convert.ToString(Convert.ToDouble(args[121]) * 0.1));
                    form.SetField("A137", Convert.ToString(Convert.ToDouble(args[132]) * 0.1)); form.SetField("A138", Convert.ToString(Convert.ToDouble(args[143]) * 0.1)); form.SetField("A139", Convert.ToString(Convert.ToDouble(args[154]) * 0.1));
                    form.SetField("A140", Convert.ToString(Convert.ToDouble(args[165]) * 0.1));

                    /*вычисленные_нагрузки_на_оси */
                    form.SetField("A150", args[78]); form.SetField("A151", args[89]);
                    form.SetField("A152", args[100]); form.SetField("A153", args[111]); form.SetField("A154", args[122]);
                    form.SetField("A155", args[133]); form.SetField("A156", args[144]); form.SetField("A157", args[155]);
                    form.SetField("A158", args[167]);

                    /*ПДК_нагрузки_на_оси */
                    form.SetField("A159", args[79]); form.SetField("A160", args[90]);
                    form.SetField("A161", args[101]); form.SetField("A162", args[112]); form.SetField("A163", args[123]);
                    form.SetField("A164", args[134]); form.SetField("A165", args[145]); form.SetField("A166", args[156]);
                    form.SetField("A167", args[167]);

                    /*ПДК_по_спец.разрешению_нагрузки_на_оси */
                    form.SetField("A168", args[80]); form.SetField("A169", args[91]);
                    form.SetField("A170", args[102]); form.SetField("A171", args[113]); form.SetField("A172", args[124]);
                    form.SetField("A173", args[135]); form.SetField("A174", args[146]); form.SetField("A175", args[157]);
                    form.SetField("A176", args[168]);

                    /*_%_превышения_нагрузки_на_оси */
                    form.SetField("A177", args[81]); form.SetField("A178", args[92]);
                    form.SetField("A179", args[103]); form.SetField("A180", args[114]); form.SetField("A181", args[125]);
                    form.SetField("A182", args[136]); form.SetField("A183", args[147]); form.SetField("A184", args[158]);
                    form.SetField("A185", args[169]);

                    /*_Скорость_ТС_превышения_скорости */
                    form.SetField("A186", args[251]); form.SetField("A187", args[252]);
                    form.SetField("A188", args[253]); form.SetField("A189", args[254]); form.SetField("A190", args[255]);
                    form.SetField("A191", args[256]); form.SetField("A192", args[257]);

                    /*ИНФОРМАЦИЯ ПО СПЕЦ.РАЗРЕШЕНИЮ */
                    form.SetField("A193", args[30]); form.SetField("A194", args[32]);
                    form.SetField("A195", args[33]); form.SetField("A196", args[34]); form.SetField("A197", args[35]);
                    form.SetField("A198", args[36]); form.SetField("A199", args[37]); form.SetField("A200", args[39]);
                    form.SetField("A201", args[38]); form.SetField("A202", "-"/*args[169]*/); form.SetField("A203", args[218]);
                    form.SetField("A204", args[229]);

                    /*_Информация о поверке */
                    form.SetField("A205", args[12]); form.SetField("A206", args[15]);
                    form.SetField("A207", args[14]); form.SetField("A208", args[16]);
                    form.SetField("A209", args[13]); form.SetField("A210", args[17]);

                    /*Информация о контолируемом участке */
                    if (args[18]=="Региональная") { form.SetField("A211", "Автомобильная дорога регионального значения общего пользования города Севастополь"); }
                    else if (args[18] == "Муниципальная") { form.SetField("A211", "Автомобильная дорога муниципального значения общего пользования города Севастополь"); }
                    else if (args[18] == "Федеральная") { form.SetField("A211", "Автомобильная дорога федерального значения общего пользования города Севастополь"); }
                    //form.SetField("A211", args[18]);
                    form.SetField("A212", args[9]);
                    form.SetField("A213", args[19]); form.SetField("A214", args[10]); form.SetField("A215", "Автомобильная дорога рассчитана под нормативную осевую нагрузку 10 тонн на ось"/*args[125]*/);
                    form.SetField("A216", "Приказ ДТиРДТИ г. Севастополя № ____________от ______________ "/*args[136]*/);
                    form.SetField("A217", args[245]); form.SetField("A218", args[246]);
                    form.SetField("A219", "-"/*args[169]*/);
                   
                    string CheckField = "";
                    int k = 1;
                    int j = 0;
                    int width = 0;
                   int i = 1;
                    int c = 0;
                    int count = 0;
                    while (KNRA[1, c] > 0)
                    {
                        count = count + KNRA[1,c];
                        c++;
                    }
                    string  Name_field = "";
                    while (i <= 8)
                    {
                        if (KNRA[0, j] == i)
                        {
                            if (KNRA[1, j] == 1)
                            { width = KNRA[1, j]; }
                            else
                            {
                                if (KNRA[1, j] == 4)
                                { KNRA[1, j] = Convert.ToInt32(args[28]) - (count - 4); }
                                width = KNRA[1, j] - 1;
                                //int c = j + 1;
                                //while (KNRA[0,c] > 0)
                                //{
                                //    KNRA[0, c] = KNRA[0, c] - 1;
                                //    c++;
                                //}
                            }
                            Name_field = "A" + '5' + KNRA[0, j].ToString() + width.ToString();
                        }
                        k = 1;
                        while (k <= 8)
                        {
                            CheckField = "A" + "5" + i.ToString() + k.ToString();
                            if (CheckField == Name_field && KNRA[1,j] != 1)
                            {
                                form.SetField(CheckField, args[164 + (j+1) * 11]);
                                j++;
                            }
                            else
                            {
                                if (KNRA[1, j] == 1)
                                    j++;
                                form.RemoveField(CheckField);
                            }
                            k++;
                        }
                        i++;
                    }

                    i = 1;
                    j = 0;
                    CheckField = "";
                    Name_field = "";
                    width = 0;
                    while (i <= 9)
                    {
                        if (KNRA[0, j] == i)
                        {
                            if (KNRA[1, j] == 4)
                            { KNRA[1, j] = Convert.ToInt32(args[28]) - (count - 4); }
                            width = KNRA[1, j];
                            Name_field = "A" + '6' + KNRA[0, j].ToString() + width.ToString();
                        }
                        k = 1;
                        while (k <= 9)
                        {
                            CheckField = "A" + "6" + i.ToString() + k.ToString();
                            if (CheckField == Name_field && KNRA[1, j] != 1)
                            {
                                form.SetField(CheckField, args[166 + (j + 1) * 11]);
                                j++;
                            }
                            else
                            {
                                if (KNRA[1, j] == 1)
                                    j++;
                                form.RemoveField(CheckField);
                            }
                            k++;
                        }
                        i++;
                    }

                    i = 1;
                    j = 0;
                    CheckField = "";
                    Name_field = "";
                    width = 0;
                    while (i <= 9)
                    {
                        if (KNRA[0, j] == i)
                        {
                            if (KNRA[1, j] == 4)
                            { KNRA[1, j] = Convert.ToInt32(args[28]) - (count - 4); }
                            width = KNRA[1, j];
                            Name_field = "A" + '7' + KNRA[0, j].ToString() + width.ToString();
                        }
                        k = 1;
                        while (k <= 9)
                        {
                            CheckField = "A" + "7" + i.ToString() + k.ToString();
                            if (CheckField == Name_field && KNRA[1, j] != 1)
                            {
                                form.SetField(CheckField, args[167 + (j + 1) * 11]);
                                j++;
                            }
                            else
                            {
                                if (KNRA[1, j] == 1)
                                    j++;
                                form.RemoveField(CheckField);
                            }
                            k++;
                        }
                        i++;
                    }

                    i = 1;
                    j = 0;
                    CheckField = "";
                    Name_field = "";
                    width = 0;
                    while (i <= 9)
                    {
                        if (KNRA[0, j] == i)
                        {
                            if (KNRA[1, j] == 4)
                            { KNRA[1, j] = Convert.ToInt32(args[28]) - (count - 4); }
                            width = KNRA[1, j];
                            Name_field = "A" + '8' + KNRA[0, j].ToString() + width.ToString();
                        }
                        k = 1;
                        while (k <= 9)
                        {
                            CheckField = "A" + "8" + i.ToString() + k.ToString();
                            if (CheckField == Name_field && KNRA[1, j] != 1)
                            {
                                form.SetField(CheckField, args[168 + (j + 1) * 11]);
                                j++;
                            }
                            else
                            {
                                if (KNRA[1, j] == 1)
                                    j++;
                                form.RemoveField(CheckField);
                            }
                            k++;
                        }
                        i++;
                    }

                    i = 1;
                    j = 0;
                    CheckField = "";
                    Name_field = "";
                    width = 0;
                    while (i <= 9)
                    {
                        if (KNRA[0, j] == i)
                        {
                            if (KNRA[1, j] == 4)
                            { KNRA[1, j] = Convert.ToInt32(args[28]) - (count - 4); }
                            width = KNRA[1, j];
                            Name_field = "A" + '9' + KNRA[0, j].ToString() + width.ToString();
                        }
                        k = 1;
                        while (k <= 9)
                        {
                            CheckField = "A" + "9" + i.ToString() + k.ToString();
                            if (CheckField == Name_field && KNRA[1, j] != 1)
                            {
                                form.SetField(CheckField, args[169 + (j + 1) * 11]);
                                j++;
                            }
                            else
                            {
                                if (KNRA[1, j] == 1)
                                    j++;
                                form.RemoveField(CheckField);
                            }
                            k++;
                        }
                        i++;
                    }
                   
                    // Установка запрета на редактирование полей.
                    resultStamper.FormFlattening = true;
                        resultStamper.Writer.Add(table);
                        resultStamper.Close();
                    }
                    templateReader.Close();

                }
                //File.Copy(@"C:\\Users\\cherednikov\\Desktop\\АКТЫ\\" + pf + ".pdf", @"C:\\Users\\cherednikov\\Desktop\\АКТЫ\\123777\\" + pf + ".pdf");
                //if (Puti[5] == "WIN-D3J6PR1H9QK")
                //{ File.Copy(@"F:\\archiv\\AKT\\" + pf + ".pdf", @"F:\\archivACT\\act\\" + pf + ".pdf"); }
                //else { File.Copy(@"" + Puti[3] + pf + ".pdf", @"" + Puti[4] + pf + ".pdf"); };
                //  File.Copy(@"F:\\archiv\\AKT\\" + pf + ".pdf", @"F:\\archivACT\\act\\" + pf + ".pdf");
            }
        }
    }

