using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_of_wrath.UI
{
    internal class Background
    {
        List<Layer> textures;
        public Background()
        {
            textures = new List<Layer>();
            string[] filesList = Directory.GetFiles("./Content/Background");
            foreach (string file in filesList)
            {
                string path = Path.GetFileNameWithoutExtension(file);
                Layer layer = new Layer(path, 0, 0, Globals.contentManager);
                textures.Add(layer);
            }
        }
        public void Draw()
        {
            textures.Sort((x, y) => y.getLayerPos().CompareTo(x.getLayerPos()));
            foreach (Layer texture in textures)
            {
                texture.Draw();
            }
        }
    }
}
