using Forest_of_wrath.Classes;
using Forest_of_wrath.Classes.Hero.States;
using Forest_of_wrath.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Forest_of_wrath.Classes.Hero
{
    public enum CharacterState
    {
        RUNNING,
        IDLE,
        ATTACK,
        DEATH,
        JUMP
    }
    public enum CharacterSound
    {
        RUNNING,
        IDLE,
        ATTACK,
        DEATH
    }
    internal class HeroClass : IGameObject,ICharacterObject
    {
        private IStateObject _state;
        private int _heightOffset;
        private Vector2 _position;
        private Vector2 _snelheid;
        ContentManager _content;
        private SpriteEffects _flip;
        private int activeVelocity { get; set; }
        public int Health { get; set; }

        public HeroClass(ContentManager content)
        {
            _heightOffset = 377;
            _position = new Vector2(0,_heightOffset);
            _snelheid = new Vector2(1, 0);
            _content = content;
            _state = new Death(_content);
            _flip = SpriteEffects.None;
            Health = 100;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            _state.Draw(spriteBatch, _position, _flip);
        }
        public void Update(GameTime gameTime)
        {
            _state.Update(gameTime);
        }
        public void Move(int x, int y)
        {
            if(_state is not Running && _state is not Jumping)
            {
                setState(CharacterState.RUNNING);
                activeVelocity = x;
                if (x <= -1 && _position.X <= 0 || x >= 1 && _position.X + _state.frameWidth > GraphicsDeviceManager.DefaultBackBufferWidth)
                {
                    _snelheid = new Vector2(0, y);
                }
                else
                {
                    _snelheid = new Vector2(x, y);
                }
            }
            _position += _snelheid;
        }
        public void Jump()
        {
            if (_state is not Jumping)
            {
                setState(CharacterState.JUMP);
            }
        }
        public int getActiveVelocity()
        {
            return activeVelocity;
        }
        public Vector2 getPosition()
        {
            return _position;
        }
        public void setState(CharacterState state)
        {
            if (state == CharacterState.RUNNING) _state = new Running(_content);
            if (state == CharacterState.IDLE) _state = new Idle(_content);
            if (state == CharacterState.DEATH) _state = new Death(_content);
            if (state == CharacterState.JUMP) _state = new Jumping(_content, this);
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
    }

}