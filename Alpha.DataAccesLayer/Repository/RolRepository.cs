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
    public class RolRepository : IRolRepository
    {
        private readonly string _connectionString;
        private readonly ILogger<RolRepository> _logger;

        public RolRepository(IConfiguration configuration, ILogger<RolRepository> logger)
        {
            _connectionString = configuration.GetConnectionString("AlphaDatabase");
            _logger = logger;
        }

        /// <summary>
        /// Obtiene el rol de un usuario
        /// </summary>
        /// <param name="usuarioId">id del usuario</param>
        /// <returns>Rol del usuario</returns>
        public Rol Get(long usuarioId)
        {
            try
            {
                Rol rol = new Rol();

                using (var db = new SqlConnection(_connectionString))
                {
                    rol = db.GetAll<Rol>()
                            .Where(x => x.Activo && x.UsuarioId.Equals(usuarioId))
                            .FirstOrDefault();
                }

                return rol;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
