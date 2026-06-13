using Microsoft.AspNetCore.Mvc;
using InventarioProyecto.Modules.Inventario.Services;
using InventarioProyecto.Modules.Inventario.Dtos;

namespace InventarioProyecto.Modules.Inventario.Controllers
{
    [ApiController]
    [Route("api/v1/productos")]
    public class InventarioController : ControllerBase
    {
        private readonly InventarioService _service;

        public InventarioController(InventarioService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_service.GetAll());

        [HttpGet("{uuid:guid}")]
        public IActionResult GetByUuid(Guid uuid)
        {
            var producto = _service.GetByUuid(uuid);
            return producto == null ? NotFound(new { message = "Recurso no encontrado." }) : Ok(producto);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CrearProductoDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Sku) || string.IsNullOrWhiteSpace(dto.Nombre))
            {
                return BadRequest(new { error = "El SKU y el nombre del producto son requeridos." });
            }

            if (dto.Precio <= 0 || dto.Stock < 0)
            {
                return BadRequest(new { error = "El precio debe ser mayor a 0 y el stock no puede ser negativo." });
            }

            var result = _service.Create(dto);
            return Created($"api/v1/productos/{result.Uuid}", result);
        }

        [HttpPut("{uuid:guid}")]
        public IActionResult Update(Guid uuid, [FromBody] ActualizarProductoDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Nombre))
            {
                return BadRequest(new { error = "El nombre del producto es obligatorio." });
            }

            var result = _service.Update(uuid, dto);
            return result == null ? NotFound(new { message = "Recurso no encontrado." }) : Ok(result);
        }

        [HttpDelete("{uuid:guid}")]
        public IActionResult Delete(Guid uuid)
        {
            return _service.Delete(uuid) ? Ok(new { message = "Producto eliminado correctamente." }) : NotFound(new { message = "Recurso no encontrado." });
        }
    }
}