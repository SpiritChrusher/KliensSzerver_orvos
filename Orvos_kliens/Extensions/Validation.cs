namespace Orvos_kliens.Extensions;

public static class Validation
{
    public static bool IsValidName(string? name) =>
        !name.Equals(string.Empty) && !name.All(s => char.IsWhiteSpace(s))
     && name.All(s => char.IsLetter(s) || char.IsSeparator(s));

    public static bool IsValidSSN(string ssn) =>
        Regex.IsMatch(ssn, "^[0-9]{3} [0-9]{3} [0-9]{3}$");
}