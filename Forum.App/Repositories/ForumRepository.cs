using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Data.Repositories
{
    public class ForumRepository : IForumRepository
    {
        private readonly GeneralContext context;

        public ForumRepository(GeneralContext givenContext)
        {
            context = givenContext;
        }
    }
}
