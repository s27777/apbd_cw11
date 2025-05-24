using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Tutorial5.DTOs;
using Tutorial5.Models;
using Tutorial5.Services;

namespace Tutorial5.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PrescriptionController : ControllerBase
{
    private readonly IDbService _dbService;
    
    public PrescriptionController(IDbService dbService)
    {
        _dbService = dbService;
    }


    [HttpGet]
    public async Task<IActionResult> GetPrescriptions(int id)
    {
        var res = _dbService.GetPrescription(id);
        return Ok(res);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreatePrescription([FromBody] PrescriptionDTO prescriptionDto)
    {
        if (prescriptionDto == null || prescriptionDto.Medicaments == null || !prescriptionDto.Medicaments.Any())
        {
            return BadRequest("Prescription or medicament not found");
        }

        try
        {
            var prescription = new Prescription();
            prescription.IdPatient = prescriptionDto.IdPatient;
            prescription.IdDoctor = prescriptionDto.IdDoctor;
            prescription.Date = prescriptionDto.Date;
            prescription.DueDate = prescriptionDto.DueDate;

            var medicaments = new List<Prescription_Medicament>();
            for (int i = 0; i < prescriptionDto.Medicaments.Count; i++)
            {
                var dto = prescriptionDto.Medicaments[i];
                var med = new Prescription_Medicament();
                med.IdMedicament = dto.IdMedicament;
                med.Dose = dto.Dose;
                med.Details = dto.Details;
                
                medicaments.Add(med);
            }

            var result = await _dbService.CreatePrescription(prescription, medicaments);
            return StatusCode(201, result);
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }
    
    
}