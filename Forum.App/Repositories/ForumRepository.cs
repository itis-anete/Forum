using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forum.Infrastructure.Entities;

namespace Forum.Data.Repositories
{
    public class ForumRepository : IForumRepository
    {
        private readonly GeneralContext context;

        public ForumRepository(GeneralContext givenContext)
        {
            context = givenContext;
        }

        public async Task AddSubForum(Subforum subforum)
        {
            await context.AddAsync(subforum);
        }

        public int Save() => context.SaveChanges();
    }
}
