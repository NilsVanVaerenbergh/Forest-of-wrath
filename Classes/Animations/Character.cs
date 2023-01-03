using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_of_wrath.Classes.Animations
{
    internal class Character
    {
        public enum CharacterState
        {
            RUNNING,
            IDLE,
            ATTACK,
            DEATH,
            JUMP
        }
        public enum CharacterSound
        {
            RUNNING,
            IDLE,
            ATTACK,
            DEATH
        }
    }
}
