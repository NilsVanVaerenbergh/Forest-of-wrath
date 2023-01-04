using Forest_of_wrath.Interfaces;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Forest_of_wrath.Classes.Animations;
using Forest_of_wrath.Classes.Collision;

namespace Forest_of_wrath.Classes.Enemies.ToothWalker.States
{
    internal class Death : IStateObject
    {
        Texture2D _enemyTexture;
        Animation _animation;
        public int frameWidth { get; set; }
        public Hitbox bodyHitBox { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        private SoundEffect _sound;


        public Death(ContentManager content)
        {
            /*
             *  DEATH STATE Hero/Death
             *  FRAMES: 6
             */
            _enemyTexture = content.Load<Texture2D>("Hero/Death");
            _sound = content.Load<SoundEffect>("Sound/Hero/death");
            frameWidth = _enemyTexture.Width / 9;
            _animation = new Animation(6);
            _animation.AddFrame(new AnimationFrame(new Rectangle(0, 0, frameWidth, _enemyTexture.Height)));
            _animation.AddFrame(new AnimationFrame(new Rectangle(frameWidth, 0, frameWidth, _enemyTexture.Height)));
            _animation.AddFrame(new AnimationFrame(new Rectangle(frameWidth * 2, 0, frameWidth, _enemyTexture.Height)));
            _animation.AddFrame(new AnimationFrame(new Rectangle(frameWidth * 3, 0, frameWidth, _enemyTexture.Height)));
            _animation.AddFrame(new AnimationFrame(new Rectangle(frameWidth * 4, 0, frameWidth, _enemyTexture.Height)));
            _animation.AddFrame(new AnimationFrame(new Rectangle(frameWidth * 5, 0, frameWidth, _enemyTexture.Height)));
            _animation.AddFrame(new AnimationFrame(new Rectangle(frameWidth * 6, 0, frameWidth, _enemyTexture.Height)));
            _animation.AddFrame(new AnimationFrame(new Rectangle(frameWidth * 8, 0, frameWidth, _enemyTexture.Height)));
            _sound.Play();
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 position, SpriteEffects effect)
        {
            spriteBatch.Draw(_enemyTexture, position, _animation._currentFrame._sourceRectangle, Color.White, 0f, Vector2.Zero, 1f, effect, 0f);
        }
        public void Update(GameTime gameTime, Hitbox hitbox = null)
        {
            if(_animation._currentFrame != _animation._lastFrame)
            {
                _animation.Update(gameTime);
            } 
        }
    }
}
