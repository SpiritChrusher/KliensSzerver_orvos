namespace KliensSzerver_orvos.Controllers;

[Route("Patient")]
public class PatientController : Controller
{
    private IPatientRepository _patientRepository { get; }
    public PatientController(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    [Route("")]
    [HttpGet]
    public ActionResult<PatientDto> GetPatient()
    {
        return Ok(new PatientDto("a", "b", "c", "d"));
    }

    [Route("")]
    [HttpPost]
    public ActionResult CreatePatient([FromBody] PatientDto patientRequest)
    {
        return StatusCode(StatusCodes.Status201Created);
    }
}
