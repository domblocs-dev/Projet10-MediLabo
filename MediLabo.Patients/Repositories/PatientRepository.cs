using MediLabo.Patients.Data;
using MediLabo.Patients.Domain;
using Microsoft.EntityFrameworkCore;

namespace MediLabo.Patients.Repositories;

public class PatientRepository(PatientsDbContext context)
{
    public async Task<List<Patient>> FindAllAsync()
    {
        return await context.Patients
            .Include(p => p.Genre)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Patient?> FindByIdAsync(int id)
    {
        return await context.Patients
            .Include(p => p.Genre)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Genre?> FindGenreByCodeAsync(string code)
    {
        return await context.Genres
            .FirstOrDefaultAsync(g => g.Code == code);
    }

    public async Task<Patient> AddAsync(Patient patient)
    {
        context.Patients.Add(patient);
        await context.SaveChangesAsync();
        return patient;
    }

    public async Task SaveChangesAsync()
    {
        await context.SaveChangesAsync();
    }
}
