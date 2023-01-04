﻿using Forest_of_wrath.Classes.Animations;
using Forest_of_wrath.Classes.Collision;
using Forest_of_wrath.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;



namespace Forest_of_wrath.Classes.Enemies.ToothWalker.States
{
    internal class Idle: IStateObject
    {
        Texture2D _enemyTexture;
        public Animation _animation;
        Hitbox bodyHitBox;
        public int frameWidth { get; set; }
        Hitbox IStateObject.bodyHitBox { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public Idle(ContentManager content, GraphicsDeviceManager graphicsDevice)
        {
            /*
             *  IDLE STATE Enemies/ToothWalker/Idle
             *  FRAMES: 4
             */
            _enemyTexture = content.Load<Texture2D>("Enemies/ToothWalker/Idle");
            frameWidth = _enemyTexture.Width / 4;
            _animation = new Animation(4);
            _animation.AddFrame(new AnimationFrame(new Rectangle(0, 0, frameWidth, _enemyTexture.Height)));
            _animation.AddFrame(new AnimationFrame(new Rectangle(frameWidth, 0, frameWidth, _enemyTexture.Height)));
            _animation.AddFrame(new AnimationFrame(new Rectangle(frameWidth * 2, 0, frameWidth, _enemyTexture.Height)));
            _animation.AddFrame(new AnimationFrame(new Rectangle(frameWidth * 3, 0, frameWidth, _enemyTexture.Height)));
            bodyHitBox = new Hitbox(graphicsDevice);
            bodyHitBox.Load(13, 45);
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 position, SpriteEffects effect)
        {
            bodyHitBox.Draw(spriteBatch, new Vector2(position.X + 70f, position.Y + 59f));
            spriteBatch.Draw(_enemyTexture, position, _animation._currentFrame._sourceRectangle, Color.White, 0f, Vector2.Zero, 1f, effect, 0f);
        }
        public void Update(GameTime gameTime, Hitbox hitbox = null)
        {
            _animation.Update(gameTime);
        }
    }
}