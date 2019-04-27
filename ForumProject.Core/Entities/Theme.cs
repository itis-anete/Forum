using System;
using System.Collections.Generic;
using System.Text;

namespace ForumProject.Core.Entities
{
    public class Theme : Identity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ForumId { get; set; }
    }
}
