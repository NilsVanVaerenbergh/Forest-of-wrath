using Forest_of_wrath.Classes.Hero;
using Forest_of_wrath.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forest_of_wrath.Classes.Hero.States;

namespace Forest_of_wrath.Classes.Handlers
{
    internal class KeyHandler : IHandler
    {
        private KeyboardState oldState;
        HeroClass _hero;
        private int speed = 2;
        public KeyHandler(HeroClass hero)
        {
            _hero = hero;
        }

        public void Handle()
        {
            KeyboardState newState = Keyboard.GetState();
            if(_hero.getState() is not Jumping)
            {
                if (newState.IsKeyUp(Keys.Up) && newState.IsKeyDown(Keys.Left) && !oldState.IsKeyDown(Keys.Left) || newState.IsKeyDown(Keys.Right) && !oldState.IsKeyDown(Keys.Right))
                {
                    if (Keyboard.GetState().IsKeyDown(Keys.Left))
                    {
                        _hero.setFlip(SpriteEffects.FlipHorizontally);
                        _hero.Move(speed * -1, 0);
                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.Right))
                    {
                        _hero.setFlip(SpriteEffects.None);
                        _hero.Move(speed * 1, 0);
                    }
                }
                else if (newState.IsKeyUp(Keys.Up) && newState.IsKeyDown(Keys.Left) && oldState.IsKeyDown(Keys.Left) || newState.IsKeyDown(Keys.Right) && oldState.IsKeyDown(Keys.Right))
                {
                    if (Keyboard.GetState().IsKeyDown(Keys.Left))
                    {
                        _hero.setFlip(SpriteEffects.FlipHorizontally);
                        _hero.Move(speed * -1, 0);
                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.Right))
                    {
                        _hero.setFlip(SpriteEffects.None);
                        _hero.Move(speed * 1, 0);
                    }
                }
                else if (newState.IsKeyUp(Keys.Up) && !newState.IsKeyDown(Keys.Left) && oldState.IsKeyDown(Keys.Left) || !newState.IsKeyDown(Keys.Right) && oldState.IsKeyDown(Keys.Right))
                {
                    _hero.setState(CharacterState.IDLE);
                }
            }
            if (newState.IsKeyDown(Keys.Up) && !oldState.IsKeyDown(Keys.Up))
            {
                _hero.setFlip(SpriteEffects.None);
                _hero.Jump();
            }
            oldState = newState;
        }
    }
}
