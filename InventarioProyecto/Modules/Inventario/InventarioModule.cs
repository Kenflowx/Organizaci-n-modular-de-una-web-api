using InventarioProyecto.Modules.Inventario.Services;

namespace InventarioProyecto.Modules.Inventario
{
    public static class InventarioModule
    {
        public static IServiceCollection AddInventarioModule(this IServiceCollection services)
        {
            services.AddScoped<InventarioService>();
            return services;
        }
    }
}