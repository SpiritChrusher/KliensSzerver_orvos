namespace Asszisztens_kliens.Pages;

public class CreatePatientBase : ComponentBase
{
    public PatientDto Patient { get; set; } = new PatientDto();

    [Inject]
    public IPatientService PatientService { get; set; }

    [Parameter]
    public string Id { get; set; }

    public string Information { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    protected async override Task OnInitializedAsync()
    {
    }

    protected async Task HandleValidSubmit()
    {
        var (_, name, address, ssn, description) = Patient;

        PatientRequest PatientRequest = new(name, address, ssn, description);

        if (!(Validation.IsValidName(name) && Validation.IsValidSSN(ssn))
            || string.IsNullOrWhiteSpace(description))
        {
            Information = "Some information is incorrect";
            return;
        }

        await PatientService.CreateAsync(PatientRequest);
        Information = "Patient is created";
        Patient = new();
    }
}
