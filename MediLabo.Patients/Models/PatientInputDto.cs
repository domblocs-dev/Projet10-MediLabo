using System.ComponentModel.DataAnnotations;

namespace MediLabo.Patients.Models;

public class PatientInputDto
{
    [Required]
    [MaxLength(100)]
    public string? Prenom { get; set; }

    [Required]
    [MaxLength(100)]
    public string? Nom { get; set; }

    [Required]
    [PasDansLeFutur(ErrorMessage = "La date de naissance ne peut pas être dans le futur.")]
    public DateOnly? DateNaissance { get; set; }

    [Required]
    public string? Genre { get; set; }

    [MaxLength(200)]
    public string? Adresse { get; set; }

    [MaxLength(20)]
    public string? Telephone { get; set; }
}
