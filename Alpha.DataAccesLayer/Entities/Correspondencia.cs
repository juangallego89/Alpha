using Dapper.Contrib.Extensions;
using System;


namespace Alpha.DataAccesLayer.Entities
{
    [Table("COR.Correspondencia")]
    public class Correspondencia : EntityBase
    {
        [Key]
        public long CorrespondenciaId { get; set; }
        public string NumeroRadicado { get; set; }
        public DateTime FechaRadicacion { get; set; }
        public long RemitentePersonaId { get; set; }
        public long DestinatarioPersonaId { get; set; }
        public string Tipo { get; set; }
        public string Estado { get; set; }
    }
}
