using System.ComponentModel.DataAnnotations.Schema;

namespace Kalfyze_backend.Models
{
    public class User_Role
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
