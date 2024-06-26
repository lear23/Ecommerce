﻿using Ecomemerce.DTO;
using Ecomemerce.Servicios.Implementacion;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecomemerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController(IProductoServicio productoServicio) : ControllerBase
    {
        private readonly IProductoServicio _productoServicio = productoServicio;



        [HttpGet("lista/{buscar:alpha?}")]

        public async Task<IActionResult> Lista(string buscar = "NA")
        {
            var response = new ResponseDTO<List<ProductoDTO>>();

            try
            {
                if (buscar == "NA") buscar = "";

                response.EsCorrecto = true;
                response.Resultado = await _productoServicio.Lista(buscar);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }


        [HttpGet("Catalogo/{Categoria}/{buscar?}")]

        public async Task<IActionResult> Catalogo(string Categoria, string buscar = "NA")
        {
            var response = new ResponseDTO<List<ProductoDTO>>();

            try
            {
                if (Categoria.ToLower() == "todos") Categoria = "";
                if (buscar == "NA") buscar = "";

                response.EsCorrecto = true;
                response.Resultado = await _productoServicio.Catalogo(Categoria, buscar);
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
            var response = new ResponseDTO<ProductoDTO>();

            try
            {


                response.EsCorrecto = true;
                response.Resultado = await _productoServicio.Obtener(Id);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }

        [HttpPost("Crear")]

        public async Task<IActionResult> Crear([FromBody] ProductoDTO modelo)
        {
            var response = new ResponseDTO<ProductoDTO>();

            try
            {

                response.EsCorrecto = true;
                response.Resultado = await _productoServicio.Crear(modelo);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }


        [HttpPut("Editar")]
        public async Task<IActionResult> Editar([FromBody] ProductoDTO modelo)
        {
            var response = new ResponseDTO<bool>();

            try
            {
                response.Resultado = await _productoServicio.Editar(modelo);
                response.EsCorrecto = response.Resultado;
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = $"Error in Editar: {ex.Message}";
                Console.Error.WriteLine($"Error in Editar: {ex}");
            }

            return Ok(response);
        }

        [HttpDelete("Eliminar/{Id:int}")]
        public async Task<IActionResult> Eliminar(int Id)
        {
            var response = new ResponseDTO<bool>();

            try
            {
                response.Resultado = await _productoServicio.Eliminar(Id);
                response.EsCorrecto = response.Resultado;
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = $"Error in Eliminar: {ex.Message}";
                Console.Error.WriteLine($"Error in Eliminar: {ex}");
            }

            return Ok(response);
        }



    }
}
