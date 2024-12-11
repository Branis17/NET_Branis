using System.ComponentModel.DataAnnotations;

namespace mvcTemplate.Models
{
    public class Teacher
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le nom est requis.")]
        [StringLength(50, ErrorMessage = "Le nom ne peut pas d�passer 50 caract�res.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Le pr�nom est requis.")]
        [StringLength(50, ErrorMessage = "Le pr�nom ne peut pas d�passer 50 caract�res.")]
        public string Namesc { get; set; }


        [Range(18, 80, ErrorMessage = "L'�ge doit �tre entre 18 et 80 ans.")]
        public int Age { get; set; }
    }
}
