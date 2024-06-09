using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

public class Prescription
{
    public Prescription(int idPrescription, DateOnly date, DateOnly dueDate, int idPatient, int idDoctor)
    {
        IdPrescription = idPrescription;
        Date = date;
        DueDate = dueDate;
        IdPatient = idPatient;
        IdDoctor = idDoctor;
    }

    [Key]
    public int IdPrescription { get; set; }
    [Required]
    public DateOnly Date { get; set; }
    [Required]
    public DateOnly DueDate { get; set; }
    [Required]
    public int IdPatient { get; set; }
    [Required]
    public int IdDoctor { get; set; }
    [ForeignKey(nameof(IdPatient))]
    public Patient Patient { get; set; } = null!;
    [ForeignKey(nameof(IdDoctor))]
    public Doctor Doctor { get; set; } = null!;

    public ICollection<Prescription_Medicament> Prescription_Medicaments { get; set; } =
        new List<Prescription_Medicament>();
}