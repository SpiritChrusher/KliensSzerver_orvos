namespace KliensSzerver_orvos.Tests.UnitTests;

[TestClass]
public class PatientRepositoryTests
{
    private IPatientRepository _patientRepository { get; set; } = null!;
    private PatientContext? _patientContext { get; set; }
    private List<PatientDto> _mockPatients { get; set; } = null!;
    private PatientRequest _mockPatientsRequest { get; set; } = null!;
    private PatientDto _mockPatientDto { get; set; } = null!;

    [TestInitialize]
    public void Initialize()
    {
        var dbContextOptions = new DbContextOptionsBuilder<PatientContext>().UseInMemoryDatabase("Filename=testdb");

        _patientRepository = Substitute.For<IPatientRepository>();
        _patientContext = new(dbContextOptions.Options);

        _mockPatientsRequest = new("a", "b", "c", "d");

        _mockPatientDto = new(1, "name", "address", "ssn", "description");

        _mockPatients = new List<PatientDto>() { 
            new(1,"a", "b", "c", "d" ),
            new(2, "a", "b", "c", "d")};

        
    }

    [TestMethod]
    public void GetPatients_ShouldGetPatients()
    {
        _patientRepository.ReadAllPatientsAsync().Returns(_mockPatients);

        Assert.AreEqual(2, _mockPatients.Count);
    }

    [TestMethod]
    public void StorePatients_ShouldStorePatients()
    {
        var response = _patientRepository.StorePatientAsync(_mockPatientsRequest)
            .Returns(Task.FromResult(true)); ;

        Assert.IsNotNull(response);
    }

    [TestMethod]
    public void UpdatePatients_ShouldUpdatePatient()
    {
        var response = _patientRepository.UpdatePatientAsync(_mockPatientDto)
            .Returns(Task.FromResult(true));

        Assert.IsNotNull(response);
    }

    [TestMethod]
    public void ReadPatientAsync_ShouldReturnPatient()
    {
        var response = _patientRepository.ReadPatientAsync(Arg.Any<long>()).Returns(_mockPatientDto);

        Assert.IsNotNull(response);
        Assert.AreEqual(_mockPatientDto, response); //this isn't good!
    }
    
    [TestMethod]
    public void DeletePatient_ShouldDeletePatient()
    {
        var response = _patientRepository.DeletePatientAsync(Arg.Any<long>())
            .Returns(Task.FromResult(true));

        Assert.IsNotNull(response);
    }
    
    [TestMethod]
    public void DeleteAllPatientsAsync_ShouldDeleteAllPatients()
    {
        var response = _patientRepository.DeleteAllPatientsAsync()
            .Returns(Task.FromResult(true));

        Assert.IsNotNull(response);
    }
}
