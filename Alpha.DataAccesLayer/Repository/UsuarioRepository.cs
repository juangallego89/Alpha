using Alpha.DataAccesLayer.Contracts;
using Alpha.DataAccesLayer.Entities;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Data.SqlClient;
using System.Linq;

namespace Alpha.DataAccesLayer.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly string _connectionString;
        private readonly ILogger<UsuarioRepository> _logger;

        public UsuarioRepository(IConfiguration configuration, ILogger<UsuarioRepository> logger)
        {
            _connectionString = configuration.GetConnectionString("AlphaDatabase");
            _logger = logger;
        }

        /// <summary>
        /// Retorna la configuración de un usuario
        /// </summary>
        /// <param name="nombre">nombre de usuario</param>
        /// <param name="contrasena">contraseña</param>
        /// <returns>Entidad usuario</returns>
        public Usuario Get(string nombre, string contrasena)
        {
            try
            {
                Usuario usuario = new Usuario();

                using (var db = new SqlConnection(_connectionString))
                {
                    usuario = db.GetAll<Usuario>()
                                    .Where(x => x.Activo
                                    && x.Nombre.Equals(nombre)
                                    && x.Contrasena.Equals(contrasena))
                                    .FirstOrDefault();
                }

                return usuario;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
