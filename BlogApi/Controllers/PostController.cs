using Domain.Entities;
using Domain.Enuns;
using Domain.Repositories;
using Domain.Repositories.InterfaceServicos;
using Domain.Servicos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlogApi.Controllers
{
    [ApiController]
    [Route("api/v1/postagens")]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        private readonly IPosts _postDomain;
        private readonly ILogger<PostController> _logger;

        public PostController(IPostService postService, IPosts Ipost, ILogger<PostController> logger)
        {
            _postService = postService;
            _postDomain = Ipost;
            _logger = logger;
        }

        [HttpGet("{postId}")]
        public IActionResult GetPostById(int postId)
        {
            var post = _postDomain.GetById(postId);

            if (post == null)
                return NotFound();

            return Ok(post);
        }

        [HttpPost]
        public async Task<IActionResult> AddPost([FromBody] Post post)
        {
            // Obtenha informações de autenticação ou contexto do usuário (por exemplo, do token)
            var usuario = ObterInformacoesUsuario();

            try
            {
                await _postService.AddPost(usuario, post);
                return Ok(post);
            }
            catch (UsuarioNaoAutorizadoException ex)
            {
                _logger.LogError(ex, "Erro ao adicionar postagem: Usuário não autorizado.");
                return Unauthorized(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao adicionar postagem.");
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{postId}")]
        public async Task<IActionResult> UpdatePost(int postId, [FromBody] Post post)
        {
            // Obtenha informações de autenticação ou contexto do usuário (por exemplo, do token)
            var usuario = ObterInformacoesUsuario();

            try
            {
                await _postService.AtualizaPost(post, usuario);
                return Ok(post);
            }
            catch (EdicaoNaoPermitidaException ex)
            {
                _logger.LogError(ex, "Erro ao atualizar postagem: Edição não permitida.");
                return Forbid(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao atualizar postagem.");
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{postId}")]
        public async Task<IActionResult> DeletePost(int postId,Post post)
        {
            // Obtenha informações de autenticação ou contexto do usuário (por exemplo, do token)
            var usuario = ObterInformacoesUsuario();
            var postagem = _postDomain.GetById(postId);

            try
            {
                if (postagem == null)
                {
                    _logger.LogError("Post não encontrado");

                    return NotFound();
                }
                await _postService.DeletePost(post, usuario);
                return Ok();
            }
            catch (DelecaoNaoPermitidaException ex)
            {
                _logger.LogError(ex, "Erro ao excluir postagem: Deleção não permitida.");
                return Forbid(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao excluir postagem.");
                return BadRequest(ex.Message);
            }
        }

        private Usuario ObterInformacoesUsuario()
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var userType = Enum.Parse<TipoUser>(User.FindFirstValue(ClaimTypes.Role));

            return new Usuario
            {
                Id = userId,
                Tipo = userType
            };
        }


        [HttpGet("autor/{autorId}")]
        public async Task<IActionResult> GetPostsByAuthor(int autorId)
        {
            var posts = await _postDomain.GetPostsByAuthor(autorId);
            return Ok(posts);
        }

        [HttpGet("todos")]
        public async Task<IActionResult> GetAllPostsAsync()
        {
            var posts = await _postDomain.GetAllPostsAsync();
            return Ok(posts);
        }
    }
}
