﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointerSurvival
{
    class PointerSurvivalController : Controller
    {
        public static int Speed = 2;
        public static int TimeToCreateAsteroid = 1;
        public static int BulletSpeed = 10;
        public static int EveryXScoreForBoss = 4;

        public const int TimeTick = 0;
        public const int Fire = 1;
        public const int CreateAsteroid = 2;
        public const int Up = 3;
        public const int Down = 4;
        public const int Left = 5;
        public const int Right = 6;
        public const int UpRight = 7;
        public const int UpLeft = 8;
        public const int DownLeft = 9;
        public const int DownRight = 10;
        public const int ItemSpawn = 11;
        public const int StageBoss = 12;
        public const int StageNormal = 13;

        public override void ActionPerformed(int action)
        {
            foreach (PointerSurvivalModel m in mList)
            {
                switch (action)
                {
                    case TimeTick:
                        m.TimeTick();
                        break;
                    case Fire:
                        m.Fire();
                        break;
                    case CreateAsteroid:
                        m.CreaeAsteroid();
                        break;
                    case ItemSpawn:
                        m.CreateItem();
                        break;
                    case Up:
                        m.MoveUp();
                        break;
                    case Down:
                        m.MoveDown();
                        break;
                    case Left:
                        m.MoveLeft();
                        break;
                    case Right:
                        m.MoveRight();
                        break;
                    case UpLeft:
                        m.MoveUpLeft();
                        break;
                    case UpRight:
                        m.MoveUpRight();
                        break;
                    case DownLeft:
                        m.MoveDownLeft();
                        break;
                    case DownRight:
                        m.MoveDownRight();
                        break;
                    case StageNormal:
                        m.BecomeBoss();
                        break;
                    case StageBoss:
                        m.BecomeNormal();
                        break;
                    case 99:
                        m.cal.getScore += 1;
                        Console.WriteLine("score " + m.cal.getScore);
                        break;
                }
            }
        }
    }
}
