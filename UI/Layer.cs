﻿using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace Forest_of_wrath.UI
{
    internal class Layer
    {
        private int _moveVector;
        private string _fileName;
        Vector2 _position;
        Texture2D _texture;
        public Layer(string fileName, int posX, int moveVector, ContentManager content)
        {
            _fileName = fileName;
            _moveVector = moveVector;
            _texture = content.Load<Texture2D>($"Background/{_fileName}");
            int offset = 680 - 793 - 120;
            _position = new Vector2(posX, offset);
        }
        public void Draw()
        {
            Globals.spriteBatch.Draw(_texture, _position, Color.White);
        }
        public void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
        public double getLayerPos()
        {
            return double.Parse(_fileName);
        }
    }
}
