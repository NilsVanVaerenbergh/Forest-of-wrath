using Forest_of_wrath.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_of_wrath.Interfaces
{
    internal interface ILevelState : IUIStateObject
    {
        public Portal GetPortal();
    }
}
