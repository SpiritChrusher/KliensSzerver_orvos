namespace KliensSzerver_orvos.Models;

public class PatientContext : DbContext
{
    public DbSet<Patient> Patients { get; set; }

    public PatientContext([NotNullAttribute] DbContextOptions options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Patient>();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer();
    }
}
