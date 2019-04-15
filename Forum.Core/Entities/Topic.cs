using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Core.Entities
{
    public class Topic
    {
        public int Id { get; set; }
        public string Head { get; set; }
        public string Text { get; set; }
        public User Creator { get; set; }
        public DateTime CreationDate { get; set; }
        public int ThemeId { get; set; }  
        
        public int ForumId { get; set; }

        public IEnumerable<Comment> Comments { get; set; }

        public Topic(int id, int forum, string title, string text)
        {
            Id = id;
            ForumId = forum;
            Head = title;
            Text = text;
        }
    }
}
