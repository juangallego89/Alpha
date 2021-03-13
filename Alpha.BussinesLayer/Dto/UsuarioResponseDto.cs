using System.Collections.Generic;

namespace Alpha.BussinesLayer.Dto
{
    public class UsuarioResponseDto
    {
        /// <summary>
        /// Id del usuario ADM.Usuario
        /// </summary>
        public long UsuarioId { get; set; }

        /// <summary>
        /// Id de la persona asociada al usuario ADM.Persona
        /// </summary>
        public long PersonaId { get; set; }

        /// <summary>
        /// Nombre de usuario
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Rol que está asociado al usuario
        /// </summary>
        public string Rol { get; set; }
    }
}
