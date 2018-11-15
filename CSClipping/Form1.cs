using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace CSClipping
{
    public partial class Form1 : Form
    {
        private Point Center;
        private Bitmap bmp;
        private Graphics grp;
        private StringBuilder Sb;
        new const int Scale = 50;
        // Коды положений согласно алгоритму
        const int INSIDE = 0; // 0000
        const int LEFT = 1;   // 0001
        const int RIGHT = 2;  // 0010
        const int BOTTOM = 4; // 0100
        const int TOP = 8;    // 1000

        public Form1()
        {
            InitializeComponent();
        }

        //отрисовка осей OX и OY
        private void SetXY(Bitmap bmp, Graphics grp)
        {
            // Центр координат
            Center = new Point(pictureBox1.Width / 2, pictureBox1.Height / 2);
            int X0 = (int)Center.X;
            int Y0 = (int)Center.Y;
            // Система Координат
            System.Drawing.Pen blPen;
            blPen = new System.Drawing.Pen(System.Drawing.Color.Blue);
            grp.DrawLine(blPen, 0, Y0, pictureBox1.Width, Y0);
            grp.DrawLine(blPen, X0, 0, X0, pictureBox1.Height);
            pictureBox1.Image = bmp;
        }

        // Отрисовка вершин треугольника
        private void SetDot(double x, double y, int Scale, string dot)
        {
            bmp.SetPixel(Center.X + (int)(x * Scale), Center.Y - ((int)y * Scale), Color.Red);
            bmp.SetPixel(Center.X + (1 + (int)(x * Scale)), Center.Y - (1 + (int)(y * Scale)), Color.Red);
            bmp.SetPixel(Center.X + (2 + (int)(x * Scale)), Center.Y - (2 + (int)(y * Scale)), Color.Red);
            bmp.SetPixel(Center.X + (1 + (int)(x * Scale)), Center.Y - (-1 + (int)(y * Scale)), Color.Red);
            bmp.SetPixel(Center.X + (2 + (int)(x * Scale)), Center.Y - (-2 + (int)(y * Scale)), Color.Red);
            bmp.SetPixel(Center.X + (-1 + (int)(x * Scale)), Center.Y - (1 + (int)(y * Scale)), Color.Red);
            bmp.SetPixel(Center.X + (-2 + (int)(x * Scale)), Center.Y - (2 + (int)(y * Scale)), Color.Red);
            bmp.SetPixel(Center.X + (-1 + (int)(x * Scale)), Center.Y - (-1 + (int)(y * Scale)), Color.Red);
            bmp.SetPixel(Center.X + (-2 + (int)(x * Scale)), Center.Y - (-2 + (int)(y * Scale)), Color.Red);
            Font aFont = new Font("Tahoma", 10, FontStyle.Regular);
            grp.DrawString(dot, aFont, Brushes.Black, Center.X + (int)(x * Scale), Center.Y - (int)(y * Scale));
        }

        // Отрисовка отрезков треугольника
        private void SetTiangle(int Scale, Point P1, Point P2, Point P3)
        {
            //отрисовка вершин треугольника
            SetDot(P1.X, P1.Y, Scale, "P1");//P1
            SetDot(P2.X, P2.Y, Scale, "P2");//P2
            SetDot(P3.X, P3.Y, Scale, "P3");//P3

            //отрисовка отрезков треугольника
            //P1P2
            grp.DrawLine(Pens.Black, Center.X + (P1.X * Scale), Center.Y - (P1.Y * Scale),
                                              Center.X + (P2.X * Scale), Center.Y - (P2.Y * Scale));
            //P1P3 
            grp.DrawLine(Pens.Black, Center.X + (P1.X * Scale), Center.Y - (P1.Y * Scale),
                                              Center.X + (P3.X * Scale), Center.Y - (P3.Y * Scale));
            //P2P3
            grp.DrawLine(Pens.Black, Center.X + (P2.X * Scale), Center.Y - (P2.Y * Scale),
                                              Center.X + (P3.X * Scale), Center.Y - (P3.Y * Scale));
        }

        // Отрисовывываем клиппинг область
        private void SetClipping(int Scale, Point TL, Point BR)
        {
            //отрисовка области клиппинга
            grp.DrawRectangle(Pens.Red, Center.X + (TL.X * Scale), Center.Y - (TL.Y * Scale),
                                                                 BR.X * Scale, BR.Y * Scale);
        }

        // Определение положения точки с координатами x, y относительно области
        int ComputeCode(Point P, Point TL, Point BR)
        {
            // установка первоначального значения во "внутри области"
            int code = INSIDE;

            if (P.X < TL.X)       // слева от области
                code |= LEFT;
            else if (P.X > BR.X)  // справа от области
                code |= RIGHT;
            if (P.Y < BR.Y)       // под областью
                code |= BOTTOM;
            else if (P.Y > TL.Y)  // над областью
                code |= TOP;

            return code;
        }


        // Реализация алгоритма Сазерледа-Ходжмена
        // Клиппинг отрезка P1 = (x1, y1) to P2 = (x2, y2) и области клиппинга
        bool CSAlgoAndClip(Point P1, Point P2, Point TL, Point BR, out double x, out double y)
        {
            // Определение положения точек P1, P2
            int code1 = ComputeCode(P1, TL, BR);
            int code2 = ComputeCode(P2, TL, BR);

            double x1, y1, x2, y2, x_min, y_min, x_max, y_max;
            x1 = P1.X; y1 = P1.Y; x2 = P2.X; y2 = P2.Y;
            x_min = TL.X; y_min = TL.Y; x_max = BR.X; y_max = BR.Y;
            // установка первоначального значения в "нет пересечения"
            bool accept = false;
            // Часть отрезка находится
            // внутри области
            int code_out;
            x = 0; y = 0;
            while (true)
            {
                if ((code1 == 0) && (code2 == 0))
                {
                    // Если концы отрезка
                    // внутри области
                    accept = true;
                    break;
                }
                else if ((code1 & code2) != 0)
                {
                    // Если концы отрезка вне области,
                    // но в одном квадранте
                    break;
                }
                else
                {
                    // Хотя бы один из концов отрезка
                    // вне области, выберем его
                    if (code1 != 0)
                        code_out = code1;
                    else
                        code_out = code2;

                    // Найдем точку пересечения;
                    // используя формулу y = y1 + slope * (x - x1),
                    // x = x1 + (1 / slope) * (y - y1)
                    if ((code_out & TOP) != 0)
                    {
                        // точка находится над
                        x = x1 + (x2 - x1) * (y_max - y1) / (y2 - y1);
                        y = y_max;
                    }
                    else if ((code_out & BOTTOM) != 0)
                    {
                        // точка находится под
                        x = x1 + (x2 - x1) * (y_min - y1) / (y2 - y1);
                        y = y_min;
                    }
                    else if ((code_out & RIGHT) != 0)
                    {
                        // точка находится справа
                        y = y1 + (y2 - y1) * (x_max - x1) / (x2 - x1);
                        x = x_max;
                    }
                    else if ((code_out & LEFT) != 0)
                    {
                        // точка находится слева
                        y = y1 + (y2 - y1) * (x_min - x1) / (x2 - x1);
                        x = x_min;
                    }

                    // Точка пересечения с координатами x,y найдена
                    // Заменим координаты точки вне пересечения
                    // на координаты точки пересечения
                    if (code_out == code1)
                    {
                        P1.X = (int)x;
                        P1.Y = (int)y;
                        code1 = ComputeCode(P1, TL, BR);
                    }
                    else
                    {
                        P2.X = (int)x;
                        P2.Y = (int)y;
                        code2 = ComputeCode(P2, TL, BR);
                    }
                }
            }

            return accept;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            grp = Graphics.FromImage(bmp);
            //отрисовка осей OX и OY 
            SetXY(bmp, grp);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Point P1, P2, P3, TL, BR;
            //очищаем область рисования
            Graphics.FromImage(bmp).Clear(pictureBox1.BackColor);
            pictureBox1.Image = bmp;
            try
            {
                //получает координаты вершин треугольника
                P1 = new Point(int.Parse(P1X.Text), int.Parse(P1Y.Text));
                P2 = new Point(int.Parse(P2X.Text), int.Parse(P2Y.Text));
                P3 = new Point(int.Parse(P3X.Text), int.Parse(P3Y.Text));

                //получаем координаты области клиппинга
                TL = new Point(int.Parse(TLX.Text), int.Parse(TLY.Text));
                BR = new Point(int.Parse(BRX.Text), int.Parse(BRY.Text));
                //отрисовка осей OX и OY 
                SetXY(bmp, grp);
                //отрисовка треугольника и области клиппинга
                SetTiangle(Scale, P1, P2, P3);
                SetClipping(Scale, TL, BR);
                pictureBox1.Image = bmp;
            }
            catch
            {
                //
            }
        }

        // Изменение координат, необходимо перирисовать область
        private void AllXYClippingChanged(object sender, EventArgs e)
        {
            try
            {
                Point P1, P2, P3, TL, BR;
                //получает координаты вершин треугольника
                P1 = new Point(int.Parse(P1X.Text), int.Parse(P1Y.Text));
                P2 = new Point(int.Parse(P2X.Text), int.Parse(P2Y.Text));
                P3 = new Point(int.Parse(P3X.Text), int.Parse(P3Y.Text));

                //получаем координаты области клиппинга
                TL = new Point(int.Parse(TLX.Text), int.Parse(TLY.Text));
                BR = new Point(int.Parse(BRX.Text), int.Parse(BRY.Text));
                if (BR.X < P3.X)
                {
                    BR.X = P3.X + 1;
                    BRX.Text = BR.X.ToString();
                }

                //очищаем область рисования
                Graphics.FromImage(bmp).Clear(pictureBox1.BackColor);
                pictureBox1.Image = bmp;

                //отрисовка осей OX и OY 
                SetXY(bmp, grp);
                //отрисовка треугольника и области клиппинга
                SetTiangle(Scale, P1, P2, P3);
                SetClipping(Scale, TL, BR);
            }
            catch
            {
                //
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool accept;
            string TriangleDots = "";
            Point P1, P2, P3, TL, BR;
            //очищаем текст
            tB1.Clear();
            //очищаем область рисования
            Graphics.FromImage(bmp).Clear(pictureBox1.BackColor);
            pictureBox1.Image = bmp;

            //получает координаты вершин треугольника
            P1 = new Point(int.Parse(P1X.Text), int.Parse(P1Y.Text));
            P2 = new Point(int.Parse(P2X.Text), int.Parse(P2Y.Text));
            P3 = new Point(int.Parse(P3X.Text), int.Parse(P3Y.Text));

            //получаем координаты области клиппинга
            TL = new Point(int.Parse(TLX.Text), int.Parse(TLY.Text));
            BR = new Point(int.Parse(BRX.Text), int.Parse(BRY.Text));

            Sb = new StringBuilder(tB1.Text);
            //получим координат пересечения для ребра P1P2
            accept = CSAlgoAndClip(P1, P2, TL, BR, out double x, out double y);
            if (accept)
            {
                Sb.AppendLine("Точка пересечения ребра P1P2 с областью клипинга: P1'" +
                              "(" + x.ToString() + "; " + y.ToString() + ")");
                SetDot(x, y, Scale, "P1'");
                pictureBox1.Image = bmp;
                TriangleDots = "P3'(" + x.ToString() + ", " + y.ToString() + ")";
            }
            else
            {
                Sb.AppendLine("Нет пересечения ребра P1P2 с областью клипинга.");
                TriangleDots = "P3(" + P3.X.ToString() + ", " + P3.Y.ToString() + ")";
            }
            //получим координат пересечения для ребра P2P3
            accept = CSAlgoAndClip(P2, P3, TL, BR, out x, out y);
            if (accept)
            {
                Sb.AppendLine("Точка пересечения ребра P2P3 с областью клипинга: P2'" +
                              "(" + x.ToString() + "; " + y.ToString() + ")");
                SetDot(x, y, Scale, "P2'");
                pictureBox1.Image = bmp;
                TriangleDots = String.Concat(TriangleDots, " ") + "P2'(" + x.ToString() + ", " + y.ToString() + ")";
            }
            else
            {
                Sb.AppendLine("Нет пересечения ребра P2P3 с областью клипинга.");
                TriangleDots = String.Concat(TriangleDots, " ") + "P2(" + P2.X.ToString() + ", " + P2.Y.ToString() + ")";
            }
            //получим координат пересечения для ребра P1P3
            accept = CSAlgoAndClip(P1, P3, TL, BR, out x, out y);
            if (accept)
            {
                Sb.AppendLine("Точка пересечения ребра P1P3 с областью клипинга: P1'" +
                              "(" + x.ToString() + "; " + y.ToString() + ")");
                SetDot(x, y, Scale, "P1'");
                pictureBox1.Image = bmp;
                TriangleDots = String.Concat(TriangleDots, " ") + "P1'(" + x.ToString() + ", " + y.ToString() + ")";
            }
            else
            {
                Sb.AppendLine("Нет пересечения ребра P1P3 с областью клипинга.");
                TriangleDots = String.Concat(TriangleDots, " ") + "P1(" + P1.X.ToString() + ", " + P1.Y.ToString() + ")";
            }
            Sb.AppendLine("Координаты треугольника в области клиппинга: ");
            Sb.AppendLine(TriangleDots);
            //!!!!ДОБАВИТЬ ВЫВОД КООРДИНАТ!!!!!
            tB1.Text = Sb.ToString();

            //отрисовка осей OX и OY 
            SetXY(bmp, grp);
            //отрисовка треугольника и области клиппинга
            SetTiangle(Scale, P1, P2, P3);
            SetClipping(Scale, TL, BR);
        }
    }
}

