using Domain.Entities;
using Domain.Repositories;
using Domain.Repositories.InterfaceServicos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace BlogApi.Controllers
{
    [ApiController]
    [Route("api/v1/usuarios")]
    public class UserController : ControllerBase
    {
        private readonly IUsuarioService _userService;
        private readonly IUsuario _userDomain;
        private readonly ILogger<UserController> _logger;

        public UserController(IUsuarioService userService, IUsuario Iusuario, ILogger<UserController> logger)
        {
            _userService = userService;
            _userDomain = Iusuario;
            _logger = logger;
        }

        [HttpGet("{userId}")]
        public IActionResult GetUserById(int userId)
        {
            var user = _userDomain.GetById(userId);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet("pesquisa")]
        public IActionResult GetUserByname(string userName)
        {
            var user = _userDomain.GetByName(userName);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(Usuario user)
        {
            await _userService.AddUser(user);
            return Ok(user);
        }

        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateUser(int userId, Usuario user)
        {
            var existingUser = _userDomain.GetById(userId);

            if (existingUser == null)
            {
                _logger.LogError("Pessoa não encontrada");
                return NotFound(); // Retorna 404 Not Found se a pessoa não existir
            }

            await _userService.UpdateUser(user);
            return Ok(user);
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUser(int userId, Usuario user)
        {
            var existingUser = _userDomain.GetById(userId);
            if (existingUser == null)
            {
                _logger.LogError("Pessoa não encontrada");

                return NotFound(); // Retorna 404 Not Found se a pessoa não existir.
            }

            await _userService.DeleteUser(user);
            return Ok();
        }
    }
}
