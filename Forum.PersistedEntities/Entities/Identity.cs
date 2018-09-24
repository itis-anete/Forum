namespace Forum.Infrastructure.Entities
{
    public abstract class Identity
    {
        public int Id { get; set; }

        public override int GetHashCode() => Id.GetHashCode();
    }
}
