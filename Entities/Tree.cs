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
    internal class Tree : IGameObject
    {
        Texture2D texture;
        Hitbox hitbox;
        Vector2 position;
        TreeHandler handler;
        public Tree() {
            texture = Globals.contentManager.Load<Texture2D>("UI/Tree");
            hitbox = new Hitbox();
            position = new Vector2(Globals.randomValue.RandomXPos(), Globals.floorYPosition - texture.Height + 5);
            hitbox.Load(texture.Width, texture.Height, position ,Color.GhostWhite);
            handler = new TreeHandler(this);
        }
        public void Draw()
        {
            Globals.spriteBatch.Draw(texture, position, Color.White * 0.7f);
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
