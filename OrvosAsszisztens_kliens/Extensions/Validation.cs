﻿using System.Text.RegularExpressions;

namespace OrvosAsszisztens_kliens.Extensions;

public static class Validation
{
    //TODO: something is not right
    public static bool IsValidName(string? name) =>
        Regex.IsMatch(name, "^[a-zA-Z]+[ |-]?[a-zA-Z]+[ |-]?[a-zA-Z]+$");
    // name.Equals(string.IsNullOrWhiteSpace) || name.Equals(string.Empty)
    //|| name.Any(s => char.IsLetter(s) || char.IsWhiteSpace(s)) ? false : true;

    public static bool IsValidSSN(string ssn) =>
        Regex.IsMatch(ssn, "^[0-9]{3} [0-9]{3} [0-9]{3}$");
}