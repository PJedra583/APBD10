namespace WebApplication1.Models.DTO_s;

public class GetPatientInfo
{
    public Patient Patient { get; set; }
    public List<Prescription> Prescription { get; set; }
}