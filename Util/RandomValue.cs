using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Forest_of_wrath.Util
{
    internal class RandomValue
    {
        private Random random = new Random();
        public RandomValue(){}
        public int RandomPlatform() 
        { 
            return random.Next(Globals.platforms.Count);
        }
        public Vector2 RandomPosOnPlatform(int xOffset, int yOffset)
        {
            int randomPlatform = RandomPlatform();
            int X = random.Next(
                Globals.platforms[randomPlatform].GetRectangle().X + xOffset,
                Globals.platforms[randomPlatform].GetRectangle().X + Globals.platforms[randomPlatform].GetRectangle().Width - xOffset + 1
            );
            int Y = Globals.platforms[randomPlatform].GetRectangle().Y - yOffset;
            return new Vector2(X, Y);
        } 
        public int RandomXPos()
        {
            int offset = 50;
            return random.Next(50, Globals.graphicsDeviceManager.PreferredBackBufferWidth - offset);
        }

    }
}
