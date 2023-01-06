using Forest_of_wrath.Classes.Animations;
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
    internal class BatAttack : EnemyAttack
    {
        public BatAttack(ContentManager content, GraphicsDeviceManager graphicsDevice, Enemy enemyInstance, string locationPath, string soundLocation, int frames, int[] hitBoxSize, float[] hitBoxOffset) : base(content, graphicsDevice, enemyInstance, locationPath, soundLocation,frames,hitBoxSize,hitBoxOffset) { }

        override public void Update(GameTime gameTime)
        {
            float[] distance = collision.distanceFromHero(new Vector2(bodyHitBox.rect.X, bodyHitBox.rect.Y), heroPosition);
            if (distance[2] < 0f && enemyInstance.getState() is not EnemyDeath)
            {
                if (animation._currentFrame == animation._lastFrame)
                {
                    enemyInstance.setState(Character.CharacterState.DEATH);

                }
            }
            if (distance[2] > 20f && enemyInstance.getState() is not EnemyDeath)
            {
                if (animation._currentFrame == animation._lastFrame)
                {
                    enemyInstance.setState(Character.CharacterState.DEATH);

                }
            }
            animation.Update(gameTime);
        }
    }
}
