using Ecomemerce.DTO;

namespace Ecomemerce.WebAssembly.Servicios.Contrato;

public interface IDashboardServicio
{
    Task<ResponseDTO<DashboardDTO>> Resumen();  
}
