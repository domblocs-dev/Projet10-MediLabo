namespace MediLabo.Patients.Models;

public class PatientDto
{
    public required int Id { get; set; }
    public required string Prenom { get; set; }
    public required string Nom { get; set; }
    public required DateOnly DateNaissance { get; set; }
    public required string Genre { get; set; }
    public string? Adresse { get; set; }
    public string? Telephone { get; set; }
}
