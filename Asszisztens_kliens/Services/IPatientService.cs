using Asszisztens_kliens.Models;
using System.Collections.Generic;

namespace Asszisztens_kliens.Services;

public interface IPatientService
{
    Task CreateAsync(PatientRequest patientRequest);
}
