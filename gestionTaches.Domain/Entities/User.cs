using System.ComponentModel.DataAnnotations;

namespace gestionTaches.Domain.Entities;

public class User : BaseEntity
{
    [Required]
    [EmailAddress]
    [MaxLength(255)]
    public string Email { get; set; }

    [Required]
    [MaxLength(100)]
    public string Nom { get; set; }

    [Required]
    [MaxLength(10)]
    public string Password { get; set; }

    public List<Tache> Taches { get; set; }
    
}