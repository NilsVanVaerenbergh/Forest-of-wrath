using Forest_of_wrath.Classes.Background;
using Forest_of_wrath.Classes.UI.States;
using Forest_of_wrath.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;


namespace Forest_of_wrath.Classes.UI
{
    public enum UiState
    {
        GAMEOVER,
        PLAYING,
        MAIN
    }
    internal class UIHandler : IGameObject
    {
        Header header;
        BackgroundHandler background;
        IUiStateObject uiState;
        public UIHandler(ContentManager content)
        {
            header = new Header(content);
            background = new BackgroundHandler(content);
            uiState = new MainMenu(content);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            background.Draw(spriteBatch);
            uiState.Draw(spriteBatch);
            header.Draw(spriteBatch);
        }
        public void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
