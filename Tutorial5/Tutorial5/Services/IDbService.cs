using Tutorial5.DTOs;
using Tutorial5.Models;

namespace Tutorial5.Services;

public interface IDbService
{
    Task<List<BookWithAuthorsDto>> GetBooks();

        Task<Prescription> CreatePrescription(Prescription prescription, List<Prescription_Medicament> medicaments);
}