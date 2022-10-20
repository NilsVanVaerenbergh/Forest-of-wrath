﻿using Forest_of_wrath.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Forest_of_wrath.Classes.Hero.States
{
    internal class Jumping : IStateObject
    {
        Texture2D _heroTexture;
        Animation _animation;
        private SoundEffect _sound;
        private HeroClass _heroInstance;
        private Vector2 _position;
        private Vector2 _velocity;
        private Vector2 _currentPosition;
        private bool hasJumped;
        private float _initialHeight;
        private SpriteEffects _spriteEffect;
        public int frameWidth { get; set; }
        public Jumping(ContentManager content, HeroClass heroInstance)
        {
            /*
             *  JUMP STATE Hero/Jump
             *  FRAMES: 4
             */
            _heroInstance = heroInstance;
            _heroTexture = content.Load<Texture2D>("Hero/Jump");
            _sound = content.Load<SoundEffect>("Sound/Hero/jump");
            frameWidth = _heroTexture.Width / 4;
            _animation = new Animation(4);
            _animation.AddFrame(new AnimationFrame(new Rectangle(0, 0, frameWidth, _heroTexture.Height)));
            _animation.AddFrame(new AnimationFrame(new Rectangle(frameWidth, 0, frameWidth, _heroTexture.Height)));
            _animation.AddFrame(new AnimationFrame(new Rectangle(frameWidth * 2, 0, frameWidth, _heroTexture.Height)));
            _animation.AddFrame(new AnimationFrame(new Rectangle(frameWidth * 3, 0, frameWidth, _heroTexture.Height)));
            _sound.Play();
            _initialHeight = heroInstance.getPosition().Y;
            hasJumped = false;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 position, SpriteEffects effect)
        {
            _currentPosition = position + _position;
            spriteBatch.Draw(_heroTexture, position + _position, _animation._currentFrame._sourceRectangle, Color.White, 0f, Vector2.Zero, 1f, _spriteEffect, 0f);
        }

        public void Update(GameTime gameTime)
        {

            _position += _velocity;
            if(Keyboard.GetState().IsKeyDown(Keys.Up) && hasJumped == false)
            {
                _position.Y += -10f;
                _velocity.Y += -3f;

                if (Keyboard.GetState().IsKeyDown(Keys.Left))
                {
                    _spriteEffect = SpriteEffects.FlipHorizontally;
                    _velocity.X -= 3f;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Right))
                {
                    _spriteEffect = SpriteEffects.None;
                    _velocity.X += 3f;
                }

                hasJumped = true;
            }
            if(hasJumped)
            {
                int i = 1;
                _velocity.Y += 0.15f * i;
            }
            if(hasJumped == false)
            {
                _velocity.Y = -0f;
            }
            if(_currentPosition.Y >= _initialHeight)
            {
                hasJumped = false;
                _heroInstance.setState(CharacterState.IDLE);
                _heroInstance.setPosition(new Vector2(_currentPosition.X, _initialHeight));
            }

            _animation.Update(gameTime);
        }
    }
}