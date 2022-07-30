using System.ComponentModel.DataAnnotations;

namespace AgendaContactos.Models {
    public class Category {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El {0} de la categoria es obligatorio")]
        [StringLength(50, ErrorMessage = "El {0} no puede tener entre {2} y {1} caracteres", MinimumLength = 4)]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Fecha de creacion")]
        public DateTime CreationDate { get; set; }
    }
}