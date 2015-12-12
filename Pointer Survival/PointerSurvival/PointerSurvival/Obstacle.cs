using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointerSurvival
{
    class Obstacle
    {
        public static Random random = new Random();
        public static int SafeDistance = 250;
        public PictureBox obj { get; set; }

        public int Number { get; set; } = 0;

        private int speed;

        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }
        private bool isActice;
        private int direction;

        public int Direction
        {
            get { return direction; }
            set { direction = value; }
        }
        private int targetX, targetY;
        public int Size { get; set; }

        public Obstacle()
        {
            while (Number == 0)
            {
                Number = random.Next(15) - 4;
            }

            int x = random.Next(1000);
            int y = random.Next(500);

            while (Math.Abs(x - Form.MousePosition.X) < SafeDistance)
            {
                x = random.Next(1000);
            }
            while (Math.Abs(y - Form.MousePosition.Y) < SafeDistance)
            {
                y = random.Next(500);
            }
            obj = new PictureBox();
            Bitmap bmp = new Bitmap(PointerSurvival.Properties.Resources.obstacle);
            Point location = new Point(x, y);
            Graphics g = Graphics.FromImage(bmp);
            Size = random.Next(50, 200);

            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;

            string symbol;
            if (Number > 0)
            {
                symbol = Number.ToString();
            }
            else
            {
                if (Number == Calculation.Plus)
                {
                    symbol = "+";
                }
                else if(Number == Calculation.Minus)
                {
                    symbol = "-";
                }
                else if(Number == Calculation.Multiply)
                {
                    symbol = "*";
                }
                else
                {
                    symbol = "/";
                }
            }

            g.DrawString(symbol, new Font("Tahoma", 20), Brushes.Black, new Point(20,20));

            g.Flush();

            obj.Image = bmp; 
            obj.Location = location;
            obj.Size = new Size(Size, Size);
            obj.SizeMode = PictureBoxSizeMode.StretchImage;
            isActice = true;
            speed = random.Next(1,4);
            //PictureBox mainSprite = new PictureBox();
            //mainSprite.Size = new Size(Size,Size);
            
            //while(Math.Abs(x - Form.MousePosition.X) < SafeDistance)
            //{
            //    x = random.Next(1000);
            //}
            //while (Math.Abs(y - Form.MousePosition.Y) < SafeDistance)
            //{
            //    y = random.Next(500);
            //}
            //mainSprite.Location = new Point(x,y);
            //mainSprite.Image = PointerSurvival.Properties.Resources.obstacle1;
            //mainSprite.SizeMode = PictureBoxSizeMode.StretchImage;
            //mainSprite.BackColor = Color.Transparent;
            //obj = mainSprite;
            goX = Form.MousePosition.X > obj.Left;
            goY = Form.MousePosition.Y > obj.Top;
            Move();
        }

        private bool goX;
        private bool goY;
        public bool Move()
        {
            if (isActice)
            {
                //Check X coord
                if (goX)
                {
                    obj.Left += speed;
                }
                else
                {
                    obj.Left -= speed;
                }

                //Check Y coord
                if (goY)
                {
                    obj.Top += speed;
                }
                else
                {
                    obj.Top -= speed;
                }
               
            }
            


            return isHit();
        }

        public void Bounce(Obstacle o)
        {
            //if (isHit(o))
            //{
            //    if(goX != o.goX)
            //    {
            //        this.goX = !goX;
            //        o.goX = !o.goX;
            //    }
            //    if(goY != o.goY)
            //    {
            //        this.goY = !goY;
            //        o.goY = !o.goY;
            //    }
            //}
        }

        public void Destroy()
        {
            //PictureBox bomb = new PictureBox();
            //bomb.Size = new Size(Size, Size);
            //bomb.Location = obj.Location;
            //bomb.Image = PointerSurvival.Properties.Resources.explosion1;
            //bomb.BackColor = Color.Transparent;
            
            obj.Dispose();
            

        }

        public bool isHit()
        {
            if (isActice)
            {
                if (PointerSurvivalView.pointerBox.Left <= obj.Right && obj.Left <= PointerSurvivalView.pointerBox.Right &&
                            PointerSurvivalView.pointerBox.Top <= obj.Bottom && obj.Top <= PointerSurvivalView.pointerBox.Bottom)
                {
                    isActice = false;
                    return true;
                }
            }
            
            return false;
        }

        public bool isHit(Weapon w)
        {
            if (isActice)
            {
                if (w.obj.Left <= obj.Right && obj.Left <= w.obj.Right &&
                            w.obj.Top <= obj.Bottom && obj.Top <= w.obj.Bottom)
                {
                    isActice = false;
                    return true;
                }
            }
            
            return false;
        }
        public bool isHit(Obstacle w)//hit obstacle
        {
            if (isActice)
            {
                if (w.obj.Left <= obj.Right && obj.Left <= w.obj.Right &&
                                            w.obj.Top <= obj.Bottom && obj.Top <= w.obj.Bottom)
                {
                    isActice = false;
                    return true;
                }
            }
            
            return false;
        }
    }
}
