using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Assistant_client.Extensions;

public static class Validator
{
    public static bool IsValidName(string name) =>
        name.Equals(String.IsNullOrEmpty) || name.Equals(String.Empty)
        || name.Any(s => ! Char.IsLetter(s)) ? false : true;

    public static bool IsValidSSN(string ssn) => 
        Regex.IsMatch(ssn, "^[0-9]{3} [0-9]{3} [0-9]{3}$");
    
}