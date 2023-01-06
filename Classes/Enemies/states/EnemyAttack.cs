using Forest_of_wrath.Classes.Animations;
using Forest_of_wrath.Classes.Collision;
using Forest_of_wrath.Classes.Handlers;
using Forest_of_wrath.Classes.Hero;
using Forest_of_wrath.Classes.Hero.States;
using Forest_of_wrath.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Forest_of_wrath.Classes.Enemies.states
{
    internal class EnemyAttack : IEnemyStateObject
    {
        // Texture handeling:
        public int frameWidth { get; set; }
        public Animation animation { get; set; }
        private Texture2D enemyTexture;

        private SoundEffect sound;
        // Mechanics:
        public Hitbox bodyHitBox { get; set; }
        private float[] hitboxOffset = new float[2];
        public CollisionHandler collision;
        private DateTime LastDamagedTime;
        // Entity instances:
        public Vector2 heroPosition;
        private Hitbox heroHitBox { get; set; }
        public Enemy enemyInstance;


        public EnemyAttack(ContentManager content, GraphicsDeviceManager graphicsDevice, Enemy enemyInstance, string locationPath, string soundLocation, int frames, int[] hitBoxSize, float[] hitBoxOffset)
        {
            if (hitBoxSize.Length > 2 || hitBoxSize.Length <= 0) { throw new ArgumentException("int[2] hitBoxSize should contain 2 integers (width,height) example: [13,45]"); }
            if (hitBoxOffset.Length > 2 || hitBoxOffset.Length <= 0)
            {
                throw new ArgumentException("float[2] hitBoxOffset should contain 2 floats (x,y) example: [13f,45f]");
            }
            else
            {
                this.hitboxOffset = hitBoxOffset;
            }
            enemyTexture = content.Load<Texture2D>(locationPath);
            sound = content.Load<SoundEffect>(soundLocation);
            this.enemyInstance = enemyInstance;
            frameWidth = enemyTexture.Width / frames;
            animation = new Animation(frames);
            for (int i = 0; i < frames; i++)
            {
                if (i == 0)
                {
                    animation.AddFrame(new AnimationFrame(new Rectangle(0, 0, frameWidth, enemyTexture.Height)));

                }
                else
                {
                    animation.AddFrame(new AnimationFrame(new Rectangle(frameWidth * i, 0, frameWidth, enemyTexture.Height)));
                }
            }
            bodyHitBox = new Hitbox(graphicsDevice);
            bodyHitBox.Load(hitBoxSize[0], hitBoxSize[1], new Vector2(0, 0));
            collision = new CollisionHandler(hitBoxSize[0], hitBoxSize[1], graphicsDevice);
        }



        public void Draw(SpriteBatch spriteBatch, Vector2 position, SpriteEffects effect)
        {
            bodyHitBox.Draw(spriteBatch, new Vector2(position.X + hitboxOffset[0], position.Y + hitboxOffset[1]));
            spriteBatch.Draw(enemyTexture, position, animation._currentFrame._sourceRectangle, Color.White, 0f, Vector2.Zero, 1f, effect, 0f);
        }
        virtual public void Update(GameTime gameTime)
        {
            float[] distance = collision.distanceFromHero(new Vector2(bodyHitBox.rect.X, bodyHitBox.rect.Y), heroPosition);
            if (distance[2] < 0f && enemyInstance.getState() is not EnemyRunning)
            {
                if(animation._currentFrame == animation._lastFrame)
                {
                    enemyInstance.setState(Character.CharacterState.RUNNING);

                }
            }
            if (distance[2] > 20f && enemyInstance.getState() is not EnemyRunning)
            {
                if (animation._currentFrame == animation._lastFrame)
                {
                    enemyInstance.setState(Character.CharacterState.RUNNING);

                }
            }
            animation.Update(gameTime);
        }
        public void setHeroPosition(Vector2 position)
        {
            heroPosition = position;
        }
        virtual public void DealDamage(HeroClass hero, float multiplier)
        {
            TimeSpan soundDuration = sound.Duration;
            if (animation._currentFrame == animation._lastFrame)
            {
                TimeSpan elapsedTime = DateTime.Now - LastDamagedTime;
                if (elapsedTime >= soundDuration)
                {
                    sound.Play();
                    LastDamagedTime = DateTime.Now;
                }
                if(!hero.getHide())
                {
                    hero.Health -= enemyInstance.baseDamage * multiplier;
                }
            }
        }
    }
}
