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
        List<Obstacle> obstacles = new List<Obstacle>();
        List<Weapon> bullets = new List<Weapon>();
        public Calculation cal = new Calculation();

        public PointerSurvivalModel()
        {
            player = new Player();
        }

        public void MoveUp()//if (y > player.Position.Y)
        {
            player.Position = new Point(player.Position.X, player.Position.Y - PointerSurvivalController.Speed);
        }

        public void MoveDown()//else if (y < player.Position.Y)
        {
            player.Position = new Point(player.Position.X, player.Position.Y + PointerSurvivalController.Speed);
        }

        public void MoveRight()//if (x > player.Position.X)
        {
            player.Position = new Point(player.Position.X + PointerSurvivalController.Speed, player.Position.Y);
        }

        public void MoveLeft()//else if (x < player.Position.X)
        {
            player.Position = new Point(player.Position.X - PointerSurvivalController.Speed, player.Position.Y);
        }

        public void MoveToMouse(int x, int y)
        {
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
            player.Fire();
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
