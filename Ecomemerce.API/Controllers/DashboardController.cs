using Ecomemerce.DTO;
using Ecomemerce.Servicios.Implementacion;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecomemerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController(IDashboardServicio dashboardServicio) : ControllerBase
    {
        private readonly IDashboardServicio _dashboardServicio = dashboardServicio;

    

        [HttpGet("Resumen")]

        public IActionResult Resumen()
        {
            var response = new ResponseDTO<DashboardDTO>();

            try
            {


                response.EsCorrecto = true;
                response.Resultado =  _dashboardServicio.Resumen();
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }





    }
}
