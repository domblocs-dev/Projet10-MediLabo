using System.Net;
using MediLabo.Front.Models;

namespace MediLabo.Front.Clients;

public class PatientsClient(HttpClient httpClient)
{
    public async Task<List<PatientDto>> GetAllAsync()
    {
        return await httpClient.GetFromJsonAsync<List<PatientDto>>("api/patients") ?? [];
    }

    // Patient absent (404) : on rend null, et la page affichera un message,
    // au lieu de l'erreur 500 que donnerait GetFromJsonAsync (exception sur le 404).
    // Les autres erreurs (500, 502) restent des exceptions : une panne
    // ne doit pas passer pour un patient absent.
    public async Task<PatientDto?> GetByIdAsync(int id)
    {
        using HttpResponseMessage response = await httpClient.GetAsync($"api/patients/{id}");

        if (response.StatusCode == HttpStatusCode.NotFound)
        {
            return null;
        }

        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<PatientDto>();
    }
}
