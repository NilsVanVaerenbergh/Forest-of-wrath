using Forest_of_wrath.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_of_wrath.Classes.Collision
{
    internal class Hitbox : IHitBoxObject
    {
        public Rectangle rect;
        public Vector2 HitBoxPosition;
        Texture2D pixelTexture;
        public Hitbox(GraphicsDeviceManager graphicsDevice)
        {
            HitBoxPosition = new Vector2(0f,0f);
            pixelTexture = new Texture2D(graphicsDevice.GraphicsDevice, 1, 1);
            pixelTexture.SetData(new Color[] { Color.White });
        }
        public void Load(int width, int height, Vector2 position)
        {
            rect = new Rectangle((int)position.X, (int)position.Y, width, height);
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            rect.X = (int)position.X;
            rect.Y = (int)position.Y;
            spriteBatch.Draw(pixelTexture, rect, Color.Aquamarine * 0.8f);
        }
    }
}
