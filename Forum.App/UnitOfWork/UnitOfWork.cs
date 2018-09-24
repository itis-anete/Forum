using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forum.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Forum.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private GeneralContext context;
        private IForumRepository forumRepository;
        private IMessageRepository messageRepository;
        private ISubjectRepository subjectRepository;
        private bool isDisposed = false;

        public IForumRepository ForumRepository => forumRepository ?? (forumRepository = new ForumRepository(context));

        public IMessageRepository MessageRepository => messageRepository ?? (messageRepository = new MessageRepository(context));

        public ISubjectRepository SubjectRepository => subjectRepository ?? (subjectRepository = new SubjectRepository(context));

        public UnitOfWork(string connectionString)
        {
            var options = new DbContextOptionsBuilder<GeneralContext>();
            options.UseSqlServer(connectionString);
            context = new GeneralContext(options.Options);
        }

        public void Save() => context.SaveChanges();

        #region IDisposableImplementation
        public virtual void Dispose(bool disposing)
        {
            if (!isDisposed)
            {
                if (disposing)
                    context.Dispose();
                isDisposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
