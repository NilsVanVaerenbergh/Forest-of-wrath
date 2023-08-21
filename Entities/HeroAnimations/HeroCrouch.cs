using Forest_of_wrath.Handlers;
using Forest_of_wrath.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Forest_of_wrath.Entities.HeroAnimations
{
    internal class HeroCrouch : IAnimationObject
    {
        private Animation animation;
        private Texture2D texture;
        public HeroCrouch()
        {
            animation = new Animation(4);
            texture = Globals.contentManager.Load<Texture2D>("Hero/Crouch");
            int frameWidth = texture.Width / 4;
            animation.AddFrame(new AnimationFrame(new Rectangle(0, 0, frameWidth, texture.Height)));
            animation.AddFrame(new AnimationFrame(new Rectangle(frameWidth, 0, frameWidth, texture.Height)));
            animation.AddFrame(new AnimationFrame(new Rectangle(frameWidth * 2, 0, frameWidth, texture.Height)));
            animation.AddFrame(new AnimationFrame(new Rectangle(frameWidth * 3, 0, frameWidth, texture.Height)));
        }
        public void Draw(Vector2 position, SpriteEffects rotation)
        {
            Globals.spriteBatch.Draw(texture, position, animation.getCurrentFrame().sourceRectangle, Color.White, 0f, Vector2.Zero, Vector2.One, rotation, 0f);
        }
        public int GetTextureHeight()
        {
            return texture.Height;
        }
        public void Update(GameTime gameTime)
        {
            animation.Update(gameTime);
        }
        public Animation GetAnimation()
        {
            return animation;
        }
    }
}
