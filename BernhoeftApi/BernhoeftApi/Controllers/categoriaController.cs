using BernhoeftApi.Domains;
using BernhoeftApi.Interfaces;
using BernhoeftApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace BernhoeftApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class categoriaController : ControllerBase
    {
        private ICategoriaRespository _categoriaRepository { get; set; }

        public categoriaController()
        {
            _categoriaRepository = new categoriaRepository();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Post(Categoria novaCategoria)
        {
            try
            {
                _categoriaRepository.Cadastrar(novaCategoria);

                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }


        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_categoriaRepository.Listar());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [Authorize]
        [HttpGet("buscarporid{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_categoriaRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [Authorize]
        [HttpGet("situcao{situcao}")]
        public IActionResult GetBySituacao(bool situcao)
        {
            try
            {
                return Ok(_categoriaRepository.BuscarPorSitucao(situcao));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [Authorize]
        [HttpGet("descricao{descticao}")]
        public IActionResult GetByDescricao(string nome)
        {
            try
            {
                return Ok(_categoriaRepository.BuscarPorDescricao(nome));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [Authorize]
        [HttpPut("atucalizarcategoria{id}")]
        public IActionResult Put(int id, Categoria categoriaAtualizada)
        {
            try
            {
                _categoriaRepository.Atualizar(id, categoriaAtualizada);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [Authorize]
        [HttpDelete("deletarcategoria{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _categoriaRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [Authorize]
        [HttpGet("minhascatetegorias")]
        public IActionResult ListarMinhasCategorias()
        {
            try
            {

                int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(u => u.Type == JwtRegisteredClaimNames.Jti).Value);

                return Ok(_categoriaRepository.ListarMinhasCategorias(idUsuario));
            }
            catch (Exception erro)
            {
                return BadRequest(new
                {
                    mensagem = "Não é possível mostrar as consultas se o usuário não estiver logado!",
                    erro
                });
            }
        }
    }
}
