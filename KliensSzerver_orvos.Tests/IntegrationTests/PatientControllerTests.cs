using Microsoft.AspNetCore.Mvc;

namespace KliensSzerver_orvos.Tests.IntegrationTests;

[TestClass]
public class PatientControllerTests
{
    private PatientController _PatientController { get; set; } = null!;
    private IPatientRepository _mockPatientRepository { get; set; } = null!;
    private PatientContext? _patientContext { get; set; }
    private List<PatientDto> _mockPatients { get; set; } = null!;
    private PatientRequest _mockPatientsRequest { get; set; } = null!;
    private PatientDto _mockPatientDto { get; set; } = null!;

    [TestInitialize]
    public void Initialize()
    {
        _PatientController.ControllerContext = new();
        _mockPatientRepository = Substitute.For<IPatientRepository>();
        _PatientController = new(_mockPatientRepository);
        
        _mockPatientsRequest = new("a", "b", "c", "d");

        _mockPatientDto = new(1, "name", "address", "ssn", "description");

        _mockPatients = new List<PatientDto>() { 
            new(1,"a", "b", "c", "d" ),
            new(2, "a", "b", "c", "d")};

        
    }
    
    [TestMethod]
    public async Task ReadPatientAsync()
    {
        _mockPatientRepository.ReadPatientAsync(Arg.Any<long>()).Returns(_mockPatientDto);

        var response = await _PatientController.GetPatient(Arg.Any<long>());
        
        Assert.IsNotNull(response);
        Assert.AreEqual(_mockPatientDto, response);
    }
}