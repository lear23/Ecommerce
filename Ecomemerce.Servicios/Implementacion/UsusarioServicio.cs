
using AutoMapper;
using Ecomemerce.DTO;
using Ecomemerce.Modelos;
using Ecomemerce.Repositorios.Contrato;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Ecomemerce.Servicios.Implementacion;

public class UsusarioServicio(IGenericoRepositorio<Usuario> modeloServicio, IMapper mapper) : IUsuarioServicio
{
    private readonly IGenericoRepositorio<Usuario> _modeloRepo = modeloServicio;
    private readonly IMapper _mapper = mapper;

    public async Task<SesionDTO> Autorizacion(LoginDTO modelo)
    {
        try
        {
            var consulta = _modeloRepo.Consultar(p => p.Correo == modelo.Correo && p.Clave == modelo.Clave);
            var fromDbModelo = await consulta.FirstOrDefaultAsync();

            if(fromDbModelo != null) 
            {
                return _mapper.Map<SesionDTO>(fromDbModelo);
            }
            else
            {
                throw new TaskCanceledException("No se encontraron coincidencias");
            }

        }
        catch (Exception ex)
        {
            throw new Exception();
        }
    }

    public async Task<UsuarioDTO> Crear(UsuarioDTO modelo)
    {
        try
        {
            var dbModelo = _mapper.Map<Usuario>(modelo); 
            var respuestaModelo = await _modeloRepo.Crear(dbModelo);
            if(respuestaModelo.IdUsuario != 0)
            {
                return _mapper.Map<UsuarioDTO>(respuestaModelo);   
                
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

    public async Task<bool> Editar(UsuarioDTO modelo)
    {
        try
        {
            var consulta = _modeloRepo.Consultar(P => P.IdUsuario == modelo.IdUsuario);
            var fromDbModelo = await consulta.FirstOrDefaultAsync();

            if(fromDbModelo != null)
            {
                fromDbModelo.NombreCompleto = modelo.NombreCompleto;
                fromDbModelo.Correo = modelo.Correo;
                fromDbModelo.Clave = modelo.Clave;
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
            var consulta = _modeloRepo.Consultar(P => P.IdUsuario == id);

            var fromDbModelo = await consulta.FirstOrDefaultAsync();


            if (fromDbModelo != null)
            {
                var respuesta = await _modeloRepo.Eliminar(fromDbModelo);
                if (!respuesta)
                    throw new TaskCanceledException("No se pudo eliminar");

                return respuesta;
            }
            else {
                throw new TaskCanceledException("No se encontraron resultados");
                 }

        }
        catch (Exception ex)
        {
            throw new Exception();
        }
    }

    public async Task<List<UsuarioDTO>> Lista(string rol, string buscar)
    {
        try
        {
            var consulta = _modeloRepo.Consultar(p => p.Rol == rol && string.Concat(p.NombreCompleto.ToLower(), p.Correo.ToLower()).Contains(buscar.ToLower()));

            List<UsuarioDTO> lista = _mapper.Map<List<UsuarioDTO>>(await consulta.ToListAsync());
            return lista;
        }
        catch (Exception ex)
        {
            throw new Exception();
        }
    }

    public async Task<UsuarioDTO> Obtener(int id)
    {
        try
        {
            var consulta = _modeloRepo.Consultar(p => p.IdUsuario == id);
            var fromDbModelo = await consulta.FirstOrDefaultAsync();

            if (fromDbModelo != null)
            {
                return _mapper.Map<UsuarioDTO>(fromDbModelo);   
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
