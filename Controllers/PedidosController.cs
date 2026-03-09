using LP2Parcial2API.Data;
using LP2Parcial2API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LP2Parcial2API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PedidosController : ControllerBase
{
    private readonly AppDbContext _db;
    private readonly ILogger<PedidosController> _logger;

    public PedidosController(
        AppDbContext db,
        ILogger<PedidosController> logger)
    {
        _db = db;
        _logger = logger;
    }

    // GET api/pedidos
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Pedido>>> GetAll()
    {
        var pedidos = await _db.Pedidos
            .Include(p => p.Items)
            .ToListAsync();
        return Ok(pedidos);
    }

    // GET api/pedidos/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Pedido>> GetById(int id)
    {
        var pedido = await _db.Pedidos
            .Include(p => p.Items)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (pedido is null)
        {
            _logger.LogWarning("[Pedidos] Pedido {Id} no encontrado.", id);
            return NotFound(new { mensaje = $"Pedido {id} no encontrado." });
        }
        return Ok(pedido);
    }

    // POST api/pedidos  ← Blazor llama a este endpoint al confirmar el pedido
    [HttpPost]
    public async Task<ActionResult<Pedido>> Create(Pedido pedido)
    {
        pedido.Id = 0;
        pedido.FechaCreacion = DateTime.Now;
        _db.Pedidos.Add(pedido);
        await _db.SaveChangesAsync();

        _logger.LogInformation(
            "[Pedidos] Nuevo pedido #{Id} de {Cliente} — Total: ${Total}",
            pedido.Id, pedido.NombreCliente, pedido.TotalFinal);

        return CreatedAtAction(nameof(GetById), new { id = pedido.Id }, pedido);
    }

    // DELETE api/pedidos/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var pedido = await _db.Pedidos.FindAsync(id);
        if (pedido is null) return NotFound();
        _db.Pedidos.Remove(pedido);
        await _db.SaveChangesAsync();
        return NoContent();
    }
}