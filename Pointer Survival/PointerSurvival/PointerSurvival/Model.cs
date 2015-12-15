using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace PointerSurvival
{
    public class Model
    {
        protected ArrayList oList;

        public Model()
        {
            oList = new ArrayList();
        }
        public void NotifyAll()
        {
            foreach (View m in oList)
            {
                m.Notify(this);
            }
        }
        public void NotifyAsteroid()
        {
            foreach (View m in oList)
            {
                m.NotifyAsteroid(this);
            }
        }

        public void NotifyBullet()
        {
            foreach (View m in oList)
            {
                m.NotifyBullet(this);
            }
        }

        public void NotifyItem()
        {
            foreach(View m in oList)
            {
                m.NotifyItem(this);
            }
        }

        public void AttachObserver(View m)
        {
            oList.Add(m);
        }

    }
}
