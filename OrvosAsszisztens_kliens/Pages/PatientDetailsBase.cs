using OrvosAsszisztens_kliens.Models;
using OrvosAsszisztens_kliens.Services;
using Microsoft.AspNetCore.Components;

namespace OrvosAsszisztens_kliens.Pages;

public class PatientDetailsBase : ComponentBase
{
    public PatientDto Patient { get; set; } = new PatientDto();

    [Inject]
    public IPatientService PatientService { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Parameter]
    public string Id { get; set; }

    protected async override Task OnInitializedAsync()
    {
        Id = Id ?? "1";
        Patient = await PatientService.GetByIdAsync(long.Parse(Id));
    }


    protected async Task DeletePatient()
    {
        await PatientService.DeletePatientByIdAsync(long.Parse(Id));

        NavigationManager.NavigateTo("/");
    }

}
