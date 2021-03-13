using Alpha.BussinesLayer.Contracts;
using Alpha.BussinesLayer.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AlphaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacionController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUsuarioBL _usuarioBL;

        public AutenticacionController(IConfiguration config, IUsuarioBL usuarioBL)
        {
            _configuration = config;
            _usuarioBL = usuarioBL;
        }

        /// <summary>
        /// Valida las credenciales del usuario y genera un bearer token para consumir  los servicios del Api
        /// </summary>
        /// <param name="usuario">Dto con las credenciales del usuario</param>
        /// <returns>Token de autenticación</returns>
        [HttpPost]
        public IActionResult Autenticar(UsuarioRequestDto usuario)
        {
            if (string.IsNullOrEmpty(usuario.Nombre) || string.IsNullOrEmpty(usuario.Contrasena))
            {
                return StatusCode(StatusCodes.Status400BadRequest, "El nombre de usuario y contraseña son obligatorios.");
            }

            try
            {
                var user = _usuarioBL.Get(usuario);

                if (user == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Credenciales no válidas.");
                }

                var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("Id", user.UsuarioId.ToString()),
                    new Claim("Nombre", user.Nombre),
                    new Claim("Rol", user.Rol)
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var issuer = _configuration["Jwt:Issuer"];
                var audience = _configuration["Jwt:Audience"];
                var token = new JwtSecurityToken(issuer, audience, claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);
                var result = new JwtSecurityTokenHandler().WriteToken(token);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
