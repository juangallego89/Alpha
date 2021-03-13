

using Alpha.BussinesLayer.Dto;
using System.Collections.Generic;

namespace Alpha.BussinesLayer.Contracts
{
    public interface ICorrespondenciaBL
    {
        /// <summary>
        /// Obtiene todas las comunicaciones radicadas en el sistema implementando paginación
        /// </summary>
        /// <param name="take">cantidad de registros</param>
        /// <param name="skip">siguientes registros</param>
        /// <returns>Listado de comunicaciones</returns>
        List<CorrespondenciaResponseDto> Get(int take, int skip);

        /// <summary>
        /// Obtiene una comunicación por su número de radicado
        /// </summary>
        /// <param name="numeroRadicado">número de radicado de la comunicación</param>
        /// <returns>Comunicación radicada</returns>
        CorrespondenciaResponseDto Get(string numeroRadicado);

        /// <summary>
        /// Registra un comunicado en la base de datos
        /// </summary>
        /// <param name="correspondencia">data del comunicado a radicar</param>
        /// <returns>Dto con la información del comunicado radicado</returns>
        CorrespondenciaResponseDto Create(CorrespondenciaRequestDto correspondencia);
    }
}
