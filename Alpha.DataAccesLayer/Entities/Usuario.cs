using Dapper.Contrib.Extensions;

namespace Alpha.DataAccesLayer.Entities
{
    [Table("ADM.Usuario")]
    public class Usuario : EntityBase
    {
        [Key]
        public long UsuarioId { get; set; }
        public long PersonaId { get; set; }
        public string Nombre { get; set; }
        public string Contrasena { get; set; }
    }
}
