using System;
using Forum.Data.Repositories;

namespace Forum.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IForumRepository ForumRepository { get; }
        IMessageRepository MessageRepository { get; }
        ISubjectRepository SubjectRepository { get; }
        void Save();
    }
}
