using Forest_of_wrath.Classes.Collision;
using Forest_of_wrath.Classes.Enemies.ToothWalker;
using Forest_of_wrath.Classes.Handlers;
using Forest_of_wrath.Classes.Hero;
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
        List<ToothWalker> toothWalkers = new List<ToothWalker>();
        Text HealthText;
        Text CurrentLevelText;
        public Playing(ContentManager content, UIHandler instance, GraphicsDeviceManager graphicsDevice)
        {
            this.content = content;
            this.instance = instance;
            hero = new HeroClass(content, graphicsDevice);
            controls = new KeyHandler(hero);
            SpriteFont font = content.Load<SpriteFont>("Font/title_12");
            HealthText = new Text($"Health: {hero.Health}", new Vector2(20f, graphicsDevice.GraphicsDevice.Viewport.Height - 50f), font, Color.Gold, false);
            CurrentLevelText = new Text($"Level: 1", new Vector2(20f, graphicsDevice.GraphicsDevice.Viewport.Height - 50f + 12f), font, Color.Gold, false);
            toothWalkers.Add(new ToothWalker(content, graphicsDevice));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            HealthText.updateString($"Health: {hero.Health}");
            HealthText.Draw(spriteBatch);
            CurrentLevelText.Draw(spriteBatch);
            hero.Draw(spriteBatch);
            toothWalkers.ForEach(toothWalker =>
            {
                toothWalker.Draw(spriteBatch);
            });
        }

        public void Update(GameTime gameTime)
        {
            controls.Handle();
            hero.Update(gameTime);
            toothWalkers.ForEach(toothWalker =>
            {
                toothWalker.Update(gameTime, hero._state.bodyHitBox.HitBoxPosition);
            });
        }
    }
}
