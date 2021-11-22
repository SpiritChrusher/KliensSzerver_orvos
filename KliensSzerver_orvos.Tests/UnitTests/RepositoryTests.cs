namespace KliensSzerver_orvos.Tests.UnitTests;

[TestClass]
public class RepositoryTests
{
    private IPatientRepository _patientRepository { get; set; } = null!;
    private List<PatientDto> _patients { get; set; } = null!;
    private PatientRequest _patientsRequest { get; set; } = null!;
    private PatientContext _patientContext { get; set; } = null;

    [TestInitialize]
    public void Initialize()
    {
        _patientRepository = Substitute.For<IPatientRepository>();
        _patientContext = Substitute.For<PatientContext>(Arg.Any<DbContextOptions>());

        _patients = new List<PatientDto>() { 
            new(1,"a", "b", "c", "d" ),
            new(2, "a", "b", "c", "d")};

        _patientsRequest = new("a", "b", "c", "d");
        
    }

    [TestMethod]
    public void GetPatients_ShouldGetPatients()
    {
        _patientRepository.ReadAllPatientsAsync().Returns(_patients);

        Assert.AreEqual(2, _patients.Count);
    }
}
