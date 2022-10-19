using Forest_of_wrath.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Forest_of_wrath.Classes.Hero
{
    internal class Hero : IGameObject
    {

        Texture2D _heroTexture;
        Animation _animation;
        private int _heightOffset;
        private int _frameWidth;
        private Vector2 _position;
        private Vector2 _snelheid;


        public Hero(ContentManager content)
        {
            _heroTexture = content.Load<Texture2D>("Hero/idle");
            _frameWidth = 150;
            _heightOffset = 400;
            _animation = new Animation();
            _animation.AddFrame(new AnimationFrame(new Rectangle(0,0,_frameWidth,_heroTexture.Height)));
            _animation.AddFrame(new AnimationFrame(new Rectangle(_frameWidth, 0, _frameWidth, _heroTexture.Height)));
            _animation.AddFrame(new AnimationFrame(new Rectangle(_frameWidth * 2,0, _frameWidth, _heroTexture.Height)));
            _animation.AddFrame(new AnimationFrame(new Rectangle(_frameWidth * 3,0, _frameWidth, _heroTexture.Height)));
            _position = new Vector2(0,_heightOffset);
            _snelheid = new Vector2(1, 0);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_heroTexture, _position, _animation._currentFrame._sourceRectangle, Color.White);
            Move();
        }
        public void Update(GameTime gameTime)
        {
            _animation.Update(gameTime);
        }
        private void Move()
        {
            _position += _snelheid;
            if (_position.X > GraphicsDeviceManager.DefaultBackBufferWidth || _position.X < 0)
            {
                _snelheid *= -1;
            } 
        }


    }
}
