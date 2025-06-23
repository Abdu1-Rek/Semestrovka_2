using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO.Models; 

public class Patient
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string ApplicationUserId { get; set; } = null!;

    [ForeignKey(nameof(ApplicationUserId))]
    public User User { get; set; } = null!;
    
    [Required, MaxLength(100)]
    public string Name { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }

    public string? MedicalHistory { get; set; } = null!;
}