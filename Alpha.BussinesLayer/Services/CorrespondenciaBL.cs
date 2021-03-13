using Alpha.BussinesLayer.Contracts;
using Alpha.BussinesLayer.Dto;
using Alpha.DataAccesLayer.Contracts;
using Alpha.DataAccesLayer.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;

namespace Alpha.BussinesLayer.Services
{
    public class CorrespondenciaBL : ICorrespondenciaBL
    {
        private readonly ICorrespondenciaRepository _correspondenciaRepository;
        private readonly IMapper _mapper;

        public CorrespondenciaBL(ICorrespondenciaRepository correspondenciaRepository, IMapper mapper)
        {
            _correspondenciaRepository = correspondenciaRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Obtiene todas las comunicaciones radicadas en el sistema implementando paginación
        /// </summary>
        /// <param name="take">cantidad de registros</param>
        /// <param name="skip">siguientes registros</param>
        /// <returns>Listado de comunicaciones</returns>
        public List<CorrespondenciaResponseDto> Get(int take, int skip)
        {
            var listCorrespondencia = _correspondenciaRepository.Get(take, skip);
            var result = _mapper.Map<List<CorrespondenciaResponseDto>>(listCorrespondencia);

            return result;
        }

        /// <summary>
        /// Obtiene una comunicación por su número de radicado
        /// </summary>
        /// <param name="numeroRadicado">número de radicado de la comunicación</param>
        /// <returns>Comunicación radicada</returns>
        public CorrespondenciaResponseDto Get(string numeroRadicado)
        {
            var correspondencia = _correspondenciaRepository.Get(numeroRadicado);
            var result = _mapper.Map<CorrespondenciaResponseDto>(correspondencia);

            return result;
        }


        /// <summary>
        /// Registra un comunicado en la base de datos
        /// </summary>
        /// <param name="correspondencia">data del comunicado a radicar</param>
        /// <returns>Dto con la información del comunicado radicado</returns>
        public CorrespondenciaResponseDto Create(CorrespondenciaRequestDto correspondencia)
        {
            if (correspondencia.DestinatarioId < 1)
            {
                throw new ArgumentException("El destinatario no es válido");
            }

            if (correspondencia.RemitenteId < 1)
            {
                throw new ArgumentException("El remitente no es válido");
            }

            if (string.IsNullOrEmpty(correspondencia.FechaRadicacion))
            {
                throw new ArgumentException("La fecha de radicación es requerida.");
            }

            if (string.IsNullOrEmpty(correspondencia.Tipo))
            {
                throw new ArgumentException("El tipo de comunicación no es válido.");
            }

            if (string.IsNullOrEmpty(correspondencia.Archivo))
            {
                throw new ArgumentException("El archivo del documento a radicar es requerido.");
            }

            var radicado = _correspondenciaRepository.Create(correspondencia);

            var result = new CorrespondenciaResponseDto
            {
                NumeroRadicado = radicado.Item1,
                CorrespondenciaId = radicado.Item2,
            };

            return result;
        }
    }
}
