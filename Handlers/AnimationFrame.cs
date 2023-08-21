using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_of_wrath.Handlers
{
    internal class AnimationFrame
    {
        public Rectangle sourceRectangle { get; set; }
        public AnimationFrame(Rectangle sourceRectangle)
        {
            this.sourceRectangle = sourceRectangle;
        }
    }
}
