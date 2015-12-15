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
        
        public static int ItemSize = 30;

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
            ItemType = Obstacle.random.Next(2);
            switch (ItemType)
            {
                case SpeedRandomItem:
                    Name = "S";
                    break;
                case ChangeBaseNumberItem:
                    Name = "B";
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
            Point location = new Point(Obstacle.random.Next(1200),Obstacle.random.Next(700));
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

        public void RunAbility(List<Obstacle> obstacles)
        {
            switch (ItemType)
            {
                case SpeedRandomItem:
                    PointerSurvivalController.Speed = Obstacle.random.Next(1, 4);
                    break;
                case ChangeBaseNumberItem:
                    foreach (Obstacle o in obstacles)
                        o.BaseNumber = 2;
                    break;
            }
            obj.Dispose();
        }
    }
}
