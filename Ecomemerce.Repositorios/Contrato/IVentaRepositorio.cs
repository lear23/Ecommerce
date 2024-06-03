using Ecomemerce.Modelos;

namespace Ecomemerce.Repositorios.Contrato;

public interface IVentaRepositorio : IGenericoRepositorio<Venta>
{

    Task<Venta> Registrar(Venta modelo);


}
