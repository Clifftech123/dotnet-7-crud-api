using dotnet_7_crud_api.Entitiles;
using System.ComponentModel.DataAnnotations;

namespace dotnet_7_crud_api.Models.Users
{
    public class UpdateRequest
{
    public Guid? guid { get; set; }

    public string? Title { get; set; }
    public string? firstName { get; set; }
    public string? lastName { get; set; }

    [EnumDataType(typeof(Role))]
    public string? Role { get; set; }

    [EmailAddress]
    public string? email { get; set; }

    private string? _password;
    [MinLength(6)]
    public string? password
    {
        get => _password; 
        set => _password = string.IsNullOrEmpty(value) ? null : value; 
    }

    private string? _confirmPassword;
    [Compare("password")]
    public string? confirmPassword
    {
        get => _confirmPassword; 
        set => _confirmPassword = string.IsNullOrEmpty(value) ? null : value; 
    }

    private string? replaceEmptyStringWithNull(string? value)
    {
        return string.IsNullOrEmpty(value) ? null : value;
    }
}
    
};
