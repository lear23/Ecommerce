

using AutoMapper;
using Ecomemerce.DTO;
using Ecomemerce.Modelos;
using Ecomemerce.Repositorios.Contrato;
using Ecomemerce.Repositorios.Implementacion;

namespace Ecomemerce.Servicios.Implementacion;

public class DashboardServicio(IVentaRepositorio ventaRepositorio, IGenericoRepositorio<Usuario> usuario, IGenericoRepositorio<Producto> producto) : IDashboardServicio
{
    private readonly IVentaRepositorio _ventaRepositorio = ventaRepositorio;
    private readonly IGenericoRepositorio<Usuario> _usuario = usuario;
    private readonly IGenericoRepositorio<Producto> _producto = producto;


    private string Ingresos()
    {
        var consulta = _ventaRepositorio.Consultar();
        decimal? ingressos = consulta.Sum(x => x.Total);
        return Convert.ToString(ingressos);
    }

    private int Ventas()
    {
        var consulta = _ventaRepositorio.Consultar();
        int total = consulta.Count();
        return total;
    } 
    
    private int Clientes()
    {
        var consulta = _usuario.Consultar(u => u.Rol.ToLower() == "cliente");
        int total = consulta.Count();
        return total;
    }  
    private int Productos()
    {
        var consulta = _producto.Consultar();
        int total = consulta.Count();
        return total;
    }

    public DashboardDTO Resumen()
    {
        try
        {
            DashboardDTO dto = new DashboardDTO()
            {
                TotalIngresos = Ingresos(),
                TotalCliente = Clientes(),
                TotalProductos = Productos(),
                TotalVentas = Ventas(),
            };
            return dto;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
