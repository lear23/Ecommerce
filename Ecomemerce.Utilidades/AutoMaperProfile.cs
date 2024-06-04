

using AutoMapper;
using Ecomemerce.DTO;
using Ecomemerce.Modelos;

namespace Ecomemerce.Utilidades;

public class AutoMaperProfile : Profile
{

    public AutoMaperProfile()
    {
        CreateMap<Usuario,UsuarioDTO>();
        CreateMap<Usuario,SesionDTO>();
        CreateMap<UsuarioDTO, Usuario >();

        CreateMap<Categoria, CategoriDTO>();
        CreateMap<CategoriDTO, Categoria>();

        
        CreateMap<Producto, ProductoDTO>();
        CreateMap<ProductoDTO, Producto>().ForMember(d => d.IdCategoriaNavigation, opt => opt.Ignore());


        CreateMap<DetalleVenta,DetalleVentaDTO>();
        CreateMap<DetalleVentaDTO, DetalleVenta>();

        CreateMap<Venta, VentaDTO>();
        CreateMap<VentaDTO,Venta>();      


    }

}
