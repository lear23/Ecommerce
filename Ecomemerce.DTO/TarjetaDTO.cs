

using System.ComponentModel.DataAnnotations;

namespace Ecomemerce.DTO;

public class TarjetaDTO
{
    [Required(ErrorMessage = "Ingrese titular")]

    public string? Titular {  get; set; }
    [Required(ErrorMessage = "Ingrese Numero Tarjeta")]
    public string? Numero {  get; set; }

    [Required(ErrorMessage = "Ingrese Vigencia")]
    public string? Vigencia {  get; set; }

    [Required(ErrorMessage = "Ingrese CVV")]
    public string? CVV {  get; set; }


}
