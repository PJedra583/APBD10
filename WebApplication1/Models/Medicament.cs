using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models;

public class Medicament
{
    public Medicament(int idMedicament, string name, string description, string type)
    {
        IdMedicament = idMedicament;
        Name = name;
        Description = description;
        Type = type;
    }

    [Key]
    public int IdMedicament { get; set; }
    [MaxLength(100)]
    [Required]
    public String Name{ get; set; }
    [MaxLength(100)]
    [Required]
    public String Description{ get; set; }
    [MaxLength(100)]
    [Required]
    public String Type{ get; set; }
    
}