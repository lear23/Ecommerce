

using Ecomemerce.DTO;

namespace Ecomemerce.Servicios.Implementacion;

public interface IProductoServicio
{

    Task<List<ProductoDTO>> Lista(string buscar);
    Task<List<ProductoDTO>> Catalogo(string categoria, string buscar);
    Task<ProductoDTO> Obtener(int id);
    Task<ProductoDTO> Crear(ProductoDTO modelo);
    Task<bool> Editar(ProductoDTO modelo);
    Task<bool> Eliminar(int id);


}
