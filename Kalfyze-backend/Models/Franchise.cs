namespace Kalfyze_backend.Models
{
    public class Franchise
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Content> Contents { get; set; }
    }
}
