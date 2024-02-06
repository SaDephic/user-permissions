using System.ComponentModel.DataAnnotations;

namespace user_permissions.Data
{
    public class Permission
    {
        public string UserRole { get; set; }
        public string[] Permissions { get; set; }
    }
}
