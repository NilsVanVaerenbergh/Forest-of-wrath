using Forest_of_wrath.Entities.Enemies;
using Forest_of_wrath.Entities.Platforms;
using Forest_of_wrath.Handlers;
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
    internal class Playing : IUIStateObject
    {
        private EnemyMovementHandler enemyMovementHandler;
        private EnemyAttackHandler enemyAttackHandler;
        private Statistics statistics;
        public Playing() {
            enemyMovementHandler = new EnemyMovementHandler();
            enemyAttackHandler = new EnemyAttackHandler();
            statistics = new Statistics();
        }
        public void Draw()
        {
            Globals.currentLevel.Draw();
            statistics.Draw();
        }
        public void Update(GameTime gameTime)
        {
            enemyMovementHandler.Update(gameTime);
            enemyAttackHandler.Update(gameTime);
            if (Globals.currentLevel is FirstLevel && Globals.hero.GetHitbox().GetRectangle().Intersects(Globals.currentLevel.GetPortal().GetHitbox().GetRectangle()))
            {
                Globals.currentLevel = new SecondLevel();
            }
            else if (Globals.currentLevel is SecondLevel && Globals.hero.GetHitbox().GetRectangle().Intersects(Globals.currentLevel.GetPortal().GetHitbox().GetRectangle()))
            {
                Globals.hero.ResetPosition();
                Globals.currentLevel = new FirstLevel();
                Globals.uiState = new MainMenu();
            }
            Globals.currentLevel.Update(gameTime);
            statistics.Update(gameTime);    
        }
    }
}
