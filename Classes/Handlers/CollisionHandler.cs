using Forest_of_wrath.Classes.Collision;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_of_wrath.Classes.Handlers
{
    internal class CollisionHandler
    {
        private int _frameWidth;
        private int _frameHeight;
        private Distance _distance;
        private GraphicsDeviceManager graphicsDeviceManager;
        public CollisionHandler(int frameWidth, int frameHeight, GraphicsDeviceManager graphicsDevice)
        {
            _frameWidth = frameWidth;
            _frameHeight = frameHeight;
            _distance = new Distance();
            graphicsDeviceManager = graphicsDevice;
        }
        public float[] distanceFromWindow(Vector2 position)
        {
            _distance.x1 = position.X;
            _distance.y1 = position.Y;
            _distance.x2 = graphicsDeviceManager.GraphicsDevice.Viewport.Width - ((float)_frameWidth + position.X);
            _distance.y2 = GraphicsDeviceManager.DefaultBackBufferHeight - ((float)_frameHeight + position.Y);
            return new float[4] {_distance.x1,_distance.y1,_distance.x2,_distance.y2};
                                
        }
        public float[] distanceFromHero(Vector2 heroPosition, Vector2 entityPosition)
        {
            float distanceX = heroPosition.X - entityPosition.X;
            return new float[3] {entityPosition.X,entityPosition.Y, distanceX}; 
        }
    }                           
}
