namespace Kalfyze_backend.Models
{
    public class User_Content_Record
    {
        public int UserId { get; set; }
        public int ContentId { get; set; }
        public int StatusId { get; set; }
        public int CapacityProgress { get; set; }

        public User User { get; set; }
        public Content Content { get; set; }
        public User_Content_Status Status { get; set; }

        public ICollection<User_Content_Record_Log> Logs { get; set; }
    }
}
