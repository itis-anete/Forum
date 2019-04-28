using System;
using System.Collections.Generic;
using System.Text;

namespace ForumProject.Core.Entities
{
    public class Comment : Identity
    {
        public int WriterId{ get; set; }
        public string Text { get; set; }
        public DateTime CreationDate { get; set; }
        public int TopicId { get; set; }
    }
}

