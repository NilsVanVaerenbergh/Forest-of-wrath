using Forest_of_wrath.Classes.Animations;
using Forest_of_wrath.Classes.Hero.States;
using Forest_of_wrath.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Forest_of_wrath.Classes.Hero
{
    internal class HeroClass : IGameObject,ICharacterObject
    {
        private IStateObject _state;
        private int _heightOffset;
        public Vector2 _position;
        ContentManager _content;
        private SpriteEffects _flip;
        public int baseVelocity { get; set; }
        public int Health { get; set; }

        public HeroClass(ContentManager content)
        {
            _heightOffset = 377;
            _position = new Vector2(0,_heightOffset);
            _content = content;
            _state = new Death(_content);
            _flip = SpriteEffects.None;
            Health = 100;
            baseVelocity = 2;
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
            if(_state is not Running && _state is not Jumping)
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
        public Vector2 getPosition()
        {
            return _position;
        }
        public void setState(Character.CharacterState state)
        {
            if (state == Character.CharacterState.RUNNING) _state = new Running(_content, this);
            if (state == Character.CharacterState.IDLE) _state = new Idle(_content);
            if (state == Character.CharacterState.DEATH) _state = new Death(_content);
            if (state == Character.CharacterState.JUMP) _state = new Jumping(_content, this);
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