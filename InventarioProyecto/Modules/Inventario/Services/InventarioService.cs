using InventarioProyecto.Modules.Inventario.Entities;
using InventarioProyecto.Modules.Inventario.Dtos;

namespace InventarioProyecto.Modules.Inventario.Services
{
    public class InventarioService
    {
        private static readonly List<Producto> _productosDb = new()
        {
            new Producto 
            { 
                Uuid = Guid.Parse("11111111-1111-1111-1111-111111111111"), 
                Sku = "PROD-TECH-4090", 
                Nombre = "Tarjeta Gráfica NVIDIA RTX 4090", 
                Precio = 1599.99m, 
                Stock = 14, 
                Categoria = "Componentes de Hardware",
                IsActive = true 
            }, 
            new Producto
            { 
                Uuid = Guid.Parse("22222222-2222-2222-2222-222222222222"), 
                Sku = "PROD-TECH-3090", 
                Nombre = "Tarjeta Gráfica NVIDIA RTX 3090", 
                Precio = 1499.99m, 
                Stock = 4, 
                Categoria = "Componentes de Hardware",
                IsActive = true 
            }
        };

        public List<Producto> GetAll() => _productosDb.Where(p => p.IsActive).ToList();

        public Producto? GetByUuid(Guid uuid) => _productosDb.FirstOrDefault(p => p.Uuid == uuid && p.IsActive);

        public Producto Create(CrearProductoDto dto)
        {
            var producto = new Producto
            {
                Uuid = Guid.NewGuid(),
                Sku = dto.Sku,
                Nombre = dto.Nombre,
                Precio = dto.Precio,
                Stock = dto.Stock,
                Categoria = dto.Categoria,
                IsActive = true
            };
            _productosDb.Add(producto);
            return producto;
        }

        public Producto? Update(Guid uuid, ActualizarProductoDto dto)
        {
            var producto = GetByUuid(uuid);
            if (producto == null) return null;

            producto.Sku = dto.Sku;
            producto.Nombre = dto.Nombre;
            producto.Precio = dto.Precio;
            producto.Stock = dto.Stock;
            producto.Categoria = dto.Categoria;

            return producto;
        }

        public bool Delete(Guid uuid)
        {
            var producto = GetByUuid(uuid);
            if (producto == null) return false;

            producto.IsActive = false;
            return true;
        }
    }
}