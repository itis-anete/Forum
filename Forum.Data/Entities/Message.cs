namespace Forum.Infrastructure.Entities
{
    public class Message : Identity
    {
        public string Text { get; set; }

        public Subject Parent { get; set; }
    }
}
