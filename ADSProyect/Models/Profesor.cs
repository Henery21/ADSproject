using System.ComponentModel.DataAnnotations;

namespace ADSProjectBackend.Models
{
    public class Profesor
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "El campo {0} no debe ser mayor a 50 caracteres")]
        public string Nombres { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(50, ErrorMessage = "EL campo {0} no debe ser mayor a 50 caracteres")]
        public string Apellidos { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength (254, ErrorMessage = "El campo {0} no debe ser mayor a 254 caracteres")]
        [EmailAddress(ErrorMessage = "Debe ingresar un correo valido")]
        public string Email { get; set; }
    }
}
