using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.DTO_s;
using WebApplication1.Services;

namespace WebApplication1.Controlers;
[Route("api/[controller]")]
[ApiController]
public class Controller : ControllerBase
{
    private readonly IDbService _dbService;
    public Controller(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpPost("/api/prescription")]
    public async Task<IActionResult> addPrescription(AddPrescriptionDTO addPrescriptionDto)
    {
        if (!await _dbService.DoesPatientExist(addPrescriptionDto.Patient.IdPatient))
        {
            await _dbService.addPatient(addPrescriptionDto.Patient);
        }

        if (!await _dbService.doesMedicamentsExist(addPrescriptionDto.Medicaments))
        {
            return NotFound("Could not found given medicament!");
        }

        if (addPrescriptionDto.Medicaments.Count > 10)
        {
            return BadRequest("Too many medicaments");
        }

        if (addPrescriptionDto.Prescription.DueDate >= DateOnly.FromDateTime(DateTime.Now))
        {
            await _dbService.addPrescription(addPrescriptionDto.Prescription);
            return Ok();
        }
        else
        {
            return BadRequest("Prescription date has expired");
        }
    }

    [HttpGet("/api/{idPatient}")]
    public async Task<IActionResult> GetPatientData(int idPatient)
    {
        if (!await _dbService.DoesPatientExist(idPatient))
        {
            return NotFound("Patient not found");
        }
        
        return Ok(await _dbService.GetPatientInfo(idPatient));
    }
}