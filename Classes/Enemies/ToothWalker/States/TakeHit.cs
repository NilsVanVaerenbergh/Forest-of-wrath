using Forest_of_wrath.Classes.Animations;
using Forest_of_wrath.Classes.Collision;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forest_of_wrath.Interfaces;
using Forest_of_wrath.Classes.Handlers;

namespace Forest_of_wrath.Classes.Enemies.ToothWalker.States
{
    internal class TakeHit : IStateObject
    {
        Texture2D _enemyTexture;
        Animation _animation;
        public int frameWidth { get; set; }
        public Hitbox bodyHitBox { get; set; }
        private SoundEffect _sound;
        private CollisionHandler _collision;

        ToothWalker _EnemyInstance;
        private Vector2 heroPosition;
        public TakeHit(ContentManager content, ToothWalker enemyInstance ,GraphicsDeviceManager graphicsDevice)
        {
            /*
             *  TAKE HIT STATE Enemies/Toothwalker/Take Hit
             *  FRAMES: 4
             */
            _enemyTexture = content.Load<Texture2D>("Enemies/Toothwalker/Take Hit");
            _sound = content.Load<SoundEffect>("Sound/Enemies/Toothwalker/tW_death");
            frameWidth = _enemyTexture.Width / 4;
            _animation = new Animation(4);
            _animation.AddFrame(new AnimationFrame(new Rectangle(0, 0, frameWidth, _enemyTexture.Height)));
            _animation.AddFrame(new AnimationFrame(new Rectangle(frameWidth, 0, frameWidth, _enemyTexture.Height)));
            _animation.AddFrame(new AnimationFrame(new Rectangle(frameWidth * 2, 0, frameWidth, _enemyTexture.Height)));
            _animation.AddFrame(new AnimationFrame(new Rectangle(frameWidth * 3, 0, frameWidth, _enemyTexture.Height)));
            _sound.Play();
            _EnemyInstance = enemyInstance;
            bodyHitBox = new Hitbox(graphicsDevice);
            bodyHitBox.Load(13, 1, new Vector2(0, 0));
            _collision = new CollisionHandler(13, 45, graphicsDevice);
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 position, SpriteEffects effect)
        {
            bodyHitBox.Draw(spriteBatch, new Vector2(position.X + 75f, position.Y + 59f));
            spriteBatch.Draw(_enemyTexture, position, _animation._currentFrame._sourceRectangle, Color.White, 0f, Vector2.Zero, 1f, effect, 0f);
        }
        public void Update(GameTime gameTime, Hitbox hitbox = null)
        {
            if(_animation._currentFrame == _animation._lastFrame)
            { 
                float[] distance = _collision.distanceFromHero(new Vector2((float)bodyHitBox.rect.X, (float)bodyHitBox.rect.Y), heroPosition);
                if (distance[2] < 0f && _EnemyInstance.getState() is not Running)
                {
                    _EnemyInstance.setState(Character.CharacterState.RUNNING);
                }
                if (distance[2] > 20f && _EnemyInstance.getState() is not Running)
                {
                    _EnemyInstance.setState(Character.CharacterState.RUNNING);
                }
            }
            _animation.Update(gameTime);
        }
        public void SetHeroPosition(Vector2 position)
        {
            heroPosition = position;
        }
    }
}
