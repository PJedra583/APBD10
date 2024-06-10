using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Context;

public partial class WebAppContext : DbContext
{
    protected WebAppContext()
    {
        
    }

    public WebAppContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Medicament> Medicaments { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<Prescription_Medicament> Prescription_Medicaments { get; set; }
    public DbSet<Doctor> Doctors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Medicament>().HasData(new List<Medicament>()
        {
            new Medicament(1,"Apap","Na noc","Przeciwbólowy"),
            new Medicament(2,"Ibuprom","Forte","Przeciwbólowy"),
            new Medicament(3,"Zolpidem","Na sen","Psychotropowy")
        });
        modelBuilder.Entity<Prescription>().HasData(new List<Prescription>()
        {
            new Prescription(1,DateOnly.Parse("2023-12-02"),DateOnly.Parse("2024-12-02"),1,1),
            new Prescription(2,DateOnly.Parse("2003-02-22"),DateOnly.Parse("2004-12-02"),1,2),
            new Prescription(3,DateOnly.Parse("2001-11-01"),DateOnly.Parse("2004-12-02"),2,1)
        });
        modelBuilder.Entity<Patient>().HasData(new List<Patient>()
        {
            new Patient(1,"Jan","Kowalski",DateOnly.Parse("2002-12-02")),
            new Patient(2,"Adam","Kowalski",DateOnly.Parse("2004-12-02"))

        });
        modelBuilder.Entity<Doctor>().HasData(new List<Doctor>()
        {
            new Doctor(1,"Dr","House","drhouse@gmail.com"),
            new Doctor(2,"Stefan","Malinowski","stefcio@gmail.com")
        });
        modelBuilder.Entity<Prescription_Medicament>().HasData(new List<Prescription_Medicament>()
        {
            new Prescription_Medicament(1,1,10,"aaa"),
            new Prescription_Medicament(2,1,null,"aaa"),
            new Prescription_Medicament(3,2,null,"aaa"),
            new Prescription_Medicament(2,3,50,"shhh")
        });
    }
}