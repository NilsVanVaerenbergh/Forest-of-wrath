using Forest_of_wrath.Interfaces;
using Microsoft.VisualBasic.Devices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Keyboard = Microsoft.Xna.Framework.Input.Keyboard;

namespace Forest_of_wrath.Classes.Hero.States
{
    internal class Running : IStateObject
    {
        Texture2D _heroTexture;
        Animation _animation;
        HeroClass _heroInstance;
        private float _initialHeight;
        private Vector2 _position;
        private Vector2 _currentPosition;
        public int frameWidth { get; set; }
        private SoundEffect _sound;
        public Running(ContentManager content, HeroClass heroInstance)
        {
            /*
             *  RUNNING STATE Hero/Run
             *  FRAMES: 8
             */
            _heroInstance = heroInstance;
            _initialHeight = _heroInstance.getPosition().Y;
            _heroTexture = content.Load<Texture2D>("Hero/Run");
            _sound = content.Load<SoundEffect>("Sound/Hero/walk");
            frameWidth = _heroTexture.Width / 8;
            _animation = new Animation(8);
            _animation.AddFrame(new AnimationFrame(new Rectangle(0, 0, frameWidth, _heroTexture.Height)));
            _animation.AddFrame(new AnimationFrame(new Rectangle(frameWidth, 0, frameWidth, _heroTexture.Height)));
            _animation.AddFrame(new AnimationFrame(new Rectangle(frameWidth * 2, 0,frameWidth, _heroTexture.Height)));
            _animation.AddFrame(new AnimationFrame(new Rectangle(frameWidth * 3, 0,frameWidth, _heroTexture.Height)));
            _animation.AddFrame(new AnimationFrame(new Rectangle(frameWidth * 4, 0,frameWidth, _heroTexture.Height)));
            _animation.AddFrame(new AnimationFrame(new Rectangle(frameWidth * 5, 0,frameWidth, _heroTexture.Height)));
            _animation.AddFrame(new AnimationFrame(new Rectangle(frameWidth * 6, 0,frameWidth, _heroTexture.Height)));
            _animation.AddFrame(new AnimationFrame(new Rectangle(frameWidth * 7, 0,frameWidth, _heroTexture.Height)));
            _sound.Play();
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 position, SpriteEffects effect)
        {
            _currentPosition = position + _position;
            spriteBatch.Draw(_heroTexture, position, _animation._currentFrame._sourceRectangle, Color.White, 0f, Vector2.Zero, 1f, effect, 0f);
        }
        public void Update(GameTime gameTime)
        {

            _position = _currentPosition;
            if(Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                _position.X -= 2f;
                
            }
            if(Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                _position.X += 2f;
            }
            _animation.Update(gameTime);
            _heroInstance.setPosition(new Vector2(_currentPosition.X, _initialHeight));
        }
    }
}
