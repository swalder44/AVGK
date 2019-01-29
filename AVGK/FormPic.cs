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
    public partial class FormPic : Form
    {
        public static Bitmap image;
        Bitmap Bmp;
        float Scl = 1;
        float X0 = 0, Y0 = 0;
        float XD = -1, YD = -1;
        public static UInt32[,] pixel;
      
        public FormPic(Image data)
        {           
            InitializeComponent();            
            PB1.MouseWheel += new System.Windows.Forms.MouseEventHandler(PB1_MouseWheel);
            PB1.Image = data;//.Width, FormDetals.SelfRef.bin.Height) ;
            PB2.Image = data;//.Width, FormDetals.SelfRef.bin.Height);           
            PB1.Refresh();

            //this.button1.Click += new System.EventHandler(this.button_Click);
            //this.button2.Click += new System.EventHandler(this.button_Click);
            //this.FormClosing += new FormClosingEventHandler(Form2Closing);
        }
        public static FormPic SelfRef
        {   get;            set;        }
        public void update()
        {
            PB1.DataBindings.Clear();
            ////PB1.DataBindings.Add(new Binding("Image", pMonitBindingSource, "Photo", true)); //"Photo", true));
            PB2.DataBindings.Clear();
            ////PB2.DataBindings.Add(new Binding("Image", pMonitBindingSource, "Photo", true));
        }
        private void Draw()          
        {
            if (PB1.Image != null)
            {
                using (Graphics Gr = Graphics.FromImage(PB1.Image))
                {
                    Gr.Clear(Color.Black);
                    Gr.DrawImage(PB2.Image, X0, Y0, PB2.Image.Width * Scl, PB2.Image.Height * Scl);
                    PB1.Refresh();
                }
            }
        }
        private void Form2_Resize(object sender, EventArgs e)
        {
            PB1.Image = new Bitmap(PB2.Width, PB2.Height);
            Draw();
        }
        private void PB1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (PB2.Image != null)
            {
                Draw();
                float x = X0 + PB2.Image.Width * Scl;
                float y = Y0 + PB2.Image.Height * Scl;
                if (e.X <= x && e.Y <= y)
                {
                    x = (e.X - X0) / Scl;
                    y = (e.Y - Y0) / Scl;
                    float ds = e.Delta > 0 ? Scl * 1.25f : Scl / 1.25f;
                    if (ds >= 0.1) Scl = ds;
                    X0 = e.X - x * Scl;
                    Y0 = e.Y - y * Scl;
                    Draw();
                }
            }
        }
        private void PB1_MouseDown_1(object sender, MouseEventArgs e)
        {
            if (PB2.Image != null)
            {
                float x = X0 + PB2.Image.Width * Scl;
                float y = Y0 + PB2.Image.Height * Scl;
                if (e.X <= x && e.Y <= y)
                {
                    XD = e.X;
                    YD = e.Y;
                }
            }
        }
        private void PB1_MouseEnter_1(object sender, EventArgs e)
        {
            PB1.Focus();
        }
        private void PB1_MouseUp_1(object sender, MouseEventArgs e)
        {
            XD = -1;
            YD = -1;
        }
        private void FormPic_ResizeEnd(object sender, EventArgs e)
        {
            PB1.Image = new Bitmap(PB2.Width, PB2.Height);
            Draw();
        }
        private void PB1_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (XD >= 0 && YD >= 0)
            {
                X0 += e.X - XD;
                Y0 += e.Y - YD;
                XD = e.X;
                YD = e.Y;
                Draw();
            }
        }
        private void FormPic_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
        internal void FormPic_LoadPMonit(int IDTS)
        {

            //pMonitTableAdapter.FillByID(rapiraDataSet.PMonit, IDTS);
            label1.Text = Convert.ToString(IDTS);
        }
        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PB1.Image != null)
            {
                Bmp = new Bitmap(PB1.Image);
                SaveFileDialog savedialog = new SaveFileDialog();
                savedialog.Title = "Сохранить изображение как...";
                savedialog.OverwritePrompt = true;
                savedialog.CheckPathExists = true;
                savedialog.Filter = "Image Files(*.BMP)|*.BMP|Image Files(*.JPG)|*.JPG|Image Files(*.GIF)|*.GIF|Image Files(*.PNG)|*.PNG|All files (*.*)|*.*";
                savedialog.ShowHelp = true;
                if (savedialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Bmp.Save(savedialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    catch
                    {
                        MessageBox.Show("Невозможно сохранить изображение", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        ////яркость контрастность
        private void яркостьконтрастностьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            image = new Bitmap(PB1.Image);
            pixel = new UInt32[image.Height, image.Width];
            for (int y = 0; y < image.Height; y++)
                for (int x = 0; x < image.Width; x++)
                    pixel[y, x] = (UInt32)(image.GetPixel(x, y).ToArgb());
            panel1.Visible = true;
            //Form2 BrightnessForm = new Form2();//this);
            //BrightnessForm.ShowDialog(); //just 'Show' for the control Form1
        }
        public static void FromPixelToBitmap()
        {
            if (FormPic.image != null)
            {
                for (int y = 0; y < image.Height; y++)
                    for (int x = 0; x < image.Width; x++)
                        image.SetPixel(x, y, Color.FromArgb((int)pixel[y, x]));
            }
        }
        //преобразование из UINT32 to Bitmap по одному пикселю
        public static void FromOnePixelToBitmap(int x, int y, UInt32 pixel)
        {
            image.SetPixel(y, x, Color.FromArgb((int)pixel));
        }
        //вывод на экран
        public void FromBitmapToScreen()
        {
            PB1.Image = image;
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            //////PB1.Image = FormDetals.SelfRef.bin;//.Width, FormDetals.SelfRef.bin.Height) ;
            //////PB2.Image = FormDetals.SelfRef.bin;//.Width, FormDetals.SelfRef.bin.Height);            
        }




        private void trackBar1_Scroll(object sender, EventArgs e)
        {
           
            this.Cursor = Cursors.AppStarting;
            if (FormPic.image != null)
            {
                UInt32 p;
                for (int i = 0; i < FormPic.image.Height; i++)
                    for (int j = 0; j < FormPic.image.Width; j++)
                    {
                        p = BrightnessContrast.Brightness(FormPic.pixel[i, j], trackBar1.Value, trackBar1.Maximum);
                        FormPic.FromOnePixelToBitmap(i, j, p);
                    }

                FromBitmapToScreen();
                this.Cursor = Cursors.Default;
            }
        }
        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            this.Cursor = Cursors.AppStarting;
            if (FormPic.image != null)
            {
                UInt32 p;
                for (int i = 0; i < FormPic.image.Height; i++)
                    for (int j = 0; j < FormPic.image.Width; j++)
                    {
                        p = BrightnessContrast.Contrast(FormPic.pixel[i, j], trackBar2.Value, trackBar2.Maximum);
                        FormPic.FromOnePixelToBitmap(i, j, p);
                    }
              this.Cursor = Cursors.Default;
                FromBitmapToScreen();
                
            }
        }
        public class ImageWrapper : IDisposable, IEnumerable<Point>
        {
            /// <summary>
            /// Ширина изображения
            /// </summary>
            public int Width { get; private set; }
            /// <summary>
            /// Высота изображения
            /// </summary>
            public int Height { get; private set; }
            /// <summary>
            /// Цвет по-умолачнию (используется при выходе координат за пределы изображения)
            /// </summary>
            public Color DefaultColor { get; set; }

            private byte[] data;//буфер исходного изображения
            private byte[] outData;//выходной буфер
            private int stride;
            public System.Drawing.Imaging.BitmapData bmpData;
            private Bitmap bmp;

            /// <summary>
            /// Создание обертки поверх bitmap.
            /// </summary>
            /// <param name="copySourceToOutput">Копирует исходное изображение в выходной буфер</param>
            public ImageWrapper(Bitmap bmp, bool copySourceToOutput = false)
            {
                if (FormPic.image != null)
                {
                    Width = bmp.Width;
                    Height = bmp.Height;
                    this.bmp = bmp;

                    bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                    stride = bmpData.Stride;

                    data = new byte[stride * Height];
                    System.Runtime.InteropServices.Marshal.Copy(bmpData.Scan0, data, 0, data.Length);

                    outData = copySourceToOutput ? (byte[])data.Clone() : new byte[stride * Height];
                }
            }

            /// <summary>
            /// Возвращает пиксел из исходнго изображения.
            /// Либо заносит пиксел в выходной буфер.
            /// </summary>
            public Color this[int x, int y]
            {
                get
                {
                    var i = GetIndex(x, y);
                    return i < 0 ? DefaultColor : Color.FromArgb(data[i + 3], data[i + 2], data[i + 1], data[i]);
                }

                set
                {
                    var i = GetIndex(x, y);
                    if (i >= 0)
                    {
                        outData[i] = value.B;
                        outData[i + 1] = value.G;
                        outData[i + 2] = value.R;
                        outData[i + 3] = value.A;
                    };
                }
            }

            /// <summary>
            /// Возвращает пиксел из исходнго изображения.
            /// Либо заносит пиксел в выходной буфер.
            /// </summary>
            public Color this[Point p]
            {
                get { return this[p.X, p.Y]; }
                set { this[p.X, p.Y] = value; }
            }

            /// <summary>
            /// Заносит в выходной буфер значение цвета, заданные в double.
            /// Допускает выход double за пределы 0-255.
            /// </summary>
            public void SetPixel(Point p, double r, double g, double b)
            {
                if (r < 0) r = 0;
                if (r >= 256) r = 255;
                if (g < 0) g = 0;
                if (g >= 256) g = 255;
                if (b < 0) b = 0;
                if (b >= 256) b = 255;

                this[p.X, p.Y] = Color.FromArgb((int)r, (int)g, (int)b);
            }

            int GetIndex(int x, int y)
            {
                return (x < 0 || x >= Width || y < 0 || y >= Height) ? -1 : x * 4 + y * stride;
            }

            /// <summary>
            /// Заносит в bitmap выходной буфер и снимает лок.
            /// Этот метод обязателен к исполнению (либо явно, лмбо через using)
            /// </summary>
            public void Dispose()
            {
                System.Runtime.InteropServices.Marshal.Copy(outData, 0, bmpData.Scan0, outData.Length);
                bmp.UnlockBits(bmpData);
            }

            /// <summary>
            /// Перечисление всех точек изображения
            /// </summary>
            public IEnumerator<Point> GetEnumerator()
            {
                for (int y = 0; y < Height; y++)
                    for (int x = 0; x < Width; x++)
                        yield return new Point(x, y);
            }

            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            /// <summary>
            /// Меняет местами входной и выходной буферы
            /// </summary>
            public void SwapBuffers()
            {
                var temp = data;
                data = outData;
                outData = temp;
            }
        }
        //изменение контрастности
        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            //if (Form1.full_name_of_image != "\0")
            //{
            //    UInt32 p;
            //    for (int i = 0; i < Form1.image.Height; i++)
            //        for (int j = 0; j < Form1.image.Width; j++)
            //        {
            //            p = BrightnessContrast.Contrast(Form1.pixel[i, j], trackBar2.Value, trackBar2.Maximum);
            //            Form1.FromOnePixelToBitmap(i, j, p);
            //        }

            //    FromBitmapToScreen();
            //}
            //матрица повышения резкости
            this.Cursor = Cursors.AppStarting;
            if (trackBar3.Value > 0)
            {
                var kernel = new double[,]
                                     {{0, -1, 0},
                              {-1, 5, -1},
                              {0, -1, 0}};

                Convolution(FormPic.image, kernel);
                FromBitmapToScreen();
                this.Cursor = Cursors.Default;
            }
            else if (trackBar3.Value < 0)
            {
                var kernel = new double[,]
                   {{0.11, 0.11, 0.11},
                  {0.11, 0.11, 0.11},
                  {0.11, 0.11, 0.11}};

                Convolution(FormPic.image, kernel);
                FromBitmapToScreen();
                this.Cursor = Cursors.Default;
            }
        }

        //....

        private void Convolution(Bitmap img, double[,] matrix)
        {
            var w = matrix.GetLength(0);
            var h = matrix.GetLength(1);

            using (var wr = new ImageWrapper(img) { DefaultColor = Color.Silver })
                foreach (var p in wr)
                {
                    double r = 0d, g = 0d, b = 0d;

                    for (int i = 0; i < w; i++)
                        for (int j = 0; j < h; j++)
                        {
                            var pixel = wr[p.X + i - 1, p.Y + j - 1];
                            r += matrix[j, i] * pixel.R;
                            g += matrix[j, i] * pixel.G;
                            b += matrix[j, i] * pixel.B;
                        }
                    wr.SetPixel(p, r, g, b);
                }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            trackBar1.Value = 0;
            trackBar2.Value = 0;
            trackBar3.Value = 0;
            panel1.Visible = false;
        }


        //сохранение изменений яркости или контрастности
        private void button_Click(object sender, EventArgs e)
        {
            if (FormPic.image != null)
            {
                //for (int i = 0; i < FormPic.image.Height; i++)
                //for (int j = 0; j < FormPic.image.Width; j++)
                //    FormPic.pixel[i, j] = (UInt32)(FormPic.image.GetPixel(j, i).ToArgb());
               trackBar1.Value = 0;
               trackBar2.Value = 0;
                trackBar3.Value = 0;
                FromBitmapToScreen();
                panel1.Visible = false;
               // this.Close();
            }
        }

        //вывод изображения на экран
        //void FromBitmapToScreen()
        //{
        //    OwnerForm.FromBitmapToScreen();
        //}

        //обновление изображения в Bitmap и pictureBox при закрытии окна
        private void Form2Closing(object sender, System.EventArgs e)
        {
            //   if (Form1.full_name_of_image != "\0")
            //   {
            //FormPic.FromPixelToBitmap();
            //FromBitmapToScreen();
            //FormPic.SelfRef.update();
            //  }
        }






    }
}

