using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_of_wrath.Handlers
{
    internal class Animation
    {
        private AnimationFrame currentFrame;
        private AnimationFrame lastFrame;
        private AnimationFrame firstFrame;
        private List<AnimationFrame> frames;
        private int counter;
        private double elapsedCounter = 0;
        private int fps;
        public Animation(int fps)
        {
            this.fps = fps;
            frames = new List<AnimationFrame>();
        }
        public void AddFrame(AnimationFrame frame)
        {
            frames.Add(frame);
            currentFrame = frames[0];
            lastFrame = frames[frames.Count - 1];
            firstFrame = frames[0];
        }
        public void Update(GameTime gameTime)
        {
            currentFrame = frames[counter];
            elapsedCounter += gameTime.ElapsedGameTime.TotalSeconds;
            if (elapsedCounter >= 1d / fps)
            {
                counter++;
                elapsedCounter = 0;
            }
            if (counter >= frames.Count)
            {
                counter = 0;
            }
        }
        public AnimationFrame getFirstFrame() { return firstFrame; }
        public AnimationFrame getLastFrame() { return lastFrame; }
        public AnimationFrame getCurrentFrame() { return currentFrame; }
        public void setCurrentFrame(AnimationFrame newFrame) { currentFrame = newFrame; }

    }
}
