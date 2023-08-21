using Forest_of_wrath.Entities;
using Forest_of_wrath.Handlers;
using Forest_of_wrath.Interfaces;
using Forest_of_wrath.UI.States;
using Forest_of_wrath.Util;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;


namespace Forest_of_wrath
{
    internal class Globals
    {
        #region DEBUG
        static public bool debug = false;
        #endregion
        static public SpriteBatch spriteBatch;
        static public ContentManager contentManager;
        static public IInputReader inputReader;
        static public GraphicsDeviceManager graphicsDeviceManager;
        static public CollisionHandler collisionHandler;
        #region Entities
        static public Hero hero;
        static public List<IPlatformObject> platforms = new List<IPlatformObject>();
        static public List<Enemy> enemies = new List<Enemy>();
        #endregion

        #region Level design
        static public int level = 0;
        static public IUIStateObject uiState;
        static public int floorYPosition = 500;
        static public RandomValue randomValue = new RandomValue();
        static public ILevelState currentLevel;
        #endregion

    }
}
