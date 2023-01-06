using Forest_of_wrath.Classes.Animations;
using Forest_of_wrath.Classes.Collision;
using Forest_of_wrath.Classes.Hero;
using Forest_of_wrath.Classes.Hero.States;
using Forest_of_wrath.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_of_wrath.Classes.UI.Foreground
{
    internal class Barrel
    {

        Texture2D _texture;
        Hitbox barrelHitbox;
        Vector2 position;
        public Barrel(ContentManager content, GraphicsDeviceManager graphicsDevice, float randomXPos) 
        {
            _texture = content.Load<Texture2D>("UI/barrel");
            barrelHitbox = new Hitbox(graphicsDevice);
            position = new Vector2(randomXPos, 470);
            barrelHitbox.Load(32,32,position);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            barrelHitbox.Draw(spriteBatch, position);
            spriteBatch.Draw(_texture, position, new Rectangle(0, 0, _texture.Width, _texture.Height), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        }

        public void Update(GameTime gameTime, HeroClass hero)
        {

            Debug.WriteLine(barrelHitbox.rect.Intersects(hero.GetHeroHitbox().rect));
            if (barrelHitbox.rect.Intersects(hero.GetHeroHitbox().rect) && hero.getState() is Crouch)
            {
                hero.setHide(true);
            } else
            {
                hero.setHide(false);
            }
            Debug.WriteLine(hero.getHide());
        }
    }
}
