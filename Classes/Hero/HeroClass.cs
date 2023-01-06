using Forest_of_wrath.Classes.Animations;
using Forest_of_wrath.Classes.Collision;
using Forest_of_wrath.Classes.Hero.States;
using Forest_of_wrath.Classes.UI;
using Forest_of_wrath.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Forest_of_wrath.Classes.Hero
{
    internal class HeroClass : IGameObject,ICharacterObject
    {
        public IStateObject _state;
        private int _heightOffset;
        public Vector2 _position;
        ContentManager _content;
        GraphicsDeviceManager graphicsDeviceManager;
        public SpriteEffects _flip;
        private UIHandler _uiInstance;
        public int baseVelocity { get; set; }
        public float Health { get; set; }
        public float HeroDamage { get; set; }

        private List<IEnemyObject> _enemyList;

        private bool isHiding;

        public HeroClass(ContentManager content, GraphicsDeviceManager graphicsDevice, UIHandler uiInstance, List<IEnemyObject> enemyList)
        {
            _heightOffset = 377;
            _position = new Vector2(0,_heightOffset);
            _content = content;
            _state = new Idle(_content, graphicsDevice, _position);
            graphicsDeviceManager = graphicsDevice;
            _flip = SpriteEffects.None;
            Health = 100;
            HeroDamage = 25f;
            baseVelocity = 2;
            _uiInstance = uiInstance;
            _enemyList = enemyList;
            isHiding = false;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            _state.Draw(spriteBatch, _position, _flip);
        }
        public void Update(GameTime gameTime)
        {
            if(Health <= 0 && _state is not Death)
            {
                setState(Character.CharacterState.DEATH);
                Death deathState = (Death)_state;
                deathState.setUiInstance(_uiInstance);
            }
            _state.Update(gameTime);
        }
        public void Move()
        {
            if(_state is not Running && _state is not Jumping && _state is not Attack)
            {
                setState(Character.CharacterState.RUNNING);
            }
        }
        public void Jump()
        {
            if (_state is not Jumping)
            {
                setState(Character.CharacterState.JUMP);
            }
        }
        public void invokeCrouch()
        {
            if(_state is not Crouch)
            {
                setState(Character.CharacterState.CROUCH);
            }
        }
        public void invokeAttack()
        {
            if (_state is not Attack)
            {
                setState(Character.CharacterState.ATTACK);
            }
        }
        public Vector2 getPosition()
        {
            return _position;
        }
        public void setState(Character.CharacterState state)
        {
            if (state == Character.CharacterState.RUNNING) _state = new Running(_content, this, graphicsDeviceManager, _position);
            if (state == Character.CharacterState.IDLE) _state = new Idle(_content, graphicsDeviceManager, _position);
            if (state == Character.CharacterState.DEATH) _state = new Death(_content, graphicsDeviceManager, _position);
            if (state == Character.CharacterState.CROUCH) _state = new Crouch(_content, this,graphicsDeviceManager, _position);
            if (state == Character.CharacterState.ATTACK) _state = new Attack(_content ,this, graphicsDeviceManager, _enemyList, _position);
            if (state == Character.CharacterState.JUMP) _state = new Jumping(_content, this, graphicsDeviceManager, _position);
        }
        public IStateObject getState()
        {
            return _state;
        }
        public void setFlip(SpriteEffects effect)
        {
            _flip = effect;
        }
        public void setPosition(Vector2 position)
        {
            _position = position;
        }

        public void setHide(bool hidingState)
        {
            isHiding = hidingState;
        }
        public bool getHide()
        {
            return isHiding;
        }
        public Hitbox GetHeroHitbox()
        {
            return _state.bodyHitBox;
        }
    }

}