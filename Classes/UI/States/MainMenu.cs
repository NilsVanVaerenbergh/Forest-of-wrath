using Forest_of_wrath.Classes.Animations;
using Forest_of_wrath.Classes.Handlers;
using Forest_of_wrath.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_of_wrath.Classes.UI.States
{
    internal class MainMenu : IUiStateObject
    {
        private SpriteFont[] font = new SpriteFont[2];
        private Text title1;
        private Text title2;
        private Text start;

        private UIHandler instance;

        private BlinkText blink;

        private Vector2 titlePos;

        public MainMenu(ContentManager content, UIHandler instance)
        {
            font[0] = content.Load<SpriteFont>("Font/title_12");
            font[1] = content.Load<SpriteFont>("Font/title_48");
            titlePos = new Vector2((928 - 8) / 2, 200f);
            start = new Text("Press to start", new Vector2(titlePos.X, 400f), font[0], Color.White, true);
            title1 = new Text("Forest of", titlePos, font[1], Color.Goldenrod, true);
            title2 = new Text("Wrath", new Vector2(titlePos.X, titlePos.Y + 50f), font[1], Color.Goldenrod, true);
            blink = new BlinkText(start);
            this.instance = instance;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            title1.Draw(spriteBatch);
            title2.Draw(spriteBatch);
            start.Draw(spriteBatch);
        }
        public void Update(GameTime gameTime)
        {
            blink.Update();

            if(Keyboard.GetState().GetPressedKeyCount() > 0)
            {
                instance.setState(UiState.PLAYING);
            }

        }
    }
}
