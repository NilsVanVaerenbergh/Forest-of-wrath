using Forest_of_wrath.Classes.Collision;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_of_wrath.Interfaces
{
    internal interface IEnemyStateObject
    {
        public int frameWidth { get; set; }
        public Hitbox bodyHitBox { get; set; }
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch, Vector2 position, SpriteEffects effect);
        void setHeroPosition(Vector2 position);
    }
}
