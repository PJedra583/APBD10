using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.DTO_s;

namespace WebApplication1.Services;

public interface IDbService
{
    Task<Boolean> DoesPatientExist(int patientId);
    Task addPatient(Patient patient);
    Task<bool> doesMedicamentsExist(List<Medicament> medicaments);
    Task addPrescription(Prescription prescription);
    Task<GetPatientInfo> GetPatientInfo(int idPatient);

}