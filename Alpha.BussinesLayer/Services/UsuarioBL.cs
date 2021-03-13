using Alpha.BussinesLayer.Contracts;
using Alpha.BussinesLayer.Dto;
using Alpha.DataAccesLayer.Contracts;
using AutoMapper;

namespace Alpha.BussinesLayer.Services
{
    public class UsuarioBL : IUsuarioBL
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IRolRepository _rolRepository;
        private readonly IMapper _mapper;

        public UsuarioBL(IUsuarioRepository usuarioRepository, IRolRepository rolRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _rolRepository = rolRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Retorna la configuración de un usuario
        /// </summary>
        /// <param name="usuario">credenciales del usuario</param>
        /// <returns>Dto con la configuración del usuario</returns>
        public UsuarioResponseDto Get(UsuarioRequestDto usuario)
        {
            var user = _usuarioRepository.Get(usuario.Nombre, usuario.Contrasena);
            var rol = _rolRepository.Get(user.UsuarioId);
            var result = _mapper.Map<UsuarioResponseDto>(user);
            result.Rol = rol.Nombre;

            return result;
        }
    }
}
