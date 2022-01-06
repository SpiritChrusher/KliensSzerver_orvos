using OrvosAsszisztens_kliens.Extensions;
using OrvosAsszisztens_kliens.Models;
using OrvosAsszisztens_kliens.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace OrvosAsszisztens_kliens.Pages;

public class EditPatientBase : ComponentBase
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
        Id = Id ?? "1";
        Patient = await PatientService.GetByIdAsync(long.Parse(Id));
    }

    protected async Task HandleValidSubmit()
    {
        if (!(Validation.IsValidName(Patient.Name) && Validation.IsValidSSN(Patient.SSN)))
            return;

        var result = await PatientService.UpdatePatientAsync(Patient);

        if (result is not null)
            NavigationManager.NavigateTo("/");
    }
}
