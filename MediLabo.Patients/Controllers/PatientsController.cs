using MediLabo.Patients.Domain;
using MediLabo.Patients.Models;
using MediLabo.Patients.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MediLabo.Patients.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PatientsController(PatientRepository repository) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(List<PatientDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        List<Patient> patients = await repository.FindAllAsync();
        return Ok(patients.Select(ToDto).ToList());
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(PatientDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(int id)
    {
        Patient? patient = await repository.FindByIdAsync(id);
        if (patient is null)
        {
            return NotFound();
        }
        return Ok(ToDto(patient));
    }

    [HttpPost]
    [ProducesResponseType(typeof(PatientDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] PatientInputDto dto)
    {
        Genre? genre = await repository.FindGenreByCodeAsync(dto.Genre!);
        if (genre is null)
        {
            ModelState.AddModelError(nameof(dto.Genre), "Le genre doit être F ou M.");
            return ValidationProblem(ModelState);
        }

        Patient patient = new Patient
        {
            Prenom = dto.Prenom!,
            Nom = dto.Nom!,
            DateNaissance = dto.DateNaissance!.Value,
            GenreId = genre.Id,
            Genre = genre,
            Adresse = dto.Adresse,
            Telephone = dto.Telephone
        };

        Patient created = await repository.AddAsync(patient);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, ToDto(created));
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(int id, [FromBody] PatientInputDto dto)
    {
        Patient? patient = await repository.FindByIdAsync(id);
        if (patient is null)
        {
            return NotFound();
        }

        Genre? genre = await repository.FindGenreByCodeAsync(dto.Genre!);
        if (genre is null)
        {
            ModelState.AddModelError(nameof(dto.Genre), "Le genre doit être F ou M.");
            return ValidationProblem(ModelState);
        }

        patient.Prenom = dto.Prenom!;
        patient.Nom = dto.Nom!;
        patient.DateNaissance = dto.DateNaissance!.Value;
        patient.GenreId = genre.Id;
        patient.Genre = genre;
        patient.Adresse = dto.Adresse;
        patient.Telephone = dto.Telephone;

        await repository.SaveChangesAsync();
        return NoContent();
    }

    private static PatientDto ToDto(Patient patient)
    {
        return new PatientDto
        {
            Id = patient.Id,
            Prenom = patient.Prenom,
            Nom = patient.Nom,
            DateNaissance = patient.DateNaissance,
            Genre = patient.Genre.Code,
            Adresse = patient.Adresse,
            Telephone = patient.Telephone
        };
    }
}
