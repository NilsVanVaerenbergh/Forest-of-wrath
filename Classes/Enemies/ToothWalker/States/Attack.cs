using Forest_of_wrath.Interfaces;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Forest_of_wrath.Classes.Animations;
using Forest_of_wrath.Classes.Collision;
using Forest_of_wrath.Classes.Handlers;
using Forest_of_wrath.Classes.Hero;
using System;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace Forest_of_wrath.Classes.Enemies.ToothWalker.States
{
    internal class Attack : IStateObject
    {
        private Texture2D _enemyTexture;
        private Animation _animation;
        private CollisionHandler _collision;
        ToothWalker _EnemyInstance;
        private Vector2 heroPosition;
        public int frameWidth { get; set; }
        public Hitbox bodyHitBox { get; set; }
        private SoundEffect _sound;
        private DateTime LastDamagedTime { get; set; }
        public Attack(ContentManager content, ToothWalker enemyInstance, GraphicsDeviceManager graphicsDevice)
        {
            /*
             *  Attack STATE Enemies/Toothwalker/Attack
             *  FRAMES: 8
             */
            _enemyTexture = content.Load<Texture2D>("Enemies/Toothwalker/Attack");
            _sound = content.Load<SoundEffect>("Sound/Enemies/Toothwalker/stab");
            frameWidth = _enemyTexture.Width / 8;
            _animation = new Animation(8);
            _animation.AddFrame(new AnimationFrame(new Rectangle(0, 0, frameWidth, _enemyTexture.Height)));
            _animation.AddFrame(new AnimationFrame(new Rectangle(frameWidth, 0, frameWidth, _enemyTexture.Height)));
            _animation.AddFrame(new AnimationFrame(new Rectangle(frameWidth * 2, 0, frameWidth, _enemyTexture.Height)));
            _animation.AddFrame(new AnimationFrame(new Rectangle(frameWidth * 3, 0, frameWidth, _enemyTexture.Height)));
            _animation.AddFrame(new AnimationFrame(new Rectangle(frameWidth * 4, 0, frameWidth, _enemyTexture.Height)));
            _animation.AddFrame(new AnimationFrame(new Rectangle(frameWidth * 5, 0, frameWidth, _enemyTexture.Height)));
            _animation.AddFrame(new AnimationFrame(new Rectangle(frameWidth * 6, 0, frameWidth, _enemyTexture.Height)));
            _animation.AddFrame(new AnimationFrame(new Rectangle(frameWidth * 7, 0, frameWidth, _enemyTexture.Height)));
            _EnemyInstance = enemyInstance;
            bodyHitBox = new Hitbox(graphicsDevice);
            bodyHitBox.Load(13, 45, Color.Red * 0.5f);
            _collision = new CollisionHandler(13, 45, graphicsDevice);
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 position, SpriteEffects effect)
        {
            bodyHitBox.Draw(spriteBatch, new Vector2(position.X + 75f, position.Y + 59f));
            spriteBatch.Draw(_enemyTexture, position, _animation._currentFrame._sourceRectangle, Color.White, 0f, Vector2.Zero, 1f, effect, 0f);
        }
        public void Update(GameTime gameTime, Hitbox hitbox = null)
        {
            float[] distance = _collision.distanceFromHero(bodyHitBox.HitBoxPosition, heroPosition);


            if (distance[2] < 0f && _EnemyInstance.getState() is not Running)
            {
                _EnemyInstance.setState(Character.CharacterState.RUNNING);
            }
            if (distance[2] > 20f && _EnemyInstance.getState() is not Running)
            {
                _EnemyInstance.setState(Character.CharacterState.RUNNING);
            }
            _animation.Update(gameTime);
        }
        public void SetHeroPosition(Vector2 position)
        {
            heroPosition = position;
        }
        public void dealDamage(HeroClass hero, float damage, float multiplier)
        {
            TimeSpan soundDuration = _sound.Duration;
            if (_animation._currentFrame == _animation._lastFrame)
            {
                TimeSpan elapsedTime = DateTime.Now - LastDamagedTime;
                if (elapsedTime >= soundDuration)
                {
                    _sound.Play();
                    LastDamagedTime = DateTime.Now;
                }
                hero.Health -= damage * multiplier;
            }
        }
    }
}
