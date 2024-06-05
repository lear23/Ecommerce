

using AutoMapper;
using Ecomemerce.DTO;
using Ecomemerce.Modelos;
using Ecomemerce.Repositorios.Contrato;
using Microsoft.EntityFrameworkCore;

namespace Ecomemerce.Servicios.Implementacion;

public class CategoriaServicio(IGenericoRepositorio<Categoria> repositorio, IMapper mapper) : ICategoriaServicio
{
    private readonly IGenericoRepositorio<Categoria> _modeloRepo = repositorio;
    private readonly IMapper _mapper = mapper;

    public async Task<CategoriDTO> Crear(CategoriDTO modelo)
    {
        try
        {
            var dbModelo = _mapper.Map<Categoria>(modelo);
            var respuestaModelo = await _modeloRepo.Crear(dbModelo);
            if (respuestaModelo.IdCategoria != 0)
            {
                return _mapper.Map<CategoriDTO>(respuestaModelo);

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

    public async Task<bool> Editar(CategoriDTO modelo)
    {
        try
        {
            var consulta = _modeloRepo.Consultar(P => P.IdCategoria == modelo.IdCategoria);
            var fromDbModelo = await consulta.FirstOrDefaultAsync();

            if (fromDbModelo != null)
            {
                fromDbModelo.Nombre = modelo.Nombre;
              
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
            var consulta = _modeloRepo.Consultar(P => P.IdCategoria == id);

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

    public async Task<List<CategoriDTO>> Lista(string buscar)
    {
        try
        {
            var consulta = _modeloRepo.Consultar(p => string.Concat(p.Nombre.ToLower()).Contains(buscar.ToLower()));

            List<CategoriDTO> lista = _mapper.Map<List<CategoriDTO>>(await consulta.ToListAsync());
            return lista;
        }
        catch (Exception ex)
        {
            throw new Exception();
        }
    }

    public async Task<CategoriDTO> Obtener(int id)
    {
        try
        {
            var consulta = _modeloRepo.Consultar(p => p.IdCategoria == id);
            var fromDbModelo = await consulta.FirstOrDefaultAsync();

            if (fromDbModelo != null)
            {
                return _mapper.Map<CategoriDTO>(fromDbModelo);
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
