using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Context;
using WebApplication1.Models;

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
}