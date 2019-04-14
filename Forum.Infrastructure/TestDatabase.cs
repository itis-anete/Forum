using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Infrastructure
{
    using Forum.Core.Entities;

    public class TestDatabase
    {
        public List<string> EntityTypes;
        public List<Forum> Forums;

        public TestDatabase()
        {
            EntityTypes = new List<string>() { "Forum" };
            Forums = new List<Forum>() { new Forum("Phones", "All about phones"), new Forum("Phones", "All about phones") };
        }
    }
}
