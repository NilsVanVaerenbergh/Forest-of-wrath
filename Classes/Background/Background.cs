using Forest_of_wrath.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Forest_of_wrath.Classes.Background
{
    internal class Background: IGameObject
    {
        List<Layer> textures = new List<Layer>();
        public Background(ContentManager content)
        {
            string[] filesList = Directory.GetFiles("./Content/Background");
            foreach (string file in filesList)
            {
                string path = Path.GetFileNameWithoutExtension(file);
                Layer layer = new Layer(path, 0, content);
                textures.Add(layer);
            }
        }
        public void Update()
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
