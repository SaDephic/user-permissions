using System.ComponentModel.DataAnnotations;

namespace user_permissions.Data
{
    public class User
    {
        public string Id { get; set; }

        public string UserLogin { get; set; }

        public string UserRole { get; set; }
    }
}
