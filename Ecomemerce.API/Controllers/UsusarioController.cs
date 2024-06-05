﻿using Ecomemerce.DTO;
using Ecomemerce.Servicios.Implementacion;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecomemerce.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsusarioController(IUsuarioServicio usuarioServicio) : ControllerBase
{

    private readonly IUsuarioServicio _usuarioServicio = usuarioServicio;


    [HttpGet("lista/{rol:alpha}/{buscar:alpha?}")]

    public async Task<IActionResult> Lista(string rol, string buscar = "NA")
    {
        var response = new ResponseDTO<List<UsuarioDTO>>();

        try
        {
            if (buscar == "NA") buscar = "";

            response.EsCorrecto = true;
            response.Resultado = await _usuarioServicio.Lista(rol, buscar);
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
        var response = new ResponseDTO<UsuarioDTO>();

        try
        {
            

            response.EsCorrecto = true;
            response.Resultado = await _usuarioServicio.Obtener(Id);
        }
        catch (Exception ex)
        {
            response.EsCorrecto = false;
            response.Mensaje = ex.Message;
        }

        return Ok(response);
    }

    [HttpPost("Crear")]

    public async Task<IActionResult> Crear([FromBody]UsuarioDTO modelo)
    {
        var response = new ResponseDTO<UsuarioDTO>();

        try
        {


            response.EsCorrecto = true;
            response.Resultado = await _usuarioServicio.Crear(modelo);
        }
        catch (Exception ex)
        {
            response.EsCorrecto = false;
            response.Mensaje = ex.Message;
        }

        return Ok(response);
    }


    [HttpPost("Autorizacion")]

    public async Task<IActionResult> Autorizacion([FromBody] LoginDTO modelo)
    {
        var response = new ResponseDTO<SesionDTO>();

        try
        {


            response.EsCorrecto = true;
            response.Resultado = await _usuarioServicio.Autorizacion(modelo);
        }
        catch (Exception ex)
        {
            response.EsCorrecto = false;
            response.Mensaje = ex.Message;
        }

        return Ok(response);
    }


    [HttpPut("Editar")]

    public async Task<IActionResult> Editar([FromBody] UsuarioDTO modelo)
    {
        var response = new ResponseDTO<bool>();

        try
        {


            response.EsCorrecto = true;
            response.Resultado = await _usuarioServicio.Editar(modelo);
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
            response.Resultado = await _usuarioServicio.Eliminar(Id);
        }
        catch (Exception ex)
        {
            response.EsCorrecto = false;
            response.Mensaje = ex.Message;
        }

        return Ok(response);
    }

}
