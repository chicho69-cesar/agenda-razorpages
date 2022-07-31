using System.ComponentModel.DataAnnotations;

namespace AgendaContactos.Models {
    public class Contact {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El {0} del contacto es obligatorio")]
        [StringLength(50, ErrorMessage = "El {0} no puede tener entre {2} y {1} caracteres", MinimumLength = 4)]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El {0} del contacto es obligatorio")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El {0} del contacto es obligatorio")]
        [Phone]
        [Display(Name = "Numero de telefono")]
        public string PhoneNumber { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Fecha de creacion")]
        public DateTime CreationDate { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Display(Name = "Categoria")]
        public Category Category { get; set; }
    }
}