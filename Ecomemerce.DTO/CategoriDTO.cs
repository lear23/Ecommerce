

using System.ComponentModel.DataAnnotations;

namespace Ecomemerce.DTO;

public class CategoriDTO
{
    public int IdCategoria { get; set; }

    [Required(ErrorMessage = "Ingrese nombre")]
    public string? Nombre { get; set; }


}
