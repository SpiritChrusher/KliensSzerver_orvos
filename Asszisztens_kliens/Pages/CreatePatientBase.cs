using Asszisztens_kliens.Extensions;
using Asszisztens_kliens.Models;
using Asszisztens_kliens.Services;
using Microsoft.AspNetCore.Components;

namespace Asszisztens_kliens.Pages;

public class CreatePatientBase : ComponentBase
{
    public PatientDto Patient { get; set; } = new PatientDto();

    [Inject]
    public IPatientService PatientService { get; set; }

    [Parameter]
    public string Id { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    protected async override Task OnInitializedAsync()
    {
    }

    protected async Task HandleValidSubmit()
    {
        var (_, name, address, ssn, description) = Patient;

        PatientRequest PatientRequest = new(name, address, ssn, description);

        if (!(Validation.IsValidName(name) && Validation.IsValidSSN(ssn)) || string.IsNullOrWhiteSpace(description))
            return;

        await PatientService.CreateAsync(PatientRequest);
        Patient = new();

    }
}
