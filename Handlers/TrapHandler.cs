using Forest_of_wrath.Entities;
using Forest_of_wrath.Entities.HeroAnimations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_of_wrath.Handlers
{
    internal class TrapHandler
    {
        private Trap trap;
        public TrapHandler(Trap trap) { 
         this.trap = trap;
        }
        public void Update()
        {
            if (trap != null)
                if(trap.GetHitbox().GetRectangle().Intersects(Globals.hero.GetHitbox().GetRectangle()))
                {
                    Globals.hero.SetHealth(0);
                }
        }
    }
}
