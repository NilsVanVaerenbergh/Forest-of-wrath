using Forest_of_wrath.Interfaces;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Forest_of_wrath.Classes.Animations;
using Forest_of_wrath.Classes.Collision;
using Forest_of_wrath.Classes.UI;
using System.Collections.Generic;

namespace Forest_of_wrath.Classes.Hero.States
{
    internal class Attack : IStateObject
    {
        private Texture2D _heroTexture;
        private Animation _animation;
        public int frameWidth { get; set; }
        public Hitbox bodyHitBox { get; set; }
        public Hitbox swordHitBox { get; set; }
        private HeroClass _heroInstance;
        private List<IEnemyObject> _enemyList;
        private float _damage;
        public Attack(ContentManager content, HeroClass instance, GraphicsDeviceManager graphicsDevice, List<IEnemyObject> enemyList)
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
            _heroInstance = instance;
            bodyHitBox = new Hitbox(graphicsDevice);
            bodyHitBox.Load(22, 65, new Vector2(0,0));
            swordHitBox = new Hitbox(graphicsDevice);
            swordHitBox.Load(60, 10, new Vector2(0, 0));
            _damage = 25f;
            _enemyList = enemyList;

        }
        public void Draw(SpriteBatch spriteBatch, Vector2 position, SpriteEffects effect)
        {
            bodyHitBox.Draw(spriteBatch, new Vector2(position.X + 75f, position.Y + 59f));

            if(_heroInstance._flip == SpriteEffects.FlipHorizontally)
            {
                swordHitBox.Draw(spriteBatch, new Vector2(position.X - 2f, position.Y + 90f));
            } else
            {
                swordHitBox.Draw(spriteBatch, new Vector2(position.X + 110f, position.Y + 90f));
            }
            spriteBatch.Draw(_heroTexture, position, _animation._currentFrame._sourceRectangle, Color.White, 0f, Vector2.Zero, 1f, effect, 0f);
        }
        public void Update(GameTime gameTime, Hitbox hitbox = null)
        {
            if(_animation._currentFrame == _animation._lastFrame)
            {
                invokeAttack();
                _heroInstance.setState(Character.CharacterState.IDLE);
            }
            _animation.Update(gameTime);
        }
        private void invokeAttack()
        {
            _enemyList.ForEach(enemy =>
            {
                if(swordHitBox.rect.Intersects(enemy.getState().bodyHitBox.rect))
                {
                    enemy.setHealth(_damage);
                }
            });
        }
    }
}
