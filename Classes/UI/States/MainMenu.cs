using Forest_of_wrath.Classes.Handlers;
using Forest_of_wrath.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_of_wrath.Classes.UI.States
{
    internal class MainMenu : IUiStateObject
    {
        private SpriteFont font;
        private Text title;

        private Vector2 titlePos;

        public MainMenu(ContentManager content)
        {
            font = content.Load<SpriteFont>("Font/title_24");
            titlePos = new Vector2(GraphicsDeviceManager.DefaultBackBufferWidth / 2, 150f);
            title = new Text("Forest of wrath", titlePos, font, Color.Goldenrod);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            title.Draw(spriteBatch);
        }
        public void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
