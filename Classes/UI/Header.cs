using Forest_of_wrath.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_of_wrath.Classes.UI
{
    internal class Header : IGameObject
    {
        Texture2D _settingsIcon;
        public Header(ContentManager content)
        {
            _settingsIcon = content.Load<Texture2D>("UI/Brown");
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_settingsIcon, new Vector2(928-10-33, 10), new Rectangle(65, 131, 33, 33), Color.White);
        }

        public void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
