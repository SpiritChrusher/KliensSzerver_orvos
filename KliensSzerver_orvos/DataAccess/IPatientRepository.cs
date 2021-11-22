namespace KliensSzerver_orvos.DataAccess;

public interface IPatientRepository
{
    Task StorePatientAsync(PatientRequest patient);
    List<PatientDto> ReadAllPatientsAsync();
    Task<PatientDto> ReadPatientAsync(long id);
    Task UpdatePatientAsync(PatientDto updatedPatient);
    Task DeletePatientAsync(long id);
    Task DeleteAllPatientsAsync();
}
