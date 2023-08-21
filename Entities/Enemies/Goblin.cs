using Forest_of_wrath.Entities.EnemyAnimations.Bat;
using Forest_of_wrath.Entities.EnemyAnimations.Goblin;
using Forest_of_wrath.Entities.EnemyAnimations.Mushroom;
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
    internal class Goblin : Enemy
    {
        private EnemyState enemyState;
        private Hitbox hitbox;
        public Goblin(int health, Vector2 position) : base(health, new GoblinIdle(), position) {
            hitbox = new Hitbox();
            hitbox.Load(15, 15, new Vector2(GetPosition().X, GetPosition().Y), Color.Red);
            enemyState = EnemyState.IDLE;
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
        public override void SetAnimation(EnemyState state)
        {
            enemyState = state;
            switch (state)
            {
                case EnemyState.IDLE:
                    SetAnimationObject(new GoblinIdle());
                    break;
                case EnemyState.ATTACK:
                    SetAnimationObject(new GoblinAttack());
                    break;
                case EnemyState.RUNNING:
                    SetAnimationObject(new GoblinRun());
                    break;
                default: return;
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
