using Forest_of_wrath.Classes;
using Forest_of_wrath.Classes.Collision;
using Forest_of_wrath.Classes.Enemies.ToothWalker.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_of_wrath.Interfaces
{
    internal interface IStateObject
    {
        public int frameWidth { get; set; }
        public Hitbox bodyHitBox { get; set; }
        void Update(GameTime gameTime, Hitbox hitbox = null);
        void Draw(SpriteBatch spriteBatch, Vector2 position, SpriteEffects effect);
    }
}
