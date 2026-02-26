using Microsoft.EntityFrameworkCore;
using gestionTaches.Domain.Entities;

namespace gestionTaches.Infrastructure;

public class TachesDBContext: DbContext
{
    public TachesDBContext(DbContextOptions<TachesDBContext> options) : base(options)
    {
        
    }
    public DbSet<Tache> Taches { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .ToTable("Users"); 

        modelBuilder.Entity<Tache>()
            .HasOne(t => t.User)
            .WithMany(u => u.Taches)
            .HasForeignKey(t => t.UserId);

        base.OnModelCreating(modelBuilder);
    }
}