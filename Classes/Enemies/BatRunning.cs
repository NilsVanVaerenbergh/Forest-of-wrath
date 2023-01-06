using Forest_of_wrath.Classes.Collision;
using Forest_of_wrath.Classes.Enemies.states;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Forest_of_wrath.Classes.Animations;
using Microsoft.Xna.Framework.Graphics;


namespace Forest_of_wrath.Classes.Enemies
{
    internal class BatRunning : EnemyRunning
    {


        public BatRunning(ContentManager content, GraphicsDeviceManager graphicsDevice, Enemy enemyInstance, Hitbox heroHitBox, Vector2 position, string locationPath, int frames, int[] hitBoxSize, float[] hitBoxOffset, float randomXVelocity) : base(content,graphicsDevice,enemyInstance,heroHitBox,position,locationPath,frames,hitBoxSize,hitBoxOffset,randomXVelocity)
        {
            base.enemyInstance = enemyInstance;
        }

        override public void Update(GameTime gameTime)
        {
            float[] distance = collision.distanceFromHero(new Vector2(bodyHitBox.rect.X, bodyHitBox.rect.Y), heroPosition);


            if (enemyInstance.getPosition().Y > 350)
            {
                currentPosition.Y = 350;
            }

            if (distance[2] == 0f && enemyInstance.getState() is not EnemyAttack)
            {
                enemyInstance.setState(Character.CharacterState.ATTACK);
            }
            if (distance[2] > 0f && distance[2] < 23f && enemyInstance.getState() is not EnemyAttack)
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


    }
}
