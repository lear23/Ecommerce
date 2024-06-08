﻿


using Blazored.LocalStorage;
using Ecomemerce.DTO;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace Ecomemerce.WebAssembly.Extensiones;

public class AutenticacionExtension(ILocalStorageService localStorage, ClaimsPrincipal sinInformacion) : AuthenticationStateProvider
{
    private readonly ILocalStorageService _localStorage = localStorage;
    private ClaimsPrincipal _sinInformacion = sinInformacion;



    public async Task ActualizarEstadoAutenticacion(SesionDTO? sesionUsuario)
    {
        ClaimsPrincipal claimsPrincipal;

        if(sesionUsuario != null)
        {
            claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, sesionUsuario.IdUsuario.ToString()),
                new Claim(ClaimTypes.Name, sesionUsuario.NombreCompleto),
                new Claim(ClaimTypes.Email, sesionUsuario.Correo),
                new Claim(ClaimTypes.Role, sesionUsuario.Rol),
            },"JwtAuth"));

            await _localStorage.SetItemAsync("sesionUsuario", sesionUsuario);
        }
        else
        {
            claimsPrincipal = _sinInformacion;
            await _localStorage.RemoveItemAsync("sesionUsuario");
        }


        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var sesionUsuario = await _localStorage.GetItemAsync<SesionDTO>("sesionUsuario");
        if(sesionUsuario == null) 
        {
            return await Task.FromResult(new AuthenticationState(_sinInformacion));
        }

        var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, sesionUsuario.IdUsuario.ToString()),
                new Claim(ClaimTypes.Name, sesionUsuario.NombreCompleto),
                new Claim(ClaimTypes.Email, sesionUsuario.Correo),
                new Claim(ClaimTypes.Role, sesionUsuario.Rol),
            }, "JwtAuth"));

        return await Task.FromResult(new AuthenticationState(claimsPrincipal));
    }
}
