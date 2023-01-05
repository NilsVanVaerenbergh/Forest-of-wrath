using Forest_of_wrath.Classes.Animations;
using Forest_of_wrath.Classes.Enemies;
using Forest_of_wrath.Classes.Enemies.states;
using Forest_of_wrath.Classes.Handlers;
using Forest_of_wrath.Classes.Hero;
using Forest_of_wrath.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SharpDX;
using System;
using System.Collections.Generic;
using Color = Microsoft.Xna.Framework.Color;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace Forest_of_wrath.Classes.UI.States
{
    internal class Playing : IUiStateObject
    {
        KeyHandler controls;
        HeroClass hero;
        List<IEnemyObject> enemyList = new List<IEnemyObject>();
        List<IEnemyObject> killedList = new List<IEnemyObject>();
        Text HealthText;
        Text CurrentLevelText;
        public float CurrentLevel { get; set; }
        private int KilledEnemies;
        private int totalEnemies;
        private bool addedHealth;
        Random rand = new Random();
        public Playing(ContentManager content, UIHandler instance, GraphicsDeviceManager graphicsDevice)
        {
            CurrentLevel = 1f;
            hero = new HeroClass(content, graphicsDevice, instance, enemyList);
            controls = new KeyHandler(hero);
            SpriteFont font = content.Load<SpriteFont>("Font/title_12");
            HealthText = new Text($"Health: {hero.Health}", new Vector2(20f, graphicsDevice.GraphicsDevice.Viewport.Height - 50f), font, Color.Gold, false);
            CurrentLevelText = new Text($"Level: {CurrentLevel.ToString("n0")}", new Vector2(20f, graphicsDevice.GraphicsDevice.Viewport.Height - 50f + 12f), font, Color.Gold, false);
            enemyList.Add(new ToothWalker(content, graphicsDevice, hero, rand.NextFloat(-200f, 1000), rand.NextFloat(0.3f, 1.5f)));
            enemyList.Add(new ToothWalker(content, graphicsDevice, hero, rand.NextFloat(-200f, 1000), rand.NextFloat(0.3f, 1.5f)));
            //enemyList.Add(new ToothWalker(content, graphicsDevice, hero, rand.NextFloat(-200f, 1000), rand.NextFloat(0.3f, 1.5f)));
            //enemyList.Add(new ToothWalker(content, graphicsDevice, hero, rand.NextFloat(-200f, 1000), rand.NextFloat(0.3f, 1.5f)));
            //enemyList.Add(new ToothWalker(content, graphicsDevice, hero, rand.NextFloat(-200f, 1000), rand.NextFloat(0.3f, 1.5f)));
            //enemyList.Add(new ToothWalker(content, graphicsDevice, hero, rand.NextFloat(-200f, 1000), rand.NextFloat(0.3f, 1.5f)));
            enemyList.Add(new Goblin(content, graphicsDevice, hero, rand.NextFloat(-1000f, 1000), rand.NextFloat(1f, 2.5f)));
            enemyList.Add(new Goblin(content, graphicsDevice, hero, rand.NextFloat(-1000f, 1000), rand.NextFloat(1f, 2.5f)));
            enemyList.Add(new Goblin(content, graphicsDevice, hero, rand.NextFloat(-1000f, 1000), rand.NextFloat(1f, 2.5f)));

            KilledEnemies = 0;
            totalEnemies = enemyList.Count;
            addedHealth = false;

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            HealthText.updateString(hero.Health < 0f ? "Health: 0" : $"Health: {hero.Health.ToString("n0")}");
            HealthText.Draw(spriteBatch);
            CurrentLevelText.updateString($"Level: {CurrentLevel.ToString("n0")}");
            CurrentLevelText.Draw(spriteBatch);
            hero.Draw(spriteBatch);
            enemyList.ForEach(enemy =>
            {
                enemy.Draw(spriteBatch);
            });
            killedList.ForEach(enemy =>
            {
                enemy.Draw(spriteBatch);
            });
        }

        public void Update(GameTime gameTime)
        {
            controls.Handle();
            hero.Update(gameTime);
            enemyList.ForEach(enemy => enemy.Update(gameTime, new Vector2(hero._state.bodyHitBox.rect.X, hero._state.bodyHitBox.rect.Y), CurrentLevel));
            killedList.ForEach(enemy => enemy.Update(gameTime, new Vector2(hero._state.bodyHitBox.rect.X, hero._state.bodyHitBox.rect.Y), CurrentLevel));
            if(KilledEnemies >= totalEnemies)
            {
                killedList.ForEach(enemy =>
                {
                    enemy.setHealth(enemy.baseHealth * CurrentLevel);
                    enemy._position = new Vector2(rand.NextFloat(-200f, 1000), enemy._position.Y);
                    enemy.setState(Character.CharacterState.IDLE);
                });
                KilledEnemies = 0;
                enemyList.AddRange(killedList);
                enemyList.ForEach(enemy => enemy.setState(Character.CharacterState.IDLE));
                killedList.Clear();
                if(!addedHealth)
                {
                    hero.HeroDamage *= CurrentLevel;
                    CurrentLevel += 1;
                    hero.Health += 50;
                    addedHealth = true;
                }
            }
            addedHealth= false;
            if(enemyList.Count > 0)
            {
                for (int i = 0; i < enemyList.Count; i++)
                {
                    if (enemyList[i].getState() is EnemyDeath)
                    {
                        KilledEnemies++;
                        killedList.Add(enemyList[i]);
                    }
                }
                enemyList.RemoveAll(enemy => enemy.getState() is EnemyDeath);
            }
        }
    }
}
