using Forest_of_wrath.Entities.HeroAnimations;
using Forest_of_wrath.Handlers;
using Forest_of_wrath.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_of_wrath.Entities
{
    internal class Hero : IGameObject,IEnitity
    {
        private IAnimationObject heroAnimation;
        private Vector2 heroPosition;
        private Vector2 velocity;
        private IInputReader inputReader;
        private Hitbox hitbox;
        private bool hasJumped;
        private bool onPlatform;
        private bool isHidden;
        private int health = 100;
        private SpriteEffects spriteEffect;

        public Hero(Texture2D texture)
        {
            heroAnimation = new HeroIdle();
            heroPosition = new Vector2(10, Globals.floorYPosition - heroAnimation.GetTextureHeight() + 15);
            velocity = new Vector2(0, 0);
            inputReader = Globals.inputReader;
            hasJumped = false;
            onPlatform = false;
            hitbox = new Hitbox();
            hitbox.Load(22, 65, heroPosition, Color.Aquamarine);
            spriteEffect = SpriteEffects.None;
            isHidden = false;
        }
        public void Draw()
        {
            heroAnimation.Draw(heroPosition, spriteEffect);
            if(spriteEffect == SpriteEffects.FlipHorizontally)
            {
                hitbox.Draw(new Vector2(heroPosition.X + 85f, heroPosition.Y + 59f));
            } else
            {
                hitbox.Draw(new Vector2(heroPosition.X + 75f, heroPosition.Y + 59f));
            }
        }
        public void Update(GameTime gameTime)
        {
            heroPosition += velocity;
            inputReader.InputReader();
            heroAnimation.Update(gameTime);
        }
        public void SetXVelocity(float velocity) { this.velocity.X = velocity; }
        public void SetYVelocity(float velocity) { this.velocity.Y = velocity; }
        public Vector2 GetVelocity() { return velocity; }
        public void SetYPosition(float y) { this.heroPosition.Y = y; }
        public Vector2 GetPosition() { return heroPosition; }
        public bool HasJumped() { return hasJumped; }
        public void SetJumped(bool hasJumped) { this.hasJumped = hasJumped; }
        public bool IsHidden() { return isHidden; }
        public void SetHidden(bool hidden) { isHidden = hidden; }
        public void SetEffect(SpriteEffects effect) { spriteEffect = effect; }
        public Hitbox GetHitbox() { return hitbox; }
        public bool GetOnPlatform() { return onPlatform;  }
        public void SetOnPlatform(bool onPlatform) { this.onPlatform = onPlatform; }
        public void SetHealth(int health) { this.health = health; }
        public int GetHealth() { return health; }
        public IAnimationObject GetAnimationObject()
        {
            return heroAnimation;
        }
        public void SetAnimationObject(IAnimationObject animation) { heroAnimation = animation; }
        public void ResetPosition() { heroPosition = new Vector2(10, Globals.floorYPosition - heroAnimation.GetTextureHeight() + 15); }
    }
}
