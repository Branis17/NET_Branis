using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace mvcTemplate.Models
{
    public class Event
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le titre est requis.")]
        [StringLength(100, ErrorMessage = "Le titre ne peut pas d�passer 100 caract�res.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "La description est requise.")]
        [StringLength(500, ErrorMessage = "La description ne peut pas d�passer 500 caract�res.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "La date de l'�v�nement est requise.")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Date de l'�v�nement")]
        public DateTime EventDate { get; set; }

        [Required(ErrorMessage = "Le nombre maximum de participants est requis.")]
        [Range(10, 200, ErrorMessage = "Le nombre de participants doit �tre compris entre 10 et 200.")]
        public int MaxParticipants { get; set; }

        [Required(ErrorMessage = "L'emplacement est requis.")]
        [StringLength(100, ErrorMessage = "L'emplacement ne peut pas d�passer 100 caract�res.")]
        public string Location { get; set; }

        [Display(Name = "Date de cr�ation")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
