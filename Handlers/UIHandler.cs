using Forest_of_wrath.Interfaces;
using Forest_of_wrath.UI.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_of_wrath.Handlers
{
    internal class UIHandler : IGameObject
    {
        public UIHandler() 
        {
            Globals.uiState = new MainMenu();
            Globals.currentLevel = new FirstLevel();
        }
        public void Draw()
        {
            Globals.uiState.Draw();
        }
        public void Update(GameTime gameTime)
        {
            if (Globals.uiState is MainMenu || Globals.uiState is GameOver)
                if (Keyboard.GetState().IsKeyDown(Keys.Space))
                    Globals.uiState = new Playing();

            if (Globals.hero.GetHealth() <= 0 && Globals.uiState is not GameOver)
                Globals.uiState = new GameOver();

            Globals.uiState.Update(gameTime);
        }
    }
}
