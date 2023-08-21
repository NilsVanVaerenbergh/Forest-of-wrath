using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Forest_of_wrath.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Forest_of_wrath.Entities
{
    internal class Enemy : IEnitity
    {
        public enum EnemyState { 
            RUNNING,
            FLIGHT,
            ATTACK,
            IDLE 
        }
        private int health;
        private int attackDamage;
        private IAnimationObject animation;
        private Vector2 position;
        private Vector2 velocity;
        private SpriteEffects spriteEffect;
        public Enemy(int health, IAnimationObject animation, Vector2 position)
        {
            this.health = health;
            attackDamage = 1;
            this.animation = animation;
            this.position = position;
            spriteEffect = SpriteEffects.None;
        }
        public virtual void Draw() { animation.Draw(position, spriteEffect); }
        public void Update(GameTime gameTime) 
        { 
            animation.Update(gameTime); 
            position += velocity; 
        }
        public IAnimationObject GetAnimationObject() { return animation; }
        public void SetAnimationObject(IAnimationObject animation) { this.animation = animation; }
        public virtual int GetAttackDamage() { return attackDamage; }
        public int GetHealth() { return health; }
        public void SetHealth(int health) { this.health = health; }
        public virtual void SetAnimation(EnemyState state) { throw new NotImplementedException(); }

        public void SetXVelocity(float velocity)
        {
            this.velocity.X = velocity;
        }
        public void SetYVelocity(float velocity)
        {
            this.velocity.Y = velocity;
        }
        public Vector2 GetPosition() { return position; }
        public virtual Hitbox GetHitbox() { throw new NotImplementedException(); }
        public void SetEffect(SpriteEffects effect) { spriteEffect = effect; }
        public SpriteEffects GetEffect() { return spriteEffect; }

        public virtual EnemyState GetEnemyState() { throw new NotImplementedException(); }

    }
}
