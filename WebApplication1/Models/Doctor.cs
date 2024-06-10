using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class Doctor
{
    public Doctor(int idDoctor, string firstName, string lastName, string email)
    {
        IdDoctor = idDoctor;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }

    [Key]
    public int IdDoctor { get; set; }
    [Required]
    [MaxLength(100)]
    public String FirstName { get; set; }
    [Required]
    [MaxLength(100)]
    public String LastName { get; set; }
    [Required]
    [MaxLength(100)]
    public String Email { get; set; }
    public ICollection<Prescription> Prescriptions { get; set; }
}