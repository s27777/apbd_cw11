using Microsoft.EntityFrameworkCore;
using Tutorial5.Data;
using Tutorial5.DTOs;
using Tutorial5.Models;

namespace Tutorial5.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;
    public DbService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<Prescription> CreatePrescription(Prescription prescription,
        List<Prescription_Medicament> medicaments)
    {
        var patient = await _context.Patients.FindAsync(prescription.IdPatient);
        var doctor = await _context.Doctors.FindAsync(prescription.IdDoctor);

        if (patient == null || doctor == null)
        {
            throw new Exception("Doctor or Patient missing");
        }

        await _context.Prescriptions.AddAsync(prescription);
        await _context.SaveChangesAsync();

        foreach (var medicament in medicaments)
        {
            var medExists = await _context.Medicaments.FindAsync(medicament.IdMedicament);
            if (medExists == null)
            {
                throw new Exception("Medicament not found");
            }

            medicament.IdPrescription = prescription.IdPrescription;
            await _context.PrescriptedMedicaments.AddAsync(medicament);
        }

        await _context.SaveChangesAsync();
        return prescription;
    }


    //delete
    public async Task<List<BookWithAuthorsDto>> GetBooks()
    {
        var books = await _context.Books.Select(e =>
        new BookWithAuthorsDto {
            Name = e.Name,
            Price = e.Price,
            Authors = e.BookAuthors.Select(a =>
            new AuthorDto {
                FirstName = a.Author.FirstName,
                LastName = a.Author.LastName
            }).ToList()
        }).ToListAsync();
        return books;
    }
}