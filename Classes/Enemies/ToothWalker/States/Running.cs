using Forest_of_wrath.Classes.Animations;
using Forest_of_wrath.Classes.Collision;
using Forest_of_wrath.Classes.Handlers;
using Forest_of_wrath.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using Keyboard = Microsoft.Xna.Framework.Input.Keyboard;

namespace Forest_of_wrath.Classes.Enemies.ToothWalker.States
{
    internal class Running : IStateObject
    {
        Texture2D _enemyTexture;
        Animation _animation;
        ToothWalker _EnemyInstance;
        private float _initialHeight;
        private Vector2 _currentPosition;
        private Vector2 _velocity;
        private float _randomXVelocity;
        private CollisionHandler _collision;
        private Vector2 heroPosition;
        public int frameWidth { get; set; }
        private SoundEffect _sound;

        public Hitbox bodyHitBox { get; set; }
        public Running(ContentManager content, ToothWalker enemyInstance, GraphicsDeviceManager graphicsDevice, float randomXVelocity)
        {
            /*
             *  RUNNING STATE Enemies/ToothWalker/Run
             *  FRAMES: 8
             */
            _EnemyInstance = enemyInstance;
            _initialHeight = _EnemyInstance.getPosition().Y;
            _enemyTexture = content.Load<Texture2D>("Enemies/ToothWalker/Run");
            _sound = content.Load<SoundEffect>("Sound/Hero/walk"); // change to other sound
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
            _sound.Play();
            _currentPosition = _EnemyInstance.getPosition();
            bodyHitBox = new Hitbox(graphicsDevice);
            bodyHitBox.Load(22, 65);
            _collision = new CollisionHandler(22, 65, graphicsDevice);
            _randomXVelocity = randomXVelocity;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 position, SpriteEffects effect)
        {
            _currentPosition = position;
            bodyHitBox.Draw(spriteBatch, new Vector2(position.X + 75f, position.Y + 59f));
            spriteBatch.Draw(_enemyTexture, position, _animation._currentFrame._sourceRectangle, Color.White, 0f, Vector2.Zero, 1f, effect, 0f);
        }
        public void Update(GameTime gameTime, Hitbox hitbox)
        {
            /*
             *  distance [x1,y1,x2,y2]
             */
            float[] distance = _collision.distanceFromHero(bodyHitBox.HitBoxPosition, heroPosition);
            System.Diagnostics.Debug.WriteLine(_EnemyInstance.getState());
            if (distance[2] == 0f && _EnemyInstance.getState() is not Attack)
            {
                _EnemyInstance.setState(Character.CharacterState.ATTACK);
            }
            if (_EnemyInstance.getState() is not Attack && distance[2] > 15f && distance[2] < 23f)
            {
                _EnemyInstance.setState(Character.CharacterState.ATTACK);
            }
            if (distance[2] == 0f)
            {
                _velocity = new Vector2(0, 0);
            } else if (distance[2] > 22f) 
            {
                _velocity = new Vector2(-_randomXVelocity, 0f);
                _EnemyInstance.setFlip(SpriteEffects.FlipHorizontally);

            } else if(distance[2] < 0f)
            {
                _velocity = new Vector2(_randomXVelocity, 0f);
                _EnemyInstance.setFlip(SpriteEffects.None);
            }
 
            _currentPosition += _velocity;
            _animation.Update(gameTime);
            _EnemyInstance.setPosition(_currentPosition);
        }
        public void SetHeroPosition(Vector2 position)
        {
            heroPosition = position;
        }
    }
}
