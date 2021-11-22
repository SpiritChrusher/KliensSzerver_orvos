namespace KliensSzerver_orvos.Controllers;

[Route("Patient")]
public class PatientController : Controller
{
    private IPatientRepository _patientRepository { get; }
    public PatientController(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    [Route("/all")]
    [HttpGet]
    public ActionResult<PatientDto> GetPatients()
    {
        try
        {
            _patientRepository.ReadAllPatientsAsync();
            return Ok(new PatientDto("a", "b", "c", "d"));
        }
        catch (Exception)
        {

            throw;
        }
    }

    [Route("")]
    [HttpGet]
    public ActionResult<PatientDto> GetPatient([FromBody] long id)
    {
        try
        {
            _patientRepository.ReadPatientAsync(id);
            return Ok(new PatientDto("a", "b", "c", "d"));
        }
        catch (Exception)
        {

            throw;
        }
    }

    [Route("")]
    [HttpPost]
    public ActionResult CreatePatient([FromBody] PatientDto patientRequest)
    {
        try
        {
            _patientRepository.StorePatientAsync(patientRequest);
            return StatusCode(StatusCodes.Status201Created);
        }
        catch (Exception)
        {
            throw;
        }
    }

    [Route("")]
    [HttpPut]
    public ActionResult UpdatePatient([FromBody] PatientDto updatedPatient)
    {
        try
        {
            _patientRepository.UpdatePatientAsync(updatedPatient);
            return Ok();
        }
        catch (Exception)
        {

            throw;
        }
    }

    [Route("")]
    [HttpDelete]
    public ActionResult DeletePatient([FromBody] long Id)
    {
        try
        {
            _patientRepository.DeletePatientAsync(Id);
            return NoContent();
        }
        catch (Exception)
        {

            return Conflict();
        }

    }
}
