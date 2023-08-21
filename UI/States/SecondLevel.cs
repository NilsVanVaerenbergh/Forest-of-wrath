using Forest_of_wrath.Entities;
using Forest_of_wrath.Entities.Platforms;
using Forest_of_wrath.Interfaces;
using Forest_of_wrath.UI.AddOn;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_of_wrath.UI.States
{
    internal class SecondLevel : ILevelState
    {
        private Portal portal;
        private SpriteFont font;
        private Text level;
        public SecondLevel()
        {
            portal = new Portal();
            font = Globals.contentManager.Load<SpriteFont>("Font/title_24");
            level = new Text("Level 2", new Vector2((Globals.graphicsDeviceManager.GraphicsDevice.Viewport.Width - 8) / 2, 100f), font, Color.Gold, true);
            Globals.hero.ResetPosition();
            Globals.platforms.Clear();
            Globals.enemies.Clear();
            Texture2D texture = Globals.contentManager.Load<Texture2D>("Entities/Platforms/floating");
            Globals.platforms.Add(new Table(texture, new Rectangle(150, Globals.floorYPosition - texture.Height - 80, 127, 48), new Vector2(150, Globals.floorYPosition - texture.Height - 70)));
            Globals.platforms.Add(new Table(texture, new Rectangle(550, Globals.floorYPosition - texture.Height - 80, 127, 48), new Vector2(550, Globals.floorYPosition - texture.Height - 70)));
        }
        public void Draw()
        {
            Globals.platforms.ForEach(platform => { platform.Draw(); });
            portal.Draw();
            Globals.hero.Draw();
            level.Draw();
        }

        public Portal GetPortal()
        {
            return portal;
        }

        public void Update(GameTime gameTime)
        {
            Globals.hero.Update(gameTime);
            portal.Update(gameTime);
        }

    }
}
