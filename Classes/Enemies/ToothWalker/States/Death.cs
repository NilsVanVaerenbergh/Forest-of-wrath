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
        public Hitbox bodyHitBox { get; set; }

        private SoundEffect _sound;


        public Death(ContentManager content, GraphicsDeviceManager graphicsDevice)
        {
            /*
             *  DEATH STATE Hero/Death
             *  FRAMES: 6
             */
            _enemyTexture = content.Load<Texture2D>("Enemies/Toothwalker/Death");
            _sound = content.Load<SoundEffect>("Sound/Hero/death");
            frameWidth = _enemyTexture.Width / 4;
            _animation = new Animation(4);
            _animation.AddFrame(new AnimationFrame(new Rectangle(0, 0, frameWidth, _enemyTexture.Height)));
            _animation.AddFrame(new AnimationFrame(new Rectangle(frameWidth, 0, frameWidth, _enemyTexture.Height)));
            _animation.AddFrame(new AnimationFrame(new Rectangle(frameWidth * 2, 0, frameWidth, _enemyTexture.Height)));
            _animation.AddFrame(new AnimationFrame(new Rectangle(frameWidth * 3, 0, frameWidth, _enemyTexture.Height)));
            _sound.Play();
            bodyHitBox = new Hitbox(graphicsDevice);
            bodyHitBox.Load(0, 0, new Vector2(0, 0));
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 position, SpriteEffects effect)
        {
            bodyHitBox.Draw(spriteBatch, new Vector2(0, 0));
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
