using Forest_of_wrath.Classes.Animations;
using Forest_of_wrath.Classes.Hero;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_of_wrath.Interfaces
{
    internal interface ICharacterObject
    {
        public int Health { get; set; }
        void setState(Character.CharacterState state);
        void setFlip(SpriteEffects effect);
    }
}
