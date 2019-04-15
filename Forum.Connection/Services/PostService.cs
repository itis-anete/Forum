using Forum.Core.Entities;
using Forum.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Forum.Connection.Services
{
    public class PostService
    {
        public TestDatabase TestDb;

        public PostService() {
            TestDb = new TestDatabase();
        }

        public IEnumerable<Topic> GetByForum(int id)
        {
            return TestDb.Topics.Where(x => x.ForumId == id);
        }
    }
}
