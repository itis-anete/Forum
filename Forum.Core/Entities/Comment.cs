using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Core.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public User Writer{ get; set; }
        public string Text { get; set; }
        public DateTime CreationDate { get; set; }
        public Topic Topic { get; set; }
    }
}
