namespace InventarioProyecto.Modules.Inventario.Dtos
{
    public class ActualizarProductoDto
    {
        public string Sku { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public string Categoria { get; set; } = string.Empty;
    }
}