using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO.Models; 

public class Doctor
{
    [Key]
    public int Id { get; set; }

    [Required, MaxLength(100)]
    public string Name { get; set; } = null!;

    [MaxLength(100)]
    public string? Specialization { get; set; } = null!;
    
    public string? Position { get; set; }

    [MaxLength(20)]
    public string? ContactNumber { get; set; } = null!;
    
    public string? Email { get; set; } = null;
    
    public string? ImageUrl { get; set; } = null;
    
    public string? WorkTime { get; set; } = null;
    
    public string? Biography { get; set; } = null;
    
}