using Alpha.DataAccesLayer.Contracts;
using Alpha.DataAccesLayer.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Alpha.DataAccesLayer
{
    public class ConfigurationDataAccesLayer
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<ICorrespondenciaRepository, CorrespondenciaRepository>();
        }
    }
}
