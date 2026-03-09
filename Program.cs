using LP2Parcial2;
using LP2Parcial2.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddSingleton(builder.Configuration);
var baseUrl = builder.Configuration["ApiSettings:BaseUrl"]
              ?? "https://localhost:7225";

builder.Services.AddScoped(sp =>
    new HttpClient { BaseAddress = new Uri(baseUrl) });

builder.Services.AddScoped<IProductoService, ProductoService>();

await builder.Build().RunAsync();