using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PacmenLabirint
{
    public partial class Form1 : Form
    {
        Random r;
        int[,] ar = new int[10, 10];

        Rectangle [,]rect = new Rectangle[10,10];
        Graphics g;

        Rectangle pacmen;

        

        public Form1()
        {
            InitializeComponent();

            this.g = this.CreateGraphics();
            r = new Random();

            pacmen = new Rectangle(0, 0, 50, 50);
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




            ///for fixed wall;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    rect[i, j] = new Rectangle(i * 50, j * 50, 50, 50);
                }
            }
            g.FillRectangle(Brushes.Yellow, pacmen);

            g.FillRectangle(Brushes.Orange, rect[2, 3]);
            g.FillRectangle(Brushes.Orange, rect[2, 4]);
            g.FillRectangle(Brushes.Orange, rect[3, 4]);



        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {


            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {

                }
            }


            if (e.KeyChar == 's')
                pacmen.Y += 5;

            if (e.KeyChar == 'w')
                pacmen.Y -= 5;

            if (e.KeyChar == 'a')
                pacmen.X -= 5;

            if (e.KeyChar == 'd')
                pacmen.X += 5;

            Refresh();
        }
    }
}
