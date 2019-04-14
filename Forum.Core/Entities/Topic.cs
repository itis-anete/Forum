using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Core.Entities
{
    public class Topic
    {
        public string Head { get; set; }
        public string Text { get; set; }
        public User Creator { get; set; }
        public DateTime CreationDate { get; set; }
        public int ThemeId { get; set; }   
    }
}
