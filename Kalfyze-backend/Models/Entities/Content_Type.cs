namespace Kalfyze_backend.Models.Entities
{
    public class Content_Type
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Content> Contents { get; set; }
    }
}
