using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Repeat
{
    public partial class Form1 : Form
    {
        //List<Particle> particles = new List<Particle>();

        List<Emitter> emitters = new List<Emitter>();
        Emitter emitter;
      //  Emitter emitter1;

        public Form1()
        {
            InitializeComponent();
            // привязал изображение
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);
            /*
            emitter1 = new TopEmitter
            {
                Width = picDisplay.Width,
                GravitationY = 0.25f
            };
            */

          //  /*
            this.emitter = new Emitter // создаю эмиттер и привязываю его к полю emitter
            {
                Direction = 0,
                Spreading = 10,
                SpeedMin = 10,
                SpeedMax = 10,
                // ColorFrom = Color.Gold,
                ColorFrom = Color.Pink,
                ColorTo = Color.FromArgb(0, Color.Red),
                ParticlesPerTick = 10,
                X = picDisplay.Width / 2,
                Y = picDisplay.Height / 2+ Ycirlce/2,
            };
          //  */
            emitters.Add(this.emitter);
          //  emitters.Add(this.emitter1);
            /*
            emitter.impactPoints.Add(new GravityPoint
            {
                X = (float)(picDisplay.Width * 0.25),
                Y = picDisplay.Height / 2
            });

            // в центре антигравитон
            emitter.impactPoints.Add(new AntiGravityPoint
            {
                X = picDisplay.Width / 2,
                Y = picDisplay.Height / 2
            });

            // снова гравитон
            emitter.impactPoints.Add(new GravityPoint
            {
                X = (float)(picDisplay.Width * 0.75),
                Y = picDisplay.Height / 2
            });
            */

        }

       
        private void timer1_Tick(object sender, EventArgs e)
        {
            emitter.UpdateState(); // каждый тик обновляем систему

            using (var g = Graphics.FromImage(picDisplay.Image))
            {
                g.Clear(Color.Black);
                emitter.Render(g); // рендерим систему
                task1(g);
               

            }

            picDisplay.Invalidate();
        }

        private int MousePositionX = 0;
        private int MousePositionY = 0;

        private void picDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            emitter.MousePositionX = e.X;
            emitter.MousePositionY = e.Y;
        }


        int Xcirlce=100;
        int Ycirlce=100;
        double pos=1,speed=0.1,m,n;
       
        private void tbDirection_Scroll(object sender, EventArgs e)
        {
          //  emitter.Direction = tbDirection.Value;
          //  lblDirection.Text = $"{tbDirection.Value}°";
          Xcirlce = tbDirection.Value;
          Ycirlce = Xcirlce;
            // emitter.X = Xcirlce;
            //  emitter.Y = Ycirlce;
            
        }


        private void speedBar_Scroll(object sender, EventArgs e)
        {
            m = speedBar.Value;
            n = 100;          
            speed = m / n;
          //  speed = speedBar.Value / 100;
        }

        int Xvector1, Xvector2, Yvector1, Yvector2;
        double angle;

        // Vector vector1 = new Vector(20, 30);
        // Vector vector2 = new Vector(45, 70);

        private void task1(Graphics g)
        {
          //  emitter.GravitationY = (float)(0.5);
            emitter.SpeedMin = 5;
            emitter.SpeedMax = 20;

            g.DrawEllipse(new Pen(Color.Yellow), picDisplay.Width / 2 - Xcirlce / 2, picDisplay.Height / 2 - Ycirlce / 2, Xcirlce, Ycirlce);
            pos = pos + speed;

            emitter.X = (int)(picDisplay.Width / 2 + Xcirlce / 2 * Math.Cos(pos));
            emitter.Y = (int)(picDisplay.Height / 2 + Ycirlce / 2 * Math.Sin(pos));
            //координаты вектора радиуса
            Xvector1 = picDisplay.Width / 2 - emitter.X;
            Yvector1 = picDisplay.Height / 2 - emitter.Y;
            //координаты вектора касательной
            //   x = 0-(emitter.Y - picDisplay.Height / 2);
            //   y = emitter.X - picDisplay.Width / 2;
            Yvector2 = -5;
            Xvector2 = 5 - emitter.Y;
            //  angle = (180 /Math.PI)*Math.Acos(Math.Cos((Yvector1*Yvector2)/(Math.Sqrt(Math.Pow(Yvector2, 2) )* Math.Sqrt(Math.Pow(Xvector1,2)+ Math.Pow(Yvector1, 2)))));
            angle = (290 / Math.PI) * Math.Acos(Math.Cos((Yvector1 * Yvector2 + Xvector2 * Xvector1) / (Math.Sqrt(Math.Pow(Yvector2, 2) + Math.Pow(Xvector2, 2)) * Math.Sqrt(Math.Pow(Xvector1, 2) + Math.Pow(Yvector1, 2)))));
            
            if (emitter.X < picDisplay.Width / 2 & emitter.Y > picDisplay.Height / 2) 
            { 
            emitter.Direction = -(int)(angle);
            }
            if (emitter.X < picDisplay.Width / 2 & emitter.Y < picDisplay.Height / 2)
            {
                emitter.Direction = 180+(int)(angle);
            }
            if (emitter.X > picDisplay.Width / 2 & emitter.Y < picDisplay.Height / 2)
            {
                emitter.Direction = 180-(int)(angle);
            }
            if (emitter.X > picDisplay.Width / 2 & emitter.Y > picDisplay.Height / 2)
            {
                emitter.Direction = (int)(angle);
            }
            emitter.Spreading = 100;

           // label3.Text = angle.ToString();                    
            /*
            Pen pen = new Pen(Color.Red, 3);          
            Point[] points =
                     {
                 new Point(picDisplay.Width/2, picDisplay.Height/2),
                 new Point(emitter.X, emitter.Y),
                 new Point(emitter.Y-5, emitter.Y),
             };
            g.DrawLines(pen, points);
            */

        }

    }
}
