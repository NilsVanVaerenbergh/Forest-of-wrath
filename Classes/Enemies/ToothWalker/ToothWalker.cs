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
using Forest_of_wrath.Classes.Hero;

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
        HeroClass _heroInstance;
        private float _randomVelocity;
        public ToothWalker(ContentManager content, GraphicsDeviceManager graphicsDevice, HeroClass heroInstance, float randomXPos, float randomVelocity) : base(50)
        {
            _heightOffset = 400;
            _position = new Vector2(randomXPos, _heightOffset);
            _content = content;
            _state = new Idle(_content, this,graphicsDevice);
            graphicsDeviceManager = graphicsDevice;
            _flip = SpriteEffects.None;
            Health = 14;
            _heroInstance = heroInstance;
            _randomVelocity = randomVelocity;
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
            if (_state is Idle)
            {
                Idle idleState = (Idle)_state;
                idleState.SetHeroPosition(heroPos);
                _state = idleState;
            }
            if (_state is Running)
            {
                Running runningState = (Running)_state;
                runningState.SetHeroPosition(heroPos);
                _state = runningState;
            }
            if (_state is Attack)
            {
                Attack AttackingState = (Attack)_state;
                AttackingState.SetHeroPosition(heroPos);
                AttackingState.dealDamage(_heroInstance, 5f, 1f);
                _state = AttackingState;
            }
            _state.Update(gameTime);
        }
        public Vector2 getPosition()
        {
            return _position;
        }

        override public void setState(Character.CharacterState state)
        {
            if (state == Character.CharacterState.RUNNING) _state = new Running(_content, this, graphicsDeviceManager, _randomVelocity);
            if (state == Character.CharacterState.IDLE) _state = new Idle(_content, this,graphicsDeviceManager);
            if (state == Character.CharacterState.ATTACK) _state = new Attack(_content, this, graphicsDeviceManager);
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

