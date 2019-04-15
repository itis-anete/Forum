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
        public List<Topic> Topics;
        public List<Comment> Comments;
        public List<User> Users;

        public TestDatabase()
        {
            EntityTypes = new List<string>() { "Forum", "Topic", "Comment" };
            Forums = new List<Forum>() { new Forum(0, "First", "About first")
                , new Forum(1, "Second", "About second")
            , new Forum(2 ,"Third" ,"About third") };
            Topics = new List<Topic>()
            {
                new Topic(0, 1, "H8ui", "llllll"),
                new Topic(1, 1, "ass", "222222"),
                new Topic(2, 2, "asaqwqqw", "3333333")
            };
        }
    }
}
