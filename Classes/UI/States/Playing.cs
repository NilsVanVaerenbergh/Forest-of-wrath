using Forest_of_wrath.Classes.Animations;
using Forest_of_wrath.Classes.Enemies;
using Forest_of_wrath.Classes.Enemies.states;
using Forest_of_wrath.Classes.Handlers;
using Forest_of_wrath.Classes.Hero;
using Forest_of_wrath.Classes.UI.Foreground;
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
        Barrel barrel;
        List<IEnemyObject> enemyList = new List<IEnemyObject>();
        List<IEnemyObject> killedList = new List<IEnemyObject>();
        List<Barrel> barrelList = new List<Barrel>();
        Text HealthText;
        Text CurrentLevelText;
        Text killedEnemiesText;
        public float CurrentLevel { get; set; }
        private int KilledEnemies;
        private int totalEnemies;
        private bool addedHealth;
        Random rand = new Random();
        public Playing(ContentManager content, UIHandler instance, GraphicsDeviceManager graphicsDevice)
        {
            CurrentLevel = 0f;
            hero = new HeroClass(content, graphicsDevice, instance, enemyList);
            controls = new KeyHandler(hero);
            SpriteFont font = content.Load<SpriteFont>("Font/title_12");
            HealthText = new Text($"Health: {hero.Health}", new Vector2(20f, 50f), font, Color.Gold, false);
            killedEnemiesText = new Text($"Killed: {KilledEnemies}/{totalEnemies}", new Vector2(20f, 90f), font, Color.Gold, false);
            CurrentLevelText = new Text($"Level: {CurrentLevel.ToString("n0")}", new Vector2(20f, 70f), font, Color.Gold, false);
            enemyList.Add(new ToothWalker(content, graphicsDevice, hero, rand.NextFloat(-200f, 1000), rand.NextFloat(0.3f, 1.5f)));
            enemyList.Add(new ToothWalker(content, graphicsDevice, hero, rand.NextFloat(-200f, 1000), rand.NextFloat(0.3f, 1.5f)));
            enemyList.Add(new ToothWalker(content, graphicsDevice, hero, rand.NextFloat(-200f, 1000), rand.NextFloat(0.3f, 1.5f)));
            enemyList.Add(new ToothWalker(content, graphicsDevice, hero, rand.NextFloat(-200f, 1000), rand.NextFloat(0.3f, 1.5f)));
            enemyList.Add(new ToothWalker(content, graphicsDevice, hero, rand.NextFloat(-200f, 1000), rand.NextFloat(0.3f, 1.5f)));
            enemyList.Add(new ToothWalker(content, graphicsDevice, hero, rand.NextFloat(-200f, 1000), rand.NextFloat(0.3f, 1.5f)));
            enemyList.Add(new Goblin(content, graphicsDevice, hero, rand.NextFloat(-1000f, 1000), rand.NextFloat(1f, 2.5f)));
            enemyList.Add(new Goblin(content, graphicsDevice, hero, rand.NextFloat(-1000f, 1000), rand.NextFloat(1f, 2.5f)));
            enemyList.Add(new Goblin(content, graphicsDevice, hero, rand.NextFloat(-1000f, 1000), rand.NextFloat(1f, 2.5f)));
            enemyList.Add(new Goblin(content, graphicsDevice, hero, rand.NextFloat(-1000f, 1000), rand.NextFloat(1f, 2.5f)));
            enemyList.Add(new Goblin(content, graphicsDevice, hero, rand.NextFloat(-1000f, 1000), rand.NextFloat(1f, 2.5f)));
            enemyList.Add(new Bat(content, graphicsDevice, hero, rand.NextFloat(-100f, -500f), rand.NextFloat(3f, 8f)));
            enemyList.Add(new Bat(content, graphicsDevice, hero, rand.NextFloat(1000f, 5000f), rand.NextFloat(3f, 8f)));
            barrelList.Add(new Barrel(content, graphicsDevice, rand.NextFloat(100f, 800f)));
            barrelList.Add(new Barrel(content, graphicsDevice, rand.NextFloat(100f, 800f)));
            KilledEnemies = 0;
            totalEnemies = enemyList.Count;
            addedHealth = false;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            HealthText.updateString(hero.Health < 0f ? "Health: 0" : $"Health: {hero.Health.ToString("n0")}");
            HealthText.Draw(spriteBatch);
            CurrentLevelText.updateString($"Level: {CurrentLevel -1}");
            CurrentLevelText.Draw(spriteBatch);
            killedEnemiesText.updateString($"Killed: {KilledEnemies}/{totalEnemies}");
            killedEnemiesText.Draw(spriteBatch);
            hero.Draw(spriteBatch);
            enemyList.ForEach(enemy =>
            {
                enemy.Draw(spriteBatch);
            });
            barrelList.ForEach(barrel =>
            {
                barrel.Draw(spriteBatch);
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
            barrelList.ForEach(barrel =>
            {
                barrel.Update(gameTime, hero);
            });
            if (KilledEnemies >= totalEnemies)
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
                if (!addedHealth)
                {
                    hero.HeroDamage *= CurrentLevel;
                    CurrentLevel += 1;
                    hero.Health += 5;
                    addedHealth = true;
                }
            }
            addedHealth = false;
            if (enemyList.Count > 0)
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
