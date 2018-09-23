using System.Threading.Tasks;
using Forum.Infrastructure.Entities;

namespace Forum.Data.Repositories
{
    public interface ISubjectRepository
    {
        Task AddSubject(Subject subject);
        int Save();
    }
}
