using System.ComponentModel.DataAnnotations;

namespace MediLabo.Patients.Models;

// La contrainte CHECK de la base refuse aussi ces dates, mais le service répondrait 500 au lieu de 400.
public class PasDansLeFuturAttribute : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        if (value is DateOnly date)
        {
            return date <= DateOnly.FromDateTime(DateTime.Today);
        }

        return true;
    }
}