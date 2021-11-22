namespace KliensSzerver_orvos.Models;

public record PatientDto(
    [Required]
    string Name,
    string Address,
    [MaxLength(12)]
    string SSN,
    [Required]
    string Description);

public class Patient
{
    [Key]
    public long Id { get; set; }
    [Required(ErrorMessage = $"{nameof(Name)} is required!")]
    public string Name { get; set; }
    public string Address { get; set; }
    [MaxLength(12)]
    public string SSN { get; set; }
    [Required(ErrorMessage = $"{nameof(Description)} is required!")]
    public string Description { get; set; }

    public Patient() { }

    public Patient(long id, string name, string address, string sSN, string description)
    {
        Id = id;
        Name = name;
        Address = address;
        SSN = sSN;
        Description = description;
    }
}
