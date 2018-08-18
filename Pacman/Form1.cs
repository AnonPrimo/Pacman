using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman
{
    public partial class Form1 : Form
    {
        System.Drawing.Bitmap sky, plane;

        Graphics g;

        int dx;

        Rectangle rct;
        Rectangle rct1;


        Boolean demo = true;

        System.Random r;

        public Form1()
        {
            InitializeComponent();

            try
            {
                sky = Properties.Resources.bl;
                plane = Properties.Resources.plane1;
                this.BackgroundImage = Properties.Resources.bl;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Полет", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            plane.MakeTransparent();

            this.ClientSize = new System.Drawing.Size(new Point(BackgroundImage.Width, BackgroundImage.Height));

            g = Graphics.FromImage(BackgroundImage);

            r = new System.Random();

            rct.X = -40;
            rct.Y = 20 + r.Next(20);

            rct.Width = plane.Width;
            rct.Height = plane.Height;

            ///----------------------------------------------
            rct1.X = -40;
            rct1.Y = 150 + r.Next(30);

            rct1.Width = plane.Width;
            rct1.Height = plane.Height;
            ///----------------------------------------------

            dx = 2;

            timer1.Interval = 20;
            timer1.Enabled = true;

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            g.DrawImage(sky, new Point(0, 0));

            if (rct.X < this.ClientRectangle.Width)
                rct.X += dx;
            else
            {
                rct.X = -40;
                rct.Y = 20 + r.Next(40);

                dx = 2 + r.Next(4);
            }

            g.DrawImage(plane, rct.X, rct.Y);

            if (!demo)
                this.Invalidate(rct);
            else
            {
                Rectangle reg = new Rectangle(20, 20, sky.Width - 40, sky.Height - 40);

                g.DrawRectangle(Pens.Black, reg.X, reg.Y, reg.Width - 1, reg.Height - 1);

                this.Invalidate(reg);
            }


            ///--------------------------------------------
            if (rct1.X < this.ClientRectangle.Width)
                rct1.X += dx;
            else
            {
                rct1.X = -40;
                rct1.Y = 150 + r.Next(50);

                dx = 2 + r.Next(4);
            }

            g.DrawImage(plane, rct1.X, rct1.Y);

        }
    }
}
