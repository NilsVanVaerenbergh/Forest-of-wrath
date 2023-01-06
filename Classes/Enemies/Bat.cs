using Forest_of_wrath.Classes.Animations;
using Forest_of_wrath.Interfaces;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Forest_of_wrath.Classes.Hero;
using Forest_of_wrath.Classes.Handlers;
using Forest_of_wrath.Classes.Enemies.states;
using System.Diagnostics;

namespace Forest_of_wrath.Classes.Enemies
{
    internal class Bat : Enemy, IEnemyObject
    {
        private IEnemyStateObject _state;
        private int _heightOffset;
        public Vector2 _position { get; set; }
        ContentManager _content;
        GraphicsDeviceManager graphicsDeviceManager;
        private SpriteEffects _flip;
        HeroClass _heroInstance;
        private float _randomVelocity;
        public float _multiplier { get; set; }
        public float baseHealth { get; set; }
        public Bat(ContentManager content, GraphicsDeviceManager graphicsDevice, HeroClass heroInstance, float randomXPos, float randomVelocity) : base(50)
        {
            _heightOffset = 350;
            _position = new Vector2(randomXPos, _heightOffset);
            _content = content;
            graphicsDeviceManager = graphicsDevice;
            _flip = SpriteEffects.None;
            _state = new EnemyIdle(_content, graphicsDeviceManager, this, "Enemies/Bat/Flight", 8, new int[2] { 13, 13 }, new float[2] { 70f, 45 });
            baseHealth = 2f;
            baseDamage = 200f;
            Health = baseHealth * _multiplier;
            _heroInstance = heroInstance;
            _randomVelocity = randomVelocity;
        }
        public void Draw(SpriteBatch spriteBatch)
        { 
            _state.Draw(spriteBatch, _position, _flip);
        }
        public void Update(GameTime gameTime, Vector2 heroPos, float multiplier)
        {
            _multiplier = multiplier;
            if (Health <= 0f && _state is not EnemyDeath)
            {
                setState(Character.CharacterState.DEATH);
            }
            if (_state is EnemyAttack)
            {
                EnemyAttack AttackingState = (EnemyAttack)_state;
                if (_state.bodyHitBox.rect.Intersects(_heroInstance.GetHeroHitbox().rect))
                {
                    AttackingState.DealDamage(_heroInstance, _multiplier);
                }
                _state = AttackingState;
            }
            _state.setHeroPosition(heroPos);
            _state.Update(gameTime);

        }
        override public Vector2 getPosition()
        {
            return _position;
        }

        override public void setState(Character.CharacterState state)
        {
            if (state == Character.CharacterState.RUNNING) _state = new BatRunning(_content, graphicsDeviceManager, this, _heroInstance.GetHeroHitbox(), _position, "Enemies/Bat/Flight", 8, new int[2] { 13, 45 }, new float[2] { 70f, 45 }, _randomVelocity);
            if (state == Character.CharacterState.IDLE) _state = new EnemyIdle(_content, graphicsDeviceManager, this, "Enemies/Bat/Flight", 8, new int[2] { 13, 45 }, new float[2] { 70f, 45 });
            if (state == Character.CharacterState.ATTACK) _state = new BatAttack(_content, graphicsDeviceManager, this, "Enemies/Bat/Attack", "Sound/Enemies/Toothwalker/stab", 8, new int[2] { 13, 45 }, new float[2] { 70f, 45 });
            if (state == Character.CharacterState.DEATH) _state = new BatDeath(_content, graphicsDeviceManager,this ,"Enemies/Bat/Death", 4);
            if (state == Character.CharacterState.TAKEHIT) _state = new EnemyTakeHit(_content, graphicsDeviceManager, this, "Enemies/Bat/Take Hit", 4, new int[2] { 13, 45 }, new float[2] { 70f, 45 });
        }
        override public IEnemyStateObject getState()
        {
            return _state;
        }
        override public void setFlip(SpriteEffects effect)
        {
            _flip = effect;
        }
        override public void setPosition(Vector2 position)
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