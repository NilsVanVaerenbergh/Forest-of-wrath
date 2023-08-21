using Forest_of_wrath.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_of_wrath.UI.AddOn
{
    internal class Statistics : IGameObject
    {

        private Text heroHealth;
        private SpriteFont font;

        public Statistics() {

            font = Globals.contentManager.Load<SpriteFont>("Font/title_12");
            heroHealth = new Text($"Health: {Globals.hero.GetHealth().ToString()}", new Vector2(50,50), font, Color.Gold);
        
        }
        public void Update(GameTime gameTime)
        {
            heroHealth.updateString($"Health: {Globals.hero.GetHealth().ToString()}");
        }
        public void Draw()
        {
            heroHealth.Draw();
        }
    }
}
