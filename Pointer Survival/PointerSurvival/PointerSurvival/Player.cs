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

        public static Point PositionStart = new Point(575, 350);
        private Point position;
        public Weapon weapon { get; set; }

        public Point Position
        {
            get { return position; }
            set { position = value; }
        }


        public Player()
        {
            Position = PositionStart;
            weapon = new Weapon(Weapon.Normal);

        }

        public void Fire(int playerDirection)
        {
            weapon.Shoot(position.X, position.Y,playerDirection);
        }

        public bool isHit(Item item)
        {

            return false;
        }
    }
}
