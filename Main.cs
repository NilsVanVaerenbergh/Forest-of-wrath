using Forest_of_wrath.Classes.Background;
using Forest_of_wrath.Classes.Handlers;
using Forest_of_wrath.Classes.Hero;
using Forest_of_wrath.Classes.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using Color = Microsoft.Xna.Framework.Color;

namespace Forest_of_wrath
{
    public class Main : Game
    {
        public GraphicsDeviceManager _graphics;
        private RenderTarget2D _renderTarget;
        private SpriteBatch _spriteBatch;
        Color _color;
        UIHandler _ui;
        public SpriteFont debugFont { get; set; }

        private Text debugText;

        public float scale = 0f;

        public Main()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            _graphics.GraphicsProfile = GraphicsProfile.HiDef;
            IsMouseVisible = true;
        }
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _color = new Color(12, 17, 34);
            _graphics.PreferredBackBufferWidth = 928;
            _graphics.PreferredBackBufferHeight = 680;
            _graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _renderTarget = new RenderTarget2D(GraphicsDevice, 928, 680);
            // TODO: use this.Content to load your game content here
            debugFont = this.Content.Load<SpriteFont>("Font/debug");
            debugText = new Text("debug", new Vector2(5f), debugFont, Color.White);
            _ui = new UIHandler(this.Content, _graphics);
        }



        protected override void UnloadContent()
        {
            base.UnloadContent();
        }


        protected override void Update(GameTime gameTime)
        {

            _ui.Update(gameTime);
            // TODO: Add your update logic here
            base.Update(gameTime);
            debugText.updateString($"w:{GraphicsDeviceManager.DefaultBackBufferWidth} | h: {GraphicsDeviceManager.DefaultBackBufferHeight}");
        }
        protected override void Draw(GameTime gameTime)
        {

            scale = 1f / (928f / _graphics.GraphicsDevice.Viewport.Width);
            GraphicsDevice.SetRenderTarget(_renderTarget);
            GraphicsDevice.Clear(_color);
            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _ui.Draw(_spriteBatch);
            debugText.Draw(_spriteBatch);
            _spriteBatch.End();

            GraphicsDevice.SetRenderTarget(null);
            GraphicsDevice.Clear(_color);
            _spriteBatch.Begin();
            _spriteBatch.Draw(_renderTarget, Vector2.Zero,null, Color.White, 0f, Vector2.Zero,1f,SpriteEffects.None,0f);
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