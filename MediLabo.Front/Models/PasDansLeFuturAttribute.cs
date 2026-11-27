using System.ComponentModel.DataAnnotations;

namespace MediLabo.Front.Models;

// Copie de la règle du service Patients : ici, elle affiche le message dans le formulaire
// sans appeler la gateway. Le service garde sa propre vérification, qui seule fait foi.
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