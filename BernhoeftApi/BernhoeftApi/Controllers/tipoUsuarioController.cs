using BernhoeftApi.Domains;
using BernhoeftApi.Interfaces;
using BernhoeftApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BernhoeftApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class tipoUsuarioController : ControllerBase
    {
        // <summary>
        /// Objeto _ITipoUsuarioRepository que irá receber todos os métodos definidos na interface ITipoUsuarioRepository
        /// </summary>
        private ITipoUsuarioRepository _tipoUsuarioRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _ITipoUsuarioRepository para que haja a referência nos métodos implementadas no repositório TipoUsuarioRepository
        /// </summary>
        public tipoUsuarioController()
        {
            _tipoUsuarioRepository = new tipoUsuarioRepository();
        }

        /// <summary>
        /// Lista todos os tipo de usuário
        /// </summary>
        /// <returns>Uma lista de tipos de usuário e um status code 200 - Ok</returns>
        [HttpGet]
        public IActionResult Get()
        {
            // Retorna a resposta da requisição fazendo a chamada para o método
            return Ok(_tipoUsuarioRepository.Listar());
        }



        /// <summary>
        /// Atualiza um TipoUsuario existente
        /// </summary>
        /// <param name="id">ID do TipoUsuario que será atualizado</param>
        /// <param name="TipoUsuarioAtualizado">Objeto TipoUsuarioAtualizado com as novas informações</param>
        /// <returns>Um status code 204 - No Content</returns>

        [HttpPut("{id}")]
        public IActionResult Put(int id, TipoUsuario TipoUsuarioAtualizado)
        {
            // Faz a chamada para o método
            _tipoUsuarioRepository.Atualizar(id, TipoUsuarioAtualizado);

            // Retorna um status code
            return StatusCode(204);
        }

        /// <summary>
        /// Busca um TipoUsuario através do seu ID
        /// </summary>
        /// <param name="id">ID do TipoUsuario que será buscado</param>
        /// <returns>Um TipoUsuario encontrado e um status code 200 - Ok</returns>
        /// http://localhost:5000/api/tipoUsuarios/1

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {

            // Retorna a resposta da requisição fazendo a chamada para o método
            return Ok(_tipoUsuarioRepository.BuscarPorId(id));
        }

        /// <summary>
        /// Busca um TipoUsuario através do seu Tipo
        /// </summary>
        /// <param name="Tipo">Nome do TipoUsuario que será buscado</param>
        /// <returns>Um TipoUsuario encontrado em um status code 200 - OK</returns>
        /// http://localhost:5000/api/Usuarios/lameck

        [HttpGet("byname/{tipo}")]
        public IActionResult GetByTipo(string situacao)
        {
            return Ok(_tipoUsuarioRepository.BuscarPeloTipo(situacao));
        }

        /// <summary>
        /// Cadastra um novo TipoUsuario
        /// </summary>
        /// <param name="novoTipoUsuario">Objeto novoTipoUsuario que será cadastrado</param>
        /// <returns>Um status code 201 - Created</returns>
        /// 

        [HttpPost]
        public IActionResult Post(TipoUsuario novoTipoUsuario)
        {
            // Faz a chamada para o método
            _tipoUsuarioRepository.Cadastrar(novoTipoUsuario);

            // Retorna um status code
            return StatusCode(201);
        }

        /// <summary>
        /// Deleta um TipoUsuario existente
        /// </summary>
        /// <param name="id">ID do TipoUsuario que será deletado</param>
        /// <returns>Um status code 204 - No Content</returns>

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Faz a chamada para o método
            _tipoUsuarioRepository.Deletar(id);

            // Retorna um status code
            return StatusCode(200);
        }
    }
}
