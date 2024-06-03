

using Ecomemerce.Repositorios.Contrato;
using Ecomemerce.Repositorios.DBContext;
using System.Linq.Expressions;

namespace Ecomemerce.Repositorios.Implementacion;

public class GenericoRepositorio<TModelo>(DbecommerceContext dbContext) : IGenericoRepositorio<TModelo> where TModelo : class 
{
    private readonly DbecommerceContext _dbContext = dbContext;

    public IQueryable<TModelo> Consultar(Expression<Func<TModelo, bool>>? filtro = null)
    {
        IQueryable<TModelo> consulta = (filtro == null) ? _dbContext.Set<TModelo>() : _dbContext.Set<TModelo>().Where(filtro);
        return consulta;
    }

    public async Task<TModelo> Crear(TModelo modelo)
    {
        try
        {
            _dbContext.Set<TModelo>().Add(modelo);
            await _dbContext.SaveChangesAsync();
            return modelo;
        }
        catch (Exception ex)
        {
            throw;
        }
       
    }

    public async Task<bool> Editar(TModelo modelo)
    {
        try
        {
            _dbContext.Set<TModelo>().Update(modelo);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task<bool> Eliminar(TModelo modelo)
    {
        try
        {
            _dbContext.Set<TModelo>().Remove(modelo);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}
