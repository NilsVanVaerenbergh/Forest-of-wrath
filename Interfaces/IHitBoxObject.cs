using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_of_wrath.Interfaces
{
    internal interface IHitBoxObject
    {
        public void Load() { }
        public void Unload() { }

        public void Draw(SpriteBatch spriteBatch, Vector2 pos) { }

    }
}
