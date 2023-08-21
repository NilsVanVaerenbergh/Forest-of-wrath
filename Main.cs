using Forest_of_wrath.Entities;
using Forest_of_wrath.Entities.Enemies;
using Forest_of_wrath.Entities.Platforms;
using Forest_of_wrath.Handlers;
using Forest_of_wrath.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Diagnostics;
using Color = Microsoft.Xna.Framework.Color;

namespace Forest_of_wrath
{
    public class Main : Game
    {
       private GraphicsDeviceManager _graphics;
        private Background _background;
        private RenderTarget2D _renderTarget;
        private UIHandler _uiHandler;
        Color _color;
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
            Globals.spriteBatch = new SpriteBatch(GraphicsDevice);
            Globals.contentManager = Content;
            _color = new Color(12, 17, 34);
            IsMouseVisible = true;
            _graphics.PreferredBackBufferHeight = 680;
            _graphics.PreferredBackBufferWidth = 928;
            _graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _renderTarget = new RenderTarget2D(GraphicsDevice, 928, 680);
            InitializeGameObjects();
            _background = new Background();
            // TODO: use this.Content to load your game content here
        }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            _uiHandler.Update(gameTime);
            base.Update(gameTime);
        }
        protected override void UnloadContent()
        {
            base.UnloadContent();
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.BurlyWood);
            // TODO: Add your drawing code here
            GraphicsDevice.SetRenderTarget(_renderTarget);
            GraphicsDevice.Clear(_color);
            // TODO: Add your drawing code here
            GraphicsDevice.SetRenderTarget(null);
            GraphicsDevice.Clear(_color);
            Globals.spriteBatch.Begin();
            Globals.spriteBatch.Draw(_renderTarget, Vector2.Zero, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            Globals.spriteBatch.End();
            Globals.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);
            _background.Draw();
            _uiHandler.Draw();
            Globals.spriteBatch.End();
            base.Draw(gameTime);
        }
        private void InitializeGameObjects()
        {
            Globals.inputReader = new MovementHandler();
            Globals.graphicsDeviceManager = _graphics;
            Globals.collisionHandler = new CollisionHandler();
            Globals.hero = new Hero(Globals.contentManager.Load<Texture2D>("Hero/Idle"));
            _uiHandler = new UIHandler();
        }
    }
}