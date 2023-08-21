using Forest_of_wrath.Handlers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_of_wrath.Interfaces
{
    internal interface IAnimationObject
    {
        public int GetTextureHeight();
        public void Draw(Vector2 position, SpriteEffects rotation);
        public void Update(GameTime gameTime);

        public Animation GetAnimation();
    }
}
