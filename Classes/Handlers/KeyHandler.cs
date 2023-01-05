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
using Forest_of_wrath.Classes.Animations;
using System.Diagnostics;

namespace Forest_of_wrath.Classes.Handlers
{
    internal class KeyHandler : IHandler
    {
        private KeyboardState oldState;
        private HeroClass _hero;
        private MouseState oldMouseState;
        public KeyHandler(HeroClass hero)
        {
            _hero = hero;
        }

        public void Handle()
        {
            KeyboardState newState = Keyboard.GetState();
            MouseState newMouseState;
            newMouseState = Mouse.GetState();
            if(_hero.getState() is Idle)
            {
                if (oldMouseState.LeftButton == ButtonState.Released && newMouseState.LeftButton == ButtonState.Pressed)
                {
                    _hero.invokeAttack();
                }
            }
            if (_hero.getState() is not Jumping && _hero.getState() is not Death)
            {
                if (newState.IsKeyUp(Keys.Up) && newState.IsKeyDown(Keys.Left) && !oldState.IsKeyDown(Keys.Left) || newState.IsKeyDown(Keys.Right) && !oldState.IsKeyDown(Keys.Right))
                {
                    if (Keyboard.GetState().IsKeyDown(Keys.Left))
                    {
                        _hero.setFlip(SpriteEffects.FlipHorizontally);
                        _hero.Move();
                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.Right))
                    {
                        _hero.setFlip(SpriteEffects.None);
                        _hero.Move();
                    }
                }
                else if (newState.IsKeyUp(Keys.Up) && newState.IsKeyDown(Keys.Left) && oldState.IsKeyDown(Keys.Left) || newState.IsKeyDown(Keys.Right) && oldState.IsKeyDown(Keys.Right))
                {
                    if (Keyboard.GetState().IsKeyDown(Keys.Left))
                    {
                        _hero.setFlip(SpriteEffects.FlipHorizontally);
                        _hero.Move();
                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.Right))
                    {
                        _hero.setFlip(SpriteEffects.None);
                        _hero.Move();
                    }
                }
                else if (newState.IsKeyUp(Keys.Up) && !newState.IsKeyDown(Keys.Left) && oldState.IsKeyDown(Keys.Left) || !newState.IsKeyDown(Keys.Right) && oldState.IsKeyDown(Keys.Right))
                {
                    _hero.setState(Character.CharacterState.IDLE);
                }
            }
            if (newState.IsKeyDown(Keys.Up) && !oldState.IsKeyDown(Keys.Up))
            {
                _hero.Jump();
            }
            oldState = newState;
            oldMouseState = newMouseState;
        }
    }
}
