using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Core.Entities
{
    class Role : Identity
    {
        public string Name { get; private set; }
    }
}
