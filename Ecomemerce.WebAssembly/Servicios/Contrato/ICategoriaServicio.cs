using Ecomemerce.DTO;

namespace Ecomemerce.WebAssembly.Servicios.Contrato;

public interface ICategoriaServicio
{

    Task<ResponseDTO<List<CategoriDTO>>> Lista(string buscar);
    Task<ResponseDTO<CategoriDTO>> Obtener(int id);
    Task<ResponseDTO<CategoriDTO>> Crear(CategoriDTO modelo);
    Task<ResponseDTO<bool>> Editar(CategoriDTO modelo);
    Task<ResponseDTO<bool>> Eliminar(int id);

}
