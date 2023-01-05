using Forest_of_wrath.Classes.Animations;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_of_wrath.Interfaces
{
    internal interface IEnemyObject
    {

        Vector2 _position { get; set; }
        float baseHealth { get; set; }
        void Update(GameTime gameTime, Vector2 heroPos, float multiplier);
        void Draw(SpriteBatch spriteBatch);

        IStateObject getState();
        void setState(Character.CharacterState state);
        void setHealth(float damage);
        float getHealth();
    }
}
