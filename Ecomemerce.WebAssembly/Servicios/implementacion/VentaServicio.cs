using Ecomemerce.DTO;
using Ecomemerce.WebAssembly.Servicios.Contrato;
using System.Net.Http.Json;

namespace Ecomemerce.WebAssembly.Servicios.implementacion;

public class VentaServicio(HttpClient httpClient) : IVentaServicio
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<ResponseDTO<VentaDTO>> Registrar(VentaDTO modelo)
    {
        var response = await _httpClient.PostAsJsonAsync("Venta/Registrar", modelo);
        var result = await response.Content.ReadFromJsonAsync<ResponseDTO<VentaDTO>>();
        return result!;
    }
}
