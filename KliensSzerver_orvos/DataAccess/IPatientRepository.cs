namespace KliensSzerver_orvos.DataAccess;

public interface IPatientRepository
{
    Task StorePatientAsync(PatientDto patient);
    Task ReadAllPatientsAsync();
    Task ReadPatientAsync(long Id);
    Task UpdatePatientAsync(PatientDto patient);
    Task DeletePatientAsync(long Id);
    Task DeleteAllPatientsAsync();
}
