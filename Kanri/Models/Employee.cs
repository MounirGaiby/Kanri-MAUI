using System.ComponentModel.DataAnnotations;

namespace Kanri.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le prénom est obligatoire")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Le nom est obligatoire")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Le genre est obligatoire")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Le salaire est obligatoire")]
        public double Salary { get; set; }

        [Required(ErrorMessage = "La date de naissance est obligatoire")]
        public DateTime BirthDate { get; set; }

        public int Age => DateTime.Now.Year - BirthDate.Year - (DateTime.Now.DayOfYear < BirthDate.DayOfYear ? 1 : 0);
    }
} 