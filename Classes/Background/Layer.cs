using Forest_of_wrath.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.MediaFoundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_of_wrath.Classes.Background
{
    internal class Layer : IGameObject
    {
        private int _offset;
        private int _moveVector;
        private string _fileName;
        Texture2D _texture;
        public Layer(string fileName, int moveVector, ContentManager content)
        {
            _fileName = fileName;
            _moveVector = moveVector;
            _texture = content.Load<Texture2D>($"Background/{_fileName}");
            _offset = 680 - 793 - 120;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, new Vector2(0, _offset), Color.White);
        }
        public void Update()
        {
            throw new NotImplementedException();
        }
        public double getLayerPos()
        {
            return double.Parse(_fileName);
        }
    }
}
