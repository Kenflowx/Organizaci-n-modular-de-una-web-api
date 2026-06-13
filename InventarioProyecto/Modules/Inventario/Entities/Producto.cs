namespace InventarioProyecto.Modules.Inventario.Entities
{
    public class Producto
    {
        public Guid Uuid { get; set; }
        public string Sku { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public string Categoria { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
    }
}