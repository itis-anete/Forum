using ForumProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ForumProject.Infrastructure.Database.Interfaces
{
    public interface IForumRepository
    {
        IEnumerable<Theme> GetThemesFromForum(int? forumId);
        Task Add(Forum forum);
        Task<Forum> GetByIdAsync(int? forumId);
        Task<Forum> GetByNameAsync(string name);
        Task Edit(Forum forum);
        Task Delete(Forum forum);
        IEnumerable<Forum> GetAllForums();
    }
}
