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
    internal class ToothWalker : Enemy,IEnemyObject
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
        private Text healthText;
        public float baseHealth { get; set; }
        public ToothWalker(ContentManager content, GraphicsDeviceManager graphicsDevice, HeroClass heroInstance, float randomXPos, float randomVelocity) : base(50)
        {
            _heightOffset = 400;
            _position = new Vector2(randomXPos, _heightOffset);
            _content = content;
            graphicsDeviceManager = graphicsDevice;
            _state = new EnemyIdle(_content, graphicsDeviceManager, this, "Enemies/ToothWalker/Idle", 4, new int[2] { 13, 45 }, new float[2] { 70f, 45 });
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
            Debug.WriteLine(_position.ToString());
            _state.Draw(spriteBatch, _position, _flip);
        }
        public void Update(GameTime gameTime, Vector2 heroPos, float multiplier)
        {
            _multiplier = multiplier;
            healthText.updatePos(new Vector2(_position.X + 65f, _position.Y + 45f));
            if(Health <= 0f && _state is not EnemyDeath)
            {
                setState(Character.CharacterState.DEATH);
            }
            if (_state is EnemyAttack)
            {
                EnemyAttack AttackingState = (EnemyAttack)_state;
                AttackingState.DealDamage(_heroInstance, _multiplier);
                _state = AttackingState;
            } 
            _state.setHeroPosition(heroPos);
            _state.Update(gameTime);
           
        }
        public Vector2 getPosition()
        {
            return _position;
        }

        override public void setState(Character.CharacterState state)
        {
            if (state == Character.CharacterState.RUNNING) _state = new EnemyRunning(_content, graphicsDeviceManager, this, _position ,"Enemies/ToothWalker/Run", 8, new int[2] { 13, 45 }, new float[2] { 70f, 45 }, _randomVelocity);
            if (state == Character.CharacterState.IDLE) _state = new EnemyIdle(_content, graphicsDeviceManager, this, "Enemies/ToothWalker/Idle", 4, new int[2] { 13, 45 }, new float[2] { 70f, 45 });
            if (state == Character.CharacterState.ATTACK) _state = new EnemyAttack(_content, graphicsDeviceManager, this, "Enemies/ToothWalker/Attack", 8, new int[2] { 13, 45 }, new float[2] { 70f, 45 });
            if (state == Character.CharacterState.DEATH) _state = new EnemyDeath(_content, graphicsDeviceManager, "Enemies/ToothWalker/Death", 4);
            if (state == Character.CharacterState.TAKEHIT) _state = new EnemyTakeHit(_content, graphicsDeviceManager, this, "Enemies/ToothWalker/Take Hit", 4, new int[2] { 13, 45 }, new float[2] { 70f, 45 });
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

