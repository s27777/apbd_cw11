using Tutorial5.DTOs;
using Tutorial5.Models;

namespace Tutorial5.Services;

public interface IDbService
{
    Task<PrescriptionDTO> GetPrescription(int id);
    Task<Prescription> CreatePrescription(Prescription prescription, List<Prescription_Medicament> medicaments);
}