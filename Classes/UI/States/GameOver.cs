using Forest_of_wrath.Classes.Animations;
using Forest_of_wrath.Classes.Handlers;
using Forest_of_wrath.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_of_wrath.Classes.UI.States
{
    internal class GameOver : IUiStateObject
    {
        private Text gameOver;
        private SpriteFont font;
        private BlinkText blink;
        private UIHandler instance;
        public GameOver(ContentManager content, UIHandler instance)
        {
            font = content.Load<SpriteFont>("Font/title_48");
            gameOver = new Text("Game Over", new Vector2((928 - 8) / 2, (680 - 8) / 2), font, Color.Red, true);
            blink = new BlinkText(gameOver);
            this.instance = instance;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            gameOver.Draw(spriteBatch);
        }

        public void Update(GameTime gameTime)
        {
            blink.Update();
            if (Keyboard.GetState().GetPressedKeyCount() > 0)
            {
                instance.setState(UiState.MAIN);
            }
        }
    }
}
