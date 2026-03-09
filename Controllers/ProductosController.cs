using LP2Parcial2API.Data;
using LP2Parcial2API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LP2Parcial2API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductosController : ControllerBase
{
    private readonly AppDbContext _db;
    private readonly ILogger<ProductosController> _logger;

    public ProductosController(
        AppDbContext db,
        ILogger<ProductosController> logger)
    {
        _db = db;
        _logger = logger;
    }

    // GET api/productos
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Producto>>> GetAll()
    {
        _logger.LogInformation("[Productos] Obteniendo todos los productos.");
        return Ok(await _db.Productos.ToListAsync());
    }

    // GET api/productos/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Producto>> GetById(int id)
    {
        var producto = await _db.Productos.FindAsync(id);
        if (producto is null)
        {
            _logger.LogWarning("[Productos] Producto {Id} no encontrado.", id);
            return NotFound(new { mensaje = $"Producto {id} no encontrado." });
        }
        return Ok(producto);
    }

    // GET api/productos/categoria/Cakes
    [HttpGet("categoria/{categoria}")]
    public async Task<ActionResult<IEnumerable<Producto>>> GetByCategoria(string categoria)
    {
        var productos = await _db.Productos
            .Where(p => p.Category.ToLower() == categoria.ToLower())
            .ToListAsync();
        return Ok(productos);
    }

    // POST api/productos
    [HttpPost]
    public async Task<ActionResult<Producto>> Create(Producto producto)
    {
        producto.Id = 0;
        _db.Productos.Add(producto);
        await _db.SaveChangesAsync();
        _logger.LogInformation("[Productos] Creado: {Title}", producto.Title);
        return CreatedAtAction(nameof(GetById), new { id = producto.Id }, producto);
    }

    // PUT api/productos/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Producto producto)
    {
        if (id != producto.Id) return BadRequest();
        _db.Entry(producto).State = EntityState.Modified;
        await _db.SaveChangesAsync();
        return NoContent();
    }

    // DELETE api/productos/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var producto = await _db.Productos.FindAsync(id);
        if (producto is null) return NotFound();
        _db.Productos.Remove(producto);
        await _db.SaveChangesAsync();
        _logger.LogInformation("[Productos] Eliminado Id={Id}", id);
        return NoContent();
    }
}