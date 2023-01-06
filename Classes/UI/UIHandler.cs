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
        BackgroundHandler background;
        IUiStateObject uiState;
        ContentManager content;
        GraphicsDeviceManager graphicsDeviceManager;
        public UIHandler(ContentManager content, GraphicsDeviceManager graphicsDevice)
        {
            background = new BackgroundHandler(content);
            uiState = new MainMenu(content, this);
            this.content = content;
            graphicsDeviceManager = graphicsDevice;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            background.Draw(spriteBatch);
            uiState.Draw(spriteBatch);
        }
        public void Update(GameTime gameTime)
        {
            uiState.Update(gameTime);
        }
        public void setState(UiState state)
        {
            // change to switch case statement 
            if (state == UiState.MAIN) uiState = new MainMenu(content, this);
            if (state == UiState.GAMEOVER) uiState = new GameOver(content, this);
            if (state == UiState.PLAYING) uiState = new Playing(content, this, graphicsDeviceManager);
        }
    }
}
