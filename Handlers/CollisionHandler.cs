using Forest_of_wrath.Entities.Platforms;
using Forest_of_wrath.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_of_wrath.Handlers
{
    internal class CollisionHandler
    {
        public CollisionHandler() { }
        public bool atLeftBorder(float currentPosition)
        {
            return currentPosition <= 0f;
        }
        public bool atRightBorder(float currentPosition)
        {
            return currentPosition >= Globals.graphicsDeviceManager.GraphicsDevice.Viewport.Width;
        }


        public bool abovePlatform(Rectangle heroRectangle, IPlatformObject platform, Vector2 velocity)
        {
            if(heroRectangle.Bottom + velocity.Y < platform.GetRectangle().Top && heroRectangle.Top > platform.GetRectangle().Top - heroRectangle.Height - 10)
            {
                if (heroRectangle.Right > platform.GetRectangle().Left && heroRectangle.Left < platform.GetRectangle().Right)
                {
                    return heroRectangle.Bottom + velocity.Y < platform.GetRectangle().Top;
                } else
                {
                    return false;
                }
            } else
            {
                return false;
            }
        }

    }
}
