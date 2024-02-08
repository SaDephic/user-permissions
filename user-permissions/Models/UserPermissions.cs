using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Models
{
    [DataContract]
    public partial class UserPermissions : IEquatable<UserPermissions>
    { 
        /// Роль
        [Required]
        [Key]
        [DataMember(Name="userRole")]
        public string UserRole { get; set; }

        /// Список доступов
        [DataMember(Name="permissions")]
        public List<string> Permissions { get; set; }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class UserPermissions {\n");
            sb.Append("  UserRole: ").Append(UserRole).Append("\n");
            sb.Append("  Permissions: ").Append(Permissions).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((UserPermissions)obj);
        }
        public bool Equals(UserPermissions other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    UserRole == other.UserRole ||
                    UserRole != null &&
                    UserRole.Equals(other.UserRole)
                ) && 
                (
                    Permissions == other.Permissions ||
                    Permissions != null &&
                    Permissions.SequenceEqual(other.Permissions)
                );
        }
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                var hashCode = 41;
                // Suitable nullity checks etc, of course :)
                    if (UserRole != null)
                    hashCode = hashCode * 59 + UserRole.GetHashCode();
                    if (Permissions != null)
                    hashCode = hashCode * 59 + Permissions.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(UserPermissions left, UserPermissions right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(UserPermissions left, UserPermissions right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
