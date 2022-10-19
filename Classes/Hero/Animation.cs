using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_of_wrath.Classes.Hero
{
    internal class Animation
    {
        public AnimationFrame _currentFrame { get; set; }
        private List<AnimationFrame> _frames;
        private int _counter;
        private double _elapsedCounter = 0;
        public Animation()
        {
            _frames = new List<AnimationFrame>();
        }
        public void AddFrame(AnimationFrame frame)
        {
            _frames.Add(frame);
            _currentFrame = _frames[0];

        }
        public void Update(GameTime gameTime)
        {
            _currentFrame = _frames[_counter];

            _elapsedCounter += gameTime.ElapsedGameTime.TotalSeconds;
            int fps = 5;

            if(_elapsedCounter >= 1d/fps)
            {
                _counter++;
                _elapsedCounter = 0;
            }

            if (_counter >= _frames.Count)
            {
                _counter = 0;
            }
        }

    }
}
