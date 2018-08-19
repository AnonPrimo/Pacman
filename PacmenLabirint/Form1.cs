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

        Rectangle pacmen;

        

        public Form1()
        {
            InitializeComponent();

            this.g = this.CreateGraphics();
            r = new Random();
            pacmen = new Rectangle(50 + 5, 50 + 5, 35, 35);

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
                    //if (ar[i, j] == 2)
                    //    pacmen = new Rectangle(i * 50 + 5, j * 50 + 5, 35, 35);

                }
            }



            g.FillRectangle(Brushes.Yellow, pacmen);

        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '2')
                pacmen.Y += 1;

            if (e.KeyChar == '8')
                pacmen.Y -= 1;

            if (e.KeyChar == '4')
                pacmen.X -= 1;
                
            if (e.KeyChar == '6')               
                pacmen.X += 1;

            if (Check())
            {
                if (e.KeyChar == '2')
                    pacmen.Y -= 2;

                if (e.KeyChar == '8')
                    pacmen.Y += 2;

                if (e.KeyChar == '4')
                    pacmen.X += 2;

                if (e.KeyChar == '6')
                    pacmen.X -= 2;
            }

            Refresh();
        }


        private bool Check()
        {

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (ar[i, j] == 1)
                    {
                        if ((Math.Abs((pacmen.X + 15) - (rect[i, j].X + 25)) < 40) && (Math.Abs((pacmen.Y + 15) - (rect[i, j].Y + 25)) < 40))
                            return true;
                            //if ((pacmen.X > rect[i, j].X + 50) || (pacmen.X + 50 < rect[i, j].X) || (pacmen.Y < rect[i, j].Y + 50) || (pacmen.Y + 50 > rect[i, j].Y))


                            
                    }  
                }
            }

            return false; //врізається 

        }
    }
}
