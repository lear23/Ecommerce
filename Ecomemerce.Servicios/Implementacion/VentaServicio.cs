

using AutoMapper;
using Ecomemerce.DTO;
using Ecomemerce.Modelos;
using Ecomemerce.Repositorios.Contrato;

namespace Ecomemerce.Servicios.Implementacion;

public class VentaServicio : IVentaServicio
{
       private readonly IMapper _mapper;
       private readonly IVentaRepositorio _repo;

    public async Task<VentaDTO> Registrar(VentaDTO modelo)
    {
        try
        {
            var dbModelo = _mapper.Map<Venta>(modelo);
            var ventaGenerada = await _repo.Registrar(dbModelo);
            if (ventaGenerada.IdVenta == 0)
                   throw new TaskCanceledException("No se puede crear");
            
          return _mapper.Map<VentaDTO>(ventaGenerada);
        }
        catch (Exception ex)
        {
            throw new Exception();
        }
    }
}
