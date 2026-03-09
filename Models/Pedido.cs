namespace LP2Parcial2.Models
{
    public class ItemCarrito
    {
        public Producto Producto { get; set; } = new();
        public int Cantidad { get; set; } = 1;
    }

    public class Pedido
    {
        public string NombreCliente { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Ubicacion { get; set; } = string.Empty;
        public string Comentarios { get; set; } = string.Empty;
        public double TotalFinal { get; set; }
        public bool DescuentoUsado { get; set; }
        public List<ItemCarrito> Items { get; set; } = new();
    }
}