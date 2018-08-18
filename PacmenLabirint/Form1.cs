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
        int[,] ar = new int[10, 10];

        Rectangle [,]rect = new Rectangle[10,10];
        Graphics g = new Graphics();


        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    rect[i, j] = new Rectangle(i * 50, j * 50, 50, 50);
                    
                }
            }
        }
    }
}
