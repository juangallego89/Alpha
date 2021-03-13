using Alpha.DataAccesLayer.Entities;
using System.Collections.Generic;

namespace Alpha.DataAccesLayer.Contracts
{
    public interface ICorrespondenciaRepository
    {
        /// <summary>
        /// Obtiene el listado de todas las comunicaciones radicadas en el sistema
        /// </summary>
        /// <returns>Listado de todas las comunicaciones radicadas en el sistema</returns>
        List<Correspondencia> Get(int take, int skip);

        /// <summary>
        /// Obtiene una comunicación por su número de radicado
        /// </summary>
        /// <param name="numeroRadicado">número de radicado de la comunicación</param>
        /// <returns>Comunicación radicada</returns>
        Correspondencia Get(string numeroRadicado);

        /// <summary>
        /// Registra un comunicado en la base de datos
        /// </summary>
        /// <param name="correspondencia">data del comunicado a radicar</param>
        /// <returns>número de radicado de la comunicación</returns>
        (string, int) Create(dynamic correspondencia);
    }
}
