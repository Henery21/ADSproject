using System.ComponentModel.DataAnnotations;


namespace ADSProyect.Models

{
    public class Estudiante
    {
        public int IdEstudiante { get; set; }
        [Required(ErrorMessage ="Este es un campo requerido")]
        [MaxLength(length:50, ErrorMessage ="La longitud del campo no puede ser mayor a 50 caracteres. ")]

        public String NombresEstudiante { get; set; }
        [Required(ErrorMessage = "Este es un campo requerido")]
        [MaxLength(length: 50, ErrorMessage = "La longitud del campo no puede ser mayor a 50 caracteres. ")]

        public String ApellidosEstudiante { get; set;}
        [Required(ErrorMessage = "Este es un campo requerido")]
        [MinLength(length: 12, ErrorMessage = "La longitud del campo no puede ser menor a 12 caracteres. ")]
        [MaxLength(length: 50, ErrorMessage = "La longitud del campo no puede ser mayor a 50 caracteres. ")]

        public  String CodigoEstudiante { get;set; }
        [Required(ErrorMessage = "Este es un campo requerido")]
        [MaxLength(length: 254, ErrorMessage = "La longitud del campo no puede ser mayor a 254 caracteres. ")]
        [EmailAddress(ErrorMessage ="El formato de correo electronico no es correcto.")]

        public string CorreoEstudiante { get; set; }
    }
}
