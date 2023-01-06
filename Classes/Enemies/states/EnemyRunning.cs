using Forest_of_wrath.Classes.Animations;
using Forest_of_wrath.Classes.Collision;
using Forest_of_wrath.Classes.Handlers;
using Forest_of_wrath.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_of_wrath.Classes.Enemies.states
{
    internal class EnemyRunning : IEnemyStateObject
    {
        // Texture handeling:
        public int frameWidth { get; set; }
        public Animation animation { get; set; }
        private Texture2D enemyTexture;
        // Mechanics:
        public Hitbox bodyHitBox { get; set; }
        private float[] hitboxOffset = new float[2];
        public CollisionHandler collision;
        public Vector2 currentPosition;
        public float randomXVelocity;
        public Vector2 velocity;
        // Entity instances:
        public Vector2 heroPosition;
        public Hitbox heroHitBox;
        public Enemy enemyInstance;
        public EnemyRunning(ContentManager content, GraphicsDeviceManager graphicsDevice, Enemy enemyInstance, Hitbox heroHitBox, Vector2 position,string locationPath, int frames, int[] hitBoxSize, float[] hitBoxOffset, float randomXVelocity) 
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
            currentPosition = position;
            enemyTexture = content.Load<Texture2D>(locationPath);
            this.enemyInstance = enemyInstance;
            this.heroHitBox = heroHitBox;
            frameWidth = enemyTexture.Width / frames;
            animation = new Animation(frames);
            this.randomXVelocity= randomXVelocity;
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
            currentPosition = position;
            bodyHitBox.Draw(spriteBatch, new Vector2(currentPosition.X + hitboxOffset[0], currentPosition.Y + hitboxOffset[1]));
            spriteBatch.Draw(enemyTexture, new Vector2(currentPosition.X, currentPosition.Y), animation._currentFrame._sourceRectangle, Color.White, 0f, Vector2.Zero, 1f, effect, 0f);
        }
        virtual public void Update(GameTime gameTime)
        {
            float[] distance = collision.distanceFromHero(new Vector2(bodyHitBox.rect.X, bodyHitBox.rect.Y), heroPosition);


            if (distance[2] == 0f && enemyInstance.getState() is not EnemyAttack)
            {
                enemyInstance.setState(Character.CharacterState.ATTACK);
            }
            if(distance[2] > 0f && distance[2] < 23f && enemyInstance.getState() is not EnemyAttack)
            {
                enemyInstance.setState(Character.CharacterState.ATTACK);
            }
            if (heroHitBox.rect.Intersects(bodyHitBox.rect) && enemyInstance.getState() is not EnemyAttack)
            {
                enemyInstance.setState(Character.CharacterState.ATTACK);
            }
            #region MovementAI
            if (distance[2] == 0f)
            {
                velocity = new Vector2(0, 0);
            }
            else if (distance[2] > 14f)
            {
                velocity = new Vector2(-randomXVelocity, 0f);
                enemyInstance.setFlip(SpriteEffects.FlipHorizontally);

            }
            else if (distance[2] < 0f)
            {
                velocity = new Vector2(randomXVelocity, 0f);
                enemyInstance.setFlip(SpriteEffects.None);
            }
            currentPosition += velocity;
            enemyInstance.setPosition(currentPosition);
            #endregion
            animation.Update(gameTime);
        }
        public void setHeroPosition(Vector2 position)
        {
            heroPosition = position;
        }
    }
}
