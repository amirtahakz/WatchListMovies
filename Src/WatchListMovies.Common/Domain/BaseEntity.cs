namespace WatchListMovies.Common.Domain
{
    public class BaseEntity
    {
        public Guid Id { get; private set; }
        public DateTime CreationDate { get; private set; }
        public BaseEntity()
        {
            CreationDate = DateTime.Now;
            Id = Guid.NewGuid();
        }
    }
}
