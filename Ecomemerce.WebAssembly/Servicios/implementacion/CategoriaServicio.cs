



using Ecomemerce.DTO;
using Ecomemerce.WebAssembly.Servicios.Contrato;
using System.Net.Http.Json;
using System.Reflection;

namespace Ecomemerce.WebAssembly.Servicios.implementacion;

public class CategoriaServicio(HttpClient httpClient) : ICategoriaServicio
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<ResponseDTO<CategoriDTO>> Crear(CategoriDTO modelo)
    {
        var response = await _httpClient.PostAsJsonAsync("Categoria/crear", modelo);
        var result = await response.Content.ReadFromJsonAsync<ResponseDTO<CategoriDTO>>();
        return result!;
    }

    public async Task<ResponseDTO<bool>> Editar(CategoriDTO modelo)
    {
        var response = await _httpClient.PutAsJsonAsync("Categoria/Editar", modelo);
        var result = await response.Content.ReadFromJsonAsync<ResponseDTO<bool>>();
        return result!;
    }

    public async Task<ResponseDTO<bool>> Eliminar(int id)
    {
        return await _httpClient.DeleteFromJsonAsync<ResponseDTO<bool>>($"Categoria/Eliminar({id}");
    }

    public async Task<ResponseDTO<List<CategoriDTO>>> Lista(string buscar)
    {
        return await _httpClient.GetFromJsonAsync<ResponseDTO<List<CategoriDTO>>>($"Categoria/Lista/({buscar}");
    }

    public async Task<ResponseDTO<CategoriDTO>> Obtener(int id)
    {
        return await _httpClient.GetFromJsonAsync<ResponseDTO<CategoriDTO>>($"Categoria/Obtener/({id}");
    }
}
