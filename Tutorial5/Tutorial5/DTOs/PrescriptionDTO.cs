namespace Tutorial5.DTOs;

public class PrescriptionDTO
{
    public int IdPatient { get; set; }
    public int IdDoctor { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    
    public List<MedicamentDTO> Medicaments { get; set; }
}