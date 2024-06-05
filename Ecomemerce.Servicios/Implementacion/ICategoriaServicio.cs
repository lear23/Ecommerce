

using Ecomemerce.DTO;

namespace Ecomemerce.Servicios.Implementacion;

public interface ICategoriaServicio
{

    Task<List<CategoriDTO>> Lista(string buscar);
    Task<CategoriDTO> Obtener(int id);
    Task<CategoriDTO> Crear(CategoriDTO modelo);
    Task<bool> Editar(CategoriDTO modelo);
    Task<bool> Eliminar(int id);

}
