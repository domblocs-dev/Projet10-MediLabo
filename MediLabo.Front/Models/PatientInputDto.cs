using System.ComponentModel.DataAnnotations;

namespace MediLabo.Front.Models;

public class PatientInputDto
{
    [Required(ErrorMessage = "Le prénom est obligatoire.")]
    [MaxLength(100, ErrorMessage = "Le prénom ne doit pas dépasser 100 caractères.")]
    public string? Prenom { get; set; }

    [Required(ErrorMessage = "Le nom est obligatoire.")]
    [MaxLength(100, ErrorMessage = "Le nom ne doit pas dépasser 100 caractères.")]
    public string? Nom { get; set; }

    [Required(ErrorMessage = "La date de naissance est obligatoire.")]
    [PasDansLeFutur(ErrorMessage = "La date de naissance ne peut pas être dans le futur.")]
    public DateOnly? DateNaissance { get; set; }

    [Required(ErrorMessage = "Le genre est obligatoire.")]
    public string? Genre { get; set; }

    [MaxLength(200, ErrorMessage = "L'adresse ne doit pas dépasser 200 caractères.")]
    public string? Adresse { get; set; }

    [MaxLength(20, ErrorMessage = "Le téléphone ne doit pas dépasser 20 caractères.")]
    public string? Telephone { get; set; }
}