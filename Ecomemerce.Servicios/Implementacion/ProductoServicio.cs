

using AutoMapper;
using Ecomemerce.DTO;
using Ecomemerce.Modelos;
using Ecomemerce.Repositorios.Contrato;
using Microsoft.EntityFrameworkCore;

namespace Ecomemerce.Servicios.Implementacion
{
    public  class ProductoServicio(IGenericoRepositorio<Producto> repositorio, IMapper mapper) : IProductoServicio
    {
        private readonly IGenericoRepositorio<Producto> _modeloRepo = repositorio;
        private readonly IMapper _mapper = mapper;

        public async Task<List<ProductoDTO>> Catalogo(string categoria, string buscar)
        {
            try
            {
                var consulta = _modeloRepo.Consultar(p => p.Nombre.ToLower().Contains(buscar.ToLower()) && p.IdCategoriaNavigation.Nombre.ToLower().Contains(categoria.ToLower()));

                List<ProductoDTO> lista = _mapper.Map<List<ProductoDTO>>(await consulta.ToListAsync());
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public async Task<ProductoDTO> Crear(ProductoDTO modelo)
        {
            try
            {
                var dbModelo = _mapper.Map<Producto>(modelo);
                var respuestaModelo = await _modeloRepo.Crear(dbModelo);
                if (respuestaModelo.IdProducto != 0)
                {
                    return _mapper.Map<ProductoDTO>(respuestaModelo);

                }
                else
                {
                    throw new TaskCanceledException("No se puede crear");
                }

            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public async Task<bool> Editar(ProductoDTO modelo)
        {
            try
            {
                var consulta = _modeloRepo.Consultar(P => P.IdProducto == modelo.IdProducto);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                {
                    fromDbModelo.Nombre = modelo.Nombre;
                    fromDbModelo.Descripcion = modelo.Descripcion;
                    fromDbModelo.IdCategoria = modelo.IdCategoria;
                    fromDbModelo.Precio = modelo.Precio;
                    fromDbModelo.PrecioOferta = modelo.PrecioOferta;
                    fromDbModelo.Cantidad = modelo.Cantidad;
                    fromDbModelo.Imagen = modelo.Imagen;

                    var respuesta = await _modeloRepo.Editar(fromDbModelo);


                    if (!respuesta)
                        throw new TaskCanceledException("No se pudo editar");

                    return respuesta;
                }
                else
                {
                    throw new TaskCanceledException("No se encontraron resultados");
                }

            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                var consulta = _modeloRepo.Consultar(P => P.IdProducto == id);

                var fromDbModelo = await consulta.FirstOrDefaultAsync();


                if (fromDbModelo != null)
                {
                    var respuesta = await _modeloRepo.Eliminar(fromDbModelo);
                    if (!respuesta)
                        throw new TaskCanceledException("No se pudo eliminar");

                    return respuesta;
                }
                else
                {
                    throw new TaskCanceledException("No se encontraron resultados");
                }

            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public async Task<List<ProductoDTO>> Lista(string buscar)
        {
            try
            {
                var consulta = _modeloRepo.Consultar(p => p.Nombre.ToLower().Contains(buscar.ToLower()));

                consulta = consulta.Include(c => c.IdCategoriaNavigation);

                List<ProductoDTO> lista = _mapper.Map<List<ProductoDTO>>(await consulta.ToListAsync());
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public async Task<ProductoDTO> Obtener(int id)
        {
            try
            {
                var consulta = _modeloRepo.Consultar(p => p.IdProducto == id);

                consulta = consulta.Include(c => c.IdCategoriaNavigation);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                {
                    return _mapper.Map<ProductoDTO>(fromDbModelo);
                }
                else
                {
                    throw new TaskCanceledException("No se encontraron coincidencia");
                }

            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
    }
}
