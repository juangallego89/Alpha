
using Alpha.DataAccesLayer.Entities;

namespace Alpha.DataAccesLayer.Contracts
{
    public interface IUsuarioRepository
    {
        /// <summary>
        /// Retorna la configuración de un usuario
        /// </summary>
        /// <param name="nombre">nombre de usuario</param>
        /// <param name="contrasena">contraseña</param>
        /// <returns>Entidad usuario</returns>
        Usuario Get(string nombre, string contrasena);
    }
}
