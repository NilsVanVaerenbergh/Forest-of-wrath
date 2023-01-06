using Forest_of_wrath.Classes.Animations;
using Forest_of_wrath.Classes.Collision;
using Forest_of_wrath.Classes.UI;
using Forest_of_wrath.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_of_wrath.Classes.Hero.States
{
    internal class Crouch : IStateObject
    {
        Texture2D _heroTexture;
        Animation _animation;
        public int frameWidth { get; set; }
        public Hitbox bodyHitBox { get; set; }
        private SoundEffect _sound;
        private HeroClass _heroInstance;
        public Crouch(ContentManager content, HeroClass heroInstance,GraphicsDeviceManager graphicsDevice, Vector2 lastKnowPostition)
        {
            /*
             *  DEATH STATE Hero/Death
             *  FRAMES: 4
             */
            _heroTexture = content.Load<Texture2D>("Hero/Crouch");
            _sound = content.Load<SoundEffect>("Sound/Hero/crouch"); 
            frameWidth = _heroTexture.Width / 4;
            _animation = new Animation(4);
            _animation.AddFrame(new AnimationFrame(new Rectangle(0, 0, frameWidth, _heroTexture.Height)));
            _animation.AddFrame(new AnimationFrame(new Rectangle(frameWidth, 0, frameWidth, _heroTexture.Height)));
            _animation.AddFrame(new AnimationFrame(new Rectangle(frameWidth * 2, 0, frameWidth, _heroTexture.Height)));
            _animation.AddFrame(new AnimationFrame(new Rectangle(frameWidth * 3, 0, frameWidth, _heroTexture.Height)));
            _sound.Play();
            _heroInstance = heroInstance;
            bodyHitBox = new Hitbox(graphicsDevice);
            bodyHitBox.Load(20, 30, new Vector2(lastKnowPostition.X + 80f, lastKnowPostition.Y));
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 position, SpriteEffects effect)
        {
            Debug.WriteLine(_heroInstance.getHide());
            spriteBatch.Draw(_heroTexture, position, _animation._currentFrame._sourceRectangle, _heroInstance.getHide() ? Color.White * 0.3f : Color.White, 0f, Vector2.Zero, 1f, effect, 0f);
            bodyHitBox.Draw(spriteBatch, new Vector2(position.X + 80f, position.Y + _heroTexture.Height - 40f));
        }
        public void Update(GameTime gameTime, Hitbox hitbox = null)
        {
            if(_animation._currentFrame != _animation._lastFrame)
            {
                _animation.Update(gameTime);
            }
        }
        public void setUiInstance(UIHandler instance)
        {
        }
    }
}
