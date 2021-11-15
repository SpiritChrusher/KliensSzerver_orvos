namespace KliensSzerver_orvos.Models;

public record Patient(
    [Required]
    string Name, 
    string Address, 
    [MaxLength(12)]
    string SSN,
    [Required]
    string Description);
