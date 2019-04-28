using ForumProject.Core.Entities;
using ForumProject.Infrastructure.Database.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumProject.Infrastructure.Database.Repositories
{
    class TopicRepositories : ITopicRepository
    {
        private readonly ForumDbContext _context;

        public TopicRepositories(ForumDbContext context)
        {
            _context = context
                ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task Add(Topic topic)
        {
            //theme.Id = 0; если сущность будет добавляться изнутри форума, то придется применять данную строчку
            await _context.Topics.AddAsync(topic);
            await _context.SaveChangesAsync();
        }

        public Topic GetById(int? topicId)
        {
            var topic = _context.Topics.Find(topicId);
            return topic;
        }

        public Topic GetByHead(string head)
        {
            var topic = _context.Topics.Find(head);
            return topic;
        }

        public async Task Edit(Topic topic)
        {
            var entity = _context.Topics.Find(topic.Id);

            if (entity == null)
                await _context.Topics.AddAsync(topic);
            else
                entity = topic;

            await _context.SaveChangesAsync();
        }

        public async Task Delete(Topic topic)
        {
            _context.Topics.Remove(topic);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Topic> GetAllTopics(int? themeId)
        {
            var topics = _context.Topics
                .AsEnumerable()
                .Where(topic => topic.ThemeId == themeId);
            return topics;
        }
    }
}

