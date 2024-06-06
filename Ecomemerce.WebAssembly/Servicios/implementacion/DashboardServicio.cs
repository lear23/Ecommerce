using Ecomemerce.DTO;
using Ecomemerce.WebAssembly.Servicios.Contrato;
using System.Net.Http.Json;

namespace Ecomemerce.WebAssembly.Servicios.implementacion;

public class DashboardServicio(HttpClient httpClient) : IDashboardServicio
{

    private readonly HttpClient _httpClient = httpClient;

    public async Task<ResponseDTO<DashboardDTO>> Resumen()
    {
        return await _httpClient.GetFromJsonAsync<ResponseDTO<DashboardDTO>>($"Dashboard/Resumen");
    }
}
