using Microsoft.EntityFrameworkCore;
using gestionTaches.Domain.Entities;

namespace gestionTaches.Infrastructure;

public class TachesDBContext: DbContext
{
    public TachesDBContext(DbContextOptions<TachesDBContext> options) : base(options)
    {
        
    }
    public DbSet<Tache> Taches { get; set; }
    
}