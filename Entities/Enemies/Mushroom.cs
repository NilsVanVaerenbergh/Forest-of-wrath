using Forest_of_wrath.Entities.EnemyAnimations.Goblin;
using Forest_of_wrath.Entities.EnemyAnimations.Mushroom;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_of_wrath.Entities.Enemies
{
    internal class Mushroom : Enemy
    {
        private Hitbox hitbox;
        private EnemyState enemyState;

        public Mushroom(int health, Vector2 position) : base(health, new MushroomIdle(), position) 
        {
            hitbox = new Hitbox();
            hitbox.Load(15, 25, new Vector2(GetPosition().X, GetPosition().Y), Color.Red);
            enemyState = EnemyState.IDLE;
        }

        public override void Draw()
        {
            base.Draw();
            if (GetEffect() == SpriteEffects.FlipHorizontally)
            {
                hitbox.Draw(new Vector2(GetPosition().X + 70, GetPosition().Y + 75));
            }
            else
            {
                hitbox.Draw(new Vector2(GetPosition().X + 70, GetPosition().Y + 75));
            }
        }

        public override Hitbox GetHitbox()
        {
            return hitbox;
        }
        public override void SetAnimation(EnemyState state)
        {
            enemyState = state;
            switch (state)
            {
                case EnemyState.IDLE:
                    SetAnimationObject(new MushroomIdle());
                    break;
                case EnemyState.ATTACK:
                    SetAnimationObject(new MushroomAttack());
                    break;
                case EnemyState.RUNNING:
                    SetAnimationObject(new MushroomRun());
                    break;
                default: return;
            }
        }
        public override EnemyState GetEnemyState()
        {
            return enemyState;
        }
    }
}
