using Forest_of_wrath.Handlers;
using Forest_of_wrath.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_of_wrath.Entities
{
    internal class GameOverTitle : IGameObject
    {
        private Animation animation;
        private Texture2D texture;
        private Vector2 position;
        private int frameWidth = 380;
        public GameOverTitle()
        {
            texture = Globals.contentManager.Load<Texture2D>("UI/game_over");
            animation = new Animation(6);
            position = new Vector2((Globals.graphicsDeviceManager.GraphicsDevice.Viewport.Width - 8) / 2, 200f);
            animation.AddFrame(new AnimationFrame(new Rectangle(0, 0, frameWidth, texture.Height)));
            animation.AddFrame(new AnimationFrame(new Rectangle(frameWidth, 0, frameWidth, texture.Height)));
            animation.AddFrame(new AnimationFrame(new Rectangle(frameWidth * 2, 0, frameWidth, texture.Height)));
            animation.AddFrame(new AnimationFrame(new Rectangle(frameWidth * 3, 0, frameWidth, texture.Height)));
            animation.AddFrame(new AnimationFrame(new Rectangle(frameWidth * 4, 0, frameWidth, texture.Height)));
            animation.AddFrame(new AnimationFrame(new Rectangle(frameWidth * 5, 0, frameWidth, texture.Height)));
            animation.AddFrame(new AnimationFrame(new Rectangle(frameWidth * 6, 0, frameWidth, texture.Height)));
            animation.AddFrame(new AnimationFrame(new Rectangle(frameWidth * 7, 0, frameWidth, texture.Height)));
            animation.AddFrame(new AnimationFrame(new Rectangle(frameWidth * 8, 0, frameWidth, texture.Height)));
            animation.AddFrame(new AnimationFrame(new Rectangle(frameWidth * 9, 0, frameWidth, texture.Height)));
            animation.AddFrame(new AnimationFrame(new Rectangle(frameWidth * 10, 0, frameWidth, texture.Height)));
        }
        public void Draw()
        {
            Globals.spriteBatch.Draw(texture, position, animation.getCurrentFrame().sourceRectangle, Color.White, 0f, new Vector2((frameWidth / 2), (texture.Height / 2)), 1f, SpriteEffects.None, 1f);
        }
        public void Update(GameTime gameTime)
        {
            animation.Update(gameTime);
        }
    }
}
