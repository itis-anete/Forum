using System.Threading.Tasks;
using Forum.Infrastructure.Entities;

namespace Forum.Data.Repositories
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly GeneralContext context;

        public SubjectRepository(GeneralContext givenContext)
        {
            context = givenContext;
        }

        public async Task AddSubject(Subject subject)
        {
            await context.AddAsync(subject);
        }

        public int Save() => context.SaveChanges();
    }
}
