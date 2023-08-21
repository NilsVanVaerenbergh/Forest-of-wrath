using Forest_of_wrath.Entities;
using Forest_of_wrath.Entities.HeroAnimations;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_of_wrath.Handlers
{
    internal class HeroAnimationHandler
    {
        public static void SetRunning()
        {
            Globals.hero.SetAnimationObject(new HeroRunning());
        }
        public static void SetJumping() 
        {
            Globals.hero.SetAnimationObject(new HeroJumping());
        }
        public static void SetIdle()
        {
            Globals.hero.SetAnimationObject(new HeroIdle());
        }
    }
}
