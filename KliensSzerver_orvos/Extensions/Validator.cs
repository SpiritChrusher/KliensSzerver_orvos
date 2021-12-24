namespace KliensSzerver_orvos.Extensions;

public static class Validator
{
    public static bool IsPatientRequestBad(PatientRequest request)
    {
        if (request.Name.Equals(string.Empty) || request.Address.Equals(string.Empty)
            || request.SSN.Equals(string.Empty) || request.Description.Equals(string.Empty)
            || request.Name.Equals(string.IsNullOrWhiteSpace) || request.Address.Equals(string.IsNullOrWhiteSpace)
            || request.SSN.Equals(string.IsNullOrWhiteSpace) || request.Description.Equals(string.IsNullOrWhiteSpace)
            || request.SSN.Length > 12)
            return true;

        return false;
    }

    public static bool IsPatientDtoBad(PatientDto request)
    {
        if (request.Id <= 0 || request.Name.Equals(string.Empty) || request.Address.Equals(string.Empty)
            || request.SSN.Equals(string.Empty) || request.Description.Equals(string.Empty) 
            || request.Name.Equals(string.IsNullOrWhiteSpace) || request.Address.Equals(string.IsNullOrWhiteSpace)
            || request.SSN.Equals(string.IsNullOrWhiteSpace) || request.Description.Equals(string.IsNullOrWhiteSpace)
            || request.SSN.Length > 12)
            return true;

        return false;
    }

    public static bool ValidateLong(long id) => id > 0 ? false : true;

    /* TODO: - Név
    - Validáció
        - Nem lehet: üres, whitespace, különleges karakterek szűrése pl !?_-:;#
    - UNIT teszt a validáló fv-re
- Lakcím
- Tajszám `Formátum: 000 000 000`
    - Validáció
        - Formátumra és hogy csak számokat tartalmaz */
}
