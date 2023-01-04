using Forest_of_wrath.Classes.Collision;
using Forest_of_wrath.Classes.Enemies;
using Forest_of_wrath.Classes.Enemies.ToothWalker;
using Forest_of_wrath.Classes.Handlers;
using Forest_of_wrath.Classes.Hero;
using Forest_of_wrath.Classes.Hero.States;
using Forest_of_wrath.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Forest_of_wrath.Classes.UI.States
{
    internal class Playing : IUiStateObject
    {
        ContentManager content;
        UIHandler instance;
        KeyHandler controls;
        HeroClass hero;
        List<IEnemyObject> enemyList = new List<IEnemyObject>();
        Text HealthText;
        Text CurrentLevelText;
        public Playing(ContentManager content, UIHandler instance, GraphicsDeviceManager graphicsDevice)
        {
            this.content = content;
            this.instance = instance;
            hero = new HeroClass(content, graphicsDevice, instance);
            controls = new KeyHandler(hero);
            SpriteFont font = content.Load<SpriteFont>("Font/title_12");
            HealthText = new Text($"Health: {hero.Health}", new Vector2(20f, graphicsDevice.GraphicsDevice.Viewport.Height - 50f), font, Color.Gold, false);
            CurrentLevelText = new Text($"Level: 1", new Vector2(20f, graphicsDevice.GraphicsDevice.Viewport.Height - 50f + 12f), font, Color.Gold, false);
            enemyList.Add(new ToothWalker(content, graphicsDevice, hero, -840, 1.1f));
            enemyList.Add(new ToothWalker(content, graphicsDevice, hero, 80, 0.8f));
            enemyList.Add(new ToothWalker(content, graphicsDevice, hero, 866, 1f));
            enemyList.Add(new ToothWalker(content, graphicsDevice, hero, -80, 0.9f));

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            HealthText.updateString($"Health: {hero.Health.ToString("n0")}");
            HealthText.Draw(spriteBatch);
            CurrentLevelText.Draw(spriteBatch);
            hero.Draw(spriteBatch);
            enemyList.ForEach(toothWalker =>
            {
                toothWalker.Draw(spriteBatch);
            });
        }

        public void Update(GameTime gameTime)
        {
            controls.Handle();
            hero.Update(gameTime);
            enemyList.ForEach(toothWalker =>
            {
                toothWalker.Update(gameTime, hero._state.bodyHitBox.HitBoxPosition);
            });
        }
    }
}
