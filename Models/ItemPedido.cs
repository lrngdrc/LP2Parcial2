namespace LP2Parcial2API.Models;

public class ItemPedido
{
    public int Id { get; set; }
    public int PedidoId { get; set; }
    public string NombreProducto { get; set; } = string.Empty;
    public double PrecioUnitario { get; set; }
    public int Cantidad { get; set; }
    public Pedido? Pedido { get; set; }
}