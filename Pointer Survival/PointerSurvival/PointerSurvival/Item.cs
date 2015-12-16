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
    class Item
    {
        public const int SpeedRandomItem = 0;
        public const int ChangeBaseNumberItem = 1;
        public const int SpeedAsteroidItem = 2;

        public static int ItemSize = 30;

        public string Text { get; set; }

        public string Name { get; set; }

        public PictureBox obj { get; set; }

        private int ItemType;

        public Item()
        {
            RandomType();
            CreateImage();
        }

        public void RandomType()
        {
            ItemType = Calculation.random.Next(3);
            switch (ItemType)
            {
                case SpeedRandomItem:
                    Name = "Speed";
                    break;
                case ChangeBaseNumberItem:
                    Name = "Base2";
                    break;
                case SpeedAsteroidItem:
                    Name = "AsteroidSpeed";
                    break;

            }
        }

        private void CreateImage()
        {
            if (obj == null)
            {
                obj = new PictureBox();
            }
            Bitmap bmp = new Bitmap(PointerSurvival.Properties.Resources.obstacle);
            Point location = new Point(Calculation.random.Next(1200), Calculation.random.Next(700));
            Graphics g = Graphics.FromImage(bmp);


            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;

            g.DrawString("Itm", new Font("Tahoma", 20), Brushes.Black, new Point(20, 20));

            g.Flush();

            obj.Image = bmp;
            obj.Location = location;
            obj.Size = new Size(ItemSize, ItemSize);
            obj.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        public bool Update(PictureBox player)
        {

            return isHit(player);
        }

        private bool isHit(PictureBox w)
        {
            if (w.Left <= obj.Right && obj.Left <= w.Right &&
                                            w.Top <= obj.Bottom && obj.Top <= w.Bottom)
            {
                return true;
            }
            return false;
        }

        public void RunSpeedItem()
        {
            PointerSurvivalController.Speed = Calculation.random.Next(3, 7);
            switch (PointerSurvivalController.Speed)
            {
                case 3:
                    Text = "Speed changed to Turtle !";
                    break;
                case 4:
                    Text = "Speed changed to Low !";
                    break;
                case 5:
                    Text = "Speed changed to Normal !";
                    break;
                case 6:
                    Text = "Speed changed to Fast !";
                    break;
                case 7:
                    Text = "Speed changed to the Fastest";
                    break;
            }
        }

        public void RunChangeBaseNumberItem(List<Obstacle> obstacles)
        {
            foreach (Obstacle o in obstacles)
                o.BaseNumber = 2;
            Text = "Number changed to Base 2";
        }

        public void RunSpeedAsteroidItem(List<Obstacle> obstacles)
        {
            int speed = Calculation.random.Next(-1, 2);
            while (speed == 0)
            {
                speed = Calculation.random.Next(-1, 2);
            }
            foreach (Obstacle o in obstacles)
            {
                if (o.Speed > 1 || speed >= 0)
                    o.Speed += speed;
            }

            switch (speed)
            {
                case 1:
                    Text = "Asteroid Speed Increased !";
                    break;
                case -1:
                    Text = "Asteroid Speed Decreased !";
                    break;
                default:
                    Text = "Error";
                    break;
            }
        }

        public void RunAbility(List<Obstacle> obstacles)
        {
            switch (ItemType)
            {
                case SpeedRandomItem:
                    RunSpeedItem();
                    break;
                case ChangeBaseNumberItem:
                    RunChangeBaseNumberItem(obstacles);
                    break;
                case SpeedAsteroidItem:
                    RunSpeedAsteroidItem(obstacles);
                    break;
            }
            obj.Dispose();
        }
    }
}
