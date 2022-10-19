using Forest_of_wrath.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;


namespace Forest_of_wrath.Classes.UI
{
    internal class Cursor : IGameObject
    {
        Texture2D _texture;
        public Cursor(ContentManager content) {
            _texture = content.Load<Texture2D>("UI/cursor");
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }

        public void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
