using Ecomemerce.DTO;
using Ecomemerce.Servicios.Implementacion;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecomemerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {

        private readonly ICategoriaServicio _categoriaServicio;

        public CategoriaController(ICategoriaServicio categoriaServicio)
        {
            _categoriaServicio = categoriaServicio;
        }


        [HttpGet("lista/{buscar:alpha?}")]

        public async Task<IActionResult> Lista(string buscar = "NA")
        {
            var response = new ResponseDTO<List<CategoriDTO>>();

            try
            {
                if (buscar == "NA") buscar = "";

                response.EsCorrecto = true;
                response.Resultado = await _categoriaServicio.Lista(buscar);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }

        [HttpGet("Obtener/{Id:int}")]

        public async Task<IActionResult> Obtener(int Id)
        {
            var response = new ResponseDTO<CategoriDTO>();

            try
            {


                response.EsCorrecto = true;
                response.Resultado = await _categoriaServicio.Obtener(Id);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }

        [HttpPost("Crear")]

        public async Task<IActionResult> Crear([FromBody] CategoriDTO modelo)
        {
            var response = new ResponseDTO<CategoriDTO>();

            try
            {

                response.EsCorrecto = true;
                response.Resultado = await _categoriaServicio.Crear(modelo);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }     


        [HttpPut("Editar")]

        public async Task<IActionResult> Editar([FromBody] CategoriDTO modelo)
        {
            var response = new ResponseDTO<bool>();

            try
            {


                response.EsCorrecto = true;
                response.Resultado = await _categoriaServicio.Editar(modelo);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }



        [HttpDelete("Eliminar/{Id:int}")]

        public async Task<IActionResult> Eliminar(int Id)
        {
            var response = new ResponseDTO<bool>();

            try
            {


                response.EsCorrecto = true;
                response.Resultado = await _categoriaServicio.Eliminar(Id);
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
