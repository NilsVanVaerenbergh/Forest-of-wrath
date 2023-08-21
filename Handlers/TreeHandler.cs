using Forest_of_wrath.Entities;
using Forest_of_wrath.Entities.HeroAnimations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_of_wrath.Handlers
{
    internal class TreeHandler
    {
        private Tree tree;
        public TreeHandler(Tree tree) { 
         this.tree = tree;
        }
        public void Update()
        {
            if (tree != null)
                Globals.hero.SetHidden(tree.GetHitbox().GetRectangle().Intersects(Globals.hero.GetHitbox().GetRectangle()));
        }
    }
}
