using BernhoeftApi.Domains;
using BernhoeftApi.Interfaces;
using BernhoeftApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BernhoeftApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : BaseController
    {
        /// <summary>
        /// Objeto _UsuarioRepository que irá receber todos os métodos definidos na interface IUsuarioRepository
        /// </summary>
        private IUsuarioRepository _usuarioRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _UsuarioRepository para que haja a referência aos métodos no repositório
        /// </summary>
        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }


        [HttpPost]
        public IActionResult Login(Usuario login)
        {
            //Busca o usuário pelo e-mail e senha
            Usuario usuarioBuscado = _usuarioRepository.Login(login.Email, login.Senha);

            //Caso não encontre nenhum usuário com o e-mail e senha informados
            if (usuarioBuscado == null)
            {
                //retorna NotFound com uma mensagem personalizada
                return NotFound("E-mail ou senha inválidos!");
            }

            var tokenHandler = new JwtSecurityTokenHandler();

            //Caso encontre um token será criado

            //Dados fornceidos no token (Payload)
            var claims = new[]
            {
                                              //Tipo da claim + seu valor
                new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.UsuarioId.ToString()),
                new Claim("role", usuarioBuscado.TipoUsuarioId.ToString()),
                new Claim("name", usuarioBuscado.Nome),
                //new Claim(JwtRegisteredClaimNames.GivenName, usuarioBuscado.NomeUsuario)
            };

            //Chave de acesso do token          Valor codificado
            var key = new SymmetricSecurityKey(System.Text.Encoding.ASCII.GetBytes("lameck-teste-testeteste-chave-autenticacao"));

            //Credenciais do token
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //Gera o token 
            var token = new JwtSecurityToken(

                issuer: "BernhoeftApi",                     // emissor do token
                audience: "BernhoeftApi",                   // destinatário do token
                claims: claims,                             // dados de definidos "claims (linha 53)"
                expires: DateTime.Now.AddMinutes(45),       // tempo de expiração
                signingCredentials: creds                   // credenciais do token 

            );
            var tokenDescripton = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature),
                Subject = new ClaimsIdentity(claims),
            };

            var token2 = tokenHandler.CreateToken(tokenDescripton);
            var result = tokenHandler.WriteToken(token2);

            //Retorna um satus code 200 (Token foi criado)
            return Ok(new
            {
                token = result
            });
        }
    }
}
