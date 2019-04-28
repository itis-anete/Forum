using ForumProject.Core.Entities;
using ForumProject.Infrastructure.Database.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumProject.Infrastructure.Database.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ForumDbContext _context;

        public CommentRepository(ForumDbContext context)
        {
            _context = context;
        }

        public async Task Add(Comment comment)
        {
            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Comment comment)
        {
            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
        }

        public async Task Edit(Comment comment)
        {
            var entity = _context.Comments.Find(comment.Id);

            if (entity == null)
                await _context.Comments.AddAsync(comment);
            else
                entity = comment;

            await _context.SaveChangesAsync();
        }

        //Возврат всех коментов принадлежащих какому-то топику
        public IEnumerable<Comment> GetAllComments(int? topicId)
        {
            var comments = _context.Comments
                .AsEnumerable()
                .Where(comment => comment.TopicId == topicId);
            return comments;
        }

        public Comment GetById(int? commentId)
        {
            var comment = _context.Comments.Find(commentId);
            return comment;
        }
    }
}


