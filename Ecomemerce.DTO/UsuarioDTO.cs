

using System.ComponentModel.DataAnnotations;

namespace Ecomemerce.DTO;

public class UsuarioDTO
{

    public int IdUsuario { get; set; }
    [Required(ErrorMessage ="Ingrese nombre completo")]
    public string? NombreCompleto { get; set; }

    [Required(ErrorMessage = "Ingrese correo")]
    public string? Correo { get; set; }

    [Required(ErrorMessage = "Ingrese password")]
    public string? Clave { get; set; }

    [Required(ErrorMessage = "Confirme password")]
    public string? ConfirmarClave { get; set; }

    public string? Rol { get; set; }

}
