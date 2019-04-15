using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Web
{
    public class ForumTopic
    {
        public Core.Entities.Forum Forum { get; set; }
        public IEnumerable<Core.Entities.Topic> Topics { get; set; }
    }
}
