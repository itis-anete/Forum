using ForumProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ForumProject.Infrastructure.Database.Interfaces
{
    public interface ITopicRepository
    {
        Task Add(Topic theme);
        Topic GetById(int? themeId);
        Task Edit(Topic theme);
        Task Delete(Topic theme);
        IEnumerable<Topic> GetAllTopics();
    }
}
