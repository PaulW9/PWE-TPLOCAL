using System.ComponentModel.DataAnnotations;
using TPLOCAL1.Controllers;

namespace TPLOCAL1.Models
{
    public class DataStored
    {
        public string Name { get; set; }

        [Required]
        public string Forename { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string Address { get; set; }

        [RegularExpression(@"^[0-9]{5,6}$", ErrorMessage = "Le code postal doit être composé de 5 à 6 chiffres.")]
        public string ZipCode { get; set; }

        [Required]
        public string City { get; set; }

        [EmailAddress(ErrorMessage = "Adresse email invalide.")]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date de début de la formation")]
        public DateTime TrainingStartDate { get; set; }

        [Required]
        public string TrainingType { get; set; }

        [Required]
        public string TrainingReviewCOBOL { get; set; }

        [Required]
        public string TrainingReviewCsharp { get; set; }
    }



}
