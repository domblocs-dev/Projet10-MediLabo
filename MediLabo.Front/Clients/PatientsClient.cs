using MediLabo.Front.Models;

namespace MediLabo.Front.Clients;

public class PatientsClient(HttpClient httpClient)
{
    public async Task<List<PatientDto>> GetAllAsync()
    {
        return await httpClient.GetFromJsonAsync<List<PatientDto>>("api/patients") ?? [];
    }
}