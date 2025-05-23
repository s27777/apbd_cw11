using Microsoft.EntityFrameworkCore;
using Tutorial5.Models;

namespace Tutorial5.Data;

public class DatabaseContext : DbContext
{
    //delete
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<BookAuthor> BookAuthors { get; set; }
    
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Medicament> Medicaments { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<Prescription_Medicament> PrescriptedMedicaments { get; set; }
    
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(a =>
        {
            a.ToTable("Author");
            
            a.HasKey(e => e.AuthorId);
            a.Property(e => e.FirstName).HasMaxLength(100);
            a.Property(e => e.LastName).HasMaxLength(200);
        });

        modelBuilder.Entity<Doctor>().HasData(new List<Doctor>()
        {
            new Doctor() { IdDoctor = 1, FirstName = "Ron", LastName = "Jakowski", Email = "asdf@nzxt.net"},
            new Doctor() { IdDoctor = 2, FirstName = "Andrzej", LastName = "Kowalski", Email = "qwer@nzxt.net"},
        });

        modelBuilder.Entity<Patient>().HasData(new List<Patient>()
        {
            new Patient() { IdPatient = 1, FirstName = "Ron", LastName = "Jakowski", Birthdate = new DateTime(1989, 6, 21)},
            new Patient() { IdPatient = 2, FirstName = "Andrzej", LastName = "Kowalski", Birthdate = new DateTime(2001, 1, 11)},
        });

        //delete
        modelBuilder.Entity<Author>().HasData(new List<Author>()
        {
            new Author() { AuthorId = 1, FirstName = "Jane", LastName = "Doe"},
            new Author() { AuthorId = 2, FirstName = "John", LastName = "Doe"},
        });
        
        
        //delete
        modelBuilder.Entity<Book>().HasData(new List<Book>()
        {
            new Book() { BookId = 1, Name = "Book 1", Price = 10.2 },
            new Book() { BookId = 2, Name = "Book 2", Price = 123.2 },
        });
        
        //delete
        modelBuilder.Entity<BookAuthor>().HasData(new List<BookAuthor>()
        {
            new BookAuthor() { AuthorId = 1, BookId = 1, Notes = "n1" },
            new BookAuthor() { AuthorId = 2, BookId = 1, Notes = "n2" },
        });
    }
}