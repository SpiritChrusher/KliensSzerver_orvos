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
    public ActionResult<Patient> Index()
    {
        return Ok(new Patient("a", "b", "c", "d"));
    }
}
