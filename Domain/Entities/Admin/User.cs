using Domain.Entities.Inheritance;

namespace Domain.Entities.Admin
{
    public class User : EntityBase
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string HashedPassword { get; set; }
        public bool IsEnabled { get; set; }
        public DateTime? LastLogin { get; set; }
    }
}
