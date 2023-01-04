using Forest_of_wrath.Interfaces;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Forest_of_wrath.Classes.Animations;
using Forest_of_wrath.Classes.Collision;

namespace Forest_of_wrath.Classes.Enemies.ToothWalker.States
{
    internal class Attack : IStateObject
    {
        Texture2D _enemyTexture;
        Animation _animation;
        public int frameWidth { get; set; }
        public Hitbox bodyHitBox { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public Attack(ContentManager content)
        {
            /*
             *  Attack STATE Hero/Attack
             *  FRAMES: 4
             */
            _enemyTexture = content.Load<Texture2D>("Hero/Attack1");
            frameWidth = _enemyTexture.Width / 4;
            _animation = new Animation(6);
            _animation.AddFrame(new AnimationFrame(new Rectangle(0, 0, frameWidth, _enemyTexture.Height)));
            _animation.AddFrame(new AnimationFrame(new Rectangle(frameWidth, 0, frameWidth, _enemyTexture.Height)));
            _animation.AddFrame(new AnimationFrame(new Rectangle(frameWidth * 2, 0, frameWidth, _enemyTexture.Height)));
            _animation.AddFrame(new AnimationFrame(new Rectangle(frameWidth * 3, 0, frameWidth, _enemyTexture.Height)));
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 position, SpriteEffects effect)
        {
            spriteBatch.Draw(_enemyTexture, position, _animation._currentFrame._sourceRectangle, Color.White, 0f, Vector2.Zero, 1f, effect, 0f);
        }
        public void Update(GameTime gameTime, Hitbox hitbox = null)
        {
            _animation.Update(gameTime);
        }
    }
}
