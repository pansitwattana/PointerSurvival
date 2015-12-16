using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PointerSurvival
{
    class Star
    {
        public float x, y, vx, vy, radius;
        public Brush brush;

        public Star(int gameWidth, int gameHeigth, Random r)
        {
            //var r = new Random();

            x = r.Next(gameWidth);
            y = r.Next(gameHeigth);

            vx = 1;
            vy = 1;

            radius = r.Next(2) + 1;

            brush = new SolidBrush(Color.FromArgb(r.Next(127) + 127, r.Next(127) + 127, r.Next(127) + 127));
        }
        /*
        public Ball duplicate()
        {
            var b = new Ball()
            {
                x = this.x,
                y = this.y,
                vx = this.vx,
                vy = this.vy,
                radius = this.radius,
                brush = this.brush,
            };
            return b;
        }
        */
        public void move(int gameWidth, int gameHeigth)
        {
            if (x - radius < 0 || x + radius > gameWidth)
            {
                x = Calculation.random.Next(gameWidth);
                y = Calculation.random.Next(gameHeigth);
            }

            if (y - radius < 0 || y + radius > gameHeigth)
            {
                x = Calculation.random.Next(gameWidth);
                y = Calculation.random.Next(gameHeigth);
            }

            this.x += vx;
            this.y += vx;
        }

        public void Draw(Graphics g)
        {
            g.FillEllipse(brush, new RectangleF(x - radius, y - radius, radius * 2, radius * 2));
        }
    }
}
