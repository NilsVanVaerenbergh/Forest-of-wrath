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
using System.Diagnostics;
using Forest_of_wrath.Classes.Handlers;

namespace Forest_of_wrath.Classes.Enemies.ToothWalker
{
    internal class ToothWalker : Enemy,IEnemyObject
    {
        private IStateObject _state;
        private int _heightOffset;
        public Vector2 _position { get; set; }
        ContentManager _content;
        GraphicsDeviceManager graphicsDeviceManager;
        private SpriteEffects _flip;
        HeroClass _heroInstance;
        private float _randomVelocity;
        public float _multiplier { get; set; }
        private Text healthText;
        public float baseHealth { get; set; }
        public ToothWalker(ContentManager content, GraphicsDeviceManager graphicsDevice, HeroClass heroInstance, float randomXPos, float randomVelocity) : base(50)
        {
            _heightOffset = 400;
            _position = new Vector2(randomXPos, _heightOffset);
            _content = content;
            _state = new Idle(_content, this,graphicsDevice);
            graphicsDeviceManager = graphicsDevice;
            _flip = SpriteEffects.None;
            baseHealth = 14f;
            Health = 14f * _multiplier;
            _heroInstance = heroInstance;
            _randomVelocity = randomVelocity;

            SpriteFont font = content.Load<SpriteFont>("Font/title_12");
            healthText = new Text($"{Health}", new Vector2(_position.X + 65f, _position.Y + 45f), font, Color.Red * 0.5f);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            healthText.updateString(Health < 0f ? "0" : $"{Health}");
            healthText.Draw(spriteBatch);
            _state.Draw(spriteBatch, _position, _flip);
        }
        public void Update(GameTime gameTime, Vector2 heroPos, float multiplier)
        {
            _multiplier = multiplier;
            healthText.updatePos(new Vector2(_position.X + 65f, _position.Y + 45f));
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
            if(Health <= 0f && _state is not Death)
            {
                setState(Character.CharacterState.DEATH);
            }

            if (_state is Running)
            {
                Running runningState = (Running)_state;
                runningState.SetHeroPosition(heroPos);
                _state = runningState;
            }
            if (_state is TakeHit)
            {
                TakeHit takeHitState = (TakeHit)_state;
                takeHitState.SetHeroPosition(heroPos);
                _state = takeHitState;
            }
            if (_state is Attack)
            {
                Attack AttackingState = (Attack)_state;
                AttackingState.SetHeroPosition(heroPos);
                AttackingState.DealDamage(_heroInstance, _multiplier);
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
            if (state == Character.CharacterState.DEATH) _state = new Death(_content, graphicsDeviceManager);
            if (state == Character.CharacterState.TAKEHIT) _state = new TakeHit(_content, this, graphicsDeviceManager);
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

        public void setHealth(float newHealth)
        {
            Health = newHealth;
        }
        public float getHealth()
        {
            return Health;
        }
    }
}

