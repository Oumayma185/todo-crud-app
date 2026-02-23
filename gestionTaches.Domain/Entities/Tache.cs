using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestionTaches.Domain.Entities;

public class Tache : BaseEntity
{
    [Required]
    public int UserId { get; set; }

    [Required]
    [MaxLength(50)]
    public string Title { get; set; }

    public string? Description { get; set; }

    public bool IsDone { get; set; } = false;

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    [ForeignKey("UserId")]
    public User User { get; set; }
    
}