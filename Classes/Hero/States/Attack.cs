using Forest_of_wrath.Interfaces;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Forest_of_wrath.Classes.Animations;

namespace Forest_of_wrath.Classes.Hero.States
{
    internal class Attack : IStateObject
    {
        Texture2D _heroTexture;
        Animation _animation;
        public int frameWidth { get; set; }
        public Attack(ContentManager content)
        {
            /*
             *  Attack STATE Hero/Attack
             *  FRAMES: 4
             */
            _heroTexture = content.Load<Texture2D>("Hero/Attack1");
            frameWidth = _heroTexture.Width / 4;
            _animation = new Animation(6);
            _animation.AddFrame(new AnimationFrame(new Rectangle(0, 0, frameWidth, _heroTexture.Height)));
            _animation.AddFrame(new AnimationFrame(new Rectangle(frameWidth, 0, frameWidth, _heroTexture.Height)));
            _animation.AddFrame(new AnimationFrame(new Rectangle(frameWidth * 2, 0, frameWidth, _heroTexture.Height)));
            _animation.AddFrame(new AnimationFrame(new Rectangle(frameWidth * 3, 0, frameWidth, _heroTexture.Height)));
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
