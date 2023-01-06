using Forest_of_wrath.Classes.Animations;
using Forest_of_wrath.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_of_wrath.Classes.Enemies
{
    internal class Enemy : ICharacterObject
    {
        public float Health { get; set; }

        public float baseDamage { get; set; }
        public float multiplier { get; set; }
        public Enemy(float newHealth) { 
            Health = newHealth;
        }
        virtual public void setFlip(SpriteEffects effect)
        {
            throw new NotImplementedException();
        }
        virtual public void setState(Character.CharacterState state)
        {
            throw new NotImplementedException();
        }
        virtual public IEnemyStateObject getState()
        {
            throw new NotImplementedException();
        }
        virtual public void setPosition(Vector2 positon)
        {
            throw new NotImplementedException();
        }

        virtual public Vector2 getPosition()
        {
            throw new NotImplementedException();
        }
    }
}
