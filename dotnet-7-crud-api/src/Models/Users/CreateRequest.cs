using dotnet_7_crud_api.Entitiles;
using System.ComponentModel.DataAnnotations;

namespace dotnet_7_crud_api.Models.Users
{
public class CreateRequest
{
    [Required]
    public Guid guid { get; set; }

    [Required]
    public string? Title { get; set; }

    [Required]
    [StringLength(50)]
    public string? FirstName { get; set; }

    [Required]
    [StringLength(50)]
    public string? LastName { get; set; }

    [Required]
    [EnumDataType(typeof(Role))]
    public string? Role { get; set; }

    [Required]
    [EmailAddress]
    public string? Email { get; set; }

    [Required]
    [MinLength(6)]
    public string? Password { get; set; }

    [Required]
    [Compare("Password")]
    public string? ConfirmPassword { get; set; }
}

};
