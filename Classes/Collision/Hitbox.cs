﻿using Forest_of_wrath.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_of_wrath.Classes.Collision
{
    internal class Hitbox : IHitBoxObject
    {
        private GraphicsDeviceManager graphicsDeviceManager;
        private Texture2D rect;
        private Color[] data;

        public Hitbox(GraphicsDeviceManager graphicsDevice)
        {
            graphicsDeviceManager = graphicsDevice;
        }
        public void Load(int width, int height)
        {
            rect = new Texture2D(graphicsDeviceManager.GraphicsDevice,width, height);
            data = new Color[width * height];
            for(int i=0; i<data.Length; i++) {
                data[i] = Color.White;
            }
            rect.SetData(data);
        }
        public void Unload()
        {
            rect.Dispose();
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 pos)
        {
            spriteBatch.Draw(rect,pos,Color.Red);
        }
    }
}
