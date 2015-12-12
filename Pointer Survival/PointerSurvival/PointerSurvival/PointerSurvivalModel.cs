using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointerSurvival
{
    class PointerSurvivalModel : Model
    {

        Player player;
        public static int DirectionUp = 1;
        public static int DirectionDown = 2;
        public static int DirectionLeft = 3;
        public static int DirectionRight = 4;
        public static int DirectionUpLeft = 5;
        public static int DirectionUpRight = 6;
        public static int DirectionDownLeft = 7;
        public static int DirectionDownRight = 8;

        private int playerDirection;

        List<Obstacle> obstacles = new List<Obstacle>();
        List<Weapon> bullets = new List<Weapon>();
        public Calculation cal = new Calculation();

        public PointerSurvivalModel()
        {
            player = new Player();
            playerDirection = DirectionUp;
        }

        public void MoveUp()
        {
            playerDirection = DirectionUp;
        }

        public void MoveDown()
        {
            playerDirection = DirectionDown;
        }

        public void MoveRight()
        {
            playerDirection = DirectionRight;
        }

        public void MoveLeft()
        {
            playerDirection = DirectionLeft;
        }

        public void MoveUpRight()
        {
            playerDirection = DirectionUpRight;
        }

        public void MoveUpLeft()
        {
            playerDirection = DirectionUpLeft;
        }

        public void MoveDownRight()
        {
            playerDirection = DirectionDownRight;
        }

        public void MoveDownLeft()
        {
            playerDirection = DirectionDownLeft;
        }
        public void MoveToMouse(int x, int y)
        {
            
            if (playerDirection == DirectionUpRight)
            {
                player.Position = new Point(player.Position.X, player.Position.Y - PointerSurvivalController.Speed);
                player.Position = new Point(player.Position.X + PointerSurvivalController.Speed, player.Position.Y);
            }
            else if (playerDirection == DirectionUpLeft)
            {
                player.Position = new Point(player.Position.X, player.Position.Y - PointerSurvivalController.Speed);
                player.Position = new Point(player.Position.X - PointerSurvivalController.Speed, player.Position.Y);
            }
            else if (playerDirection == DirectionDownRight)
            {
                player.Position = new Point(player.Position.X, player.Position.Y + PointerSurvivalController.Speed);
                player.Position = new Point(player.Position.X + PointerSurvivalController.Speed, player.Position.Y);
            }
            else if (playerDirection == DirectionDownLeft)
            {
                player.Position = new Point(player.Position.X, player.Position.Y + PointerSurvivalController.Speed);
                player.Position = new Point(player.Position.X - PointerSurvivalController.Speed, player.Position.Y);
            }
            else if (playerDirection == DirectionRight)
            {
                player.Position = new Point(player.Position.X + PointerSurvivalController.Speed, player.Position.Y);
            }
            else if (playerDirection == DirectionLeft)
            {
                player.Position = new Point(player.Position.X - PointerSurvivalController.Speed, player.Position.Y);
            }
            else if (playerDirection == DirectionUp)
            {
                player.Position = new Point(player.Position.X, player.Position.Y - PointerSurvivalController.Speed);
            }
            else if (playerDirection == DirectionDown)
            {
                player.Position = new Point(player.Position.X, player.Position.Y + PointerSurvivalController.Speed);
            }
            ////Check X coord
            //if (goRight)
            //{
            //    player.Position = new Point(player.Position.X + PointerSurvivalController.Speed, player.Position.Y);
            //}
            //else
            //{
            //    player.Position = new Point(player.Position.X - PointerSurvivalController.Speed, player.Position.Y);
            //}

            ////Check Y coord
            //if (goUp)
            //{
            //    player.Position = new Point(player.Position.X, player.Position.Y + PointerSurvivalController.Speed);
            //}
            //else
            //{
            //    player.Position = new Point(player.Position.X, player.Position.Y - PointerSurvivalController.Speed);
            //}
            ////Console.WriteLine(player.Position);
            NotifyAll();
        }

        public void Fire()
        {
            player.Fire(playerDirection);
            bullets.Add(player.weapon);
            NotifyBullet();
        }

        public Obstacle GetLastAsteroids()
        {
            return obstacles.ElementAt(obstacles.Count - 1);
        }

        public Weapon GetBullet()
        {
            return bullets.ElementAt(bullets.Count - 1);
        }

        public List<Obstacle> GetAsteroids()
        {
            
            return obstacles;
        }

        public List<Weapon> GetBullets()
        {

            return bullets;
        }

        public void CreaeAsteroid()
        {
            obstacles.Add(new Obstacle());
            NotifyAsteroid();
        }

        public void Remove(Weapon bullet)
        {
            //bullet.Destroy();
            bullets.Remove(bullet);
        }

        public void Remove(Obstacle obstacle)
        {
            //obstacle.Destroy();
            obstacles.Remove(obstacle);
        }

        public int GetDistanceX()
        {
            return player.Position.X;
        }

        public int GetDistanceY()
        {
            return player.Position.Y;
        }

        public int GetScore()
        {
            throw new NotImplementedException();
        }

        public bool isHit()
        {
            foreach (Obstacle obstacle in obstacles)
            {
                if (obstacle.isHit())
                {
                    return true;
                }
            }
            return false;
        }

    }
}
