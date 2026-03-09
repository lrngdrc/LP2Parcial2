using LP2Parcial2.Models;

namespace LP2Parcial2.Services
{
    public interface IProductoService
    {
        Task<List<Producto>> ObtenerProductosAsync();
    }
}