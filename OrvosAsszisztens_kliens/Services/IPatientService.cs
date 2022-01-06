using OrvosAsszisztens_kliens.Models;
using System.Collections.Generic;

namespace OrvosAsszisztens_kliens.Services;

public interface IPatientService
{
    Task<IEnumerable<PatientDto>> GetAsync();
    Task<PatientDto> GetByIdAsync(long id);
    Task<PatientDto> UpdatePatientAsync(PatientDto patient);
    Task DeletePatientByIdAsync(long id);
    Task DeletePatientsAsync();

}
