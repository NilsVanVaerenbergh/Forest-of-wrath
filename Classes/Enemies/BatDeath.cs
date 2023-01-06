using Forest_of_wrath.Classes.Enemies.states;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_of_wrath.Classes.Enemies
{
    internal class BatDeath: EnemyDeath
    {
        public BatDeath(ContentManager content, GraphicsDeviceManager graphicsDevice, Enemy enemyInstance,string locationPath, int frame) : base(content, graphicsDevice,enemyInstance,locationPath,frame)
        {
            base.enemyInstance= enemyInstance;
        }
        public override void Update(GameTime gameTime)
        {
            if(enemyInstance.getPosition().Y < 400)
            {
                enemyInstance.setPosition(new Vector2(enemyInstance.getPosition().X, enemyInstance.getPosition().Y + 2f));
            }
            if (animation._currentFrame != animation._lastFrame)
            {
                animation.Update(gameTime);
            }
        }

    }
}
