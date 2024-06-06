using Blazored.LocalStorage;
using Blazored.Toast.Services;
using Ecomemerce.DTO;
using Ecomemerce.WebAssembly.Servicios.Contrato;

namespace Ecomemerce.WebAssembly.Servicios.implementacion;

public class CarritoServicio(ILocalStorageService localStorage, ISyncLocalStorageService syncLocalStorageService, IToastService toastService) : ICarritoServicio
{

    private readonly ILocalStorageService _localStorage = localStorage;
    private readonly ISyncLocalStorageService _syncLocalStorageService = syncLocalStorageService;
    private readonly IToastService _toastService = toastService;

    public event Action MostrarItems;

    public async Task AgregarCarrito(CarritoDTO modelo)
    {
        try
        {
            var carrito = await _localStorage.GetItemAsync<List<CarritoDTO>>("carrito");
            if(carrito == null)            
                carrito = new List<CarritoDTO>();   

                var encontrado = carrito.FirstOrDefault(p => p.Producto.IdProducto == modelo.Producto.IdProducto);

            if(encontrado != null)
                 carrito.Remove(encontrado);

            carrito.Add(modelo);
            await _localStorage.SetItemAsync("carrito", carrito);


            if (encontrado != null)
                _toastService.ShowSuccess("Producto fue actualizado en el carrito");
            else
                _toastService.ShowSuccess("Producto fue agregado al carrito");

            MostrarItems?.Invoke();
        }
        catch (Exception ex)
        {
            _toastService.ShowError("No se pudo agregar al carrito");
        }
    }

    public int CantidadProductos()
    {
        var Carrito = _syncLocalStorageService.GetItem<List<CarritoDTO>>("carrito");
        return Carrito == null ? 0 : Carrito.Count();   
    }

    public async Task<List<CarritoDTO>> DevolverCarrito()
    {
        var carrito = await _localStorage.GetItemAsync<List<CarritoDTO>>("carrito");

        if(carrito == null)
            carrito = new List<CarritoDTO>();


        return carrito;
    }

    public async Task EliminarCarrito(int idProducto)
    {
        try
        {
            var carrito = await _localStorage.GetItemAsync<List<CarritoDTO>>("carrito");

            if (carrito != null)
            {
                var elemento = carrito.FirstOrDefault(x => x.Producto.IdProducto == idProducto);

                if (elemento != null)
                {
                    carrito.Remove(elemento);   
                    await _localStorage.SetItemAsync("carrito",carrito);


                    MostrarItems.Invoke();
                }

            }

        }
        catch (Exception ex)
        {

        }
    }

    public async Task LimpiarCarrito()
    {
        await _localStorage.RemoveItemAsync("carrito");
        MostrarItems.Invoke();
    }


}
