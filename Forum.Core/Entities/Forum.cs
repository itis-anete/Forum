using System;
using System.Collections.Generic;

namespace Forum.Core.Entities
{
    public class Forum : Identity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public string ImgUrl { get; set; }

        public IEnumerable<Topic> Topics { get; set; }

        public Forum(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
