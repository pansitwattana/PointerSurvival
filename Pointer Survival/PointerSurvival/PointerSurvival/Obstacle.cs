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
        public static int PercentBornHidable = 10;
        public static int PercentBornChanable = 10;
        public static int PercentBornDurable = 5;

        public static int TimeForExcitation = 50;

        public const int OperatorType = -1;

        public static int SafeDistance = 250;

        public PictureBox obj { get; set; }
        public Point Position { get; set; }

        public bool isHidable { get; set; }
        public bool isChangable { get; set; }
        public bool isDurable { get; set; }

        public int Number { get; set; } = 0;

        private int speed;

        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }
        public bool isActive { get; set; }
        private int direction;

        public int Direction
        {
            get { return direction; }
            set { direction = value; }
        }
        public int Size { get; set; }

        private int baseNumber;

        public int BaseNumber
        {
            get { return baseNumber; }
            set
            {
                if (baseNumber != OperatorType && (Number > 0))
                {
                    ChangeNumberToBaseN(value);
                    baseNumber = value;
                }
            }
        }

        private int counter = 0;

        public Obstacle(int playerX, int playerY, bool isBoss)
        {
            CreateObstacle(playerX, playerY, isBoss);
        }

        private void CreateObstacle(int playerX, int playerY, bool isBoss)
        {
            CreateImageWith(GenerateNumberOrOperator(), RandomLocationWithSafeDistanceFrom(playerX, playerY), Calculation.random.Next(1, 4));
            RandomType();
            goX = Convert.ToBoolean(Calculation.random.Next(0,1));
            goY = Convert.ToBoolean(Calculation.random.Next(0,1));
            RandomDirection();
            if (isBoss) BaseNumber = 2;
            else baseNumber = 10;
            Update();
        }

        private void CreateImageWith(string symbol, Point point, int speed)
        {
            if (obj == null)
            {
                obj = new PictureBox();
            }
            Bitmap bmp = new Bitmap(PointerSurvival.Properties.Resources.obstacle);
            Point location = point;
            Graphics g = Graphics.FromImage(bmp);
            Size = 200 - 50 * speed;

            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;

            int symbolsize = 0;
            Point symbolLocation;
            Brush brush;
            if (Number > 0)
            {
                brush = Brushes.Black;
                symbolsize = 15;
                symbolLocation = new Point(25, 25);
            }
            else
            {
                brush = Brushes.Red;
                symbolsize = 25;
                symbolLocation = new Point(20, 20);
            }

            g.DrawString(symbol, new Font("Consolas", symbolsize), brush, symbolLocation);

            g.Flush();

            obj.Image = bmp;
            obj.Location = location;
            obj.Size = new Size(Size, Size);
            obj.SizeMode = PictureBoxSizeMode.StretchImage;
            isActive = true;
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

        public void ChangeNumberToBaseN(int n)
        {
            string numberInBaseN = "";
            switch (n)
            {
                case 2:
                    numberInBaseN = Calculation.ConvertBase(Number, new char[] { '0', '1' });
                    break;
                case 8:
                    numberInBaseN = Calculation.ConvertBase(Number, new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8' });
                    break;
                case 16:
                    numberInBaseN = Calculation.ConvertBase(Number, new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
                         'A', 'B', 'C', 'D', 'E', 'F'});
                    break;
            }
            CreateImageWith(numberInBaseN, obj.Location, Speed);
        }

        private void RandomType()
        {
            if (Calculation.random.Next(100) < PercentBornHidable)
            {
                CreateImageWith("?", obj.Location, Speed);
                isHidable = true;
            }
            else
            {
                isHidable = false;
            }

            if (Calculation.random.Next(100) < PercentBornChanable)
            {
                speed = 1;
                isChangable = true;
            }
            else
            {
                isChangable = false;
            }

            if (Calculation.random.Next(100) < PercentBornDurable)
            {
                speed = 1;
                obj.Size = new Size(200, 200);
                isDurable = true;
            }
            else
            {
                isDurable = false;
            }

            if (Number >= 0)
            {
                baseNumber = 10;
            }
            else
            {
                baseNumber = OperatorType;
            }
        }

        private Point RandomLocationWithSafeDistanceFrom(int playerX, int playerY)
        {
            int x = Calculation.random.Next(1200);
            int y = Calculation.random.Next(700);
            while (Math.Abs(x - playerX) < SafeDistance)
            {
                x = Calculation.random.Next(1200);
            }
            while (Math.Abs(y - playerY) < SafeDistance)
            {
                y = Calculation.random.Next(700);
            }

            return new Point(x, y);
        }
        private string GenerateNumber()
        {
            Number = Calculation.random.Next(1, 10);

            string symbol;         
            symbol = Number.ToString();
            
            return symbol;
        }
        private string GenerateNumberOrOperator()
        {
            Number = Calculation.random.Next(14) - 3;

            while (Number == 0)
            {
                Number = Calculation.random.Next(14) - 3;
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
                    symbol = "x";
                }
                else
                {
                    symbol = "Error";
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
                if (counter % TimeForExcitation == 0)
                {
                    if (BaseNumber == 10)
                        CreateImageWith(GenerateNumberOrOperator(), obj.Location, Speed);
                    else if (BaseNumber == 2 && Number >= 0)
                    {
                        string number = Calculation.ConvertBase(int.Parse(GenerateNumber()), new char[] { '0', '1' });
                        CreateImageWith(number, obj.Location, Speed);
                    }
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

        public void RandomDirection()
        {
            speedX = Calculation.random.Next(-3,3);
            speedY = Calculation.random.Next(-3,3);
            while (speedX == 0 && speedY == 0)
            {
                speedX = Calculation.random.Next(-3, 3);
                speedY = Calculation.random.Next(-3, 3);
            }
        }

        private int speedX;
        private int speedY;

        public void Move()
        {
            if (isActive)
            {
                obj.Left += speed * speedX;
                obj.Top += speed * speedY;
            }
        }

        public bool isOutOfBoundary()
        {
            if (obj.Location.X < -300 || obj.Location.X > 1400 || obj.Location.Y < -300 || obj.Location.Y > 1100)
            {
                isDurable = false;
                isActive = false;
                return true;
            }
            return false;
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

            if (!isDurable)
            {
                isActive = false;
                obj.Dispose();
            }
            else
            {
                isActive = true;
            }



        }

        public bool isHit()
        {

            if (PointerSurvivalView.pointerBox.Left <= obj.Right && obj.Left <= PointerSurvivalView.pointerBox.Right &&
                        PointerSurvivalView.pointerBox.Top <= obj.Bottom && obj.Top <= PointerSurvivalView.pointerBox.Bottom && isActive)
            {
                return true;
            }
            return false;
        }

        public bool isHit(Weapon w)
        {

            if (w.obj.Left <= obj.Right && obj.Left <= w.obj.Right &&
                        w.obj.Top <= obj.Bottom && obj.Top <= w.obj.Bottom)
            {


                return true;
            }


            return false;
        }
        public bool isHit(Obstacle w)
        {
            if (isActive)
            {
                if (w.obj.Left <= obj.Right && obj.Left <= w.obj.Right &&
                                            w.obj.Top <= obj.Bottom && obj.Top <= w.obj.Bottom)
                {
                    isActive = false;
                    return true;
                }
            }

            return false;
        }
    }
}


