using Forest_of_wrath.Interfaces;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Forest_of_wrath.Classes.Animations;
using Forest_of_wrath.Classes.Collision;
using Forest_of_wrath.Classes.UI;

namespace Forest_of_wrath.Classes.Hero.States
{
    internal class Death : IStateObject
    {
        Texture2D _heroTexture;
        Animation _animation;
        public int frameWidth { get; set; }
        public Hitbox bodyHitBox { get; set; }

        private SoundEffect _sound;

        UIHandler _uiInstance;

        public Death(ContentManager content, GraphicsDeviceManager graphicsDevice)
        {
            /*
             *  DEATH STATE Hero/Death
             *  FRAMES: 6
             */
            _heroTexture = content.Load<Texture2D>("Hero/Death");
            _sound = content.Load<SoundEffect>("Sound/Hero/death");
            frameWidth = _heroTexture.Width / 9;
            _animation = new Animation(6);
            _animation.AddFrame(new AnimationFrame(new Rectangle(0, 0, frameWidth, _heroTexture.Height)));
            _animation.AddFrame(new AnimationFrame(new Rectangle(frameWidth, 0, frameWidth, _heroTexture.Height)));
            _animation.AddFrame(new AnimationFrame(new Rectangle(frameWidth * 2, 0, frameWidth, _heroTexture.Height)));
            _animation.AddFrame(new AnimationFrame(new Rectangle(frameWidth * 3, 0, frameWidth, _heroTexture.Height)));
            _animation.AddFrame(new AnimationFrame(new Rectangle(frameWidth * 4, 0, frameWidth, _heroTexture.Height)));
            _animation.AddFrame(new AnimationFrame(new Rectangle(frameWidth * 5, 0, frameWidth, _heroTexture.Height)));
            _animation.AddFrame(new AnimationFrame(new Rectangle(frameWidth * 6, 0, frameWidth, _heroTexture.Height)));
            _animation.AddFrame(new AnimationFrame(new Rectangle(frameWidth * 8, 0, frameWidth, _heroTexture.Height)));
            _sound.Play();
            bodyHitBox = new Hitbox(graphicsDevice);
            bodyHitBox.Load(50, 40, new Vector2(0,0));
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 position, SpriteEffects effect)
        {
            spriteBatch.Draw(_heroTexture, position, _animation._currentFrame._sourceRectangle, Color.White, 0f, Vector2.Zero, 1f, effect, 0f);
            bodyHitBox.Draw(spriteBatch, new Vector2(position.X + 50f, position.Y + _heroTexture.Height - 40f));
        }
        public void Update(GameTime gameTime, Hitbox hitbox = null)
        {
            if(_animation._currentFrame != _animation._lastFrame)
            {
                _animation.Update(gameTime);
            } else
            {
                _uiInstance.setState(UiState.GAMEOVER);
            }
        }

        public void setUiInstance(UIHandler instance)
        {
            _uiInstance = instance;
        }
    }
}
