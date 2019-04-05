using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Core.Entities
{
    class Forum
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public ICollection<Theme> Themes { get; private set; }
        public ICollection<User> Supermoderators { get; private set; }
    }
}
