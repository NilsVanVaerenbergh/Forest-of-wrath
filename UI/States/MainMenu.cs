using Forest_of_wrath.Entities;
using Forest_of_wrath.Interfaces;
using Forest_of_wrath.UI.AddOn;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_of_wrath.UI.States
{
    internal class MainMenu : IUIStateObject
    {
        private Text startText;
        private SpriteFont font;
        private Blink blink;
        private WelcomeTitle title;
        public MainMenu() 
        {
            font = Globals.contentManager.Load<SpriteFont>("Font/title_12");
            startText = new Text("Press spacebar to start", new Vector2((Globals.graphicsDeviceManager.GraphicsDevice.Viewport.Width - 8) / 2, 400f), font, Color.White, true);
            blink = new Blink(startText);
            title = new WelcomeTitle();
            Globals.hero.ResetPosition();
        }
        public void Draw()
        {
            title.Draw();
            startText.Draw();
            Globals.hero.GetHitbox().Draw(Globals.hero.GetPosition());
        }
        public void Update(GameTime gameTime)
        {
            title.Update(gameTime);
            blink.Update();
        }
    }
}
