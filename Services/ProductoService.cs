using System.Net.Http.Json;
using LP2Parcial2.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace LP2Parcial2.Services
{
    public class ProductoService : IProductoService
    {
        private readonly HttpClient _http;
        private readonly ILogger<ProductoService> _logger;
        private readonly IConfiguration _config;

        public ProductoService(
            HttpClient http,
            ILogger<ProductoService> logger,
            IConfiguration config)
        {
            _http = http;
            _logger = logger;
            _config = config;
        }

        public async Task<List<Producto>> ObtenerProductosAsync()
        {
            var endpoint = _config["ApiSettings:ProductosEndpoint"] ?? "/api/Productos";
            _logger.LogInformation("[ProductoService] Llamando a: {Endpoint}", endpoint);

            try
            {
                var productos = await _http
                    .GetFromJsonAsync<List<Producto>>(endpoint);

                return productos ?? new List<Producto>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "[ProductoService] Error al obtener productos.");
                return new List<Producto>();
            }
        }
    }
}