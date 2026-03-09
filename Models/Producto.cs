using System.ComponentModel.DataAnnotations;

namespace LP2Parcial2API.Models;

public class Producto
{
    public int Id { get; set; }

    [Required, MaxLength(100)]
    public string Title { get; set; } = string.Empty;

    [MaxLength(300)]
    public string Description { get; set; } = string.Empty;

    public double Price { get; set; }

    [MaxLength(50)]
    public string Category { get; set; } = string.Empty;
    public string Thumbnail { get; set; } = string.Empty;
    public double Rating { get; set; }
}