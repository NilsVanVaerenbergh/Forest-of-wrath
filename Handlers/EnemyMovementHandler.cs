using Forest_of_wrath.Entities;
using Forest_of_wrath.Entities.Enemies;
using Forest_of_wrath.Entities.HeroAnimations;
using Forest_of_wrath.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_of_wrath.Handlers
{
    internal class EnemyMovementHandler
    {
        public EnemyMovementHandler() { }
        public void Update(GameTime gameTime)
        {
            foreach(Enemy enemy in Globals.enemies)
            {
                Vector2 heroMiddle = new Vector2(
                    Globals.hero.GetHitbox().GetRectangle().X + (Globals.hero.GetHitbox().GetRectangle().Width / 2),
                    Globals.hero.GetHitbox().GetRectangle().Y + (Globals.hero.GetHitbox().GetRectangle().Height / 2)
                );
                if (enemy is Bat )
                {
                    if (heroMiddle.X < enemy.GetHitbox().GetRectangle().X && enemy.GetAnimationObject() is not IDeathEnemy)
                    {
                        enemy.SetXVelocity(-0.7f);
                        enemy.SetEffect(Microsoft.Xna.Framework.Graphics.SpriteEffects.FlipHorizontally);
                    }
                    else if (heroMiddle.X > enemy.GetHitbox().GetRectangle().X && enemy.GetAnimationObject() is not IDeathEnemy)
                    {
                        enemy.SetXVelocity(0.7f);
                        enemy.SetEffect(Microsoft.Xna.Framework.Graphics.SpriteEffects.None);
                    }
                    else enemy.SetXVelocity(0f);

                    if (heroMiddle.Y < enemy.GetHitbox().GetRectangle().Y && enemy.GetAnimationObject() is not IDeathEnemy)
                    {
                        enemy.SetYVelocity(-0.8f);
                    }
                    else if (heroMiddle.Y > enemy.GetHitbox().GetRectangle().Y && enemy.GetAnimationObject() is not IDeathEnemy)
                    {
                        enemy.SetYVelocity(0.8f);
                    }
                    else enemy.SetYVelocity(0f);
                }
                else
                {
                    if (heroMiddle.X < enemy.GetHitbox().GetRectangle().X && enemy.GetAnimationObject() is not IDeathEnemy)
                    {
                        RunGroundEnemy(enemy, -0.8f);
                    }
                    else if (heroMiddle.X > enemy.GetHitbox().GetRectangle().X && enemy.GetAnimationObject() is not IDeathEnemy)
                    {
                        RunGroundEnemy(enemy, 0.8f);
                    } else
                    {
                        RunGroundEnemy(enemy, 0f);
                    }
                }
            }
        }
        private void RunGroundEnemy(Enemy enemy, float velocity)
        {
            float multiplier = 1f;
            if (enemy is Goblin)
                multiplier = 1.5f;
            enemy.SetXVelocity(velocity * multiplier);
            if(velocity < 0)
            {
                enemy.SetEffect(Microsoft.Xna.Framework.Graphics.SpriteEffects.FlipHorizontally);
            } else if(velocity > 0) 
            {
                enemy.SetEffect(Microsoft.Xna.Framework.Graphics.SpriteEffects.None);
            }
            if (enemy.GetEnemyState() != Enemy.EnemyState.RUNNING && enemy.GetEnemyState() != Enemy.EnemyState.ATTACK)
            {
                enemy.SetAnimation(Enemy.EnemyState.RUNNING);
            }
        }
    }
}
