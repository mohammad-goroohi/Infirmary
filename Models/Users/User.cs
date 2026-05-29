using Infirmary.Models.Roles;
using Infirmary.Models.Shared;

namespace Infirmary.Models.Users
{
    public class User : BaseEntity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public int Tall { get; set; }
        public DateTime BirthDate { get; set; }
        public string Time { get; set; }
        public List<int> RolesId { get; set; } = new List<int>();
        public List<Role> Roles { get; set; } = new List<Role>();
    }
}
