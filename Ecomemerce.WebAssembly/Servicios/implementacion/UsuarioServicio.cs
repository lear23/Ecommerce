using Ecomemerce.DTO;
using Ecomemerce.WebAssembly.Servicios.Contrato;
using System.Net.Http.Json;
using System.Reflection;

namespace Ecomemerce.WebAssembly.Servicios.implementacion;

public class UsuarioServicio(HttpClient httpClient) : IUsuarioServicio
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<ResponseDTO<SesionDTO>> Autorizacion(LoginDTO modelo)
    {
        var response = await _httpClient.PostAsJsonAsync("Usuario/Autorizacion", modelo);
        var result = await response.Content.ReadFromJsonAsync<ResponseDTO<SesionDTO>>();
        return result!;
    }

    public async Task<ResponseDTO<UsuarioDTO>> Crear(UsuarioDTO modelo)
    {
        var response = await _httpClient.PostAsJsonAsync("Usuario/crear", modelo);
        var result = await response.Content.ReadFromJsonAsync<ResponseDTO<UsuarioDTO>>();
        return result!;
    }

    public async Task<ResponseDTO<bool>> Editar(UsuarioDTO modelo)
    {
        var response = await _httpClient.PutAsJsonAsync("Usuario/Editar", modelo);
        var result = await response.Content.ReadFromJsonAsync<ResponseDTO<bool>>();
        return result!;
    }

    public async Task<ResponseDTO<bool>> Eliminar(int id)
    {
       return await _httpClient.DeleteFromJsonAsync<ResponseDTO<bool>>($"Usuario/Eliminar({id}");
    }

    public async Task<ResponseDTO<List<UsuarioDTO>>> Lista(string rol, string buscar)
    {
        return await _httpClient.GetFromJsonAsync<ResponseDTO<List<UsuarioDTO>>>($"Usuario/Lista({rol}/{buscar}");
    }

    public async Task<ResponseDTO<UsuarioDTO>> Obtener(int id)
    {
        return await _httpClient.GetFromJsonAsync<ResponseDTO<UsuarioDTO>>($"Usuario/Eliminar({id}");
    }
}
