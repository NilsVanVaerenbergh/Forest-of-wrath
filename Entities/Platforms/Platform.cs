using Forest_of_wrath.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_of_wrath.Entities.Platforms
{
    internal class Platform
    {
        private bool active = false;
        Texture2D texture;
        Rectangle rect;
        public Platform(Texture2D texture, Rectangle rect)
        {
            this.texture = texture;
            this.rect = rect;
        }
        public void Draw()
        {
            Globals.spriteBatch.Draw(texture, rect, Color.White);
        }
        public bool isActive() { return active; }
        public void setActive(bool active) { this.active = active;}


    }
}
