using System.Text.RegularExpressions;

namespace KliensSzerver_orvos_client.Extensions;

public static class Validation
{
    public static bool IsValidName(string? name) =>
        name.Equals(string.IsNullOrWhiteSpace) || name.Equals(string.Empty)
        || name.Any(s => !(char.IsLetter(s) || char.IsWhiteSpace(s))) ? false : true;

    public static bool IsValidSSN(string ssn) =>
        Regex.IsMatch(ssn, "^[0-9]{3} [0-9]{3} [0-9]{3}$");
}
