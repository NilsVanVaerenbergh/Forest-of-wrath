using Forest_of_wrath.Entities;
using Forest_of_wrath.Interfaces;
using Forest_of_wrath.UI.AddOn;
using Forest_of_wrath.UI.States.Levels;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_of_wrath.UI.States
{
    internal class GameOver : IUIStateObject
    {
        private Text startText;
        private SpriteFont font;
        private Blink blink;
        private GameOverTitle title;
        public GameOver() {
            font = Globals.contentManager.Load<SpriteFont>("Font/title_12");
            startText = new Text("Press spacebar to restart", new Vector2((Globals.graphicsDeviceManager.GraphicsDevice.Viewport.Width - 8) / 2, 400f), font, Color.White, true);
            blink = new Blink(startText);
            title = new GameOverTitle();
            Globals.hero.SetHealth(100);
            Globals.currentLevel = new FirstLevel();
        }
        public void Draw()
        {
            title.Draw();
            startText.Draw();
        }
        public void Update(GameTime gameTime)
        {
            title.Update(gameTime);
            blink.Update();
        }
    }
}
