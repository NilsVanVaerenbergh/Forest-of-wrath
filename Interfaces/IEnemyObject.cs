using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_of_wrath.Interfaces
{
    internal interface IEnemyObject
    {
        void Update(GameTime gameTime, Vector2 heroPos);
        void Draw(SpriteBatch spriteBatch);
    }
}
