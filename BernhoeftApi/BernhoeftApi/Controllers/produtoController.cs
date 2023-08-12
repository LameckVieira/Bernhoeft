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
    public class produtoController : ControllerBase
    {
        private IProdutoRepository _produtoRepository { get; set; }

        public produtoController()
        {
            _produtoRepository = new produtoRepository();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Post(Produto novoProduto)
        {
            try
            {
                _produtoRepository.Cadastrar(novoProduto);

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
                return Ok(_produtoRepository.Listar());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [Authorize]
        [HttpGet("buscarporId{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_produtoRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [Authorize]
        [HttpGet("buscarporcategoriaid{id}")]
        public IActionResult GetBycategoriaId(int id)
        {
            try
            {
                return Ok(_produtoRepository.BuscarPorCategoria(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [Authorize]
        [HttpGet("descricao{descricao}")]
        public IActionResult GetbyDescricaoProduto(string descricao)
        {
            try
            {
                return Ok(_produtoRepository.BuscarPorDescricao(descricao));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [Authorize]
        [HttpGet("situacao{situacao}")]
        public IActionResult GetbySitucaoDoProduto(bool situacao)
        {
            try
            {
                return Ok(_produtoRepository.BuscarPorSitucao(situacao));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [Authorize]
        [HttpPut("atualizarprodudo{id}")]
        public IActionResult Put(int id, Produto produtoAtualizado)
        {
            try
            {
                _produtoRepository.Atualizar(id, produtoAtualizado);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [Authorize]
        [HttpDelete("deletarproduto{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _produtoRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [Authorize]
        [HttpGet("meusprodutos")]
        public IActionResult ListarMeusProdutos()
        {
            try
            {

                int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(u => u.Type == JwtRegisteredClaimNames.Jti).Value);

                return Ok(_produtoRepository.ListarMeusProdutos(idUsuario));
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
