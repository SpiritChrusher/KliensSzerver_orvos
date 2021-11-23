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
        if (Validator.ValidateLong(id))
            return BadRequest("bad patient data!!!");

        try
        {
            var result = await _patientRepository.ReadPatientAsync(id);
            return Ok(result);
        }
        catch (Exception)
        {

            return BadRequest();
        }
    }

    [HttpPost]
    [Route("")]
    public async Task<ActionResult> CreatePatient([FromBody] PatientRequest patientRequest)
    {
        if (Validator.IsPatientRequestBad(patientRequest))
            return BadRequest("bad patient data!!!");

        try
        {
            await _patientRepository.StorePatientAsync(patientRequest);
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
        if (Validator.IsPatientDtoBad(updatedPatient))
            return BadRequest("bad patient data!!!");

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
    public async Task<ActionResult> DeletePatient([FromRoute] long id)
    {
        if (Validator.ValidateLong(id))
            return BadRequest();

        try
        {
            await _patientRepository.DeletePatientAsync(id);
            return NoContent();
        }
        catch (InvalidOperationException e)
        {
            return BadRequest(e.Message);
        }
        catch (Exception)
        {

            return Conflict();
        }

    }
}
