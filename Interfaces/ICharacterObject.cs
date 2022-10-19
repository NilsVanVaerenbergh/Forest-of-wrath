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
        void setState(CharacterState state);
        void setSpeed(int x, int y);

        void setFlip(SpriteEffects effect);
    }
}
