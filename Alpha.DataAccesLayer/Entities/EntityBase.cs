using System;

namespace Alpha.DataAccesLayer.Entities
{
    public class EntityBase
    {
        public bool Activo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public long UsuarioCreaId { get; set; }
        public DateTime FechaModificacion { get; set; }
        public long UsuarioModificaId { get; set; }
    }
}
