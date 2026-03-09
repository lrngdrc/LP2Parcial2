using LP2Parcial2API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LP2Parcial2API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<Producto> Productos => Set<Producto>();
    public DbSet<Pedido> Pedidos => Set<Pedido>();
    public DbSet<ItemPedido> ItemsPedido => Set<ItemPedido>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ItemPedido>()
            .HasOne(i => i.Pedido)
            .WithMany(p => p.Items)
            .HasForeignKey(i => i.PedidoId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Producto>().HasData(
     new Producto
     {
         Id = 1,
         Title = "Cheesecake de mango y manzana",
         Price = 550,
         Category = "Pasteles",
         Rating = 4.7,
         Thumbnail = "images/productos/pastelmango.jpg",
         Description = "Tope de mermelada de mango, manzana y almíbar."
     },
     new Producto
     {
         Id = 2,
         Title = "Pastel Red Velvet",
         Price = 650,
         Category = "Pasteles",
         Rating = 4.9,
         Thumbnail = "images/productos/pastelredvelvet.jpg",
         Description = "Relleno de crema pastelera con fresas en el tope."
     },
     new Producto
     {
         Id = 3,
         Title = "Pastel de fresa",
         Price = 650,
         Category = "Pasteles",
         Rating = 4.9,
         Thumbnail = "images/productos/pastelfresa.jpg",
         Description = "Relleno de fresas, crema pastelera y fresas en el tope."
     },
     new Producto
     {
         Id = 4,
         Title = "Pastel de chocolate",
         Price = 650,
         Category = "Pasteles",
         Rating = 4.9,
         Thumbnail = "images/productos/pastelchocolate.jpg",
         Description = "Relleno de crema pastelera con chocolate rallado en el tope."
     },
     new Producto
     {
         Id = 5,
         Title = "Donut de fresa",
         Price = 70,
         Category = "Donas",
         Rating = 4.4,
         Thumbnail = "images/productos/donutfresa.jpg",
         Description = "Relleno de mermelada de fresa. Azúcar glass en el tope."
     },
     new Producto
     {
         Id = 6,
         Title = "Donut glaseado",
         Price = 50,
         Category = "Donas",
         Rating = 4.2,
         Thumbnail = "images/productos/donutglaseado.jpg",
         Description = "Donut clásico con glaseado de azúcar."
     },
     new Producto
     {
         Id = 7,
         Title = "Donut de nutella",
         Price = 70,
         Category = "Donas",
         Rating = 4.8,
         Thumbnail = "images/productos/donutnutella.jpg",
         Description = "Relleno de nutella. Azúcar glass en el tope."
     },
     new Producto
     {
         Id = 8,
         Title = "Donut glaseado de fresa",
         Price = 50,
         Category = "Donas",
         Rating = 4.3,
         Thumbnail = "images/productos/donutglaseadofresa.jpg",
         Description = "Donut clásico de fresa con glaseado. Sprinkles en el tope."
     },
     new Producto
     {
         Id = 9,
         Title = "Waffle clásico",
         Price = 150,
         Category = "Waffles",
         Rating = 3.9,
         Thumbnail = "images/productos/wafflebasico.jpg",
         Description = "Waffle clásico con mantequilla en el tope."
     },
     new Producto
     {
         Id = 10,
         Title = "Waffle de chocolate",
         Price = 300,
         Category = "Waffles",
         Rating = 4.7,
         Thumbnail = "images/productos/wafflechocolate.jpg",
         Description = "Helado de vainilla y syrup de chocolate en el tope."
     },
     new Producto
     {
         Id = 11,
         Title = "Waffle de fresa",
         Price = 150,
         Category = "Waffles",
         Rating = 4.0,
         Thumbnail = "images/productos/wafflefresa.jpg",
         Description = "Fresas y syrup de maple en el tope."
     },
     new Producto
     {
         Id = 12,
         Title = "Waffle con helado",
         Price = 150,
         Category = "Waffles",
         Rating = 4.6,
         Thumbnail = "images/productos/wafflehelado.jpg",
         Description = "Helado de vainilla en el tope."
     }
   );
  }
}

