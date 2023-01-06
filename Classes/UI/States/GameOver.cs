using Forest_of_wrath.Classes.Animations;
using Forest_of_wrath.Classes.Handlers;
using Forest_of_wrath.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Forest_of_wrath.Classes.UI.States
{
    internal class GameOver : IUiStateObject
    {
        private UIHandler instance;
        Animation title;
        Texture2D titleTexture;
        Vector2 titlePos;
        int frameWidth = 380;
        private Text start;
        private BlinkText blink;
        private SpriteFont font;
        public GameOver(ContentManager content, UIHandler instance)
        {
            this.instance = instance;
            titleTexture = content.Load<Texture2D>("UI/game_over");
            font = content.Load<SpriteFont>("Font/title_12");
            title = new Animation(6);
            titlePos = new Vector2((928 - 8) / 2, 200f);
            title.AddFrame(new AnimationFrame(new Rectangle(0, 0, frameWidth, titleTexture.Height)));
            title.AddFrame(new AnimationFrame(new Rectangle(frameWidth, 0, frameWidth, titleTexture.Height)));
            title.AddFrame(new AnimationFrame(new Rectangle(frameWidth * 2, 0, frameWidth, titleTexture.Height)));
            title.AddFrame(new AnimationFrame(new Rectangle(frameWidth * 3, 0, frameWidth, titleTexture.Height)));
            title.AddFrame(new AnimationFrame(new Rectangle(frameWidth * 4, 0, frameWidth, titleTexture.Height)));
            title.AddFrame(new AnimationFrame(new Rectangle(frameWidth * 5, 0, frameWidth, titleTexture.Height)));
            title.AddFrame(new AnimationFrame(new Rectangle(frameWidth * 6, 0, frameWidth, titleTexture.Height)));
            title.AddFrame(new AnimationFrame(new Rectangle(frameWidth * 7, 0, frameWidth, titleTexture.Height)));
            title.AddFrame(new AnimationFrame(new Rectangle(frameWidth * 8, 0, frameWidth, titleTexture.Height)));
            title.AddFrame(new AnimationFrame(new Rectangle(frameWidth * 9, 0, frameWidth, titleTexture.Height)));
            title.AddFrame(new AnimationFrame(new Rectangle(frameWidth * 10, 0, frameWidth, titleTexture.Height)));
            start = new Text("Press a button to start over", new Vector2(titlePos.X, 400f), font, Color.White, true);
            blink = new BlinkText(start);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(titleTexture, titlePos, title._currentFrame._sourceRectangle, Color.White, 0f, new Vector2((frameWidth / 2), (titleTexture.Height / 2)), 1f, SpriteEffects.None, 1f);
            start.Draw(spriteBatch);
        }
        public void Update(GameTime gameTime)
        {
            blink.Update();
            title.Update(gameTime);
            if (Keyboard.GetState().GetPressedKeyCount() > 0)
            {
                instance.setState(UiState.MAIN);
            }
        }
    }
}
