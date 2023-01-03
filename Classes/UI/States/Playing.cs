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
        Hitbox mainHeroHitBox;
        public Playing(ContentManager content, UIHandler instance, GraphicsDeviceManager graphicsDevice)
        {
            this.content = content;
            this.instance = instance;
            hero = new HeroClass(content);
            controls = new KeyHandler(hero);
            mainHeroHitBox = new Hitbox(graphicsDevice);
            mainHeroHitBox.Load(22, 65);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            mainHeroHitBox.Draw(spriteBatch, new Vector2(hero._position.X + 75f, hero._position.Y + 59f));
            hero.Draw(spriteBatch);
        }

        public void Update(GameTime gameTime)
        {
            controls.Handle();
            hero.Update(gameTime);
        }
    }
}
