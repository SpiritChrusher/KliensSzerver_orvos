namespace KliensSzerver_orvos.Controllers;

[Route("/Patient")]
public class PatientController : Controller
{
    private IPatientRepository _patientRepository { get; }
    public PatientController(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    [HttpGet]
    [Route("/all")]
    public ActionResult<List<PatientDto>> GetPatients()
    {
        try
        {
            var patients = _patientRepository.ReadAllPatientsAsync();
            return Ok(patients);
        }
        catch (Exception)
        {

            throw;
        }
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult<PatientDto> GetPatient([FromRoute] long id)
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

    [HttpPost]
    [Route("")]
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

    [HttpPut]
    [Route("")]
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

    [HttpDelete]
    [Route("{id}")]
    public ActionResult DeletePatient([FromRoute] long Id)
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
