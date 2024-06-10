using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using WebApplication1.Context;
using WebApplication1.Models;
using WebApplication1.Models.DTO_s;

namespace WebApplication1.Services;

public class DbService : IDbService
{
    private readonly WebAppContext _context;
    public DbService(WebAppContext webAppContext)
    {
        _context = webAppContext;
    }
    public async Task<bool> DoesPatientExist(int patientId)
    {
        return await _context.Patients.AnyAsync(p => p.IdPatient == patientId);
    }

    public async Task addPatient(Patient patient)
    {
        await _context.Patients.AddAsync(patient);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> doesMedicamentsExist(List<Medicament> medicaments)
    {
        foreach (var VARIABLE in medicaments)
        {
            if (!await _context.Medicaments.AnyAsync(e => e.IdMedicament == VARIABLE.IdMedicament))
            {
                return false;
            }
        }
        return true;
    }

    public async Task addPrescription(Prescription prescription)
    {
        await _context.Prescriptions.AddAsync(prescription);
        await _context.SaveChangesAsync();
    }

    public async Task<GetPatientInfo> GetPatientInfo(int idPatient)
    {
        GetPatientInfo returnPatient = new GetPatientInfo();
        var patient = await _context.Patients.FirstOrDefaultAsync(e=> e.IdPatient == idPatient);
        returnPatient.IdPatient = patient.IdPatient;
        returnPatient.FirstName = patient.Firstname;
        returnPatient.LastName = patient.Lastname;
        returnPatient.Birthdate = patient.Birthdate;
        var prescriptions = await _context.Prescriptions
            .Where(e => e.IdPatient == idPatient)
            .OrderBy(e => e.DueDate)
            .ToListAsync();

        returnPatient.Prescriptions = prescriptions.Select(e => new GetPrescriptionInfo()
        {
            IdPrescription = e.IdPrescription,
            Date = e.Date,
            DueDate = e.DueDate,
            Medicaments = _context.Prescription_Medicaments
                .Where(pm => pm.IdPrescription == e.IdPrescription)
                .Select(pm => pm.Medicament)
                .ToList(),
            Doctor = _context.Prescriptions
                .Where(p => p.IdPrescription == e.IdPrescription)
                .Select(e3 => new GetDoctorInfo()
                {
                    FirstName = e3.Doctor.FirstName,
                    IdDoctor = e3.IdDoctor
                })
                .FirstOrDefault()
        }).ToList();

        return returnPatient; 
    }
}