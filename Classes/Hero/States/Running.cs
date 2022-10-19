using Forest_of_wrath.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_of_wrath.Classes.Hero.States
{
    internal class Running : IStateObject
    {
        Texture2D _heroTexture;
        Animation _animation;
        private int _frameWidth;
        public Running(ContentManager content)
        {
            /*
             *  RUNNING STATE Hero/Run
             *  FRAMES: 8
             */
            _heroTexture = content.Load<Texture2D>("Hero/Run");
            _frameWidth = _heroTexture.Width / 8;
            _animation = new Animation(8);
            _animation.AddFrame(new AnimationFrame(new Rectangle(0, 0, _frameWidth, _heroTexture.Height)));
            _animation.AddFrame(new AnimationFrame(new Rectangle(_frameWidth, 0, _frameWidth, _heroTexture.Height)));
            _animation.AddFrame(new AnimationFrame(new Rectangle(_frameWidth * 2, 0, _frameWidth, _heroTexture.Height)));
            _animation.AddFrame(new AnimationFrame(new Rectangle(_frameWidth * 3, 0, _frameWidth, _heroTexture.Height)));
            _animation.AddFrame(new AnimationFrame(new Rectangle(_frameWidth * 4, 0, _frameWidth, _heroTexture.Height)));
            _animation.AddFrame(new AnimationFrame(new Rectangle(_frameWidth * 5, 0, _frameWidth, _heroTexture.Height)));
            _animation.AddFrame(new AnimationFrame(new Rectangle(_frameWidth * 6, 0, _frameWidth, _heroTexture.Height)));
            _animation.AddFrame(new AnimationFrame(new Rectangle(_frameWidth * 7, 0, _frameWidth, _heroTexture.Height)));
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 position, SpriteEffects effect)
        {
            spriteBatch.Draw(_heroTexture, position, _animation._currentFrame._sourceRectangle, Color.White, 0f, Vector2.Zero, 1f, effect, 0f);
        }

        public void Update(GameTime gameTime)
        {
            _animation.Update(gameTime);
        }
    }
}
