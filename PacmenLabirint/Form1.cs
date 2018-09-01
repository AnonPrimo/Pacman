using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace PacmenLabirint
{
    public partial class Form1 : Form
    {
        Random r;
        int[,] ar = { 
        { 1, 1, 1, 1, 1, 0, 0, 0, 1, 1 },
        { 0, 0, 1, 0, 0, 0, 1, 0, 0, 0 },
        { 1, 0, 1, 2, 1, 0, 1, 1, 1, 0 },
        { 1, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
        { 0, 0, 1, 0, 1, 1, 1, 1, 0, 1 },
        { 0, 1, 1, 0, 0, 0, 0, 0, 0, 1 },
        { 0, 0, 0, 0, 1, 1, 1, 1, 0, 1 },
        { 0, 1, 1, 1, 1, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 1, 1, 1, 0 },
        { 1, 1, 1, 1, 1, 0, 0, 0, 0, 0 }
        };

        Rectangle [,]rect = new Rectangle[10,10];
        Graphics g;
        Bitmap pacman_0;
        Bitmap pacman_1;
        Bitmap pacman_2;
        Bitmap pacman_3;

        Rectangle pacmen;

        

        public Form1()
        {
            InitializeComponent();

            this.g = this.CreateGraphics();
            r = new Random();
            pacmen = new Rectangle(50 + 5, 50 + 5, 30, 30);
            pacman_0 = Properties.Resources.sprite_0;
            pacman_1 = Properties.Resources.sprite_1;
            pacman_2 = Properties.Resources.sprite_2;
            pacman_3 = Properties.Resources.sprite_3;

            g.DrawImage(pacman_0, pacmen.X, pacmen.Y);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            ///for random wall
            //for (int i = 0; i < 10; i++)
            //{
            //    for (int j = 0; j < 10; j++)
            //    {
            //        ar[i, j] = r.Next(0, 2);

            //        rect[i, j] = new Rectangle(i * 50, j * 50, 50, 50);

            //        if (ar[i, j] == 0)
            //        {
            //            g.FillRectangle(Brushes.Orange, rect[i, j]);
            //        }
            //    }
            //}

            


            /////for fixed wall;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    rect[i, j] = new Rectangle(i * 50, j * 50, 50, 50);

                    if (ar[i, j] == 1)
                    {
                        g.FillRectangle(Brushes.Orange, rect[i, j]);
                    }
                   
                }
            }

            timer1.Interval = 1;
            timer1.Enabled = true;

            g.FillRectangle(Brushes.Yellow, pacmen);
            g.DrawImage(pacman_0, pacmen.X, pacmen.Y);
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if(e.KeyChar == '2' || e.KeyChar == '6' || e.KeyChar == '4' || e.KeyChar == '8')
            //while (!Check())
            //{
                   switch (e.KeyChar)
                    {
                        case '2': 
                           pacmen.Y += 1;
                            break;
                        case '8':
                            pacmen.Y -= 1;
                            break;
                        case '4':
                            pacmen.X -= 1;
                            break;
                        case '6':
                            pacmen.X += 1;
                            break;
                        default:
                            break;
                    }
                    
                if (Check())
             {
                if (e.KeyChar == '2')
                    pacmen.Y -= 1;

                if (e.KeyChar == '8')
                    pacmen.Y += 1;

                if (e.KeyChar == '4')
                    pacmen.X += 1;

                if (e.KeyChar == '6')
                    pacmen.X -= 1;
                   // break;
             }
                    Thread.Sleep(20);
                g.DrawImage(pacman_0, pacmen.X, pacmen.Y);
                
           // }

        }


        private bool Check()
        {

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (ar[i, j] == 1)
                    {
                        if ((Math.Abs((pacmen.X + 15) - (rect[i, j].X + 25)) < 40) && (Math.Abs((pacmen.Y + 15) - (rect[i, j].Y + 25)) < 40) ||
                            pacmen.Y == 0 || pacmen.Y + 30 == 500 || pacmen.X == 0 || pacmen.X + 30 == 500)
                            return true;
                    }  
                }
            }

            return false; //врізається 

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

               // g.DrawImage(pacman_0, pacmen.X, pacmen.Y);
           

        }
    }
}
