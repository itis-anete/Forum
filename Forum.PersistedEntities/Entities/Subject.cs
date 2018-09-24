namespace Forum.Infrastructure.Entities
{
    using System.Collections.Generic;

    public class Subject : Identity
    {
        public string Name { get; set; }

        public List<Message> Messages { get; set; }
    }
}
