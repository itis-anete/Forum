using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Core.Entities
{
    class Comment
    {
        public User Writer{ get; private set; }
        public string Text { get; private set; }
        public DateTime CreationDate { get; private set; }
        public Guid TopicId { get; private set; }
    }
}
