using Forest_of_wrath.Classes.Animations;
using Forest_of_wrath.Interfaces;
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

        public int Health { get; set; }
        public DateTime creationTime;
        public Enemy(int newHealth) { 
            creationTime = DateTime.Now;
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
    }
}
