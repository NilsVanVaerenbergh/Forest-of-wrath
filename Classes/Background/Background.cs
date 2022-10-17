using Forest_of_wrath.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_of_wrath.Classes.Background
{
    internal class Background: IGameObject
    {
        Texture2D _backgroundTexture_0;
        Texture2D _backgroundTexture_1;
        Texture2D _backgroundTexture_2;
        Texture2D _backgroundTexture_3;
        Texture2D _backgroundTexture_4;
        Texture2D _backgroundTexture_5;
        Texture2D _backgroundTexture_6;
        Texture2D _backgroundTexture_7;
        Texture2D _backgroundTexture_8;
        Texture2D _backgroundTexture_9;
        Texture2D _backgroundTexture_10;
        Texture2D _backgroundTexture_11;

        private int offsetY;

        public Background(ContentManager content)
        {
            _backgroundTexture_0 = content.Load<Texture2D>("Background/layer_0");
            _backgroundTexture_1 = content.Load<Texture2D>("Background/layer_1");
            _backgroundTexture_2 = content.Load<Texture2D>("Background/layer_2");
            _backgroundTexture_3 = content.Load<Texture2D>("Background/layer_3");
            _backgroundTexture_4 = content.Load<Texture2D>("Background/layer_4");
            _backgroundTexture_5 = content.Load<Texture2D>("Background/layer_5");
            _backgroundTexture_6 = content.Load<Texture2D>("Background/layer_6");
            _backgroundTexture_7 = content.Load<Texture2D>("Background/layer_7");
            _backgroundTexture_8 = content.Load<Texture2D>("Background/layer_8");
            _backgroundTexture_9 = content.Load<Texture2D>("Background/layer_9");
            _backgroundTexture_10 = content.Load<Texture2D>("Background/layer_10");
            _backgroundTexture_11 = content.Load<Texture2D>("Background/layer_11");

            offsetY = 680 - 793 - 100;
        }
        public void Update()
        {
            throw new NotImplementedException();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_backgroundTexture_11, new Vector2(0, offsetY), Color.White) ;
            spriteBatch.Draw(_backgroundTexture_10, new Vector2(0,offsetY), Color.White);
            spriteBatch.Draw(_backgroundTexture_9, new Vector2(0,offsetY), Color.White);
            spriteBatch.Draw(_backgroundTexture_8, new Vector2(0,offsetY), Color.White);
            spriteBatch.Draw(_backgroundTexture_7, new Vector2(0,offsetY), Color.White);
            spriteBatch.Draw(_backgroundTexture_6, new Vector2(0,offsetY), Color.White);
            spriteBatch.Draw(_backgroundTexture_5, new Vector2(0,offsetY), Color.White);
            spriteBatch.Draw(_backgroundTexture_4, new Vector2(0,offsetY), Color.White);
            spriteBatch.Draw(_backgroundTexture_3, new Vector2(0,offsetY), Color.White);
            spriteBatch.Draw(_backgroundTexture_2, new Vector2(0,offsetY), Color.White);
            spriteBatch.Draw(_backgroundTexture_1, new Vector2(0,offsetY), Color.White);
            spriteBatch.Draw(_backgroundTexture_0, new Vector2(0,offsetY), Color.White);
        }
    }
}
