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
      //  List<Emitter> emitters = new List<Emitter>();
      //  List<Emitter> snowfall = new List<Emitter>();
        Emitter emitter,emitter2, emitter8;
        Emitter snow;
        Cirlce cirlce1, cirlce2, cirlce3, cirlce4, cirlce5, cirlce6, cirlce7;
        Teleport tp;
        Radar rad;
        public Form1()
        {
            InitializeComponent();
            // привязал изображение
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);
            picDisplay.MouseWheel += picDisplay_MouseWheel;

            rad = new Radar
            {
                X = picDisplay.Width+200,
                Y = picDisplay.Height+200,
                R = 75,              
            };

            emitter8 = new Emitter
            {
                Direction = 90,
                Spreading = 90,
                SpeedMin = 8,
                SpeedMax = 15,
                ParticlesPerTick = 10,
                LifeMax=120,

                //       ColorFrom = Color.Gold,
                ColorFrom = Color.Gold,
                ColorTo = Color.FromArgb(0, Color.Red),
          
                X = picDisplay.Width / 2,
                Y = picDisplay.Height / 2,

            };

            emitter8.impactPoints.Add(rad);


            snow = new TopEmitter
            {
                Width = picDisplay.Width,
                GravitationY = 0.25f,

             //   ColorFrom = Color.Gold,
             //  ColorTo = Color.FromArgb(0, Color.AliceBlue),
            };
            emitter2 = new Emitter // создаю эмиттер и привязываю его к полю emitter
            {
                Direction = 0,
                Spreading = 10,
                SpeedMin = 5,
                SpeedMax = 20,
                //       ColorFrom = Color.Gold,
                ColorFrom = Color.Red,
                ColorTo = Color.FromArgb(0, Color.Yellow),
                ParticlesPerTick = 3,
                X = picDisplay.Width / 2,
                Y = picDisplay.Height / 5,

            };

            tp = new Teleport
            {
                X = picDisplay.Width / 2,
                Y = picDisplay.Height / 2,
                R = 75,
                X2 = picDisplay.Width / 2,
                Y2 = picDisplay.Height * 7 / 10,
            };

            emitter2.impactPoints.Add(tp);

            emitter = new Emitter // создаю эмиттер и привязываю его к полю emitter
            {
                Direction = 0,
                Spreading = 10,
                SpeedMin = 10,
                SpeedMax = 10,
             //   ColorFrom = Color.Gold,
                ColorFrom = Color.BlueViolet,
                ColorTo = Color.FromArgb(0, Color.AliceBlue),
              //  ColorFrom = Color.Pink,
              //  ColorTo = Color.FromArgb(0, Color.),
                ParticlesPerTick = 1,
                X = picDisplay.Width / 2,
                Y = picDisplay.Height / 2+ Ycirlce/2,
            };
         //   */
          //  emitters.Add(this.emitter);
         //   snowfall.Add(snow);


            cirlce2= new Cirlce
            {
                X = picDisplay.Width / 2 ,
                Y = picDisplay.Height * 7 / 10,
                R = 100,
                pen=Color.Red
            };
            cirlce4 = new Cirlce
            {
                X = picDisplay.Width / 4,
                Y = picDisplay.Height*2 / 5,
                R = 70,
                pen = Color.Yellow
            };
            cirlce3 = new Cirlce
            {
                X = picDisplay.Width * 4 / 5+15,
                Y = picDisplay.Height * 7 / 10,
                R = 100,
                pen = Color.Lime
            };
            cirlce6 = new Cirlce
            {
                X = picDisplay.Width * 3 / 4,
                Y = picDisplay.Height*2 / 5,
                R = 70,
                pen = Color.OrangeRed
            };
            cirlce7 = new Cirlce
            {
                X = picDisplay.Width / 2,
                Y = picDisplay.Height / 5,
                R = 55,
                pen = Color.Purple
            };
            cirlce1 = new Cirlce
            {
                X = picDisplay.Width / 5 - 10,
                Y = picDisplay.Height * 7 / 10,
                R = 100,
                pen = Color.Blue
            };
            cirlce5 = new Cirlce
            {
                X = picDisplay.Width / 2,
                Y = picDisplay.Height*2 / 5,
                R = 70,
                pen = Color.HotPink
            };
            snow.impactPoints.Add(cirlce1);
            snow.impactPoints.Add(cirlce2);
            snow.impactPoints.Add(cirlce3);
            snow.impactPoints.Add(cirlce4);
            snow.impactPoints.Add(cirlce5);
            snow.impactPoints.Add(cirlce6);
            snow.impactPoints.Add(cirlce7);
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
            switch (task)
            {
                case 1:
                    emitter.UpdateState();// каждый тик обновляем систему
                    break;
                case 2:
                    emitter.UpdateState();
                    break;
                case 4:
                    emitter2.UpdateState();
                    break;
                case 5:
                    snow.UpdateState();
                    break;
                case 8:
                    rad.counter = 0;
                    emitter8.UpdateState();
                   
                    break;
            }

            using (var g = Graphics.FromImage(picDisplay.Image))
            {

                   g.Clear(Color.FromArgb(0, 0, 0, 0));
                //  picDisplay.Image = null;
             //   picDisplay.InitialImage = null;
                //    picDisplay.BackgroundImage = Properties.Resources.handsome;                
                 //  picDisplay.Image = Properties.Resources.handsome;

              //  emitter.Render(g); // рендерим систему

               // snow.Render(g);

                 switch (task)
                 {
                     case 1:
                         task1(g);
                        emitter.Render(g);
                        break;
                     case 2:
                         task2();
                        emitter.Render(g);
                        break;
                    case 4:
                        emitter2.Render(g);
                        break;
                    case 5:
                        snow.Render(g);
                       // task5(g);
                        t5b = tbDirection.Value;
                        break;
                    case 8:
                        emitter8.Render(g);

                        break;
                 }
                
              
            }

            picDisplay.Invalidate();
        }

     //   private int MousePositionX = 0;
      //  private int MousePositionY = 0;

        private void picDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            if (task == 8)
            {
                rad.X = e.X;
                rad.Y = e.Y;
            }        

        }

        private void picDisplay_MouseWheel(object sender, MouseEventArgs e)
        {
            if (task == 8)
            {
                if (e.Delta > 0) 
                { 
                    rad.R = rad.R + 5; 
                }
                    
                else 
                {
                    if (rad.R > 30) 
                    { 
                        rad.R = rad.R - 5;
                    }
                    
                }
                    
            }
           
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
                case 5:
                    cirlce7.Y = picDisplay.Height/5 + picDisplay.Height*3 /200 * tbDirection.Value;
                    cirlce1.Y = picDisplay.Height*7 / 10 - picDisplay.Height / 40 * tbDirection.Value;
                    cirlce2.Y = picDisplay.Height*7 / 10 - picDisplay.Height / 40 * tbDirection.Value;
                    cirlce3.Y = picDisplay.Height*7 / 10 - picDisplay.Height / 40 * tbDirection.Value;
                    cirlce4.Y = picDisplay.Height * 2 / 5 + picDisplay.Height*3 / 200 * tbDirection.Value;
                    cirlce5.Y = picDisplay.Height * 2 / 5 + picDisplay.Height*3 / 200 * tbDirection.Value;
                    cirlce6.Y = picDisplay.Height * 2 / 5 + picDisplay.Height*3 / 200 * tbDirection.Value;

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

        private void button8_Click(object sender, EventArgs e)
        {
            task = 8;

            label2.Visible = false;
            speedBar.Visible = false;
            label4.Visible = false;
            label3.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            trackBar1.Visible = false;
            trackBar2.Visible = false;
            trackBar3.Visible = false;


        }

        private void picDisplay_MouseClick(object sender, MouseEventArgs e)
        {
            if ((e.Button == MouseButtons.Left)&(task == 4))
            {
                tp.X = e.X;
                tp.Y = e.Y;
            }
            if ((e.Button == MouseButtons.Right)&(task == 4))
            {
                tp.X2 = e.X;
                tp.Y2 = e.Y;
            }
        }
       
        private void button4_Click(object sender, EventArgs e)
        {
            task = 4;
            /*
            emitter.X = picDisplay.Width / 2;
            emitter.Y = picDisplay.Height / 5;
            
            emitter.Direction = 0;
            emitter.Spreading = 0;
            emitter.SpeedMax = 10;
            emitter.LifeMax = 100;
            emitter.ParticlesPerTick = 3;
            */

            label1.Text = "Направление";
            tbDirection.Maximum = 359;
            tbDirection.Minimum = 0;
            tbDirection.Value = 180;

            label2.Visible = false;
            speedBar.Visible = false;
            label4.Visible = false;
            label3.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            trackBar1.Visible = false;
            trackBar2.Visible = false;
            trackBar3.Visible = false;

        }

        int tb1 =3, tb2=3,t5b=1;

        private void button1_Click(object sender, EventArgs e)
        {
           // int tbdValue = 10;
            task = 1;
            tbDirection.Maximum = 300;
            tbDirection.Minimum = 100;

            // tbDirection.Value = 100;
            tbDirection.Value = tbdValue1;
            trackBar2.Value = tb1;

            label1.Text = "Радиус";
            label2.Text = "Скорость";
            speedBar.Maximum = 30;
            speedBar.Minimum = 10;

            // speedBar.Value = 10;
            speedBar.Value = speedV1;

            emitter.SpeedMin = 5;
            emitter.SpeedMax = 20;

            label2.Visible = true;
            speedBar.Visible = true;
            label4.Visible = true;
            trackBar2.Visible = true;

            label3.Visible = false;
           // label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            trackBar1.Visible = false;
           // trackBar2.Visible = false;
            trackBar3.Visible = false;

            emitter.LifeMax = 120;
            //  emitter.ParticlesPerTick = 3;
            emitter.ParticlesPerTick = tb1;
            emitter.SpeedMax = 20;

            emitter.ColorFrom = Color.BlueViolet;
            emitter.ColorTo = Color.FromArgb(0, Color.AliceBlue);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            task = 2;
            tbDirection.Maximum = 359;
            tbDirection.Minimum = 0;

            //  tbDirection.Value = 100;
            tbDirection.Value = tbdValue2;
            trackBar2.Value = tb2;

            label1.Text = "Направление";
            label2.Text = "Распределение";
            speedBar.Maximum = 360;
            speedBar.Minimum = 40;

            // speedBar.Value = 100;
            speedBar.Value = speedV2;

            emitter.X = picDisplay.Width / 2;
            emitter.Y = picDisplay.Height / 2;

            label2.Visible = true;
            speedBar.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            trackBar1.Visible = true;
            trackBar2.Visible = true;
            trackBar3.Visible = true;

            emitter.LifeMax = trackBar3.Value;
            emitter.ParticlesPerTick = tb2;
            emitter.SpeedMax = trackBar1.Value;
            emitter.Spreading = speedBar.Value;
            emitter.Direction = tbDirection.Value;

            emitter.ColorFrom = Color.Blue;
            emitter.ColorTo = Color.FromArgb(0, Color.DarkBlue);
        }

        int Xvector1, Xvector2, Yvector1, Yvector2;

        private void button5_Click(object sender, EventArgs e)
        {
            task = 5;

            label1.Text = "Изменить положение кругов";

            snow.ParticlesPerTick =3;
            snow.ParticlesCount = 3000;
            snow.LifeMax =160;

            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            trackBar1.Visible = false;
            trackBar2.Visible = false;
            trackBar3.Visible = false;
            speedBar.Visible = false;

            tbDirection.Maximum = 20;
            tbDirection.Minimum = 1;
            tbDirection.Value = t5b;
        }

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
                    //--
                    emitter.ParticlesPerTick = trackBar2.Value;
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
        /*
        private void task5(Graphics g)
        {
            t5b = tbDirection.Value;
            /*
            g.DrawEllipse(new Pen(Color.Red, 4), picDisplay.Width / 2-25, picDisplay.Height / 2-25 ,50 ,50 );
            g.DrawEllipse(new Pen(Color.Yellow, 4), picDisplay.Width / 4, picDisplay.Height / 8, 45, 45);
            g.DrawEllipse(new Pen(Color.Lime, 4), picDisplay.Width*3 /5 , picDisplay.Height*3 / 4-20, 90, 90);
            g.DrawEllipse(new Pen(Color.OrangeRed, 4), picDisplay.Width*3 / 4, picDisplay.Height / 4, 45, 45);
            g.DrawEllipse(new Pen(Color.Purple, 4), picDisplay.Width * 3 / 4-200, picDisplay.Height *3/ 4, 37, 37);
            g.DrawEllipse(new Pen(Color.Blue, 4), picDisplay.Width / 5-20, picDisplay.Height / 3, 100, 100);
            g.DrawEllipse(new Pen(Color.HotPink, 4), picDisplay.Width /2+200, picDisplay.Height / 8 , 40, 40);
            
        }
        */
        private void task2()
        {
             label6.Text= "Количество частиц "+ emitter.count;
             //Xvector1 = particles.Count;
            tbdValue2= tbDirection.Value ;
            speedV2 = speedBar.Value;
            tb2= trackBar2.Value;
        }

        private void task1(Graphics g)
        {
            //emitter.GravitationY = (float)(0.5);
            tbdValue1 = tbDirection.Value;
            speedV1 = speedBar.Value;
            tb1 = trackBar2.Value;

            g.DrawEllipse(new Pen(Color.LightCoral,4), picDisplay.Width / 2 - Xcirlce / 2, picDisplay.Height / 2 - Ycirlce / 2+1, Xcirlce, Ycirlce);
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

           
        }

    }
}
