using Infirmary.Models.Shared;
using Infirmary.Models.Users;
namespace Infirmary.Models.Roles
{
    public class Role :  BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public List<User> Users { get; set; } = new List<User>();
    }
}
