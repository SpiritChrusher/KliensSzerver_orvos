namespace KliensSzerver_orvos.Extensions;

public static class Validator
{
    public static bool IsPatientRequestBad(PatientRequest request)
    {
        return request.Name.Equals(string.Empty) || request.Address.Equals(string.Empty)
            || request.SSN.Equals(string.Empty) || request.Description.Equals(string.Empty)
            || string.IsNullOrWhiteSpace(request.Name) || string.IsNullOrWhiteSpace(request.SSN)
            || string.IsNullOrWhiteSpace(request.Description) || request.SSN.Length > 12;
    }

    public static bool IsPatientDtoBad(PatientDto request)
    {
        return request.Id <= 0 || request.Name.Equals(string.Empty) || request.Address.Equals(string.Empty)
            || request.SSN.Equals(string.Empty) || request.Description.Equals(string.Empty) 
            || string.IsNullOrWhiteSpace(request.Name) || string.IsNullOrWhiteSpace(request.SSN) 
            || string.IsNullOrWhiteSpace(request.Description) || request.SSN.Length > 12;
    }

    public static bool ValidateLong(long id) => id <= 0;
}
