using Forest_of_wrath.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Forest_of_wrath.Classes.Handlers
{
    internal class Text
    {
        private string str;
        private SpriteFont font;
        private Vector2 pos;
        private Color color;
        public Text(string text, Vector2 pos, SpriteFont font, Color color)
        {
            str = text;
            this.font = font;
            this.pos = pos;
            this.color = color;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, str, pos, color, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        }
        public void updatePos(Vector2 pos)
        {
            this.pos = pos;
        }
        public void updateString(string str)
        {
            this.str = str;
        }
    }
}
