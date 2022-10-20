using Forest_of_wrath.Classes.Background;
using Forest_of_wrath.Classes.Hero;
using Forest_of_wrath.Classes.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using SharpDX.Direct3D9;
using System;

namespace Forest_of_wrath
{
    public class Main : Game
    {
        private GraphicsDeviceManager _graphics;
        private RenderTarget2D _renderTarget;
        private SpriteBatch _spriteBatch;
        Background _background;
        Hero _hero;
        Color _color;
        UI _ui;
        private int speed = 2;
        public float scale = 0.44444f;

        KeyboardState oldStateLeft;
        KeyboardState oldStateRight;

        Song song;

        public Main()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _color = new Color(12, 17, 34);   
            base.Initialize();


            _graphics.PreferredBackBufferWidth = 928;
            _graphics.PreferredBackBufferHeight = 680;
            _graphics.ApplyChanges();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _renderTarget = new RenderTarget2D(GraphicsDevice, 928, 680);
            // TODO: use this.Content to load your game content here
            _background = new Background(this.Content);
            _hero = new Hero(this.Content);
            _ui = new UI(this.Content);
            song = this.Content.Load<Song>("Sound/Game");
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Volume -= 0.9f;
            MediaPlayer.Play(song);
        }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            KeyboardState newStateLeft = Keyboard.GetState();
            if (newStateLeft.IsKeyDown(Keys.Q) && !oldStateLeft.IsKeyDown(Keys.Q))
            {
                _hero.setSpeed(speed * -1, 0);
                _hero.setFlip(SpriteEffects.FlipHorizontally);
                _hero.playSound(CharacterSound.RUNNING);
                _hero.Move();
            }
            else if (newStateLeft.IsKeyDown(Keys.Q) && oldStateLeft.IsKeyDown(Keys.Q))
            {
                _hero.setSpeed(speed * -1, 0);
                _hero.setFlip(SpriteEffects.FlipHorizontally);
                _hero.Move();
            }
            else if (!newStateLeft.IsKeyDown(Keys.Q) && oldStateLeft.IsKeyDown(Keys.Q))
            {
                _hero.setState(CharacterState.IDLE);
            }
            oldStateLeft = newStateLeft;
            KeyboardState newStateRight = Keyboard.GetState();
            if (newStateRight.IsKeyDown(Keys.D) && !oldStateRight.IsKeyDown(Keys.D))
            {
                _hero.setSpeed(speed, 0);
                _hero.setFlip(SpriteEffects.None);
                _hero.playSound(CharacterSound.RUNNING);
                _hero.Move();
            }
            else if (newStateRight.IsKeyDown(Keys.D) && oldStateRight.IsKeyDown(Keys.D))
            {
                _hero.setSpeed(speed, 0);
                _hero.setFlip(SpriteEffects.None);
                _hero.Move();
            }
            else if (!newStateRight.IsKeyDown(Keys.D) && oldStateRight.IsKeyDown(Keys.D))
            {
                _hero.setState(CharacterState.IDLE);
            }
            oldStateRight = newStateRight;
            // TODO: Add your update logic here
            _hero.Update(gameTime);
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {

            scale = 1f / (928f / _graphics.GraphicsDevice.Viewport.Width);
            GraphicsDevice.SetRenderTarget(_renderTarget);
            GraphicsDevice.Clear(_color);
            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _background.Draw(_spriteBatch);
            _hero.Draw(_spriteBatch);
            _ui.Draw(_spriteBatch);
            _spriteBatch.End();

            GraphicsDevice.SetRenderTarget(null);
            GraphicsDevice.Clear(_color);
            _spriteBatch.Begin();
            _spriteBatch.Draw(_renderTarget, Vector2.Zero,null, Color.White, 0f, Vector2.Zero,scale,SpriteEffects.None,0f);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
        public void onResize(object sender, EventArgs e)
        {
            _graphics.PreferredBackBufferWidth = Window.ClientBounds.Width;
            _graphics.PreferredBackBufferHeight = Window.ClientBounds.Height;
        }
    }
}