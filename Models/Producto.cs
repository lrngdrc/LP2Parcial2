namespace LP2Parcial2.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Price { get; set; }
        public string Category { get; set; } = string.Empty;
        public string Thumbnail { get; set; } = string.Empty;
        public double Rating { get; set; }
    }
    public class ProductosResponse
    {
        public List<Producto> Products { get; set; } = new();
    }
}
