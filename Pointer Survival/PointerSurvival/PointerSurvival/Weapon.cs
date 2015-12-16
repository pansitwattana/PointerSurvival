using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointerSurvival
{
    class Weapon
    {
        public const int Left = 0;
        public const int Right = 1;

        public int Type { get; set; }

        public bool isRight { get; set; }

        private bool isActive;
        public PictureBox obj { get; set; }

        public Weapon(int t)
        {
            isActive = true;
            Type = t;
            switch (t)
            {
                case Left:
                    isRight = false;
                    break;
                case Right:
                    isRight = true;
                    break;
            }
        }

        private bool goX;
        private bool goY;
        private int playerDirection;
        public void Shoot(int x, int y, int Direction)
        {
            PictureBox mainSprite = new PictureBox();
            mainSprite.Size = new Size(15, 15);
            mainSprite.Location = new Point(x+10, y+10);

            if(Type == Right)
                mainSprite.BackColor = Color.Transparent;
            else
            {
                mainSprite.BackColor = Color.Transparent;
            }
            obj = mainSprite;
            goX = Form.MousePosition.X > x;
            goY = Form.MousePosition.Y > y;

            playerDirection = Direction;

            BulletMove();
        }

        public bool isOutOfBoundary()
        {
            if (obj.Location.X < -300 || obj.Location.X > 1500 || obj.Location.Y < -300 || obj.Location.Y > 1100)
            {
                isActive = false;
                return true;
            }
            return false;
        }


        public void BulletMove()
        {
            if (isActive)
            {
                if (playerDirection == PointerSurvivalModel.DirectionUp)
                {
                    obj.Image = PointerSurvival.Properties.Resources.bulletU;
                    obj.Top -= PointerSurvivalController.BulletSpeed;
                }
                else if (playerDirection == PointerSurvivalModel.DirectionDown)
                {
                    obj.Image = PointerSurvival.Properties.Resources.bulletD;
                    obj.Top += PointerSurvivalController.BulletSpeed;
                }
                else if (playerDirection == PointerSurvivalModel.DirectionRight)
                {
                    obj.Image = PointerSurvival.Properties.Resources.bulletR;
                    obj.Left += PointerSurvivalController.BulletSpeed;
                }
                else if (playerDirection == PointerSurvivalModel.DirectionLeft)
                {
                    obj.Image = PointerSurvival.Properties.Resources.bulletL;
                    obj.Left -= PointerSurvivalController.BulletSpeed;
                }
            }
            
        }

        public void Destroy()
        {
            obj.Dispose();
            isActive = false;
        }
    }
}
