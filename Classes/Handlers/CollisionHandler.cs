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
        public CollisionHandler(int frameWidth, int frameHeight)
        {
            _frameWidth = frameWidth;
            _frameHeight = frameHeight;
            _distance = new Distance();
        }
        public float[] distanceFromWindow(Vector2 position)
        {
            _distance.x1 = position.X;
            _distance.y1 = position.Y;
            _distance.x2 = GraphicsDeviceManager.DefaultBackBufferWidth - (_frameWidth + position.X);
            _distance.y2 = GraphicsDeviceManager.DefaultBackBufferHeight - (_frameHeight + position.Y);
            Debug.WriteLine($"x:{_distance.x1}y:{_distance.y1} | x2:{_distance.x2}y2:{_distance.y2}");
            return new float[4] {_distance.x1,_distance.y1,_distance.x2,_distance.y2};
                                
        }                       
    }                           
}
