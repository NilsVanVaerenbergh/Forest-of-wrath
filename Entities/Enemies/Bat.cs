using Forest_of_wrath.Entities.EnemyAnimations.Bat;
using Forest_of_wrath.Entities.EnemyAnimations.Goblin;
using Forest_of_wrath.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Forest_of_wrath.Entities.Enemy;

namespace Forest_of_wrath.Entities.Enemies
{
    internal class Bat : Enemy
    {
        Hitbox hitbox;
        private EnemyState enemyState;
        public Bat(int health, Vector2 position) : base(health, new BatFlight(), position)
        {
            hitbox = new Hitbox();
            hitbox.Load(15,15,new Vector2(GetPosition().X, GetPosition().Y),Color.Red);
            enemyState = EnemyState.FLIGHT;
        }
        public override void Draw()
        {
            base.Draw();
            if (GetEffect() == SpriteEffects.FlipHorizontally)
            {
                hitbox.Draw(new Vector2(GetPosition().X + 60, GetPosition().Y + 75));
            }
            else
            {
                hitbox.Draw(new Vector2(GetPosition().X + 75, GetPosition().Y + 75));
            }
        }
        public override int GetAttackDamage()
        {
            return ( base.GetAttackDamage() * 10 );
        }
        public override void SetAnimation(EnemyState state)
        {
            enemyState = state;
            switch (state)
            {
                case EnemyState.FLIGHT:
                    SetAnimationObject(new BatFlight());
                    break;
                case EnemyState.ATTACK:
                    SetAnimationObject(new BatAttack());
                    break;
                default:
                    enemyState = state;
                    SetAnimationObject(new BatFlight());
                    break;
            }
        }
        public override Hitbox GetHitbox()
        {
            return hitbox;
        }
        public override EnemyState GetEnemyState()
        {
            return enemyState;
        }
    }
}
