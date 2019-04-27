using System;
using System.Collections.Generic;
using System.Text;

namespace ForumProject.Core.Entities
{
    public class Topic : Identity
    {
        public string Head { get; set; }
        public string Text { get; set; }
        public int CreatorId { get; set; }
        public DateTime CreationDate { get; set; }
        public int ThemeId { get; set; }   
    }
}


