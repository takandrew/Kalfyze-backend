namespace Kalfyze_backend.Models.Entities
{
    public class Content
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public string? Description { get; set; }
        public string? ReleaseDate { get; set; }
        public string? PathToImage { get; set; }
        public int TypeId { get; set; }
        public int? FranchiseId { get; set; }

        public Franchise? Franchise { get; set; }
        public Content_Type Type { get; set; }
        public ICollection<User_Content_Record> ContentRecords { get; set; }
    }
}
