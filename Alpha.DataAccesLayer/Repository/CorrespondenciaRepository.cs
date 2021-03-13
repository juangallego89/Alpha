using Alpha.DataAccesLayer.Contracts;
using Alpha.DataAccesLayer.Entities;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Alpha.DataAccesLayer.Repository
{
    public class CorrespondenciaRepository : ICorrespondenciaRepository
    {
        private readonly string _connectionString;
        private readonly ILogger<CorrespondenciaRepository> _logger;

        public CorrespondenciaRepository(IConfiguration configuration, ILogger<CorrespondenciaRepository> logger)
        {
            _connectionString = configuration.GetConnectionString("AlphaDatabase");
            _logger = logger;
        }

        /// <summary>
        /// Obtiene el listado de todas las comunicaciones radicadas en el sistema
        /// </summary>
        /// <returns>Listado de todas las comunicaciones radicadas en el sistema</returns>
        public List<Correspondencia> Get(int take, int skip)
        {
            try
            {
                List<Correspondencia> correspondencia = new List<Correspondencia>();

                using (var db = new SqlConnection(_connectionString))
                {
                    correspondencia = db.GetAll<Correspondencia>()
                                    .Where(x => x.Activo)
                                    .Take(take)
                                    .Skip(skip)
                                    .ToList();
                }

                return correspondencia;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ArgumentException(ex.Message);
            }
        }

        /// <summary>
        /// Obtiene una comunicación por su número de radicado
        /// </summary>
        /// <param name="numeroRadicado">número de radicado de la comunicación</param>
        /// <returns>Comunicación radicada</returns>
        public Correspondencia Get(string numeroRadicado)
        {
            try
            {
                Correspondencia correspondencia = new Correspondencia();

                using (var db = new SqlConnection(_connectionString))
                {
                    correspondencia = db.GetAll<Correspondencia>()
                                    .Where(x => x.Activo && x.NumeroRadicado.Equals(numeroRadicado))
                                    .FirstOrDefault();
                }

                return correspondencia;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ArgumentException(ex.Message);
            }
        }

        /// <summary>
        /// Registra un comunicado en la base de datos
        /// </summary>
        /// <param name="correspondencia">data del comunicado a radicar</param>
        /// <returns>número de radicado de la comunicación</returns>
        public (string, int) Create(dynamic correspondencia)
        {
            try
            {
                using (var db = new SqlConnection(_connectionString))
                {
                    var p = new DynamicParameters();

                    p.Add("usuarioId", correspondencia.UsuarioId);
                    p.Add("remitenteId", correspondencia.RemitenteId);
                    p.Add("destinatarioId", correspondencia.DestinatarioId);
                    p.Add("fechaRadicacion", DateTime.Parse(correspondencia.FechaRadicacion));
                    p.Add("tipo", correspondencia.Tipo);
                    p.Add("estado", "Archivada");
                    p.Add("ruta", correspondencia.Archivo);
                    p.Add("numeroRadicado", dbType: DbType.String, direction: ParameterDirection.Output, size: 10);
                    p.Add("correspondenciaId", dbType: DbType.Int32, direction: ParameterDirection.Output);

                    db.Query<int>("COR.CrearCorrespondencia", p, commandType: CommandType.StoredProcedure);
                    string numeroRadicado = p.Get<string>("numeroRadicado");
                    int correspondenciaId = p.Get<int>("correspondenciaId");

                    return (numeroRadicado , correspondenciaId);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
