using Alpha.DataAccesLayer.Entities;

namespace Alpha.DataAccesLayer.Contracts
{
    public interface IRolRepository
    {
        /// <summary>
        /// Obtiene el rol de un usuario
        /// </summary>
        /// <param name="usuarioId">id del usuario</param>
        /// <returns>Rol del usuario</returns>
        Rol Get(long usuarioId);
    }
}