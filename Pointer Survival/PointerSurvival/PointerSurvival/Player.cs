using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PointerSurvival
{
    class Player
    {



        public static Point PositionStart = new Point(600, 350);
        private Point position;
        public Weapon weapon { get; set; }

        private int hp;

        public int Hp
        {
            get { return hp; }
            set
            {
                if(value <= 3)
                    hp = value;
            }
        }


        public Point Position
        {
            get { return position; }
            set { position = value; }
        }


        public Player()
        {
            Hp = 2;
            Position = PositionStart;
        }

        public void Fire(int playerDirection)
        {
            weapon = new Weapon(Weapon.Left);
            weapon.Shoot(position.X, position.Y,playerDirection);
        }

        public void Fire2(int playerDirection)
        {
            weapon = new Weapon(Weapon.Right);
            weapon.Shoot(position.X, position.Y, playerDirection);
        }

        public bool isHit(Item item)
        {

            return false;
        }

        public bool isDie()
        {
            Console.WriteLine(Hp);
            Hp--;
            if(Hp <= 0)
            {
                return true;
            }
            return false;
        }
    }
}
