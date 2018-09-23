using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Data.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly GeneralContext context;

        public MessageRepository(GeneralContext givenContext)
        {
            context = givenContext;
        }
    }
}
