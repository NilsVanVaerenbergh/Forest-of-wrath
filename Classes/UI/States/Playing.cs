using Forest_of_wrath.Classes.Collision;
using Forest_of_wrath.Classes.Handlers;
using Forest_of_wrath.Classes.Hero;
using Forest_of_wrath.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Forest_of_wrath.Classes.UI.States
{
    internal class Playing : IUiStateObject
    {
        ContentManager content;
        UIHandler instance;
        KeyHandler controls;
        HeroClass hero;
        Text Health;


        public Playing(ContentManager content, UIHandler instance, GraphicsDeviceManager graphicsDevice)
        {
            this.content = content;
            this.instance = instance;
            hero = new HeroClass(content, graphicsDevice);
            controls = new KeyHandler(hero);
            SpriteFont font = content.Load<SpriteFont>("Font/title_12");
            Health = new Text($"Health: {hero.Health}", new Vector2(25f), font, Color.Gold, false);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Health.updateString($"Health: {hero.Health}");
            Health.Draw(spriteBatch);
            hero.Draw(spriteBatch);
        }

        public void Update(GameTime gameTime)
        {
            controls.Handle();
            hero.Update(gameTime);
        }
    }
}
