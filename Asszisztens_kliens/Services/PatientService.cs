namespace Asszisztens_kliens.Services;

public class PatientService : IPatientService
{
    private readonly HttpClient _httpClient;

    public PatientService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task CreateAsync(PatientRequest patientRequest)
    {
        await _httpClient.PostAsJsonAsync<PatientRequest>("patients", patientRequest);
    }
}
