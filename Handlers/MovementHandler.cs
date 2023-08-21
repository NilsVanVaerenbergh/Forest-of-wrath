using Forest_of_wrath.Entities;
using Forest_of_wrath.Entities.HeroAnimations;
using Forest_of_wrath.Entities.Platforms;
using Forest_of_wrath.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_of_wrath.Handlers
{
    internal class MovementHandler : IInputReader
    {

        PlatformHandler platformHandler;
        public MovementHandler() { 
            platformHandler = new PlatformHandler();
        }
        public void InputReader()
        {
            Hero hero = Globals.hero;
            Vector2 heroVelocity = hero.GetVelocity();
            platformHandler.setActivePlatformState(heroVelocity);
            if (Keyboard.GetState().IsKeyDown(Keys.Right) && 
                !Globals.collisionHandler.atRightBorder(hero.GetHitbox().GetRectangle().X + hero.GetHitbox().GetRectangle().Width))
            {
                hero.SetXVelocity(heroVelocity.X = 1.5f);
                hero.SetEffect(SpriteEffects.None);
                Running(hero);
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Left) && 
                    !Globals.collisionHandler.atLeftBorder(hero.GetHitbox().GetRectangle().X))
            {
                hero.SetXVelocity(heroVelocity.X = -1.5f);
                hero.SetEffect(SpriteEffects.FlipHorizontally);
                Running(hero);
            }
            else hero.SetXVelocity(heroVelocity.X = 0f);

            if (Keyboard.GetState().IsKeyUp(Keys.Left) && Keyboard.GetState().IsKeyUp(Keys.Right))
            {
                if(hero.GetAnimationObject() is not HeroIdle && !hero.HasJumped())
                {
                    HeroAnimationHandler.SetIdle();
                }
            }
            if(Keyboard.GetState().IsKeyDown(Keys.Up) && hero.HasJumped() == false)
            {
                float Y = hero.GetPosition().Y;
                hero.SetYPosition(Y -= 10f);
                hero.SetYVelocity(heroVelocity.Y = -5f);
                HeroAnimationHandler.SetJumping();
                hero.SetJumped(true);
            }
            if(hero.HasJumped() == true)
            {
                float i = 1;
                hero.SetYVelocity(heroVelocity.Y += 0.15f * i);

            }
            #region Collisions
            if (hero.GetOnPlatform())
            {
                hero.SetJumped(false);
            } 
            if (hero.GetAnimationObject() is HeroRunning && !hero.GetOnPlatform() && hero.GetPosition().Y + hero.GetAnimationObject().GetTextureHeight() < Globals.floorYPosition)
            {
                hero.SetJumped(true);
            }
            // Wanneer de grond geraakt wordt
            if (hero.GetPosition().Y + hero.GetAnimationObject().GetTextureHeight() >= Globals.floorYPosition)
                hero.SetJumped(false);


            #endregion
            if (hero.HasJumped() == false)
            {
                if(hero.GetAnimationObject() is not HeroIdle && hero.GetAnimationObject() is not HeroRunning)
                {
                    HeroAnimationHandler.SetIdle();
                }
                hero.SetYVelocity(heroVelocity.Y = 0f);
            }
        }
        private void Running(Hero hero)
        {
            if (hero.GetAnimationObject() is not HeroRunning && hero.GetAnimationObject() is not HeroJumping)
            {
                HeroAnimationHandler.SetRunning();
            }
        }
    }
}
