namespace Kalfyze_backend.Models
{
    public class User_Content_Record_Log
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ContentId { get; set; }
        public int StatusId { get; set; }
        public int CapacityProgress { get; set;}
        public DateTime LogDatetime { get; set; }

        public User_Content_Record Record { get; set; }
    }
}
