using MediLabo.Patients.Domain;
using Microsoft.EntityFrameworkCore;

namespace MediLabo.Patients.Data;

public class PatientsDbContext(DbContextOptions<PatientsDbContext> options) : DbContext(options)
{
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Genre> Genres { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Patient>(entity =>
        {
            entity.Property(p => p.Prenom).HasMaxLength(100);
            entity.Property(p => p.Nom).HasMaxLength(100);
            entity.Property(p => p.Adresse).HasMaxLength(200);
            entity.Property(p => p.Telephone).HasMaxLength(20);

            entity.ToTable(t => t.HasCheckConstraint(
                "CK_Patients_DateNaissance",
                "[DateNaissance] <= CAST(GETDATE() AS date)"));
            entity.HasOne(p => p.Genre)
                .WithMany()
                .HasForeignKey(p => p.GenreId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.Property(g => g.Code)
                  .HasMaxLength(1)
                  .IsUnicode(false)
                  .IsFixedLength();

            entity.HasIndex(g => g.Code).IsUnique();
        });
    }

}
