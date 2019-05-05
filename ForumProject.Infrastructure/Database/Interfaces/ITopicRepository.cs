using ForumProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ForumProject.Infrastructure.Database.Interfaces
{
    public interface ITopicRepository
    {
        Task Add(Topic topic);
        Topic GetById(int? topicId);
        Task Edit(Topic topic);
        Task Delete(Topic topic);
        IEnumerable<Topic> GetAllTopics(int? themeId);
    }
}
