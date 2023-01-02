using Forest_of_wrath.Classes.Handlers;
using Forest_of_wrath.Interfaces;
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
        private Vector2 _currentPosition;
        private Vector2 _velocity;
        private CollisionHandler _collision;
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
            _currentPosition = _heroInstance.getPosition();
            _collision = new CollisionHandler(frameWidth, _heroTexture.Height);
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 position, SpriteEffects effect)
        {
            _currentPosition = position;
            spriteBatch.Draw(_heroTexture, position, _animation._currentFrame._sourceRectangle, Color.White, 0f, Vector2.Zero, 1f, effect, 0f);
        }
        public void Update(GameTime gameTime)
        {
            /*
             *  distance [x1,y1,x2,y2]
             */
            float[] distance = _collision.distanceFromWindow(_currentPosition);
            if(Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                if(Keyboard.GetState().IsKeyDown(Keys.Right) || distance[0] <= 0) 
                {
                    _velocity = new Vector2(0, 0);
                } else
                {
                    _velocity = new Vector2(-2f, 0f);
                }
                
            }
            if(Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Left) || distance[2] <= 0)
                {
                    _velocity = new Vector2(0, 0);
                }
                else
                {
                    _velocity = new Vector2(2f, 0f);
                }
            }
            _currentPosition += _velocity;
            _animation.Update(gameTime);
            _heroInstance.setPosition(_currentPosition);
            // Previous Move code from HeroClass
            //if (_state is not Running && _state is not Jumping)
            //{
            //    setState(CharacterState.RUNNING);
            //    activeVelocity = x;
            //    if (x <= -1 && _position.X <= 0 || x >= 1 && _position.X + _state.frameWidth > GraphicsDeviceManager.DefaultBackBufferWidth)
            //    {
            //        _snelheid = new Vector2(0, y);
            //    }
            //    else
            //    {
            //        _snelheid = new Vector2(x, y);
            //    }
            //}
            //_position += _snelheid;
        }
    }
}
