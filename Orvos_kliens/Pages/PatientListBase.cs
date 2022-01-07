using Orvos_kliens.Models;
using Orvos_kliens.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http.Extensions;

namespace Orvos_kliens.Pages;

public class PatientListBase : ComponentBase
{
    [Inject]
    public IPatientService PatientService { get; set; }
    public IEnumerable<PatientDto> Patients { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Patients = await PatientService.GetAsync();
    }

    protected async Task DeleteAllPatients()
    {
        await PatientService.DeletePatientsAsync();

        Patients = await PatientService.GetAsync();
    }
}
