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
    public async Task<ActionResult<PatientRequest>> GetPatient([FromRoute] long id)
    {
        try
        {
            var result = await _patientRepository.ReadPatientAsync(id);
            return Ok(result);
        }
        catch (Exception)
        {

            throw;
        }
    }

    [HttpPost]
    [Route("")]
    public async Task<ActionResult> CreatePatient([FromBody] PatientRequest patientRequest)
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
    public async Task<ActionResult> UpdatePatient([FromBody] PatientDto updatedPatient)
    {
        try
        {
            await _patientRepository.UpdatePatientAsync(updatedPatient);
            return Ok();
        }
        catch (Exception)
        {

            throw;
        }
    }

    [HttpDelete]
    [Route("")]
    public async Task<ActionResult> DeletePatient()
    {
        try
        {
            await _patientRepository.DeleteAllPatientsAsync();
            return NoContent();
        }
        catch (Exception)
        {

            return Conflict();
        }

    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult> DeletePatient([FromRoute] long Id)
    {
        try
        {
            await _patientRepository.DeletePatientAsync(Id);
            return NoContent();
        }
        catch (Exception)
        {

            return Conflict();
        }

    }
}
