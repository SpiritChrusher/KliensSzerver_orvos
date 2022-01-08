namespace Asszisztens_kliens.Services;

public interface IPatientService
{
    Task CreateAsync(PatientRequest patientRequest);
}
