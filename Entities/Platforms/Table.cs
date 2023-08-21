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
    internal class Table: Platform, IPlatformObject
    {
        Hitbox hitbox;
        Vector2 position;
        public Table(Texture2D texture, Rectangle rect, Vector2 position) : base(texture, rect)
        {
            this.position = position;
            this.position.X = position.X;
            hitbox = new Hitbox();
            hitbox.Load(128, 10, this.position, Color.Blue);
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
