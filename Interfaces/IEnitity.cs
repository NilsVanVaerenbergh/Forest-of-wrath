using Forest_of_wrath.Entities;
using Forest_of_wrath.Handlers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_of_wrath.Interfaces
{
    internal interface IEnitity
    {
        public void SetHealth(int health);
        public int GetHealth();

        public IAnimationObject GetAnimationObject();
        public void SetAnimationObject(IAnimationObject animation);
        public void SetXVelocity(float velocity);
        public void SetYVelocity(float velocity);
        public Vector2 GetPosition();
        public Hitbox GetHitbox();
        public void SetEffect(SpriteEffects effect);
    }
}
