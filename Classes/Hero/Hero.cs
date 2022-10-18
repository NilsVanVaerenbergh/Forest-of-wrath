using Forest_of_wrath.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_of_wrath.Classes.Hero
{
    internal class Hero : IGameObject
    {

        Texture2D _heroTexture;
        Vector2 _scale = new Vector2(1f,1f);
        Vector2 _origin = new Vector2(0, 0);

        private int offsetXFrame = 0;
        private int frameWidth = 150;
        private Rectangle frame;

        public Hero(ContentManager content)
        {
            _heroTexture = content.Load<Texture2D>("Hero/idle");
            frame = new Rectangle(offsetXFrame, 0, frameWidth, _heroTexture.Height);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_heroTexture, new Vector2(0,0),frame,Color.White,0,_origin,_scale,SpriteEffects.None,0);
        }
        public void Update()
        {
            offsetXFrame += frameWidth;

            if (offsetXFrame > _heroTexture.Width)
            {
                offsetXFrame = 0;
            }
            frame.X = offsetXFrame;
        }
    }
}
