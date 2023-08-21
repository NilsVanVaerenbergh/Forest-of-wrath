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
    internal class Fountain : Platform, IPlatformObject
    {
        Hitbox hitbox;
        Vector2 position;
        public Fountain(Texture2D texture, Rectangle rect, Vector2 position) : base(texture, rect)
        {
            this.position = position;
            this.position.X = position.X + 15;
            hitbox = new Hitbox();
            hitbox.Load(70, 10, this.position, Color.Blue);
        }
        public void Draw()
        {
            base.Draw();
            hitbox.Draw(this.position);
        }
        public Rectangle GetRectangle()
        {
            return hitbox.GetRectangle();
        }

        public void SetActive(bool active)
        {
            base.setActive(active);
        }

        public bool GetActive() { return base.isActive(); }

    }
}
