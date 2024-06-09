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
            new Prescription(1,DateOnly.Parse("2023-12-02"),DateOnly.Parse("2024-12-02"),1,1)
        });
        modelBuilder.Entity<Patient>().HasData(new List<Patient>()
        {
            new Patient(1,"Jan","Kowalski",DateOnly.Parse("2002-12-02"))
        });
        modelBuilder.Entity<Doctor>().HasData(new List<Doctor>()
        {
            new Doctor(1,"Dr","House","drhouse@gmail.com")
        });
        modelBuilder.Entity<Prescription_Medicament>().HasData(new List<Prescription_Medicament>()
        {
            new Prescription_Medicament(1,1,10,"aaa")
        });
    }
}