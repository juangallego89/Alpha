using System;
using System.Collections.Generic;
using System.Text;

namespace Alpha.BussinesLayer.Dto
{
    public class CorrespondenciaRequestDto
    {
        /// <summary>
        /// Id de la persona remitente ADM.Persona
        /// </summary>
        public long RemitenteId { get; set; }

        /// <summary>
        /// Id de la persona remitente ADM.Persona
        /// </summary>
        public long DestinatarioId { get; set; }

        /// <summary>
        /// Fecha en que se radicó la comunicación
        /// </summary>
        public string FechaRadicacion { get; set; }

        /// <summary>
        /// Tipo de comnicación 
        /// CI - Interna
        /// CE - Externa
        /// </summary>
        public string Tipo { get; set; }

        /// <summary>
        /// Estado de la comunicación
        /// </summary>
        public string Estado { get; set; }

        /// <summary>
        /// Archivo de la comunicación en base64 
        /// </summary>
        public string Archivo { get; set; }

        /// <summary>
        /// Id del usuario que registra la comunicación
        /// </summary>
        public long UsuarioId { get; set; }
    }
}
