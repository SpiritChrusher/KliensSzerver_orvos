namespace KliensSzerver_orvos.DataAccess;

public class PatientRepository : IPatientRepository
{
    private readonly PatientContext _context;

    public PatientRepository(PatientContext context)
    {
        _context = context;
    }


    public List<PatientDto> ReadAllPatientsAsync()
    {
        var patients = _context.Patients.ToList();
        return patients;
    }

    public async Task<PatientDto> ReadPatientAsync(long id)
    {
        var patient = await _context.Patients.Where(x => x.Id == id).FirstOrDefaultAsync();
        return patient;
    }

    public async Task StorePatientAsync(PatientRequest patientRequest)
    {
        try
        {
            var maxId = _context.Patients.Max(x => x.Id);

            await _context.AddAsync(patientRequest.ToPatientDto(maxId+1));                   
            await _context.SaveChangesAsync();
        }
        catch (InvalidOperationException)
        {
            await _context.AddAsync(patientRequest.ToPatientDto(1));
            await _context.SaveChangesAsync();
        }
    }

    public async Task UpdatePatientAsync(PatientDto updatedPatient)
    {
        _context.Update(updatedPatient);
        await _context.SaveChangesAsync();
    }
    public async Task DeleteAllPatientsAsync()
    {
        var patients = _context.Patients.ToList();
        _context.RemoveRange(patients);
        await _context.SaveChangesAsync();
    }

    public async Task DeletePatientAsync(long id)
    {
        try
        {
            var patient = await _context.Patients.FirstOrDefaultAsync(x => x.Id == id);
            _context.Remove(patient);
            await _context.SaveChangesAsync();
        }
        catch (InvalidOperationException)
        {
            throw new BadRequestException();
        }
    }
}
