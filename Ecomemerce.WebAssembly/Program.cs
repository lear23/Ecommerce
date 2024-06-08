using Blazored.LocalStorage;
using Blazored.Toast;
using CurrieTechnologies.Razor.SweetAlert2;
using Ecomemerce.WebAssembly;
using Ecomemerce.WebAssembly.Extensiones;
using Ecomemerce.WebAssembly.Servicios.Contrato;
using Ecomemerce.WebAssembly.Servicios.implementacion;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5087/api/") });


builder.Services.AddBlazoredLocalStorage();
builder.Services.AddBlazoredToast();


builder.Services.AddScoped<IUsuarioServicio, UsuarioServicio>();
builder.Services.AddScoped<ICategoriaServicio, CategoriaServicio>();
builder.Services.AddScoped<IProductoServicio, ProductoServicio>();
builder.Services.AddScoped<ICarritoServicio, CarritoServicio>();
builder.Services.AddScoped<IVentaServicio,VentaServicio>();
builder.Services.AddScoped<IDashboardServicio, DashboardServicio>();

builder.Services.AddSweetAlert2();


builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, AutenticacionExtension>();

await builder.Build().RunAsync();
