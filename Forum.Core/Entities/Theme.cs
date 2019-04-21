using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Core.Entities
{
    public class Theme
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ForumId { get; set; }

        public Theme(string name, string description, int forumId)
        {
            Name = name;
            Description = description;
            ForumId = forumId;
        }
    }
}
