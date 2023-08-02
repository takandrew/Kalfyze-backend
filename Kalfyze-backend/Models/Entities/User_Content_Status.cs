namespace Kalfyze_backend.Models.Entities
{
    public class User_Content_Status
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<User_Content_Record> ContentRecords { get; set; }
    }
}
