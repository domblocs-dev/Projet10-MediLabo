using MediLabo.Patients.Domain;
using Microsoft.EntityFrameworkCore;

namespace MediLabo.Patients.Data;

public static class PatientsSeed
{
    private static Patient[] PatientsDeTest() =>
    [
        new Patient { Prenom = "Test", Nom = "TestNone", DateNaissance = new DateOnly(1966, 12, 31), GenreId = 1, Adresse = "1 Brookside St", Telephone = "100-222-3333" },
        new Patient { Prenom = "Test", Nom = "TestBorderline", DateNaissance = new DateOnly(1945, 6, 24), GenreId = 2, Adresse = "2 High St", Telephone = "200-333-4444" },
        new Patient { Prenom = "Test", Nom = "TestInDanger", DateNaissance = new DateOnly(2004, 6, 18), GenreId = 2, Adresse = "3 Club Road", Telephone = "300-444-5555" },
        new Patient { Prenom = "Test", Nom = "TestEarlyOnset", DateNaissance = new DateOnly(2002, 6, 28), GenreId = 1, Adresse = "4 Valley Dr", Telephone = "400-555-6666" },
    ];

    public static void Seed(DbContext context, bool _)
    {
        if (context.Set<Patient>().Any()) return;

        context.Set<Patient>().AddRange(PatientsDeTest());
        context.SaveChanges();
    }

    public static async Task SeedAsync(DbContext context, bool _, CancellationToken cancellationToken)
    {
        if (await context.Set<Patient>().AnyAsync(cancellationToken)) return;

        context.Set<Patient>().AddRange(PatientsDeTest());
        await context.SaveChangesAsync(cancellationToken);
    }
}