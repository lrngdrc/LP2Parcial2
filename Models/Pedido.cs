using System.ComponentModel.DataAnnotations;

namespace LP2Parcial2API.Models;

public class Pedido
{
    public int Id { get; set; }

    [Required, MaxLength(100)]
    public string NombreCliente { get; set; } = string.Empty;

    [Required, MaxLength(20)]
    public string Telefono { get; set; } = string.Empty;

    [MaxLength(200)]
    public string Ubicacion { get; set; } = string.Empty;

    [MaxLength(300)]
    public string Comentarios { get; set; } = string.Empty;

    public double TotalFinal { get; set; }
    public bool DescuentoUsado { get; set; }
    public DateTime FechaCreacion { get; set; } = DateTime.Now;
    public List<ItemPedido> Items { get; set; } = new();
}