namespace KliensSzerver_orvos.DataAccess;

public class PatientRepository : IPatientRepository
{


    public PatientRepository()
    {

    }

    public Task DeleteAllPatientsAsync()
    {
        throw new NotImplementedException();
    }

    public Task DeletePatientAsync(long Id)
    {
        throw new NotImplementedException();
    }

    public Task ReadAllPatientsAsync()
    {
        throw new NotImplementedException();
    }

    public Task ReadPatientAsync(long Id)
    {
        throw new NotImplementedException();
    }

    public Task StorePatientAsync(PatientDto patient)
    {
        throw new NotImplementedException();
    }

    public Task UpdatePatientAsync(PatientDto patient)
    {
        throw new NotImplementedException();
    }
}
