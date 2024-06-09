using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models;

[PrimaryKey(nameof(IdMedicament),nameof(IdPrescription))]
public class Prescription_Medicament
{
    public Prescription_Medicament(int idMedicament, int idPrescription, int? dose, string details)
    {
        IdMedicament = idMedicament;
        IdPrescription = idPrescription;
        Dose = dose;
        Details = details;
    }

    [Required]
    public int IdMedicament { get; set; }
    [Required]
    public int IdPrescription { get; set; }
    public int? Dose { get; set; }
    [MaxLength(100)]
    public String Details { get; set; }
}