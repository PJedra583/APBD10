using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models;

public class Patient
{
    public Patient(int idPatient, string firstname, string lastname, DateOnly birthdate)
    {
        IdPatient = idPatient;
        Firstname = firstname;
        Lastname = lastname;
        Birthdate = birthdate;
    }

    [Key]
    public int IdPatient { get; set; }
    [Required]
    [MaxLength(100)]
    public String Firstname { get; set; }
    [Required]
    [MaxLength(100)]
    public String Lastname { get; set; }
    [Required]
    public DateOnly Birthdate { get; set; }
    
}