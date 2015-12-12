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
        public const int Normal = 0;
        public const int ThreeGun = 1;

        public int Type { get; set; }
        public int Damage { get; set; }
        public int Speed { get; set; }

        private bool isActive;
        public PictureBox obj { get; set; }

        public Weapon(int t)
        {
            isActive = true;
            Type = t;
            switch (t)
            {
                case Normal:
                    Damage = 1;
                    Speed = 5;
                    break;
                case ThreeGun:
                    Damage = 2;
                    Speed = 5;
                    break;
            }
        }

        private bool goX;
        private bool goY;
        private int playerDirection;
        public void Shoot(int x, int y, int Direction)
        {
            PictureBox mainSprite = new PictureBox();
            mainSprite.Size = new Size(10, 10);
            mainSprite.Location = new Point(x, y);

            mainSprite.BackColor = Color.Black;
            obj = mainSprite;
            goX = Form.MousePosition.X > x;
            goY = Form.MousePosition.Y > y;

            playerDirection = Direction;

            BulletMove();
        }

        public void BulletMove()
        {
            if (isActive)
            {
                if (playerDirection == PointerSurvivalModel.DirectionUp)
                {
                    obj.Top -= PointerSurvivalController.BulletSpeed;
                }
                else if (playerDirection == PointerSurvivalModel.DirectionDown)
                {
                    obj.Top += PointerSurvivalController.BulletSpeed;
                }
                else if (playerDirection == PointerSurvivalModel.DirectionRight)
                {
                    obj.Left += PointerSurvivalController.BulletSpeed;
                }
                else if (playerDirection == PointerSurvivalModel.DirectionLeft)
                {
                    obj.Left -= PointerSurvivalController.BulletSpeed;
                }
                //if (goX)
                //{
                //    obj.Left += PointerSurvivalController.BulletSpeed;
                //}
                //else
                //{
                //    obj.Left -= PointerSurvivalController.BulletSpeed;
                //}

                ////Check Y coord
                //if (goY)
                //{
                //    obj.Top += PointerSurvivalController.BulletSpeed;
                //}
                //else
                //{
                //    obj.Top -= PointerSurvivalController.BulletSpeed;
                //}
            }
            
        }

        public void Destroy()
        {
            obj.Dispose();
            isActive = false;
        }
    }
}
