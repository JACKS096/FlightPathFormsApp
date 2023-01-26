using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlightPathFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Задание параметров полета скорости и угла полета соответственно
            double speed = 50; // m/s 
            double angle = 30; // degrees

            // Расчеты скорости по X и Y направлениям с учетом угла полета: 

            double xSpeed = speed * Math.Cos(angle * Math.PI / 180); // m/s  
            double ySpeed = speed * Math.Sin(angle * Math.PI / 180); // m/s  

            // Начальные координаты:  

            int x = 0;
            int y = 0;

            // Объявляем Pen, которым будем рисовать:  

            Pen pen = new Pen(Color.Red);
            Graphics g = this.CreateGraphics();
            while (y < ClientSize.Height)
            {
               
                g.DrawLine(pen, x, ClientSize.Height - y, x + 1, ClientSize.Height - y + 1);

                x += (int)xSpeed;    // m/s -> px/frame    
                y += (int)ySpeed;    // m/s -> px/frame    

                this.Refresh();      // Refresh form for redraw line    

                Application.DoEvents();    // Process events    

                System.Threading.Thread.Sleep(10);    // Delay 10 ms for smooth drawing    
            }
        }
    }
}
