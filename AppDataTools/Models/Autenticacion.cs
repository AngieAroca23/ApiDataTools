using System.ComponentModel.DataAnnotations;

namespace AppDataTools.Models
{
    public class Autenticacion
    {
        [Required(ErrorMessage = "Debe digitar un Usuario")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Debe digitar una contraseña")]
        public string Pass { get; set; }
    }
}