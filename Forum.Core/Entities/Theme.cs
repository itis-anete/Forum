using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Core.Entities
{
    class Theme
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Guid ForumId { get; private set; }
        public ICollection<User> Moderators { get; private set; }       
    }
}
