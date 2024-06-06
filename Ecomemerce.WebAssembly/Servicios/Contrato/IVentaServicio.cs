using Ecomemerce.DTO;

namespace Ecomemerce.WebAssembly.Servicios.Contrato;

public interface IVentaServicio
{

    Task<ResponseDTO<VentaDTO>> Registrar(VentaDTO modelo);   

}
