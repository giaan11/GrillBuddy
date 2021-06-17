using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GrillBuddy.Models
{
    public class RegisterModel
    {
        [Required]
        public string Username { get; set; }
        [EmailAddress] //controlla se l'email è strutturalmente valida
        public string EMail { get; set; }
        [Required]
        [Compare("ConfirmPassword", ErrorMessage = "La password non combacia")] //ci sarà un check che confronta se password e la conferma della password sono uguale, se non corretto restituisce un http error 404
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
    }
}
