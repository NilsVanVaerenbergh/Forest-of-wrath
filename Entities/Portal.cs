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
    internal class Portal : IGameObject
    {
        private Animation animation;
        private Texture2D texture;
        private Hitbox hitbox;
        private Vector2 position;
        public Portal()
        {
            animation = new Animation(8);
            texture = Globals.contentManager.Load<Texture2D>("UI/Portal");
            int frameWidth = texture.Width / 8;
            animation.AddFrame(new AnimationFrame(new Rectangle(0, 0, frameWidth, texture.Height)));
            animation.AddFrame(new AnimationFrame(new Rectangle(frameWidth, 0, frameWidth, texture.Height)));
            animation.AddFrame(new AnimationFrame(new Rectangle(frameWidth * 2, 0, frameWidth, texture.Height)));
            animation.AddFrame(new AnimationFrame(new Rectangle(frameWidth * 3, 0, frameWidth, texture.Height)));
            animation.AddFrame(new AnimationFrame(new Rectangle(frameWidth * 4, 0, frameWidth, texture.Height)));
            animation.AddFrame(new AnimationFrame(new Rectangle(frameWidth * 5, 0, frameWidth, texture.Height)));
            animation.AddFrame(new AnimationFrame(new Rectangle(frameWidth * 6, 0, frameWidth, texture.Height)));
            animation.AddFrame(new AnimationFrame(new Rectangle(frameWidth * 7, 0, frameWidth, texture.Height)));
            position = new Vector2(Globals.graphicsDeviceManager.GraphicsDevice.Viewport.Width - frameWidth - 10, Globals.floorYPosition - texture.Height - 30);
            hitbox = new Hitbox();
            hitbox.Load(22, 65, new Vector2(position.X + 40, position.Y), Color.Green);

        }
        public void Draw()
        {
            Globals.spriteBatch.Draw(texture, position, animation.getCurrentFrame().sourceRectangle, Color.White, 0f, Vector2.Zero, 1.5f, SpriteEffects.FlipHorizontally, 0f);
            hitbox.Draw(new Vector2(position.X + 40, position.Y));
        }
        public void Update(GameTime gameTime)
        {
            animation.Update(gameTime);
        }

        public Hitbox GetHitbox() { return hitbox; }
    }
}
