namespace MediLabo.Patients.Domain;

public class Patient
{
    public int Id { get; set; }
    public required string Prenom { get; set; }
    public required string Nom { get; set; }
    public required DateOnly DateNaissance { get; set; }
    public required int GenreId { get; set; }
    public Genre Genre { get; set; } = null!;
    public string? Adresse { get; set; }
    public string? Telephone { get; set; }
}
