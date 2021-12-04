using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Repeat
{
    public abstract class IImpactPoint
    {
        public float X; // ну точка же, вот и две координаты
        public float Y;

        // абстрактный метод с помощью которого будем изменять состояние частиц
        // например притягивать
        public abstract void ImpactParticle(Particle particle);

        // базовый класс для отрисовки точечки
        public abstract void Render(Graphics g);
       
    }
    public class Cirlce : IImpactPoint
    {
        public int R;
        public Color pen;
        public override void Render(Graphics g)
        {
            g.DrawEllipse(new Pen(pen, 4), X-R/2, Y-R/2, R, R);
        }

        public override void ImpactParticle(Particle particle)
        {
            float gX = X - particle.X;
            float gY = Y - particle.Y;
            double r = Math.Sqrt(gX * gX + gY * gY); // считаем расстояние от центра точки до центра частицы


            if (r + particle.Radius < R / 2)  // если частица оказалось внутри окружности
            {
                 particle.FromColor = pen;
              //   particle.ToColor = pen;
            }

           
        }
    }

    public class Teleport : IImpactPoint
    {
        public int R,X2,Y2;
       // public Color pen;
        public override void Render(Graphics g)
        {
            //вход
            g.DrawEllipse(new Pen(Color.Blue, 4), X - R / 2, Y - R / 2, R, R);
            //выход
            g.DrawEllipse(new Pen(Color.Red, 4), X2 - R / 2, Y2 - R / 2, R, R);
           
            Pen pen = new Pen(Color.Green, 4);
            Point[] points =
                     {
               //  new Point(picDisplay.Width/2, picDisplay.Height/2),
                 new Point((int)(X),(int)(Y)),
                 new Point((int)(X2),(int)(Y2)),
             };
            g.DrawLines(pen, points);

        }

        public override void ImpactParticle(Particle particle)
        {
            float gX = X - particle.X;
            float gY = Y - particle.Y;
            double r = Math.Sqrt(gX * gX + gY * gY); // считаем расстояние от центра точки до центра частицы

            //  if (r + particle.Radius < R / 2)  // если частица оказалось внутри окружности
            if (particle.Radius+R>r)
            {
                particle.X = X2;
                particle.Y = Y2;

                particle.SpeedX = -particle.SpeedX;
                particle.SpeedY = -particle.SpeedY;


              //  particle.SpeedX = tbDirection.Value;
            }


        }
    }

    public class GravityPoint : IImpactPoint
    {
        public int Power = 100; // сила притяжения

        // а сюда по сути скопировали с минимальными правками то что было в UpdateState
        public override void ImpactParticle(Particle particle)
        {
            float gX = X - particle.X;
            float gY = Y - particle.Y;
            float r2 = (float)Math.Max(100, gX * gX + gY * gY);

            particle.SpeedX += gX * Power / r2;
            particle.SpeedY += gY * Power / r2;
        }
        public override void Render(Graphics g)
        {
            
            g.FillEllipse(
                    new SolidBrush(Color.Red),
                    X - 5,
                    Y - 5,
                    10,
                    10
                );
            
        }
    }

    public class AntiGravityPoint : IImpactPoint
    {
        public int Power = 100; // сила отторжения

        // а сюда по сути скопировали с минимальными правками то что было в UpdateState
        public override void ImpactParticle(Particle particle)
        {
            float gX = X - particle.X;
            float gY = Y - particle.Y;
            float r2 = (float)Math.Max(100, gX * gX + gY * gY);

            particle.SpeedX -= gX * Power / r2; // тут минусики вместо плюсов
            particle.SpeedY -= gY * Power / r2; // и тут
        }
        public override void Render(Graphics g)
        {

            g.FillEllipse(
                    new SolidBrush(Color.Red),
                    X - 5,
                    Y - 5,
                    10,
                    10
                );

        }
    }
}
