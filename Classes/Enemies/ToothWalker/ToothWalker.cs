using Forest_of_wrath.Classes.Animations;
using Forest_of_wrath.Interfaces;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forest_of_wrath.Classes.Enemies.ToothWalker.States;

namespace Forest_of_wrath.Classes.Enemies.ToothWalker
{
    internal class ToothWalker : Enemy,IEnemyObject
    {
        private IStateObject _state;
        private int _heightOffset;
        public Vector2 _position;
        ContentManager _content;
        GraphicsDeviceManager graphicsDeviceManager;
        private SpriteEffects _flip;
        public int baseVelocity { get; set; }
        public ToothWalker(ContentManager content, GraphicsDeviceManager graphicsDevice) : base(50)
        {
            _heightOffset = 400;
            _position = new Vector2(0, _heightOffset);
            _content = content;
            _state = new Running(_content, this,graphicsDevice);
            graphicsDeviceManager = graphicsDevice;
            _flip = SpriteEffects.None;
            Health = 14;
            baseVelocity = 1;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            _state.Draw(spriteBatch, _position, _flip);
        }
        public void Update(GameTime gameTime, Vector2 heroPos)
        {
            if(DateTime.Now == base.creationTime.AddSeconds(10)) 
            {
                setState(Character.CharacterState.RUNNING);
            }
            if(_state is Running)
            {
                Running runningState = (Running)_state;
                runningState.SetHeroPosition(heroPos);
                _state = runningState;
            }
            _state.Update(gameTime);
        }
        public void Move()
        {
            if (_state is not Running)
            {
                setState(Character.CharacterState.RUNNING);
            }
        }
        public Vector2 getPosition()
        {
            return _position;
        }

        override public void setState(Character.CharacterState state)
        {
            if (state == Character.CharacterState.RUNNING) _state = new Running(_content, this, graphicsDeviceManager);
            if (state == Character.CharacterState.IDLE) _state = new Idle(_content, graphicsDeviceManager);
            if (state == Character.CharacterState.DEATH) _state = new Death(_content);
        }
        public IStateObject getState()
        {
            return _state;
        }
        override public void setFlip(SpriteEffects effect)
        {
            _flip = effect;
        }
        public void setPosition(Vector2 position)
        {
            _position = position;
        }
    }
}

