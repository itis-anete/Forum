using ForumProject.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ForumProject.Infrastructure.Database.Interfaces
{
    public interface ICommentRepository
    {
        Task Add(Comment comment);
        Comment GetById(int? commentId);
        Task Edit(Comment comment);
        Task Delete(Comment comment);
        IEnumerable<Comment> GetAllComments(int? topicId);
    }
}



