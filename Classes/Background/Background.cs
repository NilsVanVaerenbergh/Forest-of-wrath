using Forest_of_wrath.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;

namespace Forest_of_wrath.Classes.Background
{
    internal class Background: IGameObject
    {
        List<Layer> textures;
        public Background(ContentManager content)
        {
            textures = new List<Layer>();
            string[] filesList = Directory.GetFiles("./Content/Background");
            foreach (string file in filesList)
            {
                string path = Path.GetFileNameWithoutExtension(file);
                Layer layer = new Layer(path,0, 0, content);
                textures.Add(layer);
            }
        }
        public void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            textures.Sort((x, y) => y.getLayerPos().CompareTo(x.getLayerPos()));
            foreach (Layer texture in textures)
            {
                texture.Draw(spriteBatch);
            }
        }
    }
}
