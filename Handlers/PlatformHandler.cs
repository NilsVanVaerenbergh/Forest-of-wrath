using Forest_of_wrath.Entities.Platforms;
using Forest_of_wrath.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_of_wrath.Handlers
{
    internal class PlatformHandler
    {
        public PlatformHandler() 
        { 
        }
        public void setActivePlatformState(Vector2 velocity)
        {

            bool[] activeStates = new bool[Globals.platforms.Count];
            for (int i = 0; i < Globals.platforms.Count; i++) {
                activeStates[i] = Globals.collisionHandler.abovePlatform(Globals.hero.GetHitbox().GetRectangle(), Globals.platforms[i], velocity);
            }
            Globals.hero.SetOnPlatform(activeStates.Contains(true));
        }


    }
}
