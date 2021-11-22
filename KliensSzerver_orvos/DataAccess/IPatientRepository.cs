namespace KliensSzerver_orvos.DataAccess;

public interface IPatientRepository
{
    Task StorePatientAsync(PatientDto patient);
    List<Patient> ReadAllPatientsAsync();
    Patient ReadPatientAsync(long id);
    Task UpdatePatientAsync(PatientDto patient);
    Task DeletePatientAsync(long id);
    Task DeleteAllPatientsAsync();
}
