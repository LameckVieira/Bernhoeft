using BernhoeftApi.Domains;
using BernhoeftApi.Interfaces;
using BernhoeftApi.Model.InputModels.Categoria;
using BernhoeftApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BernhoeftApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : BaseController
    {
        private ICategoriaRespository _categoriaRepository { get; set; }

        public CategoriaController()
        {
            _categoriaRepository = new CategoriaRepository();
        }

        [HttpPost]
        public IActionResult Post(CriarCategoriaInputModel novaCategoria)
        {
            try
            {
                Categoria categoria = new Categoria(base.PegarIdUsuario(), novaCategoria.Nome, novaCategoria.Situacao);

                _categoriaRepository.Cadastrar(categoria);

                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }


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

        [HttpGet("pegarid/{id}")]
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

        [HttpGet("buscarporsitucao/{situcao}")]
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

        [HttpGet("buscarpordescricao/{nome}")]
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


        [HttpPut("atualizarcategoria{id}")]
        public IActionResult Put(int id, AtualizarCategoriaInputModel categoriaAtualizada)
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
