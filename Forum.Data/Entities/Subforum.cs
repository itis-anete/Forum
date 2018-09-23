namespace Forum.Infrastructure.Entities
{
    using System.Collections.Generic;

    public class Subforum : Identity
    {
        public string Name { get; set; }

        public List<Subject> Subjects { get; set; }
    }
}