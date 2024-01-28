using dotnet_7_crud_api.Entitiles;
using System.ComponentModel.DataAnnotations;

namespace dotnet_7_crud_api.Models.Users
{
    public class UpdateRequest
    {

        public string? Title { get; set; }
        public string?  firstName { get; set; }
        public string?  lastName { get; set; }
          
        // this is for the role

        [EnumDataType(typeof(Role))]
        public string?  Role { get; set; }

        // this is for the email

        [EmailAddress]
        public string?  email { get; set; }
        // treat empty string as null for password fields to 
        // make them optional in front end apps[MinLength(6)]
         private string? _password;
        [MinLength(6)]

        public string?  password
        {
            get => _password; 
            set => _password = string.IsNullOrEmpty(value) ? null : value; 
        }

        private string? _confirmPassword;
        [Compare("password")]
        public string?  confirmPassword
        {
            get => _confirmPassword; 
            set => _confirmPassword = string.IsNullOrEmpty(value) ? null : value; 
        }

        private  string ? replaceEmptyStringWithNull(string? value)
        {
            return string.IsNullOrEmpty(value) ? null : value;
        }
    }
}
