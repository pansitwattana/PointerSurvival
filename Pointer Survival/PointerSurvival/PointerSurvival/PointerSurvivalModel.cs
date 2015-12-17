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
        List<Item> items = new List<Item>();
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

        public bool isOutOfBoundary()
        {
            if (player.Position.X < 0 || player.Position.X > 1200 || player.Position.Y < 0 || player.Position.Y > 700)
            {
                return true;
            }
            return false;
        }

        public Player GetPlayer()
        {
            return player;
        }

        public Calculation GetCalcucaltion()
        {
            return cal;
        }

        public void TimeTick()
        {
            if (!isOutOfBoundary())
            {
                if (playerDirection == DirectionRight)
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
            }
            else
            {
                if (playerDirection == DirectionRight)
                {
                    player.Position = new Point(1, player.Position.Y);
                }
                else if (playerDirection == DirectionLeft)
                {
                    player.Position = new Point(1199, player.Position.Y);
                }
                else if (playerDirection == DirectionUp)
                {
                    player.Position = new Point(player.Position.X, 699);
                }
                else if (playerDirection == DirectionDown)
                {
                    player.Position = new Point(player.Position.X, 1);
                }
            }

            NotifyAll();
        }

        public void ClearItem()
        {
            throw new NotImplementedException();
        }

        public void BecomeBoss()
        {
            cal.isBoss = true;
        }

        public void Reset()
        {
            NotifyReset();
        }

        public void Fire1()
        {
            player.Fire(playerDirection);
            bullets.Add(player.weapon);
            NotifyBullet();
        }

        public void Fire2()
        {
            player.Fire2(playerDirection);
            bullets.Add(player.weapon);
            NotifyBullet();
        }

        public Item GetItem()
        {
            return items.ElementAt(items.Count - 1);
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

        public List<Item> GetItems()
        {
            return items;
        }

        public List<Weapon> GetBullets()
        {

            return bullets;
        }

        public void CreaeAsteroid()
        {
            obstacles.Add(new Obstacle(player.Position.X,player.Position.Y,cal.isBoss));
            NotifyAsteroid();
        }

        public void CreateItem()
        {
            items.Add(new Item());
            NotifyItem();
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
            return cal.getScore;
        }

        public int GetLevel()
        {
            return cal.Level;
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

        public bool isHit(Item item)
        {
            return false;
        }

        public void UpdateNewGame()
        {
            if (obstacles.Count > 0)
            {
                foreach (Obstacle o in obstacles)
                {
                    o.Destroy();
                }
            }
            if (bullets.Count > 0)
            {
                foreach (Weapon b in bullets)
                {
                    b.Destroy();
                }
            }
            if (items.Count > 0)
            {
                foreach (Item o in items)
                {
                    o.obj.Dispose();
                }
            }
            player = new Player();
            playerDirection = DirectionUp;
            obstacles = new List<Obstacle>();
            items = new List<Item>();
            bullets = new List<Weapon>();
            cal = new Calculation();
        }
    }
}
