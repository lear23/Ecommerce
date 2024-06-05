

using Ecomemerce.DTO;
using Ecomemerce.Modelos;

namespace Ecomemerce.Servicios.Implementacion;

public interface IVentaServicio
{
    
    Task<VentaDTO> Registrar(VentaDTO modelo);  


}
