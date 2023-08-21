using Forest_of_wrath.Entities;
using Forest_of_wrath.Entities.Enemies;
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

namespace Forest_of_wrath.UI.States.Levels
{
    internal class SecondLevel : ILevelState
    {
        private Portal portal;
        private SpriteFont font;
        private Text level;
        private Tree tree;
        private Trap trap;
        public SecondLevel()
        {

            portal = new Portal();
            font = Globals.contentManager.Load<SpriteFont>("Font/title_24");
            level = new Text("Level 2", new Vector2((Globals.graphicsDeviceManager.GraphicsDevice.Viewport.Width - 8) / 2, 100f), font, Color.Gold, true);
            tree = new Tree();
            trap = new Trap();
            Init();        
        }
        public void Draw()
        {
            Globals.platforms.ForEach(platform => { platform.Draw(); });
            portal.Draw();
            Globals.hero.Draw();
            level.Draw();
            trap.Draw();
            tree.Draw();
            Globals.enemies.ForEach(enemy => { enemy.Draw(); });
        }
        public void Update(GameTime gameTime)
        {
            Globals.enemies.ForEach(enemy => { enemy.Update(gameTime); });
            Globals.hero.Update(gameTime);
            portal.Update(gameTime);
            tree.Update(gameTime);
            trap.Update(gameTime);
        }
        public Portal GetPortal() { return portal; }
        private void Init()
        {
            Globals.hero.ResetPosition();
            Globals.platforms.Clear();
            Globals.enemies.Clear();
            Texture2D texture = Globals.contentManager.Load<Texture2D>("Entities/Platforms/floating");
            Globals.platforms.Add(new Table(texture, new Rectangle(150, Globals.floorYPosition - texture.Height - 20, 127, 48), new Vector2(150, Globals.floorYPosition - texture.Height - 10)));
            Globals.platforms.Add(new Table(texture, new Rectangle(550, Globals.floorYPosition - texture.Height - 20, 127, 48), new Vector2(550, Globals.floorYPosition - texture.Height - 10)));
            Globals.enemies.Add(new Bat(1, new Vector2(Globals.randomValue.RandomXPos(), 50)));
            Globals.enemies.Add(new Bat(1, new Vector2(Globals.randomValue.RandomXPos(), 300)));
            Globals.enemies.Add(new Mushroom(1, new Vector2(Globals.randomValue.RandomXPos(), Globals.floorYPosition - 103)));
            Globals.enemies.Add(new Mushroom(1, new Vector2(Globals.randomValue.RandomXPos(), Globals.floorYPosition - 103)));
            Globals.enemies.Add(new Mushroom(1, new Vector2(Globals.randomValue.RandomXPos(), Globals.floorYPosition - 103)));
            Globals.enemies.Add(new Mushroom(1, new Vector2(Globals.randomValue.RandomXPos(), Globals.floorYPosition - 103)));
            Globals.enemies.Add(new Goblin(1, new Vector2(Globals.randomValue.RandomXPos(), Globals.floorYPosition - 103)));
            Globals.enemies.Add(new Goblin(1, new Vector2(Globals.randomValue.RandomXPos(), Globals.floorYPosition - 103)));
        }

    }
}
