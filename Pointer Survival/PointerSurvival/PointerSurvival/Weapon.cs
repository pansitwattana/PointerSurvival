﻿using System;
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
            mainSprite.Size = new Size(10, 10);
            mainSprite.Location = new Point(x, y);

            if(Type == Right)
                mainSprite.BackColor = Color.Red;
            else
            {
                mainSprite.BackColor = Color.LightSkyBlue;
            }
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
            }
            
        }

        public void Destroy()
        {
            obj.Dispose();
            isActive = false;
        }
    }
}
