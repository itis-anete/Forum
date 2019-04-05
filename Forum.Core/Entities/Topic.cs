using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Core.Entities
{
    class Topic
    {
        public string Head { get; private set; }
        public string Text { get; private set; }
        public User Creator { get; private set; }
        public DateTime CreationDate { get; private set; }
        public Guid ThemeId { get; private set; }   
    }
}
