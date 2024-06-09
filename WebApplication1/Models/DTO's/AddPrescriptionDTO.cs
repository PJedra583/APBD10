namespace WebApplication1.Models.DTO_s;

public class AddPrescriptionDTO
{
    public Patient Patient { get; set; }
    public Prescription Prescription { get; set; }
    public List<Medicament> Medicaments { get; set; }
}