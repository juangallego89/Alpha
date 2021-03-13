namespace Alpha.BussinesLayer.Dto
{
    public class UsuarioRequestDto
    {
        /// <summary>
        /// Nombre de usuario para autenticarse en el api
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Contraseña de usuario para autenticarse en el api
        /// </summary>
        public string Contrasena { get; set; }
    }
}
