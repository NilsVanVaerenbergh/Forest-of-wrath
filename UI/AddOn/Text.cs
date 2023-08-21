using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_of_wrath.UI.AddOn
{
    internal class Text
    {
        private string str;
        private SpriteFont font;
        private Vector2 pos;
        private Color color;
        private Vector2 origin;
        private float opacity { get; set; }
        public Text(string text, Vector2 pos, SpriteFont font, Color color, bool centerOrigin = false)
        {
            str = text;
            this.font = font;
            this.pos = pos;
            this.color = color;
            opacity = 1f;
            if (centerOrigin)
                origin = font.MeasureString(str) / 2;

        }
        public void Draw(float scale = 1f)
        {
            Globals.spriteBatch.DrawString(font, str, pos, color * opacity, 0f, origin, scale, SpriteEffects.None, 0f);
        }
        public void updatePos(Vector2 pos)
        {
            this.pos = pos;
        }
        public void updateString(string str)
        {
            this.str = str;
        }
        public string getString()
        {
            return str;
        }
        public void setOpacity(float opacity)
        {
            this.opacity = opacity;
        }
    }
}
