using Forest_of_wrath.Interfaces;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Forest_of_wrath.Classes.Animations;

namespace Forest_of_wrath.Classes.Hero.States
{
    internal class Death : IStateObject
    {
        Texture2D _heroTexture;
        Animation _animation;
        public int frameWidth { get; set; }

        private SoundEffect _sound;


        public Death(ContentManager content)
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
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 position, SpriteEffects effect)
        {
            spriteBatch.Draw(_heroTexture, position, _animation._currentFrame._sourceRectangle, Color.White, 0f, Vector2.Zero, 1f, effect, 0f);
        }
        public void Update(GameTime gameTime)
        {
            if(_animation._currentFrame != _animation._lastFrame)
            {
                _animation.Update(gameTime);
            } 
        }
    }
}
