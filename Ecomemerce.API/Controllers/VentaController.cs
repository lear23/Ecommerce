using Ecomemerce.DTO;
using Ecomemerce.Servicios.Implementacion;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecomemerce.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VentaController(IVentaServicio ventaServicio) : ControllerBase
{

    private readonly IVentaServicio _ventaServicio = ventaServicio;



    [HttpPost("Registrar")]

    public async Task<IActionResult> Registrar([FromBody] VentaDTO modelo)
    {
        var response = new ResponseDTO<VentaDTO>();

        try
        {


            response.EsCorrecto = true;
            response.Resultado = await _ventaServicio.Registrar(modelo);
        }
        catch (Exception ex)
        {
            response.EsCorrecto = false;
            response.Mensaje = ex.Message;
        }

        return Ok(response);
    }


}
