using Dapper.Contrib.Extensions;

namespace Alpha.DataAccesLayer.Entities
{
    [Table("ADM.Rol")]
    public class Rol : EntityBase
    {
        [Key]
        public long RolId { get; set; }
        public long UsuarioId { get; set; }
        public string Nombre { get; set; }
    }
}
