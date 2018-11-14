using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            A.SunPosition = new Vector(600, 400);
            A.SunRad = 20;
            A.planets.Add(new Planet(152.1, 147.1, 0.298, 7.155, 0.0167, A.SunPosition, 6.738, 1000f, Color.Blue));    //Земля
            A.planets[0].sputniks.Add(new Planet(36.1/2, 40.5/2, 0.802, 23.45, 0.0549, A.planets[0].curCoordPosition, 2.738, 1000f, Color.White));
            A.planets.Add(new Planet(46.001, 69.817, 0.474, 3.38, 0.205, A.SunPosition, 2.439, 1000f, Color.Orange));   //Меркурий
            A.planets.Add(new Planet(107.476, 108.942, 0.3502, 3.86, 0.0068, A.SunPosition, 6.051, 1000f, Color.Orchid));    //Венера
            A.planets.Add(new Planet(249.232/1.25, 206.655/1.25, 0.2413, 5.65, 0.0933, A.SunPosition, 3.396, 1000f,Color.LightSalmon)); // Марс
            A.planets.Add(new Planet(816.520 / 3.3, 740.573 / 3.3, 0.1307 * 2, 6.09, 0.0487, A.SunPosition, 71.492 / 2, 1000f, Color.DarkOrange)); // Юпитер
            A.planets.Add(new Planet(1353.572 / 3.9, 1513.325 / 3.9, 0.0969 * 2, 5.51, 0.055, A.SunPosition, 60.268 / 2, 1000f,Color.Chocolate));//Сатурн
            A.planets.Add(new Planet(2748.938 / 6.3, 3004.419 / 6.3, 0.0661 * 2, 6.48, 0.044, A.SunPosition, 25.559 / 2, 1000f, Color.LightSkyBlue));//Уран
            A.planets.Add(new Planet(4452.940 / 8, 4553.946 / 8, 0.0543 * 2, 6.43, 0.011, A.SunPosition, 24.764 / 2, 1000f, Color.Blue));  //Нептун

            //A.planets.Add();
            timer1.Start();
            timer2.Start();
        }
        PlanetSystem A = new PlanetSystem();

        private void timer1_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            DoubleBuffered = true;
            Bitmap b = A.DrawSystem(Size);
            e.Graphics.DrawImage(b, 0, 0);
            b.Dispose();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            A.Tick();
        }
    }
}
