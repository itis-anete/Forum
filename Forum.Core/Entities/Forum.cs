
namespace Forum.Core.Entities
{
    public class Forum : Identity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Forum(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
