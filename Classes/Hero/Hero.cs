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
        IDLE
    }
    internal class Hero : IGameObject,ICharacterObject
    {
        IStateObject _state;
        private int _heightOffset;
        private Vector2 _position;
        private Vector2 _snelheid;
        ContentManager _content;
        private SpriteEffects _flip;
        public Hero(ContentManager content)
        {
            _heightOffset = 377;
            _position = new Vector2(0,_heightOffset);
            _snelheid = new Vector2(1, 0);
            _content = content;
            _state = new Idle(_content);
            _flip = SpriteEffects.None;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            _state.Draw(spriteBatch, _position, _flip);
        }
        public void Update(GameTime gameTime)
        {
            _state.Update(gameTime);
        }
        public void Move()
        {
            if(_state is not Running)
            {
                setState(CharacterState.RUNNING);
            }
            _position += _snelheid;
            if (_position.X > GraphicsDeviceManager.DefaultBackBufferWidth || _position.X < 0)
            {
                _snelheid *= -1;
            }
        }
        public void setSpeed(int x, int y)
        {
            _snelheid = new Vector2(x, y);
        }

        public void setState(CharacterState state)
        {
            if (state == CharacterState.RUNNING) _state = new Running(_content);
            if (state == CharacterState.IDLE) _state = new Idle(_content);
        }

        public void setFlip(SpriteEffects effect)
        {
            _flip = effect;
        }
    }

}