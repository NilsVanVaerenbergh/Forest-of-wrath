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
    public enum UiState
    {
        GAMEOVER,
        PLAYING,
        MAIN
    }
    internal class UI : IGameObject
    {
        Header header;
        public UiState state { get; set; }
        public UI(ContentManager content)
        {
            header = new Header(content);
            state = UiState.MAIN;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (state == UiState.GAMEOVER)
            {

            }
            header.Draw(spriteBatch);
        }

        public void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
