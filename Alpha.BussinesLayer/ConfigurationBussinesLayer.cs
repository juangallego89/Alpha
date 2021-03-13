using Alpha.DataAccesLayer;
using Alpha.DataAccesLayer.Contracts;
using Alpha.DataAccesLayer.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Alpha.BussinesLayer
{
    public class ConfigurationBussinesLayer
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<ICorrespondenciaRepository, CorrespondenciaRepository>();
            services.AddScoped<IRolRepository, RolRepository>();
            ConfigurationDataAccesLayer.ConfigureServices(services);
        }
    }
}
