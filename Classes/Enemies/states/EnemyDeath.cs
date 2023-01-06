using Forest_of_wrath.Classes.Animations;
using Forest_of_wrath.Classes.Collision;
using Forest_of_wrath.Classes.Handlers;
using Forest_of_wrath.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_of_wrath.Classes.Enemies.states
{
    internal class EnemyDeath : IEnemyStateObject
    {
        // Texture handeling:
        public int frameWidth { get; set; }
        public Animation animation { get; set; }
        private Texture2D enemyTexture;
        // Mechanics:
        public Hitbox bodyHitBox { get; set; }
        // Entity instances:
        private Vector2 heroPosition;
        public Enemy enemyInstance;
        public EnemyDeath(ContentManager content, GraphicsDeviceManager graphicsDevice, Enemy enemyInstance, string locationPath, int frames)
        {
            enemyTexture = content.Load<Texture2D>(locationPath);
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
            bodyHitBox.Load(0, 0, new Vector2(0, 0));
        }
        virtual public void Draw(SpriteBatch spriteBatch, Vector2 position, SpriteEffects effect)
        {
            bodyHitBox.Draw(spriteBatch, new Vector2(0,0));
            spriteBatch.Draw(enemyTexture, position, animation._currentFrame._sourceRectangle, Color.White, 0f, Vector2.Zero, 1f, effect, 0f);
        }
        virtual public void Update(GameTime gameTime)
        {
            if (animation._currentFrame != animation._lastFrame)
            {
                animation.Update(gameTime);
            }

        }
        public void setHeroPosition(Vector2 position)
        {
            heroPosition = position;
        }
    }
}
