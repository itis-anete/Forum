using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forum.Data.Repositories;

namespace Forum.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private GeneralContext context;
        private IForumRepository forumRepository;
        private IMessageRepository messageRepository;
        private ISubjectRepository subjectRepository;

        public IForumRepository ForumRepository => forumRepository ?? (forumRepository = new ForumRepository(context));

        public IMessageRepository MessageRepository => messageRepository ?? (messageRepository = new MessageRepository(context));

        public ISubjectRepository SubjectRepository => subjectRepository ?? (subjectRepository = new SubjectRepository(context));

        public UnitOfWork(string connectionString)
        {
            
        }

        public void Save() => context.SaveChanges();

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
