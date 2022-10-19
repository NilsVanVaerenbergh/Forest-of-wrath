using Forest_of_wrath.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Forest_of_wrath.Classes.Hero
{
    internal class Hero : IGameObject
    {

        Texture2D _heroTexture;
        int _frameWidth;
        Animation _animation;
        int _heightOffset;

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

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_heroTexture, new Vector2(0,_heightOffset), _animation._currentFrame._sourceRectangle,Color.White);
        }
        public void Update(GameTime gameTime)
        {
            _animation.Update(gameTime);
        }
    }
}
