

using Alpha.BussinesLayer.Dto;

namespace Alpha.BussinesLayer.Contracts
{
    public interface IUsuarioBL
    {
        /// <summary>
        /// Retorna la configuración de un usuario
        /// </summary>
        /// <param name="usuario">credenciales del usuario</param>
        /// <returns>Dto con la configuración del usuario</returns>
        UsuarioResponseDto Get(UsuarioRequestDto usuario);
    }
}
