using System.ComponentModel.DataAnnotations;

namespace mvcTemplate.Models
{
    public class Teacher
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le nom est requis.")]
        [StringLength(50, ErrorMessage = "Le nom ne peut pas dépasser 50 caractères.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Le prénom est requis.")]
        [StringLength(50, ErrorMessage = "Le prénom ne peut pas dépasser 50 caractères.")]
        public string Namesc { get; set; }


        [Range(18, 80, ErrorMessage = "L'âge doit être entre 18 et 80 ans.")]
        public int Age { get; set; }
    }
}
