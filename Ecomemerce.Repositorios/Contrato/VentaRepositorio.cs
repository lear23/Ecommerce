using Ecomemerce.Modelos;
using Ecomemerce.Repositorios.DBContext;
using Ecomemerce.Repositorios.Implementacion;

namespace Ecomemerce.Repositorios.Contrato;

public class VentaRepositorio(DbecommerceContext context) : GenericoRepositorio<Venta>(context), IVentaRepositorio
{
    private readonly DbecommerceContext _context = context;

    public async Task<Venta> Registrar(Venta modelo)
    {
        Venta generada = new Venta();
        using (var Transaction = _context.Database.BeginTransaction())
        {
            try
            {
                foreach (DetalleVenta dv in modelo.DetalleVenta)
                {
                    Producto producto_encontrado = _context.Productos.Where(p => p.IdProducto == dv.IdProducto).First();

                    producto_encontrado.Cantidad = producto_encontrado.Cantidad - dv.Cantidad;

                    _context.Productos.Update(producto_encontrado);
                }
                await _context.SaveChangesAsync();


                await _context.Venta.AddAsync(modelo);
                await _context.SaveChangesAsync();

                generada = modelo;
                Transaction.Commit();

            }
            catch
            {
                Transaction.Rollback();
                throw;
            }
        }
        return generada;
    }
}
