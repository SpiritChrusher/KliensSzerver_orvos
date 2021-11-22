namespace KliensSzerver_orvos.DataAccess;

public class PatientRepository : IPatientRepository
{
    private PatientContext _context { get; set; }

    public PatientRepository(PatientContext context)
    {
        _context = context;
    }


    public List<Patient> ReadAllPatientsAsync()
    {
        try
        {
            var patients = _context.Patients.ToList();
            return patients;

        }
        catch (Exception)
        {

            throw;
        }       
    }

    public Patient ReadPatientAsync(long id)
    {
        try
        {
            var patient = _context.Patients.Where(x => x.Id == id).FirstOrDefault();
            return patient;
        }
        catch (Exception)
        {

            throw;
        }
    }

    public Task StorePatientAsync(PatientDto patient)
    {
        throw new NotImplementedException();
    }

    public Task UpdatePatientAsync(PatientDto patient)
    {
        throw new NotImplementedException();
    }
    public Task DeleteAllPatientsAsync()
    {       
        throw new NotImplementedException();
    }

    public Task DeletePatientAsync(long id)
    {
        throw new NotImplementedException();
    }
}
