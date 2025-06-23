using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace DTO.Models; 

public class User : IdentityUser
{
    [Required, MaxLength(100)]
    public string FullName { get; set; } = null!;
    
    public string? About { get; set; }
    public string? Image { get; set; }
}