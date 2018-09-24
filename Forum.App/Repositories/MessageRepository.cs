using Forum.Infrastructure.Entities;
using System.Threading.Tasks;

namespace Forum.Data.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly GeneralContext context;

        public MessageRepository(GeneralContext givenContext)
        {
            context = givenContext;
        }

        public async Task AddMessage(Message message)
        {
            await context.AddAsync(message);
        }

        public int Save() => context.SaveChanges();
    }
}
