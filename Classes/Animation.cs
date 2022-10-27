using Microsoft.Xna.Framework;
using System.Collections.Generic;


namespace Forest_of_wrath.Classes
{
    internal class Animation
    {
        public AnimationFrame _currentFrame { get; set; }
        public AnimationFrame _lastFrame { get; set; }
        private List<AnimationFrame> _frames;
        private int _counter;
        private double _elapsedCounter = 0;
        private int _fps;
        public Animation(int fps)
        {
            _fps = fps;
            _frames = new List<AnimationFrame>();
        }
        public void AddFrame(AnimationFrame frame)
        {
            _frames.Add(frame);
            _currentFrame = _frames[0];
            _lastFrame = _frames[_frames.Count-1];
        }
        public void Update(GameTime gameTime)
        {
            _currentFrame = _frames[_counter];

            _elapsedCounter += gameTime.ElapsedGameTime.TotalSeconds;
            if (_elapsedCounter >= 1d / _fps)
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
