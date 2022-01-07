using Orvos_kliens.Models;
using System.Collections.Generic;

namespace Orvos_kliens.Services;

public class PatientService : IPatientService
{
    private readonly HttpClient _httpClient;

    public PatientService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<PatientDto>> GetAsync()
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<PatientDto>>("patients");
        }
        catch (Exception)
        {
            return new List<PatientDto>();
        }
    }

    public async Task<PatientDto> GetByIdAsync(long id)
    {
        return await _httpClient.GetFromJsonAsync<PatientDto>($"patients/{id}");
    }

    public async Task<PatientDto> UpdatePatientAsync(PatientDto patient)
    {
        try
        {
            await _httpClient.PutAsJsonAsync<PatientDto>("patients", patient);

            return patient;
        }
        catch (Exception)
        {
            return null;
        }
    }

    public async Task DeletePatientByIdAsync(long id)
    {
        await _httpClient.DeleteAsync($"patients/{id}");
    }

    public async Task DeletePatientsAsync()
    {
        await _httpClient.DeleteAsync("patients");
    }
}
