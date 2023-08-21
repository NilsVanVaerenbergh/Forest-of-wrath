using Forest_of_wrath.Entities;
using Forest_of_wrath.Entities.Enemies;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_of_wrath.Handlers
{
    internal class EnemyAttackHandler
    {
        public EnemyAttackHandler() { }
        public void Update(GameTime gameTime)
        {
            foreach(Enemy enemy in Globals.enemies)
            {
                Debug.WriteLine($"{enemy.GetType()} intersects with hero {enemy.GetHitbox().GetRectangle().Intersects(Globals.hero.GetHitbox().GetRectangle())} in state {enemy.GetEnemyState()}");
                if(enemy.GetHitbox().GetRectangle().Intersects(Globals.hero.GetHitbox().GetRectangle()))
                {
                    if(enemy.GetEnemyState() != Enemy.EnemyState.ATTACK)
                    {
                        enemy.SetAnimation(Enemy.EnemyState.ATTACK);
                    }
                    Animation enemyAnimation = enemy.GetAnimationObject().GetAnimation();
                    if(enemyAnimation.getCurrentFrame() == enemyAnimation.getLastFrame())
                    {
                        if(enemy.GetHitbox().GetRectangle().Intersects(Globals.hero.GetHitbox().GetRectangle()) && !Globals.hero.IsHidden())
                        {
                            Globals.hero.SetHealth(Globals.hero.GetHealth() - enemy.GetAttackDamage());
                        }     
                    }          
                } else
                {
                    if (enemy.GetEnemyState() == Enemy.EnemyState.ATTACK)
                            enemy.SetAnimation(Enemy.EnemyState.IDLE);
                }
            }
        }

    }
}
