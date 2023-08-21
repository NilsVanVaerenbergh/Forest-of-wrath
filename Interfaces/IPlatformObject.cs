using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_of_wrath.Interfaces
{
    internal interface IPlatformObject
    {
        public void Draw();
        public Rectangle GetRectangle();

        public void SetActive(bool active);
        public bool GetActive();
    }
}
