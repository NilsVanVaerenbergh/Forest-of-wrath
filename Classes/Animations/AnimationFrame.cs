using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_of_wrath.Classes.Animations
{
    internal class AnimationFrame
    {
        public Rectangle _sourceRectangle { get; set; }
        public AnimationFrame(Rectangle sourceRectangle)
        {
            _sourceRectangle = sourceRectangle;
        }
    }
}
