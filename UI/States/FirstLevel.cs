using Forest_of_wrath.Entities;
using Forest_of_wrath.Entities.Enemies;
using Forest_of_wrath.Entities.Platforms;
using Forest_of_wrath.Interfaces;
using Forest_of_wrath.UI.AddOn;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_of_wrath.UI.States
{
    internal class FirstLevel : ILevelState
    {
        private Portal portal;
        private SpriteFont font;
        private Text level;
        public FirstLevel() {
            portal = new Portal();
            Globals.hero.ResetPosition();
            Globals.platforms.Clear();
            Globals.enemies.Clear();
            font = Globals.contentManager.Load<SpriteFont>("Font/title_24");
            level = new Text("Level 1", new Vector2((Globals.graphicsDeviceManager.GraphicsDevice.Viewport.Width - 8) / 2, 100f), font, Color.Gold, true);
            Texture2D texture = Globals.contentManager.Load<Texture2D>("Entities/Platforms/fountain");
            Globals.platforms.Add(new Fountain(texture, new Rectangle(50, Globals.floorYPosition - texture.Height, 90, 93), new Vector2(50, Globals.floorYPosition - texture.Height + 5)));
            Globals.platforms.Add(new Fountain(texture, new Rectangle(350, Globals.floorYPosition - texture.Height, 90, 93), new Vector2(350, Globals.floorYPosition - texture.Height + 5)));

            Globals.enemies.Add(new Bat(1, new Vector2(Globals.randomValue.RandomXPos(),50)));
            Globals.enemies.Add(new Bat(1, new Vector2(Globals.randomValue.RandomXPos(), 300)));
            Globals.enemies.Add(new Mushroom(1, new Vector2(Globals.randomValue.RandomXPos(), Globals.floorYPosition - 103)));
            Globals.enemies.Add(new Mushroom(1, new Vector2(Globals.randomValue.RandomXPos(), Globals.floorYPosition - 103)));
            Globals.enemies.Add(new Mushroom(1, new Vector2(Globals.randomValue.RandomXPos(), Globals.floorYPosition - 103)));
            Globals.enemies.Add(new Mushroom(1, new Vector2(Globals.randomValue.RandomXPos(), Globals.floorYPosition - 103)));


        }
        public void Draw()
        {
            Globals.platforms.ForEach(platform => { platform.Draw(); });
            Globals.enemies.ForEach(enemy => { enemy.Draw(); });
            portal.Draw();
            Globals.hero.Draw();
            level.Draw();
        }
        public void Update(GameTime gameTime)
        {
            Globals.enemies.ForEach(enemy => { enemy.Update(gameTime); });
            Globals.hero.Update(gameTime);
            portal.Update(gameTime);
        }
        public Portal GetPortal() { return  portal; }
    }
}
