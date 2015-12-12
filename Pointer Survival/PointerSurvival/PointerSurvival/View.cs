using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointerSurvival
{
    public interface View
    {
        void Notify(Model m);
        void NotifyAsteroid(Model m);
        void NotifyBullet(Model m);
    }
}
