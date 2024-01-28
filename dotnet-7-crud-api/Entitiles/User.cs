using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace dotnet_7_crud_api.Entitiles
{
    
    public class User
    {
         [Key]
        public Guid Guid { get; set; }
        public string? Title { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public Role Role { get; set; }

        [JsonIgnore]
        public string? PasswordHash { get; set; }
    }
}
