using Forest_of_wrath.Handlers;
using Forest_of_wrath.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_of_wrath.Entities
{
    internal class Trap : IGameObject
    {
        Texture2D texture;
        Hitbox hitbox;
        Vector2 position;
        TrapHandler handler;
        public Trap() {
            texture = Globals.contentManager.Load<Texture2D>("UI/Trap");
            hitbox = new Hitbox();
            position = new Vector2(Globals.randomValue.RandomXPos(), Globals.floorYPosition - texture.Height + 5);
            hitbox.Load(texture.Width, texture.Height, position ,Color.GhostWhite);
            handler = new TrapHandler(this);
        }
        public void Draw()
        {
            Globals.spriteBatch.Draw(texture, position, Color.White);
        }
        public Hitbox GetHitbox()
        {
            return hitbox;
        }
        public void Update(GameTime gameTime)
        {
            handler.Update();
        }
    }
}
