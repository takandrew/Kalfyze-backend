namespace Kalfyze_backend.Models.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string? PathToImage { get; set; }
        public int RoleId { get; set; }

        public User_Role Role { get; set; }
        public ICollection<User_Content_Record> ContentRecords { get; set; }
    }
}
