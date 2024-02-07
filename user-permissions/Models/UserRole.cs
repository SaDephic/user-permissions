using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Models
{
    [DataContract]
    public partial class UserRole : IEquatable<UserRole>
    {
        /// Идентификатор записи в таблице
        [Key]
        [DataMember(Name="id")]
        public string Id { get; set; }
        /// Учетная запись пользователя
        [Required]
        [DataMember(Name="userLogin")]
        public string UserLogin { get; set; }
        /// Роль
        [Required]
        [DataMember(Name="userRole")]
        public string _UserRole { get; set; }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class UserRole {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  UserLogin: ").Append(UserLogin).Append("\n");
            sb.Append("  _UserRole: ").Append(_UserRole).Append("\n");
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
            return obj.GetType() == GetType() && Equals((UserRole)obj);
        }
        public bool Equals(UserRole other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    Id == other.Id ||
                    Id != null &&
                    Id.Equals(other.Id)
                ) && 
                (
                    UserLogin == other.UserLogin ||
                    UserLogin != null &&
                    UserLogin.Equals(other.UserLogin)
                ) && 
                (
                    _UserRole == other._UserRole ||
                    _UserRole != null &&
                    _UserRole.Equals(other._UserRole)
                );
        }
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                var hashCode = 41;
                // Suitable nullity checks etc, of course :)
                    if (Id != null)
                    hashCode = hashCode * 59 + Id.GetHashCode();
                    if (UserLogin != null)
                    hashCode = hashCode * 59 + UserLogin.GetHashCode();
                    if (_UserRole != null)
                    hashCode = hashCode * 59 + _UserRole.GetHashCode();
                return hashCode;
            }
        }
    }
}
