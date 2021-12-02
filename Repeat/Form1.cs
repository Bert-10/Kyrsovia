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
        public int task = 1;
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
                 ColorFrom = Color.Gold,
              //  ColorFrom = Color.Pink,
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

                   g.Clear(Color.FromArgb(0, 0, 0, 0));
                //  picDisplay.Image = null;
             //   picDisplay.InitialImage = null;
                //    picDisplay.BackgroundImage = Properties.Resources.handsome;                
                 //  picDisplay.Image = Properties.Resources.handsome;

                emitter.Render(g); // рендерим систему
                
                 switch (task)
                 {
                     case 1:
                         task1(g);
                         break;
                     case 2:
                         task2();
                         break;
                 }
                
              
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
                       
            switch (task)
            {
                case 1:
                    Xcirlce = tbDirection.Value;
                    Ycirlce = Xcirlce;
                    break;
                case 2:
                    emitter.Direction = tbDirection.Value;
                    break;
            }
            
          
            // emitter.X = Xcirlce;
            //  emitter.Y = Ycirlce;
            
        }


        private void speedBar_Scroll(object sender, EventArgs e)
        {
            switch (task)
            {
                case 1:
                    m = speedBar.Value;
                    n = 100;
                    speed = m / n;
                    break;
                case 2:
                    emitter.Spreading= speedBar.Value;
                    break;
            }
                     
            //  speed = speedBar.Value / 100;
        }

        int tbdValue1 = 100, tbdValue2=0,speedV1=10, speedV2 = 100;

        private void button1_Click(object sender, EventArgs e)
        {
           // int tbdValue = 10;
            task = 1;
            tbDirection.Maximum = 300;
            tbDirection.Minimum = 100;

            // tbDirection.Value = 100;
            tbDirection.Value = tbdValue1;

            label1.Text = "Радиус";
            label2.Text = "Скорость";
            speedBar.Maximum = 30;
            speedBar.Minimum = 10;

            // speedBar.Value = 10;
            speedBar.Value = speedV1;

            emitter.SpeedMin = 5;
            emitter.SpeedMax = 20;

            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            trackBar1.Visible = false;
            trackBar2.Visible = false;
            trackBar3.Visible = false;

            emitter.LifeMax = 120;
            emitter.ParticlesPerTick = 3;
            emitter.SpeedMax = 20;
        

        }

        private void button2_Click(object sender, EventArgs e)
        {
            task = 2;
            tbDirection.Maximum = 359;
            tbDirection.Minimum = 0;

            //  tbDirection.Value = 100;
            tbDirection.Value = tbdValue2;

            label1.Text = "Направление";
            label2.Text = "Распределение";
            speedBar.Maximum = 360;
            speedBar.Minimum = 40;

            // speedBar.Value = 100;
            speedBar.Value = speedV2;

            emitter.X = picDisplay.Width / 2;
            emitter.Y = picDisplay.Height / 2;

            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            trackBar1.Visible = true;
            trackBar2.Visible = true;
            trackBar3.Visible = true;

            emitter.LifeMax = trackBar3.Value;
            emitter.ParticlesPerTick = trackBar2.Value;
            emitter.SpeedMax = trackBar1.Value;
            emitter.Spreading = speedBar.Value;
            emitter.Direction = tbDirection.Value;

        }

        int Xvector1, Xvector2, Yvector1, Yvector2;

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            switch (task)
            {
                case 1:
                   
                    break;
                case 2:
                    emitter.LifeMax = trackBar3.Value;
                    break;
            }
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            switch (task)
            {
                case 1:

                    break;
                case 2:
                    emitter.ParticlesPerTick = trackBar2.Value;
                    break;
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            switch (task)
            {
                case 1:

                    break;
                case 2:
                    emitter.SpeedMax = trackBar1.Value;
                    break;
            }
        }

        double angle;

        private void task2()
        {
             label6.Text= "Количество частиц "+ emitter.count;
             //Xvector1 = particles.Count;
            tbdValue2= tbDirection.Value ;
            speedV2 = speedBar.Value;
        }

        private void task1(Graphics g)
        {
            //  emitter.GravitationY = (float)(0.5);
            tbdValue1 = tbDirection.Value;
            speedV1 = speedBar.Value;

            g.DrawEllipse(new Pen(Color.Purple,3), picDisplay.Width / 2 - Xcirlce / 2, picDisplay.Height / 2 - Ycirlce / 2, Xcirlce, Ycirlce);
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
