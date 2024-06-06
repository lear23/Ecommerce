using Ecomemerce.DTO;
using Ecomemerce.WebAssembly.Servicios.Contrato;
using System.Net.Http.Json;

namespace Ecomemerce.WebAssembly.Servicios.implementacion;

public class ProductoServicio(HttpClient httpClient) : IProductoServicio
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<ResponseDTO<List<ProductoDTO>>> Catalogo(string categoria, string buscar)
    {
        return await _httpClient.GetFromJsonAsync<ResponseDTO<List<ProductoDTO>>>($"Producto/Catalogo({categoria}/{buscar}");
    }

    public async Task<ResponseDTO<ProductoDTO>> Crear(ProductoDTO modelo)
    {
        var response = await _httpClient.PostAsJsonAsync("Producto/crear", modelo);
        var result = await response.Content.ReadFromJsonAsync<ResponseDTO<ProductoDTO>>();
        return result!;
    }

    public async Task<ResponseDTO<bool>> Editar(ProductoDTO modelo)
    {
        var response = await _httpClient.PutAsJsonAsync("Producto/Editar", modelo);
        var result = await response.Content.ReadFromJsonAsync<ResponseDTO<bool>>();
        return result!;
    }

    public async Task<ResponseDTO<bool>> Eliminar(int id)
    {
        return await _httpClient.DeleteFromJsonAsync<ResponseDTO<bool>>($"Producto/Eliminar({id}");
    }

    public async Task<ResponseDTO<List<ProductoDTO>>> Lista(string buscar)
    {
        return await _httpClient.GetFromJsonAsync<ResponseDTO<List<ProductoDTO>>>($"Producto/Lista{buscar}");
    }

    public async Task<ResponseDTO<ProductoDTO>> Obtener(int id)
    {
        return await _httpClient.GetFromJsonAsync<ResponseDTO<ProductoDTO>>($"Producto/Eliminar({id}");
    }
}
