namespace KliensSzerver_orvos.Tests.UnitTests;


[TestClass]
public class RepositoryTests
{
    private PatientController _patientController { get; set; } = null!;
    private Mock<IPatientRepository> _patientRepository { get; set; } = null!;
    private List<PatientDto> _patients { get; set; } = null!;
    private PatientRequest _patientsRequest { get; set; } = null!;


    [TestInitialize]
    public void Initialize()
    {
        _patientRepository = new Mock<IPatientRepository>();

        _patientController = new PatientController(_patientRepository.Object);

        _patients = new List<PatientDto>() { 
            new(3,"a", "b", "c", "d" ),
            new(4, "a", "b", "c", "d")};

        _patientsRequest = new("a", "b", "c", "d");
        
    }
    // It's integration test, not unit test.
    [TestMethod]
    public void GetPatients_ShouldGetPatients()
    {
        _patientRepository.Setup(p => p.ReadAllPatientsAsync()).Returns(_patients);

        var response = _patientController.GetPatients();

        Assert.IsNotNull(response);

        var result = response.Result as OkObjectResult;

        Assert.AreEqual(200, result.StatusCode);
    }

    [TestMethod]
    public void CreatePatients_ShouldCreatePatients()
    {
        _patientRepository.Setup(p => p.ReadAllPatientsAsync()).Returns(_patients);

        Assert.AreEqual(2, _patients.Count);
    }
}