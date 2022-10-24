using Forest_of_wrath.Classes.Background;
using Forest_of_wrath.Classes.Handlers;
using Forest_of_wrath.Classes.Hero;
using Forest_of_wrath.Classes.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;

namespace Forest_of_wrath
{
    public class Main : Game
    {
        private GraphicsDeviceManager _graphics;
        private RenderTarget2D _renderTarget;
        private SpriteBatch _spriteBatch;
        Background _background;
        HeroClass _hero;
        Color _color;
        UI _ui;
        public float scale = 0f;

        KeyHandler controls;

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
            controls = new KeyHandler(_hero);
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
            _hero = new HeroClass(this.Content);
            _ui = new UI(this.Content);
            song = this.Content.Load<Song>("Sound/Game");
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Volume -= 1f;
            MediaPlayer.Play(song);
        }
        protected override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here
            controls.Handle();
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