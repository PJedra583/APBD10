using WebApplication1.Services;

namespace WebApplication1.Models.DTO_s;

public class GetPatientInfo
{
    public int IdPatient { get; set; }
    public String FirstName { get; set; }
    public String LastName { get; set; }
    public DateOnly Birthdate { get; set; }
    public List<GetPrescriptionInfo> Prescriptions { get; set; } = new List<GetPrescriptionInfo>();

}

public class GetPrescriptionInfo
{
    public int IdPrescription { get; set; }
    public DateOnly Date { get; set; }
    public DateOnly DueDate { get; set; }
    public List<Medicament> Medicaments { get; set; } = new List<Medicament>();
    public GetDoctorInfo? Doctor { get; set; }
}

public class GetDoctorInfo
{
    public int IdDoctor { get; set; }
    public String FirstName { get; set; }
}