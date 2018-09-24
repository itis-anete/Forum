using Forum.Infrastructure.Entities;
using System.Threading.Tasks;

namespace Forum.Data.Repositories
{
    public interface IMessageRepository
    {
        Task AddMessage(Message message);
        int Save();
    }
}
