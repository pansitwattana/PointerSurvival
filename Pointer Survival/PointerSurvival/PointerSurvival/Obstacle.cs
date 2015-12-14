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
        public static int PercentBornHidable = 20;
        public static int PercentBornChanable = 10;
        public static int TimeForExcitation = 50;


        public static Random random = new Random();
        public static int SafeDistance = 250;
        public PictureBox obj { get; set; }
        public Point Position { get; set; }

        public bool isHidable { get; set; }
        public bool isChangable { get; set; }

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
        public int Size { get; set; }

        private int counter = 0;

        public Obstacle(int playerX, int playerY)
        {
            CreateObstacle(playerX, playerY);
        }

        private void CreateObstacle(int playerX, int playerY)
        {
            CreateImageWith(GenerateNumberOrOperator(), RandomLocationWithSafeDistanceFrom(playerX, playerY), random.Next(50, 200), random.Next(1, 4));
            RandomType();
            goX = playerX > obj.Left;
            goY = playerY > obj.Top;
            Update();
        }

        private void CreateImageWith(string symbol, Point point, int size, int speed)
        {
            if(obj == null)
            {
                obj = new PictureBox();
            }
            Bitmap bmp = new Bitmap(PointerSurvival.Properties.Resources.obstacle);
            Point location = point;
            Graphics g = Graphics.FromImage(bmp);
            Size = size;

            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;

            g.DrawString(symbol, new Font("Tahoma", 20), Brushes.Black, new Point(20, 20));

            g.Flush();

            obj.Image = bmp;
            obj.Location = location;
            obj.Size = new Size(Size, Size);
            obj.SizeMode = PictureBoxSizeMode.StretchImage;
            isActice = true;
            this.speed = speed;
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

        }

        private void RandomType()
        {
            if(random.Next(100) < PercentBornHidable)
            {
                CreateImageWith("?", obj.Location, Size, Speed);
                isHidable = true;
            }
            else
            {
                isHidable = false;
            }

            if(random.Next(100) < PercentBornChanable)
            {
                isChangable = true;
            }
            else
            {
                isChangable = false;
            }
        }

        private Point RandomLocationWithSafeDistanceFrom(int playerX, int playerY)
        {
            int x = random.Next(1000);
            int y = random.Next(500);
            while (Math.Abs(x - playerX) < SafeDistance)
            {
                x = random.Next(1000);
            }
            while (Math.Abs(y - playerY) < SafeDistance)
            {
                y = random.Next(500);
            }

            return new Point(x, y);
        }

        private string GenerateNumberOrOperator()
        {
            Number = random.Next(15) - 4;

            while (Number == 0)
            {
                Number = random.Next(15) - 4;
            }

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
                else if (Number == Calculation.Minus)
                {
                    symbol = "-";
                }
                else if (Number == Calculation.Multiply)
                {
                    symbol = "*";
                }
                else
                {
                    symbol = "/";
                }
            }
            return symbol;
        }

        private bool goX;
        private bool goY;

        public void RunAbility()
        { 
            if (isChangable)
            {
                if(counter % TimeForExcitation == 0) 
                {
                    CreateImageWith(GenerateNumberOrOperator(), obj.Location, Size, Speed);
                    Console.WriteLine("Update new Numebr");
                } 
            }
            counter++;
        }

        public bool Update()
        {
            RunAbility();
            Move();

            return isHit();
        }

        public void Move()
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
        public bool isHit(Obstacle w)
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
