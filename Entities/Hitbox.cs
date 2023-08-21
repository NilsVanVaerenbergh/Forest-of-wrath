using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_of_wrath.Entities
{
    internal class Hitbox
    {
        Rectangle rect;
        Texture2D pixelTexture;
        Color color = Color.Aquamarine;
        public Hitbox()
        {
            pixelTexture = new Texture2D(Globals.graphicsDeviceManager.GraphicsDevice, 1, 1);
            pixelTexture.SetData(new Color[] { Color.White });
        }
        public void Load(int width, int height, Vector2 position, Color color)
        {
            this.color = color;
            rect = new Rectangle((int)position.X, (int)position.Y, width, height);
        }
        public void Draw(Vector2 position)
        {
            rect.X = (int)position.X;
            rect.Y = (int)position.Y;

            if (Globals.debug)
            {
                Globals.spriteBatch.Draw(pixelTexture, rect, color * 0.3f);
            }
            else
            {
                Globals.spriteBatch.Draw(pixelTexture, rect, color * 0.0f);
            }
        }
        public Rectangle GetRectangle() { return rect; }
    }
}
