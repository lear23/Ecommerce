

using System.ComponentModel.DataAnnotations;

namespace Ecomemerce.DTO;

public class ProductoDTO
{
    public int IdProducto { get; set; }

    [Required(ErrorMessage = "Ingrese nombre")]
    public string? Nombre { get; set; }


    [Required(ErrorMessage = "Ingrese descriptcion")]
    public string? Descripcion { get; set; }

    public int? IdCategoria { get; set; }

    [Required(ErrorMessage = "Ingrese precio ")]
    public decimal? Precio { get; set; }

    [Required(ErrorMessage = "Ingrese precio oferta")]
    public decimal? PrecioOferta { get; set; }

    [Required(ErrorMessage = "Ingrese cantidad")]
    public int? Cantidad { get; set; }
    [Required(ErrorMessage = "Ingrese imagen")]
    public string? Imagen { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual CategoriDTO? IdCategoriaNavigation { get; set; }

}
