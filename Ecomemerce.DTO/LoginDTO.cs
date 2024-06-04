

using System.ComponentModel.DataAnnotations;

namespace Ecomemerce.DTO;

public class LoginDTO
{
  

    [Required(ErrorMessage = "Ingrese correo")]
    public string? Correo { get; set; }

    [Required(ErrorMessage = "Ingrese password")]
    public string? Clave { get; set; }


}
