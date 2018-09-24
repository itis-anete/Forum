using Forum.Infrastructure.Entities;
using System.Threading.Tasks;

namespace Forum.Data.Repositories
{
    public interface IForumRepository
    {
        Task AddSubForum(Subforum subforum);
        int Save();
    }
}
