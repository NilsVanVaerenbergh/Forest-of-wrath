using Forest_of_wrath.Classes.Animations;
using Forest_of_wrath.Classes.Handlers;
using Forest_of_wrath.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace Forest_of_wrath.Classes.UI.States
{
    internal class MainMenu : IUiStateObject
    {
        private SpriteFont[] font = new SpriteFont[2];
        private Text start;
        private Texture2D title;
        private Texture2D hero;

        Animation titleAnimation;
        Animation heroAnimation;

        private UIHandler instance;

        private BlinkText blink;

        private Vector2 titlePos;
        int frameWidth = 371;
        int heroFrameWidth;
        Vector2 heroPos;
        Song song;

        public MainMenu(ContentManager content, UIHandler instance)
        {
            font[0] = content.Load<SpriteFont>("Font/title_12");
            font[1] = content.Load<SpriteFont>("Font/title_48");
            title = content.Load<Texture2D>("UI/main_screen");
            hero = content.Load<Texture2D>("Hero/Run");
            titlePos = new Vector2((928 - 8) / 2, 200f);
            titleAnimation = new Animation(6);
            titleAnimation.AddFrame(new AnimationFrame(new Rectangle(0, 0, frameWidth, title.Height)));
            titleAnimation.AddFrame(new AnimationFrame(new Rectangle(frameWidth, 0, frameWidth, title.Height)));
            titleAnimation.AddFrame(new AnimationFrame(new Rectangle(frameWidth * 2, 0, frameWidth, title.Height)));
            titleAnimation.AddFrame(new AnimationFrame(new Rectangle(frameWidth * 3, 0, frameWidth, title.Height)));
            titleAnimation.AddFrame(new AnimationFrame(new Rectangle(frameWidth * 4, 0, frameWidth, title.Height)));
            titleAnimation.AddFrame(new AnimationFrame(new Rectangle(frameWidth * 5, 0, frameWidth, title.Height)));
            titleAnimation.AddFrame(new AnimationFrame(new Rectangle(frameWidth * 6, 0, frameWidth, title.Height)));
            titleAnimation.AddFrame(new AnimationFrame(new Rectangle(frameWidth * 7, 0, frameWidth, title.Height)));
            titleAnimation.AddFrame(new AnimationFrame(new Rectangle(frameWidth * 8, 0, frameWidth, title.Height)));
            titleAnimation.AddFrame(new AnimationFrame(new Rectangle(frameWidth * 9, 0, frameWidth, title.Height)));
            titleAnimation.AddFrame(new AnimationFrame(new Rectangle(frameWidth * 10, 0, frameWidth, title.Height)));
            titleAnimation.AddFrame(new AnimationFrame(new Rectangle(frameWidth * 11, 0, frameWidth, title.Height)));
            heroAnimation = new Animation(8);
            heroFrameWidth = hero.Width / 8;
            heroPos = new Vector2(-5, 377);
            heroAnimation.AddFrame(new AnimationFrame(new Rectangle(0, 0, heroFrameWidth, hero.Height)));
            heroAnimation.AddFrame(new AnimationFrame(new Rectangle(heroFrameWidth, 0, heroFrameWidth, hero.Height)));
            heroAnimation.AddFrame(new AnimationFrame(new Rectangle(heroFrameWidth * 2, 0, heroFrameWidth, hero.Height)));
            heroAnimation.AddFrame(new AnimationFrame(new Rectangle(heroFrameWidth * 3, 0, heroFrameWidth, hero.Height)));
            heroAnimation.AddFrame(new AnimationFrame(new Rectangle(heroFrameWidth * 4, 0, heroFrameWidth, hero.Height)));
            heroAnimation.AddFrame(new AnimationFrame(new Rectangle(heroFrameWidth * 5, 0, heroFrameWidth, hero.Height)));
            heroAnimation.AddFrame(new AnimationFrame(new Rectangle(heroFrameWidth * 6, 0, heroFrameWidth, hero.Height)));
            heroAnimation.AddFrame(new AnimationFrame(new Rectangle(heroFrameWidth * 7, 0, heroFrameWidth, hero.Height)));
            start = new Text("Press to start", new Vector2(titlePos.X, 400f), font[0], Color.White, true);
            blink = new BlinkText(start);
            this.instance = instance;
            song = content.Load<Song>("Sound/Game");
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Volume -= 0.5f;
            MediaPlayer.Play(song);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(title, titlePos, titleAnimation._currentFrame._sourceRectangle,Color.White,0f, new Vector2((371 / 2), (title.Height / 2)),1f, SpriteEffects.None, 1f);
            spriteBatch.Draw(hero, heroPos, heroAnimation._currentFrame._sourceRectangle, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            start.Draw(spriteBatch);
        }
        public void Update(GameTime gameTime)
        {
            blink.Update();
            titleAnimation.Update(gameTime);
            if(heroPos.X < 1000)
            {
                heroPos += new Vector2(1f, 0f);
                heroAnimation.Update(gameTime);
            }
            if(Keyboard.GetState().GetPressedKeyCount() > 0)
            {
                instance.setState(UiState.PLAYING);
            }
        }
    }
}
