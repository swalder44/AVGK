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
                                                      ////dir1=dir1.ToString().Replace('`\`' , `\\` );
                var pdfTemplate = @"C:\Users\cherednikov\Desktop\АКТ.pdf";// + dir1 + "\\AKT.pdf";//'"+dir1+"\\
                                                                          //var pdfFile = @"C:\\Users\\cherednikov\\Desktop\\АКТЫ\\" + args[0] + "_" + DateTime.Now.ToString("ddMMyyyy") + ".pdf";
            if (Puti[5] == "WIN-D3J6PR1H9QK")
            { pdfFile = @"F:\\archiv\\AKT\\" + args[259] + "_" + DateTime.Now.ToString("ddMMyyyy") + ".pdf"; }
            else { pdfFile = @"C:\Users\cherednikov\Desktop\A\АКТ.pdf"; }//@"" + Puti[3] + args[259] + "_" + DateTime.Now.ToString("ddMMyyyy") + ".pdf"; };
                //var pdfFile = @"F:\\archiv\\AKT\\" + args[259] + "_" + DateTime.Now.ToString("ddMMyyyy") + ".pdf";
                //var pdfFile = @"F:\\" + args[259] + "_" + DateTime.Now.ToString("ddMMyyyy") + ".pdf";
                //var pdfFile = @"C:\\Users\\cherednikov\\Desktop\\АКТЫ\\" + args[259] + "_" + DateTime.Now.ToString("ddMMyyyy") + ".pdf";
                pf = args[259] + "_" + DateTime.Now.ToString("ddMMyyyy");
                using (var templateReader = new PdfReader(pdfTemplate))

                {
                    if (i1 != null)
                    {
                        System.Drawing.Bitmap imgg = new System.Drawing.Bitmap(i1);
                        imag = iTextSharp.text.Image.GetInstance(imgg, System.Drawing.Imaging.ImageFormat.Jpeg);// @"C:\Users\cherednikov\Pictures\original22.jpg");
                        //if (Puti[5] == "WIN-D3J6PR1H9QK")
                        //{ imgg.Save(@"F:\\archiv\\AKT\\" + args[259] + "_" + DateTime.Now.ToString("ddMMyyyy") + "_1.Jpeg"); }
                        //else
                        //{
                        //    imgg.Save(@"" + Puti[3] + args[259] + "_" + DateTime.Now.ToString("ddMMyyyy") + "_1.Jpeg");

                        //    //File.Copy(@"" + N1, @"" + Puti[3] + args[259] + "_" + DateTime.Now.ToString("ddMMyyyy") + "_1.png");
                        //};
                        //// imgg.Save(@""+ Puti[3] + args[259] + "_" + DateTime.Now.ToString("ddMMyyyy") + "_1.Jpeg");
                        ////imgg.Save(@"F:\\" + args[259] + "_" + DateTime.Now.ToString("ddMMyyyy") + "_1.Jpeg");

                        ////imgg.Save(@"C:\\Users\\cherednikov\\Desktop\\АКТЫ\\" + args[259] + "_" + DateTime.Now.ToString("ddMMyyyy") + "_1.Jpeg");

                    }
                    if (i2 != null)
                    {
                        System.Drawing.Bitmap imgg2 = new System.Drawing.Bitmap(i2);
                        imag2 = iTextSharp.text.Image.GetInstance(imgg2, System.Drawing.Imaging.ImageFormat.Jpeg);
                        //if (Puti[5] == "WIN-D3J6PR1H9QK")
                        //{ imgg2.Save(@"F:\\archiv\\AKT\\" + args[259] + "_" + DateTime.Now.ToString("ddMMyyyy") + "_2.Jpeg"); }
                        //else
                        //{
                        //    imgg2.Save(@"" + Puti[3] + args[259] + "_" + DateTime.Now.ToString("ddMMyyyy") + "_2.Jpeg");
                        //    //File.Copy(@"" + N2, @"" + Puti[3] + args[259] + "_" + DateTime.Now.ToString("ddMMyyyy") + "_2.png");
                        //};
                        ////imgg2.Save(@"F:\\archiv\\AKT\\" + args[259] + "_" + DateTime.Now.ToString("ddMMyyyy") + "_2.Jpeg");
                        ////imgg2.Save(@"F:\\" + args[259] + "_" + DateTime.Now.ToString("ddMMyyyy") + "_2.Jpeg");
                        ////imgg2.Save(@"C:\\Users\\cherednikov\\Desktop\\АКТЫ\\" + args[259] + "_" + DateTime.Now.ToString("ddMMyyyy") + "_2.Jpeg");
                    }
                    if (i3 != null)
                    {
                        System.Drawing.Bitmap imgg3 = new System.Drawing.Bitmap(i3);
                        imag3 = iTextSharp.text.Image.GetInstance(imgg3, System.Drawing.Imaging.ImageFormat.Jpeg);
                        //if (Puti[5] == "WIN-D3J6PR1H9QK")
                        //{ imgg3.Save(@"F:\\archiv\\AKT\\" + args[259] + "_" + DateTime.Now.ToString("ddMMyyyy") + "_3.Jpeg"); }
                        //else
                        //{
                        //    imgg3.Save(@"" + Puti[3] + args[259] + "_" + DateTime.Now.ToString("ddMMyyyy") + "_3.Jpeg");
                        //    //File.Copy(@"" + N3, @"" + Puti[3] + args[259] + "_" + DateTime.Now.ToString("ddMMyyyy") + "_3.png");
                        //};
                        //// imgg3.Save(@"F:\\archiv\\AKT\\" + args[259] + "_" + DateTime.Now.ToString("ddMMyyyy") + "_3.Jpeg");
                        ////imgg3.Save(@"F:\\" + args[259] + "_" + DateTime.Now.ToString("ddMMyyyy") + "_3.Jpeg");
                        ////imgg3.Save(@"C:\\Users\\cherednikov\\Desktop\\АКТЫ\\" + args[259] + "_" + DateTime.Now.ToString("ddMMyyyy") + "_3.Jpeg");
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
                    /*СКАТНОСТ_КОЛ_КОЛЕС*/form.SetField("A47", args[73]); form.SetField("A48", args[84]);form.SetField("A49", args[95]); form.SetField("A50", args[106]);
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

                    //(args[173]

                    //for (int i = 1; i < 10; i++ )
                    //{
                    //delete_fields(KNRA, args, 5, 8);
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

                    //}
                    ////// form.RemoveField("A97_1"); form.RemoveField("A91_1"); form.RemoveField("A92_1"); form.RemoveField("A93_1"); form.RemoveField("A94_1"); form.RemoveField("A95_1"); form.RemoveField("A96_1");
                    //////form.RemoveField("A98_2"); form.RemoveField("A99_2"); form.RemoveField("A100_2"); form.RemoveField("A101_2"); form.RemoveField("A102_2"); form.RemoveField("A103_2"); form.RemoveField("A104_2"); //если первая группа из 1 оси
                    //////form.RemoveField("A105_3"); form.RemoveField("A106_3"); form.RemoveField("A107_3"); form.RemoveField("A108_3"); form.RemoveField("A109_3");
                    //////form.RemoveField("A110_4"); form.RemoveField("A111_4"); form.RemoveField("A112_4"); form.RemoveField("A113_4");
                    //////form.RemoveField("A115_5"); form.RemoveField("A117_5"); form.RemoveField("A118_5"); form.RemoveField("A116_5");
                    //////form.RemoveField("A119_6"); form.RemoveField("A120_6"); form.RemoveField("A121_6");
                    //////form.RemoveField("A122_7"); form.RemoveField("A123_7");
                    //////form.RemoveField("A89_8");

                    //////if (args[173] == "1") {
                    //////    form.SetField("A90_1", args[65]);
                    //////    form.SetField("A99_2", args[65]);

                    //////    ////////////form.RemoveField("A89_8"); form.RemoveField("A91_1"); form.RemoveField("A92_1"); form.RemoveField("A93_1"); form.RemoveField("A94_1"); form.RemoveField("A95_1"); form.RemoveField("A96_1"); form.RemoveField("A97_1"); form.RemoveField("A100_2"); form.RemoveField("A101_2"); form.RemoveField("A102_2"); form.RemoveField("A103_2"); form.RemoveField("A104_2"); //если первая группа из 1 оси
                    //////    ////////////form.RemoveField("A105_3"); form.RemoveField("A106_3"); form.RemoveField("A107_3");
                    //////    ////////////form.RemoveField("A108_3"); form.RemoveField("A109_3"); form.RemoveField("A110_4"); form.RemoveField("A111_4"); form.RemoveField("A112_4");
                    //////    ////////////form.RemoveField("A113_4"); form.RemoveField("A115_5"); form.RemoveField("A117_5"); form.RemoveField("A118_5");
                    //////    ////////////form.RemoveField("A116_5"); form.RemoveField("A119_6"); form.RemoveField("A120_6"); form.RemoveField("A121_6");
                    //////    ////////////form.RemoveField("A122_7"); form.RemoveField("A123_7");
                    //////    //if (args[184] == "1") { form.RemoveField("A89_8"); form.RemoveField("A98_2"); //если вторая группа из 1 оси
                    //////    //    if (args[195] == "1") { form.RemoveField("A89_8"); form.RemoveField("A98_2"); //если третья группа из 1 оси
                    //////    //        if (args[206] == "1") { form.RemoveField("A89_8"); form.RemoveField("A98_2"); //если 4 группа из 1 оси
                    //////    //            if (args[217] == "1") { form.RemoveField("A89_8"); form.RemoveField("A98_2");//если 5 группа из 1 оси
                    //////    //                if (args[228] == "1") { form.RemoveField("A89_8"); form.RemoveField("A98_2"); }//если 6 группа из 1 оси
                    //////    //                else if (args[228] == "2") { form.RemoveField("A89_8"); form.RemoveField("A98_2"); form.RemoveField("A95_1"); }
                    //////    //                else { form.RemoveField("A89_8"); form.RemoveField("A98_2"); form.RemoveField("A95_1"); form.RemoveField("A103_2"); }
                    //////    //            }
                    //////    //            else if (args[217] == "2") { form.RemoveField("A89_8"); form.RemoveField("A98_2");//если 5 группа из 1 оси
                    //////    //                if (args[228] == "1") { form.RemoveField("A89_8"); form.RemoveField("A98_2"); form.RemoveField("A103_2"); form.RemoveField("A96_1"); form.RemoveField("A97_1"); }//если 6 группа из 1 оси
                    //////    //                else if (args[228] == "2") { form.RemoveField("A89_8"); form.RemoveField("A98_2"); form.RemoveField("A95_1"); form.RemoveField("A96_1"); form.RemoveField("A97_1"); }
                    //////    //                else { form.RemoveField("A89_8"); form.RemoveField("A98_2"); form.RemoveField("A95_1"); form.RemoveField("A103_2"); form.RemoveField("A96_1"); form.RemoveField("A97_1"); }
                    //////    //            }
                    //////    //    }
                    //////    //}
                    //////    //else if (args[184] == "2") { form.RemoveField("A89_8"); form.RemoveField("A98_2"); form.RemoveField("A91_1"); }
                    //////    //else if (args[184] == "3") { form.RemoveField("A89_8"); form.RemoveField("A90_1"); form.RemoveField("A98_2"); }
                    //////    //else if (args[184] == "4") { form.RemoveField("A89_8"); form.RemoveField("A90_1"); form.RemoveField("A98_2"); form.RemoveField("A105_3"); }
                    //////    //else if (args[184] == "5") { form.RemoveField("A89_8"); form.RemoveField("A90_1"); form.RemoveField("A98_2"); form.RemoveField("A105_3"); form.RemoveField("A110_4"); }
                    //////    //else if (args[184] == "6") { form.RemoveField("A89_8"); form.RemoveField("A90_1"); form.RemoveField("A98_2"); form.RemoveField("A105_3"); form.RemoveField("A110_4"); form.RemoveField("A115_5"); }
                    //////    //else if (args[184] == "7") { form.RemoveField("A89_8"); form.RemoveField("A90_1"); form.RemoveField("A98_2"); form.RemoveField("A105_3"); form.RemoveField("A110_4"); form.RemoveField("A115_5"); form.RemoveField("A119_6"); }
                    //////    //else { form.RemoveField("A90_1"); form.RemoveField("A98_2"); form.RemoveField("A105_3"); form.RemoveField("A110_4"); form.RemoveField("A115_5"); form.RemoveField("A119_6"); form.RemoveField("A122_7"); }
                    //////}
                    //////else if (args[173] == "2") { form.RemoveField("A89_8"); form.RemoveField("A90_1"); }
                    //////else if (args[173] == "3") { form.RemoveField("A89_8"); form.RemoveField("A90_1"); form.RemoveField("A98_2"); }
                    //////else if (args[173] == "4") { form.RemoveField("A89_8"); form.RemoveField("A90_1"); form.RemoveField("A98_2"); form.RemoveField("A105_3"); }
                    //////else if (args[173] == "5") { form.RemoveField("A89_8"); form.RemoveField("A90_1"); form.RemoveField("A98_2"); form.RemoveField("A105_3"); form.RemoveField("A110_4"); }
                    //////else if (args[173] == "6") { form.RemoveField("A89_8"); form.RemoveField("A90_1"); form.RemoveField("A98_2"); form.RemoveField("A105_3"); form.RemoveField("A110_4"); form.RemoveField("A115_5"); }
                    //////else if (args[173] == "7") { form.RemoveField("A89_8"); form.RemoveField("A90_1"); form.RemoveField("A98_2"); form.RemoveField("A105_3"); form.RemoveField("A110_4"); form.RemoveField("A115_5"); form.RemoveField("A119_6"); }
                    //////else  {form.RemoveField("A90_1"); form.RemoveField("A98_2"); form.RemoveField("A105_3"); form.RemoveField("A110_4"); form.RemoveField("A115_5"); form.RemoveField("A119_6"); form.RemoveField("A122_7"); }


                    //////if (args[184]== "1") { form.RemoveField("A89_8"); form.RemoveField("A98_2"); form.RemoveField("A99_2"); } 
                    //////else if (args[184] == "2") {form.RemoveField("A89_8"); form.RemoveField("A98_2"); form.RemoveField("A91_1"); }
                    //////else if (args[184] == "3") { form.RemoveField("A89_8"); form.RemoveField("A90_1"); form.RemoveField("A98_2"); }
                    //////else if (args[184] == "4") { form.RemoveField("A89_8"); form.RemoveField("A90_1"); form.RemoveField("A98_2"); form.RemoveField("A105_3"); }
                    //////else if (args[184] == "5") {form.RemoveField("A89_8"); form.RemoveField("A90_1"); form.RemoveField("A98_2"); form.RemoveField("A105_3"); form.RemoveField("A110_4"); }
                    //////else if (args[184] == "6") { form.RemoveField("A89_8"); form.RemoveField("A90_1"); form.RemoveField("A98_2"); form.RemoveField("A105_3"); form.RemoveField("A110_4"); form.RemoveField("A115_5"); }
                    //////else if (args[184] == "7") { form.RemoveField("A89_8"); form.RemoveField("A90_1"); form.RemoveField("A98_2"); form.RemoveField("A105_3"); form.RemoveField("A110_4"); form.RemoveField("A115_5"); form.RemoveField("A119_6"); }
                    //////else { form.RemoveField("A90_1"); form.RemoveField("A98_2"); form.RemoveField("A105_3"); form.RemoveField("A110_4"); form.RemoveField("A115_5"); form.RemoveField("A119_6"); form.RemoveField("A122_7"); }

                    //////form.RegenerateField("A89_8");

                    //////////////////////////////////////if (args[195] == "1") { /*form.SetField("A92");*/ form.RemoveField("A92"); form.RemoveField("A93"); }


                    //////////////////////////////////////if (args[206] == "1") { /*form.SetField("A92");*/ form.RemoveField("A92"); form.RemoveField("A93"); }


                    //////////////////////////////////////if (args[217] == "1") { /*form.SetField("A92");*/ form.RemoveField("A92"); form.RemoveField("A93"); }


                    //////////////////////////////////////if (args[228] == "1") { /*form.SetField("A92");*/ form.RemoveField("A92"); form.RemoveField("A93"); }
                    //form.SetField("A2", args[6]);  

                    //////form.SetField("A8", args[12]); form.SetField("A9", args[13]); form.SetField("A10", args[14]);
                    //////form.SetField("A11", args[15]); form.SetField("A12", args[16]); form.SetField("A13", args[17]); form.SetField("A14", args[18]); form.SetField("A15", args[19]);
                    //////form.SetField("A16", args[20]); form.SetField("A18", args[22]); form.SetField("A19", args[23]); form.SetField("A20", args[24]);

                    //////form.SetField("A26", args[30]); form.SetField("A27", args[31]); form.SetField("A28", args[32]); form.SetField("A29", args[33]); form.SetField("A30", args[34]);
                    //////form.SetField("A31", args[35]); form.SetField("A32", args[36]); form.SetField("A33", args[37]); form.SetField("A34", args[38]); form.SetField("A35", args[39]);
                    //////form.SetField("A36", args[40]);  

                    //////form.SetField("A67", args[71]); form.SetField("A68", args[72]);  form.SetField("A70", args[74]);
                    //////form.SetField("A71", args[75]); form.SetField("A72", args[76]); form.SetField("A73", args[77]); form.SetField("A74", args[78]); form.SetField("A75", args[79]);
                    //////form.SetField("A76", args[80]); form.SetField("A77", args[81]); form.SetField("A78", args[82]); form.SetField("A79", args[83]);
                    //////form.SetField("A81", args[85]);   form.SetField("A84", args[88]); form.SetField("A85", args[89]);
                    //////form.SetField("A89", args[90]);
                    //////form.SetField("A87", args[91]); form.SetField("A88", args[92]); form.SetField("A89", args[93]); form.SetField("A90", args[94]);
                    //////form.SetField("A92", args[96]);   form.SetField("A95", args[99]);
                    //////form.SetField("A96", args[100]); form.SetField("A97", args[101]); form.SetField("A98", args[102]); form.SetField("A99", args[103]); form.SetField("A100", args[104]);
                    //////form.SetField("A101", args[105]); form.SetField("A103", args[107]);  
                    //////form.SetField("A106", args[110]); form.SetField("A107", args[111]); form.SetField("A108", args[112]); form.SetField("A109", args[113]); form.SetField("A110", args[114]);
                    ////// form.SetField("A112", args[116]); form.SetField("A114", args[118]); /*form.SetField("A115", args[119]);*/
                    ////// form.SetField("A117", args[121]); form.SetField("A118", args[122]); form.SetField("A119", args[123]); form.SetField("A120", args[124]);
                    //////form.SetField("A121", args[125]); form.SetField("A122", args[126]); form.SetField("A123", args[127]);  form.SetField("A125", args[129]);
                    //////  form.SetField("A128", args[132]); form.SetField("A129", args[133]); form.SetField("A130", args[134]);
                    //////form.SetField("A131", args[135]); form.SetField("A132", args[136]); form.SetField("A133", args[137]); form.SetField("A134", args[138]); 
                    //////form.SetField("A136", args[140]);   form.SetField("A139", args[143]); form.SetField("A140", args[144]);
                    //////form.SetField("A141", args[145]); form.SetField("A142", args[146]); form.SetField("A143", args[147]); form.SetField("A144", args[148]); form.SetField("A145", args[149]);
                    ////// form.SetField("A147", args[151]);  form.SetField("A150", args[154]);
                    //////form.SetField("A151", args[155]); form.SetField("A152", args[156]); form.SetField("A153", args[157]); form.SetField("A154", args[158]); form.SetField("A155", args[159]);
                    //////form.SetField("A156", args[160]);  form.SetField("A158", args[162]);  
                    //////form.SetField("A161", args[165]); form.SetField("A162", args[166]); form.SetField("A163", args[167]); form.SetField("A164", args[168]); form.SetField("A165", args[169]);
                    //////form.SetField("A166", args[170]); form.SetField("A167", args[171]); form.SetField("A168", args[172]); form.SetField("A169", args[173]); form.SetField("A170", args[174]);
                    //////form.SetField("A171", args[175]); form.SetField("A172", args[176]); form.SetField("A173", args[177]); form.SetField("A174", args[178]); form.SetField("A175", args[179]);
                    //////form.SetField("A176", args[180]); form.SetField("A177", args[181]); form.SetField("A178", args[182]); form.SetField("A179", args[183]); form.SetField("A180", args[184]);
                    //////form.SetField("A181", args[185]);  form.SetField("A183", args[187]); form.SetField("A184", args[188]); form.SetField("A185", args[189]);
                    //////form.SetField("A186", args[190]); form.SetField("A187", args[191]); form.SetField("A188", args[192]); form.SetField("A189", args[193]); form.SetField("A190", args[194]);
                    //////form.SetField("A191", args[195]); form.SetField("A192", args[196]); form.SetField("A193", args[197]); form.SetField("A194", args[198]); form.SetField("A195", args[199]);
                    //////form.SetField("A196", args[200]); form.SetField("A197", args[201]); form.SetField("A198", args[202]); form.SetField("A199", args[203]); form.SetField("A200", args[204]);
                    //////form.SetField("A201", args[205]); form.SetField("A202", args[206]); form.SetField("A203", args[207]); form.SetField("A204", args[208]); form.SetField("A205", args[209]);
                    //////form.SetField("A206", args[210]); form.SetField("A207", args[211]); form.SetField("A208", args[212]); form.SetField("A209", args[213]); form.SetField("A210", args[214]);
                    //////form.SetField("A211", args[215]); form.SetField("A212", args[216]); form.SetField("A213", args[217]); form.SetField("A214", args[218]); form.SetField("A215", args[219]);
                    //////form.SetField("A216", args[220]); form.SetField("A217", args[221]); form.SetField("A218", args[222]); form.SetField("A219", args[223]); form.SetField("A220", args[224]);
                    //////form.SetField("A221", args[225]); form.SetField("A222", args[226]); form.SetField("A223", args[227]); form.SetField("A224", args[228]); form.SetField("A225", args[229]);
                    //////form.SetField("A226", args[230]); form.SetField("A227", args[231]); form.SetField("A228", args[232]); form.SetField("A229", args[233]); form.SetField("A230", args[234]);
                    //////form.SetField("A231", args[235]); form.SetField("A232", args[236]); form.SetField("A233", args[237]); form.SetField("A234", args[238]); form.SetField("A235", args[239]);
                    //////form.SetField("A236", args[240]); form.SetField("A237", args[241]); form.SetField("A238", args[242]); form.SetField("A239", args[243]); form.SetField("A240", args[244]);
                    //////form.SetField("A241", args[245]); form.SetField("A242", args[246]); form.SetField("A243", args[247]); form.SetField("A244", args[248]); form.SetField("A245", args[249]);
                    //////form.SetField("A246", args[250]); /*form.SetField("NComp1", args[251]); form.SetField("NComp2", args[252]); form.SetField("NComp3", args[253]);*/
                    //Image image = Image.GetInstance(@"C:\Users\cherednikov\Pictures\original22.jpg");

                    //doc.("im1", image);


                    //////////var jpg = iTextSharp.text.Image.GetInstance(@"C:\Users\cherednikov\Pictures\original22.jpg");
                    //////////jpg.SetAbsolutePosition(430, 750);
                    //////////jpg.Annotation = new Annotation("Title", "Text");
                    //////////templateReader.Add(jpg);






                    //iTextSharp.Layout.Element.Image dogImage = new iTextSharp.Layout.Element.Image(ImageDataFactory.Create(DOG));
                    //iTextSharp.text.Image im1 = iTextSharp.text.Image.GetInstance(@"C:\Users\cherednikov\Pictures\original22.jpg");
                    //PdfImage image = im1;
                    //////im1.ScalePercent(70);

                    ////////////////////var jpg = iTextSharp.text.Image.GetInstance(@"C:\Users\cherednikov\Pictures\original22.jpg");
                    ////////////////////jpg.SetAbsolutePosition(430, 750);
                    ////////////////////jpg.Annotation = new Annotation("Title", "Text");

                    // Image image = Image.GetInstance(@"C:\Users\cherednikov\Pictures\original22.jpg");
                    ////////jpg.ScaleToFit(250f, 250f);
                    ////////jpg.Border = Rectangle.BOX;
                    //////////jpg.BorderColor = Color.YELLOW;
                    ////////jpg.BorderWidth = 5f;
                    ////////Add(jpg);

                    //////////document.Add(jpg);
                    ////////PdfPCell cell = new PdfPCell(image);
                    ////////cell.PaddingTop = 0;
                    ////////cell.PaddingRight = 0;
                    ////////cell.PaddingBottom = 0;
                    ////////cell.PaddingLeft = 0;
                    ////////cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    ////////cell.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                    ////////cell.Border = 0;
                    ////////cell.BackgroundColor = new BaseColor(37, 168, 81); ;
                    ////////table.AddCell(cell);
                    //////////XImage img = XImage.FromFile(@"C:\Users\cherednikov\Pictures\original22.jpg");
                    //form.SetField("im1", @"C:\Users\cherednikov\Pictures\original22.jpg");

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

